namespace _04._CopyFiles
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            FileStream source = new FileStream("FerrisWheel.jpg", FileMode.Open);
            FileStream destination = new FileStream("Result.jpg", FileMode.Create);

            using (source)
            {
                using (destination)
                {
                    double fileLength = source.Length;
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                        Console.WriteLine($"{(Math.Min(source.Position / fileLength, 1)):P2}");
                    }
                }
            }
        }
    }
}