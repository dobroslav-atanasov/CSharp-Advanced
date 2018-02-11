namespace HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, string>> people = new Dictionary<string, Dictionary<string, string>>();
            int targetInfoIndex = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "end transmissions")
            {
                string[] inputParts = input.Split(new[] { '=', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputParts[0];
                Dictionary<string, string> parts = new Dictionary<string, string>();
                for (int i = 1; i < inputParts.Length - 1; i += 2)
                {
                    string key = inputParts[i];
                    string value = inputParts[i + 1];
                    if (!parts.ContainsKey(key))
                    {
                        parts[key] = string.Empty;
                    }
                    parts[key] = value;
                }

                if (!people.ContainsKey(name))
                {
                    people[name] = new Dictionary<string, string>();
                }
                foreach (KeyValuePair<string, string> kvp in parts)
                {
                    if (!people[name].ContainsKey(kvp.Key))
                    {
                        people[name][kvp.Key] = string.Empty;
                    }
                    people[name][kvp.Key] = kvp.Value;
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            string[] lastInput = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string searchedName = lastInput[1];

            foreach (KeyValuePair<string, Dictionary<string, string>> person in people.Where(k => k.Key == searchedName))
            {
                int infoIndex = 0;
                Console.WriteLine($"Info on {searchedName}:");
                foreach (KeyValuePair<string, string> info in person.Value.OrderBy(i => i.Key))
                {
                    infoIndex += info.Key.Length;
                    infoIndex += info.Value.Length;
                    Console.WriteLine($"---{info.Key}: {info.Value}");
                }
                Console.WriteLine($"Info index: {infoIndex}");
                if (infoIndex >= targetInfoIndex)
                {
                    Console.WriteLine("Proceed");
                }
                else
                {
                    Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
                }
            }
        }
    }
}