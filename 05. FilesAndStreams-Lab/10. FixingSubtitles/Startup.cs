namespace _10._FixingSubtitles
{
    using System.IO;
    using System.Text.RegularExpressions;

    public class Startup
    {
        private const int Addition = 5000;

        public static void Main()
        {
            StreamReader reader = new StreamReader("source.sub");
            StreamWriter writer = new StreamWriter("fixed.sub");
            string pattern = @"{(\d+)}{(\d+)}\s(.*)";

            using (reader)
            {
                using (writer)
                {
                    string input = reader.ReadLine();
                    while (input != null)
                    {
                        Match match = Regex.Match(input, pattern);
                        int startTime = int.Parse(match.Groups[1].Value) + Addition;
                        int endTime = int.Parse(match.Groups[2].Value) + Addition;
                        string newLine = $"{{{startTime}}}{{{endTime}}} {match.Groups[3].Value}";
                        writer.WriteLine(newLine);
                        input = reader.ReadLine();
                    }
                }
            }
        }
    }
}