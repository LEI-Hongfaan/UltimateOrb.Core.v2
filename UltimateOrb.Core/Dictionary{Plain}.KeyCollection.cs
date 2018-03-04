using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace UltimateOrb.Plain.ValueTypes {
    using UltimateOrb.Collections.Generic;
    using static ThrowHelper_Dictionary;

    public partial struct Dictionary<TKey, TValue, TKeyEqualityComparer> where TKeyEqualityComparer : IEqualityComparer<TKey>, new() {

        /// <summary>Represents the collection of keys in a <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />. This class cannot be inherited.</summary>
        [SerializableAttribute()]
        // [DebuggerTypeProxyAttribute(typeof(Mscorlib_DictionaryKeyCollectionDebugView<,>))]
        [DebuggerDisplayAttribute(@"Count = {LongCount}")]
        public readonly partial struct KeyCollection : ICollection<TKey, KeyCollection.Enumerator>, ICollection, IReadOnlyCollection<TKey, KeyCollection.Enumerator> {

            private readonly Dictionary<TKey, TValue, TKeyEqualityComparer> m_Dictionary;

            /// <summary>Gets the number of elements contained in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.</summary>
            /// <returns>The number of elements contained in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.
            /// Retrieving the value of this property is an O(1) operation.</returns>

            public int Count {

                get => this.m_Dictionary.Count;
            }


            bool ICollection<TKey>.IsReadOnly {

                get => true;
            }

            /// <summary>Gets a value indicating whether access to the <see cref="ICollection" /> is synchronized (thread safe).</summary>
            /// <returns>true if access to the <see cref="ICollection" /> is synchronized (thread safe); otherwise, false.  In the default implementation of <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />, this property always returns false.</returns>
            bool ICollection.IsSynchronized {

                get => false;
            }

            /// <summary>Gets an object that can be used to synchronize access to the <see cref="ICollection" />.</summary>
            /// <returns>An object that can be used to synchronize access to the <see cref="ICollection" />.  In the default implementation of <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />, this property always returns the current instance.</returns>
            object ICollection.SyncRoot {

                get {
                    throw new NotSupportedException();
                }
            }

            public long LongCount  {

                get => this.m_Dictionary.LongCount;
            }

            /// <summary>Initializes a new instance of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" /> class that reflects the keys in the specified <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
            /// <param name="dictionary">The <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> whose keys are reflected in the new <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.</param>
            /// <exception cref="ArgumentNullException">
            ///   <paramref name="dictionary" /> is null.</exception>
            public KeyCollection(Dictionary<TKey, TValue, TKeyEqualityComparer> dictionary) {
                this.m_Dictionary = dictionary;
            }

            /// <summary>Returns an enumerator that iterates through the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.</summary>
            /// <returns>A <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection.Enumerator" /> for the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.</returns>
            public Enumerator GetEnumerator() {
                return new Enumerator(this.m_Dictionary);
            }

            /// <summary>Copies the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" /> elements to an existing one-dimensional <see cref="Array" />, starting at the specified array index.</summary>
            /// <param name="array">The one-dimensional <see cref="Array" /> that is the destination of the elements copied from <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />. The <see cref="Array" /> must have zero-based indexing.</param>
            /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
            /// <exception cref="ArgumentNullException">
            ///   <paramref name="array" /> is null. </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            ///   <paramref name="index" /> is less than zero.</exception>
            /// <exception cref="ArgumentException">The number of elements in the source <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>

            public void CopyTo(TKey[] array, int index) {
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
                        array[index++] = entry.m_Key;
                    }
                }
            }

            void ICollection<TKey>.Add(TKey item) {
                ThrowNotSupportedException_KeyCollectionSet();
            }

            void ICollection<TKey>.Clear() {
                ThrowNotSupportedException_KeyCollectionSet();
            }


            bool ICollection<TKey>.Contains(TKey item) {
                return this.m_Dictionary.ContainsKey(item);
            }


            bool ICollection<TKey>.Remove(TKey item) {
                ThrowNotSupportedException_KeyCollectionSet();
                return default;
            }

            IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() {
                return new Enumerator(this.m_Dictionary);
            }

            /// <summary>Returns an enumerator that iterates through a collection.</summary>
            /// <returns>An <see cref="IEnumerator" /> that can be used to iterate through the collection.</returns>
            IEnumerator IEnumerable.GetEnumerator() {
                return new Enumerator(this.m_Dictionary);
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
                if (array is TKey[] keys) {
                    this.CopyTo(keys, index);
                } else {
                    if (array is object[] objs) {
                        var count = this.m_Dictionary.m_EntryCount;
                        var entries = this.m_Dictionary.m_EntryBuffer;
                        try {
                            for (var i = 0; count > i; ++i) {
                                ref var entry = ref entries[i];
                                if (0 <= entry.m_Flags) {
                                    objs[index++] = entry.m_Key;
                                }
                            }
                        } catch (ArrayTypeMismatchException) {
                        }
                    }
                    ThrowArgumentException_InvalidArrayType();
                }
            }

            public bool Contains<TEqualityComparer>(TEqualityComparer comparer, TKey item) where TEqualityComparer : IEqualityComparer<TKey> {
                return this.m_Dictionary.ContainsKey(comparer, item);
            }

            public bool Remove<TEqualityComparer>(TEqualityComparer comparer, TKey item) where TEqualityComparer : IEqualityComparer<TKey> {
                ThrowNotSupportedException_KeyCollectionSet();
                return default;
            }
        }
    }
}
