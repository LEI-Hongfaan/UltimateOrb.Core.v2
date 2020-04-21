using System;

namespace UltimateOrb.Mathematics {
    public static partial class DoubleArithmeticF {

        // Veltkamp’s splitter (= 1 + Pow(2, 27))
        const Double SplitterVeltkamp = 134217729;

        const Double SplitThreshold = 6.69692879491417e+299;

        // Møller’s and Knuth’s summation
        [System.CLSCompliantAttribute(false)]
        public static Double ToDouble(UInt64 value, out Double result_hi) {
            unchecked {
                var lo = (Double)(UInt32)value;
                var hi = (Double)(0xFFFFFFFF00000000u & value);
                var fp_hi = hi + lo;
                var t = fp_hi - lo;
                result_hi = fp_hi;
                return (hi - t) + (lo - (fp_hi - t));
            }
        }
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        static bool IsFinite(Double value) {
#if NETSTANDARD2_1
            return Double.IsFinite(value);
#else
            return 0x7FF0000000000000 > (0x7FFFFFFFFFFFFFFF & BitConverter.DoubleToInt64Bits(value));
#endif
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double BigAddPartial(Double first, Double second, out Double result_hi) {
            System.Diagnostics.Debug.Assert(Math.Abs(first) >= Math.Abs(second) || !IsFinite(first) || !IsFinite(second));
            var t = first + second;
            result_hi = t;
            return (first - t) + second;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double BigSubtractPartial(Double first, Double second, out Double result_hi) {
            System.Diagnostics.Debug.Assert(Math.Abs(first) >= Math.Abs(second) || !IsFinite(first) || !IsFinite(second));
            var t = first - second;
            result_hi = t;
            return (first - t) - second;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double BigAdd(Double first, Double second, out Double result_hi) {
            var t = first + second;
            var s = t - first;
            result_hi = t;
            return (first - (t - s)) + (second - s);
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double BigSubtract(Double first, Double second, out Double result_hi) {
            var t = first - second;
            var s = t - first;
            result_hi = t;
            return (first - (t - s)) - (second + s);
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double Add(Double first_lo, Double first_hi, Double second, Void _, out Double result_hi) {
            var tl = BigAdd(first_hi, second, out var th);
            tl += first_lo;
            th = BigAddPartial(th, tl, out tl);
            result_hi = th;
            return tl;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double Add(Double first, Void _, Double second_lo, Double second_hi, out Double result_hi) {
            var tl = BigAdd(first, second_hi, out var th);
            tl += second_lo;
            th = BigAddPartial(th, tl, out tl);
            result_hi = th;
            return tl;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double Add(Double first_lo, Double first_hi, Double second_lo, Double second_hi, out Double result_hi) {
            // K. Briggs and W. Kahan.
            var tl = BigAdd(first_hi, second_hi, out var th);
            var el = BigAdd(first_lo, second_lo, out var eh);
            tl += eh;
            tl = BigAddPartial(th, tl, out th);
            tl += el;
            tl = BigAddPartial(th, tl, out th);
            result_hi = th;
            return tl;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double AddRough(Double first_lo, Double first_hi, Double second_lo, Double second_hi, out Double result_hi) {
            var tl = BigAdd(first_hi, second_hi, out var th);
            tl += first_lo + second_lo;
            tl = BigAddPartial(th, tl, out th);
            result_hi = th;
            return tl;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double Subtract(Double first_lo, Double first_hi, Double second, Void _, out Double result_hi) {
            var tl = BigSubtract(first_hi, second, out var th);
            tl += first_lo;
            th = BigAddPartial(th, tl, out tl);
            result_hi = th;
            return tl;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double Subtract(Double first, Void _, Double second_lo, Double second_hi, out Double result_hi) {
            var tl = BigSubtract(first, second_hi, out var th);
            tl -= second_lo;
            th = BigAddPartial(th, tl, out tl);
            result_hi = th;
            return tl;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double Subtract(Double first_lo, Double first_hi, Double second_lo, Double second_hi, out Double result_hi) {
            var tl = BigSubtract(first_hi, second_hi, out var th);
            var el = BigSubtract(first_lo, second_lo, out var eh);
            tl += eh;
            tl = BigAddPartial(th, tl, out th);
            tl += el;
            tl = BigAddPartial(th, tl, out th);
            result_hi = th;
            return tl;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double SubtractRough(Double first_lo, Double first_hi, Double second_lo, Double second_hi, out Double result_hi) {
            var tl = BigSubtract(first_hi, second_hi, out var th);
            tl += first_lo - second_lo;
            tl = BigAddPartial(th, tl, out th);
            result_hi = th;
            return tl;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double Split(Double value, out Double result_hi) {
            // ToDo: CopySign, ScaleBPartial
            if (Math.Abs(value) <= SplitThreshold) {
                var t = SplitterVeltkamp * value;
                var hi = t - (t - value);
                var lo = value - hi;
                result_hi = hi;
                return lo;
            } else {
                value *= 3.7252902984619140625e-09; // Pow(2, -28)
                var t = SplitterVeltkamp * value;
                var hi = t - (t - value);
                var lo = value - hi;
                hi *= 268435456.0; // Pow(2, 28)
                lo *= 268435456.0; // Pow(2, 28)
                result_hi = hi;
                return lo;
            }
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double SplitPartial(Double value, out Double result_hi) {
            var t = SplitterVeltkamp * value;
            var hi = t - (t - value);
            var lo = value - hi;
            result_hi = hi;
            return lo;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double BigMul_A_Dekker(Double first, Double second, out Double product_hi) {
            var p = first * second;
            var first_lo = Split(first, out var first_hi);
            var second_lo = Split(second, out var second_hi);
            product_hi = p;
            return first_lo * second_lo + (first_lo * second_hi + first_hi * second_lo + (first_hi * second_hi - p));
        }


        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double BigMul(Double first, Double second, out Double product_hi) {
            return BigMul_A_Dekker(first, second, out product_hi);
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double BigSquare_A_Dekker(Double value, out Double product_hi) {
            var p = value * value;
            var value_lo = Split(value, out var value_hi);
            product_hi = p;
            var m = value_lo * value_hi;
            return value_lo * value_lo + (m + m + (value_hi * value_hi - p));
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double BigSquare(Double first, Double second, out Double product_hi) {
            return BigSquare_A_Dekker(first, out product_hi);
        }


        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double Multiply(Double first_lo, Double first_hi, Void _, Double second, out Double result_hi) {
            var tl = BigMul(first_hi, second, out var th);
            tl += first_lo * second;
            tl = BigAddPartial(th, tl, out th);
            result_hi = th;
            return tl;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double Multiply(Void _, Double first, Double second_lo, Double second_hi, out Double result_hi) {
            var tl = BigMul(first, second_hi, out var th);
            tl += first * second_lo;
            tl = BigAddPartial(th, tl, out th);
            result_hi = th;
            return tl;
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double Multiply(Double first_lo, Double first_hi, Double second_lo, Double second_hi, out Double result_hi) {
            var tl = BigMul(first_hi, second_hi, out var th);
            tl += first_lo * second_hi + first_hi * second_lo;
            tl = BigAddPartial(th, tl, out th);
            result_hi = th;
            return tl;
        }


        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double Divide(Double dividend_lo, Double dividend_hi, Double divisor_lo, Double divisor_hi, out Double quotient_hi) {
            var q1 = dividend_hi / divisor_hi;
            var pl = Multiply(_: default, q1, divisor_lo, divisor_hi, out var ph);
            SubtractRough(dividend_lo, dividend_hi, pl, ph, out var rh);
            var q2 = rh / divisor_hi;
            pl = Multiply(_: default, q2, divisor_lo, divisor_hi, out ph);
            SubtractRough(dividend_lo, dividend_hi, pl, ph, out rh);
            var q3 = rh / divisor_hi;
            q2 = BigAddPartial(q1, q2, out q1);
            return Add(q2, q1, q3, _: default, result_hi: out quotient_hi);
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double DivideRough(Double dividend_lo, Double dividend_hi, Double divisor_lo, Double divisor_hi, out Double quotient_hi) {
            var q1 = dividend_hi / divisor_hi;
            var rl = Multiply(divisor_lo, divisor_hi, _: default, q1, out var rh);

            var s2 = BigSubtract(dividend_hi, rh, out var s1);
            s2 -= rl;
            s2 += dividend_lo;

            var q2 = (s1 + s2) / divisor_hi;

            return BigAddPartial(q1, q2, out quotient_hi);
        }


        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double BigMulPartial(Double first, Double second, out Double product_hi) {
            var p = first * second;
            var first_lo = SplitPartial(first, out var first_hi);
            var second_lo = SplitPartial(second, out var second_hi);
            product_hi = p;
            return first_lo * second_lo + (first_lo * second_hi + first_hi * second_lo + (first_hi * second_hi - p));
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double BigSquarePartial(Double value, out Double result_hi) {
            var p = value * value;
            var value_lo = SplitPartial(value, out var value_hi);
            result_hi = p;
            var m = value_lo * value_hi;
            return value_lo * value_lo + (m + m + (value_hi * value_hi - p));
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Double DividePartial(Double dividend_lo, Double dividend_hi, Double divisor_lo, Double divisor_hi, out Double quotient_hi) {
            var s = dividend_hi / divisor_hi;
            var t_lo = BigMulPartial(s, divisor_hi, out var t_hi);
            var e = (dividend_hi - t_hi - t_lo + dividend_lo - s * divisor_lo) / divisor_hi;
            var qh = s + e;
            quotient_hi = qh;
            return e - (qh - s);
        }
    }
}
