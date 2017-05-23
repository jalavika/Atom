using Atom.Core.Attributes.Class;

namespace Atom.Protocol.Types.Version
{
    [NetworkType(393)]
    public class VersionExtended : Version
    {
        public byte Install { get; set; }
        public byte Technology { get; set; }
    }
}
