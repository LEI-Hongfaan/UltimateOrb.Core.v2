using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Core.Tests {

    public static partial class ReadOnlyArrayModule {

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<T> ToReadOnly<T>(this T[] array) {
            return new ReadOnlyArray<T>(array);
        }
    }
}
