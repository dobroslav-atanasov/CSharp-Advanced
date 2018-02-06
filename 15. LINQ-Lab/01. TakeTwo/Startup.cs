namespace _01._TakeTwo
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            numbers.Where(n => n >= 10 && n <= 20)
                .Distinct()
                .Take(2)
                .ToList()
                .ForEach(n => Console.Write(n + " "));
        }
    }
}