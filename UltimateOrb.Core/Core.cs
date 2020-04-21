using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: System.CLSCompliantAttribute(true)]
[assembly: System.Security.SecurityRulesAttribute(System.Security.SecurityRuleSet.Level2)]
[assembly: System.Security.SecurityTransparentAttribute()]

namespace UltimateOrb {

    [ComVisibleAttribute(true)]
    [SerializableAttribute()]
    public readonly partial struct Void {
    }

    /// <summary>
    ///     <para>
    ///         Provides a type that is different from the specified type.
    ///     </para>
    /// </summary>
    /// <typeparam name="T">
    ///     <para>
    ///         The specified type.
    ///     </para>
    /// </typeparam>
    [ComVisibleAttribute(true)]
    [SerializableAttribute()]
    public readonly partial struct Void<T> {
    }

    /// <summary>
    ///     <para>
    ///         Provides a type that is different from the specified types.
    ///     </para>
    /// </summary>
    /// <typeparam name="T1">
    ///     <para>
    ///         The first specified type.
    ///     </para>
    /// </typeparam>
    /// <typeparam name="T2">
    ///     <para>
    ///         The second specified type.
    ///     </para>
    /// </typeparam>
    [ComVisibleAttribute(true)]
    [SerializableAttribute()]
    public readonly partial struct Void<T1, T2> {
    }

    [AttributeUsageAttribute(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed partial class ImplementShouldNotHideBaseOverloadsAttribute : Attribute {
    }
}

namespace UltimateOrb.Linq {
    using System.Collections.Generic;
    using System.Linq;

    public static partial class Enumerable {

        public static IEnumerable<(TSource, TAccumulate)> ZipPartialAggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) {
            if (source is null) {
                throw new ArgumentNullException(nameof(source));
            }

            if (func is null) {
                throw new ArgumentNullException(nameof(func));
            }

            var acc = seed;
            foreach (var item in source) {
                acc = func(acc, item);
                yield return (item, acc);
            }
        }

        public static IEnumerable<TAccumulate> PartialAggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) {
            if (source is null) {
                throw new ArgumentNullException(nameof(source));
            }

            if (func is null) {
                throw new ArgumentNullException(nameof(func));
            }

            var acc = seed;
            foreach (var item in source) {
                acc = func(acc, item);
                yield return acc;
            }
        }

        /*
        public static IEnumerable<TSource> A<TSource>(this IEnumerable<TSource> source) {
            return source.Aggregate(System.Linq.Enumerable.Empty<TSource>().GetEnumerator(), Concatenate).AsEnumerable();
        }
        */

        public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerator<TSource> source) {
            for(; source.MoveNext(); ) {
                yield return source.Current;
            }
        }

        public static IEnumerable<T> ConcatenateR<T>(this IEnumerable<T> tail, T head) {
            yield return head;
            foreach (var item in tail) {
                yield return item;
            }
        }

        public static IEnumerator<T> ConcatenateR<T>(this IEnumerator<T> tail, T head) {
            yield return head;
            for (; tail.MoveNext(); ) {
                yield return tail.Current;
            }
        }
    }
}

namespace UltimateOrb {
    using System.Linq.Expressions;
    using System.Reflection;

    public static partial class IsStandardNullAssignable<T> {

        public static readonly bool Value = GetValue();

        private static bool GetValue() {
            return null == default(T);
        }
    }

    public static partial class IsNullAssignable {

        public static bool GetValue<T>() {
            return IsNullAssignable<T>.Value;
        }

        public static bool GetValue(Type type) {
            if (type is null) {
                throw new ArgumentNullException(nameof(type));
            }
            return (bool)typeof(IsNullAssignable<>).MakeGenericType(type).GetField(nameof(IsNullAssignable<int>.Value)).GetValue(null);
        }

        internal static bool GetValueCore(Type type) {
            if ((bool)typeof(IsStandardNullAssignable<>).MakeGenericType(type).GetField(nameof(IsStandardNullAssignable<int>.Value)).GetValue(null)) {
                return true;
            }
            if (typeof(INullableReference).IsAssignableFrom(type)) {
                return true;
            }
            if (typeof(INullable).IsAssignableFrom(type)) {
                return true;
            }
            if (!type.IsValueType) {
                return true;
            }
            return false;
        }
    }

    public static partial class IsNullAssignable<T> {

        public static readonly bool Value = IsNullAssignable.GetValueCore(typeof(T));
    }

    public static partial class IsStandardNullableValueType<T> {

        public static readonly bool Value = GetValue();

        private static bool GetValue() {
            return null != System.Nullable.GetUnderlyingType(typeof(T));
        }
    }

    public readonly partial struct DefaultConstructor<T>
        : IO.IFunc<T>
        where T : new() {

        private static readonly Func<T> Constructor = GetConstructor();

        private static Func<T> GetConstructor() {
            return Expression.Lambda<Func<T>>(Expression.New(typeof(T).GetConstructor(DefaultConstructor.Array_Empty_Type))).Compile();
            // return IsNullableValueType<T>.Value ? null : Expression.Lambda<Func<T>>(Expression.New(typeof(T).GetConstructor(DefaultConstructor.Array_Empty_Type))).Compile();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T Invoke() {
            return InvokeImpl();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static T InvokeImpl() {
            var t = default(T);
            return IsStandardNullableValueType<T>.Value ? t : (null == t ? Constructor.Invoke() : t);
        }
    }

    public static partial class DefaultConstructor {

        internal static readonly Type[] Array_Empty_Type = Type.EmptyTypes;

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static T Invoke<T>() where T : new() {
            return default(DefaultConstructor<T>).Invoke();
        }
    }
}

namespace UltimateOrb {
    using Contract = System.Diagnostics.Contracts.Contract;

    public static partial class Miscellaneous {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Likely(bool value) {
            return value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Unlikely(bool value) {
            return value;
        }

        [ILMethodBodyAttribute(@"
            pop
            ret
        ")]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void IgnoreOutParameter<T>(out T value) {
            Contract.ValueAtReturn(out value);
        }
    }
}

namespace UltimateOrb {

    [System.AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false, AllowMultiple = false)]
    sealed class ILMethodBodyAttribute : Attribute {

        readonly string ilSourceCode;

        public ILMethodBodyAttribute(string ilSourceCode) {
            this.ilSourceCode = ilSourceCode;
        }

        public string ILSourceCode {

            get {
                return ilSourceCode;
            }
        }
    }
}
