using Atom.Core.Attributes.Class;
using Atom.Core.Attributes.Property;
using Atom.Core.Enums;
using Atom.Protocol.Types.Connection;

namespace Atom.Protocol.Messages.Connection
{
    [NetworkMessage(30, Origin.Server)]
    public class ServerListMessage
    {
        public GameServerInformations[] Servers { get; set; }

        [CustomVar]
        public short AlreadyConnectedToServerId { get; set; }

        [RegularBool]
        public bool CanCreateNewCharacter { get; set; }
    }
}
