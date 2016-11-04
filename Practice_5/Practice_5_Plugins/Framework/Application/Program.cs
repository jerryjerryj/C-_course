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
        public static string[] FindDlls(string solutionName)
        {
            var solutionPath = Directory.GetCurrentDirectory();
            while (Path.GetFileName(solutionPath)!= solutionName)
                solutionPath = Directory.GetParent(solutionPath).FullName;

            return Directory.GetFiles(solutionPath, "*.dll", SearchOption.AllDirectories);
        }


        static void Main(string[] args)
        {
            var pathsToDlls = FindDlls("Framework");

            foreach (var path in pathsToDlls)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(path);
                    if (assembly == null) continue;

                    var types = assembly.GetTypes();
                    if (types == null) continue;

                    var something = Activator.CreateInstanceFrom(path, "");
                    foreach (var type in types)
                    {
                        if (!(type is IPlugin)) continue;

                        var method = (IPlugin)Activator.CreateInstance(type);
                        Console.WriteLine("Name is : " + method.Name);
                    }
                }
                catch (FileNotFoundException) { }
            }

            Console.ReadKey();
        }
    }
}
