using System;
using System.Threading;
using System.Runtime.CompilerServices;
using UltimateOrb.Collections.Generic;

namespace UltimateOrb {

    public static partial class Lazy {

        public static readonly UndefinedT Undefined = default;

        internal static readonly NullReferenceException ExceptionUndefined = new NullReferenceException();

        public readonly partial struct UndefinedT {
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Lazy<T> ToLazy<T>(this T value) {
            return new Lazy<T>(value);
        }
    }

    public partial class Lazy<T> : ILazy<T>, RefReturnSupported.ILazy<T> {

        internal object m_info;

        internal T m_value;

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private T GetValue() {
            // TODO: Perf
            var info = this.m_info;
            if (null == info) {
                return this.m_value;
            }
            var id = AsyncId.Value;
            for (var wait = 0u; ;) {
                if (info is Func<T> f) {
                    if (info == Interlocked.CompareExchange(ref this.m_info, id, info)) {
                        try {
                            var value = f.Invoke();
#if DEBUG
                                {
                                    var t = Console.Out;
                                    lock (t) {
                                        t.Write("^!^  ");
                                        t.WriteLine(typeof(T).Name);
                                    }
                                }
#endif
                            this.m_value = value;
                            info = null;
                            return value;
                        } finally {
                            this.m_info = info;
                        }
                    }
                }
                ++wait;
                if (wait < 5) {
                    Thread.SpinWait(unchecked((int)wait * 500));
                } else {
                    if (0 == wait % 64) {
                        Thread.Sleep(1);
                    } else if (0 == wait % 8) {
                        Thread.Sleep(0);
                    } else {
                        Thread.Yield();
                    }
                }
                info = this.m_info;
                if (null == info) {
                    return this.m_value;
                }
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public TFunc GetValueCreator<TFunc>() where TFunc : IO.IFunc<T> {
            if (this.m_info is TFunc c) {
                return c;
            }
            throw new NotSupportedException();
        }

        public ref readonly T Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                this.GetValue();
                return ref this.m_value;
            }
        }

        T IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.GetValue();
        }

        public bool IsEvaluated {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => null == this.m_info;
        }

        public ref readonly T Cache {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value;
        }

        T ILazy<T>.Cache {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value;
        }

        public Func<T> ValueCreator {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                if (this.m_info is Func<T> f) {
                    if (null != f) {
                        return f;
                    }
                }
                throw new NotImplementedException();
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Lazy(T value) {
            this.m_value = value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Lazy() {
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Lazy(Func<T> factory) {
            this.m_info = factory;
        }

        public static readonly Lazy<T> Undefined = Lazy.Undefined;

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Lazy<T>(Lazy.UndefinedT value) {
            return new Lazy<T>(() => throw Lazy.ExceptionUndefined);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Lazy<T>(T value) {
            return new Lazy<T>(value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static explicit operator T(Lazy<T> value) {
            return value.Value;
        }

        public override string ToString() {
            T v = default;
            bool s = false;
            try {
                v = this.GetValue();
                s = true;
            } catch (Exception ex) {
                if (Lazy.ExceptionUndefined == ex) {
                    return $@"<undefined>";
                }
                return $@"<exception {{{ex.ToString()}}}>";
            }
            if (s) {
                return $@"({v.ToString()})";
            }
            return $@"<undefined {{Unknown}}>";
        }
    }
}

namespace UltimateOrb.Linq {

    public static partial class StrictLazy {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ILazy<TResult> Select<TSource, TResult>(this ILazy<TSource> source, Func<TSource, TResult> selector) {
            return source.IsEvaluated ? new Lazy<TResult>(selector.Invoke(source.Cache)) : new Lazy<TResult>(() => selector.Invoke(source.Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ILazy<TResult> SelectMany<TSource, TCollection, TResult>(this ILazy<TSource> source, Func<TSource, ILazy<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            ILazy<TCollection> collection;
            TSource source_value;
            return source.IsEvaluated ? ((collection = collectionSelector.Invoke(source_value = source.Cache)).IsEvaluated ? new Lazy<TResult>(resultSelector.Invoke(source_value, collection.Cache)) : new Lazy<TResult>(() => resultSelector.Invoke(source_value, collection.Value))) : new Lazy<TResult>(() => resultSelector.Invoke(source_value = source.Value, collectionSelector.Invoke(source_value).Value));
        }
    }
}
