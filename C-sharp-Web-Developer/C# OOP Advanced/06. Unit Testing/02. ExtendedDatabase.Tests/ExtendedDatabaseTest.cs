using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01.Database;
using _02.Extended_Database;

namespace _02.ExtendedDatabase.Tests
{
    [TestClass]
    public class ExtendedDatabaseTest
    {
        private Person[] people;
        //Global Arrange
        //private readonly IEnumerable<int> DefaultGivenValue = Enumerable.Range(1, 15);

        [TestMethod]
        public void ConstructorSetTheGivenArrayProperly()
        {
            //Act
            Database data = new Database(people);

            //Assert
            Assert.IsTrue(people.Count().Equals(data.Count));
        }

        [TestMethod]
        public void ReturnValueShouldBeTheSameAsTheGivenOne()
        {
            //Act
            Database data = new Database(people);

            //Assert
            for (int i = 0; i < people.Count(); i++)
            {
                Assert.IsTrue(people.ToArray()[i].Equals(data.People[i]));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DatabaseSetterShouldRespectTheDatabaseRanges()
        {
            //Act + //Assert
            Database data = new Database(people);

            data.Add(default(Person));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddShouldThrowExceptionBecauseDatabaseLimitWillBeExceeded()
        {
            //Act
            Database data = new Database(people);
            //Assert
            for (int i = 0; i < 10; i++)
            {
                var person = new Person(i + 13, "Test" + i);
                data.Add(person);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddShouldThrowExceptionBecauseWeWillTryToRemoveInEmptyCollection()
        {
            //Act
            Database data = new Database(people);

            //Assert
            while (true)
            {
                data.Remove();
            }
        }

        [TestMethod]
        public void RemoveShouldRemoveLastElement()
        {
            //Act
            Database data = new Database(people);

            //Assert
            int beforeLastIndex = data.People.Length - 2;
            var beforeLastNumber = data.People[beforeLastIndex];
            data.Remove();

            int lastIndex = data.People.Length - 1;
            var lastNumber = data.People[lastIndex];

            Assert.IsTrue(beforeLastNumber.Equals(lastNumber));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddThrowExceptionIfWeTryToAddSamePersonWithTheSameIdOrUserName()
        {
            Database data = new Database(people);
            data.Add(people[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FindByIdThrowExpectionIfNoUserIsPresentedWithSpecificId()
        {
            Database data = new Database(people);

            data.FindById(100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindByIdThrowExpectionIfWeSearchWithNegativeId()
        {
            Database data = new Database(people);

            data.FindById(-1);
        }

        [TestMethod]
        public void FindByIdShouldPassWithValidParamater()
        {
            Database data = new Database(people);
            var localPersonOnFirstIndex = people.ElementAt(0);
            var dataPersonOnFirstIndex = data.People.ElementAt(0);
            Assert.AreEqual(localPersonOnFirstIndex, dataPersonOnFirstIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FindByUserNameThrowExpectionIfNoIfNoUserIsPresentedWithTheSearchedName()
        {
            Database data = new Database(people);

            data.FindByUsername("Zueka");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindByUserNameThrowExpectionIfSearchParameterIsNull()
        {
            Database data = new Database(people);

            data.FindByUsername(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FindByUserNameIsCaseSensitiveAndShouldCheckForThatConditions()
        {
            Database data = new Database(people);

            data.FindByUsername("ivan");
        }

        [TestMethod]
        public void FindByUserNameShouldPastWithExistingGivenParamater()
        {
            Database data = new Database(people);
            Person current = new Person(3, "Pesho");
            var foundedPerson = data.FindByUsername(current.UserName);
            Assert.AreEqual(current, foundedPerson);
        }

        [TestInitialize]
        public void InitilizeData()
        {
            this.people = new Person[]
            {
                new Person(1, "Ivan"), new Person(2, "Petyr") , new Person(3, "Pesho")
                ,new Person(4, "Sev") ,new Person(5, "Gosho") ,new Person(6, "Nikolay") ,new Person(7, "Stefan")
                , new Person(8, "Muco"), new Person(9, "Iliq"), new Person(10, "Kircho"), new Person(11, "Bobi"), new Person(12, "Zafircho"), new Person(13, "Vankata"), new Person(14, "Stoicho"),
                new Person(15, "Gogo"), new Person(16, "Bubo"),  
            };
        }
    }
}