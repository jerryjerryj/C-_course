using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_1_Incapsulation;

namespace EssentialRealization
{
    [TestClass]
    public class TestImmutableEconomicGame : TestGame
    {
         public TestImmutableEconomicGame()
            : base()
        {
            CorrectGame = new ImmutableEconomicGame(1, 2, 3, 0);
        }

         protected override void CreateGame(params int[] values)
         {
             new ImmutableEconomicGame(values);
         }

         [TestMethod]
         public void TestImmutableEconomicGame_Shift2Numbers()
         {
             TestShift2Numbers();
         }

         [TestMethod]
         public void TestImmutableEconomicGame_IsImmutable()
         {
             TestIfGameIsImmutable();
         }
    }
}
