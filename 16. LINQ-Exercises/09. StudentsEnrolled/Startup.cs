namespace _09._StudentsEnrolled
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
                string facultyNumber = inputParts[0];
                List<int> grades = inputParts.Skip(1).Select(int.Parse).ToList();
                Student student = new Student(facultyNumber, grades);
                students.Add(student);

                input = Console.ReadLine();
            }

            students.Where(s => s.FacultyNumber.EndsWith("14") || s.FacultyNumber.EndsWith("15"))
                .ToList()
                .ForEach(s => Console.WriteLine($"{string.Join(" ", s.Grades)}"));
        }
    }
}