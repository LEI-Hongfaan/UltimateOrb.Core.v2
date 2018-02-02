using System;

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
    ///         The specified type.
    ///     </para>
    /// </typeparam>
    /// <typeparam name="T2">
    ///     <para>
    ///         The specified type.
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

namespace UltimateOrb {
    using System.Linq.Expressions;

    public static partial class IsNullableValueType<T> {

        public static readonly bool Value = GetValue();

        private static bool GetValue() {
            return null != Nullable.GetUnderlyingType(typeof(T));
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
            return IsNullableValueType<T>.Value ? t : (null == t ? Constructor.Invoke() : t);
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
        public static void IgnoreOutParameter<T>(out T value) {
            Contract.ValueAtReturn(out value);
        }
    }
}
