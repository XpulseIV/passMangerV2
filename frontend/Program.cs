using backend;

namespace frontend
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Argument support
            if (args.Length > 0)
            {
                if ((args[0] == "login") || (args[0] == "l")) // Argument login
                {
                    switch (args.Length)
                    {
                    case 1:
                        Login();
                        break;
                    case 2: // Username added
                        Login(args[1]);
                        break;
                    case 3: // Username and password added
                        Login(args[1], args[2]);
                        break;
                    }
                }

                if ((args[0] == "create") || (args[0] == "c"))
                {
                    Creator.CreateUser();
                }
            }

            // Default startup
            Console.WriteLine("----------------------------------\n" +
                              "Press 'l' to log in to a user\n" +
                              "Press 'c' to create a new user\n" +
                              "Press 'x' to exit");
            switch (Asker.ForceKey(">", "lcx"))
            {
            case "l":
                Login();
                break;
            case "c":
                MainLoop(Creator.CreateUser());
                break;
            case "x":
                return;
            }
        }

        private static void Login(string userName = "", string masterPass = "")
        {
            while (true) // Loop instead of recursion to prevent stack overflow since User can be big
            {
                // Asking for things that are not passed in
                if (userName == "")
                {
                    userName = Asker.ForceInput("Enter username: ");
                    masterPass = Asker.GetPassword("Enter master password: ");
                }
                else if (masterPass == "")
                {
                    masterPass = Asker.GetPassword("Enter master password: ");
                }

                // Hash the master password after making sure it exists
                masterPass = PassHasher.HashString(masterPass);

                try
                {
                    var user = XmlFilerDeluxe.LoadUser(userName + ".user", PassHasher.GetEncryptionKey(masterPass));
                    if (masterPass == user.MasterPassword)
                        MainLoop(user);
                    else
                    {
                        Console.WriteLine("Incorrect credentials. Please retry");
                        userName = "";
                        masterPass = "";
                        
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("User not found. Please retry");
                    userName = "";
                    masterPass = "";
                }
            }
        }

        private static void Help()
        {
            Console.WriteLine("\n" +
                              "--------------Help Menu--------------" +
                              "'h' Display this message" +
                              "'v' View credential" +
                              "'x' Save and exit program" +
                              "-------------------------------------"
            );
        }

        private static void MainLoop(User user)
        {
            
        }
    }
}