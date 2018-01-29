namespace _02._WriteFiles
{
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("Startup.cs");
            StreamWriter writer = new StreamWriter("reversed.txt");

            using (reader)
            {
                using (writer)
                {
                    string input = reader.ReadLine();
                    while (input != null)
                    {
                        for (int i = input.Length - 1; i >= 0; i--)
                        {
                            writer.Write(input[i]);
                        }
                        writer.WriteLine();
                        input = reader.ReadLine();
                    }
                }
            }
        }
    }
}