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
                
            }
        }

        // Default startup
        Console.WriteLine("----------------------------------\n" + 
                          "Press l to log in to a user\n" +
                          "Press c to create a new user\n" + 
                          "Press x to exit");
        switch (Asker.ForceKey(">"))
        {
            case "l":
                Login();
                break;
            case "c":
                CreateUser();
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
            masterPass = Asker.ForceInput("Enter master password: ");
        }

        if (masterPass == "")
        {
            masterPass = Asker.ForceInput("Enter master password: ");
        }
    }

    private static void CreateUser()
    {
        Console.WriteLine("Creating new user");
    }
}