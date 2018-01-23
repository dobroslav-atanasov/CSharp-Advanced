namespace _06._TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            Queue<Pump> pumps = new Queue<Pump>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                long[] inputParts = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                long amountOfPetrol = inputParts[0];
                long distance = inputParts[1];
                Pump pump = new Pump(i, amountOfPetrol, distance);
                pumps.Enqueue(pump);
            }

            bool isCycle = false;
            Pump startPump = null;
            while (true)
            {
                Pump currentPump = pumps.Dequeue();
                startPump = currentPump;
                pumps.Enqueue(currentPump);
                long tank = currentPump.Petrol;

                while (tank >= currentPump.Distance)
                {
                    tank -= currentPump.Distance;
                    currentPump = pumps.Dequeue();
                    pumps.Enqueue(currentPump);

                    if (currentPump == startPump)
                    {
                        isCycle = true;
                        break;
                    }
                    tank += currentPump.Petrol;
                }

                if (isCycle)
                {
                    Console.WriteLine(currentPump.Id);
                    break;
                }
            }
        }
    }
}