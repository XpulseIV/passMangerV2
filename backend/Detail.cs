namespace backend;

public class Detail
{
    private string Name { get; set; }
    private string Value { get; set; }

    public Detail(string name, string value)
    {
        Name = name;
        Value = value;
    }
}