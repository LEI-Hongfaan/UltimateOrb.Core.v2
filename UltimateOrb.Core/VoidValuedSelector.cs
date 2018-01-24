using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb {

    public readonly partial struct VoidValuedSelector<T> : IFunc<T, Void>, IInitializable {

        [TargetedPatchingOptOutAttribute("")]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public Void Invoke(T arg) {
            return default;
        }

        [TargetedPatchingOptOutAttribute("")]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public void Initialize() {
            throw new System.NotImplementedException();
        }

        [TargetedPatchingOptOutAttribute("")]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public bool TryInitialize() {
            return true;
        }
    }
}
