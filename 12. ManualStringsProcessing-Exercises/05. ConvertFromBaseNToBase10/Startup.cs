namespace _05._ConvertFromBaseNToBase10
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Startup
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int @base = int.Parse(input[0]);
            char[] number = input[1].Reverse().ToArray();
            BigInteger resultNumber = 0;

            for (int power = 0; power < number.Length; power++)
            {
                int digit = int.Parse(number[power].ToString());
                resultNumber += digit * BigInteger.Pow(@base, power);
            }

            Console.WriteLine(resultNumber);
        }
    }
}