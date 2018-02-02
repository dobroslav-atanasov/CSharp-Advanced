namespace _11._ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> list = new List<string>(names);

            string input = Console.ReadLine();
            while (input != "Print")
            {
                string[] inputParts = input.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                string command = inputParts[0];
                string type = inputParts[1];
                string parameter = inputParts[2];

                Predicate<string> start = n => n.StartsWith(parameter);
                Predicate<string> end = n => n.EndsWith(parameter);
                Predicate<string> length = n => n.Length == int.Parse(parameter);
                Predicate<string> contain = n => n.Contains(parameter);

                if (command.Equals("Add filter"))
                {
                    List<string> removePeople = new List<string>();
                    switch (type)
                    {
                        case "Starts with":
                            removePeople = names.FindAll(start);
                            break;
                        case "Ends with":
                            removePeople = names.FindAll(end);
                            break;
                        case "Length":
                            removePeople = names.FindAll(length);
                            break;
                        case "Contains":
                            removePeople = names.FindAll(contain);
                            break;
                    }

                    foreach (string person in removePeople)
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            if (names[i] == person)
                            {
                                names[i] = string.Empty;
                            }
                        }
                    }
                }
                else if (command.Equals("Remove filter"))
                {
                    List<string> addPeople = new List<string>();
                    switch (type)
                    {
                        case "Starts with":
                            addPeople = list.FindAll(start);
                            break;
                        case "Ends with":
                            addPeople = list.FindAll(end);
                            break;
                        case "Length":
                            addPeople = list.FindAll(length);
                            break;
                        case "Contains":
                            addPeople = list.FindAll(contain);
                            break;
                    }

                    foreach (string person in addPeople)
                    {
                        int indexOfName = list.LastIndexOf(person);
                        names[indexOfName] = person;
                    }
                }
                input = Console.ReadLine();
            }

            foreach (string person in names)
            {
                if (person != string.Empty)
                {
                    Console.Write(person + " ");
                }
            }
            Console.WriteLine();
        }
    }
}