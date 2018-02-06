namespace _05._MinEvenNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .Where(n => n % 2 == 0)
                .ToList();

            if (numbers.Count == 0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine($"{numbers.Min():F2}");
            }
        }
    }
}