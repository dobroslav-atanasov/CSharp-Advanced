namespace _04._FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            Predicate<int> predicate;

            switch (command)
            {
                case "odd":
                    predicate = n => n % 2 != 0;
                    break;
                case "even":
                    predicate = n => n % 2 == 0;
                    break;
                default:
                    predicate = null;
                    break;
            }

            PrintNumbers(predicate, numbers);
        }

        private static void PrintNumbers(Predicate<int> predicate, int[] numbers)
        {
            int start = numbers[0];
            int end = numbers[1];
            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }
    }
}