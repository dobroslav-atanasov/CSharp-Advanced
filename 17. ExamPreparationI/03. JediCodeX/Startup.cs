namespace _03._JediCodeX
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                sb.Append(input);
            }

            string firstPattern = Console.ReadLine();
            string secondPattern = Console.ReadLine();
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string namePattern = $@"{firstPattern}([a-zA-Z]{{{firstPattern.Length}}})(?![a-zA-Z])";
            string messegaPattern = $@"{secondPattern}([a-zA-Z0-9]{{{secondPattern.Length}}})(?![a-zA-Z0-9])";

            Queue<string> names = new Queue<string>();
            MatchCollection nameMatches = Regex.Matches(sb.ToString(), namePattern);
            foreach (Match match in nameMatches)
            {
                names.Enqueue(match.Groups[1].Value);
            }

            List<string> messages = new List<string>();
            MatchCollection messageMatches = Regex.Matches(sb.ToString(), messegaPattern);
            foreach (Match match in messageMatches)
            {
                messages.Add(match.Groups[1].Value);
            }

            Dictionary<string, string> jedis = new Dictionary<string, string>();
            foreach (int num in numbers)
            {
                if (num - 1 < 0 || num - 1 > messages.Count - 1 )
                {
                    continue;
                }

                if (names.Count > 0)
                {
                    string name = names.Dequeue();
                    jedis.Add(name, messages[num - 1]);
                }
                else
                {
                    break;
                }
            }

            foreach (KeyValuePair<string, string> jedi in jedis)
            {
                Console.WriteLine($"{jedi.Key} - {jedi.Value}");
            }
        }
    }
}