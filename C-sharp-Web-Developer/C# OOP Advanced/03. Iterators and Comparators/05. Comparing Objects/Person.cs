using System;

namespace _05.Comparing_Objects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Town
        {
            get { return town; }
            set { town = value; }
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
            if (this.Name.CompareTo(other.Name) < 0)
            {
                return -1;
            }

            if (this.Age.CompareTo(other.Age) <  0)
            {
                return -1;
            }

            if (this.Town.CompareTo(other.Town) < 0)
            {
                return -1;
            }

            return 0;
        }
    }
}