using System;
using System.Collections.Generic;

namespace UltimateOrb {

    using System.Diagnostics.Contracts;
    using System.Runtime.CompilerServices;

    using static ThrowHelper_ArrayModule.Identifiers;

    [DiscardableAttribute()]
    public static partial class ThrowHelper_ArrayModule {

        internal static class Identifiers {
            public const int array = 0;
            public const int index = 1;
        }

        internal static string nameof(int variable) {
            return "";
        }

        public static void ThrowArgumentNullException_array() {
            throw new ArgumentNullException(nameof(array));
        }

        public static void ThrowArgumentOutOfRangeException_index() {
            ((IList<Void>)Array_Empty<Void>.Value).CopyTo(Array_Empty<Void>.Value, 1);
        }
    }
}

namespace UltimateOrb {
    using IntT = Int32;
    using UIntT = UInt32;

    using static UltimateOrb.Utilities.ThrowHelper;
    using static UltimateOrb.Utilities.SignConverter;

    using System.Diagnostics.Contracts;
    using System.Runtime.CompilerServices;

    public static partial class ArrayModule {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool CheckIndex<T>(T[] array, IntT index) {
            Contract.Requires(null != array);
            return array.Length.ToUnsignedUnchecked() > unchecked((UIntT)index);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool CheckSegment<T>(T[] array, IntT start, IntT count) {
            Contract.Requires(null != array);
            return (count == 0 && 0 <= start && start <= array.Length) || (CheckIndex(array, start) && count > 0 && CheckIndex(array, unchecked(start + count)));
        }
    }
}

namespace UltimateOrb {
    using static UltimateOrb.Utilities.ThrowHelper;
    using static UltimateOrb.Utilities.SignConverter;

    public static partial class ArrayModule {

        [CLSCompliantAttribute(false)]
        public static UInt32 MaxInternal(UInt32[] array) {
            System.Diagnostics.Contracts.Contract.Requires(null != array);
            return MaxInternal(array, 0, array.Length);
        }

        [CLSCompliantAttribute(false)]
        public static UInt64 MaxInternal(UInt64[] array) {
            System.Diagnostics.Contracts.Contract.Requires(null != array);
            return MaxInternal(array, 0, array.Length);
        }

        [CLSCompliantAttribute(false)]
        public static UInt32 MaxInternal(UInt32[] array, int start, int count) {
            System.Diagnostics.Contracts.Contract.Requires(null != array);
            var end = unchecked(start + count);
            var r = (UInt32)0;
            for (var i = start; unchecked((uint)end) > i.ToUnsignedUnchecked(); ++i) {
                var d = array[i];
                if (d > r) {
                    r = d;
                }
            }
            return r;
        }

        [CLSCompliantAttribute(false)]
        public static UInt64 MaxInternal(UInt64[] array, int start, int count) {
            System.Diagnostics.Contracts.Contract.Requires(null != array);
            var end = unchecked(start + count);
            var r = (UInt64)0;
            for (var i = start; unchecked((uint)end) > i.ToUnsignedUnchecked(); ++i) {
                var d = array[i];
                if (d > r) {
                    r = d;
                }
            }
            return r;
        }

        [CLSCompliantAttribute(false)]
        public static UInt32 Max(this UInt32[] array, int start, int count) {
            System.Diagnostics.Contracts.Contract.Requires(null != array);
            if (null == array) {
                throw new ArgumentNullException(nameof(array));
            }
            if (0 > start) {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            if (1 > count && 0 > count) {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            var end = unchecked(start + count);
            if (unchecked((uint)end) > array.Length.ToUnsignedUnchecked()) {
                throw new ArgumentException();
            }
            var r = (UInt32)0;
            for (var i = start; unchecked((uint)end) > i.ToUnsignedUnchecked(); ++i) {
                var d = array[i];
                if (d > r) {
                    r = d;
                }
            }
            return r;
        }

        [CLSCompliantAttribute(false)]
        public static UInt64 Max(this UInt64[] array, int start, int count) {
            System.Diagnostics.Contracts.Contract.Requires(null != array);
            if (null == array) {
                throw new ArgumentNullException(nameof(array));
            }
            if (0 > start) {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            if (1 > count && 0 > count) {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            var end = unchecked(start + count);
            if (unchecked((uint)end) > array.Length.ToUnsignedUnchecked()) {
                throw new ArgumentException();
            }
            var r = (UInt64)0;
            for (var i = start; unchecked((uint)end) > i.ToUnsignedUnchecked(); ++i) {
                var d = array[i];
                if (d > r) {
                    r = d;
                }
            }
            return r;
        }

        [CLSCompliantAttribute(false)]
        public static UInt32[] SortRadix(this UInt32[] input_and_buffer0, UInt32[] buffer1) {
            var count = input_and_buffer0.Length;
            if (count > buffer1.Length) {
                count = buffer1.Length;
            }
            if (count <= input_and_buffer0.Length) {
                var max = MaxInternal(input_and_buffer0, 0, count);
                if (count <= buffer1.Length) {
                    var bit = (UInt32)1;
                    var e = 0;
                    for (; 32 > e && bit <= max; ++e) {
                        var b_0 = 0;
                        for (var i = 0; count > i; ++i) {
                            var d = input_and_buffer0[i];
                            if (0u == (bit & d)) {
                                unchecked(++b_0).Ignore();
                            }
                        }
                        var b_1 = count;
                        for (var i = count - 1; 0 <= i; --i) {
                            var d = input_and_buffer0[i];
                            if (0u == (bit & d)) {
                                buffer1[unchecked(--b_0)] = d;
                            } else {
                                buffer1[unchecked(--b_1)] = d;
                            }
                        }
                        {
                            var t = buffer1;
                            buffer1 = input_and_buffer0;
                            input_and_buffer0 = t;
                        }
                        bit <<= 1;
                    }
                    return input_and_buffer0;
                }
            }
            return null;
        }

        [CLSCompliantAttribute(false)]
        public static UInt64[] SortRadix(this UInt64[] input_and_buffer0, UInt64[] buffer1) {
            var count = input_and_buffer0.Length;
            if (count > buffer1.Length) {
                count = buffer1.Length;
            }
            if (count <= input_and_buffer0.Length) {
                var max = MaxInternal(input_and_buffer0, 0, count);
                if (count <= buffer1.Length) {
                    var bit = (UInt64)1;
                    var e = 0;
                    for (; 32 > e && bit <= max; ++e) {
                        var b_0 = 0;
                        for (var i = 0; count > i; ++i) {
                            var d = input_and_buffer0[i];
                            if (0u == (bit & d)) {
                                unchecked(++b_0).Ignore();
                            }
                        }
                        var b_1 = count;
                        for (var i = count - 1; 0 <= i; --i) {
                            var d = input_and_buffer0[i];
                            if (0u == (bit & d)) {
                                buffer1[unchecked(--b_0)] = d;
                            } else {
                                buffer1[unchecked(--b_1)] = d;
                            }
                        }
                        {
                            var t = buffer1;
                            buffer1 = input_and_buffer0;
                            input_and_buffer0 = t;
                        }
                        bit <<= 1;
                    }
                    return input_and_buffer0;
                }
            }
            return null;
        }

        [CLSCompliantAttribute(false)]
        public static void SortRadix(this UInt32[] array) {
            var count = array.Length;
            if (count <= 1) {
                return;
            }
            var buffer = new UInt32[count];
            var bit = (UInt32)1;
            var max = MaxInternal(array);
            var e = 0;
            for (; 32 > e && bit <= max; ++e) {
                var b_0 = 0;
                for (var i = 0; array.Length > i; ++i) {
                    var d = array[i];
                    if (0u == (bit & d)) {
                        unchecked(++b_0).Ignore();
                    }
                }
                var b_1 = count;
                for (var i = array.Length - 1; 0 <= i; --i) {
                    var d = array[i];
                    if (0u == (bit & d)) {
                        buffer[unchecked(--b_0)] = d;
                    } else {
                        buffer[unchecked(--b_1)] = d;
                    }
                }
                {
                    var t = buffer;
                    buffer = array;
                    array = t;
                }
                bit <<= 1;
            }
            if (0u != (1u & e)) {
                /*
                for (var i = 0; count > i; ++i) {
                    buffer[i] = array[i];
                }
                */
                array.CopyTo(buffer, 0);
            }
        }

        [CLSCompliantAttribute(false)]
        public static void SortRadix(this UInt64[] array) {
            var count = array.Length;
            if (count <= 1) {
                return;
            }
            var buffer = new UInt64[count];
            var bit = (UInt64)1;
            var max = MaxInternal(array);
            var e = 0;
            for (; 32 > e && bit <= max; ++e) {
                var b_0 = 0;
                for (var i = 0; array.Length > i; ++i) {
                    var d = array[i];
                    if (0u == (bit & d)) {
                        unchecked(++b_0).Ignore();
                    }
                }
                var b_1 = count;
                for (var i = array.Length - 1; 0 <= i; --i) {
                    var d = array[i];
                    if (0u == (bit & d)) {
                        buffer[unchecked(--b_0)] = d;
                    } else {
                        buffer[unchecked(--b_1)] = d;
                    }
                }
                {
                    var t = buffer;
                    buffer = array;
                    array = t;
                }
                bit <<= 1;
            }
            if (0u != (1u & e)) {
                /*
                for (var i = 0; count > i; ++i) {
                    buffer[i] = array[i];
                }
                */
                array.CopyTo(buffer, 0);
            }
        }
    }
}


namespace UltimateOrb {
    using IntT = Int32;
    using UIntT = UInt32;

    using static ArrayModule;

    using Contract = System.Diagnostics.Contracts.Contract;
    using SortUtilities = ArrayModule.SortUtilities;

    using static UltimateOrb.Utilities.ThrowHelper;
    using static UltimateOrb.Utilities.SignConverter;

    using System.Runtime.CompilerServices;
    using System.Diagnostics.Contracts;

    public static partial class ArrayModule<T> {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static void CheckArraySegment(T[] array, int offset, int count) {
            if (
                null == array ||
                0 > offset ||
                0 > count ||
                unchecked(array.Length - offset) < count) {
                ThrowArgumentException_CheckArraySegment(array, offset, count);
            }
        }

        [MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        [PureAttribute()]
        internal static void ThrowArgumentException_CheckArraySegment(T[] array, int offset, int count) {
            new ArraySegment<T>(array, offset, count).Ignore();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool CheckCompatibleDimension<TValue>(T[] first, TValue[] second) {
            Contract.Requires(null != first);
            Contract.Requires(null != second);
            return first.Length == second.Length;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Swap<TValue>(T[] keys, IntT i, IntT j, TValue[] values) {
            Contract.Requires(null != keys);
            Contract.Requires(CheckIndex(keys, i));
            Contract.Requires(CheckIndex(keys, j));
            var t = keys[i];
            keys[i] = keys[j];
            keys[j] = t;
            if (null != values) {
                var value = values[i];
                values[i] = values[j];
                values[j] = value;
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Swap(T[] keys, IntT first, IntT second) {
            Contract.Requires(null != keys);
            Contract.Requires(CheckIndex(keys, first));
            Contract.Requires(CheckIndex(keys, second));
            Swap(keys, first, second, ArrayModule.Null);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SwapIfGreater<TComparer, TValue>(T[] keys, TComparer comparer, IntT first, IntT second, TValue[] values) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckIndex(keys, first));
            Contract.Requires(CheckIndex(keys, second));
            Contract.Requires(null != comparer);
            if (comparer.Compare(keys[first], keys[second]) > 0) {
                Swap(keys, first, second, values);
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SwapIfGreater<TComparer, TValue>(T[] keys, IntT first, IntT second, TValue[] values) where TComparer : struct, IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckIndex(keys, first));
            Contract.Requires(CheckIndex(keys, second));
            SwapIfGreater(keys, default(TComparer), first, second, values);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SwapIfGreater<TComparer>(T[] keys, TComparer comparer, IntT first, IntT second) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckIndex(keys, first));
            Contract.Requires(CheckIndex(keys, second));
            Contract.Requires(null != comparer);
            SwapIfGreater(keys, comparer, first, second, ArrayModule.Null);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SwapIfGreater<TComparer>(T[] keys, IntT first, IntT second) where TComparer : struct, IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckIndex(keys, first));
            Contract.Requires(CheckIndex(keys, second));
            SwapIfGreater(keys, default(TComparer), first, second);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortHeapWalkSiftDown<TComparer, TValue>(T[] keys, TComparer comparer, IntT root, IntT start, IntT count, TValue[] values) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckIndex(keys, start));
            Contract.Requires(null != comparer);
            unchecked {
                var d = keys[unchecked(start + root)];
                var t = (null != values) ? values[unchecked(start + root)] : default(TValue);
                for (; root < unchecked(count / 2);) {
                    var child = unchecked(1 + 2 * root);
                    {
                        var child_s = unchecked(1 + child);
                        if (count > child_s && 0 > comparer.Compare(keys[unchecked(start + child)], keys[unchecked(start + child_s)])) {
                            child = child_s;
                        }
                    }
                    if (comparer.Compare(d, keys[unchecked(start + child)]) > 0) {
                        break;
                    }
                    keys[unchecked(start + root)] = keys[unchecked(start + child)];
                    if (null != values) {
                        values[unchecked(start + root)] = values[unchecked(start + child)];
                    }
                    root = child;
                }
                keys[unchecked(start + root)] = d;
                if (null != values) {
                    values[unchecked(start + root)] = t;
                }
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortHeapWalkSiftDown<TComparer, TValue>(T[] keys, IntT root, IntT start, IntT count, TValue[] values) where TComparer : struct, IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckIndex(keys, root));
            Contract.Requires(CheckIndex(keys, start));
            SortHeapWalkSiftDown(keys, default(TComparer), root, start, count, values);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortHeapWalkSiftDown<TComparer>(T[] keys, TComparer comparer, IntT root, IntT start, IntT count) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckIndex(keys, root));
            Contract.Requires(CheckIndex(keys, start));
            Contract.Requires(null != comparer);
            SortHeapWalkSiftDown(keys, comparer, root, start, count, ArrayModule.Null);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortHeapWalkSiftDown<TComparer>(T[] keys, IntT root, IntT start, IntT count) where TComparer : struct, IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckIndex(keys, start));
            SortHeapWalkSiftDown(keys, default(TComparer), root, start, count);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortHeap<TComparer, TValue>(T[] keys, TComparer comparer, IntT start, IntT count, TValue[] values) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckSegment(keys, start, count));
            Contract.Requires(null == values || CheckSegment(values, start, count));
            Contract.Requires(null != comparer);
            unchecked {
                // Items in [0, count / 2) only are roots.
                for (var i = count / 2; i > 0;) {
                    SortHeapWalkSiftDown(keys, comparer, --i, start, count, values);
                }
                for (var i = count - 1; i > 0; --i) {
                    Swap(keys, start, start + i, values);
                    SortHeapWalkSiftDown(keys, comparer, 0, start, i, values);
                }
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortHeap<TComparer, TValue>(T[] keys, IntT start, IntT count, TValue[] values) where TComparer : struct, IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckSegment(keys, start, count));
            Contract.Requires(null == values || CheckSegment(values, start, count));
            SortHeap(keys, default(TComparer), start, count, values);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortHeap<TComparer>(T[] keys, TComparer comparer, IntT start, IntT count) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckSegment(keys, start, count));
            Contract.Requires(null != comparer);
            SortHeap(keys, comparer, start, count, ArrayModule.Null);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortHeap<TComparer>(T[] keys, IntT start, IntT count) where TComparer : struct, IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckSegment(keys, start, count));
            SortHeap(keys, default(TComparer), start, count);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortHeap<TComparer, TValue>(T[] keys, TComparer comparer, TValue[] values) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(null != comparer);
            Contract.Requires(null == values || values.Length > keys.Length);
            SortHeap(keys, comparer, 0, keys.Length, values);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortHeap<TComparer, TValue>(T[] keys, TValue[] values) where TComparer : struct, IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(null == values || keys.Length == values.Length);
            SortHeap(keys, default(TComparer), values);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortHeap<TComparer>(T[] keys, TComparer comparer) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(null != comparer);
            SortHeap(keys, comparer, ArrayModule.Null);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortHeap<TComparer>(T[] keys) where TComparer : struct, IComparer<T> {
            Contract.Requires(null != keys);
            SortHeap(keys, default(TComparer));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortPartInsertion<TComparer, TValue>(T[] keys, TComparer comparer, IntT first, IntT last, TValue[] values) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(first <= last);
            Contract.Requires(CheckIndex(keys, first));
            Contract.Requires(CheckIndex(keys, last));
            Contract.Requires(null != comparer);
            unchecked {
                IntT i, j;
                T t;
                TValue tValue;
                for (i = first; last > i; ++i) {
                    j = i;
                    t = keys[i + 1];
                    tValue = (values != null) ? values[i + 1] : default(TValue);
                    while (j >= first && comparer.Compare(t, keys[j]) < 0) {
                        keys[j + 1] = keys[j];
                        if (values != null) {
                            values[j + 1] = values[j];
                        }
                        --j;
                    }
                    keys[j + 1] = t;
                    if (values != null) {
                        values[j + 1] = tValue;
                    }
                }
            }
        }

        public static void SortInsertion<TComparer, TValue>(T[] keys, TComparer comparer, IntT start, IntT count, TValue[] values) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(CheckSegment(keys, start, count));
            Contract.Requires(null != comparer);
            SortPartInsertion(keys, comparer, start, unchecked(count - 1), values);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static IntT PickPivotAndPartition<TComparer, TValue>(T[] keys, TComparer comparer, IntT first, IntT last, TValue[] values) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(first <= last);
            Contract.Requires(CheckIndex(keys, first));
            Contract.Requires(CheckIndex(keys, last));
            Contract.Ensures(first <= Contract.Result<IntT>() && Contract.Result<IntT>() <= last);
            IntT middle = unchecked(first + ((last - first) / 2));
            SwapIfGreater(keys, comparer, first, middle, values);
            SwapIfGreater(keys, comparer, first, last, values);
            SwapIfGreater(keys, comparer, middle, last, values);
            var pivot = keys[middle];
            Swap(keys, middle, unchecked(last - 1), values);
            IntT left = first, right = unchecked(last - 1);
            while (left < right) {
                if (pivot == null) {
                    while (left < unchecked(last - 1) && keys[unchecked(++left)] == null) {
                    }
                    while (right > first && keys[unchecked(--right)] != null) {
                    }
                } else {
                    while (comparer.Compare(pivot, keys[unchecked(++left)]) > 0) {
                    }
                    while (comparer.Compare(pivot, keys[unchecked(--right)]) < 0) {
                    }
                }
                if (left >= right) {
                    break;
                }
                Swap(keys, left, right, values);
            }
            Swap(keys, left, unchecked(last - 1), values);
            return left;
        }


        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortPartIntrospectiveRecursionLimited<TComparer, TValue>(T[] keys, TComparer comparer, IntT first, IntT last, int depthLimit, TValue[] values) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(values != null);
            Contract.Requires(first >= 0);
            Contract.Requires(last < keys.Length);
            while (last > first) {
                var partitionSize = unchecked(last - first + 1);
                if (partitionSize <= SortUtilities.SortIntroSizeThreshold) {
                    if (partitionSize == 1) {
                        return;
                    }
                    if (partitionSize == 2) {
                        SwapIfGreater(keys, comparer, first, last, values);
                        return;
                    }
                    if (partitionSize == 3) {
                        SwapIfGreater(keys, comparer, first, unchecked(last - 1), values);
                        SwapIfGreater(keys, comparer, first, last, values);
                        SwapIfGreater(keys, comparer, unchecked(last - 1), last, values);
                        return;
                    }
                    SortPartInsertion(keys, comparer, first, last, values);
                    return;
                }
                if (depthLimit == 0) {
                    SortHeap(keys, comparer, first, last, values);
                    return;
                }
                unchecked(--depthLimit).Ignore();
                var p = PickPivotAndPartition(keys, comparer, first, last, values);
                SortPartIntrospectiveRecursionLimited(keys, comparer, unchecked(p + 1), last, depthLimit, values);
                last = unchecked(p - 1);
            }
        }


        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortIntrospective<TComparer, TValue>(T[] keys, TComparer comparer, IntT start, IntT count, TValue[] values) where TComparer : IComparer<T> {
            Contract.Requires(null != keys);
            Contract.Requires(0 <= start);
            Contract.Requires(0 <= count);
            Contract.Requires(count <= keys.Length);
            Contract.Requires(count + start <= keys.Length);
            Contract.Requires(null == values || count + start <= values.Length);
            if (count < 2) {
                return;
            }
            SortPartIntrospectiveRecursionLimited(keys, comparer, start, unchecked(count + start - 1), unchecked(2 * SortUtilities.FloorLog2(keys.Length)), values);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void SortQuickRecursionLimited<TComparer, TValue>(T[] keys, TComparer comparer, IntT first, IntT last, int recLimit, TValue[] values) where TComparer : IComparer<T> {
            do {
                if (recLimit == 0) {
                    SortHeap(keys, comparer, first, last, values);
                    return;
                }
                var i = first;
                var j = last;
                var middle = unchecked(i + ((j - i) >> 1));
                SwapIfGreater(keys, comparer, i, middle, values);
                SwapIfGreater(keys, comparer, i, j, values);
                SwapIfGreater(keys, comparer, middle, j, values);
                var x = keys[middle];
                do {
                    while (comparer.Compare(x, keys[i]) > 0) {
                        ++i;
                    }
                    while (comparer.Compare(x, keys[j]) < 0) {
                        --j;
                    }
                    Contract.Assert(first <= i && j <= last);
                    if (i > j) {
                        break;
                    }
                    if (i < j) {
                        T key = keys[i];
                        keys[i] = keys[j];
                        keys[j] = key;
                        if (values != null) {
                            TValue value = values[i];
                            values[i] = values[j];
                            values[j] = value;
                        }
                    }
                    unchecked {
                        ++i;
                        --j;
                    }
                } while (i <= j);
                unchecked {
                    --recLimit;
                }
                if (j - first <= unchecked(last - i)) {
                    if (first < j) {
                        SortQuickRecursionLimited(keys, comparer, first, j, recLimit, values);
                    }
                    first = i;
                } else {
                    if (i < last) {
                        SortQuickRecursionLimited(keys, comparer, i, last, recLimit, values);
                    }
                    last = j;
                }
            } while (first < last);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Sort<TComparer, TValue>(T[] keys, TComparer comparer, IntT index, IntT length, TValue[] values) where TComparer : IComparer<T> {
            Contract.Assert(null != keys);
            Contract.Assert(0 <= index && 0 <= length && (length <= keys.Length - index));
            SortIntrospective(keys, comparer, index, length, values);
        }
    }
}

namespace UltimateOrb {
    using IntT = Int32;
    using UIntT = UInt32;

    using Contract = System.Diagnostics.Contracts.Contract;
    using SortUtilities = ArrayModule.SortUtilities;

    using System.Runtime.CompilerServices;

    public static partial class ArrayModule<T> {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void PartialSortQuick<TComparer, TValue>(T[] keys, TComparer comparer, IntT start, IntT count, int k, TValue[] values) where TComparer : IComparer<T> {
            PartialSortPartQuick(keys, comparer, start, start + count - 1, k, values);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void PartialSortPartQuick<TComparer, TValue>(T[] keys, TComparer comparer, IntT first, IntT last, int k, TValue[] values) where TComparer : IComparer<T> {
            if (last > first) {
                var pivot = PickPivotAndPartition(keys, comparer, first, last, values);
                if (pivot == k - 1) {
                    return;
                } else if (pivot > k - 1) {
                    PartialSortPartQuick(keys, comparer, first, pivot, k, values);
                } else {
                    PartialSortPartQuick(keys, comparer, unchecked(pivot + 1), last, k, values);
                }
            }
        }
    }
}

namespace UltimateOrb {
    using Contract = System.Diagnostics.Contracts.Contract;

    using System.Runtime.CompilerServices;

    public static partial class ArrayModule {

        internal static partial class SortUtilities {

            public const int SortIntroSizeThreshold = 16;

            public const int SortQuickDepthThreshold = 32;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal static int FloorLog2(UInt32 value) {
                Contract.Requires(value > 0);
                Contract.Ensures(0 <= Contract.Result<int>() && 32 > Contract.Result<int>());
                unchecked {
                    value |= (value >> 1);
                    value |= (value >> 2);
                    value |= (value >> 4);
                    value |= (value >> 8);
                    value |= (value >> 16);
                    value -= ((value >> 1) & 0x55555555u);
                    value = (((value >> 2) & 0x33333333u) + (value & 0x33333333u));
                    value = (((value >> 4) + value) & 0x0F0F0F0Fu);
                    value += (value >> 8);
                    value += (value >> 16);
                    return (int)((value & 0x0000003Fu) - 1);
                }
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal static int FloorLog2(Int32 unsigned) {
                Contract.Requires(unsigned > 0);
                Contract.Ensures(0 <= Contract.Result<int>() && 31 > Contract.Result<int>());
                return FloorLog2(unchecked((UInt32)unsigned));
            }
        }
    }
}