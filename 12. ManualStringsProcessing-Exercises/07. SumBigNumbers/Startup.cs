namespace _07._SumBigNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            Stack<char> firstNumber = new Stack<char>(Console.ReadLine());
            Stack<char> secondNumber = new Stack<char>(Console.ReadLine());
            StringBuilder resultNumber = new StringBuilder();

            int sum = 0;
            while (firstNumber.Count != 0 || secondNumber.Count != 0)
            {
                sum /= 10;
                if (firstNumber.Count != 0)
                {
                    sum += int.Parse(firstNumber.Pop().ToString());
                }
                if (secondNumber.Count != 0)
                {
                    sum += int.Parse(secondNumber.Pop().ToString());
                }

                int digit = sum % 10;
                resultNumber.Insert(0, digit);
            }
            resultNumber.Insert(0, sum / 10);

            Console.WriteLine(resultNumber.ToString().TrimStart('0'));
        }
    }
}