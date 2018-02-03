namespace _02._VowelCount
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"[AEIOUYaeiouy]";

            MatchCollection matches = Regex.Matches(text, pattern);
            Console.WriteLine($"Vowel: {matches.Count}");
        }
    }
}