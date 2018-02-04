namespace _11._SemanticalHTML
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string openTagPattern = @"<(div)([^>]*)(?:id|class)\s*=\s*""(.*?)""(.*?)>";
            string closeTagPattern = @"<\/div>\s*<!--\s*(.*?)\s*-->";

            while (input != "END")
            {
                Match openTagMatch = Regex.Match(input, openTagPattern);
                Match closeTagMatch = Regex.Match(input, closeTagPattern);

                if (openTagMatch.Success)
                {
                    input = Regex.Replace(input, openTagPattern,
                        x => $"{x.Groups[3]} {x.Groups[2]} {x.Groups[4]}").Trim();
                    input = "<" + Regex.Replace(input, @"\s+", " ") + ">";
                }
                else if (closeTagMatch.Success)
                {
                    input = $"</{closeTagMatch.Groups[1]}>";
                }

                Console.WriteLine(input);
                input = Console.ReadLine();
            }
        }
    }
}