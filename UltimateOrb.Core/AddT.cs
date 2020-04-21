using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace UltimateOrb.Functional.Unchecked {
}

namespace UltimateOrb {

    public interface IBinOp<T> : IFunc<T, T, T> {
    }
}

namespace UltimateOrb.Functional {

    public static partial class Add {

        private static Delegate GetStandardFunctor(Type type) {
            var func = (Delegate)null;
            for (; ; ) {
                {
                    var t = typeof(Internal.StandardFunctor<>.InternalData).MakeGenericType(type).GetField(nameof(Internal.StandardFunctor<int>.InternalData.m_candidate)).GetValue(null) as Delegate;
                    if (null != t) {
                        func = t;
                        break;
                    }
                }
                if (null == func) {
                    var mnr = "Add";
                    var mnra = "Addition";
                    var expr = (LambdaExpression)null;
                    // var type = typeof(T);
                    var method = (MethodInfo)null;
                    var mnm = "Checked";
                    method =
                        type.GetMethod("op_" + mnra + mnm, BindingFlags.Instance | BindingFlags.Public) ??
                        type.GetMethod(mnr + mnm, BindingFlags.Instance | BindingFlags.Public) ??
                        type.GetMethod("op_" + mnra + mnm, BindingFlags.Static | BindingFlags.Public) ??
                        type.GetMethod(mnr + mnm, BindingFlags.Static | BindingFlags.Public);
                    if (null == method) {
                        var mnd = "Unchecked";
                        var d =
                            type.GetMethod("op_" + mnra + mnd, BindingFlags.Instance | BindingFlags.Public) ??
                            type.GetMethod(mnr + mnd, BindingFlags.Instance | BindingFlags.Public) ??
                            type.GetMethod("op_" + mnra + mnd, BindingFlags.Static | BindingFlags.Public) ??
                            type.GetMethod(mnr + mnd, BindingFlags.Static | BindingFlags.Public);
                        if (null != d) {
                            method =
                                type.GetMethod("op_" + mnra, BindingFlags.Instance | BindingFlags.Public) ??
                                type.GetMethod(mnr, BindingFlags.Instance | BindingFlags.Public) ??
                                type.GetMethod("op_" + mnra, BindingFlags.Static | BindingFlags.Public) ??
                                type.GetMethod(mnr, BindingFlags.Static | BindingFlags.Public);
                        }
                    }
                    if (null != method) {
                        var func_type = typeof(Func<,,>).MakeGenericType(type, type, type);
                        var first_p = Expression.Parameter(type);
                        var second_p = Expression.Parameter(type);
                        if (method.IsStatic) {
                            expr = Expression.Lambda(func_type, Expression.Call(null, method, first_p, second_p), first_p, second_p);
                        } else {
                            // TODO
                            if (!type.IsValueType || typeof(Nullable<>) != type.GetGenericTypeDefinition()) {
                                // nullable type (Nullable`1 or class)
                                // TODO
                                expr = Expression.Lambda(func_type, Expression.Call(null, method, first_p, second_p), first_p, second_p);
                            } else {
                                expr = Expression.Lambda(func_type, Expression.Call(null, method, first_p, second_p), first_p, second_p);
                            }
                        }
                    }
                    if (null != expr) {
                        func =  expr.Compile(false);
                        break;
                    }
                }
                break;
            }
            if (null == func) {
                throw new NotImplementedException();
            }
            // Internal.StandardFunctor<T>.InternalData.m_initialized = true;
            typeof(Internal.StandardFunctor<>.InternalData).MakeGenericType(type).GetField(nameof(Internal.StandardFunctor<int>.InternalData.m_initialized)).SetValue(null, true);
            return func;
        }

        public static void RegisterStandardFunctor<T>(Func<T, T, T> func) {
            if (null == func) {
                throw new ArgumentNullException(nameof(func));
            }
            if (Internal.StandardFunctor<T>.InternalData.m_initialized) {
                throw new InvalidOperationException();
            }
            CheckHardcoded(typeof(T));
            Internal.StandardFunctor<T>.InternalData.m_candidate = func;
            Register_Stub1<T>();
            Internal.StandardFunctor<T>.InternalData.m_candidate = null;
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        private static void Register_Stub1<T>() {
            GC.KeepAlive(Internal.StandardFunctor<T>.Value);
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        private static Func<T, T, T> Register_Stub0<T>() {
            return Internal.StandardFunctor<T>.Value;
        }


        private static void CheckHardcoded(Type type) {
            var b = false;
            // if (null != default(T)) {
            b = Internal.TypeHardcoded.Value.ContainsKey(type);
            // }
            if (b) {
                throw new NotSupportedException();
            }
        }

        internal static partial class Internal {

            internal static class TypeHardcoded {

                public static readonly ConcurrentDictionary<Type, Delegate> Value = new ConcurrentDictionary<Type, Delegate>(new KeyValuePair<Type, Delegate>[] {
                    new KeyValuePair<Type, Delegate>(typeof(int), (Func<int, int, int>)Add.Invoke),
                    new KeyValuePair<Type, Delegate>(typeof(int), (Func<int, int, int>)Add.Invoke),
                    new KeyValuePair<Type, Delegate>(typeof(int), (Func<int, int, int>)Add.Invoke),
                    new KeyValuePair<Type, Delegate>(typeof(int), (Func<int, int, int>)Add.Invoke),
                    new KeyValuePair<Type, Delegate>(typeof(int), (Func<int, int, int>)Add.Invoke),
                    new KeyValuePair<Type, Delegate>(typeof(int), (Func<int, int, int>)Add.Invoke),
                });
            }

            internal static class StandardFunctor<T> {

                internal static class InternalData {

                    internal static Func<T, T, T> m_candidate;

                    internal static bool m_initialized;
                }

                public static readonly Func<T, T, T> Value = (Func < T, T, T>)GetStandardFunctor(typeof(T));
            }
        }

        public static Func<T, T, T> StandardFunctor<T>() {
            return Internal.StandardFunctor<T>.Value;
        }
    }
}
