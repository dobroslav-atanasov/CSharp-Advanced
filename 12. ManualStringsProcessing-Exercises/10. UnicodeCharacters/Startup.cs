namespace _10._UnicodeCharacters
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            foreach (char symbol in text)
            {
                string unicode = "\\u" + ((int) symbol).ToString("x").PadLeft(4, '0');
                sb.Append(unicode);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}