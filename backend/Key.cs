namespace backend
{
    public sealed class Key
    {
        internal string Name { get; set; }
        internal string Url { get; set; }
        internal string KeyString { get; set; }

        public Key(string name, string url, string keyString)
        {
            Name = name;
            Url = url;
            KeyString = keyString;
        }
    }
}