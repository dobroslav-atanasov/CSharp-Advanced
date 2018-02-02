namespace _07._PredicateForNames
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> predicate = n => n.Length <= length;
            Action<string> print = n => Console.WriteLine(n);

            foreach (string name in names)
            {
                if (predicate(name))
                {
                    print(name);
                }
            }
        }
    }
}