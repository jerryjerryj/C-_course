using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1_Incapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] expectedMatrix = new int[2][] { new int[2] { 1, 2 }, new int[2] { 3, 0 } };
            var game = new Game(1, 2, 3, 0);
        }
    }
}
