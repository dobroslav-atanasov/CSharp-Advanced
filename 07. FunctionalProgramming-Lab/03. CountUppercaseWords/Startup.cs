namespace _03._CountUppercaseWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Func<string, bool> isUppercase = w => w[0] == w.ToUpper()[0];

            Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Where(isUppercase)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}