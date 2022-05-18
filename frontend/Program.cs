using System;
using System.IO;
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
                        Environment.Exit(0);
                        break;
                    case 2: // Username added
                        Login(args[1]);
                        Environment.Exit(0);
                        break;
                    case 3: // Username and password added
                        Login(args[1], args[2]);
                        Environment.Exit(0);
                        break;
                    }
                }

                if ((args[0] == "create") || (args[0] == "c"))
                {
                    var user = Creator.CreateUser();
                    MainLoop(user);
                    Environment.Exit(0);
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
                Environment.Exit(0);
                break;
            case "c":
                MainLoop(Creator.CreateUser());
                Environment.Exit(0);
                break;
            case "x":
                Environment.Exit(0);
                return;
            }
        }

        private static void Login(string userName = "", string masterPass = "")
        {
            // Asking for the things that are not passed in
            if (userName == "")
            {
                userName = Asker.ForceInput("Enter username: ");
                masterPass = Asker.GetPassword("Enter master password: ");
            }
            else if (masterPass == "")
            {
                masterPass = Asker.GetPassword("Enter master password: ");
            }

            while (!File.Exists(userName + ".user"))
            {
                userName = Asker.ForceInput("Enter username: ");
            }

            // Hash the master password after making sure it exists
            masterPass = PassHasher.HashString(masterPass);

            var user = XmlFilerDeluxe.LoadUser(userName + ".user", PassHasher.GetEncryptionKey(masterPass));

            while (masterPass != user.MasterPassword)
            {
                masterPass = PassHasher.HashString(Asker.GetPassword("Enter master password: "));
            }

            Program.MainLoop(user);
        }

        private static void Help()
        {
            Console.WriteLine("\n" +
                              "--------------Help Menu--------------" +
                              "'h' Display this message" +
                              "'x' Save and exit program" +
                              "-------------------------------------"
            );
        }

        private static void MainLoop(User user)
        {
            Console.WriteLine("Logged in to: " + user.Name +
                              " \nType h to see what options are available");
            
            var SelectedDetail = new Detail();
            var SelectedCredential = new Credential();
            var selectedKey = new Key();
            
            var running = true;
            while (running)
            {
            A                      
            }
        }
    }
}
