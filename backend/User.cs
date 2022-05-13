using System;

namespace backend
{
    public class User
    {
        private string Name { get; set; }
        private string Email { get; set; }
        private string MasterPassword { get; set; }

        private List<Detail> ExtraDetails { get; set; }
        private List<Credential> Credentials { get; set; }

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