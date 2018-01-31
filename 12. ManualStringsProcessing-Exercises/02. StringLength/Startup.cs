namespace _02._StringLength
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            if (text.Length >= 20)
            {
                text = text.Substring(0, 20);
            }
            else
            {
                string str = new string('*', 20 - text.Length);
                text += str;
            }

            Console.WriteLine(text);
        }
    }
}