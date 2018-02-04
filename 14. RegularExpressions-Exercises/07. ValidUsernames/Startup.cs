namespace _07._ValidUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string[] usernames = Console.ReadLine().Split(new []{' ', '\\', '/', '(', ')'}, StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"\b[A-z][\w+]{2,24}\b";

            List<string> validUsernames = new List<string>();
            foreach (string username in usernames)
            {
                Match match = Regex.Match(username, pattern);
                if (match.Success)
                {
                    validUsernames.Add(match.ToString());
                }
            }

            int bestSum = 0;
            int index = 0;
            for (int i = 0; i < validUsernames.Count - 1; i++)
            {
                int sum = validUsernames[i].Length + validUsernames[i + 1].Length;
                if (sum > bestSum)
                {
                    bestSum = sum;
                    index = i;
                }
            }

            Console.WriteLine(validUsernames[index]);
            Console.WriteLine(validUsernames[index + 1]);
        }
    }
}