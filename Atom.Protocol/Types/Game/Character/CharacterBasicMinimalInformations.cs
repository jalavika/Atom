using System;
using Atom.Core.Attributes.Class;
using Atom.Core.Attributes.Property;

namespace Atom.Protocol.Types.Game.Character
{
    [Serializable]
    [NetworkType(503)]
    public class CharacterBasicMinimalInformations
    {
        [CustomVar]
        public long CharacterId { get; set; }
        public string CharacterName { get; set; }
    }
}