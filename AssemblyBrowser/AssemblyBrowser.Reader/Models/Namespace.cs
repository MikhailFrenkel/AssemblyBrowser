using System.Collections.Generic;

namespace AssemblyBrowser.Reader.Models
{
    public class Namespace
    {
        public string Name { get; set; }
        public ICollection<DataType> DataTypes { get; set; }

        public Namespace()
        {

        }
    }
}
