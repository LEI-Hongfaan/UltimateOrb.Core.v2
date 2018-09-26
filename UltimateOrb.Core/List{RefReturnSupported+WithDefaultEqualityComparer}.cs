using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.ConstrainedExecution;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic {
    using UltimateOrb;

    /// <summary>
    ///     <para>Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists. This type is a value type.</para>
    /// </summary>
    /// <typeparam name="T">
    ///     <para>The type of elements in the list.</para>
    /// </typeparam>
    [DebuggerDisplayAttribute("Count = {Count}")]
    [SerializableAttribute()]
    public partial struct ListWithDefaultEqualityComparer<T, TEqualityComparer>
        : System.Collections.Generic.IList<T>
        , System.Collections.Generic.IReadOnlyList<T>
        , IList<T, List<T>.Enumerator>
        , IReadOnlyList<T, List<T>.Enumerator>
        , ExtraTypeParametersProvided.IList<T, List<T>.Enumerator, TEqualityComparer>
        , ExtraTypeParametersProvided.IReadOnlyList<T, List<T>.Enumerator, TEqualityComparer>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T>, new() {

        private List<T> value;

        public ListWithDefaultEqualityComparer(List<T> value) {
            this.value = value;
        }

        public int Count {

            get => ((IList<T, List<T>.Enumerator>) this.value).Count;
        }

        public bool IsReadOnly {

            get => ((IList<T, List<T>.Enumerator>) this.value).IsReadOnly;
        }

        public long LongCount {

            get => ((IList<T, List<T>.Enumerator>) this.value).LongCount;
        }

        private TEqualityComparer comparer {

            get => DefaultConstructor.Invoke<TEqualityComparer>();
        }

        public ref T this[long index] {

            get => ref ((IList<T, List<T>.Enumerator>) this.value)[index];
        }

        public ref T this[int index] {

            get => ref ((IList<T, List<T>.Enumerator>) this.value)[index];
        }




        ref readonly T RefReturn_Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            get => ref ((IReadOnlyList<T, List<T>.Enumerator>) this.value)[index];
        }

        ref readonly T RefReturn.Collections.Generic.IReadOnlyList<T>.this[int index] {

            get => ref ((IReadOnlyList<T, List<T>.Enumerator>) this.value)[index];
        }

        T Huge.Collections.Generic.IList<T>.this[long index] {

            get => ((IList<T, List<T>.Enumerator>) this.value)[index];

            set => ((IList<T, List<T>.Enumerator>) this.value)[index] = value;
        }

        T System.Collections.Generic.IList<T>.this[int index] {

            get => ((IList<T, List<T>.Enumerator>) this.value)[index];

            set => ((IList<T, List<T>.Enumerator>) this.value)[index] = value;
        }

        T System.Collections.Generic.IReadOnlyList<T>.this[int index] {

            get => ((IReadOnlyList<T, List<T>.Enumerator>) this.value)[index];
        }
        T Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            get => ((IReadOnlyList<T, List<T>.Enumerator>) this.value)[index];
        }

        public ref T Add(T item) {
            return ref ((IList<T, List<T>.Enumerator>) this.value).Add(item);
        }

        void System.Collections.Generic.ICollection<T>.Add(T item) {
            ((IList<T, List<T>.Enumerator>) this.value).Add(item);
        }

        public void Clear() {
            ((IList<T, List<T>.Enumerator>) this.value).Clear();
        }

        bool Typed_Huge.Collections.Generic.ICollection<T, List<T>.Enumerator>.Contains<TEqualityComparer1>(T item, TEqualityComparer1 comparer) {
            return ((Typed_Huge.Collections.Generic.ICollection<T, List<T>.Enumerator>) this.value).Contains(item, comparer);
        }

        bool Typed.Collections.Generic.ICollection<T, List<T>.Enumerator>.Contains<TEqualityComparer1>(T item, TEqualityComparer1 comparer) {
            return ((Typed.Collections.Generic.ICollection<T, List<T>.Enumerator>) this.value).Contains<TEqualityComparer1>(item, comparer);
        }

        public bool Contains(T item) {
            return this.value.Contains(item, this.comparer);
        }

        bool Typed_RefReturn.Collections.Generic.IReadOnlyCollection<T, List<T>.Enumerator>.Contains<TEqualityComparer1>(T item, TEqualityComparer1 comparer) {
            return ((Typed_RefReturn.Collections.Generic.IReadOnlyCollection<T, List<T>.Enumerator>) this.value).Contains(item, comparer);
        }

        bool Typed_RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T, List<T>.Enumerator>.Contains<TEqualityComparer1>(T item, TEqualityComparer1 comparer) {
            return ((Typed_RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T, List<T>.Enumerator>) this.value).Contains(item, comparer);
        }

        public void CopyTo(Array<T> array, long arrayIndex) {
            ((IList<T, List<T>.Enumerator>) this.value).CopyTo(array, arrayIndex);
        }

        public void CopyTo(T[] array, long arrayIndex) {
            ((IList<T, List<T>.Enumerator>) this.value).CopyTo(array, arrayIndex);
        }

        public void CopyTo(Array<T> array, int arrayIndex) {
            ((IList<T, List<T>.Enumerator>) this.value).CopyTo(array, arrayIndex);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            ((IList<T, List<T>.Enumerator>) this.value).CopyTo(array, arrayIndex);
        }

        public List<T>.Enumerator GetEnumerator() {
            return this.value.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        List<T>.Enumerator Typed.Collections.Generic.IEnumerable<T, List<T>.Enumerator>.GetEnumerator() {
            return this.GetEnumerator();
        }

        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        RefReturn.Collections.Generic.IReadOnlyEnumerator<T> RefReturn.Collections.Generic.IReadOnlyEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        List<T>.Enumerator Typed.Collections.Generic.IReadOnlyEnumerable<T, List<T>.Enumerator>.GetEnumerator() {
            return this.GetEnumerator();
        }

        RefReturn.Collections.Generic.IEnumerator<T> RefReturn.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        int Typed.Collections.Generic.IList<T, List<T>.Enumerator>.IndexOf<TEqualityComparer1>(T item, TEqualityComparer1 comparer) {
            return ((Typed.Collections.Generic.IList<T, List<T>.Enumerator>) this.value).IndexOf(item, comparer);
        }

        public int IndexOf(T item) {
            return this.value.IndexOf(item, this.comparer);
        }

        int Typed_RefReturn.Collections.Generic.IReadOnlyList<T, List<T>.Enumerator>.IndexOf<TEqualityComparer1>(T item, TEqualityComparer1 comparer) {
            return ((IReadOnlyList<T, List<T>.Enumerator>) this.value).IndexOf(item, comparer);
        }

        public ref T Insert(long index, T item) {
            return ref ((IList<T, List<T>.Enumerator>) this.value).Insert(index, item);
        }

        public ref T Insert(int index, T item) {
            return ref ((IList<T, List<T>.Enumerator>) this.value).Insert(index, item);
        }

        void Huge.Collections.Generic.IList<T>.Insert(long index, T item) {
            ((IList<T, List<T>.Enumerator>) this.value).Insert(index, item);
        }

        void System.Collections.Generic.IList<T>.Insert(int index, T item) {
            ((IList<T, List<T>.Enumerator>) this.value).Insert(index, item);
        }

        long Typed_Huge.Collections.Generic.IList<T, List<T>.Enumerator>.LongIndexOf<TEqualityComparer1>(T item, TEqualityComparer1 comparer) {
            return ((Typed_Huge.Collections.Generic.IList<T, List<T>.Enumerator>) this.value).LongIndexOf(item, comparer);
        }

        public long LongIndexOf(T item) {
            return this.value.LongIndexOf(item, this.comparer);
        }

        long Typed_RefReturn_Huge.Collections.Generic.IReadOnlyList<T, List<T>.Enumerator>.LongIndexOf<TEqualityComparer1>(T item, TEqualityComparer1 comparer) {
            return ((IReadOnlyList<T, List<T>.Enumerator>) this.value).LongIndexOf(item, comparer);
        }

        bool Typed_Huge.Collections.Generic.ICollection<T, List<T>.Enumerator>.Remove<TEqualityComparer1>(T item, TEqualityComparer1 comparer) {
            return ((Typed_Huge.Collections.Generic.ICollection<T, List<T>.Enumerator>) this.value).Remove(item, comparer);
        }

        bool Typed.Collections.Generic.ICollection<T, List<T>.Enumerator>.Remove<TEqualityComparer1>(T item, TEqualityComparer1 comparer) {
            return ((Typed.Collections.Generic.ICollection<T, List<T>.Enumerator>) this.value).Remove<TEqualityComparer1>(item, comparer);
        }

        public bool Remove(T item) {
            return this.value.Remove(item, this.comparer);
        }

        public void RemoveAt(long index) {
            ((IList<T, List<T>.Enumerator>) this.value).RemoveAt(index);
        }

        public void RemoveAt(int index) {
            ((IList<T, List<T>.Enumerator>) this.value).RemoveAt(index);
        }
    }
}
