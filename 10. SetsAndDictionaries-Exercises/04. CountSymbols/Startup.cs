namespace _04._CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
            
            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                if (!symbols.ContainsKey(symbol))
                {
                    symbols[symbol] = 0;
                }
                symbols[symbol]++;
            }

            foreach (KeyValuePair<char, int> symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}