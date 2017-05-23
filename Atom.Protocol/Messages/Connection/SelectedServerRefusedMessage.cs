using Atom.Core.Attributes.Class;
using Atom.Core.Attributes.Property;
using Atom.Core.Enums;

namespace Atom.Protocol.Messages.Connection
{
    [NetworkMessage(41, Origin.Server)]
    public class SelectedServerRefusedMessage
    {
        [CustomVar]
        public short ServerId { get; set; }
        public byte Error { get; set; }
        public byte ServerStatus { get; set; }
    }
}