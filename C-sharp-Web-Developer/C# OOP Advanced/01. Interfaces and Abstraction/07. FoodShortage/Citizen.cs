using _07.FoodShortage;

namespace _05.BorderControl
{
    public class Citizen : IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthday;
        private int food;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            Id = id;
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

        public int Food
        {
            get { return food; }
            set { food = value; }
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}