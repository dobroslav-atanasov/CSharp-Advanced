namespace _08._RecursiveFibonacci
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Stack<long> fibonacci = new Stack<long>();
            fibonacci.Push(1);
            fibonacci.Push(1);

            for (int i = 3; i <= number; i++)
            {
                long nextNumber = GetFibonacci(fibonacci);
                fibonacci.Push(nextNumber);
            }

            Console.WriteLine(fibonacci.Peek());
        }

        private static long GetFibonacci(Stack<long> fibonacci)
        {
            long firstNumber = fibonacci.Pop();
            long secondNumber = fibonacci.Peek();
            fibonacci.Push(firstNumber);
            long nextNumber = firstNumber + secondNumber;
            return nextNumber;
        }
    }
}