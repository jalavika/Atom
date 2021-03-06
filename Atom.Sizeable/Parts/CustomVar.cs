﻿using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Property;
using Atom.Core.Immutables;
using Atom.Sizeable.Interfaces;
using Atom.Sizeable.Managers;

namespace Atom.Sizeable.Parts
{
    internal class CustomVar : ISizePart
    {
        public bool Predicat(PropertyInfo property) => CustomTypes.Customs.Contains(property.PropertyType)
                                                       && property.GetCustomAttribute<CustomVarAttribute>() != null;

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
