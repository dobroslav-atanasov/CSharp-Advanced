namespace _05._FilterByAge
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < number; i++)
            {
                string[] inputParts = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputParts[0];
                int personAge = int.Parse(inputParts[1]);
                people.Add(name, personAge);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> checkAge = CheckAge(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);
            PrintResult(checkAge, printer, people);
        }

        private static void PrintResult(Func<int, bool> checkAge, Action<KeyValuePair<string, int>> printer, Dictionary<string, int> people)
        {
            foreach (KeyValuePair<string, int> person in people)
            {
                if (checkAge(person.Value))
                {
                    printer(person);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return p => Console.WriteLine($"{p.Key}");
                case "age":
                    return p => Console.WriteLine($"{p.Value}");
                case "name age":
                    return p => Console.WriteLine($"{p.Key} - {p.Value}");
                default:
                    return null;
            }
        }

        private static Func<int, bool> CheckAge(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return a => a < age;
                case "older":
                    return a => a >= age;
                default:
                    return null;
            }
        }
    }
}