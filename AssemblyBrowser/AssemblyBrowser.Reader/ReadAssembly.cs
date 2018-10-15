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
        private readonly List<Namespace> _namespaces;
        private Assembly _asm;

        public ReadAssembly()
        {
            _namespaces = new List<Namespace>();
        }

        public void GetInformation(string pathDll)
        {
            _asm = Assembly.LoadFrom(pathDll);
            LoadNamespaces();
            LoadDataTypes();
        }

        private void LoadNamespaces()
        {
            foreach (var type in _asm.DefinedTypes)
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

        private void LoadDataTypes()
        {
            foreach (var ns in _namespaces)
            {
                foreach (var type in _asm.DefinedTypes.Where(x => x.Namespace == ns.Name))
                {
                    ns.DataTypes.Add(new DataType(type));
                }
            }
        }
    }
}
