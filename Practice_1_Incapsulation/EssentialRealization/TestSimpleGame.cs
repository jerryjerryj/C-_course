using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_1_Incapsulation;

namespace EssentialRealization
{
    [TestClass]
    public class TestSimpleGame : TestGame
    {
        public TestSimpleGame()
            : base()
        {
            CorrectGame = new SimpleGame(1, 2, 3, 0);
        }
        protected override void CreateGame(params int[] values)
        {
            new SimpleGame(values);
        }

        [TestMethod]
        public void TestSimpleGame_Shift2Numbers()
        {
            TestShift2Numbers();
        }
    }
}
