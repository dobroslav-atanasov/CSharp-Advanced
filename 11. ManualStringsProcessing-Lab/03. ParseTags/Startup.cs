namespace _03._ParseTags
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string startUpcase = "<upcase>";
            string endUpcase = "</upcase>";
            int startIndex = text.IndexOf(startUpcase);
            int endIndex = text.IndexOf(endUpcase);

            while (startIndex != -1 && endIndex != -1)
            {
                string oldString = text.Substring(startIndex, endIndex - startIndex + 9);
                string newString = text.Substring(startIndex + 8, endIndex - startIndex - 8).ToUpper();
                text = text.Replace(oldString, newString);
                startIndex = text.IndexOf(startUpcase);
                endIndex = text.IndexOf(endUpcase);
            }
            Console.WriteLine(text);
        }
    }
}