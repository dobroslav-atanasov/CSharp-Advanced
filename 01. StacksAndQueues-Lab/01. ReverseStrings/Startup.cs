namespace _01._ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            foreach (char symbol in input)
            {
                stack.Push(symbol);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}