using System;

namespace _06.BirthdayCelebrations
{
    public class Pet : IInformatanable
    {
        private string name;
        private string birthday;

        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
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

        public void GetBirthdayIfMatch(string birthday)
        {
            if (this.Birthday.EndsWith(birthday))
            {
                Console.WriteLine(this.Birthday);
            }
        }
    }
}