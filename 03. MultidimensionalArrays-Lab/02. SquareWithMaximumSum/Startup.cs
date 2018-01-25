namespace _02._SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[][] matrix = new int[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int maxSum = 0;
            int rowStartIndex = 0;
            int colStartIndex = 0;
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    int sum = matrix[row][col] + matrix[row][col + 1] + matrix[row + 1][col] + matrix[row + 1][col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        rowStartIndex = row;
                        colStartIndex = col;
                    }
                }
            }

            for (int row = rowStartIndex; row <= rowStartIndex + 1; row++)
            {
                for (int col = colStartIndex; col <= colStartIndex + 1; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}