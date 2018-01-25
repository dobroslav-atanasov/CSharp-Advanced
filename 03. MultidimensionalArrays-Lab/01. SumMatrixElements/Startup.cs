namespace _01._SumMatrixElements
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
                matrix[row] = Console.ReadLine().Split(new []{' ', ','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int sum = 0;
            foreach (int[] line in matrix)
            {
                sum += line.Sum();
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}