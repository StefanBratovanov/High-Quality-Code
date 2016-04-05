using CustomLinkedList;

namespace CustomLinkedListTestProject
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTestLinkedList
    {
        private DynamicList<int> linkedList;

        [TestInitialize]
        public void InitLinkedList()
        {
            this.linkedList = new DynamicList<int>();
        }

        [TestMethod]
        public void AccessElementAtValidIndexShouldReturnCorrectResult()
        {
            linkedList.Add(5);
            linkedList.Add(10);
            linkedList.Add(17);

            Assert.AreEqual(17, linkedList[2], "No such element or wrong element index given");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SettingElementAtIncorrectIndexShouldThrowException()
        {
            linkedList.Add(5);
            linkedList.Add(10);

            linkedList[4] = 2;
        }

        [TestMethod]
        public void CountOfElementsShouldBeCorrectAfterAddingElements()
        {
            Assert.AreEqual(0, linkedList.Count);

            this.linkedList.Add(500);

            Assert.AreEqual(1, linkedList.Count);
        }

        [TestMethod]
        public void RemovingElementAtCorrectIndexShouldRemoveAndReturnTheElement()
        {
            linkedList.Add(5);
            linkedList.Add(10);
            linkedList.Add(83);
            linkedList.Add(17);

            var count = linkedList.Count;
            var result = linkedList.RemoveAt(2);
            var result1 = linkedList.RemoveAt(2);
            var countAfterRemoval = linkedList.Count;

            Assert.AreEqual(83, result);
            Assert.AreEqual(17, result1);
            Assert.AreEqual(count - 2, countAfterRemoval);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemovingElementAtIncorrectIndexShouldThrowException()
        {
            linkedList.Add(5);
            linkedList.Add(10);

            linkedList.RemoveAt(2);
        }

        [TestMethod]
        public void RemovingNotExistingElementShouldReturnMinusOne()
        {
            var result = linkedList.Remove(5);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void RemovingExistingElementShouldRemoveThem()
        {
            linkedList.Add(5);
            linkedList.Add(10);
            linkedList.Add(83);
            linkedList.Add(17);

            var count = linkedList.Count;
            var removedElIndex = linkedList.Remove(5);
            var nextRemovedElIndex = linkedList.Remove(10);
            var countAfterRemoval = linkedList.Count;

            Assert.AreEqual(count - 2, countAfterRemoval);
            Assert.AreEqual(0, nextRemovedElIndex);
        }

        [TestMethod]
        public void GettingIndexOfNotExistingElementShouldReturnMinusOne()
        {
            linkedList.Add(1);

            var result = linkedList.Remove(3);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void GettingIndexOfExistingElementShouldReturnTheFirstOccurrenceOfTheElement()
        {
            linkedList.Add(5);
            linkedList.Add(10);
            linkedList.Add(20);
            linkedList.Add(10);

            Assert.AreEqual(1, linkedList.IndexOf(10));
        }

        [TestMethod]
        public void IfTheListContainsElementItShouldReturnItCorrectly()
        {
            linkedList.Add(5);
            linkedList.Add(10);
            linkedList.Add(20);
            linkedList.Add(2);

            Assert.IsTrue(linkedList.Contains(10));
        }

        [TestMethod]
        public void IfTheListDoesNotContainsElementItShouldReturnMinusOne()
        {
            linkedList.Add(5);
            linkedList.Add(10);
            linkedList.Add(20);
            linkedList.Add(2);

            Assert.IsFalse(linkedList.Contains(17));
        }
    }
}
