namespace _03._CustomMinFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Func<IEnumerable<int>, int> func = n => n.Min();

            Console.WriteLine(func(numbers));
        }
    }
}