namespace _08._ExtractHyperlinks
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"<a\s+[^>]*?href\s*=(.*?)>.*?<\s*\/\s*a\s*>";
            StringBuilder sb = new StringBuilder();

            while (input != "END")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            MatchCollection matches = Regex.Matches(sb.ToString(), pattern);
            foreach (Match match in matches)
            {
                string href = match.Groups[1].Value.Trim();
                string hrefResult = string.Empty;

                if (href[0] == '\'')
                {
                    hrefResult = href.Split(new[] { '\'' }, StringSplitOptions.RemoveEmptyEntries).First();
                }
                else if (href[0] == '"')
                {
                    hrefResult = href.Split(new[] { '"' }, StringSplitOptions.RemoveEmptyEntries).First();
                }
                else
                {
                    hrefResult = href.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).First();
                }

                Console.WriteLine(hrefResult);
            }
        }
    }
}