namespace _07._BufferedWriter
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            FileStream fileStream = new FileStream("file.txt", FileMode.Create);
            using (fileStream)
            {
                for (int i = 0; i < 1000000; i++)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(i.ToString());
                    fileStream.Write(buffer, 0, buffer.Length);
                }
            }

            Console.WriteLine($"Done: {stopwatch.Elapsed}");
        }
    }
}