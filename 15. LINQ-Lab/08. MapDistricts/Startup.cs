namespace _08._MapDistricts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string[] inputParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, List<long>> towns = new Dictionary<string, List<long>>();

            foreach (string part in inputParts)
            {
                string[] townParts = part.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                string townName = townParts[0];
                long population = long.Parse(townParts[1]);

                if (!towns.ContainsKey(townName))
                {
                    towns[townName] = new List<long>();
                }
                towns[townName].Add(population);
            }

            long bound = long.Parse(Console.ReadLine());
            towns = towns
                .Where(t => t.Value.Sum() > bound)
                .OrderByDescending(t => t.Value.Sum())
                .ToDictionary(t => t.Key, t => t.Value);

            foreach (KeyValuePair<string, List<long>> town in towns)
            {
                Console.WriteLine($"{town.Key}: {string.Join(" ", town.Value)}");
            }
        }
    }
}