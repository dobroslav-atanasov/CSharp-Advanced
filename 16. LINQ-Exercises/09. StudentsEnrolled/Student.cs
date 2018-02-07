namespace _09._StudentsEnrolled
{
    using System.Collections.Generic;

    public class Student
    {
        public Student(string facultyNumber, List<int> grades)
        {
            this.FacultyNumber = facultyNumber;
            this.Grades = grades;
        }

        public string FacultyNumber { get; set; }

        public List<int> Grades { get; set; }
    }
}