namespace _03._GroupNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new []{' ', ','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<List<int>> jaggedList = new List<List<int>>();
            jaggedList.Add(new List<int>());
            jaggedList.Add(new List<int>());
            jaggedList.Add(new List<int>());

            foreach (int number in numbers)
            {
                switch (Math.Abs(number) % 3)
                {
                    case 0:
                        jaggedList[0].Add(number);
                        break;
                    case 1:
                        jaggedList[1].Add(number);
                        break;
                    case 2:
                        jaggedList[2].Add(number);
                        break;
                }
            }

            foreach (List<int> list in jaggedList)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }
    }
}