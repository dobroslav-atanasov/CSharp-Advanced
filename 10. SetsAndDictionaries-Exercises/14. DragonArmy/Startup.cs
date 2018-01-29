namespace _14._DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int numberOfDragons = int.Parse(Console.ReadLine());
            Dictionary<string, SortedDictionary<string, List<int>>> army = new Dictionary<string, SortedDictionary<string, List<int>>>();

            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] inputParts = Console.ReadLine().Trim().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                string type = inputParts[0];
                string name = inputParts[1];
                int damage = 0;
                if (!int.TryParse(inputParts[2], out damage))
                {
                    damage = 45;
                }

                int health = 0;
                if (!int.TryParse(inputParts[3], out health))
                {
                    health = 250;
                }

                int armor = 0;
                if (!int.TryParse(inputParts[4], out armor))
                {
                    armor = 10;
                }

                if (!army.ContainsKey(type))
                {
                    army[type] = new SortedDictionary<string, List<int>>();
                }
                if (!army[type].ContainsKey(name))
                {
                    army[type][name] = new List<int>();
                    army[type][name].Add(0);
                    army[type][name].Add(0);
                    army[type][name].Add(0);
                }
                army[type][name][0] = damage;
                army[type][name][1] = health;
                army[type][name][2] = armor;
            }

            foreach (KeyValuePair<string, SortedDictionary<string, List<int>>> type in army)
            {
                Console.WriteLine($"{type.Key}::({type.Value.Average(d => d.Value[0]):F2}/{type.Value.Average(h => h.Value[1]):F2}/{type.Value.Average(a => a.Value[2]):F2})");
                foreach (KeyValuePair<string, List<int>> dragon in type.Value)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }
    }
}