using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum PresetSaveUpdateErrorEnum
    {
        PresetUpdateErrUnknown = 1,
        PresetUpdateErrBadPresetId = 2,
        PresetUpdateErrBadPosition = 3,
        PresetUpdateErrBadObjectId = 4
    }
}
