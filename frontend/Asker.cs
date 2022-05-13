namespace frontend;

public class Asker
{
    public static string AskUser(string prompt)
    {
        Console.Write(prompt);

        var input = Console.ReadLine() ?? "";
        return input.ToLower();
    }

    public static string ForceInput(string prompt)
    {
        var input = "";
        while (input == "")
        {
            input = AskUser(prompt);
        }

        return input;
    }

    public static string ForceKey(string prompt)
    {
        var input = '\0';
        while (input == '\0')
        {
            Console.Write(prompt);
            input = Console.ReadKey().KeyChar;
        }
        Console.WriteLine();

        return input.ToString().ToLower();
    }

    public static string GetPassword(string prompt)
    {
        // ToDo Add ReadKey with intercept solution
        return ForceInput(prompt);
    }
}