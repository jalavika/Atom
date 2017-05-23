using Atom.Core.Attributes.Class;
using Atom.Core.Attributes.Property;
using Atom.Core.Enums;

namespace Atom.Protocol.Messages.Connection
{
    [NetworkMessage(3, Origin.Server)]
    public class HelloConnectMessage
    {
        public string Salt { get; set; }

        [LengthType(typeof(int), true)]
        public byte[] Key { get; set; }
    }
}
