namespace _02._SoftUniParty
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            SortedSet<string> allGuests = new SortedSet<string>();

            while (input != "PARTY")
            {
                allGuests.Add(input);
                input = Console.ReadLine();
            }

            SortedSet<string> arrivedGuests = new SortedSet<string>();
            input = Console.ReadLine();
            while (input != "END")
            {
                arrivedGuests.Add(input);
                input = Console.ReadLine();
            }

            allGuests.ExceptWith(arrivedGuests);
            Console.WriteLine(allGuests.Count);
            foreach (string guest in allGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}