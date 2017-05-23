using Atom.Core.Attributes.Class;
using Atom.Core.Attributes.Property;
using Atom.Core.Enums;
using Atom.Protocol.Types.Version;

namespace Atom.Protocol.Messages.Connection
{
    [NetworkMessage(4, Origin.Client)]
    public class IdentificationMessage
    {
        [ForceNewByte]
        public bool Autoconnect { get; set; }
        public bool UseCertificate { get; set; }
        public bool UseLoginToken { get; set; }

        public VersionExtended Version { get; set; }

        public string Lang { get; set; }

        [LengthType(typeof(int), true)]
        public sbyte[] Credentials { get; set; }

        public short ServerId { get; set; }

        public short[] FailedAttempts { get; set; }
    }
}
