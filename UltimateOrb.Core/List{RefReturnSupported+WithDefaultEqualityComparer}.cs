using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.ConstrainedExecution;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;

    using Internal.System.Collections.Generic;

    [DebuggerDisplayAttribute("Count = {Count}")]
    [SerializableAttribute()]
    public partial struct ListWithDefaultEqualityComparer<T, TEqualityComparer>
        : IList<T, List<T>.Enumerator>, ExtraTypeParametersProvided.IList<T, List<T>.Enumerator, TEqualityComparer>, IReadOnlyList<T, List<T>.Enumerator>
        where TEqualityComparer : struct, IEqualityComparer<T> {

        private List<T> value;

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ListWithDefaultEqualityComparer(List<T> value) {
            this.value = value;
        }

        public ref T this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return ref this.value[index];
            }
        }

        T IList<T>.this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => TList<T>.get_Item(this.value, index);

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => TList<T>.set_Item(this.value, index, value);
        }

        T IReadOnlyList<T>.this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => TReadOnlyList<T>.get_Item(this.value, index);
        }

        public int Count {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.value.Count;
        }

        public bool IsReadOnly {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.value.IsReadOnly;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void ICollection<T>.Add(T item) {
            this.value.Add(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref T Add(T item) {
            return ref this.value.Add(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Clear() {
            this.value.Clear();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
#pragma warning disable 693
        public bool Contains<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
#pragma warning restore 693
            return this.value.Contains(comparer, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item) {
            return this.value.Contains(default(TEqualityComparer), item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, int arrayIndex) {
            this.value.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List<T>.Enumerator GetEnumerator() {
            return this.value.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
#pragma warning disable 693
        public int IndexOf<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
#pragma warning restore 693
            return this.value.IndexOf(comparer, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item) {
            return this.value.IndexOf(default(TEqualityComparer), item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void IList<T>.Insert(int index, T item) {
            TList<T>.Insert(ref this.value, index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref T Insert(int index, T item) {
            return ref this.value.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer1>(TEqualityComparer1 comparer, T item) where TEqualityComparer1 : IEqualityComparer<T> {
            return this.value.Remove(comparer, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove(T item) {
            return this.value.Remove(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void RemoveAt(int index) {
            this.value.RemoveAt(index);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.Generic.IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return this.value.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        IEnumerator IEnumerable.GetEnumerator() {
            return this.value.GetEnumerator();
        }
    }
}
