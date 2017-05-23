using Atom.Core.Attributes.Class;
using Atom.Core.Attributes.Property;

namespace Atom.Protocol.Types.Connection
{
    [NetworkType(25)]
    public class GameServerInformations
    {
        [CustomVar]
        public short ServerId { get; set; }
        public byte Type { get; set; }
        public byte Status { get; set; }
        public byte Completion { get; set; }

        [RegularBool]
        public bool IsSelectable { get; set; }
        public byte CharactersCount { get; set; }
        public byte CharactersSlots { get; set; }
        public double Date { get; set; }
    }
}
