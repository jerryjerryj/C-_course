using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_1_Incapsulation;

namespace EssentialRealization
{
    [TestClass]
    public class TestGame
    {
        private static SimpleGame CorrectGame = new SimpleGame(1, 2, 3, 0);

        private void CheckArrays(int[][] expected)
        {
            for (int i = 0; i < 2; ++i)
                for (int j = 0; j < 2; ++j)
                    Assert.AreEqual(expected[i][j], CorrectGame[i, j]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWrongArguments_UncorrectLength()
        {
            new SimpleGame(1, 2, 3, 4, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWrongArguments_WithoutZeroNumber()
        {
            var game = new SimpleGame(1, 2, 3, 5);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCorrectArguments_DuplicatesExist()
        {
            var game = new SimpleGame(1, 2, 2, 5);
        }
        [TestMethod]
        public void TestCorrectArguments()
        {
            CheckArrays(new int[2][] { new int[2] { 1, 2 }, new int[2] { 3, 0 } });            
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestOfGettingLocationOfWrongValue()
        {
            CorrectGame.Shift(6);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestShiftingToNumberDifferentFromZero()
        {
            CorrectGame.Shift(1);
        }
        [TestMethod]
        public void TestShift2Numbers()
        {
            CorrectGame.Shift(3);
            CheckArrays(new int[2][] { new int[2] { 1, 2 }, new int[2] { 0, 3 } }); 
        }
    }
}
