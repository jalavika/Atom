using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum PartStateEnum
    {
        PartNotInstalled = 0,
        PartBeingUpdater = 1,
        PartUpToDate = 2
    }
}
