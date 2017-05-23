using System;
using Atom.Auth.Sockets;
using Atom.Core.Attributes.Class;
using Atom.Protocol.Messages.Connection;
using Atom.Protocol.Types.Connection;

namespace Atom.Auth.Handlers.Connection
{
    public static class ConnectionHandler
    {
        [NetworkMessageHandler(typeof(IdentificationMessage))]
        public static async void OnIdentificationMessage(AuthClient client, IdentificationMessage message)
        {
            client.Write(
                $"received identification message with login = {message.Lang.Split('@')[0]}, password = {message.Lang.Split('@')[1]}");

            var ism = new IdentificationSucessMessage()
            {
                AccountCreation = 4841515,
                AccountId = 1,
                CommunityId = 1,
                HasRights = true,
                HavenbagAvailableRoom = 0,
                Login = "Nameless",
                Nickname = "[Nameless]",
                SecretQuestion = "DELETE?",
                SubscriptionElapsedDuration = 2546500,
                SubscriptionEndDate = 13700000,
                WasAlreadyConnected = false
            };

            var slm = new ServerListMessage()
            {
                CanCreateNewCharacter = true,
                Servers = new[]
                {
                    new GameServerInformations()
                    {
                        CharactersCount = 1,
                        CharactersSlots = 5,
                        Completion = 0,
                        Date = 6523448615,
                        IsSelectable = true,
                        ServerId = 1,
                        Status = 3,
                        Type = 0
                    }
                },
                AlreadyConnectedToServerId = 0
            };

            await client.Send(ism);
            await client.Send(slm);
        }

        [NetworkMessageHandler(typeof(ServerSelectionMessage))]
        public static void OnServerSelectionMessage(AuthClient client, ServerSelectionMessage message)
        {
            client.Write($"trying to connect to server id : {message.ServerId}");
        }
    }
}