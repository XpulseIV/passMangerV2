using backend;

namespace frontend;

internal static class Program
{
    private static void Main(string[] args)
    {
        // Argument support
        if (args.Length > 0)
        {
            if (args[0] == "login" || args[0] == "l") // Argument login
            {
                switch (args.Length)
                {
                    case 2: // Username added
                        Login(args[1]);
                        break;
                    case 3: // Username and password added
                        Login(args[1], args[2]);
                        break;
                }
            }

            if (args[0] == "create" || args[0] == "c")
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

    private static void Login(string username = "", string masterPass = "")
    {
        if (username == "")
        {
            username = Asker.ForceInput("Enter username: ");
            masterPass = Asker.GetPassword("Enter master password: ");
        }
        else if (masterPass == "")
        {
            masterPass = Asker.GetPassword("Enter master password: ");
        }

        masterPass = PassHasher.HashString(masterPass);
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
        Console.WriteLine("Successfully logged in as " + user.Name);
        Console.WriteLine("Press 'h' to display help menu");
        var run = true;
        while (run)
        {
            var input = Asker.ForceKey(">", "hvx");

            switch (input)
            {
                case "h":
                    Help();
                    break;
                case "v":
                    ViewCredential(user.Credentials);
                    break;
                case "x":
                    run = false;
                    break;
            }
        }
        new Filer(user.Name + ".user").SaveUser(user);
    }

    private static void ViewCredential(List<Credential> credentials)
    {
        var search = Asker.ForceInput("Enter credential name: ");
        credentials.Find(x => x.Name.Contains(search));
    }
}