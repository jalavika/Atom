using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum GameActionMarkTypeEnum
    {
        Glyph = 1,
        Trap = 2,
        Wall = 3,
        Portal = 4,
        Rune = 5
    }
}
