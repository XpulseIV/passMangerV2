namespace backend
{
    [Serializable]
    public sealed class Detail
    {
        public string Name;
        public string Value;

        public Detail(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public Detail()
        {
            Name = "";
            Value = "";
        }
    }
}