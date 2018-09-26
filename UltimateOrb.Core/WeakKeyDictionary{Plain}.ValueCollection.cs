using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace UltimateOrb.Plain.ValueTypes {
    using static ThrowHelper_Dictionary;

    public partial struct WeakKeyDictionary<TKey, TValue, TKeyEqualityComparer>
        where TKey : class
        where TKeyEqualityComparer : IEqualityComparer<TKey>, new() {

        /// <summary>Represents the collection of values in a <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}" />. This class cannot be inherited. </summary>
        [SerializableAttribute()]
        // [DebuggerTypeProxyAttribute(typeof(Mscorlib_DictionaryValueCollectionDebugView<,>))]
        [DebuggerDisplayAttribute(@"Count = {LongCount}")]
        public readonly partial struct ValueCollection
            : ICollection
            , Typed.Collections.Generic.ICollection<TValue, ValueCollection.Enumerator>
            , Typed.Collections.Generic.IReadOnlyCollection<TValue, ValueCollection.Enumerator> {

            private readonly WeakKeyDictionary<TKey, TValue, TKeyEqualityComparer> m_Dictionary;

            /// <summary>Gets the number of elements contained in the <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</summary>
            /// <returns>The number of elements contained in the <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</returns>
            public ValueCollection(WeakKeyDictionary<TKey, TValue, TKeyEqualityComparer> dictionary) {
                this.m_Dictionary = dictionary;
            }

            public int Count {

                get => this.m_Dictionary.Count;
            }

            bool ICollection<TValue>.IsReadOnly {

                get => true;
            }

            /// <summary>Gets a value indicating whether access to the <see cref="ICollection" /> is synchronized (thread safe).</summary>
            /// <returns>true if access to the <see cref="ICollection" /> is synchronized (thread safe); otherwise, false.  In the default implementation of <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />, this property always returns false.</returns>

            bool ICollection.IsSynchronized {

                get => false;
            }

            /// <summary>Gets an object that can be used to synchronize access to the <see cref="ICollection" />.</summary>
            /// <returns>An object that can be used to synchronize access to the <see cref="ICollection" />.  In the default implementation of <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />, this property always returns the current instance.</returns>

            public long LongCount {

                get => this.m_Dictionary.LongCount;
            }

            object ICollection.SyncRoot {

                get => null;
            }
            /// <summary>Initializes a new instance of the <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.ValueCollection" /> class that reflects the values in the specified <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}" />.</summary>
            /// <param name="dictionary">The <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}" /> whose values are reflected in the new <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</param>
            /// <exception cref="ArgumentNullException">
            ///   <paramref name="dictionary" /> is null.</exception>
            /// <summary>Returns an enumerator that iterates through the <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</summary>
            /// <returns>A <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.ValueCollection.Enumerator" /> for the <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</returns>

            void ICollection<TValue>.Add(TValue item) {
                ThrowNotSupportedException_ValueCollectionSet();
            }

            void ICollection<TValue>.Clear() {
                ThrowNotSupportedException_ValueCollectionSet();
            }

            bool ICollection<TValue>.Contains(TValue item) {
                return this.m_Dictionary.ContainsValue(item);
            }

            public bool Contains<TEqualityComparer>(TValue item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<TValue> {
                return this.m_Dictionary.ContainsValue(comparer, item);
            }

            public void CopyTo(TValue[] array, int index) {
                if (array == null) {
                    ThrowArgumentNullException_array();
                }
                if (index < 0 || index > array.Length) {
                    ThrowArgumentOutOfRangeException_index_NeedNonNegNum();
                }
                if (array.Length - index < this.m_Dictionary.Count) {
                    ThrowArgumentException_ArrayPlusOffTooSmall();
                }
                var count = this.m_Dictionary.m_EntryCount;
                var entries = this.m_Dictionary.m_EntryBuffer;
                for (var i = 0; count > i; ++i) {
                    ref var entry = ref entries[i];
                    if (0 <= entry.m_Flags) {
                        array[index++] = entry.m_Value;
                    }
                }
            }

            /// <summary>Copies the elements of the <see cref="ICollection" /> to an <see cref="Array" />, starting at a particular <see cref="Array" /> index.</summary>
            /// <param name="array">The one-dimensional <see cref="Array" /> that is the destination of the elements copied from <see cref="ICollection" />. The <see cref="Array" /> must have zero-based indexing.</param>
            /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
            /// <exception cref="ArgumentNullException">
            ///   <paramref name="array" /> is null.</exception>
            /// <exception cref="ArgumentOutOfRangeException">
            ///   <paramref name="index" /> is less than zero.</exception>
            /// <exception cref="ArgumentException">
            ///   <paramref name="array" /> is multidimensional.-or-<paramref name="array" /> does not have zero-based indexing.-or-The number of elements in the source <see cref="ICollection" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.-or-The type of the source <see cref="ICollection" /> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
            void ICollection.CopyTo(Array array, int index) {
                if (array == null) {
                    ThrowArgumentNullException_array();
                }
                if (array.Rank != 1) {
                    ThrowArgumentException_RankMultiDimNotSupported();
                }
                if (array.GetLowerBound(0) != 0) {
                    ThrowArgumentException_NonZeroLowerBound();
                }
                if (index < 0 || index > array.Length) {
                    ThrowArgumentOutOfRangeException_index_NeedNonNegNum();
                }
                if (array.Length - index < this.m_Dictionary.Count) {
                    ThrowArgumentException_ArrayPlusOffTooSmall();
                }
                if (array is TValue[] values) {
                    this.CopyTo(values, index);
                } else {
                    if (array is object[] objs) {
                        var count = this.m_Dictionary.m_EntryCount;
                        var entries = this.m_Dictionary.m_EntryBuffer;
                        try {
                            for (var i = 0; count > i; ++i) {
                                ref var entry = ref entries[i];
                                if (0 <= entry.m_Flags) {
                                    objs[index++] = entry.m_Value;
                                }
                            }
                        } catch (ArrayTypeMismatchException) {
                        }
                    }
                    ThrowArgumentException_InvalidArrayType();
                }
            }

            public void CopyTo(TValue[] array, long arrayIndex) {
                if (array == null) {
                    ThrowArgumentNullException_array();
                }
                var index = arrayIndex;
                if (index < 0 || index > array.Length) {
                    ThrowArgumentOutOfRangeException_index_NeedNonNegNum();
                }
                if (array.Length - index < this.m_Dictionary.Count) {
                    ThrowArgumentException_ArrayPlusOffTooSmall();
                }
                var count = this.m_Dictionary.m_EntryCount;
                var entries = this.m_Dictionary.m_EntryBuffer;
                for (var i = (long)0; count > i; ++i) {
                    ref var entry = ref entries[i];
                    if (0 <= entry.m_Flags) {
                        array[index++] = entry.m_Value;
                    }
                }
            }

            public void CopyTo(Array<TValue> array, int arrayIndex) {
                this.CopyTo(array.Value, arrayIndex);
            }

            public void CopyTo(Array<TValue> array, long arrayIndex) {
                this.CopyTo(array.Value, arrayIndex);
            }

            public Enumerator GetEnumerator() {
                return new Enumerator(this.m_Dictionary);
            }

            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() {
                return new Enumerator(this.m_Dictionary);
            }

            /// <summary>Returns an enumerator that iterates through a collection.</summary>
            /// <returns>An <see cref="IEnumerator" /> that can be used to iterate through the collection.</returns>
            IEnumerator IEnumerable.GetEnumerator() {
                return new Enumerator(this.m_Dictionary);
            }

            /// <summary>Copies the <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.ValueCollection" /> elements to an existing one-dimensional <see cref="Array" />, starting at the specified array index.</summary>
            /// <param name="array">The one-dimensional <see cref="Array" /> that is the destination of the elements copied from <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />. The <see cref="Array" /> must have zero-based indexing.</param>
            /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
            /// <exception cref="ArgumentNullException">
            ///   <paramref name="array" /> is null.</exception>
            /// <exception cref="ArgumentOutOfRangeException">
            ///   <paramref name="index" /> is less than zero.</exception>
            /// <exception cref="ArgumentException">The number of elements in the source <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.ValueCollection" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
            bool ICollection<TValue>.Remove(TValue item) {
                ThrowNotSupportedException_ValueCollectionSet();
                return default;
            }

            public bool Remove<TEqualityComparer>(TValue item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<TValue> {
                ThrowNotSupportedException_ValueCollectionSet();
                return default;
            }
        }
    }
}
