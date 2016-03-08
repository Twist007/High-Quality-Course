namespace CustomLinkedList.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTest
    {
        private DynamicList<int> list;

        [TestInitialize]
        public void InitializeList()
        {
            this.list = new DynamicList<int>();
        }

        [TestMethod]
        public void TestAddMethod_AddNum_CheckIfElementIsAdded()
        {
            this.list.Add(2);

            Assert.AreEqual(1, this.list.Count, "Should return 1");
        }

        [TestMethod]
        public void TestAddMethod_AddMultipalNums_ChekIfCounterWorks()
        {
            this.InizializeValuesInList();

            Assert.AreEqual(4, this.list.Count, "Should return 4");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException), "Invalide index: ")]
        public void TestRemoveMethod_AddMultipalNums_CheckIfIndexIsInvalid()
        {
            this.InizializeValuesInList();
            this.list.RemoveAt(8);

            Assert.AreEqual(3,this.list.RemoveAt(8),"Shuld return ArgumentOutOfRangeException");
        }

        [TestMethod]
        public void TestContainsMethod_CheckIfReturnsCorrectValue()
        {
            
        }
        
        private void InizializeValuesInList()
        {
            this.list.Add(1);
            this.list.Add(1);
            this.list.Add(1);
            this.list.Add(1);
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Runtime.Remoting.Channels;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using CustomLinkedList;

//namespace CustomLinkedListTest
//{
//    [TestClass]
//    public class DynamicListTest
//    {
//        private DynamicList<int> list;

//        [TestInitialize]
//        public void StartUp()
//        {
//            this.list = new DynamicList<int>();
//        }

//        [TestMethod]
//        public void AddMethod_AddNum_CheckIfElementIsAdded()
//        {
//            this.list.Add(1);

//            Assert.AreEqual(1, this.list.Count, "Should return 1");
//        }

//        [TestMethod]
//        public void AddMethod_AddMultipalNums_CheckIfCounterWorks()
//        {
//            this.InizializeValuesInList();

//            Assert.AreEqual(3, this.list.Count, "Should return 3");
//        }



//        [TestMethod]
//        [ExpectedException(typeof(ArgumentOutOfRangeException), "Invalid index: ")]
//        public void RemoveMethod_AddMultipalNums_CheckIfIndexIsInvalid()
//        {

//            this.InizializeValuesInList();
//            this.list.RemoveAt(8);

//            Assert.AreEqual(3, this.list.RemoveAt(8), "Should return ArgumentOutOfRangeException");
//        }

//        [TestMethod]
//        public void RemoveAtMethod_AddMultipalNums_CheckIfRemoves()
//        {
//            this.InitializeAnotherValuesForList();
//            this.list.RemoveAt(1);

//            Assert.AreEqual(2, this.list.Count, "Should return 2");
//        }

//        [TestMethod]
//        public void RemoveMethod_AddMultipalNums_CheckIfRemoves()
//        {
//            this.InitializeAnotherValuesForList();
//            this.list.Remove(2);

//            Assert.AreEqual(2, this.list.Count, "Should return 2");
//        }

//        [TestMethod]
//        public void RemoveMethod_InvalidElement_CheckIfReturnsCorrectValue()
//        {
//            this.InitializeAnotherValuesForList();
//            this.list.Remove(5);

//            Assert.AreEqual(3, this.list.Count, "Should return the number of elements");
//        }

//        [TestMethod]
//        public void ContainsMethod_InvalidElement_CheckIfReturnsCorrectValue()
//        {
//            this.InitializeAnotherValuesForList();
//            this.list.Contains(5);

//            Assert.IsTrue(!(this.list.Contains(5)), "Should return false");
//        }

//        [TestMethod]
//        public void ContainsMethod_CheckIfReturnsCorrectValue()
//        {
//            this.InitializeAnotherValuesForList();

//            Assert.IsTrue(this.list.Contains(2), "Should return true");
//        }

//        [TestMethod]
//        public void IndexOfMethod_CheckIfReturnsCorrectValue()
//        {
//            this.list.Add(1);
//            this.list.Add(3);
//            this.list.Add(5);

//            Assert.AreEqual(2, this.list.IndexOf(5), "Should return 2");
//        }

//        private void InizializeValuesInList()
//        {
//            this.list.Add(1);
//            this.list.Add(1);
//            this.list.Add(1);
//        }

//        private void InitializeAnotherValuesForList()
//        {
//            this.list.Add(1);
//            this.list.Add(2);
//            this.list.Add(3);
//        }
//    }
//}

