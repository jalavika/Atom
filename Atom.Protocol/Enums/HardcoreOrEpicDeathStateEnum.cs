using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum HardcoreOrEpicDeathStateEnum
    {
        DeathStateAlive = 0,
        DeathStateDead = 1,
        DeathStateWaitingConfirmation = 2
    }
}
