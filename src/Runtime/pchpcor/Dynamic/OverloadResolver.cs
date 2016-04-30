﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pchp.Core.Dynamic
{
    /// <summary>
    /// Methods for selecting best method overload from possible candidates.
    /// </summary>
    internal static class OverloadResolver
    {
        /// <summary>
        /// Selects all method candidates.
        /// </summary>
        public static IEnumerable<MethodBase> SelectCandidates(this Type type)
        {
            return type.GetRuntimeMethods();
        }

        /// <summary>
        /// Selects only candidates of given name.
        /// </summary>
        public static IEnumerable<MethodBase> SelectByName(this IEnumerable<MethodBase> candidates, string name)
        {
            return candidates.Where(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Selects only candidates visible from the current class context.
        /// </summary>
        public static IEnumerable<MethodBase> SelectVisible(this IEnumerable<MethodBase> candidates, Type classCtx)
        {
            var result = new List<MethodBase>();
            var classCtx_type = classCtx?.GetTypeInfo();

            //
            foreach (var m in candidates)
            {
                if (m.IsPrivate && classCtx != null && m.DeclaringType != classCtx)
                {
                    continue;
                }

                if (m.IsFamily && classCtx_type != null)
                {
                    var m_type = m.DeclaringType.GetTypeInfo();
                    if (!classCtx_type.IsAssignableFrom(m_type) && !m_type.IsAssignableFrom(classCtx_type))
                    {
                        continue;
                    }
                }

                //
                result.Add(m);
            }

            //
            return result;
        }

        /// <summary>
        /// Selects only static methods.
        /// </summary>
        public static IEnumerable<MethodBase> SelectStatic(this IEnumerable<MethodBase> candidates)
        {
            return candidates.Where(m => m.IsStatic);
        }

        /// <summary>
        /// Tries to bind arguments to method parameters.
        /// </summary>
        static IList<Expression> TryBindArguments(MethodBase m, Expression[] arguments)
        {
            //int n = 0;
            //var ps = m.GetParameters();

            //foreach (var p in ps)
            //{
            //    if (n == 0)
            //    {
            //        if (p.ParameterType == typeof(Context)) continue;
            //        if (p.ParameterType == typeof(Type) && p.Name == "<locals>") continue;
            //    }

            //    if (p.IsOptional)
            //        break;

            //    // TODO: params

            //    //
            //    n++;
            //}

            ////
            //return n;

            throw new NotImplementedException();
        }

        public static IEnumerable<MethodBase> SelectWithArguments(this IEnumerable<MethodBase> candidates, Expression[] arguments)
        {
            //return candidates.Where(m => CanBeCalled(m, arguments));
            throw new NotImplementedException();
        }
    }
}
