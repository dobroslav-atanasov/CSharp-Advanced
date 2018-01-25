namespace _05._RubiksMatrix
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Startup
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[][] matrix = FillMatrix(rows, cols);

            ParseCommands(matrix, rows, cols);
            Rearrange(matrix);
        }

        private static void Rearrange(int[][] matrix)
        {
            int number = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == number)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                        {
                            for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                            {
                                if (matrix[rowIndex][colIndex] == number)
                                {
                                    int currentNumber = matrix[row][col];
                                    matrix[row][col] = number;
                                    matrix[rowIndex][colIndex] = currentNumber;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({rowIndex}, {colIndex})");
                                    break;
                                }
                            }
                        }
                    }
                    number++;
                }
            }
        }

        private static void ParseCommands(int[][] matrix, int rows, int cols)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int position = int.Parse(commandParts[0]);
                string direction = commandParts[1];
                int moves = int.Parse(commandParts[2]);

                switch (direction)
                {
                    case "left":
                        MoveLeftOrRight(matrix, position, moves);
                        break;
                    case "right":
                        MoveLeftOrRight(matrix, position, cols - moves % cols);
                        break;
                    case "up":
                        MoveUpOrDown(matrix, position, moves);
                        break;
                    case "down":
                        MoveUpOrDown(matrix, position, rows - moves % rows);
                        break;
                }
            }
        }

        private static void MoveUpOrDown(int[][] matrix, int position, int moves)
        {
            int[] newArray = new int[matrix.Length];
            for (int row = 0; row < matrix.Length; row++)
            {
                newArray[row] = matrix[(row + moves) % matrix.Length][position];
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][position] = newArray[row];
            }
        }

        private static void MoveLeftOrRight(int[][] matrix, int position, int moves)
        {
            int[] newRow = new int[matrix[0].Length];
            for (int col = 0; col < matrix[0].Length; col++)
            {
                newRow[col] = matrix[position][(col + moves) % matrix[0].Length];
            }
            matrix[position] = newRow;
        }

        private static int[][] FillMatrix(int rows, int cols)
        {
            int[][] matrix = new int[rows][];
            int number = 1;
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