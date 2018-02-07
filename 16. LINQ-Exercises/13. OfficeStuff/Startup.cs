namespace _13._OfficeStuff
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            SortedDictionary<string, Dictionary<string, int>> companies = new SortedDictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] inputParts = Console.ReadLine().Split(new []{' ', '|', '-'}, StringSplitOptions.RemoveEmptyEntries);
                string company = inputParts[0];
                int amount = int.Parse(inputParts[1]);
                string product = inputParts[2];

                if (!companies.ContainsKey(company))
                {
                    companies[company] = new Dictionary<string, int>();
                }
                if (!companies[company].ContainsKey(product))
                {
                    companies[company][product] = 0;
                }
                companies[company][product] += amount;
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> company in companies)
            {
                List<string> products = new List<string>();
                foreach (KeyValuePair<string, int> product in company.Value)
                {
                    products.Add($"{product.Key}-{product.Value}");
                }
                Console.WriteLine($"{company.Key}: {string.Join(", ", products)}");
            }
        }
    }
}