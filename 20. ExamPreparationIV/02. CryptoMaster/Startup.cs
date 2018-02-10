namespace _02._CryptoMaster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int maxCount = 0;

            for (int step = 1; step < numbers.Count; step++)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    int count = 1;
                    int index = i;
                    int nextIndex = (index + step) % numbers.Count;

                    while (numbers[index] < numbers[nextIndex])
                    {
                        count++;
                        index = nextIndex;
                        nextIndex = (index + step) % numbers.Count;
                    }

                    if (count > maxCount)
                    {
                        maxCount = count;
                    }
                }
            }

            Console.WriteLine(maxCount);
        }
    }
}