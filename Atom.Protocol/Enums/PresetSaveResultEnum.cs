using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum PresetSaveResultEnum
    {
        PresetSaveOk = 1,
        PresetSaveErrUnknown = 2,
        PresetSaveErrTooMany = 3
    }
}
