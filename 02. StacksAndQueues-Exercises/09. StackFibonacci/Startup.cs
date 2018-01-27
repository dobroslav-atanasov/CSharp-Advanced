namespace _09._StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            for (int i = 2; i <= number; i++)
            {
                long secondNumber = stack.Pop();
                long firstNumber = stack.Pop();
                long thirdNumber = firstNumber + secondNumber;
                stack.Push(secondNumber);
                stack.Push(thirdNumber);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}