using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace UltimateOrb.Core.Tests {

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public partial struct ReadOnlyArray<T> : Collections.Generic.RefReturnSupported.IReadOnlyList<T, ReadOnlyArray<T>.Enumerator> {

        private readonly ReadOnly[] array;

        [StructLayoutAttribute(LayoutKind.Sequential)]
        private partial struct ReadOnly {

            public readonly T Value;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public ReadOnly(T value) {
                this.Value = value;
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private ReadOnlyArray(ReadOnly[] array) {
            this.array = array;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyArray(T[] array) {
            if (null != array) {
                var a = new ReadOnly[array.Length];
                for (var i = 0; array.Length > i; ++i) {
                    a[i] = new ReadOnly(array[i]);
                }
                this.array = a;
                return;
            }
            this.array = null;
        }

        public ref readonly T this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.array[index].Value;
        }

        T System.Collections.Generic.IReadOnlyList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.array[index].Value;
        }
        public long LongLength {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.array.Length;
        }

        public int Length {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => checked((int)this.array.Length);
        }

        long Collections.Generic.IReadOnlyCollection<T, Enumerator>.LongCount {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.array.Length;
        }

        int IReadOnlyCollection<T>.Count {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => checked((int)this.array.Length);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() {
            return new Enumerator(this);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return new Enumerator(this);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        IEnumerator IEnumerable.GetEnumerator() {
            return new Enumerator(this);
        }

        public partial struct Enumerator : Collections.Generic.RefReturnSupported.IReadOnlyEnumerator<T> {

            private readonly ReadOnly[] array;

            private int index;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Enumerator(ReadOnlyArray<T> array) {
                this.array = array.array;
                this.index = -1;
            }

            public ref readonly T Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => ref this.array[this.index].Value;
            }

            T IEnumerator<T>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => this.array[this.index].Value;
            }

            object IEnumerator.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => this.array[this.index].Value;
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Dispose() {
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() {
                var i = this.index;
                checked {
                    ++i;
                }
                var count = this.array.Length;
                if (count > i) {
                    this.index = i;
                    return true;
                }
                this.index = count;
                return false;
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Reset() {
                this.index = -1;
            }
        }
    }
}
