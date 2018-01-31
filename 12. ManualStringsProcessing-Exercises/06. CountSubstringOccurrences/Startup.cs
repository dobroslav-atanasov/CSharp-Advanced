namespace _06._CountSubstringOccurrences
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string str = Console.ReadLine().ToLower();

            int indexOfStr = text.IndexOf(str);
            int count = 0;
            while (indexOfStr != -1)
            {
                count++;
                indexOfStr = text.IndexOf(str, indexOfStr + 1);
            }

            Console.WriteLine(count);
        }
    }
}