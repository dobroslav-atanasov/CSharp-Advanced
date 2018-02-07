namespace _03._StudentsByAge
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
                int age = int.Parse(inputParts[2]);
                Student student = new Student(firstName, lastName, age);
                students.Add(student);

                input = Console.ReadLine();
            }

            students.Where(s => s.Age >= 18 && s.Age <= 24)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName} {s.Age}"));
        }
    }
}