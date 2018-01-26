namespace _11._ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int parkingRows = dimensions[0];
            int parkingCols = dimensions[1];
            HashSet<ParkingSpot> usedParkingSpots = new HashSet<ParkingSpot>();

            string input = Console.ReadLine();
            while (input != "stop")
            {
                int[] inputParts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                int enter = inputParts[0];
                int rowPosition = inputParts[1];
                int colPosition = inputParts[2];

                ParkingSpot parkingSpot = new ParkingSpot(rowPosition, colPosition);
                bool isCarParked = IsCarParked(parkingSpot, parkingRows, parkingCols, usedParkingSpots);

                if (isCarParked)
                {
                    Console.WriteLine(Math.Abs((enter + 1) - (parkingSpot.Row + 1)) + parkingSpot.Col + 1);
                    usedParkingSpots.Add(parkingSpot);
                }
                else
                {
                    Console.WriteLine($"Row {parkingSpot.Row} full");
                }

                input = Console.ReadLine();
            }
        }

        private static bool IsCarParked(ParkingSpot parkingSpot, int parkingRows, int parkingCols,
            HashSet<ParkingSpot> usedParkingSpots)
        {
            bool isCarParked = false;
            if (usedParkingSpots.Where(c => c.Row == parkingSpot.Row && c.Col == parkingSpot.Col).FirstOrDefault() ==
                null)
            {
                return isCarParked = true;
            }

            int col = 1;
            while (true)
            {
                int leftCol = parkingSpot.Col - col;
                int rightCol = parkingSpot.Col + col;

                if (leftCol <= 0 && rightCol >= parkingCols)
                {
                    break;
                }

                if (leftCol > 0 && usedParkingSpots.Where(c => c.Row == parkingSpot.Row && c.Col == leftCol)
                        .FirstOrDefault() == null)
                {
                    parkingSpot.Col = leftCol;
                    return isCarParked = true;
                }
                if (rightCol < parkingCols && usedParkingSpots.Where(c => c.Row == parkingSpot.Row && c.Col == rightCol)
                        .FirstOrDefault() == null)
                {
                    parkingSpot.Col = rightCol;
                    return isCarParked = true;
                }
                col++;
            }
            return isCarParked = false;
        }
    }
}