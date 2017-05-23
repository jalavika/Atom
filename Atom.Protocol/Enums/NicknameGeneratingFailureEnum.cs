using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum NicknameGeneratingFailureEnum
    {
        NicknameGeneratorRetryTooShort = 1,
        NicknameGeneratorUnavailable = 2
    }
}
