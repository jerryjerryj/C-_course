using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin_1
{
    public class MyClass1 : IPlugin
    {
        public string Name { get; set; }
        public MyClass1()
        {
            Name = "FirstClass";
        }
    }
}
