namespace _02._KnightsOfHonor
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] names = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = n => Console.WriteLine($"Sir {n}");

            foreach (string name in names)
            {
                print(name);
            }
        }
    }
}