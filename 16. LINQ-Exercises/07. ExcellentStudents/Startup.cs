namespace _07._ExcellentStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (input != "END")
            {
                string[] inputParts = input.Split(' ');
                string firstName = inputParts[0];
                string lastName = inputParts[1];
                List<int> grades = inputParts.Skip(2).Select(int.Parse).ToList();
                Student student = new Student(firstName, lastName, grades);
                students.Add(student);

                input = Console.ReadLine();
            }

            students.Where(s => s.Grades.Contains(6))
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}