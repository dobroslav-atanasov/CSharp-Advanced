namespace _04._JediDreams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> methods = new Dictionary<string, List<string>>();
            string methodPattern = @"static.*?([A-Z][a-zA-Z]*)\s*\(.*\)$";
            string invokePattern = @"([A-Z][a-zA-Z]*)\s*\(";
            string lastMethod = string.Empty;
            bool hasMethod = false;

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine().Trim();
                Match methodMatch = Regex.Match(input, methodPattern);

                if (methodMatch.Success)
                {
                    lastMethod = methodMatch.Groups[1].ToString();
                    methods[lastMethod] = new List<string>();
                    hasMethod = true;
                    continue;
                }

                if (hasMethod)
                {
                    MatchCollection invokeMatches = Regex.Matches(input, invokePattern);
                    if (invokeMatches.Count > 0)
                    {
                        foreach (Match match in invokeMatches)
                        {
                            methods[lastMethod].Add(match.Groups[1].ToString());
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, List<string>> method in methods.OrderByDescending(m => m.Value.Count).ThenBy(m => m.Key))
            {
                if (method.Value.Count > 0)
                {
                    Console.WriteLine($"{method.Key} -> {method.Value.Count} -> {string.Join(", ", method.Value.OrderBy(m => m))}");
                }
                else
                {
                    Console.WriteLine($"{method.Key} -> None");
                }
            }
        }
    }
}