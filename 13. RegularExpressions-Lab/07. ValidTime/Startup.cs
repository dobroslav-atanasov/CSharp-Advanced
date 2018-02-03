namespace _07._ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"^(\d{2})\:(\d{2})\:(\d{2}) (AM|PM)$";

            while (input != "END")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    int hour = int.Parse(match.Groups[1].Value);
                    int minutes = int.Parse(match.Groups[2].Value);
                    int seconds = int.Parse(match.Groups[3].Value);

                    if (match.Groups[4].Value == "AM")
                    {
                        if (hour <= 12 && minutes <= 59 && seconds <= 59)
                        {
                            Console.WriteLine("valid");
                        }
                        else
                        {
                            Console.WriteLine("invalid");
                        }
                    }
                    else
                    {
                        if (hour <= 11 && minutes <= 59 && seconds <= 59)
                        {
                            Console.WriteLine("valid");
                        }
                        else
                        {
                            Console.WriteLine("invalid");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("invalid");
                }
                input = Console.ReadLine();
            }
        }
    }
}