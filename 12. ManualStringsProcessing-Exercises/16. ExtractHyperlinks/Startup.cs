namespace _16._ExtractHyperlinks
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"<a([^>]+?)href\s*=\s*(""|'\s?)(.+?)\2(?=\s{1}|>)";
            StringBuilder sb = new StringBuilder();

            while (input != "END")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            MatchCollection matches = Regex.Matches(sb.ToString(), pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[3]);
            }
        }
    }
}