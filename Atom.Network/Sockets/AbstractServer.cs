using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Atom.Network.Interfaces;
using Atom.Network.Managers;

namespace Atom.Network.Sockets
{
    public abstract class AbstractServer<TC> : IServer
        where TC : AbstractClient, new()
    {
        private readonly CancellationToken _acceptLoopToken;

        public ConcurrentBag<AbstractClient> Clients { get; }
        public Socket Server { get; }
        public IPEndPoint ServerAdress { get; }
        public string Name { get; }

        protected AbstractServer(string name, int port)
        {
            Clients = new ConcurrentBag<AbstractClient>();
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Name = name;
            ServerAdress = new IPEndPoint(IPAddress.Loopback, port);
            _acceptLoopToken = new CancellationToken();

            MessageManager<TC>.Init();
            Server.Bind(ServerAdress);
            Server.Listen(5);

            Write("Server successfuly started");
            AcceptLoop();
        }

        public void Write(string message) => Console.WriteLine($"<{Name}:{ServerAdress}> {message}");

        public async void AcceptLoop()
        {
            var tf = new TaskFactory(_acceptLoopToken, 
                TaskCreationOptions.LongRunning, 
                TaskContinuationOptions.ExecuteSynchronously, 
                TaskScheduler.Current);

            await tf.StartNew(async () =>
            {
                try
                {
                    for (;;)
                    {
                        var socketClient = 
                            await Server.AcceptAsync().ConfigureAwait(false);

                        var client = new TC()
                        {
                            ClientSocket = socketClient,
                            Server = this
                        };

                        client.OnCreate();
                        await client.LaunchReceiveLoop();

                        Clients.Add(client);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }, _acceptLoopToken);
        }
    }
}