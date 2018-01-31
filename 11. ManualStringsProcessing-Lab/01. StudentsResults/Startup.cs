namespace _01._StudentsResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            for (int i = 0; i < number; i++)
            {
                string[] inputParts = Console.ReadLine().Split(new []{' ', '-', ','}, StringSplitOptions.RemoveEmptyEntries);
                string name = inputParts[0];
                double cAdv = double.Parse(inputParts[1]);
                double cOop = double.Parse(inputParts[2]);
                double oopAdv = double.Parse(inputParts[3]);

                if (!students.ContainsKey(name))
                {
                    students[name] = new List<double>();
                }
                students[name].Add(cAdv);
                students[name].Add(cOop);
                students[name].Add(oopAdv);
            }

            Console.WriteLine("{0,-10}|{1,7}|{2, 7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average");
            foreach (KeyValuePair<string, List<double>> student in students)
            {
                Console.WriteLine("{0, -10}|{1, 7:F2}|{2, 7:F2}|{3, 7:F2}|{4, 7:F4}|", student.Key, student.Value[0], student.Value[1], student.Value[2], student.Value.Average());
            }
        }
    }
}