using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<double, double>> f = x => Math.Sin(x*x);
            Expression<Func<double, double>> df = f.Differentiate();

            Console.WriteLine("f  = {0}", f);   //f  = x => (x * x)
            Console.WriteLine("df = {0}", df);  //df = x => (x + x)

            Func<double, double> compiled = df.Compile();
            double result = compiled.Invoke(10);
            Console.WriteLine(result);          //24
            Console.ReadKey();
        }
    }
}
