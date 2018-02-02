namespace _12._InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string inputCommand = Console.ReadLine();
            List<string> commands = new List<string>();

            while (inputCommand != "Forge")
            {
                string[] inputCommandParts = inputCommand.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string command = inputCommandParts[0];
                string type = inputCommandParts[1];
                int parameter = int.Parse(inputCommandParts[2]);

                if (command == "Exclude")
                {
                    commands.Add(type + "," + parameter);
                }
                else if (command == "Reverse")
                {
                    if (commands.Contains(type + "," + parameter))
                    {
                        commands.Remove(type + "," + parameter);
                    }
                }

                inputCommand = Console.ReadLine();
            }

            List<int> markedNumbers = new List<int>();
            for (int i = 0; i < commands.Count; i++)
            {
                string[] commandParts = commands[i].Split(',');
                string command = commandParts[0];
                int param = int.Parse(commandParts[1]);
                Func<int, int, bool> checkLeftOrRight = (x, y) => x + y == param;
                Func<int, int, int, bool> checkLeftAndRight = (x, y, z) => x + y + z == param;
                List<int> numsMark = new List<int>();

                switch (command)
                {
                    case "Sum Left":
                        numsMark = CalculateLeftSum(numbers, checkLeftOrRight);
                        break;
                    case "Sum Right":
                        numsMark = CalculateRightSum(numbers, checkLeftOrRight);
                        break;
                    case "Sum Left Right":
                        numsMark = CalculateLeftRightSum(numbers, checkLeftAndRight);
                        break;
                }
                markedNumbers.AddRange(numsMark);
            }

            foreach (int number in markedNumbers)
            {
                numbers.Remove(number);
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> CalculateLeftRightSum(List<int> numbers, Func<int, int, int, bool> checkLeftAndRight)
        {
            List<int> leftRightSum = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                int leftNumber = 0;
                int rightNumber = 0;

                if (i == 0)
                {
                    leftNumber = 0;
                }
                else
                {
                    leftNumber = numbers[i - 1];
                }

                if (i == numbers.Count - 1)
                {
                    rightNumber = 0;
                }
                else
                {
                    rightNumber = numbers[i + 1];
                }
                int currentNumber = numbers[i];

                if (checkLeftAndRight(leftNumber, currentNumber, rightNumber))
                {
                    leftRightSum.Add(currentNumber);
                }
            }
            return leftRightSum;
        }

        private static List<int> CalculateRightSum(List<int> numbers, Func<int, int, bool> checkLeftOrRight)
        {
            List<int> rightSum = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                int rightNumber;

                if (i == numbers.Count - 1)
                {
                    rightNumber = 0;
                }
                else
                {
                    rightNumber = numbers[i + 1];
                }
                int currentNumber = numbers[i];

                if (checkLeftOrRight(currentNumber, rightNumber))
                {
                    rightSum.Add(currentNumber);
                }
            }
            return rightSum;
        }

        private static List<int> CalculateLeftSum(List<int> numbers, Func<int, int, bool> checkLeftOrRight)
        {
            List<int> leftSum = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                int leftNumber;

                if (i == 0)
                {
                    leftNumber = 0;
                }
                else
                {
                    leftNumber = numbers[i - 1];
                }
                int currentNumber = numbers[i];

                if (checkLeftOrRight(leftNumber, currentNumber))
                {
                    leftSum.Add(currentNumber);
                }
            }
            return leftSum;
        }
    }
}