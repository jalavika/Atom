using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum PresetDeleteResultEnum
    {
        PresetDelOk = 1,
        PresetDelErrUnknown = 2,
        PresetDelErrBadPresetId = 3
    }
}
