using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auxiliary;
namespace UnitTestProject1
{
    [TestClass]
    public class TestTriangle
    {

        [TestMethod]
        public void Test3Sides()
        {
            var area = Triangle.CreateFrom3Sides(5,3,4).GetArea();
            Assert.AreEqual((double) 6, area);
        }
        [TestMethod]
        public void Test2SidesEqual()
        {
            var angleInRad = Triangle.DegreesToRadians(90);
            var area = Triangle.CreateFrom1Angle2Sides(angleInRad, 4, 8).GetArea();
            Assert.AreEqual((double)16, area);
        }
        [TestMethod]
        public void Test2SidesUnequal()
        {
            var area = Triangle.CreateFrom1Angle2Sides(90, 4, 8).GetArea();
            Assert.AreNotEqual((double)16, area);
        }
        [TestMethod]
        public void TestDegreesToRadians()
        {
            var radian = Triangle.DegreesToRadians(90);
            Assert.AreEqual((double)1.5708, Math.Round(radian,4));
        }
        [TestMethod]
        public void Test1SideEqual()
        {
            var angleInRad1 = Triangle.DegreesToRadians(60);
            var angleInRad2 = Triangle.DegreesToRadians(30);
            var area = Triangle.CreateFrom2Angles1Side(  angleInRad1, angleInRad2, 8.9).GetArea();
            Assert.AreEqual((double)17.1495, Math.Round(area, 4));
        }

        [TestMethod]
        public void TestCreationWithWrongInputBelowZero()
        {
            Assert.AreEqual(null, TestWrongInput(-5,4,3));
        }
        [TestMethod]
        public void TestCreationWithWrongInputNonTriangle()
        {
            Assert.AreEqual(null, TestWrongInput(2, 3, 50));
        }


        public Triangle TestWrongInput(double a, double b, double c)
        {
            Triangle t = null;
            try
            {
                t = Triangle.CreateFrom3Sides(a,b,c);
            } catch (Exception) { }
            return t;
        }
    }
}
