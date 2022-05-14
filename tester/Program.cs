using System;
using System.Reflection;
using backend;
using backend.enc_dec;

namespace tester
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var type = typeof(backend.User);

            var user = new User("test", "test@test.com", "masterPass",
                new List<Detail>() { new("detail1", "value1"), new("detail2", "value2") },
                new List<Credential>() { new("c1", "e1", "u1", "p1") });
            
            Filer.SaveUser(user, "LOL.txt");
        }
    }
}