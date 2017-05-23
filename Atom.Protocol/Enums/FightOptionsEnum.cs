using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum FightOptionsEnum
    {
        FightOptionSetSecret = 0,
        FightOptionSetToPartyOnly = 1,
        FightOptionSetClosed = 2,
        FightOptionAskForHelp = 3
    }
}
