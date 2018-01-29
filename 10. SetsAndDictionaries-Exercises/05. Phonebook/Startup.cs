namespace _05._Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (input != "search")
            {
                string[] inputParts = input.Split('-');
                string name = inputParts[0];
                string phoneNumber = inputParts[1];
                if (!phonebook.ContainsKey(name))
                {
                    phonebook[name] = string.Empty;
                }
                phonebook[name] = phoneNumber;
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "stop")
            {
                string name = input;
                if (phonebook.ContainsKey(name))
                {
                    Console.WriteLine($"{name} -> {phonebook[name]}");
                }
                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }
                input = Console.ReadLine();
            }
        }
    }
}