namespace _04._AddVat
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Func<string, double> vat = n => double.Parse(n) * 1.2;

            Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(vat)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:F2}"));
        }
    }
}