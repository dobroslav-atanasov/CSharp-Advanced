namespace _01._Regeh
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\[\w+<(\d+)REGEH(\d+)>\w+\]";

            MatchCollection matches = Regex.Matches(input, pattern);
            string newText = string.Empty;
            int index = 0;

            foreach (Match match in matches)
            {
                int firstNumber = int.Parse(match.Groups[1].Value);
                int secondNumber = int.Parse(match.Groups[2].Value);

                index += firstNumber;
                if (index >= input.Length)
                {
                    int currentIndex = index % input.Length + 1;
                    newText += input[currentIndex];
                }
                else
                {
                    newText += input[index];
                }

                index += secondNumber;
                if (index >= input.Length)
                {
                    int currentIndex = index % input.Length + 1;
                    newText += input[currentIndex];
                }
                else
                {
                    newText += input[index];
                }
            }

            Console.WriteLine(newText);
        }
    }
}