namespace _01._MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[][] matrix = new string[rows][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[cols];
                for (int col = 0; col < cols; col++)
                {
                    string element = $"{alphabet[row]}{alphabet[row + col]}{alphabet[row]}";
                    matrix[row][col] = element;
                }
            }

            foreach (string[] line in matrix)
            {
                Console.WriteLine(string.Join(" ", line));
            }
        }
    }
}