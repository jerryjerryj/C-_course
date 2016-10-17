using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        class MyClass {}
        class MyClass2 { }
        static void Main(string[] args)
        {
            var keeper = new IDKeeper();
            var obj1 = keeper.CreateObject<MyClass>();
            var obj2 = keeper.CreateObject<MyClass2>();
            var notExistedObject = keeper.GetObject(new Guid());
            
            var pair = keeper.GetPair(obj2);
            var objectFromPair = keeper.GetObject(pair.guid);
        }
    }
}
