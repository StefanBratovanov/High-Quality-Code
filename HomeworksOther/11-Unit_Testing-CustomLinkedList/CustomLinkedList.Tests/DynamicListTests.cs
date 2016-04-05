namespace CustomLinkedList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        private DynamicList<int> testDynamicList;

        [TestInitialize]
        public void SetUp()
        {
            this.testDynamicList = new DynamicList<int>();
        }

        [TestMethod]
        public void Add_SingleEntry_ShouldAddValueAsSingleEntry()
        {
            this.testDynamicList.Add(15);

            Assert.AreEqual(1, this.testDynamicList.Count, "Input element is not added.");
        }

        [TestMethod]
        public void Add_MultipleEntries_ShouldSetMultipleValues()
        {
            this.testDynamicList.Add(16);
            this.testDynamicList.Add(25);
            this.testDynamicList.Add(41);

            Assert.AreEqual(3, this.testDynamicList.Count, "Input elements are not succesfully added.");
        }

        [TestMethod]
        public void Add_AddingAlreadyExistingRecord_ShouldAddTheSameValue()
        {
            this.testDynamicList.Add(15);
            this.testDynamicList.Add(84);
            this.testDynamicList.Add(15);

            Assert.AreEqual(3, this.testDynamicList.Count, "The same value is not added a second time.");
        }

        [TestMethod]
        public void Contains_CheckInSingleEntry_ShouldReturnTrue()
        {
            this.testDynamicList.Add(162);

            Assert.AreEqual(true, this.testDynamicList.Contains(162), "Incorectly found record.");
        }

        [TestMethod]
        public void Contains_CheckInMultipleEntires_ShouldReturnTrue()
        {
            this.testDynamicList.Add(12);
            this.testDynamicList.Add(154);
            this.testDynamicList.Add(5);
            this.testDynamicList.Add(54);

            Assert.AreEqual(true, this.testDynamicList.Contains(154), "Incorectly found record.");
        }

        [TestMethod]
        public void Contains_NonExistingEntryInSingleRecord_ShouldReturnFalse()
        {
            this.testDynamicList.Add(154);

            Assert.IsFalse(this.testDynamicList.Contains(2), "Found a nonexisting record.");
        }

        [TestMethod]
        public void Contains_NonExistingEntryInMultipleRecords_ShouldReturnFalse()
        {
            this.testDynamicList.Add(12);
            this.testDynamicList.Add(154);
            this.testDynamicList.Add(5);
            this.testDynamicList.Add(54);

            Assert.IsFalse(this.testDynamicList.Contains(8), "Found a non exsisting record.");
        }

        [TestMethod]
        public void Remove_RemoveFromEmptyList_ShouldReturnMinusOne()
        {
            var result = this.testDynamicList.Remove(0);

            Assert.AreEqual(-1, result, "Incorrect index from empty list");
            Assert.AreEqual(0, this.testDynamicList.Count, "Incorrect number of elements after try for remove.");
        }

        [TestMethod]
        public void Remove_FromSingleElementList_ShouldRemoveTheValueAndShowCorrectIndex()
        {
            this.testDynamicList.Add(18);

            var result = this.testDynamicList.Remove(18);

            Assert.AreEqual(0, result, "Incorrect index of removed value.");
            Assert.AreEqual(0, this.testDynamicList.Count, "Record is not removed");
        }

        [TestMethod]
        public void Remove_FirstElementFromMultiEntriesList_ShouldRemoveTheFirstElementAndReturnZero()
        {
            this.testDynamicList.Add(12);
            this.testDynamicList.Add(154);
            this.testDynamicList.Add(5);
            this.testDynamicList.Add(54);

            var result = this.testDynamicList.Remove(12);

            Assert.AreEqual(0, result, "Incorrect index of removed first record.");
            Assert.AreEqual(3, this.testDynamicList.Count, "Record is not removed.");
        }

        [TestMethod]
        public void Remove_LastElementFromMultipleEntries_ShouldRemoveTheLastElementAndReturnItsIndex()
        {
            this.testDynamicList.Add(12);
            this.testDynamicList.Add(154);
            this.testDynamicList.Add(5);
            this.testDynamicList.Add(54);

            var result = this.testDynamicList.Remove(54);

            Assert.AreEqual(3, result, "Incorrect index of removed last record.");
            Assert.AreEqual(3, this.testDynamicList.Count, "Record is not removed");
        }

        [TestMethod]
        public void Remove_FromMiddleInMultipleEntries_ShouldRemoveElementWithCorrectIndex()
        {
            this.testDynamicList.Add(12);
            this.testDynamicList.Add(154);
            this.testDynamicList.Add(5);
            this.testDynamicList.Add(54);

            var result = this.testDynamicList.Remove(154);

            Assert.AreEqual(1, result, "Incorrect index of removed last record.");
            Assert.AreEqual(3, this.testDynamicList.Count, "Record is not removed");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void RemoveAt_FromEmptyList_ShouldThrow()
        {
            this.testDynamicList.RemoveAt(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void RemoveAt_NegativePosition_ShouldThrow()
        {
            this.testDynamicList.Add(3);

            this.testDynamicList.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void RemoveAt_PositionEqualToListLenght_ShouldThrow()
        {
            this.testDynamicList.Add(6);
            this.testDynamicList.Add(17);

            this.testDynamicList.RemoveAt(this.testDynamicList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void RemoveAt_PositionGreaterThanListLenght_ShouldThrow()
        {
            this.testDynamicList.Add(6);
            this.testDynamicList.Add(17);

            this.testDynamicList.RemoveAt(this.testDynamicList.Count + 1);
        }

        [TestMethod]
        public void RemoveAt_LastPositin_ShouldRemoveElementOnLastPosition()
        {
            this.testDynamicList.Add(6);
            this.testDynamicList.Add(17);

            var result = this.testDynamicList.RemoveAt(1);

            Assert.AreEqual(17, result, "Incorrect removed value");
            Assert.AreEqual(1, this.testDynamicList.Count, "Record is not removed");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Indexator_GetFromEmptyList_ShouldThrow()
        {
            var result = this.testDynamicList[0];
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Indexator_GetElementFromNegativeIndex_ShouldThrow()
        {
            this.testDynamicList.Add(8);

            var result = this.testDynamicList[-2];
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Indexator_GetElementEqualToListCount_ShouldThrow()
        {
            this.testDynamicList.Add(17);
            this.testDynamicList.Add(21);

            var result = this.testDynamicList[this.testDynamicList.Count];
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Indexator_GetElementOnPositionGreaterThanListLenght_ShouldThrow()
        {
            this.testDynamicList.Add(5);
            this.testDynamicList.Add(24);

            var result = this.testDynamicList[this.testDynamicList.Count + 1];
        }

        [TestMethod]
        public void Indexator_GetFirstElement_ShouldReturnTheFirstElement()
        {
            this.testDynamicList.Add(64);
            this.testDynamicList.Add(126);
            this.testDynamicList.Add(64);

            var result = this.testDynamicList[0];

            Assert.AreEqual(64, result, "Invalid returned value.");
        }

        [TestMethod]
        public void Indexator_GetLastValue_ShouldReturnTheLastElement()
        {
            this.testDynamicList.Add(64);
            this.testDynamicList.Add(126);
            this.testDynamicList.Add(64);

            var result = this.testDynamicList[2];

            Assert.AreEqual(64, result, "Invalid returned value.");
        }

        [TestMethod]
        public void Indexator_GetMiddleValue_ShouldReturnSomeMiddleValue()
        {
            this.testDynamicList.Add(64);
            this.testDynamicList.Add(126);
            this.testDynamicList.Add(64);

            var result = this.testDynamicList[1];

            Assert.AreEqual(126, result, "Invalid returned value.");
        }

        [TestMethod]
        public void Indexator_SetSingleValue_ShouldChangeCurrentValue()
        {
            this.testDynamicList.Add(4);
            this.testDynamicList[0] = 5;

            Assert.AreEqual(true, this.testDynamicList.Contains(5), "Saved incorrect value.");
        }

        [TestMethod]
        public void Indexator_SetDifferentValueToLastElement_ShouldChangeTheLastValue()
        {
            this.testDynamicList.Add(4);
            this.testDynamicList.Add(8);
            this.testDynamicList.Add(9);
            this.testDynamicList.Add(15);

            this.testDynamicList[this.testDynamicList.Count - 1] = 3;

            Assert.AreEqual(3, this.testDynamicList[3], "Value of last element is not correctly changed.");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Indexator_SetValueToEmptyList_ShouldThrow()
        {
            this.testDynamicList[0] = 3;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Indexator_SetingNonExistentElement_ShouldThrow()
        {
            this.testDynamicList.Add(5);
            this.testDynamicList.Add(4);

            this.testDynamicList[7] = 2;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Indexator_SetElementOnIndexEqualToListCount_ShouldThrow()
        {
            this.testDynamicList.Add(5);
            this.testDynamicList.Add(7);

            this.testDynamicList[this.testDynamicList.Count] = 2;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Indexator_SetNegativeIndex_ShouldThrow()
        {
            this.testDynamicList.Add(2);

            this.testDynamicList[-1] = 0;
        }
    }
}