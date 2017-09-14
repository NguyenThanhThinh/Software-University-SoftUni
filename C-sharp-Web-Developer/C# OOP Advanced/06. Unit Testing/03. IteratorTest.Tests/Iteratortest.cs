using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03.Iterator_Test;

namespace _03.IteratorTest.Tests
{
    [TestClass]
    public class Iteratortest
    {
        private readonly List<string> collection = new List<string> {"Stefchu", "Goshku", "Peshku"};
        private readonly ListIterator twoElementsInList = new ListIterator(new List<string> { "Vankata", "Goshko" });
        private ListIterator list;

        [TestMethod]
        [TestInitialize]
        public void TestCtorWithTakingListOfStrings()
        {
            list = new ListIterator(collection);
        }

        [TestMethod]
        public void TestIfInternalIndexIsZeroAfterInitialInitialization()
        {
            Assert.IsTrue(list.Index == 0);
        }

        [TestMethod]
        public void MoveIncreaseIndexWithOne()
        {
            Assert.IsTrue(list.Move());
            Assert.IsTrue(list.Index == 1);
        }

        [TestMethod]
        public void MoveDoNotIncreaseIndexWhenItsToTheEndOfTheCollection()
        {
            for (int i = 0; i < collection.Count; i++)
            {
                list.Move();
            }
            list.Move();
            Assert.IsFalse(list.Index == collection.Count);
        }

        [TestMethod]
        public void HasNextReturnFalseIfThereIsNoNextIndex()
        {
            for (int i = 0; i < collection.Count; i++)
            {
                list.Move();
            }
            Assert.IsFalse(list.HasNext());
        }

        [TestMethod]
        public void HasNextReturnTrueIfThereIsNextIndex()
        {
            Assert.IsTrue(list.HasNext());
        }

        [TestMethod]
        public void PrintTheCorrectValueIfTheCollectionIsNotEmpty()
        {
            Assert.IsTrue(collection[0].Equals(list.Print()));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PrintThrowExeptionIfCollectionIsEmpty()
        {
            ListIterator emptyList = new ListIterator(new List<string>());
            emptyList.Print();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PrintThrowExeptionIfCollectionIsOnlyWithNulls()
        {
            ListIterator emptyList = new ListIterator(new List<string>());
            emptyList.Print();
        }

        [TestMethod]
        public void MoveShouldReturnTrueOnceAndFalseOnceWithTwoElements()
        {
            Assert.IsTrue(twoElementsInList.Move());
            Assert.IsFalse(twoElementsInList.Move());
        }

        [TestMethod]
        public void HasNextShouldReturnFalseAfterMoveWithTwoElements()
        {
            twoElementsInList.Move();
            Assert.IsFalse(twoElementsInList.HasNext());
        }

        [TestMethod]
        public void HasNextShouldReturnTrueThenFalseAfterMoveWithTwoElements()
        {
            Assert.IsTrue(twoElementsInList.HasNext());
            twoElementsInList.Move();
            Assert.IsFalse(twoElementsInList.HasNext());
        }
    }
}