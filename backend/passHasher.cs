using System.Security.Cryptography;

namespace backend
{
    public static class PassHasher
    {
        public static string HashString(string str)
        {
            var textBytes = System.Text.Encoding.UTF8.GetBytes(str);

            var sha1 = SHA1.Create();
            var sha256 = SHA256.Create();
            var sha384 = SHA384.Create();
            var sha512 = SHA512.Create();

            var sha1Text = sha1.ComputeHash(textBytes);
            var sha256Text = sha256.ComputeHash(sha1Text);
            var sha384Text = sha384.ComputeHash(sha256Text);
            var sha512Text = sha512.ComputeHash(sha384Text);

            return BitConverter.ToString(sha512Text);
        }
    }
}