using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UltimateOrb.Collections.Generic;

namespace UltimateOrb.Mathematics.Functional {

    public static partial class StandardNullable {

        public static partial class FoldLeft<T, TAccumulate, TBinaryOperator, TBinaryOperatorB1>
            where T : struct
            where TBinaryOperator : IO.IFunc<TAccumulate, TBinaryOperatorB1>
            where TBinaryOperatorB1 : IO.IFunc<T, TAccumulate> {

            public static readonly C0 Value = default;

            public readonly partial struct C0 : IO.IFunc<TBinaryOperator, C0.C1> {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                public C1 Invoke(TBinaryOperator arg) {
                    return new C1(arg);
                }

                public readonly partial struct C1 : IO.IFunc<TAccumulate, C1.C2> {

                    private readonly TBinaryOperator arg;

                    [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                    public C1(TBinaryOperator arg) {
                        this.arg = arg;
                    }

                    [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                    public C2 Invoke(TAccumulate arg) {
                        return new C2(this, arg);
                    }

                    public readonly partial struct C2 : IO.IFunc<T?, TAccumulate> {

                        private readonly C1 c1;

                        private readonly TAccumulate arg;

                        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                        public C2(C1 c1, TAccumulate arg) {
                            this.c1 = c1;
                            this.arg = arg;
                        }

                        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                        public TAccumulate Invoke(T? arg) {
                            var t = this.arg;
                            if (arg.HasValue) {
                                return this.c1.arg.Invoke(t).Invoke(arg.Value);
                            }
                            return t;                            
                        }
                    }
                }
            }
        }
    }

    public static partial class Enumerable {

        public static partial class FoldLeft<T, TAccumulate, TBinaryOperator, TBinaryOperatorB1, TEnumerable, TEnumerator>
            where TBinaryOperator : IO.IFunc<TAccumulate, TBinaryOperatorB1>
            where TBinaryOperatorB1 : IO.IFunc<T, TAccumulate>
            where TEnumerable : Typed.Collections.Generic.IEnumerable<T, TEnumerator>
            where TEnumerator : IEnumerator<T> {

            public static readonly C0 Value = default;

            public readonly partial struct C0 : IO.IFunc<TBinaryOperator, C0.C1> {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                public C1 Invoke(TBinaryOperator arg) {
                    return new C1(arg);
                }

                public readonly partial struct C1 : IO.IFunc<TAccumulate, C1.C2> {

                    private readonly TBinaryOperator arg;

                    [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                    public C1(TBinaryOperator arg) {
                        this.arg = arg;
                    }

                    [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                    public C2 Invoke(TAccumulate arg) {
                        return new C2(this, arg);
                    }

                    public readonly partial struct C2 : IO.IFunc<TEnumerable, TAccumulate> {

                        private readonly C1 c1;

                        private readonly TAccumulate arg;

                        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                        public C2(C1 c1, TAccumulate arg) {
                            this.c1 = c1;
                            this.arg = arg;
                        }

                        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                        public TAccumulate Invoke(TEnumerable arg) {
                            var binOp = this.c1.arg;
                            var result = this.arg;
                            var i = arg.GetEnumerator();
                            for (; i.MoveNext();) {
                                result = binOp.Invoke(result).Invoke(i.Current);
                            }
                            i.Dispose();
                            return result;
                        }
                    }
                }
            }
        }
    }
}
