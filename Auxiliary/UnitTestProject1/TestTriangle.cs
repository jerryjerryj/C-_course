using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auxiliary;
namespace UnitTestProject1
{
    [TestClass]
    public class TestTriangle
    {

        [TestMethod]
        public void TestCorrectCreationBy3Sides()
        {
            var area = Triangle.CreateFrom3Sides(5,3,4).GetArea();
            Assert.AreEqual(6d, area);
        }
        [TestMethod]
        public void TestCorrectCreationBy2Sides1Angle()
        {
            var angleInRad = Triangle.DegreesToRadians(90);
            var area = Triangle.CreateFrom1Angle2Sides(angleInRad, 4, 8).GetArea();
            Assert.AreEqual(16d, area);
        }
        [TestMethod]
        public void TestWrongCreationBy2Sides1Angle()
        {
            var area = Triangle.CreateFrom1Angle2Sides(90, 4, 8).GetArea();
            Assert.AreEqual(14.3039, Math.Round(area,4));
        }
        [TestMethod]
        public void TestDegreesToRadiansConverter()
        {
            var radian = Triangle.DegreesToRadians(90);
            Assert.AreEqual(1.5708, Math.Round(radian,4));
        }
        [TestMethod]
        public void TestCorrectCreationBy1Side2Angles()
        {
            var angleInRad1 = Triangle.DegreesToRadians(60);
            var angleInRad2 = Triangle.DegreesToRadians(30);
            var area = Triangle.CreateFrom2Angles1Side(  angleInRad1, angleInRad2, 8.9).GetArea();
            Assert.AreEqual(17.1495, Math.Round(area, 4));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestCreationWithWrongInputBelowZero()
        {
            Assert.AreEqual(null, TestWrongInput(-5,4,3));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestCreationWithWrongInputNonTriangle()
        {
            Assert.AreEqual(null, TestWrongInput(2, 3, 50));
        }
        
        public Triangle TestWrongInput(double a, double b, double c)
        {
            return Triangle.CreateFrom3Sides(a,b,c);
        }
    }
}
