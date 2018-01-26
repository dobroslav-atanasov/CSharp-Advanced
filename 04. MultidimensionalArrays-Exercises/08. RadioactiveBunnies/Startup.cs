namespace _08._RadioactiveBunnies
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
            char[][] matrix = FillMatrix(rows);
            char[] commands = Console.ReadLine().ToCharArray();

            List<int> playerPosition = FindPlayerPosition(matrix);
            int playerRow = playerPosition[0];
            int playerCol = playerPosition[1];
            int lastRowPosition = 0;
            int lastColPosition = 0;
            bool isWin = false;
            bool isDead = false;

            for (int i = 0; i < commands.Length; i++)
            {
                lastRowPosition = playerRow;
                lastColPosition = playerCol;
                char command = commands[i];
                switch (command)
                {
                    case 'U':
                        playerRow -= 1;
                        matrix[playerRow + 1][playerCol] = '.';
                        matrix = GetMatrixAfterCommand(matrix);
                        if (playerRow < 0)
                        {
                            isWin = true;
                            break;
                        }
                        if (matrix[playerRow][playerCol] == 'B')
                        {
                            isDead = true;
                            break;
                        }
                        break;
                    case 'D':
                        playerRow += 1;
                        matrix[playerRow - 1][playerCol] = '.';
                        matrix = GetMatrixAfterCommand(matrix);
                        if (playerRow >= matrix.Length)
                        {
                            isWin = true;
                            break;
                        }
                        if (matrix[playerRow][playerCol] == 'B')
                        {
                            isDead = true;
                            break;
                        }
                        break;
                    case 'L':
                        playerCol -= 1;
                        matrix[playerRow][playerCol + 1] = '.';
                        matrix = GetMatrixAfterCommand(matrix);
                        if (playerCol < 0)
                        {
                            isWin = true;
                            break;
                        }
                        if (matrix[playerRow][playerCol] == 'B')
                        {
                            isDead = true;
                            break;
                        }
                        break;
                    case 'R':
                        playerCol += 1;
                        matrix[playerRow][playerCol - 1] = '.';
                        matrix = GetMatrixAfterCommand(matrix);
                        if (playerCol >= matrix[0].Length)
                        {
                            isWin = true;
                            break;
                        }
                        if (matrix[playerRow][playerCol] == 'B')
                        {
                            isDead = true;
                            break;
                        }
                        break;
                }

                if (isWin)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {lastRowPosition} {lastColPosition}");
                    break;
                }
                else if (isDead)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (char[] line in matrix)
            {
                Console.WriteLine(string.Join(string.Empty, line));
            }
        }

        private static char[][] GetMatrixAfterCommand(char[][] matrix)
        {
            char[][] newMatrix = new char[matrix.Length][];
            for (int row = 0; row < newMatrix.Length; row++)
            {
                newMatrix[row] = new char[matrix[0].Length];
                for (int col = 0; col < newMatrix[0].Length; col++)
                {
                    newMatrix[row][col] = matrix[row][col];
                }
            }

            for (int row = 0; row < newMatrix.Length; row++)
            {
                for (int col = 0; col < newMatrix[0].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        if (col + 1 < newMatrix[0].Length)
                        {
                            newMatrix[row][col + 1] = 'B';
                        }
                        if (col - 1 >= 0)
                        {
                            newMatrix[row][col - 1] = 'B';
                        }
                        if (row + 1 < newMatrix.Length)
                        {
                            newMatrix[row + 1][col] = 'B';
                        }
                        if (row - 1 >= 0)
                        {
                            newMatrix[row - 1][col] = 'B';
                        }
                    }
                }
            }
            return newMatrix;
        }

        private static List<int> FindPlayerPosition(char[][] matrix)
        {
            List<int> playerPosition = new List<int>();
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        playerPosition.Add(row);
                        playerPosition.Add(col);
                    }
                }
            }
            return playerPosition;
        }

        private static char[][] FillMatrix(int rows)
        {
            char[][] matrix = new char[rows][];
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] inputLine = Console.ReadLine().ToCharArray();
                matrix[row] = inputLine;
            }
            return matrix;
        }
    }
}