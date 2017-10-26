namespace _01.Define_class_Person.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }

        public ICollection<Person> People { get; set; }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.People.OrderByDescending(p => p.Age).First();
        }
    }
}