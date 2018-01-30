namespace _04._CopyBinaryFile
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            FileStream source = new FileStream("FerrisWheel.jpg", FileMode.Open);
            FileStream destination = new FileStream("FerrisWheelCopy.jpg", FileMode.Create);

            using (source)
            {
                using (destination)
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}