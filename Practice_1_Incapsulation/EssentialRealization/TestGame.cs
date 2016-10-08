using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_1_Incapsulation;

namespace EssentialRealization
{
    [TestClass]
    public abstract class TestGame
    {
        protected static Game CorrectGame;

        private void CheckArrays(int[][] expected)
        {
            
            for (int i = 0; i < 2; ++i)
                for (int j = 0; j < 2; ++j)
                    Assert.AreEqual(expected[i][j], CorrectGame[i, j]);
        }

        protected abstract void CreateGame(params int[] values);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWrongArguments_UncorrectLength()
        {
            CreateGame(1, 2, 3, 4, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWrongArguments_WithoutZeroNumber()
        {
            CreateGame(1, 2, 3, 5);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCorrectArguments_DuplicatesExist()
        {
            CreateGame(1, 2, 2, 5);
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


        protected void TestShift2Numbers()
        {
            CorrectGame = CorrectGame.Shift(3);
            CheckArrays(new int[2][] { new int[2] { 1, 2 }, new int[2] { 0, 3 } }); 
        }

        protected  void TestIfGameIsImmutable()
        {
            var immutable = CorrectGame.Shift(3);
            bool isPassed = false;
            for (int i = 0; i < 2; ++i)
                for (int j = 0; j < 2; ++j)
                    if (CorrectGame[i, j] != immutable[i, j])
                        isPassed = true;
            if(!isPassed)
                Assert.Fail();
                        
        }
    }
}
