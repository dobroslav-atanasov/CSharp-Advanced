namespace _04._PascalTriangle
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            List<List<long>> matrix = new List<List<long>>();
            matrix.Add(new List<long>() { 1 });

            for (int i = 1; i < number; i++)
            {
                matrix.Add(new List<long>() { 1 });
                for (int j = 0; j < i - 1; j++)
                {
                    matrix[i].Add(matrix[i - 1][j] + matrix[i - 1][j + 1]);
                }
                matrix[i].Add(1);
            }

            foreach (List<long> list in matrix)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }
    }
}