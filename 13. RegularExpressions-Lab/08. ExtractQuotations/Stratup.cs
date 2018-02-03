namespace _08._ExtractQuotations
{
    using System;
    using System.Text.RegularExpressions;

    public class Stratup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"('|"")(.*?)\1";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2]);
            }
        }
    }
}