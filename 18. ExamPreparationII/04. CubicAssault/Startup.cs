namespace _04._CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();

            while (input != "Count em all")
            {
                string[] inputParts = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string regionName = inputParts[0];
                string meteorType = inputParts[1];
                long count = long.Parse(inputParts[2]);

                if (!regions.ContainsKey(regionName))
                {
                    regions[regionName] = new Dictionary<string, long>();
                    regions[regionName].Add("Black", 0);
                    regions[regionName].Add("Red", 0);
                    regions[regionName].Add("Green", 0);
                }
                switch (meteorType)
                {
                    case "Black":
                        regions[regionName][meteorType] += count;
                        break;
                    case "Red":
                        regions[regionName][meteorType] += count;
                        break;
                    case "Green":
                        regions[regionName][meteorType] += count;
                        break;
                }

                if (regions[regionName]["Green"] >= 1000000)
                {
                    while (regions[regionName]["Green"] >= 1000000)
                    {
                        regions[regionName]["Green"] -= 1000000;
                        regions[regionName]["Red"]++;
                    }
                }
                if (regions[regionName]["Red"] >= 1000000)
                {
                    while (regions[regionName]["Red"] >= 1000000)
                    {
                        regions[regionName]["Red"] -= 1000000;
                        regions[regionName]["Black"]++;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Dictionary<string, long>> region in regions.OrderByDescending(r => r.Value["Black"]).ThenBy(r => r.Key.Length).ThenBy(r => r.Key))
            {
                Console.WriteLine(region.Key);
                foreach (KeyValuePair<string, long> kvp in region.Value.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
                {
                    Console.WriteLine($"-> {kvp.Key} : {kvp.Value}");
                }
            }
        }
    }
}