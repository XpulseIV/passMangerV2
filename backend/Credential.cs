using System;

namespace backend
{
    [Serializable]
    public sealed class Credential
    {
        public string Name;
        public string Url;
        public string UserName;
        public string Email;
        public string Password;

        public Credential(string name, string url, string userName, string email, string password)
        {
            Name = name;
            Url = url;

            UserName = userName;
            Email = email;
            Password = password;
        }

        public Credential()
        {
            Name = "";
            Url = "";

            UserName = "";
            Email = "";
            Password = "";
        }
    }
}