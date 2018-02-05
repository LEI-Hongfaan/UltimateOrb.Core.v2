using System.Runtime.CompilerServices;

namespace UltimateOrb.Mathematics.Functional {

    public static partial class Curry<T1, T2, TResult, TFunc>
        where TFunc : IO.IFunc<T1, T2, TResult> {

        public static readonly C0 Value = default;

        public readonly partial struct C0 : IO.IFunc<TFunc, C0.C1> {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public C1 Invoke(TFunc arg) {
                return new C1(arg);
            }

            public readonly partial struct C1 : IO.IFunc<T1, C1.C2> {

                private readonly TFunc arg;

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                public C1(TFunc arg) {
                    this.arg = arg;
                }

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                public C2 Invoke(T1 arg) {
                    return new C2(this, arg);
                }

                public readonly partial struct C2 : IO.IFunc<T2, TResult> {

                    private readonly C1 c1;

                    private readonly T1 arg;

                    [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                    public C2(C1 c1, T1 arg) {
                        this.c1 = c1;
                        this.arg = arg;
                    }

                    [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                    public TResult Invoke(T2 arg) {
                        return this.c1.arg.Invoke(this.arg, arg);
                    }
                }
            }
        }
    }
}
