using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowser.Reader.Model
{
    public class DataType
    {
        public string Name { get; set; }
        public ICollection<Field> Fields { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Method> Methods { get; set; }
    }
}
