namespace _04._BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] inputParts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numbersToDequeue = inputParts[1];
            int searchedNumber = inputParts[2];

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < numbersToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(searchedNumber))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}