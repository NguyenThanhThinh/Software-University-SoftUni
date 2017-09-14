using System;
using System.Collections.Generic;
using System.Linq;
using _02.Extended_Database;

namespace _01.Database
{
    public class Database
    {
        private const int DefaultCapacity = 16;
        private Person[] people;
        private int currentIndex;

        public Database(IEnumerable<Person> people)
        {
            this.People = people.ToArray();
        }

        public Person[] People
        {
            get
            {
                return people.Take(currentIndex).ToArray();
            }
            private set
            {
                if (value.Length > 16 || value.Length < 1)
                {
                    throw new InvalidOperationException();
                }

                this.people = new Person[DefaultCapacity];
                int bufferIndex = 0;

                foreach (var element in value)
                {
                    this.people[bufferIndex++] = element;
                }
                this.currentIndex = value.Length;
            }
        }

        public int Capacity { get { return DefaultCapacity; } }

        public int Count { get { return this.currentIndex; } }

        public void Add(Person person)
        {
            if (this.currentIndex == DefaultCapacity)
            {
                throw new InvalidOperationException("Cannot add more elements in the collection");
            }
            if (this.People.Any(p => p.Equals(person)))
            {
                throw new InvalidOperationException("Cannot add the same person in the collection");
            }
            this.people[currentIndex] = person;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty database!");
            }
            this.People[--this.currentIndex] = default(Person);
            //this.currentIndex--;
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot search person by negative ID");
            }
            var person = this.People.FirstOrDefault(p => p.Id.Equals(id));

            if (person is null)
            {
                throw new InvalidOperationException("There is no person with this ID in the collection");
            }
            return person;
        }

        public Person FindByUsername(string userName)
        {
            if (userName is null)
            {
                throw new ArgumentNullException("Cannot give username search as null. Must specify a" +
                                                    " valid name!");
            }

            var person = this.People.FirstOrDefault(p => p.UserName.Equals(userName));
            if (person is null)
            {
                throw new InvalidOperationException("There is no person with this username in the collection");
            }

            return person;
        }
    }
}