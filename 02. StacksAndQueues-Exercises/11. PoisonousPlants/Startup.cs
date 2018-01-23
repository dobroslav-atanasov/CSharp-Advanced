namespace _11._PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] days = new int[numberOfPlants];
            Stack<int> stack = new Stack<int>();

            stack.Push(0);

            for (int i = 0; i < numberOfPlants; i++)
            {
                int maxDays = 0;
                while (stack.Count > 0 && plants[stack.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[stack.Pop()]);
                }

                if (stack.Count > 0)
                {
                    days[i] = maxDays + 1;
                }
                stack.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}