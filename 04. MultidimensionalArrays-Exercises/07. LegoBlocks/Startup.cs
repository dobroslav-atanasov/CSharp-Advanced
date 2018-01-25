namespace _07._LegoBlocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            List<List<int>> firstBlock = ParseInput(number);
            List<List<int>> secondBlock = ParseInput(number);
            List<List<int>> block = CreateLegoBlock(firstBlock, secondBlock, number);
            bool isPerfect = IsPerfect(block, number);

            if (isPerfect)
            {
                foreach (List<int> line in block)
                {
                    Console.WriteLine($"[{string.Join(", ", line)}]");
                }
            }
            else
            {
                int count = 0;
                foreach (List<int> line in block)
                {
                    count += line.Count;
                }
                Console.WriteLine($"The total number of cells is: {count}");
            }
        }

        private static bool IsPerfect(List<List<int>> block, int number)
        {
            for (int i = 0; i < number - 1; i++)
            {
                if (block[i].Count != block[i + 1].Count)
                {
                    return false;
                }
            }
            return true;
        }

        private static List<List<int>> CreateLegoBlock(List<List<int>> firstBlock, List<List<int>> secondBlock, int number)
        {
            List<List<int>> block = new List<List<int>>();
            for (int i = 0; i < number; i++)
            {
                block.Add(new List<int>());
                block[i].AddRange(firstBlock[i]);
                secondBlock[i].Reverse();
                block[i].AddRange(secondBlock[i]);
            }
            return block;
        }

        private static List<List<int>> ParseInput(int number)
        {
            List<List<int>> jagged = new List<List<int>>();
            for (int i = 0; i < number; i++)
            {
                List<int> inputLine = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                jagged.Add(inputLine);
            }
            return jagged;
        }
    }
}