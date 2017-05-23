using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum CraftResultEnum
    {
        CraftImpossible = 0,
        CraftFailed = 1,
        CraftSuccess = 2,
        CraftNeutral = 3
    }
}
