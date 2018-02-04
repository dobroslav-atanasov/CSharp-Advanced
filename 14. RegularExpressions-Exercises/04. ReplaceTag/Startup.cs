namespace _04._ReplaceTag
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
            string replacement = $"[URL href=$1]$2[/URL]";

            while (input != "end")
            {
                input = Regex.Replace(input, pattern, replacement);
                Console.WriteLine(input);
                input = Console.ReadLine();
            }
        }
    }
}