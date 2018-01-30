namespace _01._OddLines
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("file.txt");
            using (reader)
            {
                string input = reader.ReadLine();
                int count = 0;
                while (input != null)
                {
                    if (count % 2 != 0)
                    {
                        Console.WriteLine(input);
                    }
                    count++;
                    input = reader.ReadLine();
                }
            }
        }
    }
}