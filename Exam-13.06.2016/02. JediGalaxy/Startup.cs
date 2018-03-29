namespace _02._JediGalaxy
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
            int[][] matrix = CreateMatrix(rows, cols);

            long points = 0;
            string input = Console.ReadLine();
            while (input != "Let the Force be with you")
            {
                int[] ivoStartPosition = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int ivoRow = ivoStartPosition[0];
                int ivoCol = ivoStartPosition[1];

                int[] evilStartPostion = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int evilRow = evilStartPostion[0];
                int evilCol = evilStartPostion[1];

                GetAllEvilPositions(matrix, evilRow, evilCol);
                points += GetAllPoints(matrix, ivoRow, ivoCol);

                input = Console.ReadLine();
            }

            Console.WriteLine(points);
        }

        private static long GetAllPoints(int[][] matrix, int ivoRow, int ivoCol)
        {
            long points = 0;
            while (ivoRow >= 0 && ivoCol < matrix[0].Length)
            {
                if (CheckPositionInMatrix(matrix, ivoRow, ivoCol))
                {
                    points += matrix[ivoRow][ivoCol];
                }
                ivoRow--;
                ivoCol++;
            }
            return points;
        }

        private static void GetAllEvilPositions(int[][] matrix, int evilRow, int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (CheckPositionInMatrix(matrix, evilRow, evilCol))
                {
                    matrix[evilRow][evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private static bool CheckPositionInMatrix(int[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }
            return false;
        }

        private static int[][] CreateMatrix(int rows, int cols)
        {
            int[][] matrix = new int[rows][];
            int number = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = number;
                    number++;
                }
            }
            return matrix;
        }
    }
}