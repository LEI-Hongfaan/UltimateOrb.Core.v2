using System;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb {
	using static UltimateOrb.Utilities.SignConverter;

	[DiscardableAttribute()]
    public static partial class ComparisionHelper {
		
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        private static long ExtendToXLong(this IntPtr value) {
			return unchecked((long)value);
		}

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        private static ulong ExtendToXLong(this UIntPtr value) {
			return unchecked((ulong)value);
		}
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(int first, int second) {
			unchecked {
				return first <= second;
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(int first, int second) {
			unchecked {
				return first > second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(int first, int second) {
			unchecked {
				return first < second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(int first, int second) {
			unchecked {
				return first >= second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(int first, long second) {
			unchecked {
				return first <= second;
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(int first, long second) {
			unchecked {
				return first > second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(int first, long second) {
			unchecked {
				return first < second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(int first, long second) {
			unchecked {
				return first >= second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(int first, IntPtr second) {
			unchecked {
				return first <= second.ExtendToXLong();
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(int first, IntPtr second) {
			unchecked {
				return first > second.ExtendToXLong();
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(int first, IntPtr second) {
			unchecked {
				return first < second.ExtendToXLong();
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(int first, IntPtr second) {
			unchecked {
				return first >= second.ExtendToXLong();
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(int first, Int128 second) {
			unchecked {
				return first <= second;
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(int first, Int128 second) {
			unchecked {
				return first > second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(int first, Int128 second) {
			unchecked {
				return first < second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(int first, Int128 second) {
			unchecked {
				return first >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(int first, uint second) {
			unchecked {
				return !(0 <= first) || first.ToUnsignedUnchecked() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(int first, uint second) {
			unchecked {
				return !(0 > first) && first.ToUnsignedUnchecked() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(int first, uint second) {
			unchecked {
				return first < 0 || first.ToUnsignedUnchecked() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(int first, uint second) {
			unchecked {
				return first >= 0 && first.ToUnsignedUnchecked() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(int first, ulong second) {
			unchecked {
				return !(0 <= first) || first.ToUnsignedUnchecked() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(int first, ulong second) {
			unchecked {
				return !(0 > first) && first.ToUnsignedUnchecked() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(int first, ulong second) {
			unchecked {
				return first < 0 || first.ToUnsignedUnchecked() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(int first, ulong second) {
			unchecked {
				return first >= 0 && first.ToUnsignedUnchecked() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(int first, UIntPtr second) {
			unchecked {
				return !(0 <= first) || first.ToUnsignedUnchecked() <= second.ExtendToXLong();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(int first, UIntPtr second) {
			unchecked {
				return !(0 > first) && first.ToUnsignedUnchecked() > second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(int first, UIntPtr second) {
			unchecked {
				return first < 0 || first.ToUnsignedUnchecked() < second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(int first, UIntPtr second) {
			unchecked {
				return first >= 0 && first.ToUnsignedUnchecked() >= second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(int first, UInt128 second) {
			unchecked {
				return !(0 <= first) || first.ToUnsignedUnchecked() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(int first, UInt128 second) {
			unchecked {
				return !(0 > first) && first.ToUnsignedUnchecked() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(int first, UInt128 second) {
			unchecked {
				return first < 0 || first.ToUnsignedUnchecked() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(int first, UInt128 second) {
			unchecked {
				return first >= 0 && first.ToUnsignedUnchecked() >= second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(long first, int second) {
			unchecked {
				return first <= second;
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(long first, int second) {
			unchecked {
				return first > second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(long first, int second) {
			unchecked {
				return first < second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(long first, int second) {
			unchecked {
				return first >= second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(long first, long second) {
			unchecked {
				return first <= second;
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(long first, long second) {
			unchecked {
				return first > second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(long first, long second) {
			unchecked {
				return first < second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(long first, long second) {
			unchecked {
				return first >= second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(long first, IntPtr second) {
			unchecked {
				return first <= second.ExtendToXLong();
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(long first, IntPtr second) {
			unchecked {
				return first > second.ExtendToXLong();
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(long first, IntPtr second) {
			unchecked {
				return first < second.ExtendToXLong();
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(long first, IntPtr second) {
			unchecked {
				return first >= second.ExtendToXLong();
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(long first, Int128 second) {
			unchecked {
				return first <= second;
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(long first, Int128 second) {
			unchecked {
				return first > second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(long first, Int128 second) {
			unchecked {
				return first < second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(long first, Int128 second) {
			unchecked {
				return first >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(long first, uint second) {
			unchecked {
				return !(0 <= first) || first.ToUnsignedUnchecked() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(long first, uint second) {
			unchecked {
				return !(0 > first) && first.ToUnsignedUnchecked() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(long first, uint second) {
			unchecked {
				return first < 0 || first.ToUnsignedUnchecked() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(long first, uint second) {
			unchecked {
				return first >= 0 && first.ToUnsignedUnchecked() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(long first, ulong second) {
			unchecked {
				return !(0 <= first) || first.ToUnsignedUnchecked() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(long first, ulong second) {
			unchecked {
				return !(0 > first) && first.ToUnsignedUnchecked() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(long first, ulong second) {
			unchecked {
				return first < 0 || first.ToUnsignedUnchecked() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(long first, ulong second) {
			unchecked {
				return first >= 0 && first.ToUnsignedUnchecked() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(long first, UIntPtr second) {
			unchecked {
				return !(0 <= first) || first.ToUnsignedUnchecked() <= second.ExtendToXLong();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(long first, UIntPtr second) {
			unchecked {
				return !(0 > first) && first.ToUnsignedUnchecked() > second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(long first, UIntPtr second) {
			unchecked {
				return first < 0 || first.ToUnsignedUnchecked() < second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(long first, UIntPtr second) {
			unchecked {
				return first >= 0 && first.ToUnsignedUnchecked() >= second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(long first, UInt128 second) {
			unchecked {
				return !(0 <= first) || first.ToUnsignedUnchecked() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(long first, UInt128 second) {
			unchecked {
				return !(0 > first) && first.ToUnsignedUnchecked() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(long first, UInt128 second) {
			unchecked {
				return first < 0 || first.ToUnsignedUnchecked() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(long first, UInt128 second) {
			unchecked {
				return first >= 0 && first.ToUnsignedUnchecked() >= second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(IntPtr first, int second) {
			unchecked {
				return first.ExtendToXLong() <= second;
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(IntPtr first, int second) {
			unchecked {
				return first.ExtendToXLong() > second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(IntPtr first, int second) {
			unchecked {
				return first.ExtendToXLong() < second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(IntPtr first, int second) {
			unchecked {
				return first.ExtendToXLong() >= second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(IntPtr first, long second) {
			unchecked {
				return first.ExtendToXLong() <= second;
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(IntPtr first, long second) {
			unchecked {
				return first.ExtendToXLong() > second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(IntPtr first, long second) {
			unchecked {
				return first.ExtendToXLong() < second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(IntPtr first, long second) {
			unchecked {
				return first.ExtendToXLong() >= second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(IntPtr first, IntPtr second) {
			unchecked {
				return first.ExtendToXLong() <= second.ExtendToXLong();
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(IntPtr first, IntPtr second) {
			unchecked {
				return first.ExtendToXLong() > second.ExtendToXLong();
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(IntPtr first, IntPtr second) {
			unchecked {
				return first.ExtendToXLong() < second.ExtendToXLong();
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(IntPtr first, IntPtr second) {
			unchecked {
				return first.ExtendToXLong() >= second.ExtendToXLong();
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(IntPtr first, Int128 second) {
			unchecked {
				return first.ExtendToXLong() <= second;
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(IntPtr first, Int128 second) {
			unchecked {
				return first.ExtendToXLong() > second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(IntPtr first, Int128 second) {
			unchecked {
				return first.ExtendToXLong() < second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(IntPtr first, Int128 second) {
			unchecked {
				return first.ExtendToXLong() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(IntPtr first, uint second) {
			unchecked {
				return !(0 <= first.ExtendToXLong()) || first.ExtendToXLong().ToUnsignedUnchecked() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(IntPtr first, uint second) {
			unchecked {
				return !(0 > first.ExtendToXLong()) && first.ExtendToXLong().ToUnsignedUnchecked() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(IntPtr first, uint second) {
			unchecked {
				return first.ExtendToXLong() < 0 || first.ExtendToXLong().ToUnsignedUnchecked() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(IntPtr first, uint second) {
			unchecked {
				return first.ExtendToXLong() >= 0 && first.ExtendToXLong().ToUnsignedUnchecked() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(IntPtr first, ulong second) {
			unchecked {
				return !(0 <= first.ExtendToXLong()) || first.ExtendToXLong().ToUnsignedUnchecked() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(IntPtr first, ulong second) {
			unchecked {
				return !(0 > first.ExtendToXLong()) && first.ExtendToXLong().ToUnsignedUnchecked() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(IntPtr first, ulong second) {
			unchecked {
				return first.ExtendToXLong() < 0 || first.ExtendToXLong().ToUnsignedUnchecked() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(IntPtr first, ulong second) {
			unchecked {
				return first.ExtendToXLong() >= 0 && first.ExtendToXLong().ToUnsignedUnchecked() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(IntPtr first, UIntPtr second) {
			unchecked {
				return !(0 <= first.ExtendToXLong()) || first.ExtendToXLong().ToUnsignedUnchecked() <= second.ExtendToXLong();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(IntPtr first, UIntPtr second) {
			unchecked {
				return !(0 > first.ExtendToXLong()) && first.ExtendToXLong().ToUnsignedUnchecked() > second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(IntPtr first, UIntPtr second) {
			unchecked {
				return first.ExtendToXLong() < 0 || first.ExtendToXLong().ToUnsignedUnchecked() < second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(IntPtr first, UIntPtr second) {
			unchecked {
				return first.ExtendToXLong() >= 0 && first.ExtendToXLong().ToUnsignedUnchecked() >= second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(IntPtr first, UInt128 second) {
			unchecked {
				return !(0 <= first.ExtendToXLong()) || first.ExtendToXLong().ToUnsignedUnchecked() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(IntPtr first, UInt128 second) {
			unchecked {
				return !(0 > first.ExtendToXLong()) && first.ExtendToXLong().ToUnsignedUnchecked() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(IntPtr first, UInt128 second) {
			unchecked {
				return first.ExtendToXLong() < 0 || first.ExtendToXLong().ToUnsignedUnchecked() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(IntPtr first, UInt128 second) {
			unchecked {
				return first.ExtendToXLong() >= 0 && first.ExtendToXLong().ToUnsignedUnchecked() >= second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(Int128 first, int second) {
			unchecked {
				return first <= second;
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(Int128 first, int second) {
			unchecked {
				return first > second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(Int128 first, int second) {
			unchecked {
				return first < second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(Int128 first, int second) {
			unchecked {
				return first >= second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(Int128 first, long second) {
			unchecked {
				return first <= second;
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(Int128 first, long second) {
			unchecked {
				return first > second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(Int128 first, long second) {
			unchecked {
				return first < second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(Int128 first, long second) {
			unchecked {
				return first >= second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(Int128 first, IntPtr second) {
			unchecked {
				return first <= second.ExtendToXLong();
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(Int128 first, IntPtr second) {
			unchecked {
				return first > second.ExtendToXLong();
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(Int128 first, IntPtr second) {
			unchecked {
				return first < second.ExtendToXLong();
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(Int128 first, IntPtr second) {
			unchecked {
				return first >= second.ExtendToXLong();
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(Int128 first, Int128 second) {
			unchecked {
				return first <= second;
			}
        }

		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(Int128 first, Int128 second) {
			unchecked {
				return first > second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(Int128 first, Int128 second) {
			unchecked {
				return first < second;
			}
        }
        
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(Int128 first, Int128 second) {
			unchecked {
				return first >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(Int128 first, uint second) {
			unchecked {
				return !(0 <= first) || first.ToUnsignedUnchecked() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(Int128 first, uint second) {
			unchecked {
				return !(0 > first) && first.ToUnsignedUnchecked() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(Int128 first, uint second) {
			unchecked {
				return first < 0 || first.ToUnsignedUnchecked() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(Int128 first, uint second) {
			unchecked {
				return first >= 0 && first.ToUnsignedUnchecked() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(Int128 first, ulong second) {
			unchecked {
				return !(0 <= first) || first.ToUnsignedUnchecked() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(Int128 first, ulong second) {
			unchecked {
				return !(0 > first) && first.ToUnsignedUnchecked() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(Int128 first, ulong second) {
			unchecked {
				return first < 0 || first.ToUnsignedUnchecked() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(Int128 first, ulong second) {
			unchecked {
				return first >= 0 && first.ToUnsignedUnchecked() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(Int128 first, UIntPtr second) {
			unchecked {
				return !(0 <= first) || first.ToUnsignedUnchecked() <= second.ExtendToXLong();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(Int128 first, UIntPtr second) {
			unchecked {
				return !(0 > first) && first.ToUnsignedUnchecked() > second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(Int128 first, UIntPtr second) {
			unchecked {
				return first < 0 || first.ToUnsignedUnchecked() < second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(Int128 first, UIntPtr second) {
			unchecked {
				return first >= 0 && first.ToUnsignedUnchecked() >= second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(Int128 first, UInt128 second) {
			unchecked {
				return !(0 <= first) || first.ToUnsignedUnchecked() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(Int128 first, UInt128 second) {
			unchecked {
				return !(0 > first) && first.ToUnsignedUnchecked() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(Int128 first, UInt128 second) {
			unchecked {
				return first < 0 || first.ToUnsignedUnchecked() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(Int128 first, UInt128 second) {
			unchecked {
				return first >= 0 && first.ToUnsignedUnchecked() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(uint first, int second) {
			unchecked {
				return 0 <= second && first <= second.ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(uint first, int second) {
			unchecked {
				return 0 > second || first > second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(uint first, int second) {
			unchecked {
				return !(second < 0) && first < second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(uint first, int second) {
			unchecked {
				return !(second >= 0) || first >= second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(uint first, long second) {
			unchecked {
				return 0 <= second && first <= second.ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(uint first, long second) {
			unchecked {
				return 0 > second || first > second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(uint first, long second) {
			unchecked {
				return !(second < 0) && first < second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(uint first, long second) {
			unchecked {
				return !(second >= 0) || first >= second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(uint first, IntPtr second) {
			unchecked {
				return 0 <= second.ExtendToXLong() && first <= second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(uint first, IntPtr second) {
			unchecked {
				return 0 > second.ExtendToXLong() || first > second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(uint first, IntPtr second) {
			unchecked {
				return !(second.ExtendToXLong() < 0) && first < second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(uint first, IntPtr second) {
			unchecked {
				return !(second.ExtendToXLong() >= 0) || first >= second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(uint first, Int128 second) {
			unchecked {
				return 0 <= second && first <= second.ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(uint first, Int128 second) {
			unchecked {
				return 0 > second || first > second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(uint first, Int128 second) {
			unchecked {
				return !(second < 0) && first < second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(uint first, Int128 second) {
			unchecked {
				return !(second >= 0) || first >= second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(uint first, uint second) {
			unchecked {
				return first <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(uint first, uint second) {
			unchecked {
				return first > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(uint first, uint second) {
			unchecked {
				return first < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(uint first, uint second) {
			unchecked {
				return first >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(uint first, ulong second) {
			unchecked {
				return first <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(uint first, ulong second) {
			unchecked {
				return first > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(uint first, ulong second) {
			unchecked {
				return first < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(uint first, ulong second) {
			unchecked {
				return first >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(uint first, UIntPtr second) {
			unchecked {
				return first <= second.ExtendToXLong();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(uint first, UIntPtr second) {
			unchecked {
				return first > second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(uint first, UIntPtr second) {
			unchecked {
				return first < second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(uint first, UIntPtr second) {
			unchecked {
				return first >= second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(uint first, UInt128 second) {
			unchecked {
				return first <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(uint first, UInt128 second) {
			unchecked {
				return first > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(uint first, UInt128 second) {
			unchecked {
				return first < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(uint first, UInt128 second) {
			unchecked {
				return first >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(ulong first, int second) {
			unchecked {
				return 0 <= second && first <= second.ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(ulong first, int second) {
			unchecked {
				return 0 > second || first > second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(ulong first, int second) {
			unchecked {
				return !(second < 0) && first < second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(ulong first, int second) {
			unchecked {
				return !(second >= 0) || first >= second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(ulong first, long second) {
			unchecked {
				return 0 <= second && first <= second.ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(ulong first, long second) {
			unchecked {
				return 0 > second || first > second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(ulong first, long second) {
			unchecked {
				return !(second < 0) && first < second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(ulong first, long second) {
			unchecked {
				return !(second >= 0) || first >= second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(ulong first, IntPtr second) {
			unchecked {
				return 0 <= second.ExtendToXLong() && first <= second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(ulong first, IntPtr second) {
			unchecked {
				return 0 > second.ExtendToXLong() || first > second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(ulong first, IntPtr second) {
			unchecked {
				return !(second.ExtendToXLong() < 0) && first < second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(ulong first, IntPtr second) {
			unchecked {
				return !(second.ExtendToXLong() >= 0) || first >= second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(ulong first, Int128 second) {
			unchecked {
				return 0 <= second && first <= second.ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(ulong first, Int128 second) {
			unchecked {
				return 0 > second || first > second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(ulong first, Int128 second) {
			unchecked {
				return !(second < 0) && first < second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(ulong first, Int128 second) {
			unchecked {
				return !(second >= 0) || first >= second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(ulong first, uint second) {
			unchecked {
				return first <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(ulong first, uint second) {
			unchecked {
				return first > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(ulong first, uint second) {
			unchecked {
				return first < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(ulong first, uint second) {
			unchecked {
				return first >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(ulong first, ulong second) {
			unchecked {
				return first <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(ulong first, ulong second) {
			unchecked {
				return first > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(ulong first, ulong second) {
			unchecked {
				return first < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(ulong first, ulong second) {
			unchecked {
				return first >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(ulong first, UIntPtr second) {
			unchecked {
				return first <= second.ExtendToXLong();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(ulong first, UIntPtr second) {
			unchecked {
				return first > second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(ulong first, UIntPtr second) {
			unchecked {
				return first < second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(ulong first, UIntPtr second) {
			unchecked {
				return first >= second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(ulong first, UInt128 second) {
			unchecked {
				return first <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(ulong first, UInt128 second) {
			unchecked {
				return first > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(ulong first, UInt128 second) {
			unchecked {
				return first < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(ulong first, UInt128 second) {
			unchecked {
				return first >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UIntPtr first, int second) {
			unchecked {
				return 0 <= second && first.ExtendToXLong() <= second.ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UIntPtr first, int second) {
			unchecked {
				return 0 > second || first.ExtendToXLong() > second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UIntPtr first, int second) {
			unchecked {
				return !(second < 0) && first.ExtendToXLong() < second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UIntPtr first, int second) {
			unchecked {
				return !(second >= 0) || first.ExtendToXLong() >= second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UIntPtr first, long second) {
			unchecked {
				return 0 <= second && first.ExtendToXLong() <= second.ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UIntPtr first, long second) {
			unchecked {
				return 0 > second || first.ExtendToXLong() > second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UIntPtr first, long second) {
			unchecked {
				return !(second < 0) && first.ExtendToXLong() < second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UIntPtr first, long second) {
			unchecked {
				return !(second >= 0) || first.ExtendToXLong() >= second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UIntPtr first, IntPtr second) {
			unchecked {
				return 0 <= second.ExtendToXLong() && first.ExtendToXLong() <= second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UIntPtr first, IntPtr second) {
			unchecked {
				return 0 > second.ExtendToXLong() || first.ExtendToXLong() > second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UIntPtr first, IntPtr second) {
			unchecked {
				return !(second.ExtendToXLong() < 0) && first.ExtendToXLong() < second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UIntPtr first, IntPtr second) {
			unchecked {
				return !(second.ExtendToXLong() >= 0) || first.ExtendToXLong() >= second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UIntPtr first, Int128 second) {
			unchecked {
				return 0 <= second && first.ExtendToXLong() <= second.ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UIntPtr first, Int128 second) {
			unchecked {
				return 0 > second || first.ExtendToXLong() > second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UIntPtr first, Int128 second) {
			unchecked {
				return !(second < 0) && first.ExtendToXLong() < second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UIntPtr first, Int128 second) {
			unchecked {
				return !(second >= 0) || first.ExtendToXLong() >= second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UIntPtr first, uint second) {
			unchecked {
				return first.ExtendToXLong() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UIntPtr first, uint second) {
			unchecked {
				return first.ExtendToXLong() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UIntPtr first, uint second) {
			unchecked {
				return first.ExtendToXLong() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UIntPtr first, uint second) {
			unchecked {
				return first.ExtendToXLong() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UIntPtr first, ulong second) {
			unchecked {
				return first.ExtendToXLong() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UIntPtr first, ulong second) {
			unchecked {
				return first.ExtendToXLong() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UIntPtr first, ulong second) {
			unchecked {
				return first.ExtendToXLong() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UIntPtr first, ulong second) {
			unchecked {
				return first.ExtendToXLong() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UIntPtr first, UIntPtr second) {
			unchecked {
				return first.ExtendToXLong() <= second.ExtendToXLong();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UIntPtr first, UIntPtr second) {
			unchecked {
				return first.ExtendToXLong() > second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UIntPtr first, UIntPtr second) {
			unchecked {
				return first.ExtendToXLong() < second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UIntPtr first, UIntPtr second) {
			unchecked {
				return first.ExtendToXLong() >= second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UIntPtr first, UInt128 second) {
			unchecked {
				return first.ExtendToXLong() <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UIntPtr first, UInt128 second) {
			unchecked {
				return first.ExtendToXLong() > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UIntPtr first, UInt128 second) {
			unchecked {
				return first.ExtendToXLong() < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UIntPtr first, UInt128 second) {
			unchecked {
				return first.ExtendToXLong() >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UInt128 first, int second) {
			unchecked {
				return 0 <= second && first <= second.ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UInt128 first, int second) {
			unchecked {
				return 0 > second || first > second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UInt128 first, int second) {
			unchecked {
				return !(second < 0) && first < second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UInt128 first, int second) {
			unchecked {
				return !(second >= 0) || first >= second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UInt128 first, long second) {
			unchecked {
				return 0 <= second && first <= second.ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UInt128 first, long second) {
			unchecked {
				return 0 > second || first > second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UInt128 first, long second) {
			unchecked {
				return !(second < 0) && first < second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UInt128 first, long second) {
			unchecked {
				return !(second >= 0) || first >= second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UInt128 first, IntPtr second) {
			unchecked {
				return 0 <= second.ExtendToXLong() && first <= second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UInt128 first, IntPtr second) {
			unchecked {
				return 0 > second.ExtendToXLong() || first > second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UInt128 first, IntPtr second) {
			unchecked {
				return !(second.ExtendToXLong() < 0) && first < second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UInt128 first, IntPtr second) {
			unchecked {
				return !(second.ExtendToXLong() >= 0) || first >= second.ExtendToXLong().ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UInt128 first, Int128 second) {
			unchecked {
				return 0 <= second && first <= second.ToUnsignedUnchecked();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UInt128 first, Int128 second) {
			unchecked {
				return 0 > second || first > second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UInt128 first, Int128 second) {
			unchecked {
				return !(second < 0) && first < second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UInt128 first, Int128 second) {
			unchecked {
				return !(second >= 0) || first >= second.ToUnsignedUnchecked();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UInt128 first, uint second) {
			unchecked {
				return first <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UInt128 first, uint second) {
			unchecked {
				return first > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UInt128 first, uint second) {
			unchecked {
				return first < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UInt128 first, uint second) {
			unchecked {
				return first >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UInt128 first, ulong second) {
			unchecked {
				return first <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UInt128 first, ulong second) {
			unchecked {
				return first > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UInt128 first, ulong second) {
			unchecked {
				return first < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UInt128 first, ulong second) {
			unchecked {
				return first >= second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UInt128 first, UIntPtr second) {
			unchecked {
				return first <= second.ExtendToXLong();
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UInt128 first, UIntPtr second) {
			unchecked {
				return first > second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UInt128 first, UIntPtr second) {
			unchecked {
				return first < second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UInt128 first, UIntPtr second) {
			unchecked {
				return first >= second.ExtendToXLong();
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThanOrEqual(UInt128 first, UInt128 second) {
			unchecked {
				return first <= second;
			}
        }

        [CLSCompliantAttribute(false)]
		[ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThan(UInt128 first, UInt128 second) {
			unchecked {
				return first > second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool LessThan(UInt128 first, UInt128 second) {
			unchecked {
				return first < second;
			}
        }
        
        [CLSCompliantAttribute(false)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool GreaterThenOrEqual(UInt128 first, UInt128 second) {
			unchecked {
				return first >= second;
			}
        }
    }
}
