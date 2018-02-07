namespace _02._StudentsByFirstAndLastName
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
                Student student = new Student(firstName, lastName);
                students.Add(student);

                input = Console.ReadLine();
            }

            students
                .Where(s => s.FirstName[0] < s.LastName[0])
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}