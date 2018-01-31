namespace _04._ConvertFromBase10ToBaseN
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int @base = int.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);
            StringBuilder resultNumber = new StringBuilder();

            while (number > 0)
            {
                BigInteger digit = number % @base;
                resultNumber.Append(digit);
                number /= @base;
            }

            Console.WriteLine(resultNumber.ToString().Reverse().ToArray());
        }
    }
}