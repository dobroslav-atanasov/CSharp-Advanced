namespace _03._NonDigitCount
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\D";

            MatchCollection matches = Regex.Matches(input, pattern);
            Console.WriteLine($"Non-digits: {matches.Count}");
        }
    }
}