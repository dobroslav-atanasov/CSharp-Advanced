namespace _08._MultiplyBigNumber
{
    using System;
    using System.Numerics;

    public class Startup
    {
        public static void Main()
        {
            BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
            BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());

            Console.WriteLine(firstNumber * secondNumber);
        }
    }
}