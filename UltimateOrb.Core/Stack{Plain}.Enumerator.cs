using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Plain.ValueTypes {
    using UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic;

    public partial struct Stack<T> {

        public partial struct Enumerator
            : IEnumerator<T> {

            private readonly T[] buffer;

            private readonly int count;

            private int index;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Enumerator(Stack<T> collection) {
                this.buffer = collection.m_buffer;
                var count = collection.m_count;
                this.count = count;
                this.index = count;
            }

            public T Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.buffer[this.index];
                }
            }

            ref T RefReturn.Collections.Generic.IEnumerator<T>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref this.buffer[this.index];
                }
            }

            object System.Collections.IEnumerator.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.buffer[this.index];
                }
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Dispose() {
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() {
                var c = this.index;
                if (c > 0) {
                    unchecked {
                        --c;
                    }
                    this.index = c;
                    return true;
                }
                return false;
            }

            [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Reset() {
                this.index = this.count;
            }
        }
    }
}
