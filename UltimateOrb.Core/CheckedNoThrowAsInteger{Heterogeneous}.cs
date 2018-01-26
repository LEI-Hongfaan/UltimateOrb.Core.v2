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
        public static int Add(int first, uint second, out int result) {
            unchecked {
                var t = (long)first + second;
                result = (int)t;
                return int.MinValue <= t && t <= int.MaxValue ? 1 : 0;
            }
        }
    }
}
