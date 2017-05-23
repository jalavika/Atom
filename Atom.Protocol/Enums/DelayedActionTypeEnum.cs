using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum DelayedActionTypeEnum
    {
        DelayedActionDisconnect = 0,
        DelayedActionObjectUse = 1,
        DelayedActionJoinCharacter = 2,
        DelayedActionAggressionImmune = 3
    }
}
