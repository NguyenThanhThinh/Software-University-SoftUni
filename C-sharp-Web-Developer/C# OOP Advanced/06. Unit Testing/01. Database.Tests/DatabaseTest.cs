using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01.Database.Tests
{
    [TestClass]
    public class DatabaseTest
    {
        //Global Arrange
        private readonly IEnumerable<int> DefaultGivenValue = Enumerable.Range(1, 15);

        [TestMethod]
        public void ConstructorSetTheGivenArrayProperly()
        {
            //Act
            Database data = new Database(DefaultGivenValue);

            //Assert
            Assert.IsTrue(DefaultGivenValue.Count().Equals(data.Count));
        }

        [TestMethod]
        public void ReturnValueShouldBeTheSameAsTheGivenOne()
        {
            //Act
            Database data = new Database(DefaultGivenValue);

            //Assert
            for (int i = 0; i < DefaultGivenValue.Count(); i++)
            {
                Assert.IsTrue(DefaultGivenValue.ToArray()[i] == data.Numbers[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DatabaseSetterShouldRespectTheDatabaseRanges()
        {
            // Arrange
            var numbers = Enumerable.Range(1, 17).ToArray();

            //Act + //Assert
            Database data = new Database(numbers);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddShouldThrowExceptionBecauseDatabaseLimitWillBeExceeded()
        {
            //Act
            Database data = new Database(DefaultGivenValue);

            //Assert
            data.Add(0);
            data.Add(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddShouldThrowExceptionBecauseWeWillTryToRemoveInEmptyCollection()
        {
            //Act
            Database data = new Database(DefaultGivenValue);

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
            Database data = new Database(DefaultGivenValue);

            //Assert
            int beforeLastIndex = data.Numbers.Length - 2;
            int beforeLastNumber = data.Numbers[beforeLastIndex];
            data.Remove();

            int lastIndex = data.Numbers.Length - 1;
            int lastNumber = data.Numbers[lastIndex];

            Assert.IsTrue(beforeLastNumber.Equals(lastNumber));
        }
    }
}