using Atom.Core.Attributes.Class;

namespace Atom.Protocol.Types.Version
{
    [NetworkType(11)]
    public class Version
    {
        public byte Major { get; set; }
        public byte Minor { get; set; }
        public byte Release { get; set; }
        public int Revision { get; set; }
        public byte Patch { get; set; }
        public byte BuildType { get; set; }
    }
}
