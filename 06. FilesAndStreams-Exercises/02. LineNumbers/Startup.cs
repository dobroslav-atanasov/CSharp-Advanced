namespace _02._LineNumbers
{
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("file.txt");
            StreamWriter writer = new StreamWriter("result.txt");
            using (reader)
            {
                using (writer)
                {
                    string input = reader.ReadLine();
                    int count = 1;
                    while (input != null)
                    {
                        writer.WriteLine($"Line {count}: {input}");
                        count++;
                        input = reader.ReadLine();
                    }
                }
            }
        }
    }
}