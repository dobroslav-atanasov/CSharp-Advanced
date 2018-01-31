namespace _04._SpecialWords
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string[] separators = new string[] { "(", ")", "[", "]", "<", ">", ",", "-", "!", "?", "and", " ", "‘", "’" };
            string[] inputWords = Console.ReadLine().Split(' ');

            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (string word in inputWords)
            {
                if (!words.ContainsKey(word))
                {
                    words[word] = 0;
                }
            }

            string[] text = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in text)
            {
                if (words.ContainsKey(word))
                {
                    words[word]++;
                }
            }

            foreach (KeyValuePair<string, int> word in words)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}