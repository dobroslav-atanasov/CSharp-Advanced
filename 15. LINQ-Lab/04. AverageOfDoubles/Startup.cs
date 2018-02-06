namespace _04._AverageOfDoubles
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine($"{Console.ReadLine().Split(' ').Select(double.Parse).ToList().Average():F2}");
        }
    }
}