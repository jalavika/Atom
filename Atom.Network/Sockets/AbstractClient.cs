using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Atom.Network.Interfaces;
using Atom.SerDes.Managers;

namespace Atom.Network.Sockets
{
    public abstract class AbstractClient
    {
        public IServer Server { get; internal set; }
        public Socket ClientSocket { get; internal set; }
        public EndPoint ClientIp => ClientSocket.LocalEndPoint;

        private readonly CancellationToken _receiveLoopToken;
        private readonly string _name;

        protected AbstractClient()
        {
            _receiveLoopToken = new CancellationToken();
            _name = GetType().Name;
        }

        public void Write(string message) => Console.WriteLine($"<{_name}:{ClientIp}> {message}");

        public virtual void OnCreate() => Write("Client created");
        public virtual void OnReceive(ArraySegment<byte> buffer, int length) => Write($"Received {length} bytes");

        public async Task LaunchReceiveLoop() => await Task.Run(
            async () =>
            {
                try
                {
                    for (;;)
                    {
                        var segment = new ArraySegment<byte>(new byte[4096]);

                        var length =
                            await ClientSocket.ReceiveAsync(segment, SocketFlags.None);

                        if (length < 1)
                            ClientSocket.Dispose();

                        OnReceive(segment, length);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }, _receiveLoopToken);

        public async Task Send<T>(T message)
        {
            try
            {
                var buffer = SerDesManager.Serialize(message);

                await ClientSocket.SendAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                Write($"{message.GetType().Name} sent");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task SendMultiple(object[] messages)
        {
            if(!messages.Any())
                throw new ArgumentNullException();

            await ClientSocket.SendAsync(new ArraySegment<byte>(SerDesManager.Serialize(messages)), SocketFlags.None);

            foreach(var message in messages)
                Write($"{message} sended");
        }
    }
}