namespace _07._BoundedNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] boundary = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(n => n >= boundary.Min() && n <= boundary.Max())
                .ToList();

            numbers.ForEach(n => Console.Write(n + " "));
        }
    }
}