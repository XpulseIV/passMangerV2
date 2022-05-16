namespace backend
{
    [Serializable]
    public sealed class Credential
    {
        internal string Name { get; set; }
        internal string Url { get; set; }

        internal string UserName { get; set; }
        internal string Email { get; set; }
        internal string Password { get; set; }

        public Credential(string name, string url, string userName, string email, string password)
        {
            Name = name;
            Url = url;

            UserName = userName;
            Email = email;
            Password = password;
        }
    }
}