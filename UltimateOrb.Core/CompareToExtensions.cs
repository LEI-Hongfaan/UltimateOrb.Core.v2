using System;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Utilities {

    [DiscardableAttribute()]
    public static partial class ComparisionHelper {

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Compare(long @this, long other) {
            if (@this < other) {
                return -1;
            }
            if (@this > other) {
                return 1;
            }
            return 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Compare(ulong @this, ulong other) {
            if (@this < other) {
                return -1;
            }
            if (@this > other) {
                return 1;
            }
            return 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Compare(int @this, uint other) {
            unchecked {
                return Compare((long)@this, (long)other);
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Compare(uint @this, int other) {
            unchecked {
                return Compare((long)@this, (long)other);
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Compare(long @this, ulong other) {
            unchecked {
                if (0 > @this) {
                    return -1;
                }
                return Compare(@this.ToUnsignedUnchecked(), other);
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Compare(ulong @this, long other) {
            unchecked {
                if (0 > other) {
                    return 1;
                }
                return Compare(@this, other.ToUnsignedUnchecked());
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Compare(IntPtr @this, UIntPtr other) {
            unchecked {
                return ((long)@this).CompareTo((ulong)other);
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Compare(UIntPtr @this, IntPtr other) {
            unchecked {
                return ((ulong)@this).CompareTo((long)other);
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Compare(IntPtr @this, IntPtr other) {
            unchecked {
                return ((long)@this).CompareTo((long)other);
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int Compare(UIntPtr @this, UIntPtr other) {
            unchecked {
                return ((ulong)@this).CompareTo((ulong)other);
            }
        }
    }
}

namespace UltimateOrb.Utilities {
    using static ComparisionHelper;

    [DiscardableAttribute()]
    public static partial class CompareToExtensions {

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this int @this, uint other) {
            return Compare(@this, other);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this uint @this, int other) {
            return Compare(@this, other);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this long @this, ulong other) {
            return Compare(@this, other);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this ulong @this, long other) {
            return Compare(@this, other);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this IntPtr @this, UIntPtr other) {
            return Compare(@this, other);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this UIntPtr @this, IntPtr other) {
            return Compare(@this, other);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this IntPtr @this, IntPtr other) {
            return Compare(@this, other);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static int CompareTo(this UIntPtr @this, UIntPtr other) {
            return Compare(@this, other);
        }
    }
}
