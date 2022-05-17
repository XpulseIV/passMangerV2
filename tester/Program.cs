using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using backend;

namespace tester
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            User user = new(
                "testUser",
                "testMail@test.com",
                PassHasher.HashString("IsakIsBadLeLV2.0"),
                new List<Detail>
                {
                    new("detail1", "value1"),
                    new("detail2", "value2"),
                    new("detail3", "value3"),
                    new("detail4", "value4"),
                    new("detail5", "value5"),
                    new("detail6", "value6"),
                    new("detail7", "value7"),
                    new("detail8", "value8")
                },
                new List<Credential>
                {
                    new("name1", "url1", "username1", "email1", "password1"),
                    new("name2", "url2", "username2", "email2", "password2"),
                    new("name3", "url3", "username3", "email3", "password3"),
                    new("name4", "url4", "username4", "email4", "password4"),
                    new("name5", "url5", "username5", "email5", "password5"),
                    new("name6", "url6", "username6", "email6", "password6"),
                    new("name7", "url7", "username7", "email7", "password7"),
                    new("name8", "url8", "username8", "email8", "password8")
                },
                new List<Key>
                {
                    new("name1", "url1", "keystring1"),
                    new("name2", "url2", "keystring2"),
                    new("name3", "url3", "keystring3"),
                    new("name4", "url4", "keystring4"),
                    new("name5", "url5", "keystring5"),
                    new("name6", "url6", "keystring6"),
                    new("name7", "url7", "keystring7"),
                    new("name8", "url8", "keystring8")
                });

            var key = PassHasher.GetEncryptionKey(user.MasterPassword);

            XmlFilerDeluxe.SaveUser(user.Name + ".user", user, key);
        }
    }
}