namespace _01._StudentsByGroup
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
                string[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = inputParts[0];
                string lastName = inputParts[1];
                int group = int.Parse(inputParts[2]);

                Student student = new Student(firstName, lastName, group);
                students.Add(student);

                input = Console.ReadLine();
            }

            IEnumerable<IGrouping<int, Student>> studentsGroup = students
                .GroupBy(g => g.Group)
                .Where(g => g.Key == 2);

            foreach (IGrouping<int, Student> grouping in studentsGroup)
            {
                foreach (Student student in grouping.OrderBy(s => s.FirstName))
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}");
                }
            }
        }
    }
}