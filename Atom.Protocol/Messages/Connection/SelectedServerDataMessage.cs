using Atom.Core.Attributes.Class;
using Atom.Core.Attributes.Property;
using Atom.Core.Enums;

namespace Atom.Protocol.Messages.Connection
{
    [NetworkMessage(42, Origin.Server)]
    public class SelectedServerDataMessage
    {
        [CustomVar]
        public short ServerId { get; set; }
        public string Address { get; set; }
        public short Port { get; set; }

        [RegularBool]
        public bool CanCreateNewCharacter { get; set; }

        [LengthType(typeof(int), true)]
        public byte[] Ticket { get; set; }
    }
}