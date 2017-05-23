using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Class;
using Atom.Core.Extensions;
using Atom.Core.Immutables;
using Atom.SerDes.Interfaces;

namespace Atom.SerDes.Ser.Parts
{
    internal class NetworkType : ISerializerPart
    {
        public bool Predicat(PropertyInfo property) => !PrimitiveTypes.Primitives.Contains(property.PropertyType)
            && property.PropertyType.GetTypeInfo().HasCustomAttribute<NetworkTypeAttribute>();

        public void OnMatch(List<Expression> contentExpressions, PropertyInfo propertyInfo, ParameterExpression paramT,
            ParameterExpression paramWriter)
        {
            var dlg = typeof(Serializer<>).MakeGenericType(propertyInfo.PropertyType).GetProperty("SerializeAction");

            var paramProp = Expression.Property(paramT, propertyInfo);
            var invokeDlg = Expression.Invoke(Expression.Property(null, dlg), paramProp, paramWriter);

            contentExpressions.Add(invokeDlg);
        }
    }
}
