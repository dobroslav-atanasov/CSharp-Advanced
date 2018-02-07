namespace _01._StudentsByGroup
{
    public class Student
    {
        public Student(string firstName, string lastName, int @group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Group = @group;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Group { get; set; }
    }
}