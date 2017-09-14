namespace _02.Extended_Database
{
    public class Person
    {
        private long id;
        private string userName;

        public Person(long id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public override bool Equals(object person)
        {
            Person current = person as Person;

            return this.Id.Equals(current.Id) && this.UserName.Equals(current.UserName);
        }

        public override int GetHashCode()
        {
            return new { this.Id, this.UserName }.GetHashCode();
        }
    }
}