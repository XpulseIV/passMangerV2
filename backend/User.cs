using backend.enc_dec;

namespace backend
{
    public sealed class User
    {
        internal string Name { get; private set; }
        internal string Email { get; private set; }
        internal string MasterPassword { get; private set; }
        internal List<Detail> ExtraDetails { get; }
        internal List<Credential> Credentials { get; }
        internal List<Key> Keys { get; }

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

        internal void Encrypt(int[] passKey)
        {
            Name = Encrypter.EncryptString(Name, passKey);
            Email = Encrypter.EncryptString(Email, passKey);
            MasterPassword = Encrypter.EncryptString(MasterPassword, passKey);

            foreach (var detail in ExtraDetails)
            {
                detail.Name = Encrypter.EncryptString(detail.Name, passKey);
                detail.Value = Encrypter.EncryptString(detail.Value, passKey);
            }

            foreach (var credential in Credentials)
            {
                credential.Name = Encrypter.EncryptString(credential.Name, passKey);
                credential.Url = Encrypter.EncryptString(credential.Url, passKey);

                credential.UserName = Encrypter.EncryptString(credential.UserName, passKey);
                credential.Email = Encrypter.EncryptString(credential.Email, passKey);
                credential.Password = Encrypter.EncryptString(credential.Password, passKey);
            }

            foreach (var key in Keys)
            {
                key.Name = Encrypter.EncryptString(key.Name, passKey);
                key.Url = Encrypter.EncryptString(key.Url, passKey);
                key.KeyString = Encrypter.EncryptString(key.KeyString, passKey);
            }
        }

        internal void Decrypt(int[] passKey)
        {
            Name = Decrypter.DecryptString(Name, passKey);
            Email = Decrypter.DecryptString(Email, passKey);
            MasterPassword = Decrypter.DecryptString(MasterPassword, passKey);

            foreach (var detail in ExtraDetails)
            {
                detail.Name = Decrypter.DecryptString(detail.Name, passKey);
                detail.Value = Decrypter.DecryptString(detail.Value, passKey);
            }

            foreach (var credential in Credentials)
            {
                credential.Name = Decrypter.DecryptString(credential.Name, passKey);
                credential.Url = Decrypter.DecryptString(credential.Url, passKey);

                credential.UserName = Decrypter.DecryptString(credential.UserName, passKey);
                credential.Email = Decrypter.DecryptString(credential.Email, passKey);
                credential.Password = Decrypter.DecryptString(credential.Password, passKey);
            }

            foreach (var key in Keys)
            {
                key.Name = Decrypter.DecryptString(key.Name, passKey);
                key.Url = Decrypter.DecryptString(key.Url, passKey);
                key.KeyString = Decrypter.DecryptString(key.KeyString, passKey);
            }
        }
    }
}