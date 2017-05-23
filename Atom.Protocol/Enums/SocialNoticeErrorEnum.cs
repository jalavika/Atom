using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum SocialNoticeErrorEnum
    {
        SocialNoticeUnknownError = 0,
        SocialNoticeInvalidRights = 1,
        SocialNoticeCooldown = 2
    }
}
