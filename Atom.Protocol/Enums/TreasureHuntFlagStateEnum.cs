using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum TreasureHuntFlagStateEnum
    {
        TreasureHuntFlagStateUnknown = 0,
        TreasureHuntFlagStateOk = 1,
        TreasureHuntFlagStateWrong = 2
    }
}
