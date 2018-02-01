namespace _02._SumNumbers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string numbers = Console.ReadLine();

            Func<string, int> parser = n => int.Parse(n);

            Console.WriteLine(numbers
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .Count());

            Console.WriteLine(numbers
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .Sum());
        }
    }
}