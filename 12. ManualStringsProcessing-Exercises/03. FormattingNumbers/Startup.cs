namespace _03._FormattingNumbers
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int numA = int.Parse(numbers[0]);
            double numB = double.Parse(numbers[1]);
            double numC = double.Parse(numbers[2]);
            string numAToHexadecimal = numA.ToString("X");
            string numAToBinary = Convert.ToString(numA, 2);

            if (numAToBinary.Length < 10)
            {
                numAToBinary = numAToBinary.PadLeft(10, '0');
            }
            else
            {
                while (numAToBinary.Length > 10)
                {
                    numAToBinary = numAToBinary.Remove(numAToBinary.Length - 1, 1);
                }
            }

            Console.WriteLine(string.Format("|{0,-10}|{1,10}|{2,10:F2}|{3,-10:F3}|", numAToHexadecimal, numAToBinary, numB, numC));
        }
    }
}