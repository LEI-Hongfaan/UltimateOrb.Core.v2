using System.Runtime.CompilerServices;

namespace UltimateOrb.Mathematics.Functional {

    public static partial class Uncurry<T1, T2, TResult, TFunc, TFuncB1>
        where TFunc : IO.IFunc<T1, TFuncB1>
        where TFuncB1 : IO.IFunc<T2, TResult> {

        public static readonly C0 Value = default;

        public readonly partial struct C0 : IO.IFunc<TFunc, C0.C1> {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public C1 Invoke(TFunc arg) {
                return new C1(arg);
            }

            public readonly partial struct C1 : IO.IFunc<T1, T2, TResult> {

                private readonly TFunc arg;

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                public C1(TFunc arg) {
                    this.arg = arg;
                }

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                public TResult Invoke(T1 arg1, T2 arg2) {
                    return this.arg.Invoke(arg1).Invoke(arg2);
                }
            }
        }
    }
}
