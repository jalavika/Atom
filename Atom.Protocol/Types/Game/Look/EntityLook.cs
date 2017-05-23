using System;
using Atom.Core.Attributes.Class;
using Atom.Core.Attributes.Property;

namespace Atom.Protocol.Types.Game.Look
{
    [Serializable]
    [NetworkType(55)]
    public class EntityLook
    {
        [CustomVar]
        public short BonesId { get; set; }

        [CustomVar]
        [LengthType(typeof(short))]
        public short[] Skins { get; set; }

        [LengthType(typeof(short))]
        public int[] IndexedColors { get; set; }

        [CustomVar]
        [LengthType(typeof(short))]
        public short[] Scales { get; set; }

        [LengthType(typeof(short))]
        public SubEntity[] SubEntities { get; set; }
    }
}