using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb {

    [SerializableAttribute()]
    public readonly partial struct BclStringAsReadOnlyList : Collections.Generic.IReadOnlyList<char, BclStringAsReadOnlyList.Enumerator> {

        private readonly string m_value;

        public string Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.m_value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public BclStringAsReadOnlyList(string value) {
            this.m_value = value;
        }

        public char this[int index] {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.m_value[index];
        }

        public long LongCount {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.m_value.Length;
        }

        public int Count {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => checked((int)this.m_value.Length);
        }

        [SerializableAttribute()]
        public partial struct Enumerator : IEnumerator<char> {

            private readonly string m_string;

            private int m_index;

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Enumerator(string str) {
                this.m_string = str;
                this.m_index = -1;
            }

            public char Current {

                [TargetedPatchingOptOutAttribute(null)]
                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                [PureAttribute()]
                get => this.m_string[this.m_index];
            }

            object IEnumerator.Current {

                [TargetedPatchingOptOutAttribute(null)]
                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => this.m_string[this.m_index];
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
            public bool MoveNext() {
                var i = this.m_index;
                unchecked {
                    ++i;
                }
                if (this.m_string.Length > i) {
                    this.m_index = i;
                    return true;
                }
                return false;
            }

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Reset() {
                this.m_index = -1;
            }
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public Enumerator GetEnumerator() {
            return new Enumerator(this.m_value);
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        IEnumerator<char> IEnumerable<char>.GetEnumerator() {
            return new Enumerator(this.m_value);
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        IEnumerator IEnumerable.GetEnumerator() {
            return new Enumerator(this.m_value);
        }
    }
}
