namespace _13._SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> concerts = new Dictionary<string, Dictionary<string, long>>();

            while (input != "End")
            {
                string pattern = @"([A-z\s]+)\s\@([A-z\s]+)\s(\d+)\s(\d+)";
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string singer = match.Groups[1].Value;
                    string venue = match.Groups[2].Value;
                    long ticketsPrice = long.Parse(match.Groups[3].Value);
                    long ticketsCount = long.Parse(match.Groups[4].Value);

                    if (!concerts.ContainsKey(venue))
                    {
                        concerts[venue] = new Dictionary<string, long>();
                    }
                    if (!concerts[venue].ContainsKey(singer))
                    {
                        concerts[venue][singer] = 0;
                    }
                    concerts[venue][singer] += (ticketsPrice * ticketsCount);
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Dictionary<string, long>> concert in concerts)
            {
                Console.WriteLine($"{concert.Key}");
                foreach (KeyValuePair<string, long> singer in concert.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}