using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auxiliary
{
    class Program
    {
        static void Main(string[] args)
        {
            var angleInRad1 = Triangle.DegreesToRadians(30);
            var angleInRad2 = Triangle.DegreesToRadians(60);
            var area = Triangle.Set2Angles1Side(angleInRad1, angleInRad2, 8.8).GetArea();
        }
    }
}
