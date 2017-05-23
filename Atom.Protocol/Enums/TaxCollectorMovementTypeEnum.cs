using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum TaxCollectorMovementTypeEnum
    {
        TaxCollectorUnknownAction = 0,
        TaxCollectorHired = 1,
        TaxCollectorHarvested = 2,
        TaxCollectorDefeated = 3,
        TaxCollectorDestroyed = 4
    }
}
