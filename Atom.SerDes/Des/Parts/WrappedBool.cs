using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Property;
using Atom.IO.Interfaces;
using Atom.SerDes.Interfaces;

namespace Atom.SerDes.Des.Parts
{
    internal class WrappedBool : IDeserializerPart
    {
        public bool Predicat(PropertyInfo property) => property.PropertyType == typeof(bool)
                               && property.GetCustomAttribute<RegularBoolAttribute>() == null;

        public void OnMatch(List<ParameterExpression> variableExpressions, List<Expression> contentExpressions,
            PropertyInfo propertyInfo, ParameterExpression paramClass, ParameterExpression paramReader)
        {
            var mi = typeof(IReader).GetMethod("ReadWrappedBool").MakeGenericMethod(propertyInfo.PropertyType);

            var paramProp = Expression.Property(paramClass, propertyInfo);

            var callReader = propertyInfo.GetCustomAttribute<ForceNewByteAttribute>() != null 
                ? Expression.Call(paramReader, mi, Expression.Constant(0), Expression.Constant(true)) 
                : Expression.Call(paramReader, mi, Expression.Constant(0), Expression.Constant(false));

            var assignExp = Expression.Assign(paramProp, callReader);

            contentExpressions.Add(assignExp);
        }
    }
}
