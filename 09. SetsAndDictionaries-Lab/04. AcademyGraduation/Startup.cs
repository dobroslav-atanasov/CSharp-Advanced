namespace _04._AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            SortedDictionary<string, List<double>> students = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string name = Console.ReadLine();
                List<double> grades = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToList();

                if (!students.ContainsKey(name))
                {
                    students[name] = new List<double>();
                }
                students[name].AddRange(grades);
            }

            foreach (KeyValuePair<string, List<double>> student in students)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }
    }
}