using System;
using Atom.Core.Attributes.Class;
using Atom.Protocol.Types.Game.Look;

namespace Atom.Protocol.Types.Game.Character
{
    [Serializable]
    [NetworkType(163)]
    public class CharacterMinimalPlusLookInformations : CharacterMinimalInformations
    {
        public EntityLook Look { get; set; }
    }
}
