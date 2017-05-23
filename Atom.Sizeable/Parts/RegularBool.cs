using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Property;
using Atom.Sizeable.Interfaces;
using Atom.Sizeable.Managers;

namespace Atom.Sizeable.Parts
{
    internal class RegularBool : ISizePart
    {
        public bool Predicat(PropertyInfo property) => property.PropertyType == typeof(bool)
                                               && property.GetCustomAttribute<RegularBoolAttribute>() != null;

        public void OnMatch(List<Expression> expressions, PropertyInfo propertyInfo,
            ParameterExpression paramClass)
        {
            var mi = typeof(SizeMapperManager).GetMethods().First(x => !x.GetParameters().Any() && x.Name == "SizeOf").MakeGenericMethod(propertyInfo.PropertyType);
            var sizeValue = Expression.Call(mi);

            expressions.Add(sizeValue);
        }
    }
}
