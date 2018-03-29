namespace _03._CubicMessages
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            while (input != "Over!")
            {
                int lengthMessage = int.Parse(Console.ReadLine());
                string pattern = $@"^(\d+)([A-Za-z]{{{lengthMessage}}})([^A-Za-z]*)$";

                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string message = match.Groups[2].Value;
                    string symbols = $"{match.Groups[1]}{match.Groups[3]}";
                    char[] indexes = symbols.ToCharArray();

                    string verificationCode = string.Empty;
                    for (int i = 0; i < indexes.Length; i++)
                    {
                        if (Char.IsDigit(indexes[i]))
                        {
                            int index = int.Parse(indexes[i].ToString());
                            if (index >= 0 && index < message.Length)
                            {
                                verificationCode += message[index].ToString();
                            }
                            else
                            {
                                verificationCode += " ";
                            }
                        }
                    }

                    Console.WriteLine($"{message} == {verificationCode}");
                }
                input = Console.ReadLine();
            }
        }
    }
}