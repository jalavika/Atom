using System;

namespace Atom.Core.Attributes.Class
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NetworkMessageHandlerAttribute : Attribute
    {
        public Type NetworkMessageType { get; }

        public NetworkMessageHandlerAttribute(Type networkMessageType)
        {
            NetworkMessageType = networkMessageType;
        }
    }
}
