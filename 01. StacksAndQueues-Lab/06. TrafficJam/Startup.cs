namespace _06._TrafficJam
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            Queue<string> queue = new Queue<string>();
            int sum = 0;
            while (input != "end")
            {
                if (input == "green")
                {
                    if (queue.Count >= number)
                    {
                        for (int i = 0; i < number; i++)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            sum++;
                        }
                    }
                    else
                    {
                        while (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            sum++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{sum} cars passed the crossroads.");
        }
    }
}