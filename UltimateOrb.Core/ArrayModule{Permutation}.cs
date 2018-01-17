using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace UltimateOrb {
    using IntT = Int32;
    using UIntT = UInt32;

    using static UltimateOrb.Utilities.ThrowHelper;
    using static UltimateOrb.Utilities.SignConverter;

    using ThrowHelper = ThrowHelper_ArrayModule;

    public static partial class ArrayModule {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static bool PreviousPermutationInternal<T, TLessThan>(this T[] array, IntT start, IntT count, TLessThan lessThan)
                   where TLessThan : IO.IFunc<T, T, bool> {
            Contract.Requires(0 <= count);
            Contract.Requires(count > 1);
            var c = unchecked(start + count);
            var i = c;
            --i;
            for (; ; ) {
                var j = i;
                --i;
                if (lessThan.Invoke(array[j], array[i])) {
                    var k = c;
                    for (; ; ) {
                        --k;
                        {
                            var p = array[k];
                            var q = array[i];
                            if (lessThan.Invoke(p, q)) {
                                array[k] = q;
                                array[i] = p;
                                break;
                            }
                        }
                    }
                    Reverse(array, j, c - j);
                    return true;
                }
                if (i == start) {
                    Reverse(array, start, count);
                    return false;
                }
            }
        }

        public static bool PreviousPermutation<T, TLessThan>(this T[] array, IntT start, IntT count, TLessThan lessThan)
            where TLessThan : IO.IFunc<T, T, bool> {
            if (null != array) {
                if (count > 1) {
                    if (unchecked(start + count) <= array.Length && 0 <= start) {
                        PreviousPermutationInternal(array, start, count, lessThan);
                    }
                    goto L_a;
                }
                if (CheckSegment(array, start, count)) {
                    return false;
                }
                L_a:
                // TODO: Perf
                throw new ArgumentException();
            }
            ThrowHelper.ThrowArgumentNullException_array();
            throw (ArgumentNullException)null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool PreviousPermutation<T, TLessThan>(this T[] array, IntT start, IntT count) where TLessThan : IO.IFunc<T, T, bool>, new() {
            return PreviousPermutation(array, start, count, DefaultConstructor.Invoke<TLessThan>());
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool PreviousPermutation<T, TLessThan>(this T[] array, TLessThan lessThan) where TLessThan : IO.IFunc<T, T, bool> {
            if (null != array) {
                var c = array.Length;
                if (c > 1) {
                    return PreviousPermutationInternal(array, 0, c, lessThan);
                }
                return false;
            }
            ThrowHelper.ThrowArgumentNullException_array();
            throw (ArgumentNullException)null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool PreviousPermutation<T, TLessThan>(this T[] array) where TLessThan : IO.IFunc<T, T, bool>, new() {
            return PreviousPermutation(array, DefaultConstructor.Invoke<TLessThan>());
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static bool NextPermutationInternal<T, TLessThan>(this T[] array, IntT start, IntT count, TLessThan lessThan)
            where TLessThan : IO.IFunc<T, T, bool> {
            Contract.Requires(0 <= count);
            Contract.Requires(count > 1);
            var c = unchecked(start + count);
            var i = c;
            --i;
            for (; ; ) {
                var j = i;
                --i;
                if (lessThan.Invoke(array[i], array[j])) {
                    var k = c;
                    for (; ; ) {
                        --k;
                        {
                            var p = array[i];
                            var q = array[k];
                            if (lessThan.Invoke(p, q)) {
                                array[i] = q;
                                array[k] = p;
                                break;
                            }
                        }
                    }
                    Reverse(array, j, c - j);
                    return true;
                }
                if (i == start) {
                    Reverse(array, start, count);
                    return false;
                }
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool NextPermutation<T, TLessThan>(this T[] array, IntT start, IntT count, TLessThan lessThan) where TLessThan : IO.IFunc<T, T, bool> {
            if (null != array) {
                if (count > 1) {
                    if (unchecked(start + count) <= array.Length && 0 <= start) {
                        return NextPermutationInternal(array, start, count, lessThan);
                    }
                    goto L_a;
                }
                if (CheckSegment(array, start, count)) {
                    return false;
                }
                L_a:
                // TODO: Perf
                throw new ArgumentException();
            }
            ThrowHelper.ThrowArgumentNullException_array();
            throw (ArgumentNullException)null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool NextPermutation<T, TLessThan>(this T[] array, IntT start, IntT count) where TLessThan : IO.IFunc<T, T, bool>, new() {
            return NextPermutation(array, start, count, DefaultConstructor.Invoke<TLessThan>());
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool NextPermutation<T, TLessThan>(this T[] array, TLessThan lessThan) where TLessThan : IO.IFunc<T, T, bool> {
            if (null != array) {
                var c = array.Length;
                if (c > 1) {
                    return NextPermutationInternal(array, 0, c, lessThan);
                }
                return false;
            }
            ThrowHelper.ThrowArgumentNullException_array();
            throw (ArgumentNullException)null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool NextPermutation<T, TLessThan>(this T[] array) where TLessThan : IO.IFunc<T, T, bool>, new() {
            return NextPermutation(array, DefaultConstructor.Invoke<TLessThan>());
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static bool IsPermutationInternal<T, TEqualityComparer>(this T[] first, IntT startFirst, IntT countFirst, T[] second, IntT startSecond, TEqualityComparer equalityComparer) where TEqualityComparer : IO.IFunc<T, T, bool> {
            Contract.Requires(null != first && CheckSegment(first, startFirst, countFirst));
            Contract.Requires(null != second && CheckSegment(second, startSecond, countFirst));
            Contract.Requires(null != equalityComparer);
            var i = startFirst;
            var u = unchecked(startFirst + countFirst);
            var j = startSecond;
            for (; u > i;) {
                if (!equalityComparer.Invoke(first[i], second[j])) {
                    var v = unchecked(u - i + j);
                    return CheckMatchCounts(first, i, u, second, j, v, equalityComparer);
                }
                ++i;
                ++j;
            }
            return true;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static bool CheckMatchCounts<T, TEqualityComparer>(this T[] first, IntT startFirst, IntT endExFirst, T[] second, IntT startSecond, IntT endExSecond, TEqualityComparer equalityComparer) where TEqualityComparer : IO.IFunc<T, T, bool> {
            var (u, v) = TrimMatchingSuffixes(first, endExFirst, second, endExSecond, equalityComparer);
            for (var i = startFirst; u > i; ++i) {
                if (i == IndexOfInternal(first, startFirst, i, first[i], equalityComparer)) {
                    var c2 = CountInternal(first, startSecond, v, first[i], equalityComparer);
                    if (0 == c2) {
                        return false;
                    }
                    var k = i;
                    unchecked {
                        ++k;
                    }
                    var c1 = 1 + CountInternal(first, k, u, first[i], equalityComparer);
                    if (c1 != c2) {
                        return false;
                    }
                }
            }
            return true;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static (IntT, IntT) TrimMatchingSuffixes<T, TEqualityComparer>(this T[] first, IntT endExFirst, T[] second, IntT endExSecond, TEqualityComparer equalityComparer) where TEqualityComparer : IO.IFunc<T, T, bool> {
            var i = endExFirst;
            var j = endExSecond;
            for (; equalityComparer.Invoke(first[--i], second[--j]);) {
            }
            ++i;
            ++j;
            return (i, j);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static int CountInternal<T, TEqualityComparer>(this T[] first, IntT start, IntT endEx, T value, TEqualityComparer equalityComparer) where TEqualityComparer : IO.IFunc<T, T, bool> {
            var result = (int)0;
            for (var i = start; endEx > i; ++i) {
                if (equalityComparer.Invoke(first[i], value)) {
                    checked {
                        ++result;
                    }
                }
            }
            return result;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static IntT IndexOfInternal<T, TEqualityComparer>(this T[] first, IntT start, IntT endEx, T value, TEqualityComparer equalityComparer) where TEqualityComparer : IO.IFunc<T, T, bool> {
            for (var i = start; endEx > i; ++i) {
                if (equalityComparer.Invoke(first[i], value)) {
                    return i;
                }
            }
            return endEx;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool IsPermutation<T, TEqualityComparer>(this T[] first, IntT startFirst, IntT countFirst, T[] second, IntT startSecond, IntT countSecond, TEqualityComparer equalityComparer) where TEqualityComparer : IO.IFunc<T, T, bool> {
            if (null != first && null != second) {
                if (CheckSegment(first, startFirst, countFirst) && CheckSegment(second, startSecond, countSecond)) {
                    if (countFirst == countSecond) {
                        return IsPermutationInternal(first, startFirst, countFirst, second, startSecond, equalityComparer);
                    }
                    return false;
                }
                // TODO
                throw new ArgumentException();
            }
            // TODO
            ThrowHelper.ThrowArgumentNullException_array();
            throw (ArgumentNullException)null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool IsPermutation<T, TEqualityComparer>(this T[] first, T[] second, TEqualityComparer equalityComparer) where TEqualityComparer : IO.IFunc<T, T, bool> {
            if (null != first && null != second) {
                var countFirst = first.Length;
                var countSecond = second.Length;
                if (countFirst == countSecond) {
                    return IsPermutationInternal(first, 0, countFirst, second, 0, equalityComparer);
                }
                return false;
            }
            // TODO
            ThrowHelper.ThrowArgumentNullException_array();
            throw (ArgumentNullException)null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Reorder<T>(this T[] array, IntT[] indicesAndBuffer) {
            for (var i = 0; array.Length > i; ++i) {
                while (indicesAndBuffer[i] != i) {
                    var k = indicesAndBuffer[i];
                    var j = indicesAndBuffer[k];
                    var v = array[k];
                    indicesAndBuffer[k] = indicesAndBuffer[i];
                    indicesAndBuffer[i] = j;
                    array[k] = array[i];
                    array[i] = v;
                }
            }
        }

        // TODO: Move to a suitable space.
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static Int32 ConvertEvenToZeroAndOddToMinusOne(Int32 value) {
            return (value << (32 - 1)) >> (32 - 1);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static Int64 ConvertEvenToZeroAndOddToMinusOne(Int64 value) {
            return (value << (64 - 1)) >> (64 - 1);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static UInt32 ConvertEvenToZeroAndOddToMinusOne(UInt32 value) {
            return unchecked((UInt32)ConvertEvenToZeroAndOddToMinusOne((Int32)value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static UInt64 ConvertEvenToZeroAndOddToMinusOne(UInt64 value) {
            return unchecked((UInt64)ConvertEvenToZeroAndOddToMinusOne((Int64)value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static void InterleaveInPlacePartialInternal<T>(T[] array, int start, int count) {
            Contract.Requires(null != array && CheckSegment(array, start, count));
            Contract.Requires(0 == (1 & count));
            for (var i = 1; count > i;) {
                var j = i;
                var item = array[unchecked(start + j)];
                do {
                    unchecked {
                        j += ConvertEvenToZeroAndOddToMinusOne(j) & count;
                    }
                    j >>= 1;
                    {
                        var t = item;
                        item = array[unchecked(start + j)];
                        array[unchecked(start + j)] = t;
                    }
                } while (i != j);
                unchecked {
                    i *= 3;
                }
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void InterleaveInPlace<T>(T[] array, IntT start, IntT count) {
            if (null != array) {
                if (CheckSegment(array, start, count)) {
                    if (0 == (1 & count)) {
                        var res = count;
                        var i = (IntT)0;
                        for (; res > 0;) {
                            var c = (IntT)0;
                            {
                                var j = (UIntT)1;
                                for (; res.ToUnsignedUnchecked() > j;) {
                                    c = unchecked((IntT)j);
                                    if (j <= unchecked((UIntT)(IntT.MaxValue / 3))) {
                                        unchecked {
                                            j *= 3;
                                        }
                                        continue;
                                    }
                                    break;
                                }
                            }
                            unchecked {
                                ++c;
                            }
                            unchecked {
                                res -= c;
                            }
                            InterleaveInPlacePartialInternal(array, unchecked(start + i), c);
                            RotateLeftInPlace(array, unchecked(start + (i >> 1)),  (i + c) >> 1, i >> 1);
                            unchecked {
                                i += c;
                            }
                        }
                        return;
                    }
                }
                // TODO: Perf
                throw new ArgumentException();
            }
            ThrowHelper.ThrowArgumentNullException_array();
            throw null;
        }
    }
}
