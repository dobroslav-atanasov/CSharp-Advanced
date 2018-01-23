namespace _02._BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] inputParts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numbersToPop = inputParts[1];
            int searchedNumber = inputParts[2];

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            for (int i = 0; i < numbersToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(searchedNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count != 0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}