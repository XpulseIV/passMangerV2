namespace backend.enc_dec
{
    internal static class Decrypter
    {
        internal static string DecryptString(string str, IEnumerable<int> passKey)
        {
            var charArray = str.ToCharArray();

            var revPassKey = passKey.Reverse();

            foreach (var digit in revPassKey)
            {
                switch (digit)
                {
                case 0:
                    for (var i = 0; i < charArray.Length; i++) charArray[i]--;
                    break;
                case 1:
                    for (var i = 0; i < charArray.Length; i++) charArray[i] = (char)~charArray[i];
                    break;
                case 2:
                    for (var i = 0; i < charArray.Length; i++) charArray[i] = (char)(charArray[i] / 2);
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                }
            }

            var strStr = new string(charArray);

            return strStr;
        }
    }
}