using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum ListAddFailureEnum
    {
        ListAddFailureUnknown = 0,
        ListAddFailureOverQuota = 1,
        ListAddFailureNotFound = 2,
        ListAddFailureEgocentric = 3,
        ListAddFailureIsDouble = 4
    }
}
