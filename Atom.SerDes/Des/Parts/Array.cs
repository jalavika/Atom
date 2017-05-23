using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Atom.Core.Attributes.Property;
using Atom.Core.Helpers.Expressions;
using Atom.Core.Immutables;
using Atom.IO.Interfaces;
using Atom.SerDes.Interfaces;

namespace Atom.SerDes.Des.Parts
{
    internal class Array : IDeserializerPart
    {
        public bool Predicat(PropertyInfo property) => property.PropertyType.IsArray;

        public void OnMatch(List<ParameterExpression> variableExpressions, List<Expression> contentExpressions, 
            PropertyInfo propertyInfo, ParameterExpression paramClass, ParameterExpression paramReader)
        {
            var propType = propertyInfo.PropertyType;
            var elemType = propType.GetElementType();
            var typeLenAttr = propertyInfo.GetCustomAttribute<LengthTypeAttribute>();
            var customVarAttr = propertyInfo.GetCustomAttribute<CustomVarAttribute>();

            var typeLen = typeLenAttr == null ? typeof(short) : typeLenAttr.TypeLen;
            var isTypeLenCustom = typeLenAttr != null && typeLenAttr.IsCustomVar;
            var isContentCustom = customVarAttr != null;
            var isContentPrimitive = PrimitiveTypes.Primitives.Contains(elemType);

            var miLen = isTypeLenCustom ? 
                typeof(IReader).GetMethod("ReadCustom").MakeGenericMethod(typeLen) 
              : typeof(IReader).GetMethod("ReadValue").MakeGenericMethod(typeLen);

            var paramProp = Expression.Property(paramClass, propertyInfo);
            var paramLen = Expression.Variable(typeLen, "len");
            var i = Expression.Variable(typeof(int), "i");

            var callMiLen = Expression.Call(paramReader, miLen);
            var assignLen = Expression.Assign(paramLen, callMiLen);

            variableExpressions.Add(paramLen);
            variableExpressions.Add(i);
            contentExpressions.Add(assignLen);

            Expression finalExpression;
            if (!isContentPrimitive)
            {
                var dlg = typeof(Deserializer<>).MakeGenericType(elemType)
                    .GetProperty("DeserializeFunc");

                var content = Expression.Assign(
                    Expression.ArrayAccess(paramProp, i), 
                    Expression.Invoke(Expression.Property(null, dlg), paramReader));

                finalExpression = ExpressionHelpers.For(i,
                    Expression.Constant(0),
                    Expression.LessThan(i, Expression.Convert(paramLen, typeof(int))),
                    Expression.PostIncrementAssign(i),
                    content);
            }
            else
            {
                if (!isContentCustom)
                {
                    if (elemType == typeof(byte) || elemType == typeof(sbyte))
                    {
                        var mi = typeof(IReader).GetMethod("ReadArray").MakeGenericMethod(elemType);

                        finalExpression = Expression.Assign(paramProp, 
                            Expression.Call(paramReader, mi, Expression.Convert(paramLen, typeof(int))));
                    }
                    else
                    {
                        var mi = typeof(IReader).GetMethod("ReadValue").MakeGenericMethod(elemType);

                        var content = Expression.Assign(
                            Expression.ArrayAccess(paramProp, i),
                            Expression.Call(paramReader, mi));

                        finalExpression = ExpressionHelpers.For(i,
                            Expression.Constant(0),
                            Expression.LessThan(i, Expression.Convert(paramLen, typeof(int))),
                            Expression.PostIncrementAssign(i),
                            content);
                    }
                }
                else
                {
                    var mi = typeof(IReader).GetMethod("ReadCustom").MakeGenericMethod(elemType);

                    var content = Expression.Assign(
                        Expression.ArrayAccess(paramProp, i),
                        Expression.Call(paramReader, mi));

                    finalExpression = ExpressionHelpers.For(i,
                        Expression.Constant(0),
                        Expression.LessThan(i, Expression.Convert(paramLen, typeof(int))),
                        Expression.PostIncrementAssign(i),
                        content);
                }
            }

            contentExpressions.Add(finalExpression);
        }
    }
}
