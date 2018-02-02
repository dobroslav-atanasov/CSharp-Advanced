namespace _01._ActionPrint
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] names = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = n => Console.WriteLine(n);

            foreach (string name in names)
            {
                print(name);
            }
        }
    }
}