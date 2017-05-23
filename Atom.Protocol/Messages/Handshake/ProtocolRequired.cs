using Atom.Core.Attributes.Class;
using Atom.Core.Enums;

namespace Atom.Protocol.Messages.Handshake
{
    [NetworkMessage(1, Origin.Server)]
    public class ProtocolRequired
    {
        public int RequiredVersion { get; set; }
        public int CurrentVersion { get; set; }
    }
}
