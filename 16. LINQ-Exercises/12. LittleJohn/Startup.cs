namespace _12._LittleJohn
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string arrowPattern = @">{1,3}-{5}>{1,2}";
            string smallArrowPattern = @">{1}-{5}>{1}";
            string mediumArrowPattern = @">{2}-{5}>{1}";
            string largeArrowPattern = @">{3}-{5}>{2}";

            int small = 0;
            int medium = 0;
            int large = 0;

            for (int i = 0; i < 4; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, arrowPattern);
                foreach (Match match in matches)
                {
                    Match largeArrow = Regex.Match(match.ToString(), largeArrowPattern);
                    if (largeArrow.Success)
                    {
                        large++;
                    }
                    else
                    {
                        Match mediumArrow = Regex.Match(match.ToString(), mediumArrowPattern);
                        if (mediumArrow.Success)
                        {
                            medium++;
                        }
                        else
                        {
                            Match smallArrow = Regex.Match(match.ToString(), smallArrowPattern);
                            if (smallArrow.Success)
                            {
                                small++;
                            }
                        }
                    }
                }
            }

            string numberToString = $"{small}{medium}{large}";
            int number = int.Parse(numberToString);
            string convertToBinary = Convert.ToString(number, 2);
            string reverse = new string(convertToBinary.ToCharArray().Reverse().ToArray());
            string result = $"{convertToBinary}{reverse}";
            int numberInMessage = Convert.ToInt32(result, 2);
            Console.WriteLine(numberInMessage);
        }
    }
}