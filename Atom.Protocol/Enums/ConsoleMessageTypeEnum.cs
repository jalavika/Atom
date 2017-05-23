using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum ConsoleMessageTypeEnum
    {
        ConsoleTextMessage = 0,
        ConsoleInfoMessage = 1,
        ConsoleErrMessage = 2
    }
}
