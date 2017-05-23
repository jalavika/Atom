using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum PartyNameErrorEnum
    {
        PartyNameUndefinedError = 0,
        PartyNameInvalid = 1,
        PartyNameAlreadyUsed = 2,
        PartyNameUnallowedRights = 3,
        PartyNameUnallowedNow = 4
    }
}
