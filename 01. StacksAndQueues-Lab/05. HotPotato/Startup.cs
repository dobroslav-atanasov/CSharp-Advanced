namespace _05._HotPotato
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string[] players = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            int number = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(players);

            while (queue.Count > 1)
            {
                for (int i = 1; i < number; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}