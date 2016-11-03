using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Framework;

namespace Application
{
    class Program
    {
        public static string[] FindDLLs(string solutionName)
        {
            var solutionPath = Directory.GetCurrentDirectory();
            while (Path.GetFileName(solutionPath)!= solutionName)
                solutionPath = Directory.GetParent(solutionPath).FullName;

            return Directory.GetFiles(solutionPath, "*.dll", SearchOption.AllDirectories);
        }
        static void Main(string[] args)
        {
            var DLLs = FindDLLs("Framework");

            foreach (var dll in DLLs)
            {
                var types = Assembly.LoadFrom(dll).GetTypes();
                foreach(var type in types)
                {
                    var someClass = Activator.CreateInstance(type);
                   // var properties = type.GetProperties();
                   // var value = properties[0].GetValue(someClass);
                    var name = type.GetProperty("Name").GetValue(someClass);
                    Console.WriteLine("DLL : {0}, Name : {1}",type.FullName, name);
                }
            } 
            Console.ReadKey();
        }
    }
}
