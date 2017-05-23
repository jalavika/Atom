using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Atom.Core.Attributes.Class;
using Atom.Core.Enums;
using Atom.Core.Extensions;
using Atom.IO.Interfaces;
using Atom.IO.Writer;
using Atom.Network.Sockets;
using Atom.SerDes.Managers;

// ReSharper disable InconsistentNaming

namespace Atom.Network.Managers
{
    public static class MessageManager<TC>
        where TC : AbstractClient, new()
    {
        private static readonly Dictionary<int, Action<TC, IReader>> Processors;

        static MessageManager()
        {
            var messages =
                Assembly.Load(new AssemblyName("Atom.Protocol"))
                    .GetTypes()
                    .Where(m => m.GetTypeInfo().HasCustomAttribute<NetworkMessageAttribute>())
                    .ToImmutableList();

            var messagesAttr =
                messages.Select(m => m.GetTypeInfo().GetCustomAttribute<NetworkMessageAttribute>())
                    .ToImmutableList();

            Processors = new Dictionary<int, Action<TC, IReader>>(
                messages.Count(m => 
                    m.GetTypeInfo().GetCustomAttribute<NetworkMessageAttribute>().Origin != Origin.Server));


            for (var i = 0; i < messages.Count; i++)
            {
                var message = messages[i];
                var messageAttr = messagesAttr[i];

                if (messageAttr.Origin == Origin.Server)
                    continue;

                var handler =
                (from t in Assembly.GetEntryAssembly().GetTypes()
                    from m in t.GetTypeInfo().GetMethods()
                    where m.GetCustomAttribute<NetworkMessageHandlerAttribute>() != null
                       && m.GetCustomAttribute<NetworkMessageHandlerAttribute>().NetworkMessageType == message
                    select m).FirstOrDefault();

                var paramTC = Expression.Parameter(typeof(TC), "paramTC");
                var paramReader = Expression.Parameter(typeof(IReader), "paramReader");
                var paramMessage = Expression.Variable(message, message.Name);

                var deserializeMi = typeof(SerDesManager)
                    .GetMethod("Deserialize")
                    .MakeGenericMethod(message);

                var deserializeCall = Expression.Call(deserializeMi, paramReader);
                var handlerCall = Expression.Call(handler, paramTC, paramMessage);

                var messageAssign = Expression.Assign(paramMessage, deserializeCall);

                var block = Expression.Block(new[] { paramMessage }, messageAssign, handlerCall);

                var lambda = Expression.Lambda<Action<TC, IReader>>(block, paramTC, paramReader);

                Processors.Add(messageAttr.Id, lambda.Compile());
            }
        }

        public static void Process(TC client, IReader reader, int messageId)
        {
            if (!Processors.TryGetValue(messageId, out Action<TC, IReader> processor))
                throw new ArgumentNullException(nameof(processor));

            processor(client, reader);
        }

        public static void Init()
        {
        }
    }
}