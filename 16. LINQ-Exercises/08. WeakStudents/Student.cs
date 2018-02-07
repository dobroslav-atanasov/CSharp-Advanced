namespace _08._WeakStudents
{
    using System.Collections.Generic;

    public class Student
    {
        public Student(string firstName, string lastName, List<int> grades)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grades = grades;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<int> Grades { get; set; }
    }
}