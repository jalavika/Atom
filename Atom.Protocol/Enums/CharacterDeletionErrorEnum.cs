using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum CharacterDeletionErrorEnum
    {
        DelErrNoReason = 1,
        DelErrTooManyCharDeletion = 2,
        DelErrBadSecretAnswer = 3,
        DelErrRestricedZone = 4
    }
}
