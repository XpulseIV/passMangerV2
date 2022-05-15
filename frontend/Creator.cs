using System.Reflection.Metadata;
using backend;

namespace frontend;

public static class Creator
{
    public static User CreateUser()
    {
        var name = Asker.ForceInput("Enter username: ");
        var email = Asker.AskUser("Enter email (optional)");
        var master = PassHasher.HashString(Asker.GetPassword("Enter master password: "));
        var details = CreateDetailList();
        var credentials = CreateCredentialList();

        return new User(name, email, master, details, credentials);
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

    public static Detail CreateDetail()
    {
        return new Detail(Asker.AskUser("Enter detail name: "), Asker.AskUser("Enter detail value: "));
    }

    private static List<Credential> CreateCredentialList()
    {
        var credentials = new List<Credential>();

        Console.WriteLine("Creating credentials. Press 'x' to skip");
        var go = Console.ReadKey().KeyChar != 'x';
        while (go)
        {
            var credential = CreateCredential(credentials);
            if (credential != null) credentials.Add(credential);
            go = Asker.ForceKey("Add more credentials? [y,n]: ", "yn") == "y";
        }

        return credentials;
    }

    public static Credential? CreateCredential(List<Credential> credentials)
    {
        var credential = new Credential(Asker.ForceInput("Enter credential name: "), Asker.AskUser("Enter credential email: "),
            Asker.AskUser("Enter credential url: "), Asker.ForceInput("Enter credential password: "));
        return credentials.Find(x => x.Name.Equals(credential.Name)) == null ? null : credential;
    }
}