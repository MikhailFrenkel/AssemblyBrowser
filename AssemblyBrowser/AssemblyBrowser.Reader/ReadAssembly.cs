using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AssemblyBrowser.Reader.Models;

namespace AssemblyBrowser.Reader
{
    public class ReadAssembly
    {
        private List<Namespace> _namespaces;

        public ReadAssembly()
        {
            _namespaces = new List<Namespace>();
        }

        public void GetInformation(string pathDll)
        {
            var asm = Assembly.LoadFrom(pathDll);
            foreach (var type in asm.DefinedTypes)
            {
                if (_namespaces.Find(x => x.Name == type.Namespace) == null && type.Namespace != null)
                {
                    _namespaces.Add(new Namespace()
                    {
                        Name = type.Namespace
                    });
                }
            }
        }
    }
}
