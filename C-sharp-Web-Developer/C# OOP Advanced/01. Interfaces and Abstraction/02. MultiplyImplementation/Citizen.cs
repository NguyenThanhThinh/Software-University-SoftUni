using _02.MultiplyImplementation;

namespace _01.DefineIPerson
{
    public class Citizen : IBirthable, IIdentifiable, IPerson
    {
        private string name;
        private int age;
        private string birthdate;
        private string id;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Birthdate
        {
            get { return birthdate; }
        }

        public string Id
        {
            get { return id; }
        }
    }
}