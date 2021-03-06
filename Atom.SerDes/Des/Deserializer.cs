﻿using System;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Class;
using Atom.Core.Extensions;
using Atom.IO.Interfaces;

namespace Atom.SerDes.Des
{
    internal static class Deserializer<T>
    {
        public static Func<IReader, T> DeserializeFunc { get; }

        static Deserializer()
        {
            DeserializerPartsManager.Init();

            var t = typeof(T);
            var tInfo = t.GetTypeInfo();

            var className = t.Name.ToLower();

            if (!tInfo.HasCustomAttribute<NetworkMessageAttribute>()
                && !tInfo.HasCustomAttribute<NetworkTypeAttribute>())
            {
                throw new ArgumentException(nameof(t));
            }

            var paramReader = Expression.Parameter(typeof(IReader), "reader");

            DeserializeFunc = DeserializerFunctionGenerator<T>.MakeDeserializerExpression(paramReader, className).Compile();
        }

        internal static void GenerateExpression()
        { }
    }
}
