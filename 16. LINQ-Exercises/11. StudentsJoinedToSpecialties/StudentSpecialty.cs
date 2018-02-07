namespace _11._StudentsJoinedToSpecialties
{
    public class StudentSpecialty
    {
        public StudentSpecialty(string specialty, string facultyNumber)
        {
            this.Specialty = specialty;
            this.FacultyNumber = facultyNumber;
        }

        public string Specialty { get; set; }

        public string FacultyNumber { get; set; }
    }
}