namespace _08._CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> odd = new List<int>();
            List<int> even = new List<int>();
            
            Predicate<int> predicate = n => n % 2 == 0;
            foreach (int number in numbers)
            {
                if (predicate(number))
                {
                    even.Add(number);
                }
                else
                {
                    odd.Add(number);
                }
            }

            odd.Sort();
            even.Sort();
            Action<List<int>, List<int>> print = (o, e) => Console.WriteLine($"{string.Join(" ", e)} {string.Join(" ", o)}");
            print(odd, even);
        }
    }
}