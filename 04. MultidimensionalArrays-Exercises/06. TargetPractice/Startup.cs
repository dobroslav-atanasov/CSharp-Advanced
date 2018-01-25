namespace _06._TargetPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string snake = Console.ReadLine();
            int[] shotParameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int shotRow = shotParameters[0];
            int shotCol = shotParameters[1];
            int shotRadius = shotParameters[2];

            char[][] matrix = FillMatrix(rows, cols, snake);
            MatrixAfterShot(matrix, shotRow, shotCol, shotRadius);
            Rearrange(matrix);

            foreach (char[] line in matrix)
            {
                Console.WriteLine(string.Join(string.Empty, line));
            }
        }

        private static void Rearrange(char[][] matrix)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                List<char> list = new List<char>();
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    if (matrix[row][col] != ' ')
                    {
                        list.Add(matrix[row][col]);
                    }
                }

                for (int i = list.Count; i < matrix.Length; i++)
                {
                    list.Add(' ');
                }
                for (int row = 0; row < matrix.Length; row++)
                {
                    matrix[row][col] = list[list.Count - 1 - row];
                }
            }
        }

        private static void MatrixAfterShot(char[][] matrix, int shotRow, int shotCol, int shotRadius)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    double distance = Math.Sqrt(Math.Pow(row - shotRow, 2) + Math.Pow(col - shotCol, 2));
                    if (distance <= shotRadius)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static char[][] FillMatrix(int rows, int cols, string snake)
        {
            char[][] matrix = new char[rows][];
            int index = 0;
            int numberOfRows = 0;
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];
                if (numberOfRows % 2 == 0)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row][col] = snake[index % snake.Length];
                        index++;
                    }
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row][col] = snake[index % snake.Length];
                        index++;
                    }
                }
                numberOfRows++;
            }
            return matrix;
        }
    }
}