using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum HavenBagDailyLoteryErrorEnum
    {
        HavenbagDailyLoteryOk = 0,
        HavenbagDailyLoteryAlreadyused = 1,
        HavenbagDailyLoteryError = 2
    }
}
