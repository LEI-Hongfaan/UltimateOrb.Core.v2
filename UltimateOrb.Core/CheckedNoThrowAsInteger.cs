using System;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Mathematics.Utilities {

    public static partial class CheckedNoThrowAsInteger {

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Negate(uint value, out uint result) {
            result = unchecked((uint)(-(int)value));
            return value != uint.MinValue ? 1 : 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Negate(int value, out int result) {
            result = unchecked(-value);
            return value == int.MinValue ? 1 : 0;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Negate(ulong value, out ulong result) {
            result = unchecked((ulong)(-(long)value));
            return value != ulong.MinValue ? 1 : 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Negate(long value, out long result) {
            result = unchecked(-value);
            return value == long.MinValue ? 1 : 0;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Add(uint first, uint second, out uint result) {
            return first > (result = unchecked(first + second)) ? 1 : 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Add(int first, int second, out int result) {
            result = unchecked(first + second);
            return 0 <= ((first ^ second) | (((first ^ (~(first ^ second) & int.MinValue)) + second) ^ second)) ? 1 : 0;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Add(ulong first, ulong second, out ulong result) {
            return first > (result = unchecked(first + second)) ? 1 : 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Add(long first, long second, out long result) {
            result = unchecked(first + second);
            return 0 <= ((first ^ second) | (((first ^ (~(first ^ second) & long.MinValue)) + second) ^ second)) ? 1 : 0;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Subtract(uint first, uint second, out uint result) {
            result = unchecked(first - second);
            return first < second ? 1 : 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Subtract(int first, int second, out int result) {
            var t = unchecked(first - second);
            result = t;
            if (0 <= first) {
                if ((0 > second) && (first > t)) {
                    return 1;
                }
            } else {
                if ((0 <= second) && (t > first)) {
                    return 1;
                }
            }
            return 0;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Subtract(ulong first, ulong second, out ulong result) {
            result = unchecked(first - second);
            return first < second ? 1 : 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Subtract(long first, long second, out long result) {
            var t = unchecked(first - second);
            result = t;
            if (0 <= first) {
                if ((0 > second) && (first > t)) {
                    return 1;
                }
            } else {
                if ((0 <= second) && (t > first)) {
                    return 1;
                }
            }
            return 0;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Multiply(uint first, uint second, out uint result) {
            ulong t = (ulong)first * second;
            result = unchecked((uint)t);
            return t != result ? 1 : 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Multiply(int first, int second, out int result) {
            long t = (long)first * second;
            result = unchecked((int)t);
            return t != result ? 1 : 0;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Multiply(ulong first, ulong second, out ulong result) {
            ulong t;
            result = DoubleArithmetic.BigMul(first, second, out t);
            return 0 != t ? 1 : 0;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Multiply(long first, long second, out long result) {
            long t;
            var r = DoubleArithmetic.BigMul(first, second, out t);
            result = unchecked((long)r);
            if (0 > (first ^ second)) {
                if ((-1 == t && 0 > r) || (0 == t && 0 == r)) {
                    return 0;
                }
            } else {
                if (0 == t && r <= (ulong)long.MaxValue)
                    return 0;
            }
            return 1;
        }
    }
}
