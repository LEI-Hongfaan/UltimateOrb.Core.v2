using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace UltimateOrb.Plain.ValueTypes {
    using UltimateOrb.Collections.Generic;
    using static ThrowHelper_Dictionary;

    public partial struct Dictionary<TKey, TValue, TKeyEqualityComparer> where TKeyEqualityComparer : IEqualityComparer<TKey>, new() {

        /// <summary>Represents the collection of values in a <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />. This class cannot be inherited. </summary>
        [SerializableAttribute()]
        // [DebuggerTypeProxyAttribute(typeof(Mscorlib_DictionaryValueCollectionDebugView<,>))]
        [DebuggerDisplayAttribute(@"Count = {LongCount}")]
        public readonly partial struct ValueCollection : ICollection<TValue, ValueCollection.Enumerator>, ICollection, IReadOnlyCollection<TValue, ValueCollection.Enumerator> {

            private readonly Dictionary<TKey, TValue, TKeyEqualityComparer> dictionary;

            /// <summary>Gets the number of elements contained in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</summary>
            /// <returns>The number of elements contained in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</returns>

            public int Count {

                get {
                    return this.dictionary.Count;
                }
            }


            bool ICollection<TValue>.IsReadOnly {

                get {
                    return true;
                }
            }

            /// <summary>Gets a value indicating whether access to the <see cref="ICollection" /> is synchronized (thread safe).</summary>
            /// <returns>true if access to the <see cref="ICollection" /> is synchronized (thread safe); otherwise, false.  In the default implementation of <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />, this property always returns false.</returns>

            bool ICollection.IsSynchronized {

                get {
                    return false;
                }
            }

            /// <summary>Gets an object that can be used to synchronize access to the <see cref="ICollection" />.</summary>
            /// <returns>An object that can be used to synchronize access to the <see cref="ICollection" />.  In the default implementation of <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />, this property always returns the current instance.</returns>

            object ICollection.SyncRoot {

                get {
                    return ((ICollection)this.dictionary).SyncRoot;
                }
            }

            public long LongCount => throw new NotImplementedException();

            /// <summary>Initializes a new instance of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" /> class that reflects the values in the specified <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
            /// <param name="dictionary">The <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> whose values are reflected in the new <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</param>
            /// <exception cref="ArgumentNullException">
            ///   <paramref name="dictionary" /> is null.</exception>

            public ValueCollection(Dictionary<TKey, TValue, TKeyEqualityComparer> dictionary) {
                this.dictionary = dictionary;
            }

            /// <summary>Returns an enumerator that iterates through the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</summary>
            /// <returns>A <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection.Enumerator" /> for the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</returns>

            public Enumerator GetEnumerator() {
                return new Enumerator(this.dictionary);
            }

            /// <summary>Copies the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" /> elements to an existing one-dimensional <see cref="Array" />, starting at the specified array index.</summary>
            /// <param name="array">The one-dimensional <see cref="Array" /> that is the destination of the elements copied from <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />. The <see cref="Array" /> must have zero-based indexing.</param>
            /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
            /// <exception cref="ArgumentNullException">
            ///   <paramref name="array" /> is null.</exception>
            /// <exception cref="ArgumentOutOfRangeException">
            ///   <paramref name="index" /> is less than zero.</exception>
            /// <exception cref="ArgumentException">The number of elements in the source <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>

            public void CopyTo(TValue[] array, int index) {
                if (array == null) {
                    ThrowArgumentNullException_array();
                }
                if (index < 0 || index > array.Length) {
                    ThrowArgumentOutOfRangeException_index_NeedNonNegNum();
                }
                if (array.Length - index < this.dictionary.Count) {
                    ThrowArgumentException_ArrayPlusOffTooSmall();
                }
                var count = this.dictionary.m_EntryCount;
                var entries = this.dictionary.m_EntryBuffer;
                for (var i = 0; count > i; ++i) {
                    if (0 <= entries[i].m_Flags) {
                        array[index++] = entries[i].m_Value;
                    }
                }
            }


            void ICollection<TValue>.Add(TValue item) {
                // ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ValueCollectionSet);
            }


            bool ICollection<TValue>.Remove(TValue item) {
                // ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ValueCollectionSet);
                return default;
            }


            void ICollection<TValue>.Clear() {
                // ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ValueCollectionSet);
            }


            bool ICollection<TValue>.Contains(TValue item) {
                return this.dictionary.ContainsValue(item);
            }


            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() {
                return (IEnumerator<TValue>)(object)new Enumerator(this.dictionary);
            }

            /// <summary>Returns an enumerator that iterates through a collection.</summary>
            /// <returns>An <see cref="IEnumerator" /> that can be used to iterate through the collection.</returns>

            IEnumerator IEnumerable.GetEnumerator() {
                return (IEnumerator)(object)new Enumerator(this.dictionary);
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
                if (array.Length - index < this.dictionary.Count) {
                    ThrowArgumentException_ArrayPlusOffTooSmall();
                }
                if (array is TValue[] array2) {
                    this.CopyTo(array2, index);
                } else {
                    object[] array3 = array as object[];
                    if (array3 == null) {
                        // ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
                    }
                    int count = this.dictionary.m_EntryCount;
                    Entry[] entries = this.dictionary.m_EntryBuffer;
                    try {
                        for (int i = 0; i < count; i++) {
                            if (entries[i].m_Flags >= 0) {
                                array3[index++] = entries[i].m_Value;
                            }
                        }
                    } catch (ArrayTypeMismatchException) {
                        // ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
                    }
                }
            }

            public bool Contains<TEqualityComparer>(TEqualityComparer comparer, TValue item) where TEqualityComparer : IEqualityComparer<TValue> {
                throw new NotImplementedException();
            }

            public bool Remove<TEqualityComparer>(TEqualityComparer comparer, TValue item) where TEqualityComparer : IEqualityComparer<TValue> {
                throw new NotImplementedException();
            }
        }
    }
}
