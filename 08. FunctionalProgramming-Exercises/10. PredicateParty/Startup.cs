namespace _10._PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();
            while (input != "Party!")
            {
                string[] inputParts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string command = inputParts[0];
                string criteria = inputParts[1];
                string str = inputParts[2];

                Predicate<string> startWith = s => s.StartsWith(str);
                Predicate<string> endWith = s => s.EndsWith(str);
                Predicate<string> length = s => s.Length == int.Parse(str);


                if (command == "Double")
                {
                    List<string> people = new List<string>();
                    switch (criteria)
                    {
                        case "StartsWith":
                            people = names.FindAll(startWith);
                            names.AddRange(people);
                            break;
                        case "EndsWith":
                            people = names.FindAll(endWith);
                            names.AddRange(people);
                            break;
                        case "Length":
                            people = names.FindAll(length);
                            names.AddRange(people);
                            break;
                    }
                }
                else if (command == "Remove")
                {
                    switch (criteria)
                    {
                        case "StartsWith":
                            names.RemoveAll(startWith);
                            break;
                        case "EndsWith":
                            names.RemoveAll(endWith);
                            break;
                        case "Length":
                            names.RemoveAll(length);
                            break;
                    }
                }
                input = Console.ReadLine();
            }

            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
        }
    }
}