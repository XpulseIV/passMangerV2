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

                    MainLoop(user, user.Name + ".user", PassHasher.GetEncryptionKey(user.MasterPassword));
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
                var user = Creator.CreateUser();

                MainLoop(user, user.Name + ".user", PassHasher.GetEncryptionKey(user.MasterPassword));
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

            var passKey = PassHasher.GetEncryptionKey(masterPass);

            var user = XmlFilerDeluxe.LoadUser(userName + ".user", passKey);

            while (masterPass != user.MasterPassword)
            {
                masterPass = PassHasher.HashString(Asker.GetPassword("Enter master password: "));
            }

            MainLoop(user, userName + ".user", passKey);
        }

        private static void Help()
        {
            Console.WriteLine("\n" +
                              "--------------Help Menu--------------\n" +
                              "'h' Display this message\n" +
                              "'l' List possible selections\n" +
                              "'s' Select object\n" +
                              "'m' Modify selected object\n" +
                              "'a' Add a new object of specification\n" +
                              "'r' Remove selected object\n" +
                              "'x' Save and exit program\n" +
                              "-------------------------------------"
            );
        }

        private static void MainLoop(User? user, string fileName, string passKey)
        {
            Console.WriteLine("Logged in to: " + user.Name +
                              " \nType h to see what options are available");

            var selectedDetailIndex = new int();
            var selectedCredentialIndex = new int();
            var selectedKeyIndex = new int();

            var running = true;
            while (running)
            {
                switch (Asker.ForceKey(">", "HLSMARXhlsmarx"))
                {
                case "H" or "h":
                    Help();
                    break;
                case "L" or "l":
                    var modeList = Asker.ForceKey("Enter listing mode, ([D]etail, [C]redential [K]ey): ", "DCKdck");

                    switch (modeList)
                    {
                    case "D" or "d":
                        Console.WriteLine("Listing all details");

                        foreach (var detail in user.ExtraDetails)
                        {
                            Console.WriteLine(detail.Name);
                        }

                        break;

                    case "C" or "c":
                        Console.WriteLine("Listing all credentials");

                        foreach (var credential in user.Credentials)
                        {
                            Console.WriteLine(credential.Name);
                        }

                        break;
                    case "K" or "k":
                        Console.WriteLine("Listing all keys");

                        foreach (var key in user.Keys)
                        {
                            Console.WriteLine(key.Name);
                        }

                        break;
                    }

                    break;
                case "S" or "s":
                    var modeSelect = Asker.ForceKey("Enter selection mode, ([D]etail, [C]redential [K]ey): ", "DCKdck");
                    switch (modeSelect)
                    {
                    case "D" or "d":
                        var detailName = Asker.AskUser("Enter name of detail: ");

                        for (var i = 0; i < user.ExtraDetails.Count; i++)
                        {
                            if (user.ExtraDetails[i].Name != detailName) continue;

                            selectedDetailIndex = i;
                            selectedCredentialIndex = int.MaxValue;
                            selectedKeyIndex = int.MaxValue;
                        }

                        break;
                    case "C" or "c":
                        var credentialName = Asker.AskUser("Enter name of credential: ");

                        for (var i = 0; i < user.ExtraDetails.Count; i++)
                        {
                            if (user.Credentials[i].Name != credentialName) continue;

                            selectedDetailIndex = int.MaxValue;
                            selectedCredentialIndex = i;
                            selectedKeyIndex = int.MaxValue;
                        }

                        break;
                    case "K" or "k":
                        var keyName = Asker.AskUser("Enter name of key: ");

                        for (var i = 0; i < user.Keys.Count; i++)
                        {
                            if (user.Keys[i].Name != keyName) continue;

                            selectedDetailIndex = int.MaxValue;
                            selectedCredentialIndex = int.MaxValue;
                            selectedKeyIndex = i;
                        }

                        break;
                    }

                    break;

                case "M" or "m": // Modifying selected object
                    if (selectedDetailIndex != int.MaxValue)
                    {
                        var whatToModify = Asker.ForceKey("Enter what in selected detail to modify ([N]ame, [V]alue): ", "NVnv");

                        switch (whatToModify)
                        {
                        case "N" or "n":
                            user.ExtraDetails[selectedDetailIndex].Name = Asker.AskUser("Enter new name: ");
                            break;
                        case "V" or "v":
                            user.ExtraDetails[selectedDetailIndex].Value = Asker.AskUser("Enter new Value: ");
                            break;
                        }

                        selectedDetailIndex = int.MaxValue; // Why unselect?
                    }

                    else if (selectedCredentialIndex != int.MaxValue)
                    {
                        var whatToModify = Asker.ForceKey("Enter what in credential to modify ([N]ame, [U]rl, U[S]erName, [E]mail, [P]assword): ", "NUSEPnusep");

                        switch (whatToModify)
                        {
                        case "N" or "n":
                            user.ExtraDetails[selectedDetailIndex].Name = Asker.AskUser("Enter new name: ");
                            break;
                        case "U" or "u":
                            user.Credentials[selectedCredentialIndex].Url = Asker.AskUser("Enter new url: ");
                            break;
                        case "S" or "s":
                            user.Credentials[selectedCredentialIndex].UserName = Asker.AskUser("Enter new username: ");
                            break;
                        case "E" or "s":
                            user.Credentials[selectedCredentialIndex].Email = Asker.AskUser("Enter new email: ");
                            break;
                        case "P" or "p":
                            user.Credentials[selectedCredentialIndex].Password = Asker.AskUser("Enter new password: ");
                            break;
                        }

                        selectedCredentialIndex = int.MaxValue;
                    }

                    else if (selectedKeyIndex != int.MaxValue)
                    {
                        var whatToModify = Asker.ForceKey("Enter what in credential to modify ([N]ame, [U]rl, [K]ey): ", "NUKnuk");
                        
                        switch (whatToModify)
                        {
                            case "N" or "n":
                                user.Keys[selectedKeyIndex].Name = Asker.AskUser("Enter new name: ");
                                break;
                            case "U" or "u":
                                user.Keys[selectedKeyIndex].Url = Asker.AskUser("Enter new url: ");
                                break;
                            case "K" or "k":
                                user.Keys[selectedKeyIndex].KeyString = Asker.AskUser("Enter new key: ");
                                break;
                        }
                        
                        selectedKeyIndex = int.MaxValue;
                    }

                    break;

                case "A" or "a":
                    var objectTypeAdd = Asker.ForceKey("Enter object type, ([D]etail, [C]redential [K]ey): ", "DCKdck");

                    switch (objectTypeAdd)
                    {
                    case "D" or "d":
                        user.ExtraDetails.Add(Creator.CreateDetail());
                        break;
                    case "C" or "c":
                        user.Credentials.Add(Creator.CreateCredential());
                        break;
                    case "K" or "k":
                        user.Keys.Add(Creator.CreateKey());
                        break;
                    }

                    break;
                case "R" or "r":
                    if (selectedDetailIndex != int.MaxValue)
                    {
                        user.ExtraDetails.Remove(user.ExtraDetails[selectedDetailIndex]);
                        selectedDetailIndex = int.MaxValue;
                    }

                    else if (selectedCredentialIndex != int.MaxValue)
                    {
                        user.Credentials.Remove(user.Credentials[selectedCredentialIndex]);
                        selectedCredentialIndex = int.MaxValue;
                    }

                    else if (selectedKeyIndex != int.MaxValue)
                    {
                        user.Keys.Remove(user.Keys[selectedKeyIndex]);
                        selectedKeyIndex = int.MaxValue;
                    }

                    break;

                case "X" or "x":
                    XmlFilerDeluxe.SaveUser(fileName, user, passKey);
                    running = false;
                    break;
                }
            }
        }
    }
}
