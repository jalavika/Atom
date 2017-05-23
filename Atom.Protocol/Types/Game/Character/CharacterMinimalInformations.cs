using System;
using Atom.Core.Attributes.Class;

namespace Atom.Protocol.Types.Game.Character
{
    [Serializable]
    [NetworkType(110)]
    public class CharacterMinimalInformations : CharacterBasicMinimalInformations
    {
        public byte Level { get; set; }
    }
}