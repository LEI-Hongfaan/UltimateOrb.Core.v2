using System;
using System.Runtime.CompilerServices;

namespace UltimateOrb {

    public static partial class RandomModule {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int64 Next(this Random random, Int64 maxExclusive) {
            if (null != random) {
                if (maxExclusive > 0) {
                    var d0 = random.Next(1 << 24);
                    var d1 = random.Next(1 << 24);
                    var d2 = random.Next(1 << 24);
                    var d3 = random.Next(1 << 24);
                    var a =
                        (unchecked((UInt64)(UInt32)d2) << 48) |
                        (unchecked((UInt64)(UInt32)d1) << 24) |
                        unchecked((UInt64)(UInt32)d0);
                    var b = unchecked((UInt32)((d3 << 8) | (d2 >> 16)));
                    return GetNextInt64_Stub0001(maxExclusive, a, b);
                }
                throw new ArgumentOutOfRangeException(nameof(maxExclusive));
            }
            throw (NullReferenceException)null;
            // return random.AsRandomNumberGenerator().GetNextInt64(maxExclusive);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int64 GetNextInt64<TRandomNumberGenerator>(this TRandomNumberGenerator random, Int64 maxExclusive)
            where TRandomNumberGenerator : IRandomNumberGenerator {
            if (null != random) {
                var b = unchecked((UInt32)random.GetNextInt32Bits()); // null check
                if (maxExclusive > 0) {
                    var a = unchecked((UInt64)random.GetNextInt64Bits());
                    return GetNextInt64_Stub0001(maxExclusive, a, b);
                }
                throw new ArgumentOutOfRangeException(nameof(maxExclusive));
            }
            throw (NullReferenceException)null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static Int64 GetNextInt64_Stub0001(Int64 maxExclusive, UInt64 a, UInt32 b) {
            var lo = Mathematics.DoubleArithmetic.BigMul(unchecked((UInt64)maxExclusive), a, out var hi);
            Mathematics.DoubleArithmetic.BigMul(unchecked((UInt64)maxExclusive), b, out var cy);
            unchecked {
                lo += cy;
            }
            if (cy > lo) {
                unchecked {
                    ++hi;
                }
            }
            return unchecked((Int64)hi);
        }
    }
}
