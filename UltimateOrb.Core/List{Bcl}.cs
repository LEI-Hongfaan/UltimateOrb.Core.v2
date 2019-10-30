using System;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Collections.Generic {
    using Local = UltimateOrb.Typed_Wrapped;
    using UltimateOrb;

    [SerializableAttribute()]
    public readonly partial struct BclListAsList<T>
        : System.Collections.Generic.IList<T>
        , System.Collections.Generic.IReadOnlyList<T>
        , Local.Collections.Generic.IList<T, System.Collections.Generic.List<T>.Enumerator>
        , Local.Collections.Generic.IReadOnlyList<T, System.Collections.Generic.List<T>.Enumerator> {

        private readonly System.Collections.Generic.List<T> m_value;

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public BclListAsList(System.Collections.Generic.List<T> value) {
            this.m_value = value;
        }

        public T this[long index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value[checked((int)index)];

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this.m_value[checked((int)index)] = value;
        }

        public T this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value[index];

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this.m_value[index] = value;
        }

        public long LongCount {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value.Count;
        }

        public int Count {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value.Count;
        }

        public bool IsReadOnly {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ((System.Collections.Generic.IList<T>)this.m_value).IsReadOnly;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Add(T item) {
            this.m_value.Add(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Clear() {
            this.m_value.Clear();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            return -1 != this.IndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item) {
            return this.m_value.Contains(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(Array<T> array, int arrayIndex) {
            this.m_value.CopyTo(array.Value, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, int arrayIndex) {
            this.m_value.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public System.Collections.Generic.List<T>.Enumerator GetEnumerator() {
            return this.m_value.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            return UltimateOrb.Collections.Generic.List.IndexOf(this, item, 0, this.Count, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item) {
            return this.m_value.IndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Insert(int index, T item) {
            this.m_value.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public long LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            return this.IndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public long LongIndexOf(T item) {
            return this.m_value.IndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            var index = this.IndexOf(item, comparer);
            if (-1 != index) {
                this.m_value.RemoveAt(index);
                return true;
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove(T item) {
            return this.m_value.Remove(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void RemoveAt(int index) {
            this.m_value.RemoveAt(index);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed.Collections.Generic.ICollection<T, System.Collections.Generic.List<T>.Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return -1 != this.IndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return this.m_value.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.m_value.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed.Collections.Generic.ICollection<T, System.Collections.Generic.List<T>.Enumerator>.Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
            var index = this.IndexOf(item, comparer);
            if (-1 != index) {
                this.m_value.RemoveAt(index);
                return true;
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer>(T item) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T>, new() {
            return this.Remove(item, DefaultConstructor.Invoke<TEqualityComparer>());
        }
    }

    [DiscardableAttribute()]
    public static partial class BclListModule {

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static BclListAsList<T> AsList<T>(this System.Collections.Generic.List<T> value) {
            return new BclListAsList<T>(value);
        }
    }
}
