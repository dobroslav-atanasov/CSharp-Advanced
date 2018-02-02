namespace _06._ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int givenNum = int.Parse(Console.ReadLine());
            Func<int[], int[]> function = n => n.Reverse().ToArray();
            numbers = function(numbers);

            Predicate<int> predicate = n => n % givenNum != 0;
            foreach (int number in numbers)
            {
                if (predicate(number))
                {
                    Console.Write($"{number} ");
                }
            }
            Console.WriteLine();
        }
    }
}