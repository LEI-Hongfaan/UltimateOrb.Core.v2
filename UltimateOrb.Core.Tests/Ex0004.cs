﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UltimateOrb.Nongeneric;
using UltimateOrb.Utilities;

namespace UltimateOrb.Ex0004 {

    public partial interface ITypeConstructor {

        Type Type {

            get;
        }

        bool CanInvoke {

            get;
        }

        ITypeConstructor Invoke(Type type);

        ITypeConstructor Invoke(ITypeConstructor type);
    }

    public readonly partial struct BclTypeAsTypeConstructor : ITypeConstructor {

        private readonly Type m_type;

        public BclTypeAsTypeConstructor(Type type) {
            this.m_type = type;
        }

        public Type Type {

            get => this.m_type;
        }

        public bool CanInvoke {

            get => false;
        }

        public ITypeConstructor Invoke(Type type) {
            throw new NotSupportedException();
        }

        public ITypeConstructor Invoke(ITypeConstructor type) {
            throw new NotSupportedException();
        }

        public static implicit operator Type(BclTypeAsTypeConstructor value) {
            return value.m_type;
        }

        public static implicit operator BclTypeAsTypeConstructor(Type value) {
            return new BclTypeAsTypeConstructor(value);
        }
    }

    public readonly partial struct BclTypeAsTypeConstructor<T> : ITypeConstructor {

        public readonly static Type type = typeof(T);

        public Type Type {

            get => type;
        }

        public bool CanInvoke {

            get => false;
        }

        public ITypeConstructor Invoke(Type type) {
            throw new NotSupportedException();
        }

        public ITypeConstructor Invoke(ITypeConstructor type) {
            throw new NotSupportedException();
        }
    }

    public static partial class Extensions {

        public static BclTypeAsTypeConstructor ToTypeConstructor(this Type type) {
            return type;
        }
    }

    public readonly partial struct BclArray : ITypeConstructor {

        public Type Type {

            get => throw new NotSupportedException();
        }

        public bool CanInvoke {

            get => true;
        }

        public ITypeConstructor Invoke(ITypeConstructor value) {
            return this.Invoke(value.Type);
        }

        public ITypeConstructor Invoke(Type type) {
            return type.MakeArrayType().ToTypeConstructor();
        }
    }

    public interface IFunctor<T_f> where T_f : ITypeConstructor, new() {

        // Func<Func<T_a, T_b>, Func<object, object>> g__fmap<T_a, T_b>(Func<T_a, T_b> f);

        Func<Func<object, object>, Func<object, object>> _fmap {

            get;

            set;
        }

        /*
        [OperatorNotationAttribute(@"<$", 4, OperatorAssociativity.Left)]
        Func<object, object> op_g__UTF8_3C24<T_a>(T_a a);
        */

        [OperatorNotationAttribute(@"<$", 4, OperatorAssociativity.Left)]
        Func<object, Func<object, object>> op__UTF8_3C24 {

            get;

            set;
        }
    }
    public readonly partial struct C<TToken> {

        private static ReadOnlyStrongBox<object> s_Impl;

        public static ReadOnlyStrongBox<object> Impl {

            get => s_Impl;

            set => s_Impl = value;
        }

        private static int s_IsInitialized;

        public static bool IsInitialized {

            get => 0 != s_IsInitialized;

            set {
                var t = Interlocked.CompareExchange(ref s_IsInitialized, value ? 1 : 0, 0);
                if (0 == t) {
                    return;
                }
                ThrowHelper.Throw<InvalidOperationException>();
            }
        }
    }

    public static partial class Extensions {

        public static Func<object, object> _id = x => x;

        public static Func<object, Func<object, object>> _const = x => y => x;

        [OperatorNotationAttribute(@"$", 0, OperatorAssociativity.Right)]
        public static Func<Func<object, object>, Func<object, object>> op__UTF8_24 = f => x => f(x);
        
        [OperatorNotationAttribute(@".", 9, OperatorAssociativity.Right)]
        public static Func<Func<object, object>, Func<Func<object, object>, Func<object, object>>> op__UTF8_2E = f => g => x => f(g(x));

    }

    public readonly partial struct BclArray : IFunctor<BclArray> {

        private readonly partial struct s__fmap {

            private static Func<Func<object, object>, Func<object, object>> GetValue() {
                var value = (Func<Func<object, object>, Func<object, object>>)null;
                var t = C<s__fmap>.Impl;
                if (null != t) {
                    value = (Func<Func<object, object>, Func<object, object>>)t.Value;
                } else {
                    ThrowHelper.Throw<NotImplementedException>();
                }
                return value;
            }

            public static readonly Func<Func<object, object>, Func<object, object>> Value = GetValue();

            private static Void DoInitialized() {
                C<s__fmap>.IsInitialized = true;
                return default;
            }

            private static readonly Void __ignored = DoInitialized();
        }

        private readonly partial struct s_op__UTF8_3C24 {

            private static Func<object, Func<object, object>> GetValue() {
                var value = (Func<object, Func<object, object>>)null;
                var t = C<s_op__UTF8_3C24>.Impl;
                if (null != t) {
                    value = (Func<object, Func<object, object>>)t.Value;
                } else {
                    ThrowHelper.Throw<NotImplementedException>();
                }
                return value;
            }

            public static readonly Func<object, Func<object, object>> Value = GetValue();

            private static Void DoInitialized() {
                C<s_op__UTF8_3C24>.IsInitialized = true;
                return default;
            }

            private static readonly Void __ignored = DoInitialized();
        }

        public Func<Func<object, object>, Func<object, object>> _fmap {

            get => s__fmap.Value;

            set => C<s__fmap>.Impl = null == value ? null : new ReadOnlyStrongBox<object>(value);
        }

        public Func<object, Func<object, object>> op__UTF8_3C24 {

            get => s_op__UTF8_3C24.Value;

            set => C<s_op__UTF8_3C24>.Impl = null == value ? null : new ReadOnlyStrongBox<object>(value);
        }
    }
}
