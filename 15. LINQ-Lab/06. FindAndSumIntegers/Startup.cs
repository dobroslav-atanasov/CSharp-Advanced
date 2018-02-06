namespace _06._FindAndSumIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(n =>
                {
                    int number;
                    bool isParsed = int.TryParse(n, out number);
                    return new {number, isParsed};
                })
                .Where(n => n.isParsed)
                .Select(n => n.number)
                .ToList();

            if (numbers.Count == 0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine(numbers.Sum());
            }
        }
    }
}