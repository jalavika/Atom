using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Class;
using Atom.Core.Extensions;
using Atom.Core.Immutables;
using Atom.SerDes.Interfaces;

namespace Atom.SerDes.Des.Parts
{
    internal class NetworkType : IDeserializerPart
    {
        public bool Predicat(PropertyInfo property) => !PrimitiveTypes.Primitives.Contains(property.PropertyType) 
            && property.PropertyType.GetTypeInfo().HasCustomAttribute<NetworkTypeAttribute>();

        public void OnMatch(List<ParameterExpression> variableExpressions, List<Expression> contentExpressions,
            PropertyInfo propertyInfo, ParameterExpression paramClass, ParameterExpression paramReader)
        {
            var dlg = typeof(Deserializer<>).MakeGenericType(propertyInfo.PropertyType).GetProperty("DeserializeFunc");

            var paramProp = Expression.Property(paramClass, propertyInfo);
            var invokeDlg = Expression.Invoke(Expression.Property(null, dlg), paramReader);

            var assignExp = Expression.Assign(paramProp, invokeDlg);

            contentExpressions.Add(assignExp);
        }
    }
}
