namespace backend;

public class Credential
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Url { get; set; }
    public string Password { get; set; }
    
    public Credential(string name, string email, string url, string password)
    {
        Name = name;
        Email = email;
        Url = url;
        Password = password;
    }
}