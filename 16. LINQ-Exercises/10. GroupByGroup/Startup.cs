namespace _10._GroupByGroup
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
                int group = int.Parse(inputParts[2]);
                Student student = new Student($"{firstName} {lastName}", group);
                students.Add(student);

                input = Console.ReadLine();
            }

            IEnumerable<IGrouping<int, Student>> studentsGroup = students.GroupBy(s => s.Group);

            foreach (IGrouping<int, Student> grouping in studentsGroup.OrderBy(g => g.Key))
            {
                List<string> names = new List<string>();
                foreach (Student student in grouping)
                {
                    names.Add(student.FullName);
                }
                Console.WriteLine($"{grouping.Key} - {string.Join(", ", names)}");
            }
        }
    }
}