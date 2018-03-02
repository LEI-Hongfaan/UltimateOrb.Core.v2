using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace UltimateOrb.Plain.ValueTypes {

    /// <summary>Represents a collection of keys and values.</summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    [SerializableAttribute()]
    [DebuggerDisplayAttribute("Count = {Count}")]
    [ComVisibleAttribute(false)]
    public partial struct Dictionary<TKey, TValue, TEqualityComparer> :
        IDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue>,
        ISerializable, IDeserializationCallback
        where TEqualityComparer : IEqualityComparer<TKey>, new() {

        private struct Entry {

            public int hashCode;

            public int next;

            public int bucket;

            public int flags;

            public TKey key;

            public TValue value;
        }

        /// <summary>Enumerates the elements of a <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
        [SerializableAttribute()]
        public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>> {

            private Dictionary<TKey, TValue, TEqualityComparer> dictionary;

            private int index;

            private KeyValuePair<TKey, TValue> current;

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> at the current position of the enumerator.</returns>
            public KeyValuePair<TKey, TValue> Current {

                get {
                    return this.current;
                }
            }

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the collection at the current position of the enumerator, as an <see cref="object" />.</returns>
            /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>

            object IEnumerator.Current {

                get {
                    if (this.index == 0 || this.index == this.dictionary.count + 1) {
                        // ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
                    }
                    return current;
                }
            }

            internal Enumerator(Dictionary<TKey, TValue, TEqualityComparer> dictionary) {
                this.dictionary = dictionary;
                this.index = 0;
                this.current = default(KeyValuePair<TKey, TValue>);
            }

            /// <summary>Advances the enumerator to the next element of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
            /// <exception cref="InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            public bool MoveNext() {
                var entries = this.dictionary.entries;
                var index = this.index;
                var count = this.dictionary.count;
                while ((uint)index < (uint)count) {
                    ref var entry = ref entries[index];
                    if (0 <= entry.flags) {
                        this.current = new KeyValuePair<TKey, TValue>(entry.key, entry.value);
                        ++index;
                        this.index = index;
                        return true;
                    }
                    ++index;
                }
                this.index = count + 1;
                this.current = default; // Good for GC.
                return false;
            }

            /// <summary>Releases all resources used by the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.Enumerator" />.</summary>
            public void Dispose() {
            }

            /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
            /// <exception cref="InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            void IEnumerator.Reset() {
                this.index = 0;
                this.current = default;
            }
        }

        /// <summary>Enumerates the elements of a <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
        [SerializableAttribute()]
        public struct Enumerator_A : IEnumerator<KeyValuePair<TKey, TValue>>, IDictionaryEnumerator {

            private Dictionary<TKey, TValue, TEqualityComparer> dictionary;

            private int index;

            private KeyValuePair<TKey, TValue> current;

            private int getEnumeratorRetType;

            // DictEntry = 1;

            // KeyValuePair = 2;

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> at the current position of the enumerator.</returns>

            public KeyValuePair<TKey, TValue> Current {

                get {
                    return this.current;
                }
            }

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the collection at the current position of the enumerator, as an <see cref="object" />.</returns>
            /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>

            object IEnumerator.Current {

                get {
                    if (this.index == 0 || this.index == this.dictionary.count + 1) {
                        // ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
                    }
                    if (this.getEnumeratorRetType == 1) {
                        return new DictionaryEntry(this.current.Key, this.current.Value);
                    }
                    return new KeyValuePair<TKey, TValue>(this.current.Key, this.current.Value);
                }
            }

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the dictionary at the current position of the enumerator, as a <see cref="DictionaryEntry" />.</returns>
            /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>

            DictionaryEntry IDictionaryEnumerator.Entry {

                get {
                    if (this.index == 0 || this.index == this.dictionary.count + 1) {
                        // ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
                    }
                    return new DictionaryEntry(this.current.Key, this.current.Value);
                }
            }

            /// <summary>Gets the key of the element at the current position of the enumerator.</summary>
            /// <returns>The key of the element in the dictionary at the current position of the enumerator.</returns>
            /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>

            object IDictionaryEnumerator.Key {

                get {
                    if (this.index == 0 || this.index == this.dictionary.count + 1) {
                        // ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
                    }
                    return this.current.Key;
                }
            }

            /// <summary>Gets the value of the element at the current position of the enumerator.</summary>
            /// <returns>The value of the element in the dictionary at the current position of the enumerator.</returns>
            /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>

            object IDictionaryEnumerator.Value {

                get {
                    if (this.index == 0 || this.index == this.dictionary.count + 1) {
                        // ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
                    }
                    return this.current.Value;
                }
            }

            internal Enumerator_A(Dictionary<TKey, TValue, TEqualityComparer> dictionary, int getEnumeratorRetType) {
                this.dictionary = dictionary;
                this.index = 0;
                this.getEnumeratorRetType = getEnumeratorRetType;
                this.current = default;
            }

            /// <summary>Advances the enumerator to the next element of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
            /// <exception cref="InvalidOperationException">The collection was modified after the enumerator was created. </exception>

            public bool MoveNext() {
                while ((uint)this.index < (uint)this.dictionary.count) {
                    if (this.dictionary.entries[this.index].flags >= 0) {
                        this.current = new KeyValuePair<TKey, TValue>(this.dictionary.entries[this.index].key, this.dictionary.entries[this.index].value);
                        ++this.index;
                        return true;
                    }
                    ++this.index;
                }
                this.index = this.dictionary.count + 1;
                this.current = default;
                return false;
            }

            /// <summary>Releases all resources used by the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.Enumerator" />.</summary>

            public void Dispose() {
            }

            /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
            /// <exception cref="InvalidOperationException">The collection was modified after the enumerator was created. </exception>

            void IEnumerator.Reset() {
                this.index = 0;
                this.current = default;
            }
        }

        /// <summary>Represents the collection of keys in a <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />. This class cannot be inherited.</summary>
        [SerializableAttribute()]
        // [DebuggerTypeProxyAttribute(typeof(Mscorlib_DictionaryKeyCollectionDebugView<,>))]
        [DebuggerDisplayAttribute("Count = {Count}")]

        public sealed class KeyCollection : ICollection<TKey>, ICollection, IReadOnlyCollection<TKey> {

            /// <summary>Enumerates the elements of a <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.</summary>
            [SerializableAttribute()]
            public struct Enumerator : IEnumerator<TKey>, IDisposable, IEnumerator {

                private Dictionary<TKey, TValue, TEqualityComparer> dictionary;

                private int index;

                private TKey currentKey;

                /// <summary>Gets the element at the current position of the enumerator.</summary>
                /// <returns>The element in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" /> at the current position of the enumerator.</returns>
                public TKey Current {

                    get {
                        return this.currentKey;
                    }
                }

                /// <summary>Gets the element at the current position of the enumerator.</summary>
                /// <returns>The element in the collection at the current position of the enumerator.</returns>
                /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>
                object IEnumerator.Current {

                    get {
                        if (this.index == 0 || this.index == this.dictionary.count + 1) {
                            // ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
                        }
                        return this.currentKey;
                    }
                }

                internal Enumerator(Dictionary<TKey, TValue, TEqualityComparer> dictionary) {
                    this.dictionary = dictionary;
                    this.index = 0;
                    this.currentKey = default;
                }

                /// <summary>Releases all resources used by the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection.Enumerator" />.</summary>

                public void Dispose() {
                }

                /// <summary>Advances the enumerator to the next element of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.</summary>
                /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
                /// <exception cref="InvalidOperationException">The collection was modified after the enumerator was created. </exception>

                public bool MoveNext() {
                    while ((uint)this.index < (uint)this.dictionary.count) {
                        if (this.dictionary.entries[this.index].flags >= 0) {
                            this.currentKey = this.dictionary.entries[this.index].key;
                            this.index++;
                            return true;
                        }
                        this.index++;
                    }
                    this.index = this.dictionary.count + 1;
                    this.currentKey = default(TKey);
                    return false;
                }

                /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
                /// <exception cref="InvalidOperationException">The collection was modified after the enumerator was created. </exception>

                void IEnumerator.Reset() {
                    this.index = 0;
                    this.currentKey = default;
                }
            }

            private Dictionary<TKey, TValue, TEqualityComparer> dictionary;

            /// <summary>Gets the number of elements contained in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.</summary>
            /// <returns>The number of elements contained in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.
            /// Retrieving the value of this property is an O(1) operation.</returns>

            public int Count {

                get {
                    return this.dictionary.Count;
                }
            }


            bool ICollection<TKey>.IsReadOnly {

                get {
                    return true;
                }
            }

            /// <summary>Gets a value indicating whether access to the <see cref="ICollection" /> is synchronized (thread safe).</summary>
            /// <returns>true if access to the <see cref="ICollection" /> is synchronized (thread safe); otherwise, false.  In the default implementation of <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />, this property always returns false.</returns>

            bool ICollection.IsSynchronized {

                get {
                    return false;
                }
            }

            /// <summary>Gets an object that can be used to synchronize access to the <see cref="ICollection" />.</summary>
            /// <returns>An object that can be used to synchronize access to the <see cref="ICollection" />.  In the default implementation of <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />, this property always returns the current instance.</returns>

            object ICollection.SyncRoot {

                get {
                    return ((ICollection)this.dictionary).SyncRoot;
                }
            }

            /// <summary>Initializes a new instance of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" /> class that reflects the keys in the specified <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
            /// <param name="dictionary">The <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> whose keys are reflected in the new <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.</param>
            /// <exception cref="ArgumentNullException">
            ///   <paramref name="dictionary" /> is null.</exception>

            public KeyCollection(Dictionary<TKey, TValue, TEqualityComparer> dictionary) {
                this.dictionary = dictionary;
            }

            /// <summary>Returns an enumerator that iterates through the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.</summary>
            /// <returns>A <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection.Enumerator" /> for the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.</returns>

            public Enumerator GetEnumerator() {
                return new Enumerator(this.dictionary);
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
                    // ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
                }
                if (index < 0 || index > array.Length) {
                    // ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
                }
                if (array.Length - index < this.dictionary.Count) {
                    // ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
                }
                int count = this.dictionary.count;
                Entry[] entries = this.dictionary.entries;
                for (int i = 0; i < count; i++) {
                    if (entries[i].flags >= 0) {
                        array[index++] = entries[i].key;
                    }
                }
            }


            void ICollection<TKey>.Add(TKey item) {
                // ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_KeyCollectionSet);
            }


            void ICollection<TKey>.Clear() {
                // ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_KeyCollectionSet);
            }


            bool ICollection<TKey>.Contains(TKey item) {
                return this.dictionary.ContainsKey(item);
            }


            bool ICollection<TKey>.Remove(TKey item) {
                // ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_KeyCollectionSet);
                return false;
            }


            IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() {
                return (IEnumerator<TKey>)(object)new Enumerator(this.dictionary);
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
                    // ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
                }
                if (array.Rank != 1) {
                    // ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
                }
                if (array.GetLowerBound(0) != 0) {
                    // ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound);
                }
                if (index < 0 || index > array.Length) {
                    // ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
                }
                if (array.Length - index < this.dictionary.Count) {
                    // ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
                }
                TKey[] array2 = array as TKey[];
                if (array2 != null) {
                    this.CopyTo(array2, index);
                } else {
                    object[] array3 = array as object[];
                    if (array3 == null) {
                        // ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
                    }
                    int count = this.dictionary.count;
                    Entry[] entries = this.dictionary.entries;
                    try {
                        for (int i = 0; i < count; i++) {
                            if (entries[i].flags >= 0) {
                                array3[index++] = entries[i].key;
                            }
                        }
                    } catch (ArrayTypeMismatchException) {
                        // ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
                    }
                }
            }
        }

        /// <summary>Represents the collection of values in a <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />. This class cannot be inherited. </summary>
        [SerializableAttribute()]
        // [DebuggerTypeProxyAttribute(typeof(Mscorlib_DictionaryValueCollectionDebugView<,>))]
        [DebuggerDisplayAttribute("Count = {Count}")]

        public partial struct ValueCollection : ICollection<TValue>, ICollection, IReadOnlyCollection<TValue> {

            /// <summary>Enumerates the elements of a <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</summary>
            [SerializableAttribute()]
            public struct Enumerator : IEnumerator<TValue>, IDisposable, IEnumerator {

                private readonly Dictionary<TKey, TValue, TEqualityComparer> dictionary;

                private int index;

                private TValue currentValue;

                /// <summary>Gets the element at the current position of the enumerator.</summary>
                /// <returns>The element in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" /> at the current position of the enumerator.</returns>

                public TValue Current {

                    get {
                        return this.currentValue;
                    }
                }

                /// <summary>Gets the element at the current position of the enumerator.</summary>
                /// <returns>The element in the collection at the current position of the enumerator.</returns>
                /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>

                object IEnumerator.Current {

                    get {
                        if (this.index == 0 || this.index == this.dictionary.count + 1) {
                            // ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
                        }
                        return this.currentValue;
                    }
                }

                internal Enumerator(Dictionary<TKey, TValue, TEqualityComparer> dictionary) {
                    this.dictionary = dictionary;
                    this.index = 0;
                    this.currentValue = default;
                }

                /// <summary>Releases all resources used by the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection.Enumerator" />.</summary>

                public void Dispose() {
                }

                /// <summary>Advances the enumerator to the next element of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</summary>
                /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
                /// <exception cref="InvalidOperationException">The collection was modified after the enumerator was created. </exception>

                public bool MoveNext() {
                    while ((uint)this.index < (uint)this.dictionary.count) {
                        if (this.dictionary.entries[this.index].flags >= 0) {
                            this.currentValue = this.dictionary.entries[this.index].value;
                            this.index++;
                            return true;
                        }
                        this.index++;
                    }
                    this.index = this.dictionary.count + 1;
                    this.currentValue = default(TValue);
                    return false;
                }

                /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
                /// <exception cref="InvalidOperationException">The collection was modified after the enumerator was created. </exception>

                void IEnumerator.Reset() {
                    this.index = 0;
                    this.currentValue = default(TValue);
                }
            }

            private Dictionary<TKey, TValue, TEqualityComparer> dictionary;

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

            /// <summary>Initializes a new instance of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" /> class that reflects the values in the specified <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
            /// <param name="dictionary">The <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> whose values are reflected in the new <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</param>
            /// <exception cref="ArgumentNullException">
            ///   <paramref name="dictionary" /> is null.</exception>

            public ValueCollection(Dictionary<TKey, TValue, TEqualityComparer> dictionary) {
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
                    // ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
                }
                if (index < 0 || index > array.Length) {
                    // ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
                }
                if (array.Length - index < this.dictionary.Count) {
                    // ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
                }
                int count = this.dictionary.count;
                Entry[] entries = this.dictionary.entries;
                for (int i = 0; i < count; i++) {
                    if (entries[i].flags >= 0) {
                        array[index++] = entries[i].value;
                    }
                }
            }


            void ICollection<TValue>.Add(TValue item) {
                // ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ValueCollectionSet);
            }


            bool ICollection<TValue>.Remove(TValue item) {
                // ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ValueCollectionSet);
                return false;
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
                    // ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
                }
                if (array.Rank != 1) {
                    // ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
                }
                if (array.GetLowerBound(0) != 0) {
                    // ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound);
                }
                if (index < 0 || index > array.Length) {
                    // ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
                }
                if (array.Length - index < this.dictionary.Count) {
                    // ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
                }
                TValue[] array2 = array as TValue[];
                if (array2 != null) {
                    this.CopyTo(array2, index);
                } else {
                    object[] array3 = array as object[];
                    if (array3 == null) {
                        // ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
                    }
                    int count = this.dictionary.count;
                    Entry[] entries = this.dictionary.entries;
                    try {
                        for (int i = 0; i < count; i++) {
                            if (entries[i].flags >= 0) {
                                array3[index++] = entries[i].value;
                            }
                        }
                    } catch (ArrayTypeMismatchException) {
                        // ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
                    }
                }
            }
        }

        private Entry[] entries;

        private int count;

        private int freeList;

        private int freeCount;

        private const string HashSizeName = "HashSize";

        private const string KeyValuePairsName = "KeyValuePairs";

        /// <summary>Gets the <see cref="IEqualityComparer`1" /> that is used to determine equality of keys for the dictionary. </summary>
        /// <returns>The <see cref="IEqualityComparer`1" /> generic interface implementation that is used to determine equality of keys for the current <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> and to provide hash values for the keys.</returns>

        public TEqualityComparer Comparer {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return DefaultConstructor.Invoke<TEqualityComparer>();
            }
        }

        /// <summary>Gets the number of key/value pairs contained in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
        /// <returns>The number of key/value pairs contained in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</returns>
        public int Count {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return unchecked(this.count - this.freeCount);
            }
        }

        /// <summary>Gets a collection containing the keys in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
        /// <returns>A <see cref="Dictionary{TKey,TValue,TEqualityComparer}.KeyCollection" /> containing the keys in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</returns>

        public KeyCollection Keys {

            get {
                return new KeyCollection(this);
            }
        }


        ICollection<TKey> IDictionary<TKey, TValue>.Keys {

            get {
                return new KeyCollection(this);
            }
        }


        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys {

            get {
                return new KeyCollection(this);
            }
        }

        /// <summary>Gets a collection containing the values in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
        /// <returns>A <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" /> containing the values in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</returns>

        public ValueCollection Values {

            get {
                return new ValueCollection(this);
            }
        }


        ICollection<TValue> IDictionary<TKey, TValue>.Values {

            get {
                return new ValueCollection(this);
            }
        }


        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values {

            get {
                return new ValueCollection(this);
            }
        }

        /// <summary>Gets or sets the value associated with the specified key.</summary>
        /// <returns>The value associated with the specified key. If the specified key is not found, a get operation throws a <see cref="KeyNotFoundException" />, and a set operation creates a new element with the specified key.</returns>
        /// <param name="key">The key of the value to get or set.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="key" /> is null.</exception>
        /// <exception cref="KeyNotFoundException">The property is retrieved and <paramref name="key" /> does not exist in the collection.</exception>

        public TValue this[TKey key] {

            get {
                ref var entry = ref this.FindEntry(key, out var found);
                if (found) {
                    return entry.value;
                }
                // ThrowHelper.ThrowKeyNotFoundException();
                return default;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set {
                this.Insert(key, value, false);
            }
        }


        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly {

            get {
                return false;
            }
        }

        /// <summary>Gets a value indicating whether access to the <see cref="ICollection" /> is synchronized (thread safe).</summary>
        /// <returns>true if access to the <see cref="ICollection" /> is synchronized (thread safe); otherwise, false.  In the default implementation of <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />, this property always returns false.</returns>

        bool ICollection.IsSynchronized {

            get {
                return false;
            }
        }

        /// <summary>Gets an object that can be used to synchronize access to the <see cref="ICollection" />.</summary>
        /// <returns>An object that can be used to synchronize access to the <see cref="ICollection" />. </returns>

        object ICollection.SyncRoot {

            get {
                // TODO: ???
                return this;
            }
        }

        /// <summary>Gets a value indicating whether the <see cref="IDictionary" /> has a fixed size.</summary>
        /// <returns>true if the <see cref="IDictionary" /> has a fixed size; otherwise, false.  In the default implementation of <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />, this property always returns false.</returns>

        bool IDictionary.IsFixedSize {

            get {
                return false;
            }
        }

        /// <summary>Gets a value indicating whether the <see cref="IDictionary" /> is read-only.</summary>
        /// <returns>true if the <see cref="IDictionary" /> is read-only; otherwise, false.  In the default implementation of <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />, this property always returns false.</returns>

        bool IDictionary.IsReadOnly {

            get {
                return false;
            }
        }

        /// <summary>Gets an <see cref="ICollection" /> containing the keys of the <see cref="IDictionary" />.</summary>
        /// <returns>An <see cref="ICollection" /> containing the keys of the <see cref="IDictionary" />.</returns>

        ICollection IDictionary.Keys {

            get {
                return this.Keys;
            }
        }

        /// <summary>Gets an <see cref="ICollection" /> containing the values in the <see cref="IDictionary" />.</summary>
        /// <returns>An <see cref="ICollection" /> containing the values in the <see cref="IDictionary" />.</returns>
        ICollection IDictionary.Values {

            get {
                return this.Values;
            }
        }

        /// <summary>Gets or sets the value with the specified key.</summary>
        /// <returns>The value associated with the specified key, or null if <paramref name="key" /> is not in the dictionary or <paramref name="key" /> is of a type that is not assignable to the key type <paramref name="TKey" /> of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</returns>
        /// <param name="key">The key of the value to get.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="key" /> is null.</exception>
        /// <exception cref="ArgumentException">A value is being assigned, and <paramref name="key" /> is of a type that is not assignable to the key type <paramref name="TKey" /> of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.-or-A value is being assigned, and <paramref name="value" /> is of a type that is not assignable to the value type <paramref name="TValue" /> of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</exception>
        object IDictionary.this[object key] {

            get {
                if (key is TKey key0) {
                    ref var num = ref this.FindEntry(key0, out var found);
                    if (found) {
                        return num.value;
                    }
                }
                return null;
            }

            set {
                // if (key == null) {
                //     // ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
                // }
                // ThrowHelper.IfNullAndNullsAreIllegalThenThrow<TValue>(value, ExceptionArgument.value);
                try {
                    TKey key0 = (TKey)key;
                    try {
                        this[key0] = (TValue)value;
                    } catch (InvalidCastException) {
                        // ThrowHelper.ThrowWrongValueTypeArgumentException(value, typeof(TValue));
                    }
                } catch (InvalidCastException) {
                    // ThrowHelper.ThrowWrongKeyTypeArgumentException(key, typeof(TKey));
                }
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> class that is empty, has the default initial capacity, and uses the specified <see cref="IEqualityComparer`1" />.</summary>
        /// <param name="comparer">The <see cref="IEqualityComparer`1" /> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer`1" /> for the type of the key.</param>
        public static Dictionary<TKey, TValue, TEqualityComparer> Create() {
            return new Dictionary<TKey, TValue, TEqualityComparer>(0);
        }

        /// <summary>Initializes a new instance of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> class that is empty, has the specified initial capacity, and uses the specified <see cref="IEqualityComparer`1" />.</summary>
        /// <param name="minCapacity">The initial number of elements that the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> can contain.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer`1" /> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer`1" /> for the type of the key.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="minCapacity" /> is less than 0.</exception>
        public Dictionary(int minCapacity) {
            if (0 <= minCapacity) {
                this = default;
                if (minCapacity > 0) {
                    this.Initialize(minCapacity);
                    return;
                }
                this.entries = Array_Empty<Entry>.Value;
                return;
            }
            // ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity);
            this = default;
        }

        /// <summary>Initializes a new instance of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> class that contains elements copied from the specified <see cref="IDictionary{TKey,TValue,TEqualityComparer}" /> and uses the specified <see cref="IEqualityComparer`1" />.</summary>
        /// <param name="dictionary">The <see cref="IDictionary{TKey,TValue,TEqualityComparer}" /> whose elements are copied to the new <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer`1" /> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer`1" /> for the type of the key.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="dictionary" /> is null.</exception>
        /// <exception cref="ArgumentException">
        ///   <paramref name="dictionary" /> contains one or more duplicate keys.</exception>
        public Dictionary(IDictionary<TKey, TValue> dictionary)
            : this((dictionary != null) ? dictionary.Count : 0) {
            if (dictionary == null) {
                // ThrowHelper.ThrowArgumentNullException(ExceptionArgument.dictionary);
            }
            foreach (KeyValuePair<TKey, TValue> item in dictionary) {
                this.Add(item.Key, item.Value);
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> class with serialized data.</summary>
        /// <param name="info">A <see cref="SerializationInfo" /> object containing the information required to serialize the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</param>
        /// <param name="context">A <see cref="StreamingContext" /> structure containing the source and destination of the serialized stream associated with the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</param>
        private Dictionary(SerializationInfo info, StreamingContext context) {
            // Create a new object as a key to the SerializationInfo.
            var key_SerializationInfo = new Entry[0];
            this = default;
            this.entries = key_SerializationInfo;
            HashHelper.SerializationInfoTable.Add(key_SerializationInfo, info);
        }

        /// <summary>Adds the specified key and value to the dictionary.</summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null for reference types.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="key" /> is null.</exception>
        /// <exception cref="ArgumentException">An element with the same key already exists in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</exception>
        public void Add(TKey key, TValue value) {
            this.Insert(key, value, true);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair) {
            this.Add(keyValuePair.Key, keyValuePair.Value);
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair) {
            ref var entry = ref this.FindEntry(keyValuePair.Key, out var found);
            if (found && EqualityComparer<TValue>.Default.Equals(entry.value, keyValuePair.Value)) {
                return true;
            }
            return false;
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair) {
            var entries = this.entries;
            var length = entries.Length; // null check;
            if (length > 0) {
                var comparer = DefaultConstructor.Invoke<TEqualityComparer>();
                var key = keyValuePair.Key;
                var hashCode = comparer.GetHashCode(key);
                var index_prev = unchecked((int)((uint)hashCode % (uint)length));
                var index_tmp = -1;
                var value = keyValuePair.Value;
                var valueComparer = EqualityComparer<TValue>.Default;
                for (var index = entries[index_prev].bucket; 0 <= index;) {
                    ref var entry = ref entries[index];
                    if (entry.hashCode == hashCode && comparer.Equals(entry.key, key) && (null == value ? null == entry.value : valueComparer.Equals(entry.value, value))) {
                        if (index_tmp < 0) {
                            entries[index_prev].bucket = entry.next;
                        } else {
                            entries[index_tmp].next = entry.next;
                        }
                        entry.flags |= int.MinValue; // This entry is not used. 
                        entry.next = this.freeList;
                        entry.key = default; // Good for GC.
                        entry.value = default; // Good for GC.
                        this.freeList = index;
                        ++this.freeCount;
                        return true;
                    }
                    index_tmp = index;
                    index = entry.next;
                }
                goto L_NotFound;
            }
            if (Array_Empty<Entry>.Value != entries) {
                throw new InvalidOperationException(@"Serialization not completed.");
            }
            L_NotFound:
            return false;
        }

        /// <summary>Removes all keys and values from the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
        public void Clear() {
            var entries = this.entries;
            var length = entries.Length; // null check
            if (length > 0) {
                var count = this.count;
                if (count > 0) {
                    Array.Clear(entries, 0, count);
                    for (var i = 0; length > i; ++i) {
                        entries[i].bucket = -1;
                    }
                    this.freeList = -1;
                    this.count = 0;
                    this.freeCount = 0;
                }
                return;
            }
            if (Array_Empty<Entry>.Value != entries) {
                throw new InvalidOperationException(@"Serialization not completed.");
            }
        }

        /// <summary>Determines whether the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> contains the specified key.</summary>
        /// <returns>true if the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> contains an element with the specified key; otherwise, false.</returns>
        /// <param name="key">The key to locate in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="key" /> is null.</exception>
        public bool ContainsKey(TKey key) {
            return 0 <= this.FindEntry(key);
        }

        /// <summary>Determines whether the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> contains a specific value.</summary>
        /// <returns>true if the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> contains an element with the specified value; otherwise, false.</returns>
        /// <param name="value">The value to locate in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />. The value can be null for reference types.</param>
        public bool ContainsValue(TValue value) {
            var entries = this.entries;
            var length = entries.Length; // null check
            if (null != value) {
                var valueComparer = EqualityComparer<TValue>.Default;
                for (var i = 0; this.count > i; ++i) {
                    ref var entry = ref entries[i];
                    if (entry.flags >= 0 && valueComparer.Equals(entry.value, value)) {
                        return true;
                    }
                }
            } else {
                for (var i = 0; this.count > i; ++i) {
                    ref var entry = ref entries[i];
                    if (entry.flags >= 0 && entry.value == null) {
                        return true;
                    }
                }
            }
            return false;
        }

        private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index) {
            if (array == null) {
                // ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
            }
            if (index < 0 || index > array.Length) {
                // ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            }
            if (array.Length - index < this.Count) {
                // ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
            }
            int num = this.count;
            Entry[] array2 = this.entries;
            for (int i = 0; i < num; i++) {
                if (array2[i].flags >= 0) {
                    array[index++] = new KeyValuePair<TKey, TValue>(array2[i].key, array2[i].value);
                }
            }
        }

        /// <summary>Returns an enumerator that iterates through the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
        /// <returns>A <see cref="Dictionary{TKey,TValue,TEqualityComparer}.Enumerator" /> structure for the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</returns>
        public Enumerator GetEnumerator() {
            return new Enumerator(this);
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() {
            return new Enumerator(this);
        }

        /// <summary>Implements the <see cref="ISerializable" /> interface and returns the data needed to serialize the <see cref="Dictionary{TKey, TValue, TEqualityComparer}" /> instance.</summary>
        /// <param name="info">A <see cref="SerializationInfo" /> object that contains the information required to serialize the <see cref="Dictionary{TKey, TValue, TEqualityComparer}" /> instance.</param>
        /// <param name="context">A <see cref="StreamingContext" /> structure that contains the source and destination of the serialized stream associated with the <see cref="Dictionary{TKey, TValue, TEqualityComparer}" /> instance.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="info" /> is null.</exception>
        [SecurityCriticalAttribute()]
        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            var entries = this.entries;
            var length = entries.Length; // null check
            if (info == null) {
                // ThrowHelper.ThrowArgumentNullException(ExceptionArgument.info);
            }
            if (length > 0) {
                if (entries != null) {
                    var array = new KeyValuePair<TKey, TValue>[this.Count];
                    this.CopyTo(array, 0);
                    info.AddValue(KeyValuePairsName, array, typeof(KeyValuePair<TKey, TValue>[]));
                }
                goto L_1;
            }
            if (Array_Empty<Entry>.Value != entries) {
                throw new InvalidOperationException(@"Serialization not completed.");
            }
            L_1:
            info.AddValue(HashSizeName, length);
        }

        private ref Entry FindEntry(TKey key, out bool found) {
            var entries = this.entries;
            var length = entries.Length; // null check;
            if (length > 0) {
                var comparer = DefaultConstructor.Invoke<TEqualityComparer>();
                var hashCode = comparer.GetHashCode(key);
                var index_prev = unchecked((int)((uint)hashCode % (uint)length));
                for (var index = entries[index_prev].bucket; 0 <= index;) {
                    ref var entry = ref entries[index];
                    if (entry.hashCode == hashCode && comparer.Equals(entry.key, key)) {
                        found = true;
                        return ref entry;
                    }
                    index = entry.next;
                }
                goto L_NotFound;
            }
            if (Array_Empty<Entry>.Value != entries) {
                throw new InvalidOperationException(@"Serialization not completed.");
            }
            L_NotFound:
            found = false;
            return ref Dummy<Entry>.Value;
        }

        private int FindEntry(TKey key) {
            var entries = this.entries;
            var length = entries.Length; // null check;
            if (length > 0) {
                var comparer = DefaultConstructor.Invoke<TEqualityComparer>();
                var hashCode = comparer.GetHashCode(key);
                var index_prev = unchecked((int)((uint)hashCode % (uint)length));
                for (var index = entries[index_prev].bucket; 0 <= index;) {
                    ref var entry = ref entries[index];
                    if (entry.hashCode == hashCode && comparer.Equals(entry.key, key)) {
                        return index;
                    }
                    index = entry.next;
                }
                goto L_NotFound;
            }
            if (Array_Empty<Entry>.Value != entries) {
                throw new InvalidOperationException(@"Serialization not completed.");
            }
            L_NotFound:
            return -1;
        }

        private Entry[] Initialize0(int capacity) {
            Debug.Assert(UltimateOrb.Mathematics.NumberTheory.IsPrimeModule.IsPrime(capacity));
            var entries = new Entry[capacity];
            for (var i = 0; entries.Length > i; ++i) {
                entries[i].bucket = -1;
            }
            this.entries = entries;
            this.freeList = -1;
            return entries;
        }

        private void Initialize(int capacity_min) {
            var capacity = HashHelper.GetOddPrimeGreaterThanOrEqual(capacity_min);
            this.Initialize0(capacity);
        }

        private void Insert(TKey key, TValue value, bool add) {
            var entries = this.entries;
            var length = entries.Length; // null check;
            if (length > 0) {
                goto L_0;
            }
            if (Array_Empty<Entry>.Value != entries) {
                throw new InvalidOperationException(@"Serialization not completed.");
            }
            length = 3;
            entries = this.Initialize0(length);
            L_0:
            var comparer = DefaultConstructor.Invoke<TEqualityComparer>();
            var hashCode = comparer.GetHashCode(key);
            var index_prev = unchecked((int)((uint)hashCode % (uint)length));
            var collision_count = 0;
            for (var index = entries[index_prev].bucket; 0 <= index;) {
                ref var entry = ref entries[index];
                if (entry.hashCode == hashCode && comparer.Equals(entry.key, key)) {
                    if (add) {
                        // ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_AddingDuplicate);
                    }
                    entry.value = value;
                    return;
                }
                ++collision_count;
                index = entry.next;
            }
            var index_free = 0;
            if (this.freeCount > 0) {
                index_free = this.freeList;
                this.freeList = entries[index_free].next;
                unchecked {
                    --this.freeCount;
                }
            } else {
                var count = this.count;
                if (count == length) {
                    entries = this.Resize();
                    length = entries.Length;
                    index_prev = unchecked((int)((uint)hashCode % (uint)length));
                }
                index_free = count;
                ++count;
                this.count = count;
            }
            {
                ref var entry = ref entries[index_free];
                ref var entryb = ref entries[index_prev].bucket;
                entry.hashCode = hashCode;
                entry.flags &= ~int.MinValue; // This entry is used.
                entry.next = entryb;
                entry.key = key;
                entry.value = value;
                entryb = index_free;
            }
            if (collision_count > 100) {
                this.Resize(HashHelper.GetOddPrimeGreaterThanOrEqual(2 + length), true);
            }
        }

        /// <summary>Implements the <see cref="ISerializable" /> interface and raises the deserialization event when the deserialization is complete.</summary>
        /// <param name="sender">The source of the deserialization event.</param>
        /// <exception cref="SerializationException">The <see cref="SerializationInfo" /> object associated with the current <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> instance is invalid.</exception>
        public void OnDeserialization(object sender) {
            var serializationInfo = (SerializationInfo)null;
            var key_SerializationInfo = this.entries;
            var t = HashHelper.SerializationInfoTable;
            t.TryGetValue((object)key_SerializationInfo, out serializationInfo);
            if (serializationInfo != null) {
                var entries = (Entry[])null;
                var capacity = serializationInfo.GetInt32(HashSizeName);
                if (capacity > 0) {
                    entries = new Entry[capacity];
                    for (var i = 0; entries.Length > i; ++i) {
                        entries[i].bucket = -1;
                    }
                    this.freeList = -1;
                    var array = (KeyValuePair<TKey, TValue>[])serializationInfo.GetValue(KeyValuePairsName, typeof(KeyValuePair<TKey, TValue>[]));
                    if (array == null) {
                        // ThrowHelper.ThrowSerializationException(ExceptionResource.Serialization_MissingKeys);
                    }
                    for (var i = 0; entries.Length > i; ++i) {
                        ref var entry = ref array[i];
                        this.Insert(entry.Key, entry.Value, true);
                    }
                } else {
                    entries = Array_Empty<Entry>.Value;
                }
                t.Remove(key_SerializationInfo);
                this.entries = entries;
            }
        }

        private Entry[] Resize() {
            var capacity_min = 2 * this.count;
            return this.Resize(HashHelper.GetOddPrimeGreaterThanOrEqual(capacity_min), false);
        }

        private Entry[] Resize(int newSize, bool forceNewHashCodes) {
            var entries = new Entry[newSize];
            for (var i = 0; entries.Length > i; ++i) {
                entries[i].bucket = -1;
            }
            Array.Copy(this.entries, 0, entries, 0, this.count);
            if (forceNewHashCodes) {
                var comparer = DefaultConstructor.Invoke<TEqualityComparer>();
                for (var i = 0; this.count > i; ++i) {
                    ref var entry = ref entries[i];
                    var hashCode = entry.hashCode;
                    if (0 <= entry.flags) {
                        entry.hashCode = comparer.GetHashCode(entry.key);
                    }
                }
            }
            for (var i = 0; this.count > i; ++i) {
                ref var entry = ref entries[i];
                var hashCode = entry.hashCode;
                if (hashCode >= 0) {
                    var index = unchecked((int)((uint)hashCode % (uint)newSize));
                    ref var entryb = ref entries[index].bucket;
                    entry.next = entryb;
                    entryb = i;
                }
            }
            this.entries = entries;
            return entries;
        }

        /// <summary>Removes the value with the specified key from the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
        /// <returns>true if the element is successfully found and removed; otherwise, false.  This method returns false if <paramref name="key" /> is not found in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</returns>
        /// <param name="key">The key of the element to remove.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="key" /> is null.</exception>
        public bool Remove(TKey key) {
            var entries = this.entries;
            var length = entries.Length; // null check;
            if (length > 0) {
                var comparer = DefaultConstructor.Invoke<TEqualityComparer>();
                var hashCode = comparer.GetHashCode(key);
                var index_prev = unchecked((int)((uint)hashCode % (uint)length));
                var index_tmp = -1;
                for (var index = entries[index_prev].bucket; 0 <= index;) {
                    ref var entry = ref entries[index];
                    if (entry.hashCode == hashCode && comparer.Equals(entry.key, key)) {
                        if (index_tmp < 0) {
                            entries[index_prev].bucket = entry.next;
                        } else {
                            entries[index_tmp].next = entry.next;
                        }
                        entry.flags |= int.MinValue; // This entry is not used. 
                        entry.next = this.freeList;
                        entry.key = default; // Good for GC.
                        entry.value = default; // Good for GC.
                        this.freeList = index;
                        ++this.freeCount;
                        return true;
                    }
                    index_tmp = index;
                    index = entry.next;
                }
                goto L_NotFound;
            }
            if (Array_Empty<Entry>.Value != entries) {
                throw new InvalidOperationException(@"Serialization not completed.");
            }
            L_NotFound:
            return false;
        }

        /// <summary>Gets the value associated with the specified key.</summary>
        /// <returns>true if the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> contains an element with the specified key; otherwise, false.</returns>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value" /> parameter. This parameter is passed uninitialized.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="key" /> is null.</exception>
        public bool TryGetValue(TKey key, out TValue value) {
            ref var entry = ref this.FindEntry(key, out var found);
            if (found) {
                value = entry.value;
                return true;
            }
            value = default;
            return false;
        }

        internal TValue GetValueOrDefault(TKey key) {
            ref var entry = ref this.FindEntry(key, out var found);
            if (found) {
                return entry.value;
            }
            return default;
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index) {
            this.CopyTo(array, index);
        }

        /// <summary>Copies the elements of the <see cref="ICollection`1" /> to an array, starting at the specified array index.</summary>
        /// <param name="array">The one-dimensional array that is the destination of the elements copied from <see cref="ICollection`1" />. The array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="array" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than 0.</exception>
        /// <exception cref="ArgumentException">
        ///   <paramref name="array" /> is multidimensional.-or-<paramref name="array" /> does not have zero-based indexing.-or-The number of elements in the source <see cref="ICollection`1" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.-or-The type of the source <see cref="ICollection`1" /> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
        void ICollection.CopyTo(Array array, int index) {
            if (array == null) {
                // ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
            }
            if (array.Rank != 1) {
                // ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
            }
            if (array.GetLowerBound(0) != 0) {
                // ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound);
            }
            if (index < 0 || index > array.Length) {
                // ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            }
            if (array.Length - index < this.Count) {
                // ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
            }
            if (array is KeyValuePair<TKey, TValue>[] array2) {
                this.CopyTo(array2, index);
            } else if (array is DictionaryEntry[] array3) {
                var entries = this.entries;
                var count = this.count;
                for (int i = 0; i < count; i++) {
                    ref var entry = ref entries[i];
                    if (entry.flags >= 0) {
                        array3[index++] = new DictionaryEntry(entry.key, entry.value);
                    }
                }
            } else {
                if (array is object[] array5) {
                    try {
                        var count = this.count;
                        var entries = this.entries;
                        for (int j = 0; j < count; j++) {
                            ref var entry = ref entries[j];
                            if (entry.flags >= 0) {
                                array5[index++] = new KeyValuePair<TKey, TValue>(entry.key, entry.value);
                            }
                        }
                    } catch (ArrayTypeMismatchException) {
                        // ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
                    }
                } else {
                    // ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
                }
            }
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An <see cref="IEnumerator" /> that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return new Enumerator(this);
        }

        /// <summary>Adds the specified key and value to the dictionary.</summary>
        /// <param name="key">The object to use as the key.</param>
        /// <param name="value">The object to use as the value.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="key" /> is null.</exception>
        /// <exception cref="ArgumentException">
        ///   <paramref name="key" /> is of a type that is not assignable to the key type <paramref name="TKey" /> of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.
        ///   -or-<paramref name="value" /> is of a type that is not assignable to <paramref name="TValue" />, the type of values in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.
        ///   -or-A value with the same key already exists in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</exception>
        void IDictionary.Add(object key, object value) {
            if (key == null) {
                // ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
            }
            // ThrowHelper.IfNullAndNullsAreIllegalThenThrow<TValue>(value, ExceptionArgument.value);
            try {
                var key0 = (TKey)key;
                try {
                    this.Add(key0, (TValue)value);
                } catch (InvalidCastException) {
                    // ThrowHelper.ThrowWrongValueTypeArgumentException(value, typeof(TValue));
                }
            } catch (InvalidCastException) {
                // ThrowHelper.ThrowWrongKeyTypeArgumentException(key, typeof(TKey));
            }
        }

        /// <summary>Determines whether the <see cref="IDictionary" /> contains an element with the specified key.</summary>
        /// <returns>true if the <see cref="IDictionary" /> contains an element with the specified key; otherwise, false.</returns>
        /// <param name="key">The key to locate in the <see cref="IDictionary" />.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="key" /> is null.</exception>
        bool IDictionary.Contains(object key) {
            if (key is TKey key0) {
                return this.ContainsKey(key0);
            }
            return false;
        }

        /// <summary>Returns an <see cref="IDictionaryEnumerator" /> for the <see cref="IDictionary" />.</summary>
        /// <returns>An <see cref="IDictionaryEnumerator" /> for the <see cref="IDictionary" />.</returns>
        IDictionaryEnumerator IDictionary.GetEnumerator() {
            return new Enumerator_A(this, 1);
        }

        /// <summary>Removes the element with the specified key from the <see cref="IDictionary" />.</summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="key" /> is null.</exception>
        void IDictionary.Remove(object key) {
            if (key is TKey key0) {
                this.Remove(key0);
            }
        }
    }
}


namespace UltimateOrb.Plain.ValueTypes {
    using UltimateOrb.Mathematics.NumberTheory;

    internal static partial class HashHelper {

        public static int GetOddPrimeGreaterThanOrEqual(int n) {
            if (n > 3) {
                for (var i = 1 | n; ; i += 2) {
                    if (IsOddPrimePartial(unchecked((uint)i))) {
                        return i;
                    }
                }
            }
            return 3;
        }

        private const ulong prime_table_odd = 0b_1000000101101101_0001001010011010_0110010010110100_1100101101101110;

        private const uint primes_3_5_7 = 3 * 5 * 7;

        private const ulong euler_3_5_7_lo = 0b_0110110000110000_1101101001100101_1010010011001011_0010100100010110;

        private const ulong euler_3_5_7_hi = 0b________________________0110100010_0101001101001100_1001011010011001;

        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.MayFail)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        private static bool IsProbablePrimeTrialDivision(uint primes, ulong euler_lo, ulong euler_hi, UInt32 value) {
            var a = unchecked((int)(value % primes));
            var euler = 64 <= a ? euler_hi : euler_lo;
            if (0 == ((euler >> a) & 1)) {
                return false;
            }
            return true;
        }

        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        internal static bool IsMillerRabinPseudoprimeInternal(uint a, UInt64 n, UInt64 d, int s) {
            unchecked {
                var t = ZZOverNZZModule.Power(n, a, d);
                if (t == 1) {
                    return true;
                }
                if (t == n - 1u) {
                    return true;
                }
                for (int i = s; i != 0; --i) {
                    t = ZZOverNZZModule.Square(n, t);
                    if (t == n - 1) {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        ///     <para>Checks whether an input number is prime or not.</para>
        /// </summary>
        /// <param name="value">
        ///     <para>The input number.</para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         <c lang="cs">true</c> if the input number is prime;
        ///         otherwise, <c lang="cs">false</c>.
        ///     </para>
        /// </returns>
        [System.CLSCompliantAttribute(false)]
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static bool IsOddPrimePartial(UInt32 value) {
            System.Diagnostics.Contracts.Contract.Requires(1 == value % 2);
            unchecked {
                if (133u > value) {
                    if (3u > value) {
                        return false;
                    }
                    return 0 != (1 & (int)(prime_table_odd >> (int)(value >> 1)));
                }
                if (!IsProbablePrimeTrialDivision(primes_3_5_7, euler_3_5_7_lo, euler_3_5_7_hi, value)) {
                    return false;
                }
                var d = value >> 1;
                int s = 1;
                while (0u == (1u & d)) {
                    d >>= 1;
                    ++s;
                }
                if (!IsMillerRabinPseudoprimeInternal(2, value, d, s)) {
                    return false;
                }
                if (value < 2047u) {
                    return true;
                }
                if (!IsMillerRabinPseudoprimeInternal(61, value, d, s)) {
                    return false;
                }
                if (value < 916327u) {
                    return true;
                }
                if (!IsMillerRabinPseudoprimeInternal(7, value, d, s)) {
                    return false;
                }
                return true;
            }
        }

        internal static readonly ConditionalWeakTable<object, SerializationInfo> SerializationInfoTable = new ConditionalWeakTable<object, SerializationInfo>();
    }
}