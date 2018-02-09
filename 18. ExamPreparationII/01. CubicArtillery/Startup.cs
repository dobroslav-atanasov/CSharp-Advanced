namespace _01._CubicArtillery
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            int leftCapacity = maxCapacity;
            Queue<string> bunkers = new Queue<string>();
            Queue<int> weapons = new Queue<int>();

            string input = Console.ReadLine();
            while (input != "Bunker Revision")
            {
                string[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in inputParts)
                {
                    int weapon;
                    bool hasParsed = int.TryParse(part, out weapon);

                    if (!hasParsed)
                    {
                        bunkers.Enqueue(part);
                    }
                    else
                    {
                        bool isWeaponSaved = false;
                        while (bunkers.Count > 1)
                        {
                            if (leftCapacity >= weapon)
                            {
                                weapons.Enqueue(weapon);
                                leftCapacity -= weapon;
                                isWeaponSaved = true;
                                break;
                            }

                            if (weapons.Count == 0)
                            {
                                Console.WriteLine($"{bunkers.Dequeue()} -> Empty");
                            }
                            else
                            {
                                Console.WriteLine($"{bunkers.Dequeue()} -> {string.Join(", ", weapons)}");
                                weapons.Clear();
                                leftCapacity = maxCapacity;
                            }
                        }

                        if (!isWeaponSaved)
                        {
                            if (weapon <= maxCapacity)
                            {
                                while (leftCapacity < weapon)
                                {
                                    leftCapacity += weapons.Dequeue();
                                }
                                weapons.Enqueue(weapon);
                                leftCapacity -= weapon;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}