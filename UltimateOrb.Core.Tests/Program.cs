﻿using FsCheck.Xunit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace UltimateOrb.Core.Tests {
    using System.Diagnostics;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.CompilerServices;
    using UltimateOrb.Collections.Generic;
    using UltimateOrb.Collections.Generic.ReferenceTypes;
    using UltimateOrb.IO;
    using UltimateOrb.Mathematics.Exact;
    using UltimateOrb.Mathematics.Functional;
    using UltimateOrb.Plain.ValueTypes;

    public static class AAA {

        public static PtrSimulated<T> End<T>(this T[] array) {
            return new PtrSimulated<T>(array, checked((uint)array.Length));
        }
    }

    public static partial class AAAf {

        public static BclStringAsReadOnlyList AsIReadOnlyList(this string str) {
            return new BclStringAsReadOnlyList(str);
        }

        public partial interface IAsEnumerable<out T, TEnumerable, out TEnumerator>
            where TEnumerator : IEnumerator<T> {

            TEnumerator Invoke(in TEnumerable enumerable);
        }

        public partial interface IAccumulatorHeterogeneous<in T, TAccumulate, TAccumulateForeign> {

            bool Invoke(in TAccumulateForeign accumulate, T value, out TAccumulate result);
        }


        public static void kkkk<T, TAccumulate, TEnumerator, TStack, TAsEnumerable, TAccumulator>(TStack stack, TAsEnumerable asEnumerable, TAccumulator accumulator)
            where TEnumerator : IEnumerator<T>
            where TStack : IStack<TAccumulate>
            where TAsEnumerable : IAsEnumerable<T, TStack, TEnumerator>
            where TAccumulator : IAccumulatorHeterogeneous<T, TAccumulate, TStack> {
            for (; !stack.IsEmpty;) {
                var en = asEnumerable.Invoke(stack);
                for (; en.MoveNext();) {
                    var move = en.Current;
                    if (accumulator.Invoke(in stack, move, out var state)) {
                        stack.Push(state);
                        en = asEnumerable.Invoke(stack);
                        continue;
                    }
                }
                en.Dispose();
                stack.Pop();
            }
        }

        public partial interface IAccumulatorHeterogeneous3<in T, TAccumulate, TAccumulateForeign> {

            bool Invoke(ref TAccumulateForeign accumulate, T value, out TAccumulate result);
        }


        public partial interface IFoldingStack<in T, out TAccumulate> {

            bool IsEmpty {

                get;
            }

            TAccumulate Accumulate {

                get;
            }

            void Push(T item);

            void Pop(T item);

            TAccumulate PeekAccumulatePop();

            TAccumulate PushPeekAccumulate(T item);
        }


        public partial interface IAsEnumerable2<out T, TAccumulate, out TEnumerator>
            where TEnumerator : IEnumerator<T> {

            TEnumerator Create(in TAccumulate a);

            TEnumerator Restore(in TAccumulate a);
        }

        public static void kkkffk<T, TAccumulate, TEnumerator, TStack, TAsEnumerable, TAccumulator>(TAccumulate accumulate, TStack stack, TAsEnumerable asEnumerable, TAccumulator accumulator)
        where TEnumerator : IEnumerator<T>
        where TStack : IFoldingStack<T, TAccumulate>
        where TAsEnumerable : IAsEnumerable2<T, TAccumulate, TEnumerator>
        where TAccumulator : IO.IFunc<TAccumulate, bool> {
            for (var en = asEnumerable.Create(accumulate); ;) {
                for (; en.MoveNext();) {
                    var move = en.Current;
                    if (accumulator.Invoke(stack.PushPeekAccumulate(move))) {
                        en = asEnumerable.Create(stack.Accumulate);
                        continue;
                    } else {
                        stack.Pop(move);
                    }
                }
                en.Dispose();
                if (!stack.IsEmpty) {
                    en = asEnumerable.Restore(stack.PeekAccumulatePop());
                    continue;
                }
                break;
            }
        }

        public static Collections.Generic.RefReturnSupported.List<BitArrayUnchecked> dsafsf(int[] a, long b) {
            var s = new FStack(a);
            var dfsa = new adsaddfasee(a.Length, b);
            kkkffk<bool, (BitArrayUnchecked Solution, long CurrentSum, int Count, bool LastMove, long MaxNegativeDifference, long MaxPositiveDifference), FalseTrueEnumerator, FStack, adsaddfas, adsaddfasee>((default, 0, 0, default, s.m_MaxNegativeDifference, s.m_MaxPositiveDifference), s, default(adsaddfas), dfsa);
            return (Collections.Generic.RefReturnSupported.List<BitArrayUnchecked>)dfsa.a;
        }

        public partial struct adsaddfasee : IO.IFunc<(BitArrayUnchecked Solution, long CurrentSum, int Count, bool LastMove, long MaxNegativeDifference, long MaxPositiveDifference), bool> {

            public readonly Collections.Generic.RefReturnSupported.IList<BitArrayUnchecked, Collections.Generic.RefReturnSupported.List<BitArrayUnchecked>.Enumerator> a;

            public readonly int MaxCount;

            public readonly long TargetSum;

            public adsaddfasee(int c, long b) {
                this.a = new Collections.Generic.RefReturnSupported.List<BitArrayUnchecked>(0);
                this.MaxCount = c;
                this.TargetSum = b;
            }

            public bool Invoke((BitArrayUnchecked Solution, long CurrentSum, int Count, bool LastMove, long MaxNegativeDifference, long MaxPositiveDifference) arg) {

                if (this.TargetSum == arg.CurrentSum) {
                    this.a.Add(arg.Solution.Clone());
                    return false;
                }
                if (arg.Count >= this.MaxCount) {
                    return false;
                }
                var c = this.TargetSum - arg.CurrentSum;
                if (c > arg.MaxPositiveDifference) {
                    return false;
                }
                if (c < arg.MaxNegativeDifference) {
                    return false;
                }

                return true;
            }
        }

        public partial struct adsaddfas : IAsEnumerable2<bool, (BitArrayUnchecked Solution, long CurrentSum, int Count, bool LastMove, long MaxNegativeDifference, long MaxPositiveDifference), FalseTrueEnumerator> {

            public FalseTrueEnumerator Create(in (BitArrayUnchecked Solution, long CurrentSum, int Count, bool LastMove, long MaxNegativeDifference, long MaxPositiveDifference) a) {
                return new FalseTrueEnumerator(-1);
            }

            public FalseTrueEnumerator Restore(in (BitArrayUnchecked Solution, long CurrentSum, int Count, bool LastMove, long MaxNegativeDifference, long MaxPositiveDifference) a) {
                return new FalseTrueEnumerator(a.LastMove ? 1 : 0);
            }
        }

        public partial struct FalseTrueEnumerator : IEnumerator<bool> {

            private int index;

            public bool Current {

                get => 0 != this.index;
            }

            internal FalseTrueEnumerator(int a) {
                this.index = a;
            }

            private static readonly object TrueBoxed = true;

            private static readonly object FalseBoxed = true;

            object IEnumerator.Current {

                get => 0 != this.index ? TrueBoxed : FalseBoxed;
            }

            public void Dispose() {
            }

            public bool MoveNext() {
                var i = (int)this.index;
                unchecked {
                    ++i;
                }
                if (2 <= i) {
                    return false;
                }
                this.index = unchecked((int)i);
                return true;
            }

            public void Reset() {
                throw new NotSupportedException();
            }
        }

        public partial struct Boolean64FoldingStack {

            internal UInt64 m_Item_BitArray;

            internal UInt64 m_Flag_BitArray;

            internal int m_Count;

            internal int m_Capacity;


        }

        /*
        public partial interface IBox<T> {

            ref T Value {

                get;
            }
        }
        */

        public static UInt64 SetFlag(UInt64 bitArray, int index, bool value) {
            return value ? bitArray | ((UInt64)1 << index) : bitArray & ~((UInt64)1 << index);
        }

        public partial interface IMoveNextState<T, TStateEx, BooleanT> {

            NextStateAcceptance Invoke(ref TStateEx state, T item);
        }

        public partial interface IMovePreviousState<T, TStateEx> {

            void Invoke(ref TStateEx state, T item, bool move);
        }

        public partial interface IInitializeStateEx<T, TList, TState, TStateEx>
           where TList : IList<T> {

            TStateEx Invoke(TList collection, TState state);
        }

        [FlagsAttribute()]
        public enum NextStateAcceptance {
            NotRejecting = 1,
            Accepting = 2,
        }

        public partial struct TrueT {
        }

        public partial struct FalseT {
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SolveManyBranchAndBound<T, TList, TState, TStateEx, TInitializeStateEx, TStackRecorder, TMoveNextStateTrue, TMoveNextStateFalse, TMovePreviousState>(TList collection, TState initial, TInitializeStateEx initializer, ref TStackRecorder recorder, TMoveNextStateTrue moveNextStateTrue, TMoveNextStateFalse moveNextStateFalse, TMovePreviousState movePreviousState)
            where TList : IList<T>
            // where TStateEx : IBox<TState>
            where TInitializeStateEx : IInitializeStateEx<T, TList, TState, TStateEx>
            where TStackRecorder : IO.IAction<UInt64>
            where TMoveNextStateTrue : IMoveNextState<T, TStateEx, TrueT>
            where TMoveNextStateFalse : IMoveNextState<T, TStateEx, FalseT>
            where TMovePreviousState : IMovePreviousState<T, TStateEx> {
            var m_Capacity = checked((int)collection.Count);
            if (m_Capacity <= 64) {
                var m_Count = (int)0;
                var m_Flag0_BitArray = (UInt64)0;
                var m_Flag1_BitArray = (UInt64)0;
                var m_Item_BitArray = (UInt64)0;
                if (m_Capacity > m_Count) {
                    var x = collection[m_Count];
                    for (var t = initializer.Invoke(collection, initial); ;) {
                        if (0 == (m_Flag0_BitArray & ((UInt64)1 << m_Count))) {
                            {
                                m_Flag0_BitArray |= ((UInt64)1 << m_Count);
                                var r = moveNextStateTrue.Invoke(ref t, x);
                                if (0 != (NextStateAcceptance.Accepting & r)) {
                                    recorder.Invoke(m_Item_BitArray | ((UInt64)1 << m_Count));
                                }
                                if (0 != (NextStateAcceptance.NotRejecting & r)) {
                                    m_Item_BitArray |= ((UInt64)1 << m_Count);
                                    unchecked {
                                        ++m_Count;
                                    }
                                    if (m_Capacity > m_Count) {
                                        x = collection[m_Count];
                                    } else {
                                        unchecked {
                                            --m_Count;
                                        }
                                    }
                                }
                                continue;
                            }
                        } else {
                            if (0 == (m_Flag1_BitArray & ((UInt64)1 << m_Count))) {
                                m_Flag1_BitArray |= ((UInt64)1 << m_Count);
                                if (0 != (NextStateAcceptance.NotRejecting & moveNextStateFalse.Invoke(ref t, x))) {
                                    m_Item_BitArray &= ~((UInt64)1 << m_Count);
                                    unchecked {
                                        ++m_Count;
                                    }
                                    if (m_Capacity > m_Count) {
                                        x = collection[m_Count];
                                    } else {
                                        unchecked {
                                            --m_Count;
                                        }
                                    }
                                    continue;
                                }
                            }
                        }
                        m_Flag0_BitArray &= ~((UInt64)1 << m_Count);
                        m_Flag1_BitArray &= ~((UInt64)1 << m_Count);
                        unchecked {
                            --m_Count;
                        }
                        if (0 <= m_Count) {
                            var s = (m_Item_BitArray & ((UInt64)1 << m_Count));
                            x = collection[m_Count];
                            movePreviousState.Invoke(ref t, x, 0 != s);
                            continue;
                        }
                        break;
                    }
                }
                return;
            }
            throw new NotSupportedException();
        }

        public partial struct P233MoveNextState {

            private readonly long m_TargetSum;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public P233MoveNextState(long targetSum) {
                this.m_TargetSum = targetSum;
            }
        }

        public partial struct P233MoveNextState : IMoveNextState<int, (long CurrentSum, long MaxPositiveDifference, long MaxNegativeDifference), TrueT> {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            NextStateAcceptance IMoveNextState<int, (long CurrentSum, long MaxPositiveDifference, long MaxNegativeDifference), TrueT>.Invoke(ref (long CurrentSum, long MaxPositiveDifference, long MaxNegativeDifference) state, int item) {
                var CurrentSum = state.CurrentSum;
                unchecked {
                    CurrentSum += item;
                }
                var TargetSum = this.m_TargetSum;
                if (TargetSum == CurrentSum) {
                    return NextStateAcceptance.Accepting;
                }
                var MaxPositiveDifference = state.MaxPositiveDifference;
                var MaxNegativeDifference = state.MaxNegativeDifference;
                if (0 <= item) {
                    MaxPositiveDifference -= item;
                    if (TargetSum - CurrentSum < MaxNegativeDifference) {
                        return default;
                    }
                    state.MaxPositiveDifference = MaxPositiveDifference;
                } else {
                    MaxNegativeDifference -= item;
                    if (TargetSum - CurrentSum > MaxPositiveDifference) {
                        return default;
                    }
                    state.MaxNegativeDifference = MaxNegativeDifference;
                }
                state.CurrentSum = CurrentSum;
                return NextStateAcceptance.NotRejecting;

            }
        }

        public partial struct P233MoveNextState : IMoveNextState<int, (long CurrentSum, long MaxPositiveDifference, long MaxNegativeDifference), FalseT> {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            NextStateAcceptance IMoveNextState<int, (long CurrentSum, long MaxPositiveDifference, long MaxNegativeDifference), FalseT>.Invoke(ref (long CurrentSum, long MaxPositiveDifference, long MaxNegativeDifference) state, int item) {
                var CurrentSum = state.CurrentSum;
                var TargetSum = this.m_TargetSum;
                var MaxPositiveDifference = state.MaxPositiveDifference;
                var MaxNegativeDifference = state.MaxNegativeDifference;
                if (0 <= item) {
                    MaxPositiveDifference -= item;
                    if (TargetSum - CurrentSum > MaxPositiveDifference) {
                        return default;
                    }
                    state.MaxPositiveDifference = MaxPositiveDifference;
                } else {
                    MaxNegativeDifference -= item;
                    if (TargetSum - CurrentSum < MaxNegativeDifference) {
                        return default;
                    }
                    state.MaxNegativeDifference = MaxNegativeDifference;
                }
                return NextStateAcceptance.NotRejecting;
            }
        }

        public partial struct P233MovePreviousState : IMovePreviousState<int, (long CurrentSum, long MaxPositiveDifference, long MaxNegativeDifference)> {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Invoke(ref (long CurrentSum, long MaxPositiveDifference, long MaxNegativeDifference) state, int item, bool move) {
                var CurrentSum = state.CurrentSum;
                var MaxPositiveDifference = state.MaxPositiveDifference;
                var MaxNegativeDifference = state.MaxNegativeDifference;
                if (move) {
                    unchecked {
                        CurrentSum -= item;
                    }
                    state.CurrentSum = CurrentSum;
                }
                if (0 <= item) {
                    MaxPositiveDifference += item;
                    state.MaxPositiveDifference = MaxPositiveDifference;
                } else {
                    MaxNegativeDifference += item;
                    state.MaxNegativeDifference = MaxNegativeDifference;
                }
            }
        }

        public partial struct P233StateExInitializer<TList>
            : IInitializeStateEx<int, TList, long, (long CurrentSum, long MaxPositiveDifference, long MaxNegativeDifference)>
            where TList : IList<int> {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public (long CurrentSum, long MaxPositiveDifference, long MaxNegativeDifference) Invoke(TList collection, long state) {
                var p = (long)0;
                var n = (long)0;
                for (var i = collection.Count; i > 0;) {
                    var x = collection[--i];
                    if (0 <= x) {
                        checked {
                            p += x;
                        }
                    } else {
                        checked {
                            n += x;
                        }
                    }
                }
                return (0, p, n);
            }
        }

        public partial struct UInt64Recorder : IO.IAction<UInt64> {

            internal Collections.Generic.RefReturnSupported.List<UInt64> content;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public UInt64Recorder(int v) {
                this.content = new Collections.Generic.RefReturnSupported.List<UInt64>(v);
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Invoke(UInt64 arg) {
                this.content.Add(arg);
            }
        }

        public static Collections.Generic.RefReturnSupported.List<UInt64> SolveP233(int[] collection, long target) {
            var mover = new P233MoveNextState(target);
            var recorder = new UInt64Recorder(0);
            SolveManyBranchAndBound<int, int[], long, (long, long, long), P233StateExInitializer<int[]>, UInt64Recorder, P233MoveNextState, P233MoveNextState, P233MovePreviousState>(collection, 0, DefaultConstructor.Invoke<P233StateExInitializer<int[]>>(), ref recorder, mover, mover, DefaultConstructor.Invoke<P233MovePreviousState>());
            return recorder.content;
        }

        public partial struct FStack : IFoldingStack<bool, (BitArrayUnchecked Solution, long CurrentSum, int Count, bool LastMove, long MaxNegativeDifference, long MaxPositiveDifference)> {

            internal readonly BitArrayUnchecked m_BitArray;

            private uint m_Count;

            private readonly uint m_Capacity;

            private readonly int[] m_Collection;

            private readonly uint m_NegativeCount;

            private long m_CurrentSum;

            internal long m_MaxPositiveDifference;

            internal long m_MaxNegativeDifference;

            private partial struct Comparer : IComparer<int> {

                public int Compare(int x, int y) {
                    return x >= y ? (x == y ? 0 : 1) : -1;
                }
            }

            public FStack(int[] collection) {
                ArrayModule.Sort(collection, default(Comparer), 0, collection.Length, ArrayModule.Null);
                var count = unchecked((uint)collection.Length);
                var t = Array.BinarySearch(collection, 0);
                if (0 > t) {
                    t = ~t;
                }
                var a = new BitArrayUnchecked(count);
                var n = (long)0;
                var p = (long)0;
                var ignored = collection.All((x) => {
                    ref var o = ref (0 > x ? ref n : ref p);
                    unchecked {
                        o += x;
                    }
                    return true;
                });
                this.m_BitArray = a;
                this.m_Count = 0;
                this.m_Capacity = count;
                this.m_Collection = collection;
                this.m_NegativeCount = unchecked((uint)t);
                this.m_CurrentSum = 0;
                this.m_MaxPositiveDifference = p;
                this.m_MaxNegativeDifference = n;
            }

            public bool IsEmpty {

                get => this.m_Count <= 0;
            }

            public (BitArrayUnchecked Solution, long CurrentSum, int Count, bool LastMove, long MaxNegativeDifference, long MaxPositiveDifference) Accumulate {

                get => (this.m_BitArray, this.m_CurrentSum, checked((int)this.m_Count), this.m_BitArray[this.m_Count - 1], this.m_MaxNegativeDifference, this.m_MaxPositiveDifference);
            }

            public void Push(bool item) {
                var count = this.m_Count;
                var aaa = this.m_Collection;
                if (aaa.Length > count) {
                    var vv = aaa[count];
                    ref var o = ref (m_NegativeCount > count ? ref this.m_MaxNegativeDifference : ref this.m_MaxPositiveDifference);
                    unchecked {
                        o -= vv;
                    }
                    unchecked {
                        this.m_CurrentSum += item ? vv : 0;
                    }
                    this.m_BitArray.Set(count, item);
                    unchecked {
                        ++count;
                    }
                    this.m_Count = count;
                    return;
                }
                throw new InvalidOperationException();
            }

            public void Pop(bool item) {
                var count = (long)this.m_Count;
                unchecked {
                    --count;
                }
                if (0 <= count) {
                    var vv = this.m_Collection[count];
                    ref var o = ref (m_NegativeCount > count ? ref this.m_MaxNegativeDifference : ref this.m_MaxPositiveDifference);
                    unchecked {
                        o += vv;
                    }
                    unchecked {
                        this.m_CurrentSum -= item ? vv : 0;
                    }
                    this.m_Count = unchecked((uint)count);
                    return;
                }
                throw new InvalidOperationException();
            }

            public (BitArrayUnchecked Solution, long CurrentSum, int Count, bool LastMove, long MaxNegativeDifference, long MaxPositiveDifference) PeekAccumulatePop() {
                var count = (long)this.m_Count;
                unchecked {
                    --count;
                }
                if (0 <= count) {
                    var vv = this.m_Collection[count];
                    var no = this.m_MaxNegativeDifference;
                    var po = this.m_MaxPositiveDifference;
                    var item = this.m_BitArray[count];
                    ref var o = ref (m_NegativeCount > count ? ref this.m_MaxNegativeDifference : ref this.m_MaxPositiveDifference);
                    unchecked {
                        o += vv;
                    }
                    var v = this.m_CurrentSum;
                    if (item) {
                        this.m_CurrentSum = v - vv;
                    }
                    this.m_Count = unchecked((uint)count);
                    return (this.m_BitArray, v, checked((int)this.m_Count), item, no, po);
                }
                throw new InvalidOperationException();
            }

            public (BitArrayUnchecked Solution, long CurrentSum, int Count, bool LastMove, long MaxNegativeDifference, long MaxPositiveDifference) PushPeekAccumulate(bool item) {
                this.Push(item);
                return this.Accumulate;
            }
        }

        public partial struct BitArrayUnchecked {

            private readonly UInt64[] m_array;

            public bool this[long index] {

                get {
                    return 0 != (this.m_array[index >> 8] & (UInt64)1 << (unchecked((int)index) & (64 - 1)));
                }

                set {
                    if (value) {
                        this.m_array[index >> 8] |= ((UInt64)1 << (unchecked((int)index) & (64 - 1)));
                    } else {
                        this.m_array[index >> 8] &= ~((UInt64)1 << (unchecked((int)index) & (64 - 1)));
                    }
                }
            }

            public void Set(long index, bool value) {
                if (value) {
                    this.m_array[index >> 8] |= ((UInt64)1 << (unchecked((int)index) & (64 - 1)));
                } else {
                    this.m_array[index >> 8] &= ~((UInt64)1 << (unchecked((int)index) & (64 - 1)));
                }
            }

            public BitArrayUnchecked(long bitCount) {
                var c = (bitCount >> 8);
                if (0 != (unchecked((int)bitCount) & (64 - 1))) {
                    unchecked {
                        ++c;
                    }
                }
                var b = new UInt64[c];
                this.m_array = b;
            }

            internal BitArrayUnchecked(UInt64[] v) {
                this.m_array = v;
            }

            public BitArrayUnchecked Clone() {
                return new BitArrayUnchecked(this.m_array.Clone() as UInt64[]);
            }
        }
    }

    public static partial class Aadfadfdsf {

        public static TFoldA1Impl<T, TBinOp, TBinOpA1, TEnumerable, TEnumerator> Fold<T, TBinOp, TBinOpA1, TEnumerable, TEnumerator>(TBinOp binOp)
            where TBinOp : IO.IFunc<T, TBinOpA1>
            where TBinOpA1 : IO.IFunc<T, T>
            where TEnumerable : IEnumerable<T, TEnumerator>
            where TEnumerator : IEnumerator<T> {
            return new TFoldA1Impl<T, TBinOp, TBinOpA1, TEnumerable, TEnumerator>(binOp);
        }

        public readonly partial struct TFoldA1Impl<T, TBinOp, TBinOpA1, TEnumerable, TEnumerator>
            : IO.IFunc<T, TFoldA2Impl<T, TBinOp, TBinOpA1, TEnumerable, TEnumerator>>
            where TBinOp : IO.IFunc<T, TBinOpA1>
            where TBinOpA1 : IO.IFunc<T, T>
            where TEnumerable : IEnumerable<T, TEnumerator>
            where TEnumerator : IEnumerator<T> {

            private readonly TBinOp binOp;

            public TFoldA1Impl(TBinOp binOp) {
                this.binOp = binOp;
            }

            public TFoldA2Impl<T, TBinOp, TBinOpA1, TEnumerable, TEnumerator> Invoke(T arg) {
                return new TFoldA2Impl<T, TBinOp, TBinOpA1, TEnumerable, TEnumerator>(this.binOp, arg);
            }
        }

        public readonly partial struct TFoldA2Impl<T, TBinOp, TBinOpA1, TEnumerable, TEnumerator>
            : IO.IFunc<TEnumerable, T>
            where TBinOp : IO.IFunc<T, TBinOpA1>
            where TBinOpA1 : IO.IFunc<T, T>
            where TEnumerable : IEnumerable<T, TEnumerator>
            where TEnumerator : IEnumerator<T> {

            private readonly TBinOp binOp;

            private readonly T arg;

            public TFoldA2Impl(TBinOp binOp, T arg) {
                this.binOp = binOp;
                this.arg = arg;
            }

            public T Invoke(TEnumerable arg) {
                var result = this.arg;
                var binOp = this.binOp;
                var i = arg.GetEnumerator();
                for (; i.MoveNext();) {
                    result = binOp.Invoke(result).Invoke(i.Current);
                }
                i.Dispose();
                return result;
            }
        }
    }

    public partial class Program {

        private static AsyncLocal<long> item_id_1 = new AsyncLocal<long>();

        private static AsyncLocal<Queue<long>> collection_1 = new AsyncLocal<Queue<long>>();

        private static AsyncLocal<Random> random = new AsyncLocal<Random>();



        [Property(MaxTest = 40000, QuietOnSuccess = true)]
        public bool Test_1() {
            var ff = 2345;
            var rr = GetRandom();
            {
                var deque0 = new LinkedList<long>();
                var deque1 = new Queue<long>(0);
                var iid = 1001;
                for (var i = 0; 300 > i; ++i) {
                    var m = rr.NextDouble();
                    if (m < 0.150) {
                        if (deque0.Count > 0) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                        continue;
                    } else if (m < 0.425) {
                        {
                            var d = iid++;
                            deque0.AddLast(d);
                            deque1.Push(d);
                        }
                    } else if (m < 0.475) {
                        if (deque0.Count >= ff) {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            var d = iid++;
                            deque0.AddLast(d);
                            deque1.Push(d);
                        }
                    } else if (m < 0.490) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                    } else if (m < 0.500) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = deque0.Count;
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                    } else if (m < 0.650) {
                        if (deque0.Count > 0) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                        continue;
                    } else if (m < 0.925) {
                        {
                            var d = iid++;
                            deque0.AddFirst(d);
                            deque1.Unshift(d);
                        }
                    } else if (m < 0.975) {
                        if (deque0.Count >= ff) {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            var d = iid++;
                            deque0.AddFirst(d);
                            deque1.Unshift(d);
                        }
                    } else if (m < 0.990) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                    } else if (m < 1.000) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = deque0.Count;
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                    }
                    {
                        var s0 = deque0.ToArray();
                        var s1 = deque1.ToArray();
                        var ss = s0.SequenceEqual(s1);
                        if (!ss) {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        [Property(MaxTest = 50000, QuietOnSuccess = true)]
        public bool Test_2() {
            var ff = 2345;
            var rr = GetRandom();
            {
                var cc = rr.Next(100);
                var deque0 = new LinkedList<long>();
                var deque1 = new Queue<long>(cc);
                var iid = 1001;
                for (var i = 0; 150 > i; ++i) {
                    var m = rr.NextDouble();
                    if (m < 0.150) {
                        if (deque0.Count > 0) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                        continue;
                    } else if (m < 0.425) {
                        {
                            var d = iid++;
                            deque0.AddLast(d);
                            deque1.Push(d);
                        }
                    } else if (m < 0.475) {
                        if (deque0.Count >= ff) {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            var d = iid++;
                            deque0.AddLast(d);
                            deque1.Push(d);
                        }
                    } else if (m < 0.490) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                    } else if (m < 0.500) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = deque0.Count;
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                    } else if (m < 0.650) {
                        if (deque0.Count > 0) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                        continue;
                    } else if (m < 0.925) {
                        {
                            var d = iid++;
                            deque0.AddFirst(d);
                            deque1.Unshift(d);
                        }
                    } else if (m < 0.975) {
                        if (deque0.Count >= ff) {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            var d = iid++;
                            deque0.AddFirst(d);
                            deque1.Unshift(d);
                        }
                    } else if (m < 0.990) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                    } else if (m < 1.000) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = deque0.Count;
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                    }
                    {
                        var s0 = deque0.ToArray();
                        var s1 = deque1.ToArray();
                        var ss = s0.SequenceEqual(s1);
                        if (!ss) {
                            return false;
                        }
                    }
                    {
                        var s1 = deque1.ToArray();
                        var s1a = deque1.AsEnumerable().ToArray();
                        var ssa = s1.SequenceEqual(s1a);
                        if (!ssa) {
                            return false;
                        }
                    }
                }
                return true;
            }
        }


        private partial class AA : Collections.Generic.IStack<int>, IEnumerable<int> {

            private partial struct AAA : IFunc<int?, int, int?> {

                public int? Invoke(int? arg1, int arg2) {
                    return !(arg1 < arg2) ? arg2 : arg1;
                }
            }

            private partial struct AAAss : IFunc<Plain.ValueTypes.Stack<(int, int?)>>, IFunc<int, Plain.ValueTypes.Stack<(int, int?)>> {

                public Stack<(int, int?)> Invoke() {
                    return new Stack<(int, int?)>(0);
                }

                public Stack<(int, int?)> Invoke(int arg) {
                    return new Stack<(int, int?)>(arg);
                }
            }

            private Plain.ValueTypes.FoldingStack<int, int?, AAA, Plain.ValueTypes.Stack<(int Item, int?)>> _;

            public AA() {
                this._ = Plain.ValueTypes.FoldingStack<int, int?, AAA, Plain.ValueTypes.Stack<(int, int?)>>.Create<AAAss>();
            }

            public AA(int capacity) {
                this._ = Plain.ValueTypes.FoldingStack<int, int?, AAA, Plain.ValueTypes.Stack<(int, int?)>>.Create<AAAss>(capacity);
            }

            public bool IsEmpty {

                get => this._.IsEmpty;
            }

            public int? Min {

                get => this._.Accumulate;
            }

            public int Pop() {
                return this._.Pop();
            }

            public int Peek() {
                return this._.Peek();
            }

            public void Push(int item) {
                this._.Push(item);
            }

            public bool TryPush(int item) {
                return this._.TryPush(item);
            }

            public bool TryPeek(out int item) {
                return this._.TryPeek(out item);
            }

            public bool TryPop(out int item) {
                return this._.TryPop(out item);
            }

            public IEnumerator<int> GetEnumerator() {
                var b = this._.data.m_buffer;
                var c = this._.data.m_count;
                for (; c > 0;) {
                    yield return b[--c].Item1;
                }
            }


            private partial struct Adfsad : IFunc<(int, int?), int> {

                public int Invoke((int, int?) arg) {
                    return arg.Item1;
                }
            }

            public int[] ToArray() {
                return this._.data.ToArray<int, Adfsad>();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                throw new NotImplementedException();
            }
        }


        private partial class AB : Collections.Generic.IStack<int>, IEnumerable<int> {

            private System.Collections.Generic.Stack<int> _;

            public AB() {
                this._ = new System.Collections.Generic.Stack<int>();
            }

            public AB(int capacity) {
                this._ = new System.Collections.Generic.Stack<int>(capacity);
            }

            public int Count {

                get {
                    return this._.Count;
                }
            }


            public bool IsEmpty {

                get => this._.Count <= 0;
            }

            public int? Min {

                get => (!this.IsEmpty ? (int?)this._.Min() : null);
            }

            public int Pop() {
                return this._.Pop();
            }

            public int Peek() {
                return this._.Peek();
            }

            public void Push(int item) {
                this._.Push(item);
            }

            public bool TryPush(int item) {
                try {
                    this._.Push(item);
                } catch (OutOfMemoryException) {
                    return false;
                }
                return true;
            }

            public bool TryPeek(out int item) {
                return this._.TryPeek(out item);
            }

            public bool TryPop(out int item) {
                return this._.TryPop(out item);
            }

            public IEnumerator<int> GetEnumerator() {
                return this._.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return this._.GetEnumerator();
            }
        }

        /*
        [Property(MaxTest = 100, QuietOnSuccess = true)]
        public bool Test_X100() {
            return true;
        }

        [Property(MaxTest = 1000, QuietOnSuccess = true)]
        public bool Test_X1000() {
            return true;
        }

        [Property(MaxTest = 10000, QuietOnSuccess = true)]
        public bool Test_X10000() {
            return true;
        }

        [Property(MaxTest = 100000, QuietOnSuccess = true)]
        public bool Test_X100000() {
            return true;
        }

        [Property(MaxTest = 1000000, QuietOnSuccess = true)]
        public bool Test_X1000000() {
            return true;
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_XA3300000000() {
            var a = false;
            for (var i = 0UL; 3300000000 > i; ++i) {
                a ^= a;
            }
            return !a;
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_X1A330000000() {
            var a = (bool?)false;
            for (var i = 0UL; 330000000 > i; ++i) {
                a ^= null;
            }
            return !a.GetValueOrDefault();
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_X2A330000000() {
            var a = (bool?)false;
            for (var i = 0UL; 330000000 > i; ++i) {
                a ^= DefaultConstructor.Invoke<bool?>();
            }
            return !a.GetValueOrDefault();
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_X3A330000000() {
            var a = (bool?)false;
            for (var i = 0UL; 330000000 > i; ++i) {
                a ^= DefaultConstructor.Invoke<bool>();
            }
            return !a.GetValueOrDefault();
        }
        */

        [Property(MaxTest = 500, QuietOnSuccess = true)]
        public bool Test_3() {
            var ff = 2345;
            var rr = GetRandom();
            {
                var cc = rr.Next(100);
                for (var g = 15; g > 0; --g) {
                    var deque0 = new AB();
                    var deque1 = new AA();
                    var iid = 1001;
                    for (var i = 0; 300 > i; ++i) {
                        var m = rr.NextDouble();
                        if (m < 0.150) {
                            if (deque0.Count > 0) {
                                deque0.Pop();
                                deque1.Pop();
                            }
                            continue;
                        } else if (m < 0.850) {
                            {
                                var d = iid++;
                                deque0.Push(d);
                                deque1.Push(d);
                            }
                        } else if (m < 0.950) {
                            if (deque0.Count >= ff) {
                                continue;
                            }
                            var n0 = 1 + rr.Next(deque0.Count);
                            for (var n = n0; n > 0; --n) {
                                var d = iid++;
                                deque0.Push(d);
                                deque1.Push(d);
                            }
                        } else if (m < 0.980) {
                            if (deque0.Count > 0) {
                            } else {
                                continue;
                            }
                            var n0 = 1 + rr.Next(deque0.Count);
                            for (var n = n0; n > 0; --n) {
                                deque0.Pop();
                                deque1.Pop();
                            }
                        } else if (m <= 1.000) {
                            if (deque0.Count > 0) {
                            } else {
                                continue;
                            }
                            var n0 = deque0.Count;
                            for (var n = n0; n > 0; --n) {
                                deque0.Pop();
                                deque1.Pop();
                            }
                        }
                        {
                            var s0 = deque0.ToArray();
                            var s1 = deque1.ToArray();
                            var ss = s0.SequenceEqual(s1);
                            if (!ss) {
                                Xunit.Assert.True(false);
                            }
                        }
                        {
                            var s0 = deque0.Min;
                            var s1 = deque1.Min;
                            var ss = s0 == s1;
                            if (!ss) {
                                Xunit.Assert.True(false);
                            }
                        }
                        {
                            var s1 = deque1.ToArray();
                            var s1a = deque1.AsEnumerable().ToArray();
                            var ssa = s1.SequenceEqual(s1a);
                            if (!ssa) {
                                Xunit.Assert.True(false);
                            }
                        }
                    }
                }
                return true;
            }
        }

        private static Random GetRandom() {
            var rr = Program.random.Value;
            if (null == rr) {
                rr = new Random();
                Program.random.Value = rr;
            }
            return rr;
        }

        private static long? dddd1 = default;



        internal static void Printf<T>(System.IO.TextWriter textWriter, T value) {
            var t = new Microsoft.FSharp.Core.PrintfFormat<Microsoft.FSharp.Core.FSharpFunc<T, Microsoft.FSharp.Core.Unit>, System.IO.TextWriter, Microsoft.FSharp.Core.Unit, Microsoft.FSharp.Core.Unit, T>("%A");
            var f = Microsoft.FSharp.Core.PrintfModule.PrintFormatLineToTextWriter(textWriter, t);
            f.Invoke(value);
        }

        private static bool aa2aa(int[] a) {
            var c = a.Length;
            Debug.Assert(c % 2 == 0);
            for (var i = 0; i < c / 2; i++) {
                if (a[i] != 2 * i) {
                    return false;
                }
            }
            for (var i = 0; i < c / 2; i++) {
                if (a[c / 2 + i] != 1 + 2 * i) {
                    return false;
                }
            }
            return true;
        }
        private static bool aa2aa(int[] a, int start, int count) {
            var c = count;
            Debug.Assert(c % 2 == 0);
            for (var i = 0; i < c / 2; i++) {
                if (a[start + i] != 2 * i) {
                    return false;
                }
            }
            for (var i = 0; i < c / 2; i++) {
                if (a[start + c / 2 + i] != 1 + 2 * i) {
                    return false;
                }
            }
            return true;
        }

        private partial struct fff : IO.IFunc<int, int, int>, IComparer<int> {

            public int Compare(int x, int y) {
                return this.Invoke(x, y);
            }

            public int Invoke(int arg1, int arg2) {
                if (arg1 < arg2) {
                    return -1;
                }
                if (arg1 > arg2) {
                    return 1;
                }
                return 0;
            }
        }

        public partial struct DefaultValuedSelector<T, TResult> : IO.IFunc<T, TResult> {

            public TResult Invoke(T arg) {
                return default;
            }
        }

        public partial struct DefaultConstructedValuedSelector<T, TResult>
            : IO.IFunc<T, TResult>
            where TResult : new() {

            public TResult Invoke(T arg) {
                return DefaultConstructor.Invoke<TResult>();
            }
        }

        public static partial class Constant {

            public readonly partial struct Functor<T1, T2> : IO.IFunc<T1, T2, T1> {

                public T1 Invoke(T1 arg1, T2 arg2) {
                    return arg1;
                }
            }
        }

        public static partial class Select {

            public readonly partial struct Functor<TSelector, TFunctorOfT1, TFunctorOfT2, T1, T2>
                : IO.IFunc<TSelector, TFunctorOfT1, TFunctorOfT2>
                where TSelector : IO.IFunc<T1, T2> {

                [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
                public TFunctorOfT2 Invoke(TSelector arg1, TFunctorOfT1 arg2) {
                    if (typeof(TFunctorOfT1) == typeof(T1[]) &&
                        typeof(TFunctorOfT2) == typeof(T2[])) {
                        return (TFunctorOfT2)(object)Array.ConvertAll((T1[])(object)arg2, (x) => arg1.Invoke(x));
                    }
                    throw new NotImplementedException();
                }
            }
        }

        private partial struct asdafsadfa : IO.IFunc<uint, long> {

            [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            public long Invoke(uint arg) {
                return arg * arg - 3;
            }
        }

        private readonly partial struct Product<T> {

            private readonly T product;

            [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            public T GetProduct() {
                return this.product;
            }
        }

        public abstract class KindAsBclType : TypeDelegator {

            protected KindAsBclType(Type delegatingType) : base(delegatingType) {
            }

            protected KindAsBclType() : base() {
            }
        }

        internal abstract class KindUnsafeInstanceAsBclType<T> : TypeDelegator {

            protected KindUnsafeInstanceAsBclType() : base(typeof(T)) {
            }
        }

        public class KindMismatchException : SystemException {
        }

        public abstract partial class KindExpression {

            public static readonly TypeKindExpression Unknown = TypeKindExpression.Create();

            public static readonly FunctionKindExpression Array = FunctionKindExpression.Create(typeof(Array<>));

            public static readonly FunctionKindExpression BclArray = FunctionKindExpression.Create(typeof(System.Array));

            protected abstract string NameImpl {

                get;
            }

            public string Name {

                get {
                    return this.NameImpl;
                }
            }

            protected abstract string FullNameImpl {

                get;
            }

            public string FullName {

                get {
                    return this.FullNameImpl;
                }
            }

            internal KindExpression() {
            }
        }

        public abstract partial class KindExpressionImplBase : KindExpression {

            internal static readonly System.Collections.Concurrent.ConcurrentDictionary<Type, KindExpressionImplBase> s_CachedKinds = new System.Collections.Concurrent.ConcurrentDictionary<Type, KindExpressionImplBase>();

            protected abstract Collections.Generic.ReferenceTypes.LinkedTree<ScopeSegment>.Node ScopeImpl {

                get;
            }

            internal KindExpressionImplBase() : base() {
            }

            protected override string FullNameImpl {

                get {
                    var n = this.Name;
                    var s = this.ScopeImpl;
                    var ss = new Plain.ValueTypes.Stack<Collections.Generic.ReferenceTypes.LinkedTree<ScopeSegment>.Node>(0);
                    while (null != s) {
                        ss.Push(s);
                    }
                    var sb = new System.Text.StringBuilder();
                    foreach (var item in ss) {
                        sb.Append(item.Value.Name);
                        if (item.Value.IsNamespace) {
                            sb.Append('.');
                        } else {
                            sb.Append('+');
                        }
                    }
                    sb.Append(n);
                    return sb.ToString();
                }
            }
        }

        public abstract partial class NullaryKindExpression : KindExpressionImplBase {

            protected abstract Type ImplementImpl {

                get;
            }

            public Type Implement {

                get {
                    return this.ImplementImpl;
                }
            }

            internal NullaryKindExpression() : base() {
            }
        }

        public sealed partial class ConstraintKindExpression : NullaryKindExpression {

            private readonly Type impl;

            private readonly string name;

            private readonly Collections.Generic.ReferenceTypes.LinkedTree<ScopeSegment>.Node scope;

            public ConstraintKindExpression(Type inhabited) {
                if (inhabited.IsGenericTypeDefinition) {
                    throw new InvalidOperationException();
                }
                var impl = inhabited;
                this.impl = impl;
                this.name = impl.Name;
                // TODO
                this.scope = null;
            }

            protected override LinkedTree<ScopeSegment>.Node ScopeImpl {

                get => this.scope;
            }

            protected override string NameImpl {

                get => this.name;
            }

            protected override Type ImplementImpl {

                get => this.impl;
            }
        }

        public sealed partial class TypeKindExpression : NullaryKindExpression {

            private readonly Type impl;

            private readonly string name;

            private readonly Collections.Generic.ReferenceTypes.LinkedTree<ScopeSegment>.Node scope;

            private TypeKindExpression() : base() {
                this.name = "*";
            }

            private TypeKindExpression(Type inhabited) : base() {

                var impl = inhabited;
                this.impl = impl;
                this.name = impl.Name;
                // TODO
                this.scope = null;
            }

            private static partial class Any {

                internal static readonly TypeKindExpression Value = new TypeKindExpression();
            }

            protected override LinkedTree<ScopeSegment>.Node ScopeImpl {

                get => this.scope;
            }

            protected override string NameImpl {

                get => this.name;
            }

            protected override Type ImplementImpl {

                get => this.impl;
            }

            public static TypeKindExpression Create() {
                return Any.Value;
            }

            public static TypeKindExpression Create(Type inhabited) {
                if (inhabited.IsGenericTypeDefinition) {
                    throw new InvalidOperationException();
                }
                if (inhabited == typeof(Array)) {
                    throw new InvalidOperationException();
                }
                var d = KindExpressionImplBase.s_CachedKinds;
                var t = d.GetOrAdd(inhabited, (x) => new TypeKindExpression(x)) as TypeKindExpression;
                if (null == t) {
                    throw new NotImplementedException();
                }
                return t;
            }
        }

        public readonly partial struct ScopeSegment {

            private readonly string name;

            private readonly KindExpression kind;

            public bool IsNamespace {

                get {
                    return null == this.kind;
                }
            }

            public string Name {

                get {
                    return this.name ?? this.kind.Name ?? "";
                }
            }

            public ScopeSegment(string name) {
                if (null == name) {
                    throw new ArgumentNullException(nameof(name));
                }
                this.name = name;
                this.kind = null;
            }

            public ScopeSegment(KindExpression entity) {
                if (null == entity) {
                    throw new ArgumentNullException(nameof(entity));
                }
                this.name = null;
                this.kind = entity;
            }
        }


        private abstract partial class Kinds {

        }

        public static partial class KindSystem {


        }

        public sealed partial class FunctionKindExpression : KindExpressionImplBase {

            private readonly Func<KindExpression, KindExpression> impl;

            private readonly string name;

            private readonly Collections.Generic.ReferenceTypes.LinkedTree<ScopeSegment>.Node scope;

            private readonly ConstraintKindExpression[] constraints;

            private readonly KindExpression parameter_kind;

            private readonly KindExpression return_kind;

            protected override LinkedTree<ScopeSegment>.Node ScopeImpl {

                get => this.scope;
            }

            protected override string NameImpl {

                get => this.name;
            }

            internal FunctionKindExpression(Func<KindExpression, KindExpression> impl, string name, Collections.Generic.ReferenceTypes.LinkedTree<ScopeSegment>.Node scope, ConstraintKindExpression[] constraints, KindExpression parameter_kind, KindExpression return_kind) : base() {
                this.impl = impl;
                this.name = name;
                this.scope = scope;
                this.constraints = constraints;
                this.parameter_kind = parameter_kind;
                this.return_kind = return_kind;
            }

            /*
            private FunctionKindExpression(Type instance) : base() {
            }
            */

            public static FunctionKindExpression Create(Type instance) {
                var s = (FunctionKindExpression)null;
                if (instance.IsGenericType) {
                    if (instance.ContainsGenericParameters) {
                        var a = instance.GetGenericArguments();
                        if (1 == a.Length) {
                            var d = KindExpressionImplBase.s_CachedKinds;
                            s = d.GetOrAdd(instance, (m) => {
                                var impl = (Func<KindExpression, KindExpression>)((type) => {
                                    KindExpression result = null;
                                    if (null != type) {
                                        if (type is TypeKindExpression t) {
                                            if (t == Unknown) {
                                                result = t;
                                            } else {
                                                result = TypeKindExpression.Create(m.MakeGenericType(t.Implement));
                                            }
                                            Debug.Assert(result is TypeKindExpression);
                                            return result;
                                        }
                                        throw new KindMismatchException();
                                    }
                                    throw new ArgumentNullException("type");
                                });
                                var name = m.FullName;
                                return new FunctionKindExpression(
                                    impl,
                                    name,
                                    // TODO
                                    null,
                                    Array_Empty<ConstraintKindExpression>.Value,
                                    KindExpression.Unknown,
                                    KindExpression.Unknown
                                    );
                            }) as FunctionKindExpression;
                            if (null == s) {
                                throw new NotImplementedException();
                            }
                        }
                    }
                } else if (typeof(Array) == instance) {
                    var d = KindExpressionImplBase.s_CachedKinds;
                    s = d.GetOrAdd(instance, (m) => {
                        var impl = (Func<KindExpression, KindExpression>)((type) => {
                            KindExpression result = null;
                            if (null != type) {
                                if (type is TypeKindExpression t) {
                                    if (t == Unknown) {
                                        result = t;
                                    } else {
                                        result = TypeKindExpression.Create(t.Implement.MakeArrayType());
                                    }
                                    Debug.Assert(result is TypeKindExpression);
                                    return result;
                                }
                                throw new KindMismatchException();
                            }
                            throw new ArgumentNullException("type");
                        });
                        var name = m.FullName;
                        return new FunctionKindExpression(
                            impl,
                            name,
                            // TODO
                            null,
                            Array_Empty<ConstraintKindExpression>.Value,
                            KindExpression.Unknown,
                            KindExpression.Unknown
                            );
                    }) as FunctionKindExpression;
                    if (null == s) {
                        throw new NotImplementedException();
                    }
                }
                if (null == s) {
                    throw new InvalidOperationException();
                }
                return s;
            }

            public KindExpression Invoke(KindExpression kind) {
                return this.impl.Invoke(kind);
            }
        }


        private readonly struct adsafsd : IO.IFunc<double, (double Left, double Right)> {

            private readonly double p;

            public adsafsd(double p) {
                this.p = p;
            }

            public (double Left, double Right) Invoke(double arg) {
                var t = p * arg;
                return (t, arg - t);
            }
        }

        public static void GeneratePerfectBinaryTree<T, TSelector>(T[] array, int startExclusive, int order, TSelector selector)
            where TSelector : IO.IFunc<T, (T Left, T Right)> {
            var c = Utilities.SignConverter.ToSignedChecked(Mathematics.Elementary.Math.Pow(2, Utilities.SignConverter.ToUnsignedChecked(order)));
            var j = checked(1 + startExclusive);
            unchecked {
                --c;
            }
            ArrayModule.CheckArraySegmentThrowIfFailed(array, j, c);
            var k = unchecked(1 + j);
            for (; c > 1; c -= 2) {
                var t = array[j++];
                (array[k++], array[k++]) = selector.Invoke(t);
            }
        }

        public static void GeneratePerfectBinaryTree<T, TLeftSelector, TRightSelector>(T[] array, int startExclusive, int order, TLeftSelector left, TRightSelector right)
            where TLeftSelector : IO.IFunc<T, Void<T>, T>
            where TRightSelector : IO.IFunc<Void<T>, T, T> {
            var c = Utilities.SignConverter.ToSignedChecked(Mathematics.Elementary.Math.Pow(2, Utilities.SignConverter.ToUnsignedChecked(order)));
            var j = checked(1 + startExclusive);
            unchecked {
                --c;
            }
            ArrayModule.CheckArraySegmentThrowIfFailed(array, j, c);
            var k = unchecked(1 + j);
            for (; c > 1; c -= 2) {
                var t = array[j++];
                array[k++] = left.Invoke(t, default);
                array[k++] = right.Invoke(default, t);
            }
        }

        [Property(MaxTest = 100000, QuietOnSuccess = true)]
        public static bool Test_Rational64_BinOp_1(uint p0, int q0, uint p1, int q1) {
            var d = 0;
            var r = default(BigRational);
            var e = 0;
            var s = default(Rational64);
            try {
                r = BigRational.FromFraction(p0, q0) + BigRational.FromFraction(p1, q1);
                d = 1;
            } catch (OverflowException) {
                d = 2;
            } catch (DivideByZeroException) {
                d = 3;
            } catch (ArgumentException) {
                d = 4;
            }
            try {
                s = Rational64.FromFraction(p0, q0) + Rational64.FromFraction(p1, q1);
                e = 1;
            } catch (OverflowException) {
                e = 2;
            } catch (DivideByZeroException) {
                e = 3;
            } catch (ArgumentException) {
                e = 4;
            }
            return d == e && r == s;
        }

        [Property(MaxTest = 100000, QuietOnSuccess = true)]
        public static bool Test_Rational64_BinOp_2(uint p0, int q0, uint p1, int q1) {
            var d = 0;
            var r = default(BigRational);
            var e = 0;
            var s = default(Rational64);
            try {
                r = BigRational.FromFraction(p0, q0) - BigRational.FromFraction(p1, q1);
                d = 1;
            } catch (OverflowException) {
                d = 2;
            } catch (DivideByZeroException) {
                d = 3;
            } catch (ArgumentException) {
                d = 4;
            }
            try {
                s = Rational64.FromFraction(p0, q0) - Rational64.FromFraction(p1, q1);
                e = 1;
            } catch (OverflowException) {
                e = 2;
            } catch (DivideByZeroException) {
                e = 3;
            } catch (ArgumentException) {
                e = 4;
            }
            return d == e && r == s;
        }

        [Property(MaxTest = 100000, QuietOnSuccess = true)]
        public static bool Test_Rational64_BinOp_3(uint p0, int q0, uint p1, int q1) {
            var d = 0;
            var r = default(BigRational);
            var e = 0;
            var s = default(Rational64);
            try {
                r = BigRational.FromFraction(p0, q0) * BigRational.FromFraction(p1, q1);
                d = 1;
            } catch (OverflowException) {
                d = 2;
            } catch (DivideByZeroException) {
                d = 3;
            } catch (ArgumentException) {
                d = 4;
            }
            try {
                s = Rational64.FromFraction(p0, q0) * Rational64.FromFraction(p1, q1);
                e = 1;
            } catch (OverflowException) {
                e = 2;
            } catch (DivideByZeroException) {
                e = 3;
            } catch (ArgumentException) {
                e = 4;
            }
            return d == e && r == s;
        }

        [Property(MaxTest = 100000, QuietOnSuccess = true)]
        public static bool Test_Rational64_BinOp_3_1(uint p0, int q0, uint p1, int q1) {
            var d = 0;
            var r = default(BigRational);
            var e = 0;
            var s = default(Rational64);
            try {
                r = BigRational.FromFraction(p0, q0) * BigRational.FromFraction(p1, q1);
                d = 1;
            } catch (OverflowException) {
                d = 2;
            } catch (DivideByZeroException) {
                d = 3;
            } catch (ArgumentException) {
                d = 4;
            }
            try {
                s = Rational64.Multiply(Rational64.FromFraction(p0, q0), Rational64.FromFraction(p1, q1));
                e = 1;
            } catch (OverflowException) {
                e = 2;
            } catch (DivideByZeroException) {
                e = 3;
            } catch (ArgumentException) {
                e = 4;
            }
            return d == e && r == s;
        }

        [Property(MaxTest = 100000, QuietOnSuccess = true)]
        public static bool Test_Rational64_BinOp_4(uint p0, int q0, uint p1, int q1) {
            var d = 0;
            var r = default(BigRational);
            var e = 0;
            var s = default(Rational64);
            try {
                r = BigRational.FromFraction(p0, q0) / BigRational.FromFraction(p1, q1);
                d = 1;
            } catch (OverflowException) {
                d = 2;
            } catch (DivideByZeroException) {
                d = 3;
            } catch (ArgumentException) {
                d = 4;
            }
            try {
                s = Rational64.FromFraction(p0, q0) / Rational64.FromFraction(p1, q1);
                e = 1;
            } catch (OverflowException) {
                e = 2;
            } catch (DivideByZeroException) {
                e = 3;
            } catch (ArgumentException) {
                e = 4;
            }
            return d == e && r == s;
        }

        [Property(MaxTest = 200000, QuietOnSuccess = true)]
        public static bool Test_Rational64_Create_1(uint p, int q) {
            var d = 0;
            var r = default(BigRational);
            var e = 0;
            var s = default(Rational64);
            try {
                r = BigRational.FromFraction(p, q);
                d = 1;
            } catch (OverflowException) {
                d = 2;
            } catch (DivideByZeroException) {
                d = 3;
            } catch (ArgumentException) {
                d = 4;
            }
            try {
                s = Rational64.FromFraction(p, q);
                e = 1;
            } catch (OverflowException) {
                e = 2;
            } catch (DivideByZeroException) {
                e = 3;
            } catch (ArgumentException) {
                e = 4;
            }
            return d == e && r == s;
        }

        private static void dsfasdf<T>() {
        }

        private static int Main(string[] args) {
            {
                var adfs = new Int128[] { -2, 3, 4, -5, -6, }.AsArray();
                var c = Enumerable.FoldLeft<
                    Int128,
                    Int128,
                    Curry<Int128, Int128, Int128, MultiplyChecked.Functor<Int128>>.C0.C1,
                    Curry<Int128, Int128, Int128, MultiplyChecked.Functor<Int128>>.C0.C1.C2,
                    BclArrayAsArray<Int128>,
                    Array<Int128>.Enumerator
                >.Value.Invoke(default).Invoke(100).Invoke(adfs);
                Printf(System.Console.Out, c);
                Console.ReadKey(true);
                return 0;
            }
            {
                var arg = new int[] { -2, 3, 4, -5, -6, }.AsArray();
                var result = 100;
                var i = arg.GetEnumerator();
                for (; i.MoveNext();) {
                    result = result * i.Current;
                }
                i.Dispose();
                var c = result;
                Printf(System.Console.Out, c);
                Console.ReadKey(true);
                return 0;
            }
            {
                var adfs = new int[] { -2, 3, 4, -5, -6, }.AsArray();
                var c = Enumerable.FoldLeft<
                    int,
                    int,
                    Curry<int, int, int, MultiplyChecked.Functor<int>>.C0.C1,
                    Curry<int, int, int, MultiplyChecked.Functor<int>>.C0.C1.C2,
                    BclArrayAsArray<int>,
                    Array<int>.Enumerator
                >.Value.Invoke(default).Invoke(100).Invoke(adfs);
                Printf(System.Console.Out, c);
                Console.ReadKey(true);
                return 0;
            }
            {
                var arg = new int[] { -2, 3, 4, -5, -6, }.AsArray();
                var c = arg.Aggregate(100, (x, y) => checked(x * y));
                Printf(System.Console.Out, c);
                Console.ReadKey(true);
                return 0;
            }
            {
                var sssafd = Test_Rational64_BinOp_1(1, 1, 1, -1);
                Printf(System.Console.Out, sssafd);
                Console.ReadKey(true);
                return 0;
            }
            {
                var sssafd = Test_Rational64_BinOp_4(3, -54, 6, -7);
                Printf(System.Console.Out, sssafd);
                Console.ReadKey(true);
                return 0;
            }
            {
                var a = new double[4];
                var p = 0.4;
                a[1] = 1.0;
                GeneratePerfectBinaryTree(a, 0, 2, new adsafsd(p));
                Printf(System.Console.Out, a);
                Console.ReadKey(true);
                return 0;
            }
            {
                var a = new double[2];
                var p = 0.4;
                a[1] = 1.0;
                GeneratePerfectBinaryTree(a, 0, 1, new adsafsd(p));
                Printf(System.Console.Out, a);
                Console.ReadKey(true);
                return 0;
            }
            {
                var a = new double[2];
                var p = 0.4;
                a[1] = 1.0;
                GeneratePerfectBinaryTree(a, 0, 1, new adsafsd(p));
                Printf(System.Console.Out, a);
                Console.ReadKey(true);
                return 0;
            }
            {
                var a = new double[0];
                var p = 0.4;
                // a[1] = 1.0;
                GeneratePerfectBinaryTree(a, -1, 0, new adsafsd(p));
                Printf(System.Console.Out, a);
                Console.ReadKey(true);
                return 0;
            }
            {
                var a = new double[1];
                var p = 0.4;
                // a[1] = 1.0;
                GeneratePerfectBinaryTree(a, 0, 0, new adsafsd(p));
                Printf(System.Console.Out, a);
                Console.ReadKey(true);
                return 0;
            }
            {
                var a = new double[8];
                var p = 0.4;
                a[1] = 1.0;
                GeneratePerfectBinaryTree(a, 0, 0, new adsafsd(p));
                Printf(System.Console.Out, a);
                Console.ReadKey(true);
                return 0;
            }
            {
                dsfasdf<int>();
                {
                    var asdfa = KindExpression.Array.Invoke(TypeKindExpression.Create(typeof(ulong)));
                    if (asdfa is TypeKindExpression t) {
                        var dsfa = t.Implement;
                        Console.WriteLine(dsfa.FullName);
                    }
                }
                {
                    var asdfa = KindExpression.BclArray.Invoke(TypeKindExpression.Create(typeof(ulong)));
                    if (asdfa is TypeKindExpression t) {
                        var dsfa = t.Implement;
                        Console.WriteLine(dsfa.FullName);
                    }
                }
                Console.ReadKey(true);
                return 0;
            }
            {
                Select.Functor<asdafsadfa, uint[], long[], uint, long> a;
                var sdfa = a.Invoke(default(asdafsadfa), new uint[] { 3, 4, 5 });
                Printf(Console.Out, sdfa);
                Console.ReadKey(true);
                return 0;
            }
            {
                MultiplyChecked.Functor<Int128> mul;
                var e = mul.Invoke(7, 110);
                Console.WriteLine(e);
                MultiplyChecked.Register<string>((x, y) => $@"checked({x} * {y})");
                {
                    MultiplyChecked.Functor<string> pol;
                    var f = pol.Invoke("7", "110");
                    Console.WriteLine(f);
                }
                try {
                    MultiplyChecked.Register<int>((x, y) => 2 * x + y);
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString()); ;
                }
                {
                    MultiplyChecked.Functor<int> pol;
                    var f = pol.Invoke(7, 110);
                    Console.WriteLine(f);
                }
                {
                    var f = Operators.Checked.Multiply((UInt128)Int64.MaxValue, 11033333333333333333);
                    Console.WriteLine(f);
                    Console.WriteLine(f.ToString());
                }
                // var d = IO.TFunc<int, int, int>.Invoke(a, 7, 11);
                // Console.WriteLine(typeof(Int32).IsPrimitive);
                // var c = MultiplyChecked.Typed<int>.Value(7, 11);
                // Console.WriteLine(d);
                // Console.WriteLine(c);
                Console.ReadKey(true);
                return 0;
            }
            {
                for (long i = UInt32.MinValue; i <= UInt32.MaxValue; ++i) {
                    var v = unchecked((UInt32)i);

                    var f = Mathematics.Elementary.Math.Sqrt_A_F(v);
                    var g = Mathematics.Elementary.Math.Sqrt_A_I(v);
                    if (f != g) {
                        Console.WriteLine($@"{v,8}: {f,8} != {g,-8}");
                        Console.WriteLine("!!!");
                    }
                }
                Console.WriteLine("...");
                Console.ReadKey(true);
                return 0;
            }
            {
                var sdafa = false;
                Console.WriteLine(Utilities.SizeOfModule.BitSizeOf<Int128>());
                Console.ReadKey(true);
                return 0;
            }
            {
                var rrr = GetRandom();
                var a = new Collections.Generic.RefReturnSupported.List<int>(0);
                var b = new Collections.Generic.RefReturnSupported.List<long>(0);
                var g = new Graph<ulong, double>(0);
                for (var i = 0; 6 > i; ++i) {
                    a.Add(g.AddNode((ulong)rrr.Next()));
                }
                for (var i = 0; 12 > i; ++i) {
                    var s = rrr.Next(a.Count);
                    var t = rrr.Next(a.Count);
                    b.Add(g.AddLink(s, t, rrr.NextDouble()));
                }
                var enc = System.Text.Encoding.UTF8;
                var xws = new System.Xml.XmlWriterSettings {
                    Async = false,
                    CheckCharacters = true,
                    CloseOutput = false,
                    ConformanceLevel = System.Xml.ConformanceLevel.Document,
                    DoNotEscapeUriAttributes = false,
                    Encoding = enc,
                    NamespaceHandling = System.Xml.NamespaceHandling.OmitDuplicates,
                    NewLineHandling = System.Xml.NewLineHandling.Entitize,
                    NewLineOnAttributes = false,
                    OmitXmlDeclaration = false,
                    WriteEndDocumentOnClose = true
                };

                var sb = new System.IO.MemoryStream();
                var xw = System.Xml.XmlWriter.Create(sb, xws);
                xw.WriteStartElement("DirectedGraph", "http://schemas.microsoft.com/vs/2009/dgml");
                xw.WriteStartElement("Nodes");
                foreach (var item in a) {
                    xw.WriteStartElement("Node");
                    xw.WriteAttributeString("Id", $@"N{item}");
                    xw.WriteAttributeString("Label", $@"{item}: {g.GetNodeValue(item)}");
                    xw.WriteEndElement();
                }
                xw.WriteEndElement();
                xw.WriteStartElement("Links");
                foreach (var item in b) {
                    xw.WriteStartElement("Link");
                    xw.WriteAttributeString("Source", $@"N{g.GetSourceNode(item)}");
                    xw.WriteAttributeString("Target", $@"N{g.GetTargetNode(item)}");
                    xw.WriteAttributeString("Label", $@"{g.GetLinkIdSourceNodeLocal(item)}: {g.GetLinkValue(item)}");
                    xw.WriteEndElement();
                }
                xw.WriteEndElement();
                xw.WriteEndElement();
                xw.Close();
                sb.Seek(0, System.IO.SeekOrigin.Begin);
                var fef = new System.IO.StreamReader(sb, enc);
                var sdfsas = fef.ReadToEnd();

                System.IO.File.WriteAllText("ttt233.dgml", sdfsas, enc);
                /*
                var g1 = g.Select<affasdfasdf, Void, DefaultValuedSelector<ulong, affasdfasdf>, VoidValuedSelector<double>>(DefaultConstructor.Invoke<DefaultValuedSelector<ulong, affasdfasdf>>(), DefaultConstructor.Invoke<VoidValuedSelector<double>>());

                GraphModule.aaaa(ref g1);
                */
                // affasdfasdf e = default;
                Console.WriteLine(sdfsas);
                Console.ReadKey(true);
                return 0;



            }
            {
                var rrr = GetRandom();
                var a = new Collections.Generic.RefReturnSupported.List<long>(0);
                var b = new Collections.Generic.RefReturnSupported.List<long>(0);
                var g = new Graph<ulong, double>(0);
                for (var i = 0; 12 > i; ++i) {
                    a.Add(g.AddNode((ulong)rrr.Next()));
                }
                for (var i = 0; 133 > i; ++i) {
                    var s = rrr.Next(a.Count);
                    var t = rrr.Next(a.Count);
                    b.Add(g.AddLink(s, t, rrr.NextDouble()));
                }
                Console.ReadKey(true);
                return 0;
            }
            if (false) {
                var adsfa = new long[] { 1, -3, 4, 5, 7, 9, -2, };
                var asdfa = adsfa;
                foreach (var item in asdfa) {
                    Console.WriteLine(item);
                }
                Console.ReadKey(true);
                return 0;
            }
            {
                var adsfa = new long[] { 1, -3, 4, 5, 7, 9, -2, };
                var asdfa = adsfa.ToReadOnly();
                for (var i = 0; asdfa.Length > i; ++i) {
                    Console.WriteLine(asdfa[i]);
                }
                Console.ReadKey(true);
                return 0;
            }
            {
                var adsfa = new long[] { 1, -3, 4, 5, 7, 9, -2, };
                var asdfa = adsfa.ToReadOnly();
                foreach (var item in asdfa) {
                    Console.WriteLine(item);
                }
                Console.ReadKey(true);
                return 0;
            }
            {
                ref var tree = ref BinaryTreeModule.Create(3);
                BinaryTreeModule.AddSorted(ref tree, 4, DefaultConstructor.Invoke<fff>());
                BinaryTreeModule.AddSorted(ref tree, 0, DefaultConstructor.Invoke<fff>());
                BinaryTreeModule.AddSorted(ref tree, 2, DefaultConstructor.Invoke<fff>());
                BinaryTreeModule.AddSorted(ref tree, -5, DefaultConstructor.Invoke<fff>());
                BinaryTreeModule.AddSorted(ref tree, 3, DefaultConstructor.Invoke<fff>());
                BinaryTreeModule.AddSorted(ref tree, 2, DefaultConstructor.Invoke<fff>());
                Console.WriteLine(tree.ToString<int>());
                Console.ReadKey(true);
                return 0;
            }
            {
                var a = "(x,[x])";
                var s0 = new List<string> { };
                var s1 = new List<string> { "x", };
                var s2 = new List<string> { a, };
                var s = new List<List<string>> { s0, s1, s2, };
                do {
                    var sn = s[s.Count - 1];
                    s.Add(sn.SelectMany((x) => x.Select((ch, i) => (ch, i)).Where((p) => 'x' == p.ch).Select((p) => x.Substring(0, p.i) + a + x.Substring(1 + p.i))).Concat(sn.SelectMany((x) => x.Select((ch, i) => (ch, i)).Where((p) => ']' == p.ch).Select((p) => x.Substring(0, p.i) + ",x" + x.Substring(p.i)))).Distinct().ToList());
                } while (10 > s.Count);
                foreach (var item in s) {
                    Console.Out.WriteLine(item.Count);
                }
                Console.ReadKey(true);
                return 0;

            }
            {
                var cc = 200000000;
                var s = 7;
                var c = System.Linq.Enumerable.Range(10000, s);
                c = c.Concat(System.Linq.Enumerable.Range(0, cc));
                c = c.Concat(System.Linq.Enumerable.Range(20000, 11));
                var d = c.ToArray();

                ArrayModule.InterleaveInPlace(d, s, cc);
                Console.Out.WriteLine(aa2aa(d, s, cc));
                Console.ReadKey(true);
                return 0;
            }
            /*{
                {
                    var c = Enumerable.Range(0, 0).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 2).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 4).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 2).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 4).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 6).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 8).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 10).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 12).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 26).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 28).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 30).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 80).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 82).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                {
                    var c = Enumerable.Range(0, 84).ToArray();
                    ArrayModule.InterleavePartialInternal(c, 0, c.Length);
                    Console.Out.WriteLine($@"{c.Length,-4}: {aa2aa(c),-8}");
                }
                Console.ReadKey(true);
                return 0;
            }*/
            {
                var st = new Stopwatch();
                var c = new int[] { -3, -2, -1, -1, 0, 1, 2, 2, 3 };
                st.Start();
                var s = AAAf.SolveP233(c, 7);
                st.Stop();
                Console.Out.WriteLine("...");
                Console.Out.WriteLine(st.Elapsed);
                Console.Out.WriteLine(s.Count);
                Console.Out.WriteLine("...");
                c = System.Linq.Enumerable.Range(1, 26).ToArray();
                st.Restart();
                s = AAAf.SolveP233(c, 200);
                st.Stop();
                Console.Out.WriteLine("...");
                Console.Out.WriteLine(st.Elapsed);
                Console.Out.WriteLine(s.Count);
                Console.Out.WriteLine("...");
                Console.ReadKey(true);
                return 0;
            }
            {
                var c = new int[] { -3, -2, -1, -1, 0, 1, 2, 2, 3 };
                var s = AAAf.dsafsf(c, 7);
                Console.Out.WriteLine("...");
                Console.Out.WriteLine(s.Count);
                Console.Out.WriteLine("...");
                c = System.Linq.Enumerable.Range(1, 26).ToArray();
                s = AAAf.dsafsf(c, 200);
                Console.Out.WriteLine("...");
                Console.Out.WriteLine(s.Count);
                Console.Out.WriteLine("...");
                Console.ReadKey(true);
                return 0;
            }
            {
                Console.Out.WriteLine("".IndexOf(""));
                Console.Out.WriteLine(SequenceSearchModule.IndexOf_A_KnuthMorrisPratt<char, char[], char[], TestModule.CharComparer>("".ToCharArray(), "".ToCharArray(), DefaultConstructor.Invoke<TestModule.CharComparer>()));

                var source = "abc abab bbda bd bb🌍a  ba badba dbad db a dcadb bad bab adb b🌍cdab d bda　🌍 dsf 地球人好壞 b da b b🌍a a".ToCharArray();
                var pattern = " b b🌍a".ToCharArray();

                var c = SequenceSearchModule.IndexOf_A_KnuthMorrisPratt<char, char[], char[], TestModule.CharComparer>(source, pattern, DefaultConstructor.Invoke<TestModule.CharComparer>());
                Console.Out.WriteLine("...");
                Console.Out.WriteLine(c);
                Console.Out.WriteLine(new string(source.Skip(c).Take(pattern.Length).ToArray()));
                c = SequenceSearchModule.IndexOf_A_KnuthMorrisPratt<char, char[], char[], TestModule.CharComparer>(source, pattern, DefaultConstructor.Invoke<TestModule.CharComparer>());
                Console.Out.WriteLine("...");
                Console.Out.WriteLine(c);
                Console.Out.WriteLine(new string(source.Skip(c).Take(pattern.Length).ToArray()));
                Console.ReadKey(true);
                return 0;
            }
            {
                TestModule.Test_IsPermutation_2();
                {
                    var a = "Banaan🌍nas".ToCharArray();
                    var c = ((Func<char, char, bool>)((x, y) => x == y)).AsIFunc();
                    var d = ((Func<char, char, bool>)((x, y) => x < y)).AsIFunc();
                    var t = 0UL;
                    var s = new List<(ulong Id, bool Value)>(0);
                    for (var b = a.Clone() as char[]; ;) {
                        Console.Out.WriteLine(b);
                        var z = ArrayModule.IsPermutation(a.Clone() as char[], b.Clone() as char[], c);
                        s.Add((t++, z));
                        if (ArrayModule.PreviousPermutation(b, d)) {
                            continue;
                        }
                        break;
                    }
                    var f = s.All((x) => x.Value);
                }
                return 0;
            }
            {
                var source = "abc abab bbda bd bb🌍a  ba badba dbad db a dcadb bad bab adb b🌍cdab d bda　🌍 dsf 地球人好壞 b da b b🌍a a".ToCharArray();
                var pattern = " b b🌍a".ToCharArray();
                Console.Out.WriteLine(DefaultConstructor.Invoke<StringOrdinalEqualityComparer>().GetHashCode(pattern, 0, pattern.Length));
                var hash = DefaultConstructor.Invoke<StringOrdinalEqualityComparer>().CreateHashCodeBuilder(pattern, 0, pattern.Length);

                Console.Out.WriteLine(hash.GetCurrentHashCode());
                hash.Shift(' ', ' ');
                hash.Shift('b', 'b');
                hash.Shift(' ', ' ');
                hash.Shift('b', 'b');
                hash.Shift('a', 'a');
                Console.Out.WriteLine(hash.GetCurrentHashCode());

                var c = SequenceSearchModule.IndexOf_A_RabinKarp<char, char[], char[], StringOrdinalEqualityComparer.HashCodeBuilder, StringOrdinalEqualityComparer>(source, pattern, DefaultConstructor.Invoke<StringOrdinalEqualityComparer>());
                Console.Out.WriteLine("...");
                Console.Out.WriteLine(c);
                Console.Out.WriteLine(new string(source.Skip(c).Take(pattern.Length).ToArray()));
                Console.ReadKey(true);
                return 0;
            }
            {
                var b = new int[] { 1, 2, 2, 3, 4, };
                var a = System.Linq.Enumerable.Range(0, b.Length).ToArray();
                var dd = 0L;
                do {
                    var c = b.Clone() as int[];
                    ArrayModule.Reorder(c, a.Clone() as int[]);
                    ++dd;
                    Printf(System.Console.Out, c);
                } while (ArrayModule.NextPermutation(a, ((Func<int, int, bool>)((x, y) => x < y)).AsIFunc()));
                Console.Out.WriteLine("...");
                Console.Out.WriteLine(dd);
                Console.ReadKey(true);
                return 0;
            }

            {
                var b = new int[] { 1, 2, 2, 3, 4, };
                var a = System.Linq.Enumerable.Range(0, b.Length).ToArray();
                var dd = 0L;
                do {
                    var c = a.Select(x => b[x]).ToArray();
                    ++dd;
                    Printf(System.Console.Out, c);
                } while (ArrayModule.NextPermutation(a, ((Func<int, int, bool>)((x, y) => x < y)).AsIFunc()));
                Console.Out.WriteLine("...");
                Console.Out.WriteLine(dd);
                Console.ReadKey(true);
                return 0;
            }
            {
                var a = new int[] { 4, 4, 5, 5, 5, 6 };
                // a = new int[] { 1, 3, 2, };
                var b = a.Clone() as int[];
                do {
                    Printf(System.Console.Out, b);
                } while (ArrayModule.NextPermutation(b, ((Func<int, int, bool>)((x, y) => x < y)).AsIFunc()));

                Console.Out.WriteLine("...");
                Console.ReadKey(true);
                return 0;
            }
            {
                {
                    var aaa = TestModule.Test_Rotate_RotateInPlace_RotateLeftInPlace_1();
                }

                var asdfs = new object().GetHashCode();
                if (asdfs > 1) {
                    if (asdfs == 1) {
                        Console.Out.WriteLine(1024);
                    }
                }
                bool a = false;
                for (var i = 100; i > 0; --i) {
                    // a = new Program().Test_Rotate_3a(new long[] { 0, 1, 0 });
                }
                Console.Out.WriteLine(a);
                Console.Out.WriteLine("...");
                Console.ReadKey(true);
                return 0;
            }
            {
                var a = new long[33];
                {
                    long s = 10000;
                    for (PtrSimulated<long> i = a; i < a.End(); i += 7) {
                        i.Data = s++;
                    }
                }
                Console.Out.WriteLine("...");
                Console.ReadKey(true);
                return 0;
            }

            {


                var rrrrr = new Random();

                var id = 10000L;
                var tree = new Collections.Generic.ReferenceTypes.LinkedTree<long>(id++);
                var ll = new Collections.Generic.RefReturnSupported.List<Collections.Generic.ReferenceTypes.LinkedTree<long>.Node> {
                    tree.Root
                };
                var aaa = ll[rrrrr.Next(ll.Count)];
                {

                }
                ll.Add(aaa.AddFirst(id++));





                var a = tree.GetPreorderNodeInfo();
                var duzz = Plain.ValueTypes.Tree<long>.FromPreorderNodeInfo(a);
                var b = duzz.GetPreorderNodeInfo();
                var duzz2 = Plain.ValueTypes.Tree<long>.FromPreorderNodeInfo(b);

                var tree2 = new Collections.Generic.ReferenceTypes.LinkedTree<long>(duzz2.GetPreorderNodeInfo());

                Console.Out.WriteLine(tree2.ToString());

            }
            {
                UltimateOrb.Plain.ValueTypes.Stack<int> a = default;
                System.Threading.Thread.MemoryBarrier();
                a.TryInitialize(args.Length);
                System.Threading.Thread.MemoryBarrier();
                Console.Out.WriteLine(a.Count);
                return 0;
            }
            {
                System.Threading.Thread.MemoryBarrier();
                dddd1 = DefaultConstructor.Invoke<long?>();
                System.Threading.Thread.MemoryBarrier();
                return 0;
                Console.Out.WriteLine("...");
                Console.ReadKey(true);
            }

            {
                // new Program().Test_X2A330000000();
            }
            {
                System.Threading.Thread.MemoryBarrier();
                var b = DefaultConstructor.Invoke<long>();
                System.Threading.Thread.MemoryBarrier();
                Dummy<long>.Value = b;
                Console.Out.WriteLine(b);
                System.Threading.Thread.MemoryBarrier();
                var c = DefaultConstructor.Invoke<long?>();
                System.Threading.Thread.MemoryBarrier();
                Dummy<long?>.Value = c;
                Console.Out.WriteLine(c);
                Console.Out.WriteLine("...");
                Console.ReadKey(true);
            }
            {
                new Program().Test_3();
            }
            {
                var a = DefaultConstructor.Invoke<object>();
                Console.Out.WriteLine(a);
            }
            {
                var a = DefaultConstructor.Invoke<RuntimeTypeHandle>();
                Console.Out.WriteLine(a);
                try {
                    var b = a.GetModuleHandle();
                    Console.Out.WriteLine(b);
                } catch (Exception) {
                }
            }
            {
                var a = default(DefaultConstructor<System.Collections.Generic.List<long>>).Invoke();
                Console.Out.WriteLine(a);
                var b = default(DefaultConstructor<long>).Invoke();
                Console.Out.WriteLine(b);
                var c = DefaultConstructor.Invoke<long>();
                Console.Out.WriteLine(c);
                var d = DefaultConstructor.Invoke<System.Collections.Generic.List<long>>();
                Console.Out.WriteLine(d);
                Console.ReadKey(true);
            }
            return 0;
        }
    }
}
