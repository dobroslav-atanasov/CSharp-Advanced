namespace _03._FirstName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string[] names = Console.ReadLine().Split(' ');
            SortedSet<string> letters = new SortedSet<string>(Console.ReadLine().Split(' '));

            string name = null;
            foreach (string letter in letters)
            {
                name = names
                    .Where(n => n.ToLower().StartsWith(letter))
                    .FirstOrDefault();

                if (name != null)
                {
                    Console.WriteLine(name);
                    break;
                }
            }
            if (name == null)
            {
                Console.WriteLine("No match");
            }
        }
    }
}