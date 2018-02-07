namespace _11._StudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<StudentSpecialty> studentSpecialties = new List<StudentSpecialty>();
            while (input != "Students:")
            {
                string[] inputParts = input.Split(' ');
                string specialtyName = $"{inputParts[0]} {inputParts[1]}";
                string facultyNumber = inputParts[2];
                StudentSpecialty studentSpecialty = new StudentSpecialty(specialtyName, facultyNumber);
                studentSpecialties.Add(studentSpecialty);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            List<Student> students = new List<Student>();
            while (input != "END")
            {
                string[] inputParts = input.Split(' ');
                string facultyNumber = inputParts[0];
                string fullName = $"{inputParts[1]} {inputParts[2]}";
                Student student = new Student(facultyNumber, fullName);
                students.Add(student);

                input = Console.ReadLine();
            }

            var query = studentSpecialties.Join(
                students,
                spec => spec.FacultyNumber,
                st => st.FacultyNumber,
                (spec, st) => new
                {
                    StudentName = st.FullName,
                    FacultyNumber = spec.FacultyNumber,
                    Specailty = spec.Specialty
                });

            foreach (var student in query.OrderBy(s => s.StudentName))
            {
                Console.WriteLine($"{student.StudentName} {student.FacultyNumber} {student.Specailty}");
            }
        }
    }
}