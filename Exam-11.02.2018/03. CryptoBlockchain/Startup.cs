namespace CryptoBlockchain
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            string pattern = @"((\{)[^\]\[]*?(\}))|((\[)[^\{\}]*?(\]))";
            string digitPattern = @"\d{3,}";

            string text = string.Empty;
            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                text += input;
            }

            string result = string.Empty;
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                int blockLength = match.ToString().Length;
                string numbers = string.Empty;
                MatchCollection digitMatches = Regex.Matches(match.ToString(), digitPattern);
                foreach (Match digtiMatch in digitMatches)
                {
                    numbers += digtiMatch.ToString();
                }

                if (numbers.Length % 3 == 0)
                {
                    for (int i = 0; i < numbers.Length - 2; i += 3)
                    {
                        string searchedNumber = $"{numbers[i]}{numbers[i + 1]}{numbers[i + 2]}";
                        int parsedNumber = int.Parse(searchedNumber);
                        parsedNumber -= blockLength;
                        result += (char)parsedNumber;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}