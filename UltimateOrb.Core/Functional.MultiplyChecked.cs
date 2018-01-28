using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Mathematics.Functional {

    public static partial class MultiplyChecked {

        public readonly partial struct Functor<T> : IO.IFunc<T, T, T> {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public T Invoke(T arg1, T arg2) {
                return InvokeImpl(arg1, arg2);
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public static T InvokeImpl(T arg1, T arg2) {
                if (null != default(T)) {
                    if (typeof(Int32) == typeof(T)) {
                        return (T)(object)checked((Int32)(object)arg1 * (Int32)(object)arg2);
                    } else if (typeof(Int64) == typeof(T)) {
                        return (T)(object)checked((Int64)(object)arg1 * (Int64)(object)arg2);
                    } else if (typeof(UInt32) == typeof(T)) {
                        return (T)(object)checked((UInt32)(object)arg1 * (UInt32)(object)arg2);
                    } else if (typeof(UInt64) == typeof(T)) {
                        return (T)(object)checked((UInt64)(object)arg1 * (UInt64)(object)arg2);
                    } else if (typeof(Int16) == typeof(T)) {
                        return (T)(object)checked((Int16)unchecked((int)(Int16)(object)arg1 * (int)(Int16)(object)arg2));
                    } else if (typeof(UInt16) == typeof(T)) {
                        return (T)(object)checked((UInt16)unchecked((uint)(UInt16)(object)arg1 * (uint)(UInt16)(object)arg2));
                    } else if (typeof(Byte) == typeof(T)) {
                        return (T)(object)checked((Byte)unchecked((uint)(Byte)(object)arg1 * (uint)(Byte)(object)arg2));
                    } else if (typeof(SByte) == typeof(T)) {
                        return (T)(object)checked((SByte)unchecked((int)(SByte)(object)arg1 * (int)(SByte)(object)arg2));
                    } else if (typeof(Int128) == typeof(T)) {
                        return (T)(object)(Int128.Multiply((Int128)(object)arg1, (Int128)(object)arg2));
                    } else if (typeof(UInt128) == typeof(T)) {
                        return (T)(object)(UInt128.Multiply((UInt128)(object)arg1, (UInt128)(object)arg2));
                    }
                }
                return InvokeImpl1(arg1, arg2);
            }

            private static T InvokeImpl1(T arg1, T arg2) {
                return Typed<T>.Value(arg1, arg2);
            }
        }

        private static partial class TypedInternalData<T> {

            internal static Func<T, T, T> m_candidate;

            internal static bool m_initialized;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Register<T>(Func<T, T, T> func) {
            if (null == func) {
                throw new ArgumentNullException(nameof(func));
            }
            if (TypedInternalData<T>.m_initialized) {
                throw new InvalidOperationException();
            }
            {
                var b = false;
                if (null != default(T)) {
                    if (typeof(Int32) == typeof(T)) {
                        b = true;
                    } else if (typeof(Int64) == typeof(T)) {
                        b = true;
                    } else if (typeof(UInt32) == typeof(T)) {
                        b = true;
                    } else if (typeof(UInt64) == typeof(T)) {
                        b = true;
                    } else if (typeof(Int16) == typeof(T)) {
                        b = true;
                    } else if (typeof(UInt16) == typeof(T)) {
                        b = true;
                    } else if (typeof(Byte) == typeof(T)) {
                        b = true;
                    } else if (typeof(SByte) == typeof(T)) {
                        b = true;
                    } else if (typeof(Int128) == typeof(T)) {
                        b = true;
                    } else if (typeof(UInt128) == typeof(T)) {
                        b = true;
                    }
                }
                if (b) {
                    throw new NotSupportedException();
                }
            }
            TypedInternalData<T>.m_candidate = func;
            Register_Stub1<T>();
            TypedInternalData<T>.m_candidate = null;
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        private static void Register_Stub1<T>() {
            GC.KeepAlive(Typed<T>.Value);
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        private static Func<T, T, T> Register_Stub0<T>() {
            return Typed<T>.Value;
        }

        public static partial class Typed<T> {

            private static readonly Func<T, T, T> m_value = GetValue();

            public static Func<T, T, T> Value {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => m_value;
            }

            private static Func<T, T, T> GetValue() {
                var func = (Func<T, T, T>)null;
                for (; ; ) {
                    {
                        var t = TypedInternalData<T>.m_candidate;
                        if (null != t) {
                            func = t;
                            break;
                        }
                    }
                    if (null == func) {
                        var mnr = "Multiply";
                        var expr = (Expression<Func<T, T, T>>)null;
                        var type = typeof(T);
                        var method = (MethodInfo)null;
                        var mnm = "Checked";
                        method =
                            type.GetMethod("op_" + mnr + mnm, BindingFlags.Instance | BindingFlags.Public) ??
                            type.GetMethod(mnr + mnm, BindingFlags.Instance | BindingFlags.Public) ??
                            type.GetMethod("op_" + mnr + mnm, BindingFlags.Static | BindingFlags.Public) ??
                            type.GetMethod(mnr + mnm, BindingFlags.Static | BindingFlags.Public);
                        if (null == method) {
                            var mnd = "Unchecked";
                            var d =
                                type.GetMethod("op_" + mnr + mnd, BindingFlags.Instance | BindingFlags.Public) ??
                                type.GetMethod(mnr + mnd, BindingFlags.Instance | BindingFlags.Public) ??
                                type.GetMethod("op_" + mnr + mnd, BindingFlags.Static | BindingFlags.Public) ??
                                type.GetMethod(mnr + mnd, BindingFlags.Static | BindingFlags.Public);
                            if (null != d) {
                                method =
                                    type.GetMethod("op_" + mnr, BindingFlags.Instance | BindingFlags.Public) ??
                                    type.GetMethod(mnr, BindingFlags.Instance | BindingFlags.Public) ??
                                    type.GetMethod("op_" + mnr, BindingFlags.Static | BindingFlags.Public) ??
                                    type.GetMethod(mnr, BindingFlags.Static | BindingFlags.Public);
                            }
                        }
                        if (null != method) {
                            var first_p = Expression.Parameter(type);
                            var second_p = Expression.Parameter(type);
                            if (method.IsStatic) {
                                expr = Expression.Lambda<Func<T, T, T>>(Expression.Call(null, method, first_p, second_p), first_p, second_p);
                            } else {
                                if (null == default(T)) {
                                    // nullable type (Nullable`1 or class)
                                    // TODO
                                    expr = Expression.Lambda<Func<T, T, T>>(Expression.Call(first_p, method, second_p), first_p, second_p);
                                } else {
                                    expr = Expression.Lambda<Func<T, T, T>>(Expression.Call(first_p, method, second_p), first_p, second_p);
                                }
                            }
                        }
                        if (null != expr) {
                            func = expr.Compile();
                            break;
                        }
                    }
                    break;
                }
                if (null == func) {
                    throw new NotImplementedException();
                }
                TypedInternalData<T>.m_initialized = true;
                return func;
            }
        }
    }
}

namespace UltimateOrb {
    using UltimateOrb.Mathematics.Functional;

    public static partial class Operators {

        public static partial class Checked {

            // TODO
            // Multiply<T1, T2, TResult>
            // op_Multiply<T1, T2, TResult>

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public static T Multiply<T>(T first, T second) {
                return default(MultiplyChecked.Functor<T>).Invoke(first, second);
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public static T op_Multiply<T>(T first, T second) {
                return default(MultiplyChecked.Functor<T>).Invoke(first, second);
            }
        }
    }
}
