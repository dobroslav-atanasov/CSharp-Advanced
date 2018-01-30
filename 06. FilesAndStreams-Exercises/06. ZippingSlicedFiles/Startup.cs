namespace _06._ZippingSlicedFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;

    public class Startup
    {
        private const string SourcePath = "FerrisWheel.jpg";
        private const string DestinationDirPath = @"D:\PROJECTS\CSharp Advanced\08. FilesAndStreams-Exercises\06. ZippingSlicedFiles\";
        private const string DestiantionPath = "FerrisWheel-NEW.jpg";
        private static List<string> slicedFiles = new List<string>();

        public static void Main()
        {
            Console.Write($"Please enter the number of pieces: ");
            int pieces = int.Parse(Console.ReadLine());
            Slice(SourcePath, DestinationDirPath, pieces);
            Assemble(slicedFiles);
        }

        private static void Assemble(List<string> slicedFiles)
        {
            for (int i = 0; i < slicedFiles.Count; i++)
            {
                FileStream source = new FileStream(slicedFiles[i], FileMode.Open);
                GZipStream decompressStream = new GZipStream(source, CompressionMode.Decompress, false);
                FileStream destination = new FileStream(DestiantionPath, FileMode.Append);
                using (source)
                {
                    using (decompressStream)
                    {
                        using (destination)
                        {
                            byte[] buffer = new byte[source.Length];
                            int readBytes = decompressStream.Read(buffer, 0, buffer.Length);
                            destination.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        private static void Slice(string sourcePath, string destinationDirPath, int pieces)
        {
            FileStream fileReader = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            using (fileReader)
            {
                double fileSize = Math.Ceiling((double) fileReader.Length / pieces);
                for (int i = 1; i <= pieces; i++)
                {
                    FileStream fileWriter = new FileStream(destinationDirPath + $"FerrisWheel-Part{i}.gz", FileMode.Create);
                    GZipStream compressStream = new GZipStream(fileWriter, CompressionMode.Compress, false);
                    using (fileWriter)
                    {
                        byte[] buffer = new byte[(int)fileSize];
                        int readBytes = fileReader.Read(buffer, 0, buffer.Length);
                        compressStream.Write(buffer, 0, readBytes);
                        slicedFiles.Add(destinationDirPath + $"FerrisWheel-Part{i}.gz");
                    }
                }
            }
        }
    }
}