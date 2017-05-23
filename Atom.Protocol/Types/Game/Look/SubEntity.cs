using System;
using Atom.Core.Attributes.Class;

namespace Atom.Protocol.Types.Game.Look
{
    [Serializable]
    [NetworkType(54)]
    public class SubEntity
    {
        public byte BindingPointCategory { get; set; }
        public byte BindingPointIndex { get; set; }
        public EntityLook SubEntityLook { get; set; }
    }
}