using System;
using _06.BirthdayCelebrations;

namespace _05.BorderControl
{
    public class Citizen : ICountable, IInformatanable
    {
        private string name;
        private int age;
        private string id;
        private string birthday;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
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

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public void GetBirthdayIfMatch(string birthday)
        {
            if (this.Birthday.EndsWith(birthday))
            {
                Console.WriteLine(this.Birthday);
            }
        }
    }
}