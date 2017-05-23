using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum FightOutcomeEnum
    {
        ResultLost = 0,
        ResultDraw = 1,
        ResultVictory = 2,
        ResultTax = 5,
        ResultDefenderGroup = 6
    }
}
