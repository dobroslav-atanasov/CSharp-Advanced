namespace _07._DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.Write("Please enter the directory: ");
            string directory = Console.ReadLine() + "\\";
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            Dictionary<string, List<FileInfo>> allFiles = new Dictionary<string, List<FileInfo>>();
            GetFiles(dirInfo, allFiles);

            string report = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\report.txt";
            StreamWriter writer = new StreamWriter(report);
            using (writer)
            {
                foreach (KeyValuePair<string, List<FileInfo>> kvp in allFiles.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key))
                {
                    writer.WriteLine(kvp.Key);
                    foreach (FileInfo fileInfo in kvp.Value)
                    {
                        writer.WriteLine($"--{fileInfo.Name} - {fileInfo.Length / 1024}kb");
                    }
                }
            }
        }

        private static void GetFiles(DirectoryInfo dirInfo, Dictionary<string, List<FileInfo>> allFiles)
        {
            FileInfo[] files = dirInfo.GetFiles(".");
            foreach (FileInfo file in files)
            {
                string fileExtension = Path.GetExtension(file.FullName);
                if (!allFiles.ContainsKey(fileExtension))
                {
                    allFiles[fileExtension] = new List<FileInfo>();
                }
                allFiles[fileExtension].Add(file);
            }
        }
    }
}