using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Atom.Network.Sockets;

namespace Atom.Auth.Sockets
{
    public class AuthServer : AbstractServer<AuthClient>
    {
        public AuthServer() : base("Server", 443)
        { }
    }
}