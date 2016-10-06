using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_1_Incapsulation;

namespace EssentialRealization
{
    [TestClass]
    public class TestGame
    {
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWrongArguments_UncorrectLength()
        {
            new Game(1, 2, 3, 4, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWrongArguments_WithoutZeroNumber()
        {
            var game = new Game(1, 2, 3, 5);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCorrectArguments_DuplicatesExist()
        {
            var game = new Game(1, 2, 2, 5);
        }
        [TestMethod]
        public void TestCorrectArguments()
        {
            int[][] expectedMatrix = new int[2][] { new int[2] { 1, 2 }, new int[2] { 3, 0 } };
            var game = new Game(1, 2, 3, 0);
            for (int i = 0; i < expectedMatrix.Length;++i )
                CollectionAssert.AreEqual(expectedMatrix[i], game.desk[i]);
        }
        //TODO check LOCATION and SHIFT
    }
}
