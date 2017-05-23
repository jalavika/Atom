using System;
using Atom.Core.Attributes.Class;
using Atom.Core.Attributes.Property;

namespace Atom.Protocol.Types.Game.Character.Choice
{
    [Serializable]
    [NetworkType(45)]
    public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
    {
        public byte Breed { get; set; }

        [RegularBool]
        public bool Sex { get; set; }
    }
}
