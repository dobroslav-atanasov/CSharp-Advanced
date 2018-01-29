namespace _06._AMinersTask
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, long> mine = new Dictionary<string, long>();

            while (input != "stop")
            {
                string resource = input;
                long quantity = long.Parse(Console.ReadLine());
                if (!mine.ContainsKey(resource))
                {
                    mine[resource] = 0;
                }
                mine[resource] += quantity;

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, long> kvp in mine)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}