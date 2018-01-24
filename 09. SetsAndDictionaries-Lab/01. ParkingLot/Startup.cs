namespace _01._ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            SortedSet<string> parking = new SortedSet<string>();

            while (input != "END")
            {
                string[] inputParts = input.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                string direction = inputParts[0].ToLower();
                string carNumber = inputParts[1];

                switch (direction)
                {
                    case "in":
                        parking.Add(carNumber);
                        break;
                    case "out":
                        parking.Remove(carNumber);
                        break;
                }
                input = Console.ReadLine();
            }

            if (parking.Count == 0)
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
            else
            {
                foreach (string carNumber in parking)
                {
                    Console.WriteLine(carNumber);
                }
            }
        }
    }
}