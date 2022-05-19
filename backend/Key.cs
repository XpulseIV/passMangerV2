namespace backend
{
    [Serializable]
    public sealed class Key
    {
        public string Name;
        public string Url;
        public string KeyString;

        public Key(string name, string url, string keyString)
        {
            Name = name;
            Url = url;
            KeyString = keyString;
        }

        public Key()
        {
            Name = "";
            Url = "";
            KeyString = "";
        }
    }
}