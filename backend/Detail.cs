namespace backend;

public class Detail
{
    public string Name { get; set; }
    public string Value { get; set; }

    public Detail(string name, string value)
    {
        Name = name;
        Value = value;
    }
}