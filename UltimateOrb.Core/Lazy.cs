using System;
using System.Threading;
using System.Runtime.CompilerServices;
using UltimateOrb.Collections.Generic;

namespace UltimateOrb {

    public partial class Lazy<T> : ILazy<T> {

        internal object m_info;

        internal T m_value;

        T IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.GetValue();
        }

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
                                        t.Write("^!^:");
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

        public bool IsEvaluated {

            get => null == this.m_info;
        }

        public ref readonly T Cache {

            get => ref this.m_value;
        }

        public Func<T> ValueCreator {

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
        internal Lazy(T value) {
            this.m_value = value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Lazy() {
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Lazy(Func<T> factory) {
            this.m_info = factory;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Lazy<T>(T value) {
            return new Lazy<T>(value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static explicit operator T(Lazy<T> value) {
            return value.Value;
        }
    }
}
