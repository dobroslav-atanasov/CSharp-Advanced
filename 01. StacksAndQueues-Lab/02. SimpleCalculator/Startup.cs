namespace _02._SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string[] inputParts = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            IEnumerable<string> reverseInput = inputParts.Reverse();
            Stack<string> stack = new Stack<string>(reverseInput);
            int sum = int.Parse(stack.Pop());
            while (stack.Count > 0)
            {
                string @operator = stack.Pop();
                int number = int.Parse(stack.Pop());

                switch (@operator)
                {
                    case "+":
                        sum += number;
                        break;
                    case "-":
                        sum -= number;
                        break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}