using System;
using Atom.IO.Interfaces;
using Atom.IO.Reader;
using Atom.Network.Managers;
using Atom.Network.Sockets;
using Atom.Protocol.Messages.Connection;
using Atom.Protocol.Messages.Handshake;

namespace Atom.Auth.Sockets
{
    public class AuthClient : AbstractClient
    {
        public override async void OnCreate()
        {
            base.OnCreate();

            var pr = new ProtocolRequired() { CurrentVersion = 1759, RequiredVersion = 1759 };
            var hcm = new HelloConnectMessage() { Salt = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Key = new byte[1] };

            await Send(pr);
            await Send(hcm);
        }

        public override void OnReceive(ArraySegment<byte> buffer, int length)
        {
            base.OnReceive(buffer, length);

            var fbr = new FastBinaryReader(buffer.Array, length);

            while (MessageParser.TryParse(fbr, out int messageId, out int dataLength, out byte[] data))
            {
                Write($"Received message with id = {messageId}, dataLength = {dataLength}, realLength = {data.Length}");
                MessageManager<AuthClient>.Process(this, new FastBinaryReader(data), messageId);
            }
        }
    }
}