using System;
using System.Collections.Generic;
using backend;

namespace frontend
{
    internal static class Creator
    {
        public static User CreateUser()
        {
            var name = Asker.ForceInput("Enter username: ");
            var email = Asker.AskUser("Enter email: ");
            var masterPassword = PassHasher.HashString(Asker.ForceInput("Enter master password: "));
            var details = CreateDetailList();
            var credentials = CreateCredentialList();
            var keys = CreateKeyList();

            return new User(name, email, masterPassword, details, credentials, keys);
        }

        private static List<Detail> CreateDetailList()
        {
            var details = new List<Detail>();

            Console.WriteLine("Creating details. Press 'x' to skip");
            var go = Console.ReadKey().KeyChar != 'x';
            while (go)
            {
                details.Add(CreateDetail());
                go = Asker.ForceKey("Add more details? [y,n]: ", "yn") == "y";
            }

            return details;
        }

        private static Detail CreateDetail()
        {
            return new Detail(
                Asker.AskUser("Enter detail name: "),
                Asker.AskUser("Enter detail value: "));
        }

        private static List<Credential> CreateCredentialList()
        {
            var credentials = new List<Credential>();

            Console.WriteLine("Creating credentials. Press 'x' to skip");
            var go = Console.ReadKey().KeyChar != 'x';
            while (go)
            {
                credentials.Add(CreateCredential());
                go = Asker.ForceKey("Add more credentials? [y,n]: ", "yn") == "y";
            }

            return credentials;
        }

        private static Credential CreateCredential()
        {
            return new Credential(
                Asker.AskUser("Enter credential name: "),
                Asker.AskUser("Enter credential url: "),
                Asker.AskUser("Enter credential username: "),
                Asker.AskUser("Enter credential email: "),
                Asker.AskUser("Enter credential password: "));
        }

        private static List<Key> CreateKeyList()
        {
            var keys = new List<Key>();

            Console.WriteLine("Creating keys. Press 'x' to skip");
            var go = Console.ReadKey().KeyChar != 'x';
            while (go)
            {
                keys.Add(CreateKey());
                go = Asker.ForceKey("Add more keys? [y,n]: ", "yn") == "y";
            }

            return keys;
        }

        private static Key CreateKey()
        {
            return new Key(
                Asker.AskUser("Enter key name: "),
                Asker.AskUser("Enter key url: "),
                Asker.AskUser("Enter key contents: "));
        }
    }
}