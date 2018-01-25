namespace _02._DiagonalDifference
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int primaryDiagonal = 0;
            for (int row = 0; row < size; row++)
            {
                primaryDiagonal += matrix[row][row];
            }

            int secondaryDiagonal = 0;
            for (int row = 0; row < size; row++)
            {
                secondaryDiagonal += matrix[row][size - row - 1];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}