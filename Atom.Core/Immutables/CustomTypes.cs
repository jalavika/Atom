using System;
using System.Collections.Immutable;

namespace Atom.Core.Immutables
{
    public static class CustomTypes
    {
        public static ImmutableList<Type> Customs = ImmutableList
            .Create(typeof(short), typeof(int), typeof(long));
    }
}
