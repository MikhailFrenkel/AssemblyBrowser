using System;
using System.Collections.Generic;

namespace AssemblyBrowser.Reader.Models
{
    public class DataType
    {
        public string Name { get; set; }
        public ICollection<Field> Fields { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Method> Methods { get; set; }

        public DataType(Type type)
        {
            Name = type.Name;
            GetFields(ref type);
            GetProperties(ref type);
            GetMethods(ref type);
        }

        private void GetFields(ref Type type)
        {
            var fields = type.GetFields();
            if (fields.Length != 0)
            {
                Fields = new List<Field>();
                foreach (var field in fields)
                {
                    Fields.Add(new Field(field));
                }
            }
        }

        private void GetProperties(ref Type type)
        {
            var properties = type.GetProperties();
            if (properties.Length != 0)
            {
                Properties = new List<Property>();
                foreach (var property in properties)
                {
                    Properties.Add(new Property(property));
                }
            }
        }

        private void GetMethods(ref Type type)
        {
            var methods = type.GetMethods();
            if (methods.Length != 0)
            {
                Methods = new List<Method>();
                foreach (var method in methods)
                {
                    Methods.Add(new Method(method));
                }
            }
        }
    }
}
