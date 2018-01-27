using System;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Mathematics {

    public static partial class BinaryNumerals {

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int ComputeParityCheckBit(byte v) {
            return unchecked((byte)((((v * 0x0101010101010101ul) & 0x8040201008040201ul) % 0x1FF) & 1));
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int ComputeParityCheckBit(sbyte v) {
            return ComputeParityCheckBit(unchecked((byte)v));
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int ComputeParityCheckBit(UInt32 v) {
            v ^= v >> 1;
            v ^= v >> 2;
            v = unchecked((v & 0x11111111u) * 0x11111111u);
            return unchecked((byte)((v >> 28) & 1));
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int ComputeParityCheckBit(Int32 v) {
            return ComputeParityCheckBit(unchecked((UInt32)v));
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int ComputeParityCheckBit(UInt64 v) {
            v ^= v >> 1;
            v ^= v >> 2;
            v = unchecked((v & 0x1111111111111111ul) * 0x1111111111111111ul);
            return unchecked((byte)((v >> 60) & 1));
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int ComputeParityCheckBit(Int64 v) {
            return ComputeParityCheckBit(unchecked((Int64)v));
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int CountLeadingZeros(UInt64 v) {
            System.Diagnostics.Contracts.Contract.Ensures(0 <= System.Diagnostics.Contracts.Contract.Result<int>());
            System.Diagnostics.Contracts.Contract.Ensures(System.Diagnostics.Contracts.Contract.Result<int>() <= 64);
            if (v == 0u) {
                return 64;
            }
            var r = 0;
            if ((v & 0xFFFFFFFF00000000u) == 0u) {
                v <<= 32;
                r = unchecked(r + 32);
            }
            if ((v & 0xFFFF000000000000u) == 0u) {
                v <<= 16;
                r = unchecked(r + 16);
            }
            if ((v & 0xFF00000000000000u) == 0u) {
                v <<= 8;
                r = unchecked(r + 8);
            }
            if ((v & 0xF000000000000000u) == 0u) {
                v <<= 4;
                r = unchecked(r + 4);
            }
            if ((v & 0xC000000000000000u) == 0u) {
                v <<= 2;
                r = unchecked(r + 2);
            }
            if ((v & 0x8000000000000000u) == 0u) {
                r = unchecked(r + 1);
            }
            return r;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int CountLeadingZeros(byte value) {
            System.Diagnostics.Contracts.Contract.Ensures(0 <= System.Diagnostics.Contracts.Contract.Result<int>());
            System.Diagnostics.Contracts.Contract.Ensures(System.Diagnostics.Contracts.Contract.Result<int>() <= 32);
            var v = unchecked((uint)value);
            if (v == (byte)0u) {
                return 8;
            }
            var r = 0;
            if ((v & 0xF0u) == 0u) {
                v <<= 4;
                r = unchecked(r + 4);
            }
            if ((v & 0xC0u) == 0u) {
                v <<= 2;
                r = unchecked(r + 2);
            }
            if ((v & 0x80u) == 0u) {
                r = unchecked(r + 1);
            }
            return r;
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int CountLeadingZeros(UInt32 v) {
            System.Diagnostics.Contracts.Contract.Ensures(0 <= System.Diagnostics.Contracts.Contract.Result<int>());
            System.Diagnostics.Contracts.Contract.Ensures(System.Diagnostics.Contracts.Contract.Result<int>() <= 32);
            if (v == 0u) {
                return 32;
            }
            var r = 0;
            if ((v & 0xFFFF0000u) == 0u) {
                v <<= 16;
                r = unchecked(r + 16);
            }
            if ((v & 0xFF000000u) == 0u) {
                v <<= 8;
                r = unchecked(r + 8);
            }
            if ((v & 0xF0000000u) == 0u) {
                v <<= 4;
                r = unchecked(r + 4);
            }
            if ((v & 0xC0000000u) == 0u) {
                v <<= 2;
                r = unchecked(r + 2);
            }
            if ((v & 0x80000000u) == 0u) {
                r = unchecked(r + 1);
            }
            return r;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int CountStorageBits(Int64 v) {
            v ^= v << 1;
            var r = 64;
            if ((v & unchecked((Int64)0xFFFFFFFF00000000)) == 0) {
                v <<= 32;
                r = unchecked(r - 32);
            }
            if ((v & unchecked((Int64)0xFFFF000000000000)) == 0) {
                v <<= 16;
                r = unchecked(r - 16);
            }
            if ((v & unchecked((Int64)0xFF00000000000000)) == 0) {
                v <<= 8;
                r = unchecked(r - 8);
            }
            if ((v & unchecked((Int64)0xF000000000000000)) == 0) {
                v <<= 4;
                r = unchecked(r - 4);
            }
            if ((v & unchecked((Int64)0xC000000000000000)) == 0) {
                v <<= 2;
                r = unchecked(r - 2);
            }
            if ((v & unchecked((Int64)0x8000000000000000)) == 0) {
                r = unchecked(r - 1);
            }
            return r;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int CountStorageBits(Int32 v) {
            v ^= v << 1;
            var r = 32;
            if ((v & unchecked((Int64)0xFFFF0000)) == 0) {
                v <<= 16;
                r = unchecked(r - 16);
            }
            if ((v & unchecked((Int64)0xFF000000)) == 0) {
                v <<= 8;
                r = unchecked(r - 8);
            }
            if ((v & unchecked((Int64)0xF0000000)) == 0) {
                v <<= 4;
                r = unchecked(r - 4);
            }
            if ((v & unchecked((Int64)0xC0000000)) == 0) {
                v <<= 2;
                r = unchecked(r - 2);
            }
            if ((v & unchecked((Int64)0x80000000)) == 0) {
                r = unchecked(r - 1);
            }
            return r;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
#if DEBUG
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
#else
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
#endif
        [System.Diagnostics.Contracts.PureAttribute()]
        public static long CountTrailingZeros(byte[] source) {
            if (source == null) {
                return -1;
            }
            long r = 0;
            int i;
            for (i = 0; source.Length > i; ++i) {
                if (source[i] == 0) {
                    r = unchecked(r + 8);
                } else {
                    i = source[i];
                    i &= unchecked(-(sbyte)(byte)i);
                    goto L_1;
                }
            }
            return -1;
        L_1: ;
            if (0 == (i & 0x0F)) {
                r = unchecked(r + 4);
            }
            if (0 == (i & 0x33)) {
                r = unchecked(r + 2);
            }
            if (0 == (i & 0x55)) {
                r = unchecked(r + 1);
            }
            return r;
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int CountTrailingZeros(UInt32 x) {
            System.Diagnostics.Contracts.Contract.Ensures(0 <= System.Diagnostics.Contracts.Contract.Result<int>());
            System.Diagnostics.Contracts.Contract.Ensures(System.Diagnostics.Contracts.Contract.Result<int>() <= 64);
            if (x == 0) {
                return 32;
            }
            var n = 0;
            if ((x & 0x0000FFFF) == 0) {
                x >>= 16;
                n = unchecked(n + 16);
            }
            if ((x & 0x000000FF) == 0) {
                x >>= 8;
                n = unchecked(n + 8);
            }
            if ((x & 0x0000000F) == 0) {
                x >>= 4;
                n = unchecked(n + 4);
            }
            if ((x & 0x00000003) == 0) {
                x >>= 2;
                n = unchecked(n + 2);
            }
            if ((x & 0x00000001) == 0) {
                n = unchecked(n + 1);
            }
            return n;
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int CountTrailingZeros(UInt64 x) {
            System.Diagnostics.Contracts.Contract.Ensures(0 <= System.Diagnostics.Contracts.Contract.Result<int>());
            System.Diagnostics.Contracts.Contract.Ensures(System.Diagnostics.Contracts.Contract.Result<int>() <= 64);
            if (x == 0) {
                return 64;
            }
            var n = 0;
            if ((x & 0xFFFFFFFF) == 0) {
                x >>= 32;
                n = unchecked(n + 32);
            }
            if ((x & 0x0000FFFF) == 0) {
                x >>= 16;
                n = unchecked(n + 16);
            }
            if ((x & 0x000000FF) == 0) {
                x >>= 8;
                n = unchecked(n + 8);
            }
            if ((x & 0x0000000F) == 0) {
                x >>= 4;
                n = unchecked(n + 4);
            }
            if ((x & 0x00000003) == 0) {
                x >>= 2;
                n = unchecked(n + 2);
            }
            if ((x & 0x00000001) == 0) {
                n = unchecked(n + 1);
            }
            return n;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static byte ExtendSigned(int bits, byte value) {
            bits &= (1 << unchecked((int)(sizeof(byte) * 8))) - 1;
            return unchecked((byte)ExtendSigned(bits, value));
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static short ExtendSigned(int bits, short value) {
            bits &= (1 << unchecked((int)(sizeof(short) * 8))) - 1;
            return unchecked((short)ExtendSigned(bits, value));
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int ExtendSigned(int bits, int value) {
            var m = unchecked((int)(sizeof(int) * 8) - bits);
            return (value << m) >> m;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static long ExtendSigned(int bits, long value) {
            var m = unchecked((int)(sizeof(long) * 8) - bits);
            return (value << m) >> m;
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int ExtendUnsigned(int bits, int value) {
            var m = unchecked((int)(sizeof(int) * 8) - bits);
            return unchecked((int)(((uint)(value << m)) >> m));
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static long ExtendUnsigned(int bits, long value) {
            var m = unchecked((int)(sizeof(long) * 8) - bits);
            return unchecked((long)(((ulong)(value << m)) >> m));
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool HasZeroBytes(UInt64 v) {
            return 0 != unchecked((v - 0x0101010101010101ul) & ~v & 0x8080808080808080ul);
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool HasZeroBytes(UInt32 v) {
            return 0 != unchecked((v - 0x01010101u) & ~v & 0x80808080ul);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool HasZeroBytes(Int64 v) {
            return HasZeroBytes(unchecked((UInt64)v));
        }
        
        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool HasZeroBytes(Int32 v) {
            return 0 != unchecked((v - 0x01010101) & ~v & 0x80808080);
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool HasZeroBytes_A_Definition(UInt64 v) {
            for (int i = 0; i < unchecked((int)sizeof(UInt64)); ++i) {
                if ((v & 0xFF) == 0) {
                    return true;
                }
                v >>= 8;
            }
            return false;
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool HasZeroBytes_A_Definition(UInt32 v) {
            for (int i = 0; i < unchecked((int)sizeof(UInt32)); ++i) {
                if ((v & 0xFF) == 0) {
                    return true;
                }
                v >>= 8;
            }
            return false;
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static UInt64 MostSignificantBit(UInt64 x) {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            x |= (x >> 32);
            return (x & ~(x >> 1));
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static UInt32 MostSignificantBit(UInt32 x) {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return (x & ~(x >> 1));
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static UInt64 MostSignificantBit_A_Definition(UInt64 x) {
            var a = unchecked((UInt64)Int64.MinValue);
            for (int i = 0; i < unchecked((int)(sizeof(UInt64) * 8)); ++i) {
                if ((x & a) != 0) {
                    return a;
                }
                a >>= 1;
            }
            return a;
        }

        [System.CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static UInt32 MostSignificantBit_A_Definition(UInt32 x) {
            var a = unchecked((UInt32)Int32.MinValue);
            for (int i = 0; i < unchecked((int)(sizeof(UInt32) * 8)); ++i) {
                if ((x & a) != 0) {
                    return a;
                }
                a >>= 1;
            }
            return a;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static long NextPermutation(long v) {
            return unchecked((long)NextPermutation((ulong)v));
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int NextPermutation(int v) {
            return unchecked((int)NextPermutation((uint)v));
        }

        [System.CLSCompliantAttribute(false)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        // ~30.9 Cyc
        public static ulong NextPermutation(ulong v) {
            unchecked {
                if (v == 0) {
                    return ulong.MaxValue;
                }
                ulong t = (v | (v - 1)) + 1;
                return (ulong)(t | ((((t & (ulong)(-(long)t)) / (v & (ulong)(-(long)v))) >> 1) - 1));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2233:OperationsShouldNotOverflow", MessageId = "v-1")]
        [System.CLSCompliantAttribute(false)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static uint NextPermutation(uint v) {
            unchecked {
                if (v == 0) {
                    return uint.MaxValue;
                }
                uint t = (v | (v - 1)) + 1;
                return (uint)(t | ((((t & -t) / (v & -v)) >> 1) - 1));
            }
        }

        [System.CLSCompliantAttribute(false)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int PopulationCount(UInt64 x) {
            unchecked {
                x -= (x >> 1) & 0x5555555555555555;
                x = (x & 0x3333333333333333) + ((x >> 2) & 0x3333333333333333);
                x = (x + (x >> 4)) & 0x0f0f0f0f0f0f0f0f;
                return (int)((x * 0x0101010101010101) >> 56);
            }
        }

        [System.CLSCompliantAttribute(false)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        // 8.38 Cyc
        public static int PopulationCount(UInt32 x) {
            unchecked {
                x -= (x >> 1) & 0x55555555;
                x = (x & 0x33333333) + ((x >> 2) & 0x33333333);
                x = (x + (x >> 4)) & 0x0f0f0f0f;
                return (int)((x * 0x01010101) >> 24);
            }
        }

        [System.CLSCompliantAttribute(false)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int PopulationCount_A_Definition(UInt32 x) {
            unchecked {
                var r = 0;
                for (int i = 0; i < unchecked((int)(sizeof(UInt32) * 8)); ++i) {
                    if ((x & 1) == 1) {
                        ++r;
                    }
                    x >>= 1;
                }
                return r;
            }
        }

        [System.CLSCompliantAttribute(false)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int PopulationCount_A_Definition(UInt64 x) {
            unchecked {
                var r = 0;
                for (int i = 0; i < unchecked((int)(sizeof(UInt64) * 8)); ++i) {
                    if ((x & 1) == 1) {
                        ++r;
                    }
                    x >>= 1;
                }
                return r;
            }
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static byte ReverseBits(byte v) {
            return unchecked((byte)((v * 0x0202020202ul & 0x010884422010ul) % 1023));
        }

        [System.CLSCompliantAttribute(false)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static uint ReverseBits(uint v) {
            var r = (uint)0;
            for (int i = 0; i < unchecked((int)(sizeof(uint))); ++i) {
                r = unchecked(((r << 8) | ReverseBits((byte)v)));
                v >>= 8;
            }
            return r;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static byte ReverseBits_A_Definition(byte v) {
            byte r = 0;
            for (int i = 0; i < unchecked((int)(sizeof(byte) * 8)); ++i) {
                r = unchecked((byte)((r << 1) | (v & (byte)1)));
                v >>= 1;
            }
            return r;
        }

        [System.CLSCompliantAttribute(false)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static uint ReverseBits_A_Definition(uint v) {
            uint r = 0;
            for (int i = 0; i < unchecked((int)(sizeof(uint) * 8)); ++i) {
                r = unchecked((uint)((r << 1) | (v & (uint)1)));
                v >>= 1;
            }
            return r;
        }
    }
}
