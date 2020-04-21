using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace UltimateOrb {
    using Local = Typed_RefReturn_Wrapped_Huge;

    [SerializableAttribute()]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public readonly partial struct StandardArrayAsReadOnlyList<T>
        : IList<T>
        , IReadOnlyList<T>
        , Local.Collections.Generic.IList<T, StandardArrayAsReadOnlyList<T>.Enumerator>
        , Local.Collections.Generic.IReadOnlyList<T, StandardArrayAsReadOnlyList<T>.Enumerator> {

        private readonly T[] m_value;

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public StandardArrayAsReadOnlyList(T[] value) {
            this.m_value = value;
        }

        public ref readonly T this[int index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        [CLSCompliantAttribute(false)]
        public ref readonly T this[uint index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        public ref readonly T this[long index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }

        [CLSCompliantAttribute(false)]
        public ref readonly T this[ulong index] {
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.m_value[index];
        }


        internal T[] Value {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value;
        }

        public long LongLength {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            // TODO
            get => this.m_value.Length;
        }

        public int Length {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => checked((int) this.m_value.Length);
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
        private int Count {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Length;
        }

        private long LongCount {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.LongLength;
        }

        long Huge.Collections.Generic.ICollection<T>.LongCount {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.LongLength;
        }

        int System.Collections.Generic.ICollection<T>.Count {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Count;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item) {
            var buffer = this.m_value;
            var length = buffer.Length; // null check
            var count = length;
            if (null != item) {
                EqualityComparer<T> c = EqualityComparer<T>.Default;
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

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
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

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, int arrayIndex) {
            // TODO
            var buffer = this.m_value;
            Array.Copy(buffer, 0, array, arrayIndex, buffer.Length);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() {
            return new Enumerator(this.m_value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item) {
            // TODO
            return Array.IndexOf<T>(this.m_value, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            var buffer = this.m_value;
            for (var i = 0; buffer.Length > i; ++i) {
                if (comparer.Equals(item, buffer[i])) {
                    return i;
                }
            }
            return -1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public long LongIndexOf(T item) {
            var array = this.m_value;
            if (array == null) {
                // TODO: Perf
                throw new ArgumentNullException(nameof(array));
            }
            System.Diagnostics.Contracts.Contract.Ensures(System.Diagnostics.Contracts.Contract.Result<int>() < array.Length);
            System.Diagnostics.Contracts.Contract.EndContractBlock();
            var comparer = EqualityComparer<T>.Default;
            for (var i = (long) 0; array.LongLength > i; ++i) {
                if (comparer.Equals(array[i], item)) {
                    return i;
                }
            }
            return -1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public long LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            var buffer = this.m_value;
            for (var i = (long) 0; buffer.Length > i; ++i) {
                if (comparer.Equals(item, buffer[i])) {
                    return i;
                }
            }
            return -1;
        }

        #region Members Not Supported
        private void Add(T item) {
            // TODO
            throw new NotSupportedException();
        }

        private void Clear() {
            // TODO
            throw new NotSupportedException();
        }

        private void Insert(int index, T item) {
            // TODO
            throw new NotSupportedException();
        }

        private bool Remove(T item) {
            // TODO
            throw new NotSupportedException();
        }

        private bool Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
            // TODO
            throw new NotSupportedException();
        }

        private void RemoveAt(int index) {
            // TODO
            throw new NotSupportedException();
        }

        private ref T AddRef(T item) {
            // TODO
            throw new NotSupportedException();
        }

        private ref T InsertRef(int index, T item) {
            // TODO
            throw new NotSupportedException();
        }

        private ref T InsertRef(long index, T item) {
            // TODO
            throw new NotSupportedException();
        }

        private void Insert(long index, T item) {
            // TODO
            throw new NotSupportedException();
        }

        private void RemoveAt(long index) {
            // TODO
            throw new NotSupportedException();
        }
        #endregion

        #region Interface Implementations
        long Huge.Collections.Generic.IReadOnlyCollection<T>.LongCount {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.LongCount;
        }

        int System.Collections.Generic.IReadOnlyCollection<T>.Count {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Count;
        }

        bool System.Collections.Generic.ICollection<T>.IsReadOnly {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.IsReadOnly;
        }

        T System.Collections.Generic.IReadOnlyList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value[index];
        }

        T System.Collections.Generic.IList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[index];

            set {
                //TODO
                throw new NotSupportedException();
            }
        }

        T Huge.Collections.Generic.IList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[index];

            set {
                //TODO
                throw new NotSupportedException();
            }
        }

        ref readonly T RefReturn.Collections.Generic.IReadOnlyList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        T Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[index];
        }

        ref readonly T RefReturn_Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }


        ref T RefReturn.Collections.Generic.IList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                //TODO
                throw new NotSupportedException();
            }
        }

        ref T RefReturn_Huge.Collections.Generic.IList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                //TODO
                throw new NotSupportedException();
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, long arrayIndex) {
            this.m_value.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(Array<T> array, int arrayIndex) {
            this.m_value.CopyTo(array.Value, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(Array<T> array, long arrayIndex) {
            // TODO: FUTURE
            this.m_value.CopyTo(array.Value, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Wrapped_Huge.Collections.Generic.ICollection<T>.CopyTo(Array<T> array, long arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        ref T RefReturn_Huge.Collections.Generic.IList<T>.Insert(long index, T item) {
            return ref this.InsertRef(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        long Typed_Huge.Collections.Generic.IList<T, Enumerator>.LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.LongIndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Contains(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Remove(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Huge.Collections.Generic.IList<T>.Insert(long index, T item) {
            this.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        long Huge.Collections.Generic.IList<T>.LongIndexOf(T item) {
            return this.LongIndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Huge.Collections.Generic.IList<T>.RemoveAt(long index) {
            this.RemoveAt(index);
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
        ref T RefReturn.Collections.Generic.IList<T>.Insert(int index, T item) {
            return ref this.InsertRef(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        ref T RefReturn.Collections.Generic.ICollection<T>.Add(T item) {
            return ref this.AddRef(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        RefReturn.Collections.Generic.IEnumerator<T> RefReturn.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        int Typed.Collections.Generic.IList<T, Enumerator>.IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.IndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed.Collections.Generic.ICollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Contains(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed.Collections.Generic.ICollection<T, Enumerator>.Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Remove(item, comparer);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        Enumerator Typed.Collections.Generic.IEnumerable<T, Enumerator>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        int System.Collections.Generic.IList<T>.IndexOf(T item) {
            return this.IndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.IList<T>.Insert(int index, T item) {
            this.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.IList<T>.RemoveAt(int index) {
            this.RemoveAt(index);
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
        bool System.Collections.Generic.ICollection<T>.Contains(T item) {
            return this.Contains(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.ICollection<T>.CopyTo(T[] array, int arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool System.Collections.Generic.ICollection<T>.Remove(T item) {
            return this.Remove(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyCollection<T>.CopyTo(Array<T> array, long arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        long Typed_RefReturn_Huge.Collections.Generic.IReadOnlyList<T, Enumerator>.LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.LongIndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Contains(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        long RefReturn_Huge.Collections.Generic.IReadOnlyList<T>.LongIndexOf(T item) {
            return this.LongIndexOf(item);
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
        int Typed_RefReturn.Collections.Generic.IReadOnlyList<T, Enumerator>.IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.IndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_RefReturn.Collections.Generic.IReadOnlyCollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Contains(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        int RefReturn.Collections.Generic.IReadOnlyList<T>.IndexOf(T item) {
            return this.IndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        RefReturn.Collections.Generic.IReadOnlyEnumerator<T> RefReturn.Collections.Generic.IReadOnlyEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        Enumerator Typed.Collections.Generic.IReadOnlyEnumerable<T, Enumerator>.GetEnumerator() {
            return this.GetEnumerator();
        }
        #endregion

        public partial struct Enumerator
            : IEnumerator<T>
            , Local.Collections.Generic.IEnumerator<T>
            , Local.Collections.Generic.IReadOnlyEnumerator<T> {

            private readonly T[] array;

            private int index;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Enumerator(T[] array) {
                this.array = array;
                this.index = -1;
            }

            public ref readonly T Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => ref this.array[this.index];
            }

            ref T RefReturn.Collections.Generic.IEnumerator<T>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                get {
                    // TODO
                    throw new NotSupportedException();
                }
            }

            T IEnumerator<T>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => this.array[this.index];
            }

            object System.Collections.IEnumerator.Current {

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

            [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Reset() {
                this.index = -1;
            }
        }
    }
}
