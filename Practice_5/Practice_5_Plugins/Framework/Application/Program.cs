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

        public static List<TPlugin> GetPlugins<TPlugin>(string[] pathsToDlls)
        {
            var plugins = new List<TPlugin>();
            foreach (var path in pathsToDlls)
            {
                var dll = new Dll(path);
                var instances = dll.GetInstances<TPlugin>();
                if (instances != null)
                    plugins.AddRange(instances);
            }
            return plugins;
        }

        static void Main(string[] args)
        {
            var pathsToDlls = FindDlls("Framework");
            var plugins = GetPlugins<IPlugin>(pathsToDlls);
            foreach (var plugin in plugins)
                Console.WriteLine("Name is : " + plugin.Name);

            Console.ReadKey();
        }
        private class Dll
        {
            private Assembly assembly;
            public Dll(string path)
            {
                try
                {
                    assembly = Assembly.LoadFrom(path);
                }
                catch (FileNotFoundException)
                {
                    assembly = null;
                }
            }

            public List<TObject> GetInstances<TObject>()
            {
                if (assembly == null)
                    return null;

                var types = assembly.GetTypes();
                if (types == null)
                    return null;

                var result = new List<TObject>(); 
                foreach (var type in types)
                {
                    var instanceFromDll = Activator.CreateInstance(type);
                    if ((instanceFromDll != null) && (instanceFromDll is TObject))
                        result.Add((TObject)instanceFromDll);
                }
                return result;
            }
        }
    }
}
