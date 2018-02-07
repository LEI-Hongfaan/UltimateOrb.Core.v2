using System.Runtime.CompilerServices;

namespace UltimateOrb.Nonstrict {

    public readonly partial struct List<T> {

        private readonly ILazy<List<T>> m_tail;

        private readonly ILazy<T> m_head;

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Lazy<List<T>> CreateConstantList(ILazy<T> const_value) {
            var a = new Lazy<List<T>>();
            var b = new List<T>(a, const_value);
            a.m_value = b;
            return a;
        }

        public static readonly Lazy<List<T>> Nil = default(List<T>);

        public static readonly Lazy<ConsT.C0> Cons = ConsT.Value;

        public static partial class ConsT {

            public static readonly C0 Value = default;

            public readonly partial struct C0 : IFunc<ILazy<T>, C0.C1> {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                public C1 Invoke(ILazy<T> arg) {
                    return new C1(arg);
                }

                public readonly partial struct C1 : IFunc<ILazy<List<T>>, Lazy<List<T>>> {

                    private readonly ILazy<T> arg;

                    [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                    public C1(ILazy<T> arg) {
                        this.arg = arg;
                    }

                    [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                    public Lazy<List<T>> Invoke(ILazy<List<T>> arg) {
                        return new Lazy<List<T>>(new List<T>(arg, this.arg));
                    }
                }
            }
        }

        public static readonly Lazy<HeadT> Head_ = new Lazy<HeadT>();

        public readonly partial struct HeadT : IFunc<ILazy<List<T>>, ILazy<T>> {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public ILazy<T> Invoke(ILazy<List<T>> arg) {
                if (arg.IsEvaluated) {
                    return arg.Cache.m_head;
                }
                return new Lazy<T>(() => arg.Value.m_head.Value);
            }
        }

        public static readonly Lazy<TailT> Tail_ = new Lazy<TailT>();

        public readonly partial struct TailT : IFunc<ILazy<List<T>>, ILazy<List<T>>> {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public ILazy<List<T>> Invoke(ILazy<List<T>> arg) {
                if (arg.IsEvaluated) {
                    return arg.Cache.m_tail;
                }
                return new Lazy<List<T>>(() => arg.Value.m_tail.Value);
            }
        }

        public ILazy<T> Head {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return this.m_head;
            }
        }

        public ILazy<List<T>> Tail {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return this.m_tail;
            }
        }

        private partial class NestListUnit<TFunc>
           where TFunc : IO.IFunc<ILazy<T>, ILazy<T>> {

            private readonly ILazy<TFunc> func;

            private ILazy<T> value;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public NestListUnit(ILazy<TFunc> func, ILazy<T> initial_value) {
                this.func = func;
                this.value = initial_value;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public List<T> GetNext() {
                var a = this.value;
                ILazy<T> b;
                var f = this.func;
                if (f.IsEvaluated) {
                    b = f.Cache.Invoke(a);
                } else {
                    b = new Lazy<T>(() => f.Value.Invoke(a).Value);
                }
                var t = new List<T>(new Lazy<List<T>>(this.GetNext), b);
                this.value = b;
                return t;
            }
        }

        public static Lazy<List<T>> CreateNestList<TFunc>(ILazy<TFunc> func, ILazy<T> initial_value)
            where TFunc : IO.IFunc<ILazy<T>, ILazy<T>> {
            var a = new NestListUnit<TFunc>(func, initial_value);
            return new Lazy<List<T>>(new List<T>(new Lazy<List<T>>(a.GetNext()), initial_value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal List(ILazy<List<T>> tail, ILazy<T> head) {
            this.m_tail = tail;
            this.m_head = head;
        }

        public bool IsNil {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => null == this.m_head;
        }

        public bool IsCons {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => null != this.m_head;
        }
    }
}
