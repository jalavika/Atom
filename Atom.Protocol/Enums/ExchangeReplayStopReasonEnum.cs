using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum ExchangeReplayStopReasonEnum
    {
        StoppedReasonOk = 1,
        StoppedReasonUser = 2,
        StoppedReasonMissingRessource = 3,
        StoppedReasonImpossibleModification = 4
    }
}
