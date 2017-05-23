using Atom.Core.Attributes.Class;
using Atom.Core.Enums;

namespace Atom.Protocol.Messages.Connection
{
    [NetworkMessage(6174, Origin.Server)]
    public class IdentificationFailedBannedMessage : IdentificationFailedMessage
    {
        public double BanEndDate { get; set; }
    }
}