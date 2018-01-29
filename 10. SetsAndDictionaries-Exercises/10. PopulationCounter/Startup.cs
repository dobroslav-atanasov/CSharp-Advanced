namespace _10._PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> countries = new Dictionary<string, Dictionary<string, long>>();

            while (input != "report")
            {
                string[] inputParts = input.Split('|');
                string city = inputParts[0];
                string country = inputParts[1];
                long population = long.Parse(inputParts[2]);

                if (!countries.ContainsKey(country))
                {
                    countries[country] = new Dictionary<string, long>();
                }
                if (!countries[country].ContainsKey(city))
                {
                    countries[country][city] = 0;
                }
                countries[country][city] += population;

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Dictionary<string, long>> country in countries.OrderByDescending(c => c.Value.Sum(p => p.Value)))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Sum(p => p.Value)})");
                foreach (KeyValuePair<string, long> city in country.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}