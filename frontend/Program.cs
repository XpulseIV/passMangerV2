using backend;
using backend.enc_dec;

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
                    case 4:
                        Login(args[1], args[2], args[3]);
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

        private static void Login(string userName = "", string masterPass = "", string fileName = "")
        {
            if (userName == "")
            {
                userName = Asker.ForceInput("Enter username: ");
                masterPass = Asker.GetPassword("Enter master password: ");
            }
            else if (masterPass == "")
            {
                masterPass = Asker.GetPassword("Enter master password: ");
            }

            if (fileName == "") fileName = Asker.AskUser("Enter name of file");

            
            
            var user = FilerDeluxe.LoadUser(fileName, passKey);
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