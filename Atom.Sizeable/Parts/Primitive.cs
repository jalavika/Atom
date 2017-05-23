using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Property;
using Atom.Core.Immutables;
using Atom.Sizeable.Interfaces;
using Atom.Sizeable.Managers;

namespace Atom.Sizeable.Parts
{
    internal class Primitive : ISizePart
    {
        public bool Predicat(PropertyInfo property) => PrimitiveTypes.Primitives.Contains(property.PropertyType)
                                                       && property.GetCustomAttribute<CustomVarAttribute>() == null;

        public void OnMatch(List<Expression> expressions, PropertyInfo propertyInfo, 
            ParameterExpression paramClass)
        {
            var mi = typeof(SizeMapperManager).GetMethods().First(x => !x.GetParameters().Any()).MakeGenericMethod(propertyInfo.PropertyType);
            var sizeValue = Expression.Call(mi);

            expressions.Add(sizeValue);
        }
    }
}
