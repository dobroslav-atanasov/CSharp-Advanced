namespace _05._ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"(?<=\s)[a-z0-9]+([.-]\w*)*@[a-z]+([.-]\w*)*(\.[a-z]+)";

            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}