using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;

    [SerializableAttribute()]
    public readonly partial struct BclListAsList<T>
        : IList<T, System.Collections.Generic.List<T>.Enumerator>, IReadOnlyList<T, System.Collections.Generic.List<T>.Enumerator> {

        private readonly System.Collections.Generic.List<T> m_value;

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public BclListAsList(System.Collections.Generic.List<T> value) {
            this.m_value = value;
        }

        public T this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value[index];

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this.m_value[index] = value;
        }

        public int Count {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value.Count;
        }

        public long LongCount {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.m_value.Count;
        }

        private static partial class Private {

            public static partial class TCollection {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                public static bool get_IsReadOnly<TCollection>(TCollection @this) where TCollection : ICollection<T> {
                    return @this.IsReadOnly;
                }
            }
        }

        public bool IsReadOnly {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => Private.TCollection.get_IsReadOnly(this.m_value);
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
        public bool Contains(T item) {
            return this.m_value.Contains(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
            throw new NotImplementedException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, int arrayIndex) {
            this.m_value.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.m_value.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return this.m_value.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public System.Collections.Generic.List<T>.Enumerator GetEnumerator() {
            return this.m_value.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item) {
            return this.m_value.IndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
            return this.m_value.FindIndex(new EqualityPredicate<T, TEqualityComparer>(comparer, item).Invoke);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(T item) where TEqualityComparer : struct, IEqualityComparer<T> {
            return this.IndexOf(default(TEqualityComparer), item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Insert(int index, T item) {
            this.m_value.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove(T item) {
            return this.m_value.Remove(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
            var index = this.IndexOf(comparer, item);
            if (0 <= index) {
                this.m_value.RemoveAt(index);
                return true;
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer>(T item) where TEqualityComparer : struct, IEqualityComparer<T> {
            return this.Remove(default(TEqualityComparer), item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void RemoveAt(int index) {
            this.m_value.RemoveAt(index);
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
