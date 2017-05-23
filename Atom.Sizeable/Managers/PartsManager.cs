using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Atom.Sizeable.Interfaces;

namespace Atom.Sizeable.Managers
{
    internal static class PartsManager
    {
        internal static ImmutableList<ISizePart> Parts { get; }

        static PartsManager()
        {
            var ass = typeof(ISizePart).GetTypeInfo().Assembly;

            var types =
                ass.GetTypes()
                    .Where(
                        type => type.GetTypeInfo().IsClass && !type.GetTypeInfo().IsAbstract && type.GetInterfaces().Contains(typeof(ISizePart)));

            Parts = types.Select(type => (ISizePart)Activator.CreateInstance(type)).ToImmutableList();
        }

        public static void Init()
        { }
    }
}
