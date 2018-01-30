namespace _05._SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        private const string SourcePath = "FerrisWheel.jpg";
        private const string DestinationDirPath = @"D:\PROJECTS\CSharp Advanced\08. FilesAndStreams-Exercises\05. SlicingFile\";
        private static List<string> slicedFiles = new List<string>();

        public static void Main()
        {
            Console.Write($"Please enter the number of pieces: ");
            int pieces = int.Parse(Console.ReadLine());
            Slice(SourcePath, DestinationDirPath, pieces);
            Assemble(slicedFiles, DestinationDirPath);
        }

        private static void Assemble(List<string> slicedFiles, string destinationDir)
        {
            for (int i = 0; i < slicedFiles.Count; i++)
            {
                FileStream source = new FileStream(slicedFiles[i], FileMode.Open);
                FileStream destination = new FileStream(destinationDir + $"FerrisWheel-NEW.jpg", FileMode.Append);
                using (source)
                {
                    using (destination)
                    {
                        byte[] buffer = new byte[source.Length];
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }

        private static void Slice(string source, string destinationDir, int pieces)
        {
            FileStream fileReader = new FileStream(source, FileMode.Open, FileAccess.Read);
            using (fileReader)
            {
                double fileSize = Math.Ceiling((double) fileReader.Length / pieces);
                for (int i = 1; i <= pieces; i++)
                {
                    FileStream fileWriter = new FileStream(destinationDir + $"FerrisWheel-Part{i}.jpg", FileMode.Create);
                    using (fileWriter)
                    {
                        byte[] buffer = new byte[(int)fileSize];
                        int readBytes = fileReader.Read(buffer, 0, buffer.Length);
                        fileWriter.Write(buffer, 0, readBytes);
                        slicedFiles.Add(destinationDir + $"FerrisWheel-Part{i}.jpg");
                    }
                }
            }
        }
    }
}