using System;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Mathematics.Utilities {

    public static partial class CheckedNoThrow {

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Negate(uint value, out uint result) {
            result = unchecked((uint)(-(int)value));
            return value != uint.MinValue;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Negate(int value, out int result) {
            result = unchecked(-value);
            return value == int.MinValue;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Negate(ulong value, out ulong result) {
            result = unchecked((ulong)(-(long)value));
            return value != ulong.MinValue;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Negate(long value, out long result) {
            result = unchecked(-value);
            return value == long.MinValue;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Add(uint first, uint second, out uint result) {
            return first > (result = unchecked(first + second));
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Add(int first, int second, out int result) {
            result = unchecked(first + second);
            return 0 <= ((first ^ second) | (((first ^ (~(first ^ second) & int.MinValue)) + second) ^ second));
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Add(ulong first, ulong second, out ulong result) {
            return first > (result = unchecked(first + second));
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Add(long first, long second, out long result) {
            result = unchecked(first + second);
            return 0 <= ((first ^ second) | (((first ^ (~(first ^ second) & long.MinValue)) + second) ^ second));
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Subtract(uint first, uint second, out uint result) {
            result = unchecked(first - second);
            return first < second;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Subtract(int first, int second, out int result) {
            var t = unchecked(first - second);
            result = t;
            if (0 <= first) {
                if ((0 > second) && (first > t)) {
                    return true;
                }
            } else {
                if ((0 <= second) && (t > first)) {
                    return true;
                }
            }
            return false;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Subtract(ulong first, ulong second, out ulong result) {
            result = unchecked(first - second);
            return first < second;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Subtract(long first, long second, out long result) {
            var t = unchecked(first - second);
            result = t;
            if (0 <= first) {
                if ((0 > second) && (first > t)) {
                    return true;
                }
            } else {
                if ((0 <= second) && (t > first)) {
                    return true;
                }
            }
            return false;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Multiply(uint first, uint second, out uint result) {
            ulong t = (ulong)first * second;
            result = unchecked((uint)t);
            return t != result;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Multiply(int first, int second, out int result) {
            long t = (long)first * second;
            result = unchecked((int)t);
            return t != result;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Multiply(ulong first, ulong second, out ulong result) {
            ulong t;
            result = DoubleArithmetic.BigMul(first, second, out t);
            return 0 != t;
        }

        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool Multiply(long first, long second, out long result) {
            long t;
            var r = DoubleArithmetic.BigMul(first, second, out t);
            result = unchecked((long)r);
            if (0 > (first ^ second)) {
                if ((-1 == t && 0 > r) || (0 == t && 0 == r)) {
                    return false;
                }
            } else {
                if (0 == t && r <= (ulong)long.MaxValue)
                    return false;
            }
            return true;
        }
    }
}
