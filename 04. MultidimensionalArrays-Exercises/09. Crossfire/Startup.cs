namespace _09._Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            List<List<int>> matrix = FillMatrix(rows, cols);

            string input = Console.ReadLine();
            while (input != "Nuke it from orbit")
            {
                int[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                int shotRow = inputParts[0];
                int shotCol = inputParts[1];
                int radius = inputParts[2];

                Destroying(matrix, shotRow, shotCol, radius, cols);
                Rearrange(matrix, rows, cols);
                input = Console.ReadLine();
            }

            foreach (List<int> line in matrix)
            {
                Console.WriteLine(string.Join(" ", line));
            }
        }

        private static void Rearrange(List<List<int>> matrix, int rows, int cols)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                List<int> line = matrix[row].Where(n => n > 0).ToList();
                if (line.Count > 0)
                {
                    matrix[row] = line;
                }
                else
                {
                    matrix.RemoveAt(row);
                    row--;
                }
            }
        }

        private static void Destroying(List<List<int>> matrix, int shotRow, int shotCol, int radius, int cols)
        {
            if (shotRow >= 0 && shotRow < matrix.Count)
            {
                for (int col = Math.Max(0, shotCol - radius);
                    col <= Math.Min(matrix[shotRow].Count - 1, shotCol + radius);
                    col++)
                {
                    matrix[shotRow][col] = 0;
                }
            }
            if (shotCol >= 0 && shotCol < matrix[0].Count)
            {
                for (int row = Math.Max(0, shotRow - radius);
                    row <= Math.Min(matrix.Count - 1, shotRow + radius);
                    row++)
                {
                    if (shotCol < matrix[row].Count)
                    {
                        matrix[row][shotCol] = 0;
                    }
                }
            }
        }

        private static List<List<int>> FillMatrix(int rows, int cols)
        {
            List<List<int>> matrix = new List<List<int>>();
            int number = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>());
                for (int col = 0; col < cols; col++)
                {
                    matrix[row].Add(number);
                    number++;
                }
            }
            return matrix;
        }
    }
}