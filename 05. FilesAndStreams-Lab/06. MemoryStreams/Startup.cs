namespace _06._MemoryStreams
{
    using System;
    using System.IO;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string text = "Hello this is course of CSharp Advanced!";
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            MemoryStream memoryStream = new MemoryStream(bytes);
            using (memoryStream)
            {
                while (true)
                {
                    int readBytes = memoryStream.ReadByte();
                    if (readBytes == -1)
                    {
                        break;
                    }
                    Console.WriteLine($"{(char)readBytes} --- {readBytes.ToString("X")} --- {readBytes}");
                }
            }
        }
    }
}