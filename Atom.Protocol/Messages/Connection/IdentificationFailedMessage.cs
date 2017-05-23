using Atom.Core.Attributes.Class;
using Atom.Core.Enums;

namespace Atom.Protocol.Messages.Connection
{
    [NetworkMessage(20, Origin.Server)]
    public class IdentificationFailedMessage
    {
        public byte Reason { get; set; }
    }
}