namespace _01._MatchCount
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);
            Console.WriteLine(matches.Count);
        }
    }
}