using System;
using System.Collections.Generic;
using System.Linq;
using AssemblyBrowser.Reader.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyBrowser.Reader.Test
{
    [TestClass]
    public class ReaderTest
    {
        private const string Dll = @"D:\учёба\3 курс\5 сем\СПП\2 лаба\Plugins\Plugins\Generators\bin\Debug\netstandard2.0\Generators.dll";
        private List<Namespace> _namespaces;

        [TestInitialize]
        public void Init()
        {
            var reader = new ReadAssembly();
            _namespaces = reader.GetInformation(Dll);
        }

        [TestMethod]
        public void TestNamespacesNotNull()
        {
            _namespaces.Should().NotBeNull();
        }

        [TestMethod]
        public void TestNamespacesCount()
        {
            int expected = 1;
            _namespaces.Count.Should().Be(expected);
        }

        [TestMethod]
        public void TestDataTypesCount()
        {
            int expected = 13;
            _namespaces[0].DataTypes.Count.Should().Be(expected);
        }

        [TestMethod]
        public void TestContainToStringMethod()
        {
            //TODO: проверить на наличие метода у коллекции
            string expected = "ToString";

            foreach (var ns in _namespaces)
            {
                foreach (var type in ns.DataTypes)
                {
                    Assert.IsNotNull(type.Methods.Where(x => x.Name == expected));
                }
            }
        }

        [TestMethod]
        public void TestContainEqualsMethod()
        {
            //TODO: проверить на наличие метода у коллекции
            string expected = "Equals";

            foreach (var ns in _namespaces)
            {
                foreach (var type in ns.DataTypes)
                {
                    Assert.IsNotNull(type.Methods.Where(x => x.Name == expected));
                }
            }
        }

        [TestMethod]
        public void TestContainGetHashCodeMethod()
        {
            //TODO: проверить на наличие метода у коллекции
            string expected = "GetHashCode";

            foreach (var ns in _namespaces)
            {
                foreach (var type in ns.DataTypes)
                {
                    Assert.IsNotNull(type.Methods.Where(x => x.Name == expected));
                }
            }
        }

        [TestMethod]
        public void TestContainGetTypeMethod()
        {
            //TODO: проверить на наличие метода у коллекции
            string expected = "GetType";

            foreach (var ns in _namespaces)
            {
                foreach (var type in ns.DataTypes)
                {
                    Assert.IsNotNull(type.Methods.Where(x => x.Name == expected));
                }
            }
        }
    }
}
