using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Class;
using Atom.Core.Extensions;
using Atom.IO.Interfaces;
using Atom.IO.Writer;
using Atom.SerDes.Des;
using Atom.SerDes.Ser;
using Atom.Sizeable.Managers;

namespace Atom.SerDes.Managers
{
    public static class SerDesManager
    {
        private static readonly Action ExpressionGenerator;

        static SerDesManager()
        {
            var types =
                Assembly.Load(new AssemblyName("Atom.Protocol"))
                    .GetTypes()
                    .Where(m => m.GetTypeInfo().HasCustomAttribute<NetworkMessageAttribute>() 
                             || m.GetTypeInfo().HasCustomAttribute<NetworkTypeAttribute>());

            var serExpressions = types.Select(t =>
            {
                var genSerializerMi = typeof(Serializer<>).MakeGenericType(t)
                    .GetMethod("GenerateExpression", BindingFlags.NonPublic | BindingFlags.Static);

                return  Expression.Call(genSerializerMi);
            });

            var desExpressions = types.Select(t =>
            {
                var genDeserializerMi = typeof(Deserializer<>).MakeGenericType(t)
                    .GetMethod("GenerateExpression", BindingFlags.NonPublic | BindingFlags.Static);

                return Expression.Call(genDeserializerMi);
            });

            Console.WriteLine($"<SerDes> {desExpressions.Count() + serExpressions.Count()} expressions generated");

            var block = Expression.Block(Expression.Block(desExpressions), Expression.Block(serExpressions));

            var lambda = Expression.Lambda<Action>(block);

            ExpressionGenerator = lambda.Compile();
        }

        public static void Serialize<T>(T message, IWriter writer)
            => Serializer<T>.SerializeAction(message, writer);

        public static byte[] Serialize<T>(T message)
        {
            var sizeOfMessage = SizeMapperManager.SizeOfMessage(message, true);
            var fbw = new FastBinaryWriter(sizeOfMessage);

            fbw.CreateContext(
                ctx => Serialize<T>(message, ctx));

            return fbw.Buffer;
        }

        public static byte[] Serialize<T>(IEnumerable<T> messages)
        {
            var sizeOfMessage = SizeMapperManager.SizeOfMessage(messages, true);
            var fbw = new FastBinaryWriter(sizeOfMessage);

            fbw.CreateContext(
                ctx =>
                {
                    foreach (var message in messages)
                    {
                        Serialize(message, ctx);
                    }
                });

            return fbw.Buffer;
        }

        public static T Deserialize<T>(IReader reader)
            => Deserializer<T>.DeserializeFunc(reader);

        public static void GenerateExpressions() => ExpressionGenerator();

    }
}
