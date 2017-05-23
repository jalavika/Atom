using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum FightSpellCastCriticalEnum
    {
        Normal = 1,
        CriticalHit = 2,
        CriticalFail = 3
    }
}
