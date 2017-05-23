using Atom.Core.Attributes.Class;
using Atom.Core.Enums;
using Atom.Protocol.Types.Connection;

namespace Atom.Protocol.Messages.Connection
{
    [NetworkMessage(50, Origin.Server)]
    public class ServerStatusUpdateMessage
    {
        public GameServerInformations Server { get; set; }
    }
}