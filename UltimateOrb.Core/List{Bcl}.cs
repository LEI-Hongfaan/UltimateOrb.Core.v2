using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;
    
    public partial struct BclListAsIList<T>
        : IList<T, System.Collections.Generic.List<T>.Enumerator>, IReadOnlyList<T, System.Collections.Generic.List<T>.Enumerator> {

        private readonly System.Collections.Generic.List<T> value;

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public BclListAsIList(System.Collections.Generic.List<T> value) {
            this.value = value;
        }

        public T this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.value[index];

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this.value[index] = value;
        }

        public int Count {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.value.Count;
        }

        public long LongCount {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.value.Count;
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
            get => Private.TCollection.get_IsReadOnly(this.value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Add(T item) {
            this.value.Add(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Clear() {
            this.value.Clear();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item) {
            return this.value.Contains(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
            throw new NotImplementedException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, int arrayIndex) {
            this.value.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.value.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return this.value.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public System.Collections.Generic.List<T>.Enumerator GetEnumerator() {
            return this.value.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item) {
            return this.value.IndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
            return this.value.FindIndex(new EqualityPredicate<T, TEqualityComparer>(comparer, item).Invoke);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(T item) where TEqualityComparer : struct, IEqualityComparer<T> {
            return this.IndexOf(default(TEqualityComparer), item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Insert(int index, T item) {
            this.value.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove(T item) {
            return this.value.Remove(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
            var index = this.IndexOf(comparer, item);
            if (0 <= index) {
                this.value.RemoveAt(index);
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
            this.value.RemoveAt(index);
        }
    }

    [DiscardableAttribute()]
    public static partial class BclListModule {

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static BclListAsIList<T> AsIList<T>(this System.Collections.Generic.List<T> @this) {
            return new BclListAsIList<T>(@this);
        }
    }
}
