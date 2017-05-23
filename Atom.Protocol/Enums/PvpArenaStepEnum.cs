using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum PvpArenaStepEnum
    {
        ArenaStepRegistred = 0,
        ArenaStepWaitingFight = 1,
        ArenaStepStartingFight = 2,
        ArenaStepUnregister = 3
    }
}
