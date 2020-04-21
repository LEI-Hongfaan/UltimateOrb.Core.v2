using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using UltimateOrb.RefReturn.Collections.Generic;
using UltimateOrb.Typed_RefReturn.Collections.Generic;

namespace UltimateOrb {

    [SerializableAttribute()]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public readonly partial struct StandardArrayAsList<T> : System.Collections.Generic.IList<T>, System.Collections.Generic.IReadOnlyList<T>, Typed_RefReturn_Wrapped_Huge.Collections.Generic.IList<T, StandardArrayAsList<T>.Enumerator>, Typed_RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyList<T, StandardArrayAsList<T>.Enumerator> {

        private readonly T[] m_value;

        public void Add(T item) {
            // TODO
            throw new NotSupportedException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StandardArrayAsList<T>(T[] value) {
            return new StandardArrayAsList<T>(value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static implicit operator T[](StandardArrayAsList<T> value) {
            return value.m_value;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public StandardArrayAsList(T[] value) {
            this.m_value = value;
        }

        public void Clear() {
            // TODO
            throw new NotSupportedException();
        }

        public bool Contains(T item) {
            var buffer = this.m_value;
            var length = buffer.Length; // null check
            var count = length;
            if (null != item) {
                System.Collections.Generic.EqualityComparer<T> c = System.Collections.Generic.EqualityComparer<T>.Default;
                for (var i = 0; count > i; ++i) {
                    if (c.Equals(buffer[i], item)) {
                        return true;
                    }
                }
                return false;
            }
            {
                for (var i = 0; count > i; ++i) {
                    if (null == buffer[i]) {
                        return true;
                    }
                }
                return false;
            }
        }

        public void CopyTo(Array<T> array, int arrayIndex) {
            throw new NotImplementedException();
        }

        public void CopyTo(Array<T> array, long arrayIndex) {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex) {
            // TODO
            var buffer = this.m_value;
            Array.Copy(buffer, 0, array, arrayIndex, buffer.Length);
        }

        public void CopyTo(T[] array, long arrayIndex) {
            throw new NotImplementedException();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() {
            return new Enumerator(this.m_value);
        }

        ref T RefReturn.Collections.Generic.ICollection<T>.Add(T item) {
            // TODO
            throw new NotSupportedException();
        }

        int System.Collections.Generic.ICollection<T>.Count {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => checked((int)this.m_value.Length);
        }

        long Huge.Collections.Generic.ICollection<T>.LongCount {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value.Length;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        IEnumerator IEnumerable.GetEnumerator() {
            return new Enumerator(this.m_value);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return new Enumerator(this.m_value);
        }

        public ref T this[int index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        [CLSCompliantAttribute(false)]
        public ref T this[uint index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        public ref T this[long index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        [CLSCompliantAttribute(false)]
        public ref T this[ulong index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        ref readonly T RefReturn.Collections.Generic.IReadOnlyList<T>.this[int index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        ref readonly T RefReturn_Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        T System.Collections.Generic.IReadOnlyList<T>.this[int index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value[index];
        }

        T Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value[index];
        }

        T System.Collections.Generic.IList<T>.this[int index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value[index];

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this.m_value[index] = value;
        }

        T Huge.Collections.Generic.IList<T>.this[long index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value[index];

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this.m_value[index] = value;
        }

        public long LongLength {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value.Length;
        }

        public int Length {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => checked((int)this.m_value.Length);
        }

        public bool IsReadOnly {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => true;
        }

        public bool IsFixedSize {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => true;
        }

        public long LongCount {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            // TODO: FUTURE
            get => this.m_value.LongLength;
        }

        int System.Collections.Generic.IReadOnlyCollection<T>.Count {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => checked((int)this.m_value.Length);
        }

        public int IndexOf(T item) {
            // TODO
            return Array.IndexOf<T>(this.m_value, item);
        }

        public int IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            var buffer = this.m_value;
            for (var i = 0; buffer.Length > i; ++i) {
                if (comparer.Equals(item, buffer[i])) {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item) {
            // TODO
            throw new NotSupportedException();
        }

        public ref T Insert(long index, T item) {
            throw new NotImplementedException();
        }

        public long LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            throw new NotImplementedException();
        }

        long Typed_Huge.Collections.Generic.IList<T, Enumerator>.LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return LongIndexOf(item, comparer);
        }

        long Typed_RefReturn_Huge.Collections.Generic.IReadOnlyList<T, Enumerator>.LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return LongIndexOf(item, comparer);
        }

        public long LongIndexOf(T item) {
            throw new NotImplementedException();
        }

        public bool Remove(T item) {
            // TODO
            throw new NotSupportedException();
        }

        public bool Remove<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            // TODO
            throw new NotSupportedException();
        }

        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return Remove(item, comparer);
        }

        public void RemoveAt(int index) {
            // TODO
            throw new NotSupportedException();
        }

        public void RemoveAt(long index) {
            // TODO
            throw new NotSupportedException();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        ref T UltimateOrb.RefReturn.Collections.Generic.IList<T>.Insert(int index, T item) {
            // TODO
            throw new NotSupportedException();
        }

        void UltimateOrb.Huge.Collections.Generic.IList<T>.Insert(long index, T item) {
            // TODO
            throw new NotSupportedException();
        }

        RefReturn.Collections.Generic.IReadOnlyEnumerator<T> RefReturn.Collections.Generic.IReadOnlyEnumerable<T>.GetEnumerator() {
            return GetEnumerator();
        }

        RefReturn.Collections.Generic.IEnumerator<T> RefReturn.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return GetEnumerator();
        }

        public bool Contains<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            var buffer = this.m_value;
            var length = buffer.Length; // null check
            var count = length;
            for (int i = 0; count > i; i++) {
                if (comparer.Equals(buffer[i], item)) {
                    return true;
                }
            }
            return false;
        }

        bool Typed_RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return Contains(item, comparer);
        }

        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return Contains(item, comparer);
        }

        public struct Enumerator : System.Collections.Generic.IEnumerator<T>, Typed_RefReturn.Collections.Generic.IEnumerator<T>, Typed_RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {

            private readonly T[] array;

            private int index;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Enumerator(T[] array) {
                this.array = array;
                this.index = -1;
            }

            public ref T Current {
                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => ref this.array[this.index];
            }

            ref readonly T RefReturn.Collections.Generic.IReadOnlyEnumerator<T>.Current {
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => ref this.array[this.index];
            }

            T System.Collections.Generic.IEnumerator<T>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => this.array[this.index];
            }

            object IEnumerator.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => this.array[this.index];
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
