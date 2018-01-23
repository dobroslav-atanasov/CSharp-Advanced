namespace _03._MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int numberOfQueries = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numberOfQueries; i++)
            {
                int[] inputParts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int command = inputParts[0];

                switch (command)
                {
                    case 1:
                        int number = inputParts[1];
                        stack.Push(number);
                        if (number > maxNumber)
                        {
                            maxNumber = number;
                        }
                        break;
                    case 2:
                        stack.Pop();
                        if (stack.Count > 0)
                        {
                            maxNumber = stack.Max();
                        }
                        break;
                    case 3:
                        Console.WriteLine(maxNumber);
                        break;
                }
            }
        }
    }
}