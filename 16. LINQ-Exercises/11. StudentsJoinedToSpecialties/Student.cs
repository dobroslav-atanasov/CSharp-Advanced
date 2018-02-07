namespace _11._StudentsJoinedToSpecialties
{
    public class Student
    {
        public Student(string facultyNumber, string fullName)
        {
            this.FacultyNumber = facultyNumber;
            this.FullName = fullName;
        }
        
        public string FacultyNumber { get; set; }

        public string FullName { get; set; }
    }
}