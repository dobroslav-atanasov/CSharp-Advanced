namespace _03._WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            StreamReader wordReader = new StreamReader("words.txt");
            StreamReader textReader = new StreamReader("text.txt");
            StreamWriter writer = new StreamWriter("result.txt");

            ReadWords(wordsCount, wordReader);
            ReadText(wordsCount, textReader);
            WriteResult(wordsCount, writer);
        }

        private static void WriteResult(Dictionary<string, int> wordsCount, StreamWriter writer)
        {
            using (writer)
            {
                foreach (KeyValuePair<string, int> kvp in wordsCount.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }

        private static void ReadText(Dictionary<string, int> wordsCount, StreamReader textReader)
        {
            using (textReader)
            {
                string line = textReader.ReadLine();
                while (line != null)
                {
                    string[] lineParts = line.Split(new[] { ' ', '\'', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in lineParts)
                    {
                        if (wordsCount.ContainsKey(word.ToLower()))
                        {
                            wordsCount[word.ToLower()]++;
                        }
                    }
                    line = textReader.ReadLine();
                }
            }
        }

        private static void ReadWords(Dictionary<string, int> wordsCount, StreamReader wordReader)
        {
            using (wordReader)
            {
                string word = wordReader.ReadLine();
                while (word != null)
                {
                    if (!wordsCount.ContainsKey(word))
                    {
                        wordsCount[word] = 0;
                    }
                    word = wordReader.ReadLine();
                }
            }
        }
    }
}