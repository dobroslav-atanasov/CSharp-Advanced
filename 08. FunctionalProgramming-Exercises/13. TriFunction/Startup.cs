namespace _13._TriFunction
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> func = (str, num) => str.ToCharArray().Select(c => (int) c).Sum() >= num;
            Func<string[], int, Func<string, int, bool>, string> name = (n, num, f) => names.FirstOrDefault(s => func(s, num));

            Console.WriteLine(name(names, number, func));
        }
    }
}