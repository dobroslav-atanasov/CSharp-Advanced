namespace Sneaking
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = FillMatrix(rows);
            char[] input = Console.ReadLine().ToCharArray();
            int rowSam = 0;
            int colSam = 0;
            int rowNikoladze = 0;
            int colNikoladze = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        rowSam = row;
                        colSam = col;
                    }
                    if (matrix[row][col] == 'N')
                    {
                        rowNikoladze = row;
                        colNikoladze = col;
                    }
                }
            }

            bool isSamDead = false;
            int nextRowSam = rowSam;
            int nextColSam = colSam;
            while (true)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    char command = input[i];
                    switch (command)
                    {
                        case 'U':
                            nextRowSam -= 1;
                            MoveEnemies(matrix);

                            if (nextRowSam == rowNikoladze)
                            {
                                Console.WriteLine("Nikoladze killed!");
                                matrix[rowSam][colSam] = '.';
                                rowSam = nextRowSam;
                                colSam = nextColSam;
                                matrix[rowSam][colSam] = 'S';
                                matrix[rowNikoladze][colNikoladze] = 'X';
                                PrintMatrix(matrix);
                                return;
                            }
                            isSamDead = CheckForEnemies(matrix, rowSam, colSam);
                            if (isSamDead)
                            {
                                Console.WriteLine($"Sam died at {rowSam}, {colSam}");
                                matrix[rowSam][colSam] = 'X';
                                PrintMatrix(matrix);
                                return;
                            }
                            matrix[rowSam][colSam] = '.';
                            rowSam = nextRowSam;
                            colSam = nextColSam;
                            matrix[rowSam][colSam] = 'S';
                            break;
                        case 'D':
                            nextRowSam += 1;
                            MoveEnemies(matrix);
                            if (nextRowSam == rowNikoladze)
                            {
                                Console.WriteLine("Nikoladze killed!");
                                matrix[rowSam][colSam] = '.';
                                rowSam = nextRowSam;
                                colSam = nextColSam;
                                matrix[rowSam][colSam] = 'S';
                                matrix[rowNikoladze][colNikoladze] = 'X';
                                PrintMatrix(matrix);
                                return;
                            }
                            isSamDead = CheckForEnemies(matrix, rowSam, colSam);
                            if (isSamDead)
                            {
                                Console.WriteLine($"Sam died at {rowSam}, {colSam}");
                                matrix[rowSam][colSam] = 'X';
                                PrintMatrix(matrix);
                                return;
                            }
                            matrix[rowSam][colSam] = '.';
                            rowSam = nextRowSam;
                            colSam = nextColSam;
                            matrix[rowSam][colSam] = 'S';
                            break;
                        case 'L':
                            nextColSam -= 1;
                            MoveEnemies(matrix);
                            isSamDead = CheckForEnemies(matrix, rowSam, colSam);
                            if (isSamDead)
                            {
                                Console.WriteLine($"Sam died at {rowSam}, {colSam}");
                                matrix[rowSam][colSam] = 'X';
                                PrintMatrix(matrix);
                                return;
                            }
                            matrix[rowSam][colSam] = '.';
                            rowSam = nextRowSam;
                            colSam = nextColSam;
                            matrix[rowSam][colSam] = 'S';
                            break;
                        case 'R':
                            nextColSam += 1;
                            MoveEnemies(matrix);
                            isSamDead = CheckForEnemies(matrix, rowSam, colSam);
                            if (isSamDead)
                            {
                                Console.WriteLine($"Sam died at {rowSam}, {colSam}");
                                matrix[rowSam][colSam] = 'X';
                                PrintMatrix(matrix);
                                return;
                            }
                            matrix[rowSam][colSam] = '.';
                            rowSam = nextRowSam;
                            colSam = nextColSam;
                            matrix[rowSam][colSam] = 'S';
                            break;
                        case 'W':
                            MoveEnemies(matrix);
                            isSamDead = CheckForEnemies(matrix, rowSam, colSam);
                            if (isSamDead)
                            {
                                Console.WriteLine($"Sam died at {rowSam}, {colSam}");
                                matrix[rowSam][colSam] = 'X';
                                PrintMatrix(matrix);
                                return;
                            }
                            matrix[rowSam][colSam] = '.';
                            rowSam = nextRowSam;
                            colSam = nextColSam;
                            matrix[rowSam][colSam] = 'S';
                            break;
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine($"{string.Join("", matrix[row])}");
            }
        }

        private static bool CheckForEnemies(char[][] matrix, int rowSam, int colSam)
        {
            for (int col = 0; col < colSam; col++)
            {
                if (matrix[rowSam][col] == 'b')
                {
                    return true;
                }
            }
            for (int col = colSam; col < matrix[0].Length; col++)
            {
                if (matrix[rowSam][col] == 'd')
                {
                    return true;
                }
            }
            return false;
        }

        private static void MoveEnemies(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        if (col + 1 == matrix[row].Length)
                        {
                            matrix[row][col] = 'd';
                            break;
                        }
                        else
                        {
                            matrix[row][col + 1] = 'b';
                            matrix[row][col] = '.';
                            break;
                        }
                    }

                    if (matrix[row][col] == 'd')
                    {
                        if (col - 1 < 0)
                        {
                            matrix[row][col] = 'b';
                            break;
                        }
                        else
                        {
                            matrix[row][col - 1] = 'd';
                            matrix[row][col] = '.';
                            break;
                        }
                    }
                }
            }
        }

        private static char[][] FillMatrix(int rows)
        {
            char[][] matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                matrix[row] = input;
            }
            return matrix;
        }
    }
}