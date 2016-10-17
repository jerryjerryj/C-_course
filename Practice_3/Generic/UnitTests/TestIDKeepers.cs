using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic;


namespace UnitTests
{
     class MyClass
        {
            public DateTime created;
            public MyClass()
            {
                created = DateTime.Now;
            }
        }
        class MyClass2 { }

    [TestClass]
    public class TestIDKeepers
    {

        private static IDKeeper keeper;


        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            keeper = new IDKeeper();
            keeper.CreateObject<MyClass>();
            keeper.CreateObject<MyClass2>();
            keeper.CreateObject<MyClass>();
        }
        [TestMethod]
        public void TestIfObjectHasCreated()
        {
            var obj = new IDKeeper().CreateObject<MyClass>();
            Assert.IsInstanceOfType(obj, typeof(MyClass));
        }

        [TestMethod]
        public void TestIfKeeperReturnsPairsWhenItHaveObjectsOfRequestedType()
        {
            var pairs = keeper.GetPair<MyClass>();
            Assert.AreEqual(2, pairs.Count);
        }
        [TestMethod]
        public void TestIfKeeperReturnsNullWhenItHaventAnyPairForRequestedType()
        {
            var notExistedPair = keeper.GetPair<int>();
            Assert.AreEqual(0, notExistedPair.Count);
        }
    }
}
