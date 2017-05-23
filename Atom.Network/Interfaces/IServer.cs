using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using Atom.Network.Sockets;

namespace Atom.Network.Interfaces
{
    public interface IServer
    {
        ConcurrentBag<AbstractClient> Clients { get; }
        Socket Server { get; }
        IPEndPoint ServerAdress { get; }
        string Name { get; }

        void Write(string message);
    }
}