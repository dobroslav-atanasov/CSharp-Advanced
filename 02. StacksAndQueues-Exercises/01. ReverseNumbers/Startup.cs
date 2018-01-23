namespace _01._ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}