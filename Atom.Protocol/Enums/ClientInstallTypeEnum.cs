using System;

namespace Atom.Protocol.Enums
{
    [Flags]
    public enum ClientInstallTypeEnum
    {
        ClientInstallUnknown = 0,
        ClientBundle = 1,
        ClientStreaming = 2
    }
}
