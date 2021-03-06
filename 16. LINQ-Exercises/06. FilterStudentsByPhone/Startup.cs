﻿namespace _06._FilterStudentsByPhone
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
                string phoneNumber = inputParts[2];
                Student student = new Student(firstName, lastName, phoneNumber);
                students.Add(student);

                input = Console.ReadLine();
            }

            students.Where(s => s.PhoneNumber.StartsWith("02") || s.PhoneNumber.StartsWith("+3592"))
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}