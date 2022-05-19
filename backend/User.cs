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

        public User? Encrypt(string keyStr)
        {
            User? user = new()
            {
                Name = AesImpl.EncryptString(this.Name, keyStr),
                Email = AesImpl.EncryptString(this.Email, keyStr),
                MasterPassword = AesImpl.EncryptString(this.MasterPassword, keyStr)
            };

            foreach (var detail in ExtraDetails)
            {
                var newDetailName = AesImpl.EncryptString(detail.Name, keyStr);
                var newDetailValue = AesImpl.EncryptString(detail.Value, keyStr);

                user.ExtraDetails.Add(new Detail(newDetailName, newDetailValue));
            }

            foreach (var credential in Credentials)
            {
                var newCredentialName = AesImpl.EncryptString(credential.Name, keyStr);
                var newCredentialUrl = AesImpl.EncryptString(credential.Url, keyStr);

                var newCredentialUserName = AesImpl.EncryptString(credential.UserName, keyStr);
                var newCredentialEmail = AesImpl.EncryptString(credential.Email, keyStr);
                var newCredentialPassword = AesImpl.EncryptString(credential.Password, keyStr);

                user.Credentials.Add(new Credential(newCredentialName, newCredentialUrl, newCredentialUserName, newCredentialEmail, newCredentialPassword));
            }

            foreach (var key in Keys)
            {
                var newKeyName = AesImpl.EncryptString(key.Name, keyStr);
                var newKeyUrl = AesImpl.EncryptString(key.Url, keyStr);
                var newKeyKeyString = AesImpl.EncryptString(key.KeyString, keyStr);

                user.Keys.Add(new Key(newKeyName, newKeyUrl, newKeyKeyString));
            }

            return user;
        }

        internal User Decrypt(string keyStr)
        {
            User? user = new()
            {
                Name = AesImpl.DecryptString(this.Name, keyStr),
                Email = AesImpl.DecryptString(this.Email, keyStr),
                MasterPassword = AesImpl.DecryptString(this.MasterPassword, keyStr)
            };

            foreach (var detail in ExtraDetails)
            {
                var newDetailName = AesImpl.DecryptString(detail.Name, keyStr);
                var newDetailValue = AesImpl.DecryptString(detail.Value, keyStr);

                user.ExtraDetails.Add(new Detail(newDetailName, newDetailValue));
            }

            foreach (var credential in Credentials)
            {
                var newCredentialName = AesImpl.DecryptString(credential.Name, keyStr);
                var newCredentialUrl = AesImpl.DecryptString(credential.Url, keyStr);

                var newCredentialUserName = AesImpl.DecryptString(credential.UserName, keyStr);
                var newCredentialEmail = AesImpl.DecryptString(credential.Email, keyStr);
                var newCredentialPassword = AesImpl.DecryptString(credential.Password, keyStr);

                user.Credentials.Add(new Credential(newCredentialName, newCredentialUrl, newCredentialUserName, newCredentialEmail, newCredentialPassword));
            }

            foreach (var key in Keys)
            {
                var newKeyName = AesImpl.DecryptString(key.Name, keyStr);
                var newKeyUrl = AesImpl.DecryptString(key.Url, keyStr);
                var newKeyKeyString = AesImpl.DecryptString(key.KeyString, keyStr);

                user.Keys.Add(new Key(newKeyName, newKeyUrl, newKeyKeyString));
            }

            return user;
        }
    }
}