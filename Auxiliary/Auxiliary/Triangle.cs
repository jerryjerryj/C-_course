using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auxiliary
{
    public class Triangle
    {
        private double A, B, C; //more useful than array and long names
        private Triangle(double a, double b, double c)
        {
            try
            {
                CheckInput(a,b,c);
            }
            catch (ArgumentException)
            {
                throw;
            }
            A = a;
            B = b;
            C = c;
        }
        public static Triangle CreateFrom3Sides(double sideAB, double sideBC, double sideCA)
        {
           
            return new Triangle(sideAB, sideBC, sideCA );
        }
        public static Triangle CreateFrom1Angle2Sides(double angleA, double sideAB, double sideAC)
        {
            double sideBC = Math.Sqrt(Math.Pow(sideAB, 2) + Math.Pow(sideAC, 2) - 2 * sideAB * sideAC * Math.Cos(angleA));
            return new Triangle(sideAB, sideAC, sideBC );
        }
        public static Triangle CreateFrom2Angles1Side(double angleA, double angleB, double sideAB)
        {
            double angleC =DegreesToRadians(180) - angleA - angleB;
            double sideBC = GetSide(angleA, sideAB, angleC);
            double sideCA = GetSide(angleB, sideAB, angleC);
            return new Triangle(sideAB, sideBC, sideCA );
        }
        private static void CheckInput(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
                throw new ArgumentException("Each side must be bigger than 0");
            if (a + b < c || a + c < b || b + c < a)
                throw new ArgumentException("Each side must be less than 2 another's sum");

        }
        private static double GetSide(double opposideAngle, double knownSide, double knownSideOpposideAngle)
        {
            //var tmp1 = Math.Round(Math.Sin(opposideAngle),4);
            //var tmp2 = Math.Round(Math.Sin(knownSideOpposideAngle),4);
            //var tmp3 = tmp1 * knownSide;
            //var tmp4 = tmp3 / tmp2;
            return Math.Sin(opposideAngle) * knownSide / Math.Sin(knownSideOpposideAngle);
        }
        public static double DegreesToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        public double GetArea()
        {
            var halfPerimeter = (A + B + C) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - A) * (halfPerimeter - B) * (halfPerimeter - C)); 
        }
    }
}
