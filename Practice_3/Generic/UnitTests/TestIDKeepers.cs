using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic;
using System.Linq;


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
        public void TestIfKeeperReturnsEmptyDictionaryWhenItHaventAnyPairForRequestedType()
        {
            var notExistedPair = keeper.GetPair<int>();
            Assert.IsNull(notExistedPair);
        }
        [TestMethod]
        public void TestIfKeeperReturnsPairsWhenItHaveObjectsOfRequestedType()
        {
            var pairs = keeper.GetPair<MyClass>();
            Assert.AreEqual(2, pairs.Count);
        }

        [TestMethod]
        public void TestIfKeeperReturnsNullWhenItHaventAnyObjectForRequestedGuid()
        {
            var notExistedObject = keeper.GetObject(new Guid());
            Assert.IsNull(notExistedObject);
        }
        [TestMethod]
        public void TestIfKeeperReturnsObjectForRequestedGuid()
        {
            var pairs = keeper.GetPair<MyClass>();
            var getMyClass = keeper.GetObject(pairs.First().Key);
            Assert.AreEqual(pairs.First().Value, getMyClass);
        }
    }


}
