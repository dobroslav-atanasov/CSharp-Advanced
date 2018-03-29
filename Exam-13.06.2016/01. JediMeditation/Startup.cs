namespace _01._JediMeditation
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            List<string> allJedi = new List<string>();
            for (int i = 0; i < number; i++)
            {
                string[] inputParts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                allJedi.AddRange(inputParts);
            }

            Queue<string> master = new Queue<string>();
            Queue<string> knight = new Queue<string>();
            Queue<string> padawan = new Queue<string>();
            Queue<string> newPadawan = new Queue<string>();

            bool isHereYoda = false;
            foreach (string jedi in allJedi)
            {
                switch (jedi[0])
                {
                    case 'm':
                        master.Enqueue(jedi);
                        break;
                    case 'k':
                        knight.Enqueue(jedi);
                        break;
                    case 'p':
                        padawan.Enqueue(jedi);
                        break;
                    case 't':
                        newPadawan.Enqueue(jedi);
                        break;
                    case 's':
                        newPadawan.Enqueue(jedi);
                        break;
                    case 'y':
                        isHereYoda = true;
                        break;
                }
            }

            if (isHereYoda)
            {
                PrintJedi(master);
                PrintJedi(knight);
                PrintJedi(newPadawan);
                PrintJedi(padawan);
                Console.WriteLine();
            }
            else
            {
                PrintJedi(newPadawan);
                PrintJedi(master);
                PrintJedi(knight);
                PrintJedi(padawan);
                Console.WriteLine();
            }
        }

        private static void PrintJedi(Queue<string> queue)
        {
            foreach (string jedi in queue)
            {
                Console.Write($"{jedi} ");
            }
        }
    }
}