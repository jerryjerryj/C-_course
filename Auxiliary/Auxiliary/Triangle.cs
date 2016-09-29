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
            A = a;
            B = b;
            C = c;
        }
        public static Triangle Set3Sides(double sideAB, double sideBC, double sideCA)
        {
            return new Triangle(sideAB, sideBC, sideCA );
        }
        public static Triangle Set1Angle2Sides(double angleA, double sideAB, double sideAC)
        {
            double sideBC = Math.Sqrt(Math.Pow(sideAB, 2) + Math.Pow(sideAC, 2) - 2 * sideAB * sideAC * Math.Cos(angleA));
            return new Triangle(sideAB, sideAC, sideBC );
        }
        public static Triangle Set2Angles1Side(double angleA, double angleB, double sideAB)
        {
            double angleC =DegreesToRadians(180) - angleA - angleB;
            double sideBC = GetSide(angleA, sideAB, angleC);
            double sideCA = GetSide(angleB, sideAB, angleC);
            return new Triangle(sideAB, sideBC, sideCA );
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
            var halfArea = (A + B + C) / 2;
            return Math.Sqrt(halfArea * (halfArea - A) * (halfArea - B) * (halfArea - C)); 
        }
    }
}
