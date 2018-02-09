namespace _02._CubicsRube
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[][][] cube = FillCube(number);

            string input = Console.ReadLine();
            while (input != "Analyze")
            {
                int[] numbers = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = numbers[0];
                int col = numbers[1];
                int height = numbers[2];
                int particle = numbers[3];
                bool isPointInside = IsPointInside(number, row, col, height);
                if (isPointInside)
                {
                    cube[row][col][height] = particle;
                }
                input = Console.ReadLine();
            }

            long sum = 0;
            int amountOfCells = (int)Math.Pow(number, 3);
            int usedCells = 0;
            for (int row = 0; row < number; row++)
            {
                for (int col = 0; col < number; col++)
                {
                    for (int height = 0; height < number; height++)
                    {
                        if (cube[row][col][height] != 0)
                        {
                            sum += cube[row][col][height];
                            usedCells++;
                        }
                    }
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(amountOfCells - usedCells);
        }

        private static bool IsPointInside(int number, int row, int col, int height)
        {
            if (row >= 0 && row < number && col >= 0 && col < number && height >= 0 && height < number)
            {
                return true;
            }
            return false;
        }

        private static int[][][] FillCube(int number)
        {
            int[][][] cube = new int[number][][];
            for (int row = 0; row < number; row++)
            {
                cube[row] = new int[number][];
                for (int col = 0; col < number; col++)
                {
                    cube[row][col] = new int[number];
                    for (int height = 0; height < number; height++)
                    {
                        cube[row][col][height] = 0;
                    }
                }
            }
            return cube;
        }
    }
}