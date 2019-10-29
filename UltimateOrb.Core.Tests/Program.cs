using System;

namespace UltimateOrb.Core.Tests {

    internal static class Program {

        private static int Main(string[] args) {
            return 0;
        }
    }
}
namespace UltimateOrb {

    public struct BclArrayAccessorBasic<T>
        : IArrayAccessorBasic<T> {

        ref T IArrayAccessorBasic<T>.this[int index] => throw new NotImplementedException();

        ref T IArrayAccessorBasic<T>.this[uint index] => throw new NotImplementedException();

        ref T IArrayAccessorBasic<T>.this[long index] => throw new NotImplementedException();

        ref T IArrayAccessorBasic<T>.this[ulong index] => throw new NotImplementedException();

        ref T IArrayAccessorBasic<T>.this[IntPtr index] => throw new NotImplementedException();

        ref T IArrayAccessorBasic<T>.this[UIntPtr index] => throw new NotImplementedException();

        bool IArrayAccessorBasic<T>.IsHuge => throw new NotImplementedException();

        int IArrayAccessorBasic<T>.Length => throw new NotImplementedException();

        long IArrayAccessorBasic<T>.LongLength => throw new NotImplementedException();
    }
}
    namespace UltimateOrb {
    using System;
    using System.Runtime.CompilerServices;
    using static UltimateOrb.Utilities.SignConverter;

    public readonly struct ArrayAsList<T, TArray>
        : Typed_RefReturn_Wrapped_Huge.Collections.Generic.IList<T, ArrayAsList<T, TArray>.Enumerator>
        , Typed_RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyList<T, ArrayAsList<T, TArray>.Enumerator>
        , IArrayAccessorBasic<T>
        where TArray : IArrayAccessorBasic<T> {

        private readonly TArray m_value;

        public ref T this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        public ref T this[uint index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        public ref T this[long index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        public ref T this[ulong index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        public ref T this[IntPtr index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        public ref T this[UIntPtr index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        public int Length {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value.Length;
        }

        public long LongLength {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value.LongLength;
        }

        private long LongCount {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.LongLength;
        }

        private int Count {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Length;
        }

        private bool IsReadOnly {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => true;
        }

        private ref T Add(T item) {
            // TODO: perf
            throw new NotSupportedException();
        }

        private void Clear() {
            // TODO: perf
            throw new NotSupportedException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item) {
            return this.Contains(item, System.Collections.Generic.EqualityComparer<T>.Default);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains<TEqualityComparer>(T item, TEqualityComparer comparer)
            where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            return -1 != this.IndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(Array<T> array, long arrayIndex) {
            throw new NotImplementedException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, long arrayIndex) {
            throw new NotImplementedException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(Array<T> array, int arrayIndex) {
            throw new NotImplementedException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, int arrayIndex) {
            throw new NotImplementedException();
        }


        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() {
            return new Enumerator(this.m_value);
        }


        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer)
            where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            var buffer = this.m_value;
            for (var i = 0; buffer.Length > i; ++i) {
                if (comparer.Equals(item, buffer[i])) {
                    return i;
                }
            }
            return -1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item) {
            return this.IndexOf(item, System.Collections.Generic.EqualityComparer<T>.Default);
        }

        private ref T Insert(long index, T item) {
            // TODO: perf
            throw new NotSupportedException();
        }

        private ref T Insert(int index, T item) {
            // TODO: perf
            throw new NotSupportedException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public long LongIndexOf(T item) {
            return this.LongIndexOf(item, System.Collections.Generic.EqualityComparer<T>.Default);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public long LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer)
            where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            var buffer = this.m_value;
            for (var i = (long)0; buffer.LongLength > i; ++i) {
                if (comparer.Equals(item, buffer[i])) {
                    return i;
                }
            }
            return -1;
        }

        private bool Remove<TEqualityComparer>(T item, TEqualityComparer comparer)
             where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            // TODO: perf
            throw new NotSupportedException();
        }

        private bool Remove(T item) {
            // TODO: perf
            throw new NotSupportedException();
        }

        private void RemoveAt(long index) {
            // TODO: perf
            throw new NotSupportedException();
        }

        private void RemoveAt(int index) {
            // TODO: perf
            throw new NotSupportedException();
        }

        private bool IsHuge {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => true;
        }

        #region Explicit Interface Implements (Default)
        bool IArrayAccessorBasic<T>.IsHuge {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.IsHuge;
        }

        ref T RefReturn_Huge.Collections.Generic.IList<T>.this[long index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        T Huge.Collections.Generic.IList<T>.this[long index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[index];

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this[index] = value;
        }

        ref T RefReturn.Collections.Generic.IList<T>.this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        T System.Collections.Generic.IList<T>.this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[index];

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this[index] = value;
        }

        ref readonly T RefReturn_Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        T Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[index];
        }

        ref readonly T RefReturn.Collections.Generic.IReadOnlyList<T>.this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        T System.Collections.Generic.IReadOnlyList<T>.this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[index];
        }

        ref T IArrayAccessorBasic<T>.this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        ref T IArrayAccessorBasic<T>.this[uint index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        ref T IArrayAccessorBasic<T>.this[long index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        ref T IArrayAccessorBasic<T>.this[ulong index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        ref T IArrayAccessorBasic<T>.this[IntPtr index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        ref T IArrayAccessorBasic<T>.this[UIntPtr index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        long Huge.Collections.Generic.ICollection<T>.LongCount {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.LongCount;
        }

        long Huge.Collections.Generic.IReadOnlyCollection<T>.LongCount {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.LongCount;
        }

        int System.Collections.Generic.ICollection<T>.Count {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Count;
        }

        int System.Collections.Generic.IReadOnlyCollection<T>.Count {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Count;
        }

        bool System.Collections.Generic.ICollection<T>.IsReadOnly {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.IsReadOnly;
        }

        int IArrayAccessorBasic<T>.Length {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Length;
        }

        long IArrayAccessorBasic<T>.LongLength {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.LongLength;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        ref T RefReturn.Collections.Generic.ICollection<T>.Add(T item) {
            return ref this.Add(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.ICollection<T>.Add(T item) {
            this.Add(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.ICollection<T>.Clear() {
            this.Clear();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Contains(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed.Collections.Generic.ICollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Contains(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool System.Collections.Generic.ICollection<T>.Contains(T item) {
            return this.Contains(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Contains(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_RefReturn.Collections.Generic.IReadOnlyCollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Contains(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Wrapped_Huge.Collections.Generic.ICollection<T>.CopyTo(Array<T> array, long arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Huge.Collections.Generic.ICollection<T>.CopyTo(T[] array, long arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Wrapped.Collections.Generic.ICollection<T>.CopyTo(Array<T> array, int arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.ICollection<T>.CopyTo(T[] array, int arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyCollection<T>.CopyTo(Array<T> array, long arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T>.CopyTo(T[] array, long arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void RefReturn_Wrapped.Collections.Generic.IReadOnlyCollection<T>.CopyTo(Array<T> array, int arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        RefReturn.Collections.Generic.IEnumerator<T> RefReturn.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        Enumerator Typed.Collections.Generic.IEnumerable<T, Enumerator>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        RefReturn.Collections.Generic.IReadOnlyEnumerator<T> RefReturn.Collections.Generic.IReadOnlyEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        Enumerator Typed.Collections.Generic.IReadOnlyEnumerable<T, Enumerator>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        int Typed.Collections.Generic.IList<T, Enumerator>.IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.IndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        int System.Collections.Generic.IList<T>.IndexOf(T item) {
            return this.IndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        int Typed_RefReturn.Collections.Generic.IReadOnlyList<T, Enumerator>.IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.IndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        int RefReturn.Collections.Generic.IReadOnlyList<T>.IndexOf(T item) {
            return this.IndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        ref T RefReturn_Huge.Collections.Generic.IList<T>.Insert(long index, T item) {
            return ref this.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Huge.Collections.Generic.IList<T>.Insert(long index, T item) {
            this.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        ref T RefReturn.Collections.Generic.IList<T>.Insert(int index, T item) {
            return ref this.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.IList<T>.Insert(int index, T item) {
            this.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        long Typed_Huge.Collections.Generic.IList<T, Enumerator>.LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.LongIndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        long Huge.Collections.Generic.IList<T>.LongIndexOf(T item) {
            return this.LongIndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        long Typed_RefReturn_Huge.Collections.Generic.IReadOnlyList<T, Enumerator>.LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.LongIndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        long RefReturn_Huge.Collections.Generic.IReadOnlyList<T>.LongIndexOf(T item) {
            return this.LongIndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Remove(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed.Collections.Generic.ICollection<T, Enumerator>.Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Remove(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool System.Collections.Generic.ICollection<T>.Remove(T item) {
            return this.Remove(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Huge.Collections.Generic.IList<T>.RemoveAt(long index) {
            this.RemoveAt(index);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.IList<T>.RemoveAt(int index) {
            this.RemoveAt(index);
        }
        #endregion

        [SerializableAttribute()]
        public struct Enumerator
            : Typed_RefReturn_Wrapped_Huge.Collections.Generic.IEnumerator<T>
            , Typed_RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyEnumerator<T> {

            private readonly TArray _array;

            private long _index;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Enumerator(TArray array) {
                this._array = array;
                this._index = -1;
            }

            public ref T Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => ref this._array[this._index];
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Dispose() {
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() {
                var length = this._array.LongLength;
                var index = this._index;
                unchecked {
                    ++index;
                }
                if (length.ToUnsignedUnchecked() > index.ToUnsignedUnchecked()) {
                    this._index = index;
                    return true;
                }
                this._index = length;
                return false;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Reset() {
                this._index = -1;
            }

            #region Explicit Interface Implements (Default)
            ref T RefReturn.Collections.Generic.IEnumerator<T>.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => ref this.Current;
            }

            T System.Collections.Generic.IEnumerator<T>.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => this.Current;
            }

            object System.Collections.IEnumerator.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => this.Current;
            }

            ref readonly T RefReturn.Collections.Generic.IReadOnlyEnumerator<T>.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => ref this.Current;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            void IDisposable.Dispose() {
                this.Dispose();
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            bool System.Collections.IEnumerator.MoveNext() {
                return this.MoveNext();
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            void System.Collections.IEnumerator.Reset() {
                this.Reset();
            }
            #endregion
        }
    }
}
