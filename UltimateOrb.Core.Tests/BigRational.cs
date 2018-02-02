using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using UltimateOrb.Mathematics.Exact;

namespace UltimateOrb {

    [SerializableAttribute()]
    public readonly partial struct BigRational {

        private readonly BigInteger m_Denominator;

        private readonly BigInteger m_SignedNumerator;

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        private BigRational(BigInteger denominator, BigInteger signedNumerator) {
            Debug.Assert(!signedNumerator.IsZero || denominator.IsZero);
            Debug.Assert(signedNumerator.IsZero || denominator.Sign > 0);
            Debug.Assert(signedNumerator.IsZero || BigInteger.GreatestCommonDivisor(denominator, signedNumerator).IsOne);
            this.m_Denominator = denominator;
            this.m_SignedNumerator = signedNumerator;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator BigRational(Rational64 value) {
            return default == value ? default : new BigRational(value.Denominator, value.SignedNumerator);
        }

        private static readonly BigInteger s_Rational64MaxDenominator = unchecked((UInt32)Int32.MinValue);

        private static readonly BigInteger s_Rational64MaxNumerator = UInt32.MaxValue;

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static explicit operator Rational64(BigRational value) {
            var d = value.m_Denominator;
            if (!d.IsZero) {
                if (d <= s_Rational64MaxDenominator) {
                    var n = value.m_SignedNumerator;
                    if (0 < n.Sign) {
                        if (n <= s_Rational64MaxNumerator) {
                            return Rational64.FromInt64Bits(((Int64)(unchecked((Int32)checked((UInt32)d) - (Int32)1)) << 32 | (Int64)unchecked((Int32)checked((UInt32)n))));
                        }
                    }
                    {
                        n = -n;
                        if (n <= s_Rational64MaxNumerator) {
                            return Rational64.FromInt64Bits(((Int64)(-unchecked((Int32)checked((UInt32)d))) << 32 | (Int64)unchecked((Int32)checked((UInt32)n))));
                        }
                    }
                }
                {
                    var ignored = checked(0u - unchecked((uint)d.Sign));
                }
            }
            return default;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static BigRational operator +(BigRational first, BigRational second) {
            var d = first.m_Denominator * second.m_Denominator;
            var n = first.m_SignedNumerator * second.m_Denominator + first.m_Denominator * second.m_SignedNumerator;
            var g = BigInteger.GreatestCommonDivisor(d, n);
            return new BigRational(d / g, n / g);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static BigRational operator -(BigRational first, BigRational second) {
            var d = first.m_Denominator * second.m_Denominator;
            var n = first.m_SignedNumerator * second.m_Denominator - first.m_Denominator * second.m_SignedNumerator;
            var g = BigInteger.GreatestCommonDivisor(d, n);
            return new BigRational(d / g, n / g);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static BigRational FromFraction(long numerator, long denominator) {
            if (0 == denominator) {
                var ignored = 0 / denominator;
            }
            if (0 == numerator) {
                return default;
            }
            var g = Mathematics.NumberTheory.EuclideanAlgorithm.GreatestCommonDivisor(numerator, denominator);
            if (0 > denominator) {
                g = -g;
            }
            return new BigRational(denominator / g, numerator / g);
        }

        public static bool operator ==(BigRational first, BigRational second) {
            return first.m_SignedNumerator == second.m_SignedNumerator && first.m_Denominator == second.m_Denominator;
        }

        public static bool operator !=(BigRational first, BigRational second) {
            return first.m_SignedNumerator != second.m_SignedNumerator || first.m_Denominator != second.m_Denominator;
        }
    }
}

