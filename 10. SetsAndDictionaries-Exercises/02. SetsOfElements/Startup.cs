namespace _02._SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int numberOfFirstSet = numbers[0];
            int numberOfSecondSet = numbers[1];

            HashSet<int> firstSet = new HashSet<int>();
            for (int i = 0; i < numberOfFirstSet; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            HashSet<int> secondSet = new HashSet<int>();
            for (int i = 0; i < numberOfSecondSet; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}