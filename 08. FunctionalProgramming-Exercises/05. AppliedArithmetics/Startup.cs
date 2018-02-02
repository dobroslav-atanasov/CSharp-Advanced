namespace _05._AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Func<int, int> add = n => n + 1;
            Func<int, int> multiply = n => n * 2;
            Func<int, int> subtract = n => n - 1;
            Action<List<int>> print = n => Console.WriteLine(string.Join(" ", n));

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(n => add(n)).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(n => multiply(n)).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => subtract(n)).ToList();
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}