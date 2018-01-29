namespace _12._LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, long> keyMaterials = new Dictionary<string, long>();
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;
            Dictionary<string, long> junkMaterials = new Dictionary<string, long>();

            bool hasWinner = false;
            while (true)
            {
                string[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < inputParts.Length - 1; i += 2)
                {
                    long quantity = long.Parse(inputParts[i]);
                    string material = inputParts[i + 1].ToLower();
                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials.Any(m => m.Value >= 250))
                        {
                            hasWinner = true;
                            break;
                        }
                    }
                    else
                    {
                        GetMaterial(material, quantity, junkMaterials);
                    }
                }

                if (hasWinner)
                {
                    break;
                }
                input = Console.ReadLine();
            }

            if (keyMaterials["shards"] >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                keyMaterials["shards"] -= 250;
            }
            else if (keyMaterials["fragments"] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                keyMaterials["fragments"] -= 250;
            }
            else if (keyMaterials["motes"] >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                keyMaterials["motes"] -= 250;
            }

            foreach (KeyValuePair<string, long> keyMaterial in keyMaterials.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
            {
                Console.WriteLine($"{keyMaterial.Key}: {keyMaterial.Value}");
            }
            foreach (KeyValuePair<string, long> junkMaterial in junkMaterials.OrderBy(m => m.Key))
            {
                Console.WriteLine($"{junkMaterial.Key}: {junkMaterial.Value}");
            }
        }

        private static void GetMaterial(string material, long quantity, Dictionary<string, long> materials)
        {
            if (!materials.ContainsKey(material))
            {
                materials[material] = 0;
            }
            materials[material] += quantity;
        }
    }
}