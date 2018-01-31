namespace _14._LettersChangeNumbers
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] inputParts = Console.ReadLine().Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;
            foreach (string part in inputParts)
            {
                char firstLetter = part[0];
                char secondLetter = part[part.Length - 1];
                double number = double.Parse(part.Substring(1, part.Length - 2));

                if (Char.IsUpper(firstLetter))
                {
                    int position = (int) firstLetter - 64;
                    number /= position;
                }
                else
                {
                    int position = (int)firstLetter - 96;
                    number *= position;
                }

                if (Char.IsUpper(secondLetter))
                {
                    int position = (int)secondLetter - 64;
                    number -= position;
                }
                else
                {
                    int position = (int)secondLetter - 96;
                    number += position;
                }
                sum += number;
            }

            Console.WriteLine($"{sum:F2}");
        }
    }
}