namespace _10._GroupByGroup
{
    public class Student
    {
        public Student(string fullName, int @group)
        {
            this.FullName = fullName;
            this.Group = @group;
        }

        public string FullName { get; set; }

        public int Group { get; set; }
    }
}