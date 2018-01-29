namespace _03._PeriodicTable
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            SortedSet<string> tables = new SortedSet<string>();

            for (int i = 0; i < number; i++)
            {
                string[] elements = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string element in elements)
                {
                    tables.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", tables));
        }
    }
}