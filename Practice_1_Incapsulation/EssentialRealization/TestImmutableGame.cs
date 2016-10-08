using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_1_Incapsulation;

namespace EssentialRealization
{
    [TestClass]
    public class TestImmutableGame : TestGame
    {
         public TestImmutableGame()
            : base()
        {
            CorrectGame = new ImmutableGame(1, 2, 3, 0);
        }

         protected override void CreateGame(params int[] values)
         {
             new ImmutableGame(values);
         }

         [TestMethod]
         public void TestImmutableGame_Shift2Numbers()
         {
             TestShift2Numbers();
         }

         [TestMethod]
         public void TestImmutableGame_IsImmutable()
         {
             TestIfGameIsImmutable();
         }
       
    }
}
