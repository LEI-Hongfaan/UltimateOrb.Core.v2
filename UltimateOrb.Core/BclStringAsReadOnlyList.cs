using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb {

    [SerializableAttribute()]
    public readonly partial struct BclStringAsReadOnlyList : IList<char>, IReadOnlyList<char>/*, Collections.Generic.IList<char, BclStringAsReadOnlyList.Enumerator>, Collections.Generic.IReadOnlyList<char, BclStringAsReadOnlyList.Enumerator>*/ {

        private readonly string m_value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public BclStringAsReadOnlyList(string value) {
            this.m_value = value;
        }

        public int Count {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => checked((int)this.m_value.Length);
        }

        bool ICollection<char>.IsReadOnly {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => true;
        }

        public long LongCount {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.m_value.Length;
        }

        public string Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.m_value;
        }

        public char this[int index] {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.m_value[index];
        }

        char IList<char>.this[int index] {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.m_value[index];

            set => throw new NotSupportedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator BclStringAsReadOnlyList(string value) {
            return new BclStringAsReadOnlyList(value);
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator string(BclStringAsReadOnlyList value) {
            return value.m_value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        void ICollection<char>.Add(char item) {
            throw new NotSupportedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        void ICollection<char>.Clear() {
            throw new NotSupportedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public bool Contains(char item) {
            var str = this.m_value;
            for (var i = 0; str.Length > i; ++i) {
                if (item == str[i]) {
                    return true;
                }
            }
            return false;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(char[] array, int arrayIndex) {
            var str = this.m_value;
            str.CopyTo(0, array, arrayIndex, str.Length);
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

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public int IndexOf(char item) {
            var str = this.m_value;
            for (var i = 0; str.Length > i; ++i) {
                if (item == str[i]) {
                    return i;
                }
            }
            return -1;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        void IList<char>.Insert(int index, char item) {
            throw new NotSupportedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        bool ICollection<char>.Remove(char item) {
            throw new NotSupportedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        void IList<char>.RemoveAt(int index) {
            throw new NotSupportedException();
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
    }
}
