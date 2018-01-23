namespace _07._BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            char[] parentheses = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();

            if (parentheses.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (parentheses[i] == '(' || parentheses[i] == '[' || parentheses[i] == '{')
                {
                    stack.Push(parentheses[i]);
                }
                else if (parentheses[i] == ')')
                {
                    char previous = stack.Pop();
                    if (previous != '(')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (parentheses[i] == ']')
                {
                    char previous = stack.Pop();
                    if (previous != '[')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (parentheses[i] == '}')
                {
                    char previous = stack.Pop();
                    if (previous != '{')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}