using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using static UltimateOrb.Utilities.BooleanIntegerModule;

namespace UltimateOrb.Numeric {

}
namespace UltimateOrb.Mathematics {

    using UIntT = UInt64;
    using IntT = Int64;



    public static partial class MultiArithmetic {

        [Conditional("ASSERTIONS_FULL")]
        public static void Assert(
#if NETSTANDARD2_1
            [DoesNotReturnIf(false)]
#endif
            bool condition) {

        }





#if NETSTANDARD2_1
        public static UIntT mpn_preinv_divrem_1(Span<UIntT> q, ReadOnlySpan<UIntT> a, UIntT d_unnorm, UIntT dinv, int shift) {

            unchecked {
                UIntT r;
                int i;
                UIntT d;
                var xsize = q.Length;
                Assert(xsize >= 0);
                var size = a.Length;
                Assert(size >= 1);
                Assert(d_unnorm != 0);

#if true || ASSERTIONS_FULL
                mpn_preinv_divrem_1_assert_1(d_unnorm, dinv, shift);
#endif

                /* FIXME: What's the correct overlap rule when xsize!=0? */
                Assert(IsSameOrSeparate(q.Slice(xsize), a));

                var ahigh = a[size - 1];
                d = d_unnorm << shift;
                var q_index = (size + xsize - 1);   /* dest high limb */

                if (shift == 0) {
                    /* High quotient limb is 0 or 1, and skip a divide step. */
                    r = ahigh;
                    var qhigh = (r >= d ? (UIntT)1 : 0);
                    r = (r >= d ? r - d : r);
                    q[q_index--] = qhigh;
                    size--;

                    for (i = size - 1; i >= 0; i--) {
                        q[q_index] = DoubleArithmetic.BigDivRemByInverseInternal(a[i], r, dinv, d, out r);
                        q_index--;
                    }
                } else {
                    UIntT n1, n0;

                    r = 0;
                    if (ahigh < d_unnorm) {
                        r = ahigh << shift;
                        q[q_index--] = 0;
                        size--;
                        if (size == 0) {
                            goto L_1;
                        }
                    }

                    n1 = a[size - 1];
                    r |= n1 >> (-shift/* sizeof(UIntT) - shift */);

                    for (i = size - 2; i >= 0; i--) {
                        Assert(r < d);
                        n0 = a[i];
                        q[q_index] = DoubleArithmetic.BigDivRemByInverseInternal((n1 << shift) | (n0 >> (-shift/* sizeof(UIntT) - shift */)), r, dinv, d, out r);
                        q_index--;
                        n1 = n0;
                    }
                    q[q_index] = DoubleArithmetic.BigDivRemByInverseInternal(n1 << shift, r, dinv, d, out r);
                    q_index--;
                }

            L_1:;
                for (i = 0; i < xsize; i++) {
                    q[q_index] = DoubleArithmetic.BigDivRemByInverseInternal(_: default, r, dinv, d, out r);
                    q_index--;
                }

                return r >> shift;
            }
        }
#endif

        private static void mpn_preinv_divrem_1_assert_1(UIntT d_unnorm, UIntT dinv, int shift) {
            unchecked {
                var want_shift = BinaryNumerals.CountLeadingZeros(d_unnorm);
                Assert(shift == want_shift);
                var want_dinv = invert_limb(d_unnorm << shift);
                Assert(dinv == want_dinv);
            }
        }

        public static UIntT invert_limb(UIntT v) {
            Assert(v != 0);
            return DoubleArithmetic.BigDivRemPartialInternal(~(UIntT)0, ~v, v, out _);
        }

        public static UInt64 invert_limb_A(UInt64 v) {
            Assert(v != 0);
            unchecked {
                var v0 = (uint)invert_limb_table_64((int)(v >> 55));
                var d40s25p1 = 1 + (v >> 24);
                var v1 = (v0 << 11) - 1 - (UInt32)(((v0 * v0) * d40s25p1) >> 40);
                var v2 = (v1 << 13) + (v1 * (((UInt64)1 << 60) - d40s25p1 * v1) >> 47);
                throw new NotImplementedException();
            }
            
        }

        public static int invert_limb_table_64(int bits9shifted55) {
            Assert(256 <= bits9shifted55 && bits9shifted55 < 512);
            return unchecked((int)(523520.0/* 0x7fd00 */ / bits9shifted55));
        }
        
    }
}
namespace UltimateOrb.Mathematics {



    public static partial class MultiArithmetic {


#if NETSTANDARD2_1
        public static void Increase(Span<UInt64> value) {
            for (var t = value; 0 == ++t[0]; t = t.Slice(1)) {
            }
        }

        public static void Decrease(Span<UInt64> value) {
            for (var t = value; 0 == t[0]--; t = t.Slice(1)) {
            }
        }

        static bool IsOverlapping<T>(this T[] first, T[] second) {
            return first == second;
        }

        static unsafe bool IsOverlapping<T>(this ReadOnlySpan<T> first, ReadOnlySpan<T> second) where T : unmanaged {
            fixed (T* first_offset = &first[0])
            fixed (T* second_offset = &second[0]) {
                return
                    first_offset + first.Length > second_offset &&
                    second_offset + second.Length > first_offset;
            }
        }

        static bool IsSameOrSeparate<T>(this T[] first, T[] second) {
            return true;
        }

        static unsafe bool IsSameOrSeparate<T>(this ReadOnlySpan<T> first, ReadOnlySpan<T> second) where T : unmanaged {
            fixed (T* first_offset = &first[0])
            fixed (T* second_offset = &second[0]) {
                return
                    !(first_offset != second_offset) ||
                    !IsOverlapping(first, second);
            }
        }

        static bool IsSameOrPreceding<T>(this T[] first, T[] second) {
            return true;
        }

        static unsafe bool IsSameOrPreceding<T>(this ReadOnlySpan<T> first, ReadOnlySpan<T> second) where T : unmanaged {
            fixed (T* first_offset = &first[0])
            fixed (T* second_offset = &second[0]) {
                return
                    !(first_offset > second_offset) ||
                    !IsOverlapping(first, second);
            }
        }

        static bool IsSameOrSucceeding<T>(this T[] first, T[] second) {
            return true;
        }

        static unsafe bool IsSameOrSucceeding<T>(this ReadOnlySpan<T> first, ReadOnlySpan<T> second) where T : unmanaged {
            fixed (T* first_offset = &first[0])
            fixed (T* second_offset = &second[0]) {
                return
                    !(first_offset < second_offset) ||
                    !IsOverlapping(first, second);
            }
        }

    //    static object Add(int cout, Span<UInt64> w, ReadOnlySpan<UInt64> x, ReadOnlySpan<UInt64> y) {                                                                  \
    
    //UInt64 __gmp_x;

    //        Assert(y.Length >= 0);
    //        Assert(x.Length >= y.Length);
    //        Assert(IsSameOrSeparate(w, x));
    //        Assert(IsSameOrSeparate(w, y));

    //        var __gmp_i = y.Length;
    //        if (__gmp_i != 0) {
    //            if (FUNCTION(wp, xp, yp, __gmp_i)) {
    //                do {
    //                    if (__gmp_i >= (xsize)) {
    //                        (cout) = 1;
    //                        goto __gmp_done;
    //                    }
    //                    __gmp_x = x[__gmp_i];
    //                }
    //                while (TEST);
    //            }
    //        }
    //        if ((wp) != (xp))
    //            __GMPN_COPY_REST(wp, xp, xsize, __gmp_i);
    //        (cout) = 0;
    //    __gmp_done:;
    //    }





        static void CopyRest<T>(this Span<T> dst, ReadOnlySpan<T> src, int size, int start) {
            Copy(dst.Slice(start), src.Slice(start), (size) - (start));
        }

        static void Copy<T>(this Span<T> dst, ReadOnlySpan<T> src, int c) {
            src.CopyTo(dst.Slice(0, c));
        }

        public static uint Add(ReadOnlySpan<UInt64> first, UInt64 second, Span<UInt64> result) {
            Assert(first != null);
            Assert(first.Length >= 1);
            Assert(result != null);
            Assert(result.Length >= first.Length);


            unchecked {
                var bits = result;

                var digit = first[0] + second;
                bits[0] = digit;
                var carry = (second > digit).AsIntegerUnsafe();

                for (int i = 1; i < first.Length; i++) {
                    digit = first[i] + (uint)carry;
                    bits[i] = digit;
                    carry = (second > digit).AsIntegerUnsafe();
                }
                return (uint)carry;
            }

        }
#endif
    }
}
