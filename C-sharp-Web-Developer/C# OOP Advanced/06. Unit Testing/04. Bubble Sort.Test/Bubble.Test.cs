using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04.Bubble_Sort.Test
{
    [TestClass]
    public class UnitTest1
    {
        private int[] numbers;
        private Bubble bubble;

        [TestInitialize]
        public void InitilizeDefaultCollection()
        {
            this.numbers = new[] { 5, 4, 3, 2, 1, 0 };
            bubble = new Bubble(this.numbers);
        }

        [TestMethod]
        public void TestCtorSettingUpCOllectionProperly()
        {
            CollectionAssert.AreEqual(bubble.Collection, this.numbers);
        }

        [TestMethod]
        public void TestIfSortWillSortTheCollectionProperly()
        {
            var sortedBubble = bubble.Sort();
            var sortedNumbers = this.numbers.OrderBy(n => n).ToArray();

            CollectionAssert.AreEqual(sortedBubble, sortedNumbers);
        }

        [TestMethod]
        public void TestIfSortWillSortCollectionWithOnlyLastTwoNumbersNotSorted()
        {
            bubble = new Bubble(new int[] { 0, 1, 2, 3, 5, 4 });
            CheckIfTwoCollectionsAreEqual(bubble);
        }

        [TestMethod]
        public void TestIfSortWillSortCorrectlyItemsWithCollectionOfTwoNumbers()
        {
            bubble = new Bubble(new int[] { 2, 1 });
            CheckIfTwoCollectionsAreEqual(bubble);
        }

        [TestMethod]
        public void TestIfSortWillSortCollectionWithOnlyOneNumber()
        {
            bubble = new Bubble(new int[] { 1 });
            CheckIfTwoCollectionsAreEqual(bubble);
        }

        [TestMethod]
        public void TestIfSortWillSortCollectionWithNegativeAndPositiveNumbers()
        {
            bubble = new Bubble(new int[] { -5, 5, 4, -3, 2, 1 - 3 });
            CheckIfTwoCollectionsAreEqual(bubble);
        }

        [TestMethod]
        public void TestIfSortWillSortCollectionWithOnlyOneDifferentNumberInIt()
        {
            bubble = new Bubble(new int[] { 1, 1, 1, 1, 2 });
            CheckIfTwoCollectionsAreEqual(bubble);
        }

        [TestMethod]
        public void TestIfSortWillSortCollectionWithOnlyNegativeNumbers()
        {
            bubble = new Bubble(new int[] { -5, -11, -29, -21, -2 });
            CheckIfTwoCollectionsAreEqual(bubble);
        }

        private void CheckIfTwoCollectionsAreEqual(Bubble bubble)
        {
            int[] customSortedNums = bubble.Sort();
            int[] linqSortedNums = bubble.Collection.OrderBy(n => n).ToArray();

            CollectionAssert.AreEqual(customSortedNums, linqSortedNums);
        }

        [TestMethod]
        public void ShouldSortZerosCorrectlyInAscendingOrder()
        {
            bubble = new Bubble(new int[] { 0, 0 });
            CheckIfTwoCollectionsAreEqual(bubble);
        }
    }
}