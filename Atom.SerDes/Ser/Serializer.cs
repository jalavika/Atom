﻿using System;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Class;
using Atom.Core.Extensions;
using Atom.IO.Interfaces;

namespace Atom.SerDes.Ser
{
    internal static class Serializer<T>
    {
        public static Action<T, IWriter> SerializeAction{ get; }

        static Serializer()
        {
            SerializerPartsManager.Init();

            var t = typeof(T);
            var tInfo = t.GetTypeInfo();

            var className = t.Name.ToLower();

            if (!tInfo.HasCustomAttribute<NetworkMessageAttribute>()
             && !tInfo.HasCustomAttribute<NetworkTypeAttribute>())
                throw new ArgumentException(nameof(t));

            var paramT = Expression.Parameter(typeof(T), className);
            var paramWriter = Expression.Parameter(typeof(IWriter), "writer");

            SerializeAction = tInfo.HasCustomAttribute<NetworkMessageAttribute>() 
                ? SerializerFunctionGenerator<T>.MakeMessageSerializerExpression(paramT, paramWriter).Compile() 
                : SerializerFunctionGenerator<T>.MakeTypeSerializerExpression(paramT, paramWriter).Compile();
        }

        internal static void GenerateExpression()
        { }
    }
}
