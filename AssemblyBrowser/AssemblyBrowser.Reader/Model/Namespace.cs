using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowser.Reader.Model
{
    public class Namespace
    {
        public string Name { get; set; }
        public ICollection<DataType> DataTypes { get; set; }
    }
}
