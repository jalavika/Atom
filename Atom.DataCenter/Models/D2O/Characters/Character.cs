using System;
using Atom.Protocol.Types.Game.Character;
using Atom.Protocol.Types.Game.Character.Choice;
using Atom.Protocol.Types.Game.Look;

namespace Atom.DataCenter.Models.D2O.Characters
{
    [Serializable]
    public class Character
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public byte Level { get; set; }
        public EntityLook Look { get; set; }
        public byte Breed { get; set; }
        public bool Sex { get; set; }

        public CharacterBaseInformations ToCharacterBaseInformations()
            => new CharacterBaseInformations()
            {
                CharacterId = Id,
                CharacterName = Name,
                Level = Level,
                Look = Look,
                Breed = Breed,
                Sex = Sex
            };

        public CharacterMinimalPlusLookInformations ToCharacterMinimalPlusLookInformations()
            => new CharacterMinimalPlusLookInformations()
            {
                CharacterId = Id,
                CharacterName = Name,
                Level = Level,
                Look = Look
            };

        public CharacterMinimalInformations ToCharacterMinimalInformations()
            => new CharacterMinimalInformations()
            {
                CharacterId = Id,
                CharacterName = Name,
                Level = Level
            };

        public CharacterBasicMinimalInformations ToCharacterBasicMinimalInformations()
            => new CharacterBasicMinimalInformations()
            {
                CharacterId = Id,
                CharacterName = Name
            };

    }
}