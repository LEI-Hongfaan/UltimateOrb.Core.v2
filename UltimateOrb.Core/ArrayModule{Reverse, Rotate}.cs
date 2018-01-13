using System;

namespace UltimateOrb {
    using IntT = Int32;
    using UIntT = UInt32;

    using static UltimateOrb.Utilities.ThrowHelper;
    using static UltimateOrb.Utilities.SignConverter;

    using System.Diagnostics.Contracts;
    using System.Runtime.CompilerServices;
    using ThrowHelper = ThrowHelper_ArrayModule;

    public static partial class ArrayModule {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static void ReverseInternal<T>(this T[] array, IntT start, IntT count) {
            unchecked {
                var i = start;
                var j = start + count - 1;
                for (; i < j; ++i, --j) {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Reverse<T>(this T[] array, IntT start, IntT count) {
            if (null != array) {
                if (CheckSegment(array, start, count)) {
                    ReverseInternal(array, start, count);
                    return;
                }
                // TODO: Perf
                throw new ArgumentException();
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static void ReverseInternal<T>(this T[] array) {
            var c = array.Length;
            var j = c - 1;
            if (j > 0) {
                c >>= 1;
                for (var i = 0; c > i && array.Length > i && 0 <= j; ++i, --j) {
                    var t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                }
            }
            return;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Reverse<T>(this T[] array) {
            if (null != array) {
                ReverseInternal(array);
                return;
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static void RotateLeftInPlaceInternal<T>(this T[] array, IntT start, IntT count, IntT shift) {
            Contract.Requires(null != array && CheckSegment(array, start, count));
            Contract.Requires(shift > 0);
            Contract.Requires(count > shift);
            Contract.Requires(count > 1);
            var c = 0;
            for (var m = 0; count > c; ++m) {
                var t = array[start + m];
                var i = m;
                for (var j = m + shift; ;) {
                    array[start + i] = array[start + j];
                    ++c;
                    i = j;
                    j += shift;
                    if (count <= j) {
                        j -= count;
                    }
                    if (j == m) {
                        break;
                    }
                }
                array[start + i] = t;
                ++c;
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static void RotateLeftInPlaceInternal<T>(this T[] array, IntT shift) {
            Contract.Requires(shift > 0);
            Contract.Requires(null != array && array.Length > shift && array.Length > 1);
            var c = 0;
            var count = array.Length;
            for (var m = 0; count > c; ++m) {
                var t = array[m];
                var i = m;
                for (var j = m + shift; ;) {
                    array[i] = array[j];
                    ++c;
                    i = j;
                    j += shift;
                    if (count <= j) {
                        j -= count;
                    }
                    if (j == m) {
                        break;
                    }
                }
                array[i] = t;
                ++c;
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static IntT NormalizeShiftCount(IntT count, IntT shift) {
            var s = shift;
            if (0 > s || count <= s) {
                unchecked {
                    s %= count;
                }
                if (0 > s) {
                    unchecked {
                        s += count;
                    }
                }
            }
            return s;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void RotateLeftInPlace<T>(this T[] array, IntT start, IntT count, IntT shift) {
            if (null != array) {
                if (count > 1) {
                    if (unchecked(start + count) <= array.Length && 0 <= start) {
                        var s = NormalizeShiftCount(count, shift);
                        if (s > 0) {
                            RotateLeftInPlaceInternal(array, start, count, s);
                        }
                        return;
                    }
                    goto L_a;
                }
                if (CheckSegment(array, start, count)) {
                    return;
                }
                L_a:
                // TODO: Perf
                throw new ArgumentException();
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void RotateLeftInPlace<T>(this T[] array, IntT shift) {
            if (null != array) {
                var count = array.Length;
                if (count > 1) {
                    var s = NormalizeShiftCount(count, shift);
                    if (s > 0) {
                        RotateLeftInPlaceInternal(array, s);
                    }
                }
                return;
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void RotateRightInPlace<T>(this T[] array, IntT start, IntT count, IntT shift) {
            if (null != array) {
                if (count > 1) {
                    if (unchecked(start + count) <= array.Length && 0 <= start) {
                        var s = NormalizeShiftCount(count, shift);
                        if (s > 0) {
                            RotateLeftInPlaceInternal(array, start, count, unchecked(count - s));
                        }
                        return;
                    }
                    goto L_a;
                }
                if (CheckSegment(array, start, count)) {
                    return;
                }
                L_a:
                // TODO: Perf
                throw new ArgumentException();
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void RotateRightInPlace<T>(this T[] array, IntT shift) {
            if (null != array) {
                var count = array.Length;
                if (count > 1) {
                    var s = NormalizeShiftCount(count, shift);
                    if (s > 0) {
                        RotateLeftInPlaceInternal(array, unchecked(count - s));
                    }
                }
                return;
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static IntT RotateInPlace<T>(this T[] array, IntT start, IntT mid, IntT endExclusive) {
            if (null != array) {
                if (unchecked((UIntT)endExclusive) <= array.Length.ToUnsignedUnchecked() && mid <= endExclusive && start <= mid && 0 <= start) {
                    if (start == mid) {
                        return endExclusive;
                    }
                    if (mid == endExclusive) {
                        return start;
                    }
                    var i = start;
                    var k = mid;
                    var j = k;
                    var residue = endExclusive;
                    for (; ; ) {
                        {
                            var t = array[i];
                            array[i] = array[j];
                            array[j] = t;
                        }
                        unchecked {
                            ++i;
                        }
                        if (k == i) {
                            unchecked {
                                ++j;
                            }
                            if (endExclusive == j) {
                                return (residue == endExclusive ? k : residue);
                            } else {
                                k = j;
                            }
                        } else {
                            unchecked {
                                ++j;
                            }
                            if (endExclusive == j) {
                                if (residue == endExclusive) {
                                    residue = i;
                                }
                                j = k;
                            }
                        }
                    }
                }
                // TODO: Perf
                throw new ArgumentException();
            }
            ThrowHelper.ThrowArgumentNullException_array();
            throw (ArgumentNullException)null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void RotateRightInPlace_A<T>(this T[] array, IntT start, IntT count, IntT shift) {
            if (null != array) {
                if (count > 1) {
                    if (unchecked(start + count) <= array.Length && 0 <= start) {
                        var s = NormalizeShiftCount(count, shift);
                        if (s > 0) {
                            ReverseInternal(array, start, count);
                            ReverseInternal(array, unchecked(start + s), unchecked(count - s));
                            ReverseInternal(array, start, s);
                        }
                        return;
                    }
                    goto L_a;
                }
                if (CheckSegment(array, start, count)) {
                    return;
                }
                L_a:
                // TODO: Perf
                throw new ArgumentException();
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void RotateLeftInPlace_A<T>(this T[] array, IntT start, IntT count, IntT shift) {
            if (null != array) {
                if (count > 1) {
                    if (unchecked(start + count) <= array.Length && 0 <= start) {
                        var s = NormalizeShiftCount(count, shift);
                        if (s > 0) {
                            var t = unchecked(count - s);
                            ReverseInternal(array, start, count);
                            ReverseInternal(array, unchecked(start + t), s);
                            ReverseInternal(array, start, t);
                        }
                        return;
                    }
                    goto L_a;
                }
                if (CheckSegment(array, start, count)) {
                    return;
                }
                L_a:
                // TODO: Perf
                throw new ArgumentException();
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void RotateRightInPlace_A<T>(this T[] array, IntT shift) {
            if (null != array) {
                var start = 0;
                var count = array.Length;
                if (count > 1) {
                    var s = NormalizeShiftCount(count, shift);
                    if (s > 0) {
                        ReverseInternal(array);
                        ReverseInternal(array, unchecked(start + s), unchecked(count - s));
                        ReverseInternal(array, start, s);
                    }
                }
                return;
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void RotateLeftInPlace_A<T>(this T[] array, IntT shift) {
            if (null != array) {
                var start = 0;
                var count = array.Length;
                if (count > 1) {
                    var s = NormalizeShiftCount(count, shift);
                    if (s > 0) {
                        var t = unchecked(count - s);
                        ReverseInternal(array);
                        ReverseInternal(array, unchecked(start + t), s);
                        ReverseInternal(array, start, t);
                    }
                }
                return;
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static bool PreviousPermutationInternal<T, TLessThan>(T[] array, IntT start, IntT count, TLessThan lessThan)
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

        public static bool PreviousPermutation<T, TLessThan>(T[] array, IntT start, IntT count, TLessThan lessThan)
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
        public static bool PreviousPermutation<T, TLessThan>(T[] array, IntT start, IntT count) where TLessThan : IO.IFunc<T, T, bool>, new() {
            return PreviousPermutation(array, start, count, DefaultConstructor.Invoke<TLessThan>());
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool PreviousPermutation<T, TLessThan>(T[] array, TLessThan lessThan) where TLessThan : IO.IFunc<T, T, bool> {
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
        public static bool PreviousPermutation<T, TLessThan>(T[] array) where TLessThan : IO.IFunc<T, T, bool>, new() {
            return PreviousPermutation(array, DefaultConstructor.Invoke<TLessThan>());
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal static bool NextPermutationInternal<T, TLessThan>(T[] array, IntT start, IntT count, TLessThan lessThan)
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
        public static bool NextPermutation<T, TLessThan>(T[] array, IntT start, IntT count, TLessThan lessThan) where TLessThan : IO.IFunc<T, T, bool> {
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
        public static bool NextPermutation<T, TLessThan>(T[] array, IntT start, IntT count) where TLessThan : IO.IFunc<T, T, bool>, new() {
            return NextPermutation(array, start, count, DefaultConstructor.Invoke<TLessThan>());
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool NextPermutation<T, TLessThan>(T[] array, TLessThan lessThan) where TLessThan : IO.IFunc<T, T, bool> {
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
        public static bool NextPermutation<T, TLessThan>(T[] array) where TLessThan : IO.IFunc<T, T, bool>, new() {
            return NextPermutation(array, DefaultConstructor.Invoke<TLessThan>());
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Reorder<T>(T[] array, IntT[] indicesAndBuffer) {
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
    }
}
