namespace _03._WritingToFile
{
    using System.IO;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            FileStream fileStream = new FileStream("file.txt", FileMode.Create);
            string word = "Кирилица";
            using (fileStream)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(word);
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}