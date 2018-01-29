namespace _01._UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int numberOfNames = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < numberOfNames; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}