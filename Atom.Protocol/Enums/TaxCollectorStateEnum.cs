using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum TaxCollectorStateEnum
    {
        StateCollecting = 0,
        StateWaitingForHelp = 1,
        StateFighting = 2
    }
}
