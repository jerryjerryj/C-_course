using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Generic
{
    class MyClass
    {
        public DateTime created;
        public MyClass()
        {
            created = DateTime.Now;
        }
    }
    class MyClass2 { }
    public class Program
    {
       
        static void Main(string[] args)
        {
            var keeper2 = new IDKeeper();
            for (int i = 0; i < 10000;++i )
                keeper2.CreateObject<MyClass>();
            keeper2.CreateObject<StringBuilder>();
            keeper2.CreateObject<MyClass2>();

            keeper2.GetObject(new Guid());
            var timer = new Stopwatch();
            timer.Start();
            var temp = keeper2.GetPair<MyClass2>();
            timer.Stop();



            Console.Write(timer.Elapsed);
            Console.ReadKey();
        }
    }
}
