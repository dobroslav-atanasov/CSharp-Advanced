namespace _01._ReadFiles
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
                string line = reader.ReadLine();
                int numberOfLine = 1;
                while (line != null)
                {
                    Console.WriteLine($"Line {numberOfLine}: {line}");
                    numberOfLine++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}