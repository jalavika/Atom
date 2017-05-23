using System;
using Atom.Core.Attributes.Class;

namespace Atom.Protocol.Types.Game.Look
{
    [Serializable]
    [NetworkType(405)]
    public class IndexedEntityLook
    {
        public EntityLook Look { get; set; }
        public byte Index { get; set; }
    }
}