namespace backend;

public class Credential
{
    private string Name { get; set; }
    private string Email { get; set; }
    private string Url { get; set; }
    private string Password { get; set; }
    
    public Credential(string name, string email, string url, string password)
    {
        Name = name;
        Email = email;
        Url = url;
        Password = password;
    }
}