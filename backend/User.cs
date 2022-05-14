using System;

namespace backend
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MasterPassword { get; set; }

        public List<Detail> ExtraDetails { get; set; }
        public List<Credential> Credentials { get; set; }

        public User(string name, string email, string masterPassword, List<Detail> extraDetails, List<Credential> credentials)
        {
            Name = name;
            Email = email;
            MasterPassword = masterPassword;
            ExtraDetails = extraDetails;
            Credentials = credentials;
        }
    }
}