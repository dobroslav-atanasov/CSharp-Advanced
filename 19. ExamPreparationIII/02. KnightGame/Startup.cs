namespace _02._KnightGame
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[][] matrix = FillMatrix(size);

            int knightInDanger = 0;
            int maxKnightInDanger = 0;
            int count = 0;
            int mostedDangerKnightRow = 0;
            int mostedDangerKnightCol = 0;

            while (true)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            if (IsInside(row - 2, col - 1, size))
                            {
                                if (matrix[row - 2][col - 1] == 'K')
                                {
                                    knightInDanger++;
                                }
                            }
                            if (IsInside(row - 2, col + 1, size))
                            {
                                if (matrix[row - 2][col + 1] == 'K')
                                {
                                    knightInDanger++;
                                }
                            }
                            if (IsInside(row + 2, col - 1, size))
                            {
                                if (matrix[row + 2][col - 1] == 'K')
                                {
                                    knightInDanger++;
                                }
                            }
                            if (IsInside(row + 2, col + 1, size))
                            {
                                if (matrix[row + 2][col + 1] == 'K')
                                {
                                    knightInDanger++;
                                }
                            }
                            if (IsInside(row - 1, col - 2, size))
                            {
                                if (matrix[row - 1][col - 2] == 'K')
                                {
                                    knightInDanger++;
                                }
                            }
                            if (IsInside(row - 1, col + 2, size))
                            {
                                if (matrix[row - 1][col + 2] == 'K')
                                {
                                    knightInDanger++;
                                }
                            }
                            if (IsInside(row + 1, col - 2, size))
                            {
                                if (matrix[row + 1][col - 2] == 'K')
                                {
                                    knightInDanger++;
                                }
                            }
                            if (IsInside(row + 1, col + 2, size))
                            {
                                if (matrix[row + 1][col + 2] == 'K')
                                {
                                    knightInDanger++;
                                }
                            }
                        }

                        if (knightInDanger > maxKnightInDanger)
                        {
                            maxKnightInDanger = knightInDanger;
                            mostedDangerKnightRow = row;
                            mostedDangerKnightCol = col;
                        }
                        knightInDanger = 0;
                    }
                }

                if (maxKnightInDanger != 0)
                {
                    matrix[mostedDangerKnightRow][mostedDangerKnightCol] = 'O';
                    maxKnightInDanger = 0;
                    count++;
                }
                else
                {
                    Console.WriteLine(count);
                    break;
                }
            }
        }

        private static bool IsInside(int row, int col, int size)
        {
            if (row >= 0 && row < size && col >= 0 && col < size)
            {
                return true;
            }
            return false;
        }

        private static char[][] FillMatrix(int size)
        {
            char[][] matrix = new char[size][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Trim().ToCharArray();
            }
            return matrix;
        }
    }
}