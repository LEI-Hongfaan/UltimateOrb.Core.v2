using System;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: System.CLSCompliantAttribute(true)]
[assembly: System.Security.SecurityRulesAttribute(System.Security.SecurityRuleSet.Level2)]
[assembly: System.Security.SecurityTransparentAttribute()]

namespace UltimateOrb {

    [ComVisibleAttribute(true)]
    [SerializableAttribute()]
    public struct Void {
    }

    [AttributeUsageAttribute(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ImplementShouldNotHideBaseOverloadsAttribute : Attribute {
    }
}

namespace UltimateOrb {
    using System.Linq.Expressions;

    public struct DefaultConstuctor<T>
        : IO.IFunc<T>
        where T : new() {

        private static readonly Type[] Array_Empty_Type = Type.EmptyTypes;

        private static readonly Func<T> Constructor = Expression.Lambda<Func<T>>(Expression.New(typeof(T).GetConstructor(Array_Empty_Type))).Compile();

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T Invoke() {
            var t = default(T);
            return null == t ? Constructor.Invoke() : t;
        }
    }

    public static class DefaultConstuctor {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static T Invoke<T>() where T : new() {
            return default(DefaultConstuctor<T>).Invoke();
        }
    }
}
