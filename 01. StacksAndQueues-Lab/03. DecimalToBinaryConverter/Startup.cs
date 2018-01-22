namespace _03._DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            if (number == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (number > 0)
                {
                    int remainder = number % 2;
                    stack.Push(remainder);
                    number /= 2;
                }
            }

            Console.WriteLine(string.Join(string.Empty, stack));
        }
    }
}