using System;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Utilities {
	using static ComparisionHelper;

    public static partial class CompareToExtensions {

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this int @this, IntPtr other) {
			unchecked {
				return Compare((long)@this, (long)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this int @this, UIntPtr other) {
			unchecked {
				return Compare((long)@this, (ulong)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this uint @this, IntPtr other) {
			unchecked {
				return Compare((ulong)@this, (long)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this uint @this, UIntPtr other) {
			unchecked {
				return Compare((ulong)@this, (ulong)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this long @this, IntPtr other) {
			unchecked {
				return Compare((long)@this, (long)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this long @this, UIntPtr other) {
			unchecked {
				return Compare((long)@this, (ulong)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this ulong @this, IntPtr other) {
			unchecked {
				return Compare((ulong)@this, (long)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this ulong @this, UIntPtr other) {
			unchecked {
				return Compare((ulong)@this, (ulong)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this IntPtr @this, int other) {
			unchecked {
				return Compare((long)@this, (long)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this IntPtr @this, uint other) {
			unchecked {
				return Compare((long)@this, (ulong)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this IntPtr @this, long other) {
			unchecked {
				return Compare((long)@this, (long)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this IntPtr @this, ulong other) {
			unchecked {
				return Compare((long)@this, (ulong)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this UIntPtr @this, int other) {
			unchecked {
				return Compare((ulong)@this, (long)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this UIntPtr @this, uint other) {
			unchecked {
				return Compare((ulong)@this, (ulong)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this UIntPtr @this, long other) {
			unchecked {
				return Compare((ulong)@this, (long)other);
			}
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this UIntPtr @this, ulong other) {
			unchecked {
				return Compare((ulong)@this, (ulong)other);
			}
        }
    }
}
