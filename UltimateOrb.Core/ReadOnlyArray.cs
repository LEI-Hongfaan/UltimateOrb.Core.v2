using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace UltimateOrb {

    [SerializableAttribute()]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public readonly partial struct ReadOnlyArray<T>
        : System.Collections.Generic.IList<T>
        , System.Collections.Generic.IReadOnlyList<T>
        , Typed_RefReturn_Wrapped_Huge.Collections.Generic.IList<T, ReadOnlyArray<T>.Enumerator>
        , Typed_RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyList<T, ReadOnlyArray<T>.Enumerator> {

        private readonly ReadOnly[] m_value;

        internal ReadOnly[] Value {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value;
        }

        [SerializableAttribute()]
        [StructLayoutAttribute(LayoutKind.Sequential)]
        internal readonly partial struct ReadOnly {

            internal readonly T Value;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal ReadOnly(T value) {
                this.Value = value;
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private ReadOnlyArray(ReadOnly[] array) {
            this.m_value = array;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyArray(T[] array) {
            if (null != array) {
                var a = new ReadOnly[array.Length];
                for (var i = 0; array.Length > i; ++i) {
                    a[i] = new ReadOnly(array[i]);
                }
                this.m_value = a;
                return;
            }
            this.m_value = null;
        }

        public ref readonly T this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index].Value;
        }

        [CLSCompliantAttribute(false)]
        public ref readonly T this[uint index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index].Value;
        }

        public ref readonly T this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index].Value;
        }

        [CLSCompliantAttribute(false)]
        public ref readonly T this[ulong index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index].Value;
        }


        T IList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value[index].Value;

            set {
                // TODO
                throw new NotSupportedException();
            }
        }

        T Huge.Collections.Generic.IList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value[index].Value;

            set {
                // TODO
                throw new NotSupportedException();
            }
        }

        ref T RefReturn.Collections.Generic.IList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                // TODO
                throw new NotSupportedException();
            }
        }

        ref T RefReturn_Huge.Collections.Generic.IList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                // TODO
                throw new NotSupportedException();
            }
        }

        T System.Collections.Generic.IReadOnlyList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value[index].Value;
        }

        T Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value[index].Value;
        }

        ref readonly T RefReturn_Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index].Value;
        }


        public long LongLength {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value.Length;
        }

        public int Length {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => checked((int) this.m_value.Length);
        }

        long Huge.Collections.Generic.IReadOnlyCollection<T>.LongCount {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value.Length;
        }

        int IReadOnlyCollection<T>.Count {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => checked((int) this.m_value.Length);
        }

        int System.Collections.Generic.ICollection<T>.Count {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => checked((int) this.m_value.Length);
        }

        bool System.Collections.Generic.ICollection<T>.IsReadOnly {

            get => true;
        }

        long Huge.Collections.Generic.ICollection<T>.LongCount {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value.LongLength;
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

        public int IndexOf(T item) {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item) {
            // TODO
            throw new NotSupportedException();
        }

        public void RemoveAt(int index) {
            // TODO
            throw new NotSupportedException();
        }

        public void Add(T item) {
            // TODO
            throw new NotSupportedException();
        }

        void ICollection<T>.Clear() {
            // TODO
            throw new NotSupportedException();
        }

        public bool Contains(T item) {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex) {
            throw new NotImplementedException();
        }

        public bool Remove(T item) {
            // TODO
            throw new NotSupportedException();
        }

        ref T RefReturn.Collections.Generic.IList<T>.Insert(int index, T item) {
            // TODO
            throw new NotSupportedException();
        }

        private ref T Insert(long index, T item) {
            // TODO
            throw new NotSupportedException();
        }

        public int IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            throw new NotImplementedException();
        }

        public long LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            throw new NotImplementedException();
        }
        long Typed_Huge.Collections.Generic.IList<T, Enumerator>.LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            throw new NotImplementedException();
        }

        long Typed_RefReturn_Huge.Collections.Generic.IReadOnlyList<T, Enumerator>.LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            throw new NotImplementedException();
        }

        public long LongIndexOf(T item) {
            throw new NotImplementedException();
        }

        void Huge.Collections.Generic.IList<T>.Insert(long index, T item) {
            // TODO
            throw new NotSupportedException();
        }

        public void RemoveAt(long index) {
            // TODO
            throw new NotSupportedException();
        }

        ref T RefReturn.Collections.Generic.ICollection<T>.Add(T item) {
            // TODO
            throw new NotSupportedException();
        }

        public bool Contains<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            throw new NotImplementedException();
        }
        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            throw new NotImplementedException();
        }

        bool Typed_RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            throw new NotImplementedException();
        }

        private bool Remove<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            // TODO
            throw new NotSupportedException();
        }

        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
            // TODO
            throw new NotSupportedException();
        }

        public void CopyTo(T[] array, long arrayIndex) {
            throw new NotImplementedException();
        }

        public void CopyTo(Array<T> array, int arrayIndex) {
            throw new NotImplementedException();
        }

        public void CopyTo(Array<T> array, long arrayIndex) {
            throw new NotImplementedException();
        }

        RefReturn.Collections.Generic.IReadOnlyEnumerator<T> RefReturn.Collections.Generic.IReadOnlyEnumerable<T>.GetEnumerator() {
            throw new NotImplementedException();
        }

        ref T RefReturn_Huge.Collections.Generic.IList<T>.Insert(long index, T item) {
            throw new NotImplementedException();
        }

        RefReturn.Collections.Generic.IEnumerator<T> RefReturn.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            throw new NotImplementedException();
        }

        bool Typed.Collections.Generic.ICollection<T, Enumerator>.Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
            throw new NotImplementedException();
        }

        public static partial class Empty {

            public static readonly ReadOnlyArray<T> Value = new ReadOnlyArray<T>(Array_Empty<ReadOnly>.Value);
        }

        public partial struct Enumerator
            : System.Collections.Generic.IEnumerator<T>
            , Typed_RefReturn_Wrapped_Huge.Collections.Generic.IEnumerator<T>
            , Typed_RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyEnumerator<T> {

            private readonly ReadOnly[] array;

            private int index;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Enumerator(ReadOnlyArray<T> array) {
                this.array = array.m_value;
                this.index = -1;
            }

            public ref readonly T Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => ref this.array[this.index].Value;
            }

            ref T RefReturn.Collections.Generic.IEnumerator<T>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                // TODO
                get => throw new NotSupportedException();
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
