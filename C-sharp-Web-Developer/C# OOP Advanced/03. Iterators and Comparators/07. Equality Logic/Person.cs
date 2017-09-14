using System;

namespace _05.Comparing_Objects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) == 0)
            {
                return this.Age.CompareTo(other.Age);
            }
            return this.Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)
        {
            var person = obj as Person;

            return person.Name.Equals(this.Name) && person.Age.Equals(this.Age);
        }

        public override int GetHashCode()
        {
            return new {this.Name, this.Age}.GetHashCode();
        }
    }
}