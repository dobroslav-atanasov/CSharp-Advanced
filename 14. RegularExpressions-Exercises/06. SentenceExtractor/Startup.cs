namespace _06._SentenceExtractor
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string keyword = Console.ReadLine();
            string text = Console.ReadLine();
            string pattern = @".*?(\.|\!|\?)";

            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                string[] words = match.ToString().Split('.', ' ', '!', '?');
                foreach (string word in words)
                {
                    if (word == keyword)
                    {
                        Console.WriteLine(match);
                    }
                }
            }
        }
    }
}