using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UltimateOrb.Mathematics;

namespace UltimateOrb {

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 16)]
    public readonly struct Quadruple : IEquatable<Quadruple> {

        readonly UInt64 _Lo64Bits;

        readonly UInt64 _Hi64Bits;

        const int FractionBitCount = 112;

        const int ExponentBitCount = 15;

        const UInt64 Hi64BitsImplicitBit = (UInt64)1 << (FractionBitCount - 64);

        const UInt64 Hi64BitsFractionMask = Hi64BitsImplicitBit - 1;

        const UInt64 Hi64BitsExponentMask = (((UInt64)1 << ExponentBitCount) - 1) << (FractionBitCount - 64);

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        Quadruple(UInt64 lo64Bits, UInt64 hi64Bits) {
            _Lo64Bits = lo64Bits;
            _Hi64Bits = hi64Bits;
        }

        UInt64 ShiftedSignificandHi {

            [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            get => unchecked((UInt64)(Hi64BitsFractionMask & _Hi64Bits));
        }

        UInt64 ShiftedSignificandLo {

            [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            get => _Lo64Bits;
        }

        public static Quadruple operator +(Quadruple value) {
            return value;
        }

        public static Quadruple operator -(Quadruple value) {
            return new Quadruple(value._Lo64Bits, 0x8000000000000000 ^ value._Hi64Bits);
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public static Quadruple operator +(Quadruple first, Quadruple second) {

            var uiA64 = first._Hi64Bits;
            var uiA0 = first._Lo64Bits;
            var signA = unchecked((int)(uiA64 >> (64 - 1)));
            var uiB64 = second._Hi64Bits;
            var uiB0 = second._Lo64Bits;
            var signB = unchecked((int)(uiB64 >> (64 - 1)));
            if (signA == signB) {
                return Helper.softfloat_addMagsF128(uiA64, uiA0, uiB64, uiB0, signA, FloatingPointRounding.ToNearestWithMidpointToEven);
            } else {
                return Helper.softfloat_subMagsF128(uiA64, uiA0, uiB64, uiB0, signA, FloatingPointRounding.ToNearestWithMidpointToEven);
            }
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public static Quadruple operator -(Quadruple first, Quadruple second) {

            var uiA64 = first._Hi64Bits;
            var uiA0 = first._Lo64Bits;
            var signA = unchecked((int)(uiA64 >> (64 - 1)));
            var uiB64 = second._Hi64Bits;
            var uiB0 = second._Lo64Bits;
            var signB = unchecked((int)(uiB64 >> (64 - 1)));
            if (signA == signB) {
                return Helper.softfloat_subMagsF128(uiA64, uiA0, uiB64, uiB0, signA, FloatingPointRounding.ToNearestWithMidpointToEven);
            } else {
                return Helper.softfloat_addMagsF128(uiA64, uiA0, uiB64, uiB0, signA, FloatingPointRounding.ToNearestWithMidpointToEven);
            }
        }

        public static Quadruple operator *(Quadruple first, Quadruple second) {
            var first_e = 0x7FFF000000000000 & first._Hi64Bits;
            var second_e = 0x7FFF000000000000 & second._Hi64Bits;
            if (0x7FFF000000000000 != first_e) {
                if (0x7FFF000000000000 != second_e) {
                    var first_lo = first.ShiftedSignificandLo;
                    var first_hi = first.ShiftedSignificandHi;
                    var f = -0x3FFF;
                    if (0 != first_e) {
                        first_hi |= Hi64BitsImplicitBit;
                    } else {
                        if (0 == (first_hi | first_lo)) {
                            return new Quadruple(0, 0x8000000000000000 & (first._Lo64Bits ^ second._Lo64Bits));
                        }
                        unchecked {
                            ++f;
                        }
                    }

                    var second_lo = second.ShiftedSignificandLo;
                    var second_hi = second.ShiftedSignificandHi;
                    if (0 != first_e) {
                        first_hi |= Hi64BitsImplicitBit;
                    } else {
                        if (0 == (second_hi | second_lo)) {
                            return new Quadruple(0, 0x8000000000000000 & (first._Lo64Bits ^ second._Lo64Bits));
                        }
                        unchecked {
                            ++f;
                        }
                    }
                    unchecked {
                        f += (int)((first_e + second_e) >> (FractionBitCount - 64));
                    }



                    var result_lo_lo = DoubleArithmetic.BigMul(first_lo, first_hi, second_lo, second_hi, out var result_lo_hi, out var result_hi_lo, out var result_hi_hi);

                    var c = BinaryNumerals.CountLeadingZeros(result_hi_hi);
                    if (64 != c) {
                    } else if (2 * 64 != unchecked(c += BinaryNumerals.CountLeadingZeros(result_hi_lo))) {
                    } else if (3 * 64 != unchecked(c += BinaryNumerals.CountLeadingZeros(result_lo_hi))) {
                    } else {
                        unchecked {
                            c += BinaryNumerals.CountLeadingZeros(result_lo_lo);
                        }
                        Debug.Assert(4 * 64 != c);
                    }


                    throw new NotImplementedException();
                } else {
                    // NaN, Infinity
                    return MultiplyNonFiniteByFinite(second, first);
                }
            } else {
                // NaN, Infinity
                if (0x7FFF000000000000 != second_e) {
                    return MultiplyNonFiniteByFinite(first, second);
                } else {
                    // NaN, Infinity
                    // {NaN,Infinity} * {NaN,Infinity}
                    return OrThenMultiplyBySign(first, second);
                }
            }


            /**
             * if (qd1.Exponent <= notANumberExponent) //zero/infinity/NaN * something            
                return specialMultiplicationTable[(int)(qd1.Exponent - zeroExponent), qd2.Exponent > notANumberExponent ? (int)(4 + (qd2.SignificandBits >> 63)) : (int)(qd2.Exponent - zeroExponent)];
            else if (qd2.Exponent <= notANumberExponent) //finite * zero/infinity/NaN            
                return specialMultiplicationTable[(int)(4 + (qd1.SignificandBits >> 63)), (int)(qd2.Exponent - zeroExponent)];

            ulong high1 = (qd1.SignificandBits | highestBit) >> 32; //de-implicitize the 1
            ulong high2 = (qd2.SignificandBits | highestBit) >> 32;

            //because the MSB of both significands is 1, the MSB of the result will also be 1, and the product of low bits on both significands is dropped (and thus we can skip its calculation)
            ulong significandBits = high1 * high2 + (((qd1.SignificandBits & lowWordMask) * high2) >> 32) + ((high1 * (qd2.SignificandBits & lowWordMask)) >> 32);

            long qd2Exponent;
            Quad result;
            if (significandBits < (1UL << 63))
            {
                qd2Exponent = qd2.Exponent - 1 + 64;
                result = new Quad(((qd1.SignificandBits ^ qd2.SignificandBits) & highestBit) | ((significandBits << 1) & ~highestBit), qd1.Exponent + qd2Exponent);
            }
            else
            {
                qd2Exponent = qd2.Exponent + 64;
                result = new Quad(((qd1.SignificandBits ^ qd2.SignificandBits) & highestBit) | (significandBits & ~highestBit), qd1.Exponent + qd2Exponent);
            }

            if (qd2Exponent < 0 && result.Exponent > qd1.Exponent) //did the exponent get larger after adding something negative?
                return Zero; //underflow
            else if (qd2Exponent > 0 && result.Exponent < qd1.Exponent) //did the exponent get smaller when it should have gotten larger?
                return result.SignificandBits >= highestBit ? NegativeInfinity : PositiveInfinity; //overflow
            else if (result.Exponent < exponentLowerBound) //check for underflow
                return Zero;
            else if (result.Exponent > exponentUpperBound) //overflow
                return result.SignificandBits >= highestBit ? NegativeInfinity : PositiveInfinity; //overflow
            else
                return result;
             */

        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        private static Quadruple MultiplyNonFiniteByFinite(Quadruple nonfinite, Quadruple finite) {
            if (Quadruple.IsInfinity(nonfinite)) {
                if (!Quadruple.IsZero(finite)) {
                    // {Infinity} * {NonZeroFiniteNumber}
                    // Result: Infinity
                } else {
                    // {Infinity} * {Zero}
                    // Result: Zero
                    return MultiplyBySign(finite, nonfinite);
                }
            } else {
                // {NaN} * {FiniteNumber}
                // Result: NaN
            }
            // {NaN} * {FiniteNumber}
            // Result: NaN
            // {Infinity} * {NonZeroFiniteNumber}
            // Result: Infinity
            return MultiplyBySign(nonfinite, finite);
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        static Quadruple OrThenMultiplyBySign(Quadruple first, Quadruple second) {
            return new Quadruple(first._Lo64Bits | second._Lo64Bits, (0x7FFFFFFFFFFFFFFF & (first._Lo64Bits | second._Lo64Bits)) | (0x8000000000000000 & (first._Lo64Bits ^ second._Lo64Bits)));
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        static Quadruple MultiplyBySign(Quadruple value, Quadruple sign) {
            return new Quadruple(value._Lo64Bits, value._Hi64Bits ^ (0x8000000000000000 & sign._Hi64Bits));
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool IsInfinity(Quadruple value) {
            return (value._Lo64Bits == 0 && unchecked((value._Hi64Bits & 0x7FFFFFFFFFFFFFFF) == 0x7FFF000000000000));
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool IsFinite(Quadruple value) {
            return 0x7FFF000000000000 != (0x7FFF000000000000 & value._Hi64Bits);
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool IsNaN(Quadruple value) {
            // (value._Hi64Bits & 0x7FFF000000000000) == 0x7FFF000000000000 && !IsInfinity(value);
            return DoubleArithmetic.GreaterThan(value._Lo64Bits, 0x7FFFFFFFFFFFFFFFu & value._Hi64Bits, 0u, 0x7FFF000000000000u);
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool IsPositiveInfinity(Quadruple value) {
            return (value._Lo64Bits == 0 && value._Hi64Bits == 0x7FFF000000000000);
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool IsNegativeInfinity(Quadruple value) {
            return (value._Lo64Bits == 0 && value._Hi64Bits == 0xFFFF000000000000);
        }

        public static bool IsNegative(Quadruple value) {
            return 0 > unchecked((Int64)value._Hi64Bits);
        }

        public static bool IsNormal(Quadruple value) {
            var hi = 0x7FFF000000000000U & value._Hi64Bits;
            return 0x7FFF000000000000U > hi && hi > 0;
        }

        public static bool IsSubnormal(Quadruple value) {
            var hi = 0x7FFF000000000000U & value._Hi64Bits;
            return 0 == hi && (0 != value._Lo64Bits || 0 != (0x7FFFFFFFFFFFFFFFU & value._Hi64Bits));
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool IsZero(Quadruple value) {
            return (value._Lo64Bits == 0 && unchecked((value._Hi64Bits & 0x7FFFFFFFFFFFFFFF) == 0x0000000000000000));
        }

        public override bool Equals(object obj) {
            return obj is Quadruple quadruple && Equals(quadruple);
        }

        public bool Equals(Quadruple other) {
            if (IsNaN(this)) {
                return IsNaN(other);
            }
            if (IsNaN(other)) {
                return false;
            }
            return EqualsNonNaN(this, other);
        }

        static bool IsNaN_A(Quadruple value) {
            return (0 == (0x7FFF000000000000U & ~value._Hi64Bits)) && (0 != value._Lo64Bits || 0 != (0x0000FFFFFFFFFFFF & value._Hi64Bits));
        }

        static bool EqualsNonNaN(Quadruple first, Quadruple second) {
            return first._Lo64Bits == second._Lo64Bits && (first._Hi64Bits == second._Hi64Bits || (0 == first._Lo64Bits && 0 == (0x7FFFFFFFFFFFFFFFU & (first._Hi64Bits | second._Hi64Bits))));
        }

        public static bool operator ==(Quadruple first, Quadruple second) {
            if (IsNaN(first) || IsNaN(second)) {
                return false;
            }
            return EqualsNonNaN(first, second);
        }

        public static bool operator !=(Quadruple first, Quadruple second) {
            return !(first == second);
        }

        public static bool operator <(Quadruple first, Quadruple second) {
            if (IsNaN(first) || IsNaN(second)) {
                return false;
            }
            var first_sign = first.RawSign;
            var second_sign = second.RawSign;
            return (first_sign != second_sign) ?
                ((0 != first_sign) && (0 != ((0x7FFFFFFFFFFFFFFFU & (first._Hi64Bits | second._Hi64Bits)) | first._Lo64Bits | second._Lo64Bits))) :
                (((first._Hi64Bits != second._Hi64Bits) || (first._Lo64Bits != second._Lo64Bits)) && ((0 != first_sign) ^ DoubleArithmetic.LessThan(first._Lo64Bits, first._Hi64Bits, second._Lo64Bits, second._Hi64Bits)));
        }

        public static bool operator >(Quadruple first, Quadruple second) {
            if (IsNaN(first) || IsNaN(second)) {
                return false;
            }
            var first_sign = first.RawSign;
            var second_sign = second.RawSign;
            return (first_sign != second_sign) ?
                ((0 == first_sign) && (0 != ((0x7FFFFFFFFFFFFFFFU & (first._Hi64Bits | second._Hi64Bits)) | first._Lo64Bits | second._Lo64Bits))) :
                (((first._Hi64Bits != second._Hi64Bits) || (first._Lo64Bits != second._Lo64Bits)) && ((0 == first_sign) == DoubleArithmetic.GreaterThan(first._Lo64Bits, first._Hi64Bits, second._Lo64Bits, second._Hi64Bits)));
        }

        public static bool operator <=(Quadruple first, Quadruple second) {
            if (IsNaN(first) || IsNaN(second)) {
                return false;
            }
            var first_sign = first.RawSign;
            var second_sign = second.RawSign;
            return (first_sign != second_sign) ?
                ((0 != first_sign) || (0 == ((0x7FFFFFFFFFFFFFFFU & (first._Hi64Bits | second._Hi64Bits)) | first._Lo64Bits | second._Lo64Bits))) :
                (((first._Hi64Bits == second._Hi64Bits) && (first._Lo64Bits == second._Lo64Bits)) || ((0 != first_sign) ^ DoubleArithmetic.LessThan(first._Lo64Bits, first._Hi64Bits, second._Lo64Bits, second._Hi64Bits)));
        }

        public static bool operator >=(Quadruple first, Quadruple second) {
            if (IsNaN(first) || IsNaN(second)) {
                return false;
            }
            var first_sign = first.RawSign;
            var second_sign = second.RawSign;
            return (first_sign != second_sign) ?
                ((0 == first_sign) || (0 == ((0x7FFFFFFFFFFFFFFFU & (first._Hi64Bits | second._Hi64Bits)) | first._Lo64Bits | second._Lo64Bits))) :
                (((first._Hi64Bits == second._Hi64Bits) && (first._Lo64Bits == second._Lo64Bits)) || ((0 == first_sign) == DoubleArithmetic.GreaterThan(first._Lo64Bits, first._Hi64Bits, second._Lo64Bits, second._Hi64Bits)));
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public override int GetHashCode() {
            var lo = this._Lo64Bits;
            var hi = this._Hi64Bits;
            // x => IsNan(x) || IsZero(x)
            if (DoubleArithmetic.LessThanOrEqual(0, 0x7FFF000000000000U, DoubleArithmetic.DecreaseUnchecked(lo, hi, out var t_hi), 0x7FFFFFFFFFFFFFFFU & t_hi)) {
                return (0x7FFF000000000000U & hi).GetHashCode();
            }
            return lo.GetHashCode() ^ hi.GetHashCode();
        }

        //public static Quadruple PositiveZero {

        //    [System.Runtime.TargetedPatchingOptOutAttribute("")]
        //    [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        //    [System.Diagnostics.Contracts.PureAttribute()]
        //    get {
        //        return new Quadruple(0, UInt64.MinValue);
        //    }
        //}

        //public static Quadruple NegativeZero {

        //    [System.Runtime.TargetedPatchingOptOutAttribute("")]
        //    [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        //    [System.Diagnostics.Contracts.PureAttribute()]
        //    get {
        //        return new Quadruple(0, unchecked((UInt64)Int64.MinValue));
        //    }
        //}

        public static Quadruple PositiveInfinity {

            [System.Runtime.TargetedPatchingOptOutAttribute("")]
            [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            [System.Diagnostics.Contracts.PureAttribute()]
            get => new Quadruple(0, 0x7FFF000000000000u);
        }

        public static Quadruple NaN {

            [System.Runtime.TargetedPatchingOptOutAttribute("")]
            [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            [System.Diagnostics.Contracts.PureAttribute()]
            get => new Quadruple(0, 0xFFFF800000000000u);
        }

        public static Quadruple NegativeInfinity {

            [System.Runtime.TargetedPatchingOptOutAttribute("")]
            [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            [System.Diagnostics.Contracts.PureAttribute()]
            get => new Quadruple(0, 0xFFFF000000000000u);
        }

        public static Quadruple MaxValue {

            [System.Runtime.TargetedPatchingOptOutAttribute("")]
            [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            [System.Diagnostics.Contracts.PureAttribute()]
            get => new Quadruple(0xFFFFFFFFFFFFFFFFu, 0x7FFEFFFFFFFFFFFFu);
        }

        public static Quadruple MinValue {

            [System.Runtime.TargetedPatchingOptOutAttribute("")]
            [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            [System.Diagnostics.Contracts.PureAttribute()]
            get => new Quadruple(0xFFFFFFFFFFFFFFFFu, 0xFFFEFFFFFFFFFFFFu);
        }

        public static Quadruple Epsilon {

            [System.Runtime.TargetedPatchingOptOutAttribute("")]
            [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            [System.Diagnostics.Contracts.PureAttribute()]
            get => new Quadruple(1, 0);
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static implicit operator Quadruple(Double value) {
            var lo = unchecked((UInt64)System.BitConverter.DoubleToInt64Bits(value));
            var e = (unchecked((int)(lo >> 52)) & ((1 << 11) - 1)) + (0x3FFF - (1024 - 1));
            UInt64 hi = 0x8000000000000000u & lo;
            lo &= ((UInt64)1 << 52) - 1;
            if ((0x3FFF - (1024 - 1)) != e) {
                if (((1 << 11) - 1) + (0x3FFF - (1024 - 1)) != e) {
                } else {
                    e = 0x7FFF;
                }
            } else {
                if (lo <= 1) {
                    return new Quadruple(0, (unchecked((UInt64)(-(Int64)lo)) & ((UInt64)(1 + (0x3FFF - (1024 - 1)) - 52) << (FractionBitCount - 64))) | hi);
                }
                var c = BinaryNumerals.CountLeadingZeros(lo);
                unchecked {
                    // e += unchecked(1 + (64 - 52) - (1 + c));
                    e += unchecked((64 - 52) - c);
                }
                lo <<= unchecked(1 + c);
                lo >>= (64 - 52);
            }
            hi |= unchecked((UInt64)e) << (FractionBitCount - 64);
            return new Quadruple(lo << (FractionBitCount - 52), (lo >> (64 - (FractionBitCount - 52))) | hi);
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static explicit operator Double(Quadruple value) {
            var e = (unchecked((int)(value._Hi64Bits >> (FractionBitCount - 64))) & ((1 << ExponentBitCount) - 1)) + ((1024 - 1) - 0x3FFF);
            UInt64 hi = 0x8000000000000000u & value._Hi64Bits;
            var lo = Hi64BitsFractionMask & value._Hi64Bits;
            var t = value._Lo64Bits;
            if (e > 0) {
                if (0x7FF > e) {
                    hi |= unchecked((UInt64)e) << 52;
                    lo = lo << 6 | t >> 58 | ((UInt64)(t << 6) == 0 ? 0u : 1u);
                } else {
                    goto L_NF;
                }
            } else {
                goto L_Sub;
            }
        L_0:;
            lo = unchecked((lo >> 2) + (1u & (0Xc8U >> (7 & unchecked((int)lo)))));
        L_1:;
            return System.BitConverter.Int64BitsToDouble(unchecked((Int64)(hi | lo)));
        L_Sub:;
            {
                // Subnormal or Zero
                if ((1024 - 1) - 0x3FFF != e || 0 != (lo | t)) {
                    lo |= Hi64BitsImplicitBit;
                    var count = unchecked(64 - 2 + -3 - e);
                    UInt64 s;
                    if (count < 64) {
                        var minus_count = unchecked(-count);
                        lo = lo << (/*63 & */minus_count) | t >> count | ((UInt64)(t << (/*63 & */minus_count)) == 0 ? 0u : 1u);
                    } else {
                        lo = (count < 127) ?
                            lo >> (/*63 & */count) | (((lo & (((UInt64)1 << (/*63 & */count)) - 1)) | t) == 0 ? 0u : 1u) :
                            (0 == (lo | t) ? 0u : 1u);
                    }
                    goto L_0;
                } else {
                    lo = 0;
                    goto L_1;
                }
            }
        L_NF:;
            hi |= 0x7FF0000000000000u;
            if (((1 << ExponentBitCount) - 1) + ((1024 - 1) - 0x3FFF) != e) {
                lo = 0;
            } else {
                lo = (lo << 4) | (t >> 60) | (0x0FFFFFFFFFFFFFFFu & t) >> 13 | (0x1FFFu & t);
            }
            goto L_1;
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static implicit operator Quadruple(Int64 value) {
            if (0 != value) {
                var a = unchecked((UInt64)(0 > value ? -value : value));
                if (1 == a) {
                    return new Quadruple(0, (0x8000000000000000u & unchecked((UInt64)value)) ^ 0x3FFF000000000000u);
                }
                var c = BinaryNumerals.CountLeadingZeros(a);
                // 1    63
                // 0x3FFF000000000000 0000000000000000
                // 2    62
                // 0x4000000000000000 0000000000000000
                a <<= unchecked(1 + c);
                return new Quadruple(a << (FractionBitCount - 64), (0x8000000000000000u & unchecked((UInt64)value)) ^ ((unchecked((UInt64)(0x3FFF + (64 - 1) - c)) << (FractionBitCount - 64)) | (a >> (128 - FractionBitCount))));
            }
            return default;
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static implicit operator Quadruple(UInt64 value) {
            var a = value;
            if (2 <= a) {
                var c = BinaryNumerals.CountLeadingZeros(a);
                a <<= unchecked(1 + c);
                return new Quadruple(a << (FractionBitCount - 64), (unchecked((UInt64)(0x3FFF + (64 - 1) - c)) << (FractionBitCount - 64)) | (a >> (128 - FractionBitCount)));
            }
            if (0 == a) {
                return default;
            }
            return new Quadruple(0, 0x3FFF000000000000u);
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static explicit operator UInt64(Quadruple value) {
            if (0 <= unchecked((Int64)value._Hi64Bits)) {
                _ = checked(0xBFC1000000000000u + (UInt64)value._Hi64Bits);
                var e = 0x7FFF & unchecked((int)(value._Hi64Bits >> (FractionBitCount - 64)));
                var hi = 0x0001000000000000U | (Hi64BitsFractionMask & value._Hi64Bits);
                var count = 0x402F - e;
                if (0 > count) {
                    return (hi << -count) | (value._Lo64Bits >> (/*63 & */count));
                } else {
                    if (49 <= count) {
                        return 0;
                    }
                    return hi >> count;
                }
            }
            {
                _ = checked(0x4001000000000000u + (UInt64)value._Hi64Bits);
                return 0;
            }
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static explicit operator UInt32(Quadruple value) {
            if (0 <= unchecked((Int64)value._Hi64Bits)) {
                _ = checked(0xBFE1000000000000u + (UInt64)value._Hi64Bits);
                var e = 0x7FFF & unchecked((int)(value._Hi64Bits >> (FractionBitCount - 64)));
                var hi = 0x0001000000000000U | (Hi64BitsFractionMask & value._Hi64Bits);
                var count = 0x402F - e;
                if (49 <= count) {
                    return 0;
                }
                return unchecked((UInt32)(hi >> count));
            }
            {
                _ = checked(0x4001000000000000u + (UInt64)value._Hi64Bits);
                return 0;
            }
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static implicit operator Quadruple(Int32 value) {
            if (0 != value) {
                var a = unchecked((UInt32)(0 > value ? -value : value));
                if (1 == a) {
                    return new Quadruple(0, (0x8000000000000000u & unchecked((UInt64)(Int64)value)) ^ 0x3FFF000000000000u);
                }
                var c = BinaryNumerals.CountLeadingZeros(unchecked((UInt32)a));
                // 1    63
                // 0x3FFF000000000000 0000000000000000
                // 2    62
                // 0x4000000000000000 0000000000000000
                a <<= unchecked(1 + c);
                return new Quadruple(0, (0x8000000000000000u & unchecked((UInt64)(Int64)value)) ^ ((unchecked((UInt64)(0x3FFF + (32 - 1) - c)) << (FractionBitCount - 64)) | ((UInt64)a << ((FractionBitCount - 64) - 32))));
            }
            return default;
        }

        [System.Runtime.TargetedPatchingOptOutAttribute("")]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static implicit operator Quadruple(UInt32 value) {
            var a = value;
            if (2 <= a) {
                var c = BinaryNumerals.CountLeadingZeros(a);
                a <<= unchecked(1 + c);
                return new Quadruple(0, (unchecked((UInt64)(0x3FFF + (32 - 1) - c)) << (FractionBitCount - 64)) | ((UInt64)a << ((FractionBitCount - 64) - 32)));
            }
            if (0 == a) {
                return default;
            }
            return new Quadruple(0, 0x3FFF000000000000u);
        }

        int RawSign {

            get => unchecked((int)(((UInt64)this._Hi64Bits) >> 63));
        }


        static class Helper {


            static UInt64 GetHi64BitsFromParts112(int sign, int exponent, UInt64 fraction) {
                return unchecked(((UInt64)sign << (64 - 1)) + ((UInt64)exponent << (FractionBitCount - 64)) + fraction);
            }

            static Quadruple FromParts112(int sign, int exponent, UInt64 fraction) {
                return new Quadruple(0, GetHi64BitsFromParts112(sign, exponent, fraction));
            }

            static Quadruple FromParts112(int sign, int exponent, UInt64 fraction_d1, UInt64 fraction_d0) {
                return new Quadruple(fraction_d0, GetHi64BitsFromParts112(sign, exponent, fraction_d1));
            }

            static void ShiftRightWithJamming(UInt64 value_d1, UInt64 value_d0, int count, out UInt64 result_d1, out UInt64 result_d0) {
                Debug.Assert(0 <= count);
                if (count < 64) {
                    var minus_count = unchecked(-count);
                    result_d1 = value_d1 >> count;
                    result_d0 = value_d1 << (/*63 & */minus_count) | value_d0 >> count | ((UInt64)(value_d0 << (/*63 & */minus_count)) == 0 ? 0u : 1u);
                } else {
                    result_d1 = 0;
                    result_d0 = (count < 127) ?
                        value_d1 >> (/*63 & */count) | (((value_d1 & (((UInt64)1 << (/*63 & */count)) - 1)) | value_d0) == 0 ? 0u : 1u) :
                        ((value_d1 | value_d0) == 0 ? 0u : 1u);
                }
            }

            static void ShiftRight128WithJamming(UInt64 value_d1, UInt64 value_d0, UInt64 value_dM1, int count, out UInt64 result_d1, out UInt64 result_d0, out UInt64 result_dM1) {
                UInt64 r;
                var minus_count = unchecked(-count);
                if (count < 64) {
                    result_d1 = value_d1 >> count;
                    result_d0 = (value_d1 << (/*63 & */minus_count)) | (value_d0 >> count);
                    r = value_d0 << (/*63 & */minus_count);
                } else {
                    result_d1 = 0;
                    if (count == 64) {
                        result_d0 = value_d1;
                        r = value_d0;
                    } else {
                        value_dM1 |= value_d0;
                        if (count < 128) {
                            result_d0 = value_d1 >> (/*63 & */count);
                            r = value_d1 << (/*63 & */minus_count);
                        } else {
                            result_d0 = 0;
                            r = (count == 128) ? value_d1 : (value_d1 != 0 ? (UInt64)1 : 0);
                        }
                    }
                }
                if (0 != value_dM1) {
                    r |= 1;
                }
                result_dM1 = r;
            }

            static void ShiftRight128WithJammingPartial(UInt64 value_d1, UInt64 value_d0, UInt64 value_dM1, int count, out UInt64 result_d1, out UInt64 result_d0, out UInt64 result_dM1) {
                var minus_count = unchecked(-count);
                result_d1 = value_d1 >> count;
                result_d0 = (value_d1 << (/*63 & */minus_count)) | (value_d0 >> count);
                result_dM1 = (value_d0 << (/*63 & */minus_count)) | (0 == value_dM1 ? 0u : 1u);
            }

            static Quadruple softfloat_normRoundPackToF128(int sign, int exp, UInt64 sig64, UInt64 sig0, FloatingPointRounding rounding) {
                if (0 == sig64) {
                    exp -= 64;
                    sig64 = sig0;
                    sig0 = 0;
                }
                var shiftDist = BinaryNumerals.CountLeadingZeros(sig64) - 15;
                exp -= shiftDist;
                UInt64 sigExtra;
                if (0 <= shiftDist) {
                    if (0 != shiftDist) {
                        sig0 = DoubleArithmetic.ShiftLeft(sig0, sig64, shiftDist, out sig64);
                    }
                    if (unchecked((uint)exp) < 0x7FFD) {
                        return new Quadruple(sig0, GetHi64BitsFromParts112(sign, 0 == (sig64 | sig0) ? 0 : exp, sig64));
                    }
                    sigExtra = 0;
                } else {
                    ShiftRight128WithJammingPartial(sig64, sig0, 0, -shiftDist, out sig64, out sig0, out sigExtra);
                }
                return FromParts112WithRounding(sign, exp, sig64, sig0, sigExtra, rounding);

            }




            static Quadruple FromParts112WithRounding(int sign, int exponent, UInt64 fraction_d1, UInt64 fraction_d0, UInt64 fraction_dM1, FloatingPointRounding rounding) {
                var toEven = (rounding == FloatingPointRounding.ToNearestWithMidpointToEven);
                var cy = (0x8000000000000000U <= fraction_dM1);
                if (!toEven && (rounding != FloatingPointRounding.ToNearestWithMidpointAwayFromZero)) {
                    // unchecked(FloatingPointRounding.Up - sign) == (((0 != sign) ? FloatingPointRounding.Down : FloatingPointRounding.Up))
                    cy =
                        (rounding
                             == unchecked(FloatingPointRounding.Upward - sign))
                            && (0 != fraction_dM1);
                }

                if (0x7FFD <= unchecked((uint)exponent)) {
                    if (exponent < 0) {
                        ShiftRight128WithJamming(fraction_d1, fraction_d0, fraction_dM1, unchecked(-exponent), out fraction_d1, out fraction_d0, out fraction_dM1);
                        exponent = 0;
                        cy = (0x8000000000000000u <= fraction_dM1);
                        if (
                               !toEven
                            && (rounding != FloatingPointRounding.ToNearestWithMidpointAwayFromZero)
                        ) {
                            cy =
                                (rounding
                                     == unchecked(FloatingPointRounding.Upward - sign))
                                    && (0 != fraction_dM1);
                        }
                    } else if (
                           (0x7FFD < exponent)
                        || ((exponent == 0x7FFD)
                                && DoubleArithmetic.Equals(
                                       fraction_d0,
                                       fraction_d1,
                                       0xFFFFFFFFFFFFFFFFU,
                                       0x0001FFFFFFFFFFFFU
                                   )
                                && cy)
                    ) {

                        if (
                               toEven
                            || (rounding == FloatingPointRounding.ToNearestWithMidpointAwayFromZero)
                            || (rounding
                                    == unchecked(FloatingPointRounding.Upward - sign))
                        ) {
                            return new Quadruple(0, 0x7FFF000000000000U | (unchecked((UInt64)sign) << (64 - 1)));
                        } else {
                            return new Quadruple(0xFFFFFFFFFFFFFFFFU, 0x7FFEFFFFFFFFFFFFU | (unchecked((UInt64)sign) << (64 - 1)));
                        }
                    }
                }

                if (0 != fraction_dM1) {
                    // Rounding: ToOdd
                    if (rounding == FloatingPointRounding.ToOdd) {
                        fraction_d0 |= 1;
                        goto L_1;
                    }
                }
                if (cy) {
                    fraction_d0 = DoubleArithmetic.IncreaseUnchecked(fraction_d0, fraction_d1, out fraction_d1);
                    fraction_d0 &= ((0 == (fraction_dM1 & 0x7FFFFFFFFFFFFFFFU))
                                        && toEven) ? ~(UInt64)1 : ~(UInt64)0;
                } else {
                    if (0 == (fraction_d1 | fraction_d0)) exponent = 0;
                }

            L_1:
                return new Quadruple(fraction_d0, GetHi64BitsFromParts112(sign, exponent, fraction_d1));
            }

            static int GetRawExponentFromHi64Bits(UInt64 hi) {
                const int ExponentMask = (1 << ExponentBitCount) - 1;
                return ExponentMask & unchecked((int)(hi >> (FractionBitCount - 64)));
            }

            internal static Quadruple softfloat_addMagsF128(UInt64 uiA64, UInt64 uiA0, UInt64 uiB64, UInt64 uiB0, int signZ, FloatingPointRounding rounding) {
                int expA;
                UInt64 sigA_v0, sigA_v64;
                int expB;
                UInt64 sigB_v0, sigB_v64;
                int expDiff;
                UInt64 sigZ_v0, sigZ_v64;
                int expZ;
                UInt64 sigZExtra;

                expA = GetRawExponentFromHi64Bits(uiA64);
                sigA_v64 = Hi64BitsFractionMask & uiA64;
                sigA_v0 = uiA0;
                expB = GetRawExponentFromHi64Bits(uiB64);
                sigB_v64 = Hi64BitsFractionMask & uiB64;
                sigB_v0 = uiB0;
                expDiff = expA - expB;
                if (0 == expDiff) {
                    if (expA == 0x7FFF) {
                        if (0 != (sigA_v64 | sigA_v0 | sigB_v64 | sigB_v0)) goto L_NaN;
                        return new Quadruple(uiA0, uiA64);
                    }
                    sigZ_v0 = DoubleArithmetic.AddUnchecked(sigA_v0, sigA_v64, sigB_v0, sigB_v64, out sigZ_v64);
                    if (0 == expA) {
                        return new Quadruple(sigZ_v0, GetHi64BitsFromParts112(signZ, 0, sigZ_v64));

                    }
                    expZ = expA;
                    sigZ_v64 |= 0x0002000000000000u;
                    sigZExtra = 0;
                    goto shiftRight1;
                }
                if (expDiff < 0) {
                    if (expB == 0x7FFF) {
                        if (0 != (sigB_v64 | sigB_v0)) goto L_NaN;
                        return new Quadruple(0, GetHi64BitsFromParts112(signZ, 0x7FFF, 0));

                    }
                    expZ = expB;
                    if (0 != expA) {
                        sigA_v64 |= 0x0001000000000000u;
                    } else {
                        ++expDiff;
                        sigZExtra = 0;
                        if (0 == expDiff) goto newlyAligned;
                    }
                    ShiftRight128WithJamming(sigA_v64, sigA_v0, 0, -expDiff, out sigA_v64, out sigA_v0, out sigZExtra);

                } else {
                    if (expA == 0x7FFF) {
                        if (0 != (sigA_v64 | sigA_v0)) goto L_NaN;
                        return new Quadruple(uiA0, uiA64);
                    }
                    expZ = expA;
                    if (0 != expB) {
                        sigB_v64 |= 0x0001000000000000u;
                    } else {
                        --expDiff;
                        sigZExtra = 0;
                        if (0 == expDiff) goto newlyAligned;
                    }
                    ShiftRight128WithJamming(sigB_v64, sigB_v0, 0, expDiff, out sigB_v64, out sigB_v0, out sigZExtra);
                }
            newlyAligned:
                sigZ_v0 = DoubleArithmetic.AddUnchecked(sigA_v0, sigA_v64 | 0x0001000000000000u, sigB_v0, sigB_v64, out sigZ_v64);
                --expZ;
                if (sigZ_v64 < 0x0002000000000000u) goto roundAndPack;
                ++expZ;
            shiftRight1:
                ShiftRight128WithJammingPartial(
                    sigZ_v64, sigZ_v0, sigZExtra, 1, out sigZ_v64, out sigZ_v0, out sigZExtra);
            roundAndPack:
                return
                    FromParts112WithRounding(signZ, expZ, sigZ_v64, sigZ_v0, sigZExtra, rounding);
            L_NaN:
                return new Quadruple(Binary128Module.ComposeNaNs(uiA0, uiA64, uiB0, uiB64, Binary128Module.BinaryArithmeticOperationKind.Add, out var t), t);

            }


            internal static Quadruple softfloat_subMagsF128(UInt64 uiA64, UInt64 uiA0, UInt64 uiB64, UInt64 uiB0, int signZ, FloatingPointRounding rounding) {
                int expA;
                UInt64 sigA_v0, sigA_v64;
                int expB;
                UInt64 sigB_v0, sigB_v64;
                int expDiff;
                UInt64 sigZ_v0, sigZ_v64;
                int expZ;

                expA = GetRawExponentFromHi64Bits(uiA64);
                sigA_v64 = Hi64BitsFractionMask & uiA64;
                sigA_v0 = uiA0;
                expB = GetRawExponentFromHi64Bits(uiB64);
                sigB_v64 = Hi64BitsFractionMask & uiB64;
                sigB_v0 = uiB0;
                sigA_v0 = DoubleArithmetic.ShiftLeft(sigA_v0, sigA_v64, 4, out sigA_v64);
                sigB_v0 = DoubleArithmetic.ShiftLeft(sigB_v0, sigB_v64, 4, out sigB_v64);

                expDiff = expA - expB;
                if (0 < expDiff) goto expABigger;
                if (expDiff < 0) goto expBBigger;
                if (expA == 0x7FFF) {
                    if (0 != (sigA_v64 | sigA_v0 | sigB_v64 | sigB_v0)) goto L_NaN;
                    // inf - inf
                    return Quadruple.NaN;
                }
                expZ = expA;
                if (0 == expZ) expZ = 1;
                if (sigB_v64 < sigA_v64) goto aBigger;
                if (sigA_v64 < sigB_v64) goto bBigger;
                if (sigB_v0 < sigA_v0) goto aBigger;
                if (sigA_v0 < sigB_v0) goto bBigger;


                return new Quadruple(0, GetHi64BitsFromParts112((rounding == FloatingPointRounding.Downward) ? 1 : 0, 0, 0));

            expBBigger:
                if (expB == 0x7FFF) {
                    if (0 != (sigB_v64 | sigB_v0)) goto L_NaN;
                    return new Quadruple(0, GetHi64BitsFromParts112(signZ ^ 1, 0x7FFF, 0));
                }
                if (0 != expA) {
                    sigA_v64 |= 0x0010000000000000u;
                } else {
                    ++expDiff;
                    if (0 == expDiff) goto newlyAlignedBBigger;
                }
                ShiftRightWithJamming(sigA_v64, sigA_v0, -expDiff, out sigA_v64, out sigA_v0);
            newlyAlignedBBigger:
                expZ = expB;
                sigB_v64 |= 0x0010000000000000u;
            bBigger:
                signZ = 1 - signZ;
                sigZ_v0 = DoubleArithmetic.SubtractUnchecked(sigB_v0, sigB_v64, sigA_v0, sigA_v64, out sigZ_v64);
                goto normRoundPack;
            expABigger:
                if (expA == 0x7FFF) {
                    if (0 != (sigA_v64 | sigA_v0)) goto L_NaN;
                    return new Quadruple(uiA0, uiA64);
                }
                if (0 != expB) {
                    sigB_v64 |= 0x0010000000000000u;
                } else {
                    --expDiff;
                    if (0 == expDiff) goto newlyAlignedABigger;
                }
                ShiftRightWithJamming(sigB_v64, sigB_v0, expDiff, out sigB_v64, out sigB_v0);
            newlyAlignedABigger:
                expZ = expA;
                sigA_v64 |= 0x0010000000000000u;
            aBigger:
                sigZ_v0 = DoubleArithmetic.SubtractUnchecked(sigA_v0, sigA_v64, sigB_v0, sigB_v64, out sigZ_v64);
            normRoundPack:
                return softfloat_normRoundPackToF128(signZ, expZ - 5, sigZ_v64, sigZ_v0, rounding);
            L_NaN:
                return new Quadruple(Binary128Module.ComposeNaNs(uiA0, uiA64, uiB0, uiB64, Binary128Module.BinaryArithmeticOperationKind.Subtract, out var t), t);


            }



        }

        static class Binary128Module {

            internal enum BinaryArithmeticOperationKind {

                Add,

                Subtract,

                Multiply,

                Divide,
            }

            internal static UInt64 ComposeNaNs(UInt64 first_lo, UInt64 first_hi, UInt64 second_lo, UInt64 second_hi, BinaryArithmeticOperationKind op, out UInt64 result_hi) {
                var mask_fNq = 0x00007FFFFFFFFFFFu;
                var mask_eq = 0x7FFF800000000000u;
                var first_eq = mask_eq & first_hi;
                var second_eq = mask_eq & second_hi;
                if ((Hi64BitsExponentMask == first_eq) && (0 != (first_lo | (mask_fNq & first_hi)))) {
                    // first: sNaN
                    // second: ?
                    if ((Hi64BitsExponentMask == second_eq) && (0 != (second_lo | (mask_fNq & second_hi)))) {
                        // first: sNaN
                        // second: sNaN
                        goto L_0;
                    }
                    {
                        result_hi = first_hi;
                        return first_lo;
                    }
                }
                {
                    // first: qNaN or ...
                    // second: ?
                    if ((Hi64BitsExponentMask == second_eq) && (0 != (second_lo | (mask_fNq & second_hi)))) {
                        // first: qNaN or ...
                        // second: sNaN
                        result_hi = second_hi;
                        return second_lo;
                    }

                    if (mask_eq == first_eq) {
                        // first: qNaN
                        // second: qNaN or ...
                        if (mask_eq == second_eq) {
                            // first: qNaN
                            // second: qNaN 
                            goto L_0;
                        }
                        {
                            // first: qNaN
                            // second: Infinity or ...
                            result_hi = first_hi;
                            return first_lo;
                        }
                    }
                    {
                        Debug.Assert(mask_eq == second_eq);
                        {
                            // first: Infinity or ...
                            // second: qNaN 
                            result_hi = second_hi;
                            return second_lo;
                        }
                    }
                }
            L_0:;
                result_hi = first_hi | second_hi;
                return first_lo | second_lo;
            }
        }

        public static class Math {

            public static int Sign(Quadruple value) {
                var value_e = 0x7FFF000000000000 & value._Hi64Bits;
                if (0x7FFF000000000000 != value_e) {
                    return IsZero(value) ? 0 : 0 > unchecked((Int64)value._Hi64Bits) ? -1 : 1;
                } else {
                    if (0 == value._Lo64Bits) {
                        if (0x7FFFFFFFFFFFFFFF == value._Hi64Bits) {
                            return 1;
                        } else if (0xFFFFFFFFFFFFFFFF == value._Hi64Bits) {
                            return -1;
                        }
                    }
                }
                throw ThrowArithmeticException();
            }

            public static Quadruple Abs(Quadruple value) {
                return new Quadruple(value._Lo64Bits, 0x7FFFFFFFFFFFFFFFu & value._Hi64Bits);
            }

            private static ArithmeticException ThrowArithmeticException() {
                _ = System.Math.Sign(Double.NaN);
                throw null;
            }
        }

        public static class BitConverter {

            public static Int128 QuadrupleToInt128Bits(Quadruple value) {
                return new Int128(value._Lo64Bits, unchecked((Int64)value._Hi64Bits));
            }

            public static Quadruple Int128BitsToQuadruple(Int128 bits) {
                return new Quadruple(unchecked((UInt64)bits.LoInt64Bits), unchecked((UInt64)bits.HiInt64Bits));
            }
        }
    }


}
