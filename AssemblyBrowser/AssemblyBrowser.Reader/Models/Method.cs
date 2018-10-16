using System.Reflection;

namespace AssemblyBrowser.Reader.Models
{
    public class Method
    {
        public string Name { get; set; }

        public string Signature { get; set; }

        public Method(MethodInfo method)
        {
            Name = method.Name;
            if (!method.IsSpecialName)
            {
                Signature = "public ";
                if (method.IsStatic)
                {
                    Signature += "static ";
                }
                else if (method.IsVirtual && !method.IsFinal)
                {
                    Signature += "virtual ";
                }

                Signature += method + ";";
            }
        }
    }
}
