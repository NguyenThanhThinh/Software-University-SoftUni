using System;
namespace _05.BorderControl
{
    public class Citizen : ICountable
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
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

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public void FakeID(string fakeID)
        {
            if (this.Id.EndsWith(fakeID))
            {
                Console.WriteLine(this.Id);
            }
        }
    }
}