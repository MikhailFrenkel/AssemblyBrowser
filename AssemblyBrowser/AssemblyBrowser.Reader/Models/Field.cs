using System.Reflection;

namespace AssemblyBrowser.Reader.Models
{
    public class Field
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public Field(FieldInfo field)
        {
            Name = field.Name;
            Type = field.FieldType.Name;
        }
    }
}
