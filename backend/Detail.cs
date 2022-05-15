namespace backend
{
    public sealed class Detail
    {
        internal string Name { get; set; }
        internal string Value { get; set; }

        public Detail(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}