namespace _01._DangerousFloor
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            char[][] matrix = FillMatrix();
            string input = Console.ReadLine();
            while (input != "END")
            {
                char symbol = input[0];
                int currentRow = int.Parse(input[1].ToString());
                int currentCol = int.Parse(input[2].ToString());
                int nextRow = int.Parse(input[4].ToString());
                int nextCol = int.Parse(input[5].ToString());
                if (!CheckForPiece(matrix, symbol, currentRow, currentCol))
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (!CheckForMove(matrix, symbol, currentRow, currentCol, nextRow, nextCol))
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (!IsInside(nextRow, nextCol))
                {
                    input = Console.ReadLine();
                    continue;
                }

                matrix[currentRow][currentCol] = 'x';
                matrix[nextRow][nextCol] = symbol;
                input = Console.ReadLine();
            }
        }

        private static bool IsInside(int row, int col)
        {
            if (row >= 0 && row <= 7 && col >= 0 && col <= 7)
            {
                return true;
            }
            Console.WriteLine("Move go out of board!");
            return false;
        }

        private static bool CheckForMove(char[][] matrix, char symbol, int currentRow, int currentCol, int nextRow,
            int nextCol)
        {
            if (symbol == 'K')
            {
                if (HasKingMove(currentRow, currentCol, nextRow, nextCol))
                {
                    return true;
                }
            }
            else if (symbol == 'R')
            {
                if (HasRockMove(currentRow, currentCol, nextRow, nextCol))
                {
                    return true;
                }
            }
            else if (symbol == 'B')
            {
                if (HasBishopMove(currentRow, currentCol, nextRow, nextCol))
                {
                    return true;
                }
            }
            else if (symbol == 'Q')
            {
                if (HasQueenMove(currentRow, currentCol, nextRow, nextCol))
                {
                    return true;
                }
            }
            else if (symbol == 'P')
            {
                if (HasPawnMove(currentRow, currentCol, nextRow, nextCol))
                {
                    return true;
                }
            }

            Console.WriteLine("Invalid move!");
            return false;
        }

        private static bool HasPawnMove(int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (nextRow == currentRow - 1 && currentCol == nextCol)
            {
                return true;
            }
            return false;
        }

        private static bool HasQueenMove(int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (HasKingMove(currentRow, currentCol, nextRow, nextCol)
                || HasRockMove(currentRow, currentCol, nextRow, nextCol)
                || HasBishopMove(currentRow, currentCol, nextRow, nextCol))
            {
                return true;
            }
            return false;
        }

        private static bool HasBishopMove(int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (Math.Abs(currentRow - nextRow) == Math.Abs(currentCol - nextCol))
            {
                return true;
            }
            return false;
        }

        private static bool HasRockMove(int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (nextRow == currentRow || nextCol == currentCol)
            {
                return true;
            }
            return false;
        }

        private static bool HasKingMove(int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (Math.Abs(currentRow - nextRow) <= 1 && Math.Abs(currentCol - nextCol) <= 1)
            {
                return true;
            }
            return false;
        }

        private static bool CheckForPiece(char[][] matrix, char symbol, int currentRow, int currentCol)
        {
            if (matrix[currentRow][currentCol] != symbol)
            {
                Console.WriteLine("There is no such a piece!");
                return false;
            }
            return true;
        }

        private static char[][] FillMatrix()
        {
            char[][] matrix = new char[8][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[8];
                char[] input = Console.ReadLine().Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                matrix[row] = input;
            }
            return matrix;
        }
    }
}