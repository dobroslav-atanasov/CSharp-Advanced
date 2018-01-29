namespace _09._GZipStreams
{
    using System.IO;
    using System.IO.Compression;

    public class Startup
    {
        public static void Main()
        {
            Compress("file.txt", "zipped.gz");
            Decompress("zipped.gz", "result.txt");
        }

        private static void Decompress(string zippedGz, string resultTxt)
        {
            FileStream source = new FileStream(zippedGz, FileMode.Open);
            FileStream destination = new FileStream(resultTxt, FileMode.Create);
            GZipStream decompressStream = new GZipStream(source, CompressionMode.Decompress, false);
            using (source)
            {
                using (decompressStream)
                {
                    using (destination)
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = decompressStream.Read(buffer, 0, buffer.Length);
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

        private static void Compress(string fileTxt, string zippedGz)
        {
            FileStream source = new FileStream(fileTxt, FileMode.Open);
            FileStream destination = new FileStream(zippedGz, FileMode.Create);
            GZipStream compressStream = new GZipStream(destination, CompressionMode.Compress, false);
            using (source)
            {
                using (destination)
                {
                    using (compressStream)
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }
                            compressStream.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }
    }
}