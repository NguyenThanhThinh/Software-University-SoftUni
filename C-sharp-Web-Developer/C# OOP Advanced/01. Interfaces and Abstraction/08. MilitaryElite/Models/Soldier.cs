namespace _08.MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        private int id;
        private string firstName;
        private string lastName;

        protected Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName
        {
            get { return lastName; }
            private set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            private set { firstName = value; }
        }

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        public override string ToString()
        {
            return string.Format($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
        }
    }
}