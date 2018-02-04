namespace _02._MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\+359(\s|\-)2\1[\d]{3}\1[\d]{4}";

            while (input != "end")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    Console.WriteLine(match);
                }
                input = Console.ReadLine();
            }
        }
    }
}