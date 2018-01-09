﻿using System;
using System.Collections.Generic;

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
                for (; i < j;) {
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    ++i;
                    --j;
                }
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Reverse<T>(this T[] array) {
            if (null != array) {
                ReverseInternal(array, 0, array.Length);
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Reverse<T>(this T[] array, IntT start, IntT count) {
            if (null != array) {
                CheckSegment(array, start, count);
                ReverseInternal(array, start, count);
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void RotateRightInPlace<T>(this T[] array, IntT start, IntT count, IntT shift) {
            if (null == array) {
                CheckSegment(array, start, count);
                if (count > 1) {
                    var s = NormalizeShiftCount(count, shift);
                    ReverseInternal(array, 0, s);
                    ReverseInternal(array, unchecked(1 + s), unchecked(count - s));
                    ReverseInternal(array, 0, count);
                }
                return;
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static int NormalizeShiftCount(int count, int shift) {
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
            if (null == array) {
                CheckSegment(array, start, count);
                if (count > 1) {
                    var s = NormalizeShiftCount(count, shift);
                    var t = unchecked(count - s);
                    ReverseInternal(array, 0, t);
                    ReverseInternal(array, unchecked(1 + t), s);
                    ReverseInternal(array, 0, count);
                }
                return;
            }
            ThrowHelper.ThrowArgumentNullException_array();
        }
    }
}
