namespace _04._TreasureMap
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string pattern = @"\![^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*[^\d](?<number>\d{3})-(?<password>\d{6}|\d{4})(?:[^\d!#][^!#]*)?\#|\#[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*[^\d](?<number>\d{3})-(?<password>\d{6}|\d{4})(?:[^\d!#][^!#]*)?\!";
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);

                if (matches.Count == 1)
                {
                    Match match = matches[0];
                    Console.WriteLine($"Go to str. {match.Groups[1]} {match.Groups[2]}. Secret pass: {match.Groups[3]}.");
                }
                else if (matches.Count >= 2)
                {
                    Match match = matches[matches.Count / 2];
                    Console.WriteLine($"Go to str. {match.Groups["street"]} {match.Groups["number"]}. Secret pass: {match.Groups["password"]}.");
                }
            }
        }
    }
}