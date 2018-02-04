namespace _09._QueryMess
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"([^&=?\s]*)(?=\=)=(?<=\=)([^&=\s]*)";
            string spacePattern = @"((%20|\+)+)";

            while (input != "END")
            {
                Dictionary<string, List<string>> queries = new Dictionary<string, List<string>>();
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    string field = match.Groups[1].Value;
                    string value = match.Groups[2].Value;
                    field = Regex.Replace(field, spacePattern, x => " ").Trim();
                    value = Regex.Replace(value, spacePattern, x => " ").Trim();

                    if (!queries.ContainsKey(field))
                    {
                        queries[field] = new List<string>();
                    }
                    queries[field].Add(value);
                }
                foreach (KeyValuePair<string, List<string>> kvp in queries)
                {
                    Console.Write($"{kvp.Key}=[{string.Join(", ", kvp.Value)}]");
                }
                Console.WriteLine();

                input = Console.ReadLine();
            }
        }
    }
}