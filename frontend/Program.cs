using System;

namespace frontend 
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("---------------PassManger---------------\n" +
                              "Input master password: ");
            Console.WriteLine("\nkey: " + Console.ReadKey(true).KeyChar);
        }
    }
}