﻿using System;
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
            Fields = new List<Field>();
            var fields = type.GetFields();
            
            foreach (var field in fields)
            {
                Fields.Add(new Field(field));
            }
        }

        private void GetProperties(ref Type type)
        {
            Properties = new List<Property>();
            var properties = type.GetProperties();
            
            foreach (var property in properties)
            {
                Properties.Add(new Property(property));
            }
        }

        private void GetMethods(ref Type type)
        {
            Methods = new List<Method>();
            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                if (!method.IsSpecialName)
                {
                    Methods.Add(new Method(method));
                }
            }
        }
    }
}
