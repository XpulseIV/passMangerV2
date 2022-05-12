using System;

namespace frontend 
{
    internal static class Program
    {
        private static void Main(string[] args)
        {

        }

        private static string AskUser(string prompt)
        {
            Console.Write(prompt);

            var input = Console.ReadLine() ?? "";
            return input.ToLower();
        }
    }
}