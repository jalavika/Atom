using Atom.Core.Attributes.Class;
using Atom.Core.Attributes.Property;
using Atom.Core.Enums;

namespace Atom.Protocol.Messages.Connection
{
    [NetworkMessage(40, Origin.Client)]
    public class ServerSelectionMessage
    {
        [CustomVar]
        public short ServerId { get; set; }
    }
}