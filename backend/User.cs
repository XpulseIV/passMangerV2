namespace backend
{
    [Serializable]
    public sealed class User
    {
        public string Name;
        public string Email;
        public string MasterPassword;
        public List<Detail> ExtraDetails;
        public List<Credential> Credentials;
        public List<Key> Keys;

        public User(string name, string email, string masterPassword, List<Detail> extraDetails,
            List<Credential> credentials, List<Key> keys)
        {
            Name = name;
            Email = email;
            MasterPassword = masterPassword;
            ExtraDetails = extraDetails;
            Credentials = credentials;
            Keys = keys;
        }

        public User()
        {
            Name = "";
            Email = "";
            MasterPassword = "";
            ExtraDetails = new List<Detail>();
            Credentials = new List<Credential>();
            Keys = new List<Key>();
        }

        public void Display()
        {
            var userInfoStr = "# User info #\n" +
                              "Name: " + Name + "\n" +
                              "Email: " + Email + "\n" +
                              "masterPassword: " + MasterPassword + "\n" +
                              "\n# Extra details #";

            if (ExtraDetails.Count != 0)
            {
                var count = 1;
                foreach (var detail in ExtraDetails)
                {
                    userInfoStr += "\nDetail " + count + ": " + detail.Name + ", " + detail.Value + "\n";
                    count++;
                }
            }

            if (Credentials.Count != 0)
            {
                var count = 1;
                foreach (var credential in Credentials)
                {
                    userInfoStr += "\nCredential " + count + ": " + credential.Name + ", " + credential.Url + ", " +
                                   credential.UserName + ", " + credential.Email + ", " + credential.Password + "\n";
                    count++;
                }
            }

            if (Keys.Count != 0)
            {
                var count = 1;
                foreach (var key in Keys)
                {
                    userInfoStr += "\nKey " + count + ": " + key.Name + ", " + key.Url + ", " + key.KeyString + "\n";
                    count++;
                }
            }

            Console.WriteLine(userInfoStr);
        }
    }
}