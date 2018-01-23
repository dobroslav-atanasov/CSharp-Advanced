namespace _10._SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] inputParts = Console.ReadLine().Split(' ');
                string command = inputParts[0];
                switch (command)
                {
                    case "1":
                        string text = inputParts[1];
                        if (stack.Count == 0)
                        {
                            stack.Push(text);
                        }
                        else
                        {
                            string lastText = stack.Peek();
                            lastText += text;
                            stack.Push(lastText);
                        }
                        break;
                    case "2":
                        int length = int.Parse(inputParts[1]);
                        string textToCut = stack.Peek();
                        textToCut = textToCut.Substring(0, textToCut.Length - length);
                        stack.Push(textToCut);
                        break;
                    case "3":
                        int index = int.Parse(inputParts[1]) - 1;
                        Console.WriteLine(stack.Peek()[index]);
                        break;
                    case "4":
                        stack.Pop();
                        break;
                }
            }
        }
    }
}