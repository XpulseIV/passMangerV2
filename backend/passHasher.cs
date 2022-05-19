using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace backend
{
    public static class PassHasher
    {
        public static string HashString(string str)
        {
            return Regex.Replace(BitConverter
                    .ToString(SHA256.Create()
                        .ComputeHash(System.Text.Encoding.UTF8.GetBytes(str))),
                @"-", "");
        }

        public static string GetEncryptionKey(string masterPassword)
        {
            return masterPassword.Substring(masterPassword.Length / 4, masterPassword.Length / 2);
        }
    }
}