using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace UltimateOrb.Plain.ValueTypes {
    using UltimateOrb.Collections.Generic;
    using static ThrowHelper_Dictionary;

    /// <summary>Represents a collection of keys and values.</summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <typeparam name="TKeyEqualityComparer">Specifies the comparer of keys.</typeparam>
    [SerializableAttribute()]
    [DebuggerDisplayAttribute(@"Count = {LongCount}")]
    [ComVisibleAttribute(false)]
    public partial struct Dictionary<TKey, TValue, TKeyEqualityComparer> :
        IDictionary<TKey, TValue, Dictionary<TKey, TValue, TKeyEqualityComparer>.Enumerator, Dictionary<TKey, TValue, TKeyEqualityComparer>.KeyCollection.Enumerator, Dictionary<TKey, TValue, TKeyEqualityComparer>.KeyCollection, Dictionary<TKey, TValue, TKeyEqualityComparer>.ValueCollection.Enumerator, Dictionary<TKey, TValue, TKeyEqualityComparer>.ValueCollection>,
        IDictionary,
        IReadOnlyDictionary<TKey, TValue, Dictionary<TKey, TValue, TKeyEqualityComparer>.Enumerator, Dictionary<TKey, TValue, TKeyEqualityComparer>.KeyCollection.Enumerator, Dictionary<TKey, TValue, TKeyEqualityComparer>.KeyCollection, Dictionary<TKey, TValue, TKeyEqualityComparer>.ValueCollection.Enumerator, Dictionary<TKey, TValue, TKeyEqualityComparer>.ValueCollection>,
        ISerializable, IDeserializationCallback
        where TKeyEqualityComparer : IEqualityComparer<TKey>, new() {

        public partial struct Entry {

            public int m_HashCode;

            // linked list
            public int m_Next;

            // linked list
            public int m_First;

            public int m_Flags;

            public TKey m_Key;

            public TValue m_Value;
        }

        public bool ContainsKey<TEqualityComparer>(TEqualityComparer comparer, TKey item) where TEqualityComparer : IEqualityComparer<TKey> {
            throw new NotImplementedException();
        }

        public bool ContainsValue<TEqualityComparer>(TEqualityComparer comparer, TValue item) where TEqualityComparer : IEqualityComparer<TValue> {
            throw new NotImplementedException();
        }

        private const string HashSizeName = "HashSize";

        private const string KeyValuePairsName = "KeyValuePairs";

        private Entry[] m_EntryBuffer;

        // linked list
        private int m_FreeEntryFirst;

        private int m_Flags;

        private int m_EntryCount;

        private int m_FreeEntryCount;

        /// <summary>Gets the <see cref="IEqualityComparer{TKey}" /> that is used to determine equality of keys for the dictionary. </summary>
        /// <returns>The <see cref="IEqualityComparer{TKey}" /> generic interface implementation that is used to determine equality of keys for the current <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> and to provide hash values for the keys.</returns>
        public TKeyEqualityComparer Comparer {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return DefaultConstructor.Invoke<TKeyEqualityComparer>();
            }
        }

        /// <summary>Gets the number of key/value pairs contained in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
        /// <returns>The number of key/value pairs contained in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</returns>
        public int Count {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return unchecked(this.m_EntryCount - this.m_FreeEntryCount);
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
        /// <exception cref="KeyNotFoundException">The property is retrieved and <paramref name="key" /> does not exist in the collection.</exception>
        public TValue this[TKey key] {

            get {
                ref var entry = ref this.FindEntry(key, out var found);
                if (found) {
                    return entry.m_Value;
                }
                ThrowKeyNotFoundException();
                return default;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set {
                this.Insert(key, value, false);
            }
        }


        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly {

            get => false;
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

            get => null;
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

        ValueCollection IDictionary<TKey, TValue, Enumerator, KeyCollection.Enumerator, KeyCollection, ValueCollection.Enumerator, ValueCollection>.Values => throw new NotImplementedException();

        public long LongCount {

            get => this.Count;
        }

        ValueCollection IReadOnlyDictionary<TKey, TValue, Enumerator, KeyCollection.Enumerator, KeyCollection, ValueCollection.Enumerator, ValueCollection>.Values => throw new NotImplementedException();

        /// <summary>Gets or sets the value with the specified key.</summary>
        /// <returns>The value associated with the specified key, or null if <paramref name="key" /> is not in the dictionary or <paramref name="key" /> is of a type that is not assignable to the key type <paramref name="TKey" /> of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</returns>
        /// <param name="key">The key of the value to get.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="key" /> is null.</exception>
        /// <exception cref="ArgumentException">A value is being assigned, and <paramref name="key" /> is of a type that is not assignable to the key type <typeparamref name="TKey" /> of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.-or-A value is being assigned, and <paramref name="value" /> is of a type that is not assignable to the value type <typeparamref name="TValue" /> of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</exception>
        object IDictionary.this[object key] {

            get {
                if (key is TKey key0) {
                    ref var num = ref this.FindEntry(key0, out var found);
                    if (found) {
                        return num.m_Value;
                    }
                }
                return null;
            }

            set {
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

        /// <summary>Initializes a new instance of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> class that is empty, has the default initial capacity, and uses the specified <see cref="IEqualityComparer{TKey}" />.</summary>
        public static Dictionary<TKey, TValue, TKeyEqualityComparer> Create() {
            return new Dictionary<TKey, TValue, TKeyEqualityComparer>(0);
        }

        /// <summary>Initializes a new instance of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> class that is empty, has the specified initial capacity, and uses the specified <see cref="IEqualityComparer{TKey}" />.</summary>
        /// <param name="minCapacity">The initial number of elements that the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> can contain.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="minCapacity" /> is less than 0.</exception>
        public Dictionary(int minCapacity) {
            if (0 <= minCapacity) {
                this = default;
                if (minCapacity > 0) {
                    this.Initialize(minCapacity);
                    return;
                }
                this.m_EntryBuffer = Array_Empty<Entry>.Value;
                return;
            }
            // ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity);
            this = default;
        }

        /// <summary>Initializes a new instance of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> class that contains elements copied from the specified <see cref="IDictionary{TKey,TValue}" /> and uses the specified <see cref="IEqualityComparer{TKey}" />.</summary>
        /// <param name="dictionary">The <see cref="IDictionary{TKey,TValue}" /> whose elements are copied to the new <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="dictionary" /> is null.</exception>
        /// <exception cref="ArgumentException">
        ///   <paramref name="dictionary" /> contains one or more duplicate keys.</exception>
        public Dictionary(IDictionary<TKey, TValue> dictionary)
            : this((dictionary != null) ? dictionary.Count : 0) {
            if (dictionary == null) {
                ThrowArgumentNullException_dictionary();
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
            this.m_EntryBuffer = key_SerializationInfo;
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
            if (found && EqualityComparer<TValue>.Default.Equals(entry.m_Value, keyValuePair.Value)) {
                return true;
            }
            return false;
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair) {
            var entries = this.m_EntryBuffer;
            var length = entries.Length; // null check;
            if (length > 0) {
                var comparer = DefaultConstructor.Invoke<TKeyEqualityComparer>();
                var key = keyValuePair.Key;
                var hashCode = comparer.GetHashCode(key);
                var index_prev = unchecked((int)((uint)hashCode % (uint)length));
                var index_tmp = -1;
                var value = keyValuePair.Value;
                var valueComparer = EqualityComparer<TValue>.Default;
                for (var index = entries[index_prev].m_First; 0 <= index;) {
                    ref var entry = ref entries[index];
                    if (entry.m_HashCode == hashCode && comparer.Equals(entry.m_Key, key) && (null == value ? null == entry.m_Value : valueComparer.Equals(entry.m_Value, value))) {
                        if (index_tmp < 0) {
                            entries[index_prev].m_First = entry.m_Next;
                        } else {
                            entries[index_tmp].m_Next = entry.m_Next;
                        }
                        entry.m_Flags |= int.MinValue; // This entry is not used. 
                        entry.m_Next = this.m_FreeEntryFirst;
                        entry.m_Key = default; // Good for GC.
                        entry.m_Value = default; // Good for GC.
                        this.m_FreeEntryFirst = index;
                        ++this.m_FreeEntryCount;
                        return true;
                    }
                    index_tmp = index;
                    index = entry.m_Next;
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
            var entries = this.m_EntryBuffer;
            var length = entries.Length; // null check
            if (length > 0) {
                var count = this.m_EntryCount;
                if (count > 0) {
                    Array.Clear(entries, 0, count);
                    for (var i = 0; length > i; ++i) {
                        entries[i].m_First = -1;
                    }
                    this.m_FreeEntryFirst = -1;
                    this.m_EntryCount = 0;
                    this.m_FreeEntryCount = 0;
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
            var entries = this.m_EntryBuffer;
            var length = entries.Length; // null check
            if (null != value) {
                var valueComparer = EqualityComparer<TValue>.Default;
                for (var i = 0; this.m_EntryCount > i; ++i) {
                    ref var entry = ref entries[i];
                    if (entry.m_Flags >= 0 && valueComparer.Equals(entry.m_Value, value)) {
                        return true;
                    }
                }
            } else {
                for (var i = 0; this.m_EntryCount > i; ++i) {
                    ref var entry = ref entries[i];
                    if (entry.m_Flags >= 0 && entry.m_Value == null) {
                        return true;
                    }
                }
            }
            return false;
        }

        private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index) {
            if (array == null) {
                ThrowArgumentNullException_array();
            }
            if (index < 0 || index > array.Length) {
                ThrowArgumentOutOfRangeException_index_NeedNonNegNum();
            }
            if (array.Length - index < this.Count) {
                ThrowArgumentException_ArrayPlusOffTooSmall();
            }
            var count = this.m_EntryCount;
            var entries = this.m_EntryBuffer;
            for (var i = 0; count > i; ++i) {
                ref var entry = ref entries[i];
                if (0 <= entry.m_Flags) {
                    array[index++] = new KeyValuePair<TKey, TValue>(entry.m_Key, entry.m_Value);
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
            var entries = this.m_EntryBuffer;
            var length = entries.Length; // null check
            if (info == null) {
                ThrowArgumentNullException_info();
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
            var entries = this.m_EntryBuffer;
            var length = entries.Length; // null check;
            if (length > 0) {
                var comparer = DefaultConstructor.Invoke<TKeyEqualityComparer>();
                var hashCode = comparer.GetHashCode(key);
                var index_prev = unchecked((int)((uint)hashCode % (uint)length));
                for (var index = entries[index_prev].m_First; 0 <= index;) {
                    ref var entry = ref entries[index];
                    if (entry.m_HashCode == hashCode && 0 <= entry.m_Flags && comparer.Equals(entry.m_Key, key)) {
                        found = true;
                        return ref entry;
                    }
                    index = entry.m_Next;
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
            var entries = this.m_EntryBuffer;
            var length = entries.Length; // null check;
            if (length > 0) {
                var comparer = DefaultConstructor.Invoke<TKeyEqualityComparer>();
                var hashCode = comparer.GetHashCode(key);
                var index_prev = unchecked((int)((uint)hashCode % (uint)length));
                for (var index = entries[index_prev].m_First; 0 <= index;) {
                    ref var entry = ref entries[index];
                    if (entry.m_HashCode == hashCode && 0 <= entry.m_Flags && comparer.Equals(entry.m_Key, key)) {
                        return index;
                    }
                    index = entry.m_Next;
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
                entries[i].m_First = -1;
            }
            this.m_EntryBuffer = entries;
            this.m_FreeEntryFirst = -1;
            return entries;
        }

        private void Initialize(int capacity_min) {
            var capacity = HashHelper.GetOddPrimeGreaterThanOrEqual(capacity_min);
            this.Initialize0(capacity);
        }

        private void Insert(TKey key, TValue value, bool add) {
            var entries = this.m_EntryBuffer;
            var length = entries.Length; // null check;
            if (length > 0) {
                goto L_0;
            }
            if (Array_Empty<Entry>.Value != entries) {
                throw new InvalidOperationException(@"Serialization not completed.");
            }
            if (add) {
                length = 3;
                entries = this.Initialize0(length);
            }
            L_0:
            var comparer = DefaultConstructor.Invoke<TKeyEqualityComparer>();
            var hashCode = comparer.GetHashCode(key);
            var index_prev = unchecked((int)((uint)hashCode % (uint)length));
            var collision_count = 0;
            for (var index = entries[index_prev].m_First; 0 <= index;) {
                ref var entry = ref entries[index];
                if (entry.m_HashCode == hashCode && 0 <= entry.m_Flags && comparer.Equals(entry.m_Key, key)) {
                    if (add) {
                        ThrowArgumentException_AddingDuplicate();
                    }
                    entry.m_Value = value;
                    return;
                }
                ++collision_count;
                index = entry.m_Next;
            }
            var index_free = 0;
            if (this.m_FreeEntryCount > 0) {
                index_free = this.m_FreeEntryFirst;
                this.m_FreeEntryFirst = entries[index_free].m_Next;
                unchecked {
                    --this.m_FreeEntryCount;
                }
            } else {
                var count = this.m_EntryCount;
                if (count == length) {
                    entries = this.Resize();
                    length = entries.Length;
                    index_prev = unchecked((int)((uint)hashCode % (uint)length));
                }
                index_free = count;
                ++count;
                this.m_EntryCount = count;
            }
            {
                ref var entry = ref entries[index_free];
                ref var entryb = ref entries[index_prev].m_First;
                entry.m_HashCode = hashCode;
                entry.m_Flags &= ~int.MinValue; // This entry is used.
                entry.m_Next = entryb;
                entry.m_Key = key;
                entry.m_Value = value;
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
            var key_SerializationInfo = this.m_EntryBuffer;
            var t = HashHelper.SerializationInfoTable;
            t.TryGetValue((object)key_SerializationInfo, out serializationInfo);
            if (serializationInfo != null) {
                var entries = (Entry[])null;
                var capacity = serializationInfo.GetInt32(HashSizeName);
                if (capacity > 0) {
                    entries = new Entry[capacity];
                    for (var i = 0; entries.Length > i; ++i) {
                        entries[i].m_First = -1;
                    }
                    this.m_FreeEntryFirst = -1;
                    var array = (KeyValuePair<TKey, TValue>[])serializationInfo.GetValue(KeyValuePairsName, typeof(KeyValuePair<TKey, TValue>[]));
                    if (array == null) {
                        ThrowSerializationException_MissingKeys();
                    }
                    for (var i = 0; entries.Length > i; ++i) {
                        ref var entry = ref array[i];
                        this.Insert(entry.Key, entry.Value, true);
                    }
                } else {
                    entries = Array_Empty<Entry>.Value;
                }
                t.Remove(key_SerializationInfo);
                this.m_EntryBuffer = entries;
            }
        }

        private Entry[] Resize() {
            var capacity_min = 2 * this.m_EntryCount;
            return this.Resize(HashHelper.GetOddPrimeGreaterThanOrEqual(capacity_min), false);
        }

        private Entry[] Resize(int newSize, bool forceNewHashCodes) {
            var entries = new Entry[newSize];
            for (var i = 0; entries.Length > i; ++i) {
                entries[i].m_First = -1;
            }
            Array.Copy(this.m_EntryBuffer, 0, entries, 0, this.m_EntryCount);
            if (forceNewHashCodes) {
                var comparer = DefaultConstructor.Invoke<TKeyEqualityComparer>();
                for (var i = 0; this.m_EntryCount > i; ++i) {
                    ref var entry = ref entries[i];
                    var hashCode = entry.m_HashCode;
                    if (0 <= entry.m_Flags) {
                        entry.m_HashCode = comparer.GetHashCode(entry.m_Key);
                    }
                }
            }
            for (var i = 0; this.m_EntryCount > i; ++i) {
                ref var entry = ref entries[i];
                var hashCode = entry.m_HashCode;
                if (0 <= entry.m_Flags) {
                    var index = unchecked((int)((uint)hashCode % (uint)newSize));
                    ref var entryb = ref entries[index].m_First;
                    entry.m_Next = entryb;
                    entryb = i;
                }
            }
            this.m_EntryBuffer = entries;
            return entries;
        }

        /// <summary>Removes the value with the specified key from the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
        /// <returns>true if the element is successfully found and removed; otherwise, false.  This method returns false if <paramref name="key" /> is not found in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</returns>
        /// <param name="key">The key of the element to remove.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="key" /> is null.</exception>
        public bool Remove(TKey key) {
            var entries = this.m_EntryBuffer;
            var length = entries.Length; // null check;
            if (length > 0) {
                var comparer = DefaultConstructor.Invoke<TKeyEqualityComparer>();
                var hashCode = comparer.GetHashCode(key);
                var index_prev = unchecked((int)((uint)hashCode % (uint)length));
                var index_tmp = -1;
                for (var index = entries[index_prev].m_First; 0 <= index;) {
                    ref var entry = ref entries[index];
                    if (entry.m_HashCode == hashCode && 0 <= entry.m_Flags && comparer.Equals(entry.m_Key, key)) {
                        if (index_tmp < 0) {
                            entries[index_prev].m_First = entry.m_Next;
                        } else {
                            entries[index_tmp].m_Next = entry.m_Next;
                        }
                        entry.m_Flags |= int.MinValue; // This entry is not used. 
                        entry.m_Next = this.m_FreeEntryFirst;
                        entry.m_Key = default; // Good for GC.
                        entry.m_Value = default; // Good for GC.
                        this.m_FreeEntryFirst = index;
                        ++this.m_FreeEntryCount;
                        return true;
                    }
                    index_tmp = index;
                    index = entry.m_Next;
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
                value = entry.m_Value;
                return true;
            }
            value = default;
            return false;
        }

        internal TValue GetValueOrDefault(TKey key) {
            ref var entry = ref this.FindEntry(key, out var found);
            if (found) {
                return entry.m_Value;
            }
            return default;
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index) {
            this.CopyTo(array, index);
        }

        /// <summary>Copies the elements of the <see cref="ICollection" /> to an array, starting at the specified array index.</summary>
        /// <param name="array">The one-dimensional array that is the destination of the elements copied from <see cref="ICollection" />. The array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="array" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than 0.</exception>
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
            if (array.Length - index < this.Count) {
                ThrowArgumentException_ArrayPlusOffTooSmall();
            }
            if (array is KeyValuePair<TKey, TValue>[] array2) {
                this.CopyTo(array2, index);
            } else if (array is DictionaryEntry[] array3) {
                var entries = this.m_EntryBuffer;
                var count = this.m_EntryCount;
                for (int i = 0; i < count; i++) {
                    ref var entry = ref entries[i];
                    if (entry.m_Flags >= 0) {
                        array3[index++] = new DictionaryEntry(entry.m_Key, entry.m_Value);
                    }
                }
            } else {
                if (array is object[] array5) {
                    try {
                        var count = this.m_EntryCount;
                        var entries = this.m_EntryBuffer;
                        for (int j = 0; j < count; j++) {
                            ref var entry = ref entries[j];
                            if (entry.m_Flags >= 0) {
                                array5[index++] = new KeyValuePair<TKey, TValue>(entry.m_Key, entry.m_Value);
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
        ///   <paramref name="key" /> is of a type that is not assignable to the key type <typeparamref name="TKey" /> of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.
        ///   -or-<paramref name="value" /> is of a type that is not assignable to <typeparamref name="TValue" />, the type of values in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.
        ///   -or-A value with the same key already exists in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</exception>
        void IDictionary.Add(object key, object value) {
            // ThrowHelper.IfNullAndNullsAreIllegalThenThrow<TValue>(value, ExceptionArgument.value);
            try {
                var key0 = (TKey)key;
                try {
                    this.Add(key0, (TValue)value);
                } catch (InvalidCastException) {
                    ThrowArgumentException_WrongValueType(value, typeof(TValue));
                }
            } catch (InvalidCastException) {
                ThrowArgumentException_WrongValueType(key, typeof(TKey));
            }
        }

        /// <summary>Determines whether the <see cref="IDictionary" /> contains an element with the specified key.</summary>
        /// <returns>true if the <see cref="IDictionary" /> contains an element with the specified key; otherwise, false.</returns>
        /// <param name="key">The key to locate in the <see cref="IDictionary" />.</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="key" /> is null.</exception>
        bool IDictionary.Contains(object key) {
            var k = default(TKey);
            if (key is TKey key0) {
                k = key0;
                goto L_0;
            } else if (null == key && IsBclNullValid<TKey>.Value) {
                goto L_0;
            }
            return false;
            L_0:
            return this.ContainsKey(k);
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
            var k = default(TKey);
            if (key is TKey key0) {
                k = key0;
                goto L_0;
            } else if (null == key && IsBclNullValid<TKey>.Value) {
                goto L_0;
            }
            return;
            L_0:
            this.Remove(k);
        }

        public TValue GetOrAdd<TFunc>(TKey key, TFunc valueFactory) where TFunc : IFunc<TKey, TValue> {
            var entries = this.m_EntryBuffer;
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
            var comparer = DefaultConstructor.Invoke<TKeyEqualityComparer>();
            var hashCode = comparer.GetHashCode(key);
            var index_prev = unchecked((int)((uint)hashCode % (uint)length));
            var collision_count = 0;
            for (var index = entries[index_prev].m_First; 0 <= index;) {
                ref var entry = ref entries[index];
                if (entry.m_HashCode == hashCode && 0 <= entry.m_Flags && comparer.Equals(entry.m_Key, key)) {
                    return entry.m_Value;
                }
                ++collision_count;
                index = entry.m_Next;
            }
            var value = valueFactory.Invoke(key);
            var index_free = 0;
            var freeEntryCount = this.m_FreeEntryCount;
            if (freeEntryCount > 0) {
                index_free = this.m_FreeEntryFirst;
                this.m_FreeEntryFirst = entries[index_free].m_Next;
                unchecked {
                    --freeEntryCount;
                }
                this.m_FreeEntryCount = freeEntryCount;
            } else {
                var count = this.m_EntryCount;
                if (count == length) {
                    entries = this.Resize();
                    length = entries.Length;
                    index_prev = unchecked((int)((uint)hashCode % (uint)length));
                }
                index_free = count;
                ++count;
                this.m_EntryCount = count;
            }
            {
                ref var entry = ref entries[index_free];
                ref var entryb = ref entries[index_prev].m_First;
                entry.m_HashCode = hashCode;
                entry.m_Flags &= ~int.MinValue; // This entry is used.
                entry.m_Next = entryb;
                entry.m_Key = key;
                entry.m_Value = value;
                entryb = index_free;
            }
            if (collision_count > 100) {
                this.Resize(HashHelper.GetOddPrimeGreaterThanOrEqual(2 + (int)unchecked((ulong)(1.6180339887498948 * length))), true);
            }
            return value;
        }

        public TValue AddOrUpdate<TAdd, TUpdate>(TKey key, TAdd addValueFactory, TUpdate updateValueFactory)
            where TAdd : IFunc<TKey, TValue>
            where TUpdate : IFunc<TKey, TValue, TValue> {
            var entries = this.m_EntryBuffer;
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
            var comparer = DefaultConstructor.Invoke<TKeyEqualityComparer>();
            var hashCode = comparer.GetHashCode(key);
            var index_prev = unchecked((int)((uint)hashCode % (uint)length));
            var collision_count = 0;
            TValue value;
            for (var index = entries[index_prev].m_First; 0 <= index;) {
                ref var entry = ref entries[index];
                if (entry.m_HashCode == hashCode && 0 <= entry.m_Flags && comparer.Equals(entry.m_Key, key)) {
                    value = updateValueFactory.Invoke(entry.m_Key, entry.m_Value);
                    entry.m_Value = value;
                    return value;
                }
                ++collision_count;
                index = entry.m_Next;
            }
            value = addValueFactory.Invoke(key);
            var index_free = 0;
            var freeEntryCount = this.m_FreeEntryCount;
            if (freeEntryCount > 0) {
                index_free = this.m_FreeEntryFirst;
                this.m_FreeEntryFirst = entries[index_free].m_Next;
                unchecked {
                    --freeEntryCount;
                }
                this.m_FreeEntryCount = freeEntryCount;
            } else {
                var count = this.m_EntryCount;
                if (count == length) {
                    entries = this.Resize();
                    length = entries.Length;
                    index_prev = unchecked((int)((uint)hashCode % (uint)length));
                }
                index_free = count;
                ++count;
                this.m_EntryCount = count;
            }
            {
                ref var entry = ref entries[index_free];
                ref var entryb = ref entries[index_prev].m_First;
                entry.m_HashCode = hashCode;
                entry.m_Flags &= ~int.MinValue; // This entry is used.
                entry.m_Next = entryb;
                entry.m_Key = key;
                entry.m_Value = value;
                entryb = index_free;
            }
            if (collision_count > 100) {
                this.Resize(HashHelper.GetOddPrimeGreaterThanOrEqual(2 + (int)unchecked((ulong)(1.6180339887498948 * length))), true);
            }
            return value;
        }

        public bool TryAdd(TKey key, TValue value) {
            var entries = this.m_EntryBuffer;
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
            var comparer = DefaultConstructor.Invoke<TKeyEqualityComparer>();
            var hashCode = comparer.GetHashCode(key);
            var index_prev = unchecked((int)((uint)hashCode % (uint)length));
            var collision_count = 0;
            for (var index = entries[index_prev].m_First; 0 <= index;) {
                ref var entry = ref entries[index];
                if (entry.m_HashCode == hashCode && 0 <= entry.m_Flags && comparer.Equals(entry.m_Key, key)) {
                    return false;
                }
                ++collision_count;
                index = entry.m_Next;
            }
            var index_free = 0;
            var freeEntryCount = this.m_FreeEntryCount;
            if (freeEntryCount > 0) {
                index_free = this.m_FreeEntryFirst;
                this.m_FreeEntryFirst = entries[index_free].m_Next;
                unchecked {
                    --freeEntryCount;
                }
                this.m_FreeEntryCount = freeEntryCount;
            } else {
                var count = this.m_EntryCount;
                if (count == length) {
                    entries = this.Resize();
                    length = entries.Length;
                    index_prev = unchecked((int)((uint)hashCode % (uint)length));
                }
                index_free = count;
                ++count;
                this.m_EntryCount = count;
            }
            {
                ref var entry = ref entries[index_free];
                ref var entryb = ref entries[index_prev].m_First;
                entry.m_HashCode = hashCode;
                entry.m_Flags &= ~int.MinValue; // This entry is used.
                entry.m_Next = entryb;
                entry.m_Key = key;
                entry.m_Value = value;
                entryb = index_free;
            }
            if (collision_count > 100) {
                this.Resize(HashHelper.GetOddPrimeGreaterThanOrEqual(2 + length), true);
            }
            return true;
        }

        public bool TryRemove(TKey key, out TValue value) {
            var entries = this.m_EntryBuffer;
            var length = entries.Length; // null check;
            if (length > 0) {
                var comparer = DefaultConstructor.Invoke<TKeyEqualityComparer>();
                var hashCode = comparer.GetHashCode(key);
                var index_prev = unchecked((int)((uint)hashCode % (uint)length));
                var index_tmp = -1;
                for (var index = entries[index_prev].m_First; 0 <= index;) {
                    ref var entry = ref entries[index];
                    if (entry.m_HashCode == hashCode && 0 <= entry.m_Flags && comparer.Equals(entry.m_Key, key)) {
                        this.m_FreeEntryFirst = index;
                        ++this.m_FreeEntryCount;
                        if (index_tmp < 0) {
                            entries[index_prev].m_First = entry.m_Next;
                        } else {
                            entries[index_tmp].m_Next = entry.m_Next;
                        }
                        entry.m_Flags |= int.MinValue; // This entry is not used. 
                        entry.m_Next = this.m_FreeEntryFirst;
                        entry.m_Key = default; // Good for GC.
                        var value0 = entry.m_Value;
                        entry.m_Value = default; // Good for GC.
                        value = value0; // ignore
                        return true;
                    }
                    index_tmp = index;
                    index = entry.m_Next;
                }
                goto L_NotFound;
            }
            if (Array_Empty<Entry>.Value != entries) {
                throw new InvalidOperationException(@"Serialization not completed.");
            }
            L_NotFound:
            value = default; // ignore
            return false;
        }

        public bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue) {
            var entries = this.m_EntryBuffer;
            var length = entries.Length; // null check;
            if (length > 0) {
                goto L_0;
            }
            if (Array_Empty<Entry>.Value != entries) {
                throw new InvalidOperationException(@"Serialization not completed.");
            }
            L_0:
            var comparer = DefaultConstructor.Invoke<TKeyEqualityComparer>();
            var hashCode = comparer.GetHashCode(key);
            var index_prev = unchecked((int)((uint)hashCode % (uint)length));
            var collision_count = 0;
            TValue value;
            for (var index = entries[index_prev].m_First; 0 <= index;) {
                ref var entry = ref entries[index];
                if (entry.m_HashCode == hashCode && 0 <= entry.m_Flags && comparer.Equals(entry.m_Key, key)) {
                    var valueComparer = EqualityComparer<TValue>.Default;
                    if (valueComparer.Equals(entry.m_Value, comparisonValue)) {
                        entry.m_Value = newValue;
                        return true;
                    }
                    return false;
                }
                ++collision_count;
                index = entry.m_Next;
            }
            return false;
        }

        public bool Contains<TEqualityComparer>(TEqualityComparer comparer, KeyValuePair<TKey, TValue> item) where TEqualityComparer : IEqualityComparer<KeyValuePair<TKey, TValue>> {
            throw new NotImplementedException();
        }

        public bool Remove<TEqualityComparer>(TEqualityComparer comparer, KeyValuePair<TKey, TValue> item) where TEqualityComparer : IEqualityComparer<KeyValuePair<TKey, TValue>> {
            throw new NotImplementedException();
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
