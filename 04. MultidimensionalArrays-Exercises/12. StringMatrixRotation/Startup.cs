namespace _12._StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string[] commandParts = Console.ReadLine().Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int degrees = int.Parse(commandParts[1]);
            int rotate = degrees % 360;

            List<List<char>> block = ParseInput();
            FillBlockWithSpaces(block);

            switch (rotate)
            {
                case 0:
                    PrintBlockFirstCase(block);
                    break;
                case 90:
                    PrintBlockSecondCase(block);
                    break;
                case 180:
                    PrintBlockThirdCase(block);
                    break;
                case 270:
                    PrintBlockFourthCase(block);
                    break;
            }
        }

        private static void PrintBlockFourthCase(List<List<char>> block)
        {
            for (int col = block[0].Count - 1; col >= 0; col--)
            {
                for (int row = 0; row < block.Count; row++)
                {
                    Console.Write(block[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintBlockThirdCase(List<List<char>> block)
        {
            for (int row = block.Count - 1; row >= 0; row--)
            {
                for (int col = block[0].Count - 1; col >= 0; col--)
                {
                    Console.Write(block[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintBlockSecondCase(List<List<char>> block)
        {
            for (int col = 0; col < block[0].Count; col++)
            {
                for (int row = block.Count - 1; row >= 0; row--)
                {
                    Console.Write(block[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintBlockFirstCase(List<List<char>> block)
        {
            foreach (List<char> line in block)
            {
                Console.WriteLine(string.Join(string.Empty, line));
            }
        }

        private static void FillBlockWithSpaces(List<List<char>> block)
        {
            int maxLength = block.Max(b => b.Count);
            foreach (List<char> list in block)
            {
                if (list.Count <maxLength)
                {
                    for (int i = list.Count; i < maxLength; i++)
                    {
                        list.Add(' ');
                    }
                }
            }
        }

        private static List<List<char>> ParseInput()
        {
            List<List<char>> block = new List<List<char>>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                block.Add(input.ToCharArray().ToList());
                input = Console.ReadLine();
            }
            return block;
        }
    }
}