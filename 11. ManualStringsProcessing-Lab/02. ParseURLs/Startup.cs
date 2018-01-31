namespace _02._ParseURLs
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string[] inputParts = input.Split("://", StringSplitOptions.RemoveEmptyEntries);

            if (inputParts.Length != 2 || inputParts[1].IndexOf('/') == -1)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                string protocol = inputParts[0];
                int indexOfSlash = inputParts[1].IndexOf('/');
                string server = inputParts[1].Substring(0, indexOfSlash);
                string resources = inputParts[1].Substring(indexOfSlash + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }
        }
    }
}