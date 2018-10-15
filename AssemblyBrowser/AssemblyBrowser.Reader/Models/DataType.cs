using System.Collections.Generic;

namespace AssemblyBrowser.Reader.Models
{
    public class DataType
    {
        public string Name { get; set; }
        public ICollection<Field> Fields { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Method> Methods { get; set; }
    }
}
