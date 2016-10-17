using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class Program
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
        static void Main(string[] args)
        {
            // creation
            var keeper = new IDKeeper();
            var obj1 = keeper.CreateObject<MyClass>();
            var obj2 = keeper.CreateObject<MyClass2>();
            var obj3 = keeper.CreateObject<MyClass>();

            // get pair by Type
            var pairs = keeper.GetPair<MyClass>();
            var notExistedPair = keeper.GetPair<int>();

            // get object by Guid
            var notExistedObject = keeper.GetObject(new Guid());
            var getMyClass = keeper.GetObject(pairs.First().Key);
           

        }
    }
}
