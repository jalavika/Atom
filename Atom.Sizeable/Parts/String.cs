using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Sizeable.Interfaces;
using Atom.Sizeable.Managers;

namespace Atom.Sizeable.Parts
{
    internal class String : ISizePart
    {
        public bool Predicat(PropertyInfo property) => property.PropertyType == typeof(string);

        public void OnMatch(List<Expression> expressions, PropertyInfo propertyInfo,
            ParameterExpression paramClass)
        {
            var paramProp = Expression.Property(paramClass, propertyInfo);

            var mi = typeof(SizeMapperManager).GetMethods().First(x => x.GetParameters().Any() && x.Name == "SizeOf").MakeGenericMethod(propertyInfo.PropertyType);
            var sizeValue = Expression.Call(mi, paramProp);

            expressions.Add(sizeValue);
        }
    }
}
