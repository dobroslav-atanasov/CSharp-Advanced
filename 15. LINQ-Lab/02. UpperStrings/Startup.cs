namespace _02._UpperStrings
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(' ')
                .Select(n => n.ToUpper())
                .ToList()
                .ForEach(n => Console.Write(n + " "));
        }
    }
}