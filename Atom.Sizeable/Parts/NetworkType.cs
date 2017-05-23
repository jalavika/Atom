using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Class;
using Atom.Core.Extensions;
using Atom.Core.Immutables;
using Atom.Sizeable.Interfaces;
using Atom.Sizeable.Managers;

namespace Atom.Sizeable.Parts
{
    internal class NetworkType : ISizePart
    {
        public bool Predicat(PropertyInfo property) => !PrimitiveTypes.Primitives.Contains(property.PropertyType)
                                               && property.PropertyType.GetTypeInfo().HasCustomAttribute<NetworkTypeAttribute>();

        public void OnMatch(List<Expression> expressions, PropertyInfo propertyInfo,
            ParameterExpression paramClass)
        {
            var paramProp = Expression.Property(paramClass, propertyInfo);

            var mi = typeof(SizeMapperManager).GetMethods()
                .First(x => x.GetParameters().Any() && x.Name == "SizeOf")
                .MakeGenericMethod(propertyInfo.PropertyType);

            Expression sizeValue = Expression.Call(mi, paramProp);

            expressions.Add(sizeValue);

        }
    }
}
