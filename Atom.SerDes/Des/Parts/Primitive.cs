using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Property;
using Atom.Core.Immutables;
using Atom.IO.Interfaces;
using Atom.SerDes.Interfaces;

namespace Atom.SerDes.Des.Parts
{
    internal class Primitive : IDeserializerPart
    {
        public bool Predicat(PropertyInfo property) => PrimitiveTypes.Primitives.Contains(property.PropertyType)
                                                       && property.GetCustomAttribute<CustomVarAttribute>() == null;

        public void OnMatch(List<ParameterExpression> variableExpressions, List<Expression> contentExpressions, 
            PropertyInfo propertyInfo, ParameterExpression paramClass, ParameterExpression paramReader)
        {
            var mi = typeof(IReader).GetMethod("ReadValue").MakeGenericMethod(propertyInfo.PropertyType);

            var paramProp = Expression.Property(paramClass, propertyInfo);
            var callReader = Expression.Call(paramReader, mi);

            var assignExp = Expression.Assign(paramProp, callReader);

            contentExpressions.Add(assignExp);
        }
    }
}
