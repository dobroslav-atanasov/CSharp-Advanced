namespace _05._ConcatenateStrings
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numberOfLines; i++)
            {
                string text = Console.ReadLine();
                sb.Append(text + " ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}