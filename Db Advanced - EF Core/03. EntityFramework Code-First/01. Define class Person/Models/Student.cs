namespace _01.Define_class_Person.Models
{
    public class Student
    {
        private static int count = 0;

        public Student(string name)
        {
            this.Name = name;
            Count++;
        }

        public string Name { get; set; }

        public static int Count
        {
            get { return count; }
            private set { count = value; }
        }
    }
}