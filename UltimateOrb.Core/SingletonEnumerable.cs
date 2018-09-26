using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Linq {
    using Local = UltimateOrb.Typed_Wrapped_Huge;

    public readonly partial struct SingletonEnumerable<T>
        : Local.Collections.Generic.IEnumerable<T, SingletonEnumerable<T>.Enumerator>
        , Local.Collections.Generic.IReadOnlyEnumerable<T, SingletonEnumerable<T>.Enumerator> {

        private readonly T Value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public SingletonEnumerable(T value) {
            this.Value = value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public Enumerator GetEnumerator() {
            return new Enumerator(this);
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return new Enumerator(this);
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        IEnumerator IEnumerable.GetEnumerator() {
            return new Enumerator(this);
        }


        public partial struct Enumerator
            : Local.Collections.Generic.IEnumerator<T>
            , Local.Collections.Generic.IReadOnlyEnumerator<T> {

            private readonly SingletonEnumerable<T> sinletonEnumerable;

            private sbyte index;

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            public Enumerator(SingletonEnumerable<T> sinletonEnumerable) {
                this.sinletonEnumerable = sinletonEnumerable;
                this.index = -1;
            }

            public T Current {

                [TargetedPatchingOptOutAttribute(null)]
                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                [PureAttribute()]
                get => this.sinletonEnumerable.Value;
            }

            object IEnumerator.Current {

                [TargetedPatchingOptOutAttribute(null)]
                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                [PureAttribute()]
                get => this.sinletonEnumerable.Value;
            }

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            public void Dispose() {
            }

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            public bool MoveNext() {
                var i = this.index;
                if (1 > i) {
                    unchecked {
                        ++i;
                    }
                    this.index = i;
                }
                return 0 == i;
            }

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            public void Reset() {
                this.index = -1;
            }
        }
    }
}
