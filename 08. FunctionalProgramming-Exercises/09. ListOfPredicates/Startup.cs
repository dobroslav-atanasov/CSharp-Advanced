namespace _09._ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int, bool>[] predicates = numbers.Select(d => (Func<int, bool>)(n => n % d == 0)).ToArray();
            List<int> list = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                bool isDivide = true;
                foreach (Func<int, bool> predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        isDivide = false;
                        break;
                    }
                }
                if (isDivide)
                {
                    list.Add(i);
                }
            }

            Action<List<int>> print = n => Console.WriteLine(string.Join(" ", n));
            print(list);
        }
    }
}