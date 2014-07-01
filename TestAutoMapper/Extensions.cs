using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using AutoMapper;
using Mono.Reflection;

namespace TestAutoMapper
{
    static class Extensions
    {
        public static void DecompileMap<T, TR>(this IMemberConfigurationExpression<T> configurationExpression,
            Expression<Func<T, TR>> expression)
        {
            var body = expression.Body;

            var memberExpression = body as MemberExpression;
            if (memberExpression != null)
            {
                var propertyInfo = (PropertyInfo)memberExpression.Member;
                if (!propertyInfo.CanWrite)
                {
                    var method = propertyInfo.GetMethod;
                    var instructions = method.GetInstructions();
                    var parameters = method.GetParameters();
                    var args = new[] { Expression.Parameter(method.DeclaringType, "this") }
                    .Union(parameters.Select(p => Expression.Parameter(p.ParameterType, p.Name)))
                    .ToList();

                    var expressions = new Stack<Expression>();
                    foreach (var instruction in instructions)
                    {
                        if (instruction.OpCode == OpCodes.Nop)
                        {
                            
                        }
                        else if (instruction.OpCode == OpCodes.Ldarg_0)
                        {
                            expressions.Push();
                        }
                    }
                }
            }


            /*var parameterExpression = Expression.Parameter(typeof(T));
            var lambda = Expression.Lambda<Func<T, TR>>(parameterExpression, parameterExpression);
            configurationExpression.MapFrom(lambda);*/
            configurationExpression.MapFrom(expression);
        }
    }
}