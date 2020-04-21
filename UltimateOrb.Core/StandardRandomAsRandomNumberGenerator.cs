using System;
using System.Runtime.CompilerServices;

namespace UltimateOrb {

    public readonly struct StandardRandomAsRandomNumberGenerator : IRandomNumberGenerator {

        private readonly Random random;

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public StandardRandomAsRandomNumberGenerator(Random value) {
            this.random = value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void GetBytes(byte[] array, int offset, int count) {
            var random = this.random;
            if (null != random) {
                ArrayModule.CheckArraySegmentThrowIfFailed(array, offset, count);
                if (0 == offset && count == array.Length) {
                    random.NextBytes(array);
                    return;
                }
                // TODO: Perf
                var a = new byte[count];
                random.NextBytes(a);
                a.CopyTo(array, offset);
                return;
            }
            throw (NullReferenceException)null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int GetNextInt32(int maxExclusive) {
            var random = this.random;
            if (null != random) {
                return random.Next(maxExclusive);
            }
            throw (NullReferenceException)null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Int32 GetNextInt32Bits() {
            var random = this.random;
            if (null != random) {
                var a = random.Next(1 << 16);
                var b = random.Next(1 << 16);
                return (a << 16) | b;
            }
            throw (NullReferenceException)null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Int64 GetNextInt64Bits() {
            var random = this.random;
            if (null != random) {
                var a = (Int64)random.Next(1 << 21);
                var b = (Int64)random.Next(1 << 21);
                var c = random.Next(1 << 22);
                return (a << 43) | (b << 22) | (Int64)c;
            }
            throw (NullReferenceException)null;
        }
    }
}
