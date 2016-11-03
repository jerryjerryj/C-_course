using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin_2
{
     public class MyClass2 : IPlugin
    {
         public string Name { get; set; }
         public MyClass2()
         {
             Name = "SecondClass";
         }

    }
}