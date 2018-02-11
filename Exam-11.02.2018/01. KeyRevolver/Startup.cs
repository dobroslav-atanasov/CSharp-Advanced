namespace KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int sizeOfGumBarrel = int.Parse(Console.ReadLine());
            int[] inputBullets = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> locks = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(inputBullets);

            int countOfShots = 0;
            int countOfBullets = 0;
            while (true)
            {
                countOfShots++;
                countOfBullets++;
                int currentBullet = bullets.Pop();

                if (currentBullet <= locks[0])
                {
                    Console.WriteLine("Bang!");
                    locks.RemoveAt(0);
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (countOfShots == sizeOfGumBarrel && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    countOfShots = 0;
                }
                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence - (countOfBullets * priceBullet)}");
                    return;
                }
                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }
            }
        }
    }
}