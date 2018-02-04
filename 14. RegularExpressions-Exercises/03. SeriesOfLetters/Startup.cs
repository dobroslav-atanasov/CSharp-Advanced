namespace _03._SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"([A-z])\1+";
            input = Regex.Replace(input, pattern, s => s.Groups[1].ToString());
            Console.WriteLine(input);
        }
    }
}