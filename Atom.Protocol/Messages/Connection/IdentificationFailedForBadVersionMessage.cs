using System;
using Atom.Core.Attributes.Class;
using Atom.Core.Enums;

namespace Atom.Protocol.Messages.Connection
{
    [NetworkMessage(21, Origin.Server)]
    public class IdentificationFailedForBadVersionMessage : IdentificationFailedMessage
    {
        public Version RequiredVersion { get; set; }
    }
}