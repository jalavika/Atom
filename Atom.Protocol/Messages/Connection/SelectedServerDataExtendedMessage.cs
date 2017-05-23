using Atom.Core.Attributes.Class;
using Atom.Core.Attributes.Property;
using Atom.Core.Enums;

namespace Atom.Protocol.Messages.Connection
{
    [NetworkMessage(6469, Origin.Server)]
    public class SelectedServerDataExtendedMessage : SelectedServerDataMessage
    {
        [CustomVar]
        [LengthType(typeof(short))]
        public short[] ServerIds { get; set; }
    }
}