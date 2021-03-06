﻿using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Atom.SerDes.Interfaces;

namespace Atom.SerDes.Ser
{
    internal class SerializerPartsManager
    {
        internal static ImmutableList<ISerializerPart> Parts { get; }

        static SerializerPartsManager()
        {
            var ass = typeof(ISerializerPart).GetTypeInfo().Assembly;

            var types =
                ass.GetTypes()
                    .Where(
                        type => type.GetTypeInfo().IsClass && !type.GetTypeInfo().IsAbstract && type.GetInterfaces().Contains(typeof(ISerializerPart)));

            Parts = types.Select(type => (ISerializerPart)Activator.CreateInstance(type)).ToImmutableList();
        }

        public static void Init()
        { }
    }
}
