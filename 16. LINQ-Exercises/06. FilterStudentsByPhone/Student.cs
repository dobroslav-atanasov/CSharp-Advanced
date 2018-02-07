namespace _06._FilterStudentsByPhone
{
    public class Student
    {
        public Student(string firstName, string lastName, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}