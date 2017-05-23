using System.Collections.Generic;
using Atom.IO.Interfaces;

namespace Atom.DataCenter.D2O.Files
{
    public class D2OClass
    {
        public string Name { get; }
        public string PackageName { get; }
        public List<D2OProperty> Properties { get; }

        public D2OClass(string className, string packageName)
        {
            Properties = new List<D2OProperty>();
            Name = className;
            PackageName = packageName;
        }

        internal void AddField(IReader reader)
        {
            var property = new D2OProperty(reader);

            Properties.Add(property);
        }
    }
}
