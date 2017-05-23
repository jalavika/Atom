using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum PlayerLifeStatusEnum
    {
        StatusAliveAndKicking = 0,
        StatusTombstone = 1,
        StatusPhantom = 2
    }
}
