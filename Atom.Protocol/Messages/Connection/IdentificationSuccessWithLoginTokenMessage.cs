using Atom.Core.Attributes.Class;
using Atom.Core.Enums;

namespace Atom.Protocol.Messages.Connection
{
    [NetworkMessage(6209, Origin.Server)]
    public class IdentificationSuccessWithLoginTokenMessage : IdentificationMessage
    {
        public string LoginToken { get; set; }
    }
}