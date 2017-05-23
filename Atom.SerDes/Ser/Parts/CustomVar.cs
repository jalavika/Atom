using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Property;
using Atom.Core.Immutables;
using Atom.IO.Interfaces;
using Atom.SerDes.Interfaces;

namespace Atom.SerDes.Ser.Parts
{
    internal class CustomVar : ISerializerPart
    {
        public bool Predicat(PropertyInfo property) => PrimitiveTypes.Primitives.Contains(property.PropertyType)
                                                       && property.GetCustomAttribute<CustomVarAttribute>() != null;

        public void OnMatch(List<Expression> contentExpressions, PropertyInfo propertyInfo, ParameterExpression paramT,
            ParameterExpression paramWriter)
        {
            var paramProp = Expression.Property(paramT, propertyInfo);

            var mi = typeof(IWriter).GetMethod("WriteCustom").MakeGenericMethod(propertyInfo.PropertyType);
            var callWriter = Expression.Call(paramWriter, mi, paramProp);

            contentExpressions.Add(callWriter);
        }
    }
}
