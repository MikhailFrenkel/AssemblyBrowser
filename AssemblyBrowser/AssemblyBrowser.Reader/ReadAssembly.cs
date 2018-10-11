using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AssemblyBrowser.Reader
{
    public class ReadAssembly
    {
        public void GetInformation(string pathDll)
        {
            var asm = Assembly.LoadFrom(pathDll);
        }
    }
}
