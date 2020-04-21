using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Collections.ObjectModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic {
    using UltimateOrb;

    using System.Collections;
    using static Internal.System.ArrayModule;
    using static UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic.List_ThrowHelper;
    using static UltimateOrb.Utilities.SignConverter;

    /// <summary>
    ///     <para>Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists. This type is a value type.</para>
    /// </summary>
    /// <typeparam name="T">
    ///     <para>The type of elements in the list.</para>
    /// </typeparam>
    [DebuggerDisplayAttribute("Count = {Count}")]
    [SerializableAttribute()]
    public partial struct List<T>
        : System.Collections.Generic.IList<T>
        , System.Collections.Generic.IReadOnlyList<T>
        , Typed_RefReturn_Wrapped_Huge.Collections.Generic.IList<T, List<T>.Enumerator>
        , Typed_RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyList<T, List<T>.Enumerator> {

        private T[] buffer;

        [ContractPublicPropertyNameAttribute("Count")]
        private int count;

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="List{T}"/> type that is empty and has sufficient capacity to accommodate the specified number of elements.
        ///     </para>
        /// </summary>
        /// <param name="capacity">
        ///     <para>
        ///         The number of elements that the new list can initially store.
        ///     </para>
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <para>
        ///         <paramref name="capacity"/> is less than 0.
        ///     </para>
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        ///     <para>There is insufficient memory to satisfy the request.</para>
        /// </exception>
        /// <remarks>
        ///     <para>The capacity of a <see cref="List{T}"/> is the number of elements that the <see cref="List{T}"/> can hold. As elements are added to a <see cref="List{T}"/>, the capacity is automatically increased as required by reallocating the internal array.</para>
        ///     <para>If the size of the collection can be estimated, specifying the initial capacity eliminates the need to perform a number of resizing operations while adding elements to the <see cref="List{T}"/>.</para>
        ///     <para>The capacity can be decreased by calling the <see cref="TrimExcess"/> method or by setting the <see cref="Capacity"/> property explicitly. Decreasing the capacity reallocates memory and copies all the elements in the <see cref="List{T}"/>.</para>
        ///     <para>This constructor is an O(n) operation, where n is <paramref name="capacity"/>.</para>
        /// </remarks>
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List(int capacity) {
            if (0 <= capacity) {
                this.buffer = ((0 == capacity) ? Array_Empty<T>.Value : new T[capacity]);
                this.count = 0;
                return;
            }
            throw ThrowArgumentOutOfRangeException_capacity();
        }

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="List{T}"/> type that is empty and has sufficient capacity to accommodate the specified number of elements.
        ///     </para>
        /// </summary>
        /// <param name="capacity">
        ///     <para>
        ///         The number of elements that the new list can initially store.
        ///     </para>
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <para>
        ///         <paramref name="capacity"/> is less than 0.
        ///     </para>
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        ///     <para>There is insufficient memory to satisfy the request.</para>
        /// </exception>
        /// <remarks>
        ///     <para>The capacity of a <see cref="List{T}"/> is the number of elements that the <see cref="List{T}"/> can hold. As elements are added to a <see cref="List{T}"/>, the capacity is automatically increased as required by reallocating the internal array.</para>
        ///     <para>If the size of the collection can be estimated, specifying the initial capacity eliminates the need to perform a number of resizing operations while adding elements to the <see cref="List{T}"/>.</para>
        ///     <para>The capacity can be decreased by calling the <see cref="TrimExcess"/> method or by setting the <see cref="Capacity"/> property explicitly. Decreasing the capacity reallocates memory and copies all the elements in the <see cref="List{T}"/>.</para>
        ///     <para>This constructor is an O(n) operation, where n is <paramref name="capacity"/>.</para>
        /// </remarks>
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List(long capacity) {
            if (0 <= capacity) {
                this.buffer = ((0 == capacity) ? Array_Empty<T>.Value : new T[capacity]);
                this.count = 0;
                return;
            }
            throw ThrowArgumentOutOfRangeException_capacity();
        }

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="List{T}"/> type that is empty and has default capacity.
        ///     </para>
        /// </summary>
        /// <param name="_">
        ///     <para>
        ///         Ignored.
        ///     </para>
        /// </param>
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List(Void _) : this(List.default_capacity) {
        }

        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="List{T}"/> type that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.</para>
        /// </summary>
        /// <param name="collection">
        ///     <para>The collection whose elements are copied to the new list.</para>
        /// </param>
        /// <exception cref="OutOfMemoryException">
        ///     <para>There is insufficient memory to satisfy the request.</para>
        /// </exception>
        public List(IEnumerable<T> collection) {
            if (null != collection) {
                if (collection is ICollection<T> c) {
                    var count = c.Count;
                    if (0 != count) {
                        var buffer = new T[count];
                        c.CopyTo(buffer, 0);
                        this.buffer = buffer;
                        this.count = count;
                        return;
                    }
                    {
                        this.buffer = Array_Empty<T>.Value;
                        this.count = 0;
                        return;
                    }
                }
                {
                    this = new List<T>(0);
                    var e = collection.GetEnumerator();
                    while (e.MoveNext()) {
                        this.Add(e.Current);
                    }
                    e.Dispose();
                    return;
                }
            }
            throw ThrowArgumentNullException_collection();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private List(T[] buffer, int count) {
            this.buffer = buffer;
            this.count = count;
        }

        public int Capacity {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                Contract.Requires(this.IsInitialized);
                Contract.EnsuresOnThrow<NullReferenceException>(Contract.OldValue(this.IsInitialized));
                Contract.Ensures(0 <= Contract.Result<int>());
                return this.buffer.Length;
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set {
                var buffer = this.buffer;
                var count = this.count;
                if (null != buffer) {
                    if (count <= value) {
                        if (value != buffer.Length) {
                            if (value > 0) {
                                var new_buffer = new T[value];
                                if (count > 0) {
                                    Array.Copy(buffer, 0, new_buffer, 0, count);
                                }
                                this.buffer = new_buffer;
                                return;
                            }
                            {
                                this.buffer = Array_Empty<T>.Value;
                                return;
                            }
                        }
                    }
                    throw ThrowArgumentOutOfRangeException_value();
                }
                throw (NullReferenceException) null;
            }
        }

        public int Count {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                if (null != this.buffer) {
                    return checked((int) this.count);
                }
                throw (NullReferenceException) null;
            }
        }

        int System.Collections.Generic.IReadOnlyCollection<T>.Count {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Count;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool IsNull {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => null == this.buffer;
        }

        [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
        public bool IsReadOnly {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                if (null != this.buffer) {
                    return false;
                }
                throw (NullReferenceException) null;
            }
        }

        bool System.Collections.Generic.ICollection<T>.IsReadOnly {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.IsReadOnly;
        }

        public long LongCount {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                if (null != this.buffer) {
                    return this.count;
                }
                throw (NullReferenceException) null;
            }
        }

        long Huge.Collections.Generic.IReadOnlyCollection<T>.LongCount {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.LongCount;
        }

        private bool IsInitialized {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return null != this.buffer;
            }
        }

        public ref T this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                Contract.Requires(null != this.buffer);
                var @this = this;
                @this.CheckIndex(index);
                return ref @this.buffer[index];
            }
        }

        [CLSCompliantAttribute(false)]
        public ref T this[uint index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                var @this = this;
                @this.CheckIndex(index);
                return ref @this.buffer[index];
            }
        }

        public ref T this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                var @this = this;
                @this.CheckIndex(index);
                return ref @this.buffer[index];
            }
        }

        [CLSCompliantAttribute(false)]
        public ref T this[ulong index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                var @this = this;
                @this.CheckIndex(index);
                return ref @this.buffer[index];
            }
        }

        public ref T this[IntPtr index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                var @this = this;
                @this.CheckIndex(index);
                return ref @this.buffer[unchecked((long) index)];
            }
        }

        [CLSCompliantAttribute(false)]
        public ref T this[UIntPtr index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                var @this = this;
                @this.CheckIndex(index);
                return ref @this.buffer[unchecked((ulong) index)];
            }
        }

        T System.Collections.Generic.IReadOnlyList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[index];
        }

        ref readonly T RefReturn.Collections.Generic.IReadOnlyList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        T Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[index];
        }

        ref readonly T RefReturn_Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        T System.Collections.Generic.IList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[index];

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this[index] = value;
        }

        ref T RefReturn.Collections.Generic.IList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        T Huge.Collections.Generic.IList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[index];

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this[index] = value;
        }

        ref T RefReturn_Huge.Collections.Generic.IList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[index];
        }

        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="List{T}"/> type that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.</para>
        /// </summary>
        /// <typeparam name="TEnumerable">
        ///     <para>The type of <paramref name="collection"/>.</para>
        /// </typeparam>
        /// <typeparam name="TEnumerator">
        ///     <para>The enumerator type of <paramref name="collection"/>.</para>
        /// </typeparam>
        /// <param name="collection">
        ///     <para>The collection whose elements are copied to the new list.</para>
        /// </param>
        /// <exception cref="OutOfMemoryException">
        ///     <para>There is insufficient memory to satisfy the request.</para>
        /// </exception>
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static List<T> Create<TEnumerable, TEnumerator>(TEnumerable collection)
            where TEnumerable : Typed.Collections.Generic.IEnumerable<T, TEnumerator>
            where TEnumerator : IEnumerator<T> {
            var @this = new List<T>(0);
            var e = collection.GetEnumerator();
            while (e.MoveNext()) {
                @this.Add(e.Current);
            }
            e.Dispose();
            return @this;
        }

        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="List{T}"/> type that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.</para>
        /// </summary>
        /// <typeparam name="TCollection">
        ///     <para>The type of <paramref name="collection"/>.</para>
        /// </typeparam>
        /// <typeparam name="TEnumerator">
        ///     <para>The enumerator type of <paramref name="collection"/>.</para>
        /// </typeparam>
        /// <param name="collection">
        ///     <para>The collection whose elements are copied to the new list.</para>
        /// </param>
        /// <exception cref="OutOfMemoryException">
        ///     <para>There is insufficient memory to satisfy the request.</para>
        /// </exception>
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static List<T> CreateFromCollection<TCollection, TEnumerator>(TCollection collection)
            where TCollection : Typed.Collections.Generic.ICollection<T, TEnumerator>
            where TEnumerator : IEnumerator<T> {
            if (null != collection) {
                var count = collection.Count;
                if (count > 0) {
                    var buffer = new T[count];
                    collection.CopyTo(buffer, 0);
                    return new List<T>(buffer, count);
                }
                return new List<T>(0);
            }
            throw ThrowArgumentNullException_collection();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List<T> Clone() {
            return new List<T>(this.buffer.Clone() as T[], this.count);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref T Add(T item) {
            var @this = this;
            if (null != @this.buffer) {
                var c = @this.count;
                checked {
                    ++c;
                }
                if (c <= @this.buffer.Length) {
                    ref var result = ref @this.buffer[@this.count];
                    result = item;
                    this.count = c;
                    return ref result;
                }
                {
                    @this.EnsureCapacityInternal(c);
                    ref var result = ref @this.buffer[@this.count];
                    result = item;
                    this.buffer = @this.buffer;
                    this.count = c;
                    return ref result;
                }
            }
            throw (NullReferenceException) null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        ref T RefReturn.Collections.Generic.ICollection<T>.Add(T item) {
            return ref this.Add(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.ICollection<T>.Add(T item) {
            this.Add(item);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void AddRange(IEnumerable<T> collection) {
            Contract.Ensures(Contract.OldValue(this.Count) <= this.Count);
            this.InsertRange(this.count, collection);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void AddRange(int start, int length) {
            Contract.Ensures(Contract.OldValue(this.Count) <= this.Count);
            var index = this.count;
            this.CheckIteratorIndex(start);
            this.CheckIteratorIndex(length);
            this.CheckIteratorIndex(unchecked(start + length));
            var count = length;
            if (count > 0) {
                var new_count = checked(index + count);
                var buffer = this.buffer;
                var buffer_Length = buffer.Length;
                if (new_count > buffer_Length) {
                    buffer = CreateNewBuffer(new_count, count, buffer);
                    this.buffer = buffer;
                }
                Array.Copy(buffer, start, buffer, index, length);
                this.count = new_count;
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyCollection<T> AsReadOnly() {
            Contract.Ensures(null != Contract.Result<ReadOnlyCollection<T>>());
            return new ReadOnlyCollection<T>(this);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Clear() {
            var buffer = this.buffer;
            if (null != buffer) {
                var count = this.count;
                if (count > 0) {
                    Array.Clear(buffer, 0, count); // Good for GC.
                    this.count = 0;
                }
            }
            throw (NullReferenceException) null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.ICollection<T>.Clear() {
            this.Clear();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void ClearQuick() {
            var buffer = this.buffer;
            if (null != buffer) {
                this.count = 0;
            }
            throw (NullReferenceException) null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item) {
            var buffer = this.buffer;
            var length = buffer.Length; // null check
            var count = this.count;
            if (null != item) {
                EqualityComparer<T> c = EqualityComparer<T>.Default;
                for (var i = 0; count > i; ++i) {
                    if (c.Equals(buffer[i], item)) {
                        return true;
                    }
                }
                return false;
            }
            {
                for (var i = 0; count > i; ++i) {
                    if (null == buffer[i]) {
                        return true;
                    }
                }
                return false;
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            var buffer = this.buffer;
            var length = buffer.Length; // null check
            var count = this.count;
            for (int i = 0; count > i; i++) {
                if (comparer.Equals(buffer[i], item)) {
                    return true;
                }
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains<TEqualityComparer>(T item)
            where TEqualityComparer : IEqualityComparer<T>, new() {
            return this.Contains(item, DefaultConstructor.Invoke<TEqualityComparer>());
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Contains(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed.Collections.Generic.ICollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Contains(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool System.Collections.Generic.ICollection<T>.Contains(T item) {
            return this.Contains(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Contains(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_RefReturn.Collections.Generic.IReadOnlyCollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Contains(item);
        }

        // Copies this List into array, which must be of a 
        // compatible array type.  
        //
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array) {
            this.CopyTo(array, 0);
        }

        // Copies a section of this list to the given array at the given index.
        // 
        // The method uses the Array.Copy method to copy the elements.
        // 
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(int index, T[] array, int arrayIndex, int count) {
            var buffer = this.buffer;
            var length = buffer.Length; // null check
            var this_count = this.count;
            if (this_count - index < count) {
                throw new ArgumentException();
            }
            // Delegate rest of error checking to Array.Copy.
            Array.Copy(buffer, index, array, arrayIndex, count);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, int arrayIndex) {
            // Delegate rest of error checking to Array.Copy.
            Array.Copy(this.buffer, 0, array, arrayIndex, this.count);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, long arrayIndex) {
            Array.Copy(this.buffer, 0, array, arrayIndex, this.count);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(Array<T> array, int arrayIndex) {
            Array.Copy(this.buffer, 0, array.Value, arrayIndex, this.count);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(Array<T> array, long arrayIndex) {
            Array.Copy(this.buffer, 0, array.Value, arrayIndex, this.count);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Wrapped_Huge.Collections.Generic.ICollection<T>.CopyTo(Array<T> array, long arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Huge.Collections.Generic.ICollection<T>.CopyTo(T[] array, long arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Wrapped.Collections.Generic.ICollection<T>.CopyTo(Array<T> array, int arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.ICollection<T>.CopyTo(T[] array, int arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyCollection<T>.CopyTo(Array<T> array, long arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T>.CopyTo(T[] array, long arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void RefReturn_Wrapped.Collections.Generic.IReadOnlyCollection<T>.CopyTo(Array<T> array, int arrayIndex) {
            this.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="min"></param>
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void EnsureCapacity(int min) {
            this.EnsureCapacityInternal(min);
        }

        public ref T GetData(int index) {
            return ref this.buffer[index];
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() {
            var @this = this;
            var length = @this.buffer.Length; // null check
            return new Enumerator(@this);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        RefReturn.Collections.Generic.IEnumerator<T> RefReturn.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        Enumerator Typed.Collections.Generic.IEnumerable<T, Enumerator>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        RefReturn.Collections.Generic.IReadOnlyEnumerator<T> RefReturn.Collections.Generic.IReadOnlyEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        Enumerator Typed.Collections.Generic.IReadOnlyEnumerable<T, Enumerator>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List<T> GetRange(int index, int count) {
            var @this = this;
            var length = @this.buffer.Length; // null check
            if (0 <= index && 0 <= count && count <= unchecked(@this.count - index)) {
                List<T> list = new List<T>(count);
                Array.Copy(@this.buffer, index, list.buffer, 0, count);
                list.count = count;
                return list;
            }
            if (0 > index) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (0 > count) {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            {
                throw new ArgumentException();
            }
        }

        // Returns the index of the first occurrence of a given value in a range of
        // this list. The list is searched forwards from beginning to end.
        // The elements of the list are compared to the given value using the
        // Object.Equals method.
        // 
        // This method uses the Array.IndexOf method to perform the
        // search.
        // 
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item) {
            Contract.Ensures(Contract.Result<int>() >= -1);
            // Contract.Ensures(Contract.Result<int>() < Count);
            var buffer = this.buffer;
            if (null != buffer) {
                return Array.IndexOf(buffer, item, 0, this.count);
            }
            throw (NullReferenceException) null;
        }

        // TODO: ...
        // Returns the index of the first occurrence of a given value in a range of
        // this list. The list is searched forwards, starting at index
        // index and ending at count number of elements. The
        // elements of the list are compared to the given value using the
        // Object.Equals method.
        // 
        // This method uses the Array.IndexOf method to perform the
        // search.
        // 
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item, int index) {
            if (index > this.count) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            Contract.Ensures(Contract.Result<int>() >= -1);
            Contract.Ensures(Contract.Result<int>() < this.Count);
            Contract.EndContractBlock();
            return Array.IndexOf(this.buffer, item, index, this.count - index);
        }

        // Returns the index of the first occurrence of a given value in a range of
        // this list. The list is searched forwards, starting at index
        // index and up to count number of elements. The
        // elements of the list are compared to the given value using the
        // Object.Equals method.
        // 
        // This method uses the Array.IndexOf method to perform the
        // search.
        // 
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item, int index, int count) {
            if (index > this.count) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (count < 0 || index > this.count - count) {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            Contract.Ensures(Contract.Result<int>() >= -1);
            Contract.Ensures(Contract.Result<int>() < this.Count);
            Contract.EndContractBlock();
            return Array.IndexOf(this.buffer, item, index, count);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            var buffer = this.buffer;
            var count = this.count;
            for (var i = 0; count > i; ++i) {
                if (comparer.Equals(item, buffer[i])) {
                    return i;
                }
            }
            return -1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(T item) where TEqualityComparer : IEqualityComparer<T>, new() {
            return this.IndexOf(item, DefaultConstructor.Invoke<TEqualityComparer>());
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        int Typed.Collections.Generic.IList<T, Enumerator>.IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.IndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        int System.Collections.Generic.IList<T>.IndexOf(T item) {
            return this.IndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        int Typed_RefReturn.Collections.Generic.IReadOnlyList<T, Enumerator>.IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.IndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        int RefReturn.Collections.Generic.IReadOnlyList<T>.IndexOf(T item) {
            return this.IndexOf(item);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref T Insert(int index, T item) {
            var buffer = this.buffer;
            var count = this.count;
            if (unchecked((uint) index) > unchecked((uint) count)) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            Contract.EndContractBlock();
            if (count == buffer.Length) {
                this.EnsureCapacityInternal(checked(1 + count));
            }
            if (index < count) {
                Array.Copy(buffer, index, buffer, 1 + index, count - index);
            }
            ref var ret = ref buffer[index];
            ret = item;
            this.count = unchecked(1 + count);
            return ref ret;
        }

        public ref T Insert(long index, T item) {
            var buffer = this.buffer;
            var count = this.count;
            if (unchecked((uint) index) > unchecked((uint) count)) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            Contract.EndContractBlock();
            if (count == buffer.LongLength) {
                this.EnsureCapacityInternal(checked(1 + count));
            }
            if (index < count) {
                Array.Copy(buffer, index, buffer, 1 + index, count - index);
            }
            ref var ret = ref buffer[index];
            ret = item;
            this.count = unchecked(1 + count);
            return ref ret;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        ref T RefReturn_Huge.Collections.Generic.IList<T>.Insert(long index, T item) {
            return ref this.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Huge.Collections.Generic.IList<T>.Insert(long index, T item) {
            this.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        ref T RefReturn.Collections.Generic.IList<T>.Insert(int index, T item) {
            return ref this.Insert(index, item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.IList<T>.Insert(int index, T item) {
            this.Insert(index, item);
        }

        public void InsertRange(int index, IEnumerable<T> collection) {
            if (List_CompilationOptions.Checking) {
                if (null == collection) {
                    throw new ArgumentNullException(nameof(collection));
                }
            }
            this.CheckIteratorIndex(index);
            if (collection is System.Collections.Generic.ICollection<T> c) {
                int count = c.Count;
                if (count > 0) {
                    var this_count = this.count;
                    var new_count = checked(this_count + count);
                    this.EnsureCapacityInternal(new_count);
                    var buffer = this.buffer;
                    if (this_count > index) {
                        Array.Copy(buffer, index, buffer, index + count, this_count - index);
                    }
                    if (buffer == c) {
                        Array.Copy(buffer, 0, buffer, index, index);
                        Array.Copy(buffer, index + count, buffer, unchecked(index * 2), this_count - index);
                    } else {
                        var items_to_insert = new T[count];
                        c.CopyTo(items_to_insert, 0);
                        items_to_insert.CopyTo(buffer, index);
                    }
                    this.count = new_count;
                }
            } else {
                var e = collection.GetEnumerator();
                while (e.MoveNext()) {
                    this.Insert(index++, e.Current);
                }
                e.Dispose();
            }
        }

        public void InsertRange<TEnumerable, TEnumerator>(int index, TEnumerable collection)
            where TEnumerable : Typed.Collections.Generic.IEnumerable<T, TEnumerator>
            where TEnumerator : IEnumerator<T> {
            this.CheckIteratorIndex(index);
            {
                var e = collection.GetEnumerator();
                for (; e.MoveNext();) {
                    this.Insert(index++, e.Current);
                }
                e.Dispose();
            }
            return;
            {
                var e = collection.GetEnumerator();
                var new_start = this.count;
                var c = 0;
                for (; e.MoveNext(); ++c) {
                    this.Add(e.Current);
                }
                var c_remainder = new_start - index;
            }
        }

        public void InsertRangeFromCollection<TCollection, TEnumerator>(int index, TCollection collection)
            where TCollection : Typed.Collections.Generic.ICollection<T, TEnumerator>
            where TEnumerator : IEnumerator<T> {
            this.CheckIteratorIndex(index);
            var count = collection.Count;
            if (count > 0) {
                var this_count = this.count;
                var new_count = checked(this_count + count);
                this.EnsureCapacityInternal(new_count);
                var buffer = this.buffer;
                T[] items_to_insert = new T[count];
                collection.CopyTo(items_to_insert, 0);
                {
                    var t = List_CompilationOptions.Checking ? unchecked(this_count - index) : checked(this_count - index);
                    if (t > 0) {
                        Array.Copy(buffer, index, buffer, index + count, t);
                    }
                }
                items_to_insert.CopyTo(buffer, index);
                this.count = new_count;
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public long LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            var buffer = this.buffer;
            var count = this.count;
            for (var i = (long) 0; count > i; ++i) {
                if (comparer.Equals(item, buffer[i])) {
                    return i;
                }
            }
            return -1;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public long LongIndexOf(T item) {
            Contract.Ensures(Contract.Result<int>() >= -1);
            // Contract.Ensures(Contract.Result<int>() < Count);
            var buffer = this.buffer;
            if (null != buffer) {
                return Array.IndexOf(buffer, item, 0, this.count);
            }
            throw (NullReferenceException) null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        long Typed_Huge.Collections.Generic.IList<T, Enumerator>.LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.LongIndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        long Huge.Collections.Generic.IList<T>.LongIndexOf(T item) {
            return this.LongIndexOf(item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        long Typed_RefReturn_Huge.Collections.Generic.IReadOnlyList<T, Enumerator>.LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.LongIndexOf(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        long RefReturn_Huge.Collections.Generic.IReadOnlyList<T>.LongIndexOf(T item) {
            return this.LongIndexOf(item);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove(T item) {
            var index = this.IndexOf(item);
            if (0 <= index) {
                this.RemoveAt(index);
                return true;
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            var index = this.IndexOf(item, comparer);
            if (0 <= index) {
                this.RemoveAt(index);
                return true;
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer>(T item) where TEqualityComparer : struct, IEqualityComparer<T> {
            return this.Remove(item, default(TEqualityComparer));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Remove(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed.Collections.Generic.ICollection<T, Enumerator>.Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return this.Remove(item, comparer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool System.Collections.Generic.ICollection<T>.Remove(T item) {
            return this.Remove(item);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void RemoveAt(int index) {
            var count = this.count;
            if (unchecked((uint) index) >= unchecked((uint) count)) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            Contract.EndContractBlock();
            unchecked {
                --count;
            }
            var buffer = this.buffer;
            if (index < count) {
                Array.Copy(buffer, index + 1, buffer, index, count - index);
            }
            buffer[count] = default; // Good for GC.
            this.count = count;
        }

        public void RemoveAt(long index) {
            throw new NotImplementedException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Huge.Collections.Generic.IList<T>.RemoveAt(long index) {
            this.RemoveAt(index);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.IList<T>.RemoveAt(int index) {
            this.RemoveAt(index);
        }

        [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void ResetData() {
            var buffer = this.buffer;
            if (null != buffer) {
                Array.Clear(buffer, 0, buffer.Length);
            }
        }

        [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void ResetDataRange(int start, int length) {
            if (length > 0) {
                var buffer = this.buffer;
                if (null != buffer) {
                    var i = start;
                    var d = (long) start + length;
                    if (0 > i) {
                        i = 0;
                    }
                    var l = buffer.Length;
                    if (d > l) {
                        d = l;
                    }
                    Array.Clear(buffer, i, unchecked((int) d - i));
                }
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List<T> Select() {
            Contract.Ensures(!this.IsInitialized || null != Contract.Result<T[]>());
            Contract.Ensures(!this.IsInitialized || this.Count == Contract.Result<T[]>().Length);
            var buffer = this.buffer;
            var count = this.count;
            var new_buffer = new T[count];
            Array.Copy(buffer, 0, new_buffer, 0, count);
            return new List<T>(new_buffer, count);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List<TResult> Select<TResult, TSelector>(TSelector selector) where TSelector : IO.IFunc<T, TResult>, new() {
            Contract.Ensures(!this.IsInitialized || null != Contract.Result<T[]>());
            Contract.Ensures(!this.IsInitialized || this.Count == Contract.Result<T[]>().Length);
            var buffer = this.buffer;
            var count = this.count;
            return new List<TResult>(ArrayModule.Select<T, TResult, TSelector>(buffer, count, selector), count);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List<TResult> Select<TResult, TSelector>() where TSelector : IO.IFunc<T, TResult>, new() {
            Contract.Ensures(!this.IsInitialized || null != Contract.Result<T[]>());
            Contract.Ensures(!this.IsInitialized || this.Count == Contract.Result<T[]>().Length);
            return this.Select<TResult, TSelector>(DefaultConstructor.Invoke<TSelector>());
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T[] ToArray() {
            Contract.Ensures(!this.IsInitialized || null != Contract.Result<T[]>());
            Contract.Ensures(!this.IsInitialized || this.Count == Contract.Result<T[]>().Length);
            var buffer = this.buffer;
            var count = this.count;
            var array = new T[count];
            Array.Copy(buffer, 0, array, 0, count);
            return array;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T[] TransferData() {
            Contract.Ensures(null != Contract.Result<T[]>());
            this.count = 0;
            var buffer = this.buffer;
            if (null == buffer) {
                return Array_Empty<T>.Value;
            }
            this.buffer = null;
            return buffer;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void TrimExcess() {
            var count = this.count;
            var threshold = (int) (((double) this.buffer.Length) * 0.9); // null check
            if (count < threshold) {
                this.Capacity = count;
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool TrueForAll<TPredicate>(TPredicate match) where TPredicate : IPredicate<T> {
            var buffer = this.buffer;
            var count = this.count;
            for (var i = 0; count > i; ++i) {
                if (!match.Invoke(buffer[i])) {
                    return false;
                }
            }
            return true;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ListWithDefaultEqualityComparer<T, TEqualityComparer> WithEqualityComparerMoveSemantics<TEqualityComparer>() where TEqualityComparer : Huge.Collections.Generic. IEqualityComparer<T>, new() {
            return new ListWithDefaultEqualityComparer<T, TEqualityComparer>(this);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static int ComputeNewCapacity(int min, int current) {
            Contract.Requires(0 <= current);
            Contract.Ensures(Contract.Result<int>() > Contract.OldValue(current));
            var new_capacity = current == 0 ? List.default_capacity : unchecked(current * 2);
            // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
            // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
            if (unchecked((uint) new_capacity) > Internal.System.ArrayModule.MaxArrayLength) {
                new_capacity = Internal.System.ArrayModule.MaxArrayLength;
            }
            if (new_capacity < min) {
                new_capacity = min;
            }
            return new_capacity;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static long ComputeNewCapacity(long min, long current) {
            Contract.Requires(0 <= current);
            Contract.Ensures(Contract.Result<long>() > Contract.OldValue(current));
            var new_capacity = current == 0 ? List.default_capacity : unchecked(current * 2);
            // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
            // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
            if (unchecked((ulong) new_capacity) > Internal.System.ArrayModule.MaxArrayLength) {
                new_capacity = Internal.System.ArrayModule.MaxArrayLength;
            }
            if (new_capacity < min) {
                new_capacity = min;
            }
            return new_capacity;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static T[] CreateNewBuffer() {
            return new T[List.default_capacity];
        }
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        private static T[] CreateNewBuffer(int min_capacity, int current_count, T[] old) {
            Contract.Requires(0 <= current_count);
            Contract.Requires(null != old && current_count <= old.LongLength);
            // current_length may less then old.LongLength
            var new_capacity = ComputeNewCapacity(min_capacity, old.LongLength);
            var buffer = new T[new_capacity];
            Array.Copy(old, buffer, current_count);
            return buffer;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static T[] CreateNewBuffer(long min_capacity, long current_count, T[] old) {
            Contract.Requires(0 <= current_count);
            Contract.Requires(null != old && current_count <= old.LongLength);
            // current_length may less then old.LongLength
            var new_capacity = ComputeNewCapacity(min_capacity, old.LongLength);
            var buffer = new T[new_capacity];
            Array.Copy(old, buffer, current_count);
            return buffer;
        }
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIndex(int index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (unchecked(count.ToUnsignedUnchecked() <= index.ToUnsignedUnchecked())) {
                    throw CheckIndex_ArgumentOutOfRangeException();
                }
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIndex(uint index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (unchecked(count.ToUnsignedUnchecked() <= index.ToUnsignedUnchecked())) {
                    throw CheckIndex_ArgumentOutOfRangeException();
                }
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIndex(long index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (unchecked(count.ToUnsignedUnchecked() <= index.ToUnsignedUnchecked())) {
                    throw CheckIndex_ArgumentOutOfRangeException();
                }
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIndex(ulong index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (unchecked(count.ToUnsignedUnchecked() <= index.ToUnsignedUnchecked())) {
                    throw CheckIndex_ArgumentOutOfRangeException();
                }
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIndex(IntPtr index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (ComparisionHelper.LessThanOrEqual(count.ToUnsignedUnchecked(), index.ToUnsignedUnchecked())) {
                    throw CheckIndex_ArgumentOutOfRangeException();
                }
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIndex(UIntPtr index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (ComparisionHelper.LessThanOrEqual(count.ToUnsignedUnchecked(), index.ToUnsignedUnchecked())) {
                    throw CheckIndex_ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        ///     Checks the index.
        /// </summary>
        /// <param name="index"></param>
        /// <remarks>Allow <code>this.LongCount == <paramref name="index"/></code>.</remarks>
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIteratorIndex(int index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (unchecked(index.ToUnsignedUnchecked() > count.ToUnsignedUnchecked())) {
                    throw CheckIteratorIndex_ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        ///     Checks the index.
        /// </summary>
        /// <param name="index"></param>
        /// <remarks>Allow <code>this.LongCount == <paramref name="index"/></code>.</remarks>
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIteratorIndex(uint index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (unchecked(index.ToUnsignedUnchecked() > count.ToUnsignedUnchecked())) {
                    throw CheckIteratorIndex_ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        ///     Checks the index.
        /// </summary>
        /// <param name="index"></param>
        /// <remarks>Allow <code>this.LongCount == <paramref name="index"/></code>.</remarks>
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIteratorIndex(long index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (unchecked(index.ToUnsignedUnchecked() > count.ToUnsignedUnchecked())) {
                    throw CheckIteratorIndex_ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        ///     Checks the index.
        /// </summary>
        /// <param name="index"></param>
        /// <remarks>Allow <code>this.LongCount == <paramref name="index"/></code>.</remarks>
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIteratorIndex(ulong index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (unchecked(index.ToUnsignedUnchecked() > count.ToUnsignedUnchecked())) {
                    throw CheckIteratorIndex_ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        ///     Checks the index.
        /// </summary>
        /// <param name="index"></param>
        /// <remarks>Allow <code>this.LongCount == <paramref name="index"/></code>.</remarks>
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIteratorIndex(UIntPtr index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (unchecked(ComparisionHelper.GreaterThan(index.ToUnsignedUnchecked(), (ulong) count))) {
                    throw CheckIteratorIndex_ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        ///     Checks the index.
        /// </summary>
        /// <param name="index"></param>
        /// <remarks>Allow <code>this.LongCount == <paramref name="index"/></code>.</remarks>
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIteratorIndex(IntPtr index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (unchecked(ComparisionHelper.GreaterThan(index.ToUnsignedUnchecked(), (long) count))) {
                    throw CheckIteratorIndex_ArgumentOutOfRangeException();
                }
            }
        }
        /*
        public int BinarySearch(int index, int count, T item, IComparer<T> comparer) {
            if (index < 0)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            if (count < 0)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            if (this.count - index < count)
                ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
            Contract.Ensures(Contract.Result<int>() <= index + count);
            Contract.EndContractBlock();

            return Array.BinarySearch<T>(buffer, index, count, item, comparer);
        }        

        public int BinarySearch(T item) {
            Contract.Ensures(Contract.Result<int>() <= Count);
            return BinarySearch(0, Count, item, null);
        }

        public int BinarySearch(T item, IComparer<T> comparer) {
            Contract.Ensures(Contract.Result<int>() <= Count);
            return BinarySearch(0, Count, item, comparer);
        }
        */
        /*
        public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter) {
            if (converter == null) {
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.converter);
            }
            // @


            Contract.EndContractBlock();

            List<TOutput> list = new List<TOutput>(count);
            for (int i = 0; i < count; i++) {
                list.buffer[i] = converter(buffer[i]);
            }
            list.count = count;
            return list;
        }
        */
        // Ensures that the capacity of this list is at least the given minimum
        // value. If the currect capacity of the list is less than min, the
        // capacity is increased to twice the current capacity or to min,
        // whichever is larger.

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void EnsureCapacityInternal(int min) {
            var buffer = this.buffer;
            var buffer_Length = buffer.Length;
            if (min > buffer_Length) {
                var new_capacity = buffer_Length == 0 ? List.default_capacity : unchecked(buffer_Length * 2);
                // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
                // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
                if (unchecked((uint) new_capacity) > Internal.System.ArrayModule.MaxArrayLength) {
                    new_capacity = Internal.System.ArrayModule.MaxArrayLength;
                }
                if (min > new_capacity) {
                    new_capacity = min;
                }
                Array.Resize(ref this.buffer, new_capacity);
            }
        }
        /*
public bool Exists(Predicate<T> match) {
   return FindIndex(match) != -1;
}


public T Find(Predicate<T> match) {
   if (match == null) {
       ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
   }
   Contract.EndContractBlock();

   for (int i = 0; i < count; i++) {
       if (match(buffer[i])) {
           return buffer[i];
       }
   }
   return default(T);
}

public List<T> FindAll(Predicate<T> match) {
   if (match == null) {
       ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
   }
   Contract.EndContractBlock();

   List<T> list = new List<T>();
   for (int i = 0; i < count; i++) {
       if (match(buffer[i])) {
           list.Add(buffer[i]);
       }
   }
   return list;
}

public int FindIndex(Predicate<T> match) {
   Contract.Ensures(Contract.Result<int>() >= -1);
   Contract.Ensures(Contract.Result<int>() < Count);
   return FindIndex(0, count, match);
}

public int FindIndex(int startIndex, Predicate<T> match) {
   Contract.Ensures(Contract.Result<int>() >= -1);
   Contract.Ensures(Contract.Result<int>() < startIndex + Count);
   return FindIndex(startIndex, count - startIndex, match);
}

public int FindIndex(int startIndex, int count, Predicate<T> match) {
   if ((uint)startIndex > (uint)this.count) {
       ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_Index);
   }

   if (count < 0 || startIndex > this.count - count) {
       ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
   }

   if (match == null) {
       ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
   }
   Contract.Ensures(Contract.Result<int>() >= -1);
   Contract.Ensures(Contract.Result<int>() < startIndex + count);
   Contract.EndContractBlock();

   int endIndex = startIndex + count;
   for (int i = startIndex; i < endIndex; i++) {
       if (match(buffer[i])) return i;
   }
   return -1;
}

public T FindLast(Predicate<T> match) {
   if (match == null) {
       ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
   }
   Contract.EndContractBlock();

   for (int i = count - 1; i >= 0; i--) {
       if (match(buffer[i])) {
           return buffer[i];
       }
   }
   return default(T);
}

public int FindLastIndex(Predicate<T> match) {
   Contract.Ensures(Contract.Result<int>() >= -1);
   Contract.Ensures(Contract.Result<int>() < Count);
   return FindLastIndex(count - 1, count, match);
}

public int FindLastIndex(int startIndex, Predicate<T> match) {
   Contract.Ensures(Contract.Result<int>() >= -1);
   Contract.Ensures(Contract.Result<int>() <= startIndex);
   return FindLastIndex(startIndex, startIndex + 1, match);
}

public int FindLastIndex(int startIndex, int count, Predicate<T> match) {
   if (match == null) {
       ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
   }
   Contract.Ensures(Contract.Result<int>() >= -1);
   Contract.Ensures(Contract.Result<int>() <= startIndex);
   Contract.EndContractBlock();

   if (this.count == 0) {
       // Special case for 0 length List
       if (startIndex != -1) {
           ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_Index);
       }
   } else {
       // Make sure we're not out of range            
       if ((uint)startIndex >= (uint)this.count) {
           ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_Index);
       }
   }

   // 2nd have of this also catches when startIndex == MAXINT, so MAXINT - 0 + 1 == -1, which is < 0.
   if (count < 0 || startIndex - count + 1 < 0) {
       ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
   }

   int endIndex = startIndex - count;
   for (int i = startIndex; i > endIndex; i--) {
       if (match(buffer[i])) {
           return i;
       }
   }
   return -1;
}

public void ForEach(Action<T> action) {
   if (action == null) {
       ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
   }
   Contract.EndContractBlock();

   for (int i = 0; i < count; i++) {
       action(buffer[i]);
   }
}
*/
        /*
        internal virtual int IndexOf(T[] array, T value, int startIndex, int count) {
            int endIndex = startIndex + count;
            for (int i = startIndex; i < endIndex; i++) {
                if (Equals(array[i], value)) return i;
            }
            return -1;
        }

        internal virtual int LastIndexOf(T[] array, T value, int startIndex, int count) {
            int endIndex = startIndex - count + 1;
            for (int i = startIndex; i >= endIndex; i--) {
                if (Equals(array[i], value)) return i;
            }
            return -1;
        }
        */
        /*
        // Returns the index of the last occurrence of a given value in a range of
        // this list. The list is searched backwards, starting at the end 
        // and ending at the first element in the list. The elements of the list 
        // are compared to the given value using the Object.Equals method.
        // 
        // This method uses the Array.LastIndexOf method to perform the
        // search.
        // 
        public int LastIndexOf(T item) {
            Contract.Ensures(Contract.Result<int>() >= -1);
            Contract.Ensures(Contract.Result<int>() < Count);
            if (count == 0) {  // Special case for empty list
                return -1;
            } else {
                return LastIndexOf(item, count - 1, count);
            }
        }

        // Returns the index of the last occurrence of a given value in a range of
        // this list. The list is searched backwards, starting at index
        // index and ending at the first element in the list. The 
        // elements of the list are compared to the given value using the 
        // Object.Equals method.
        // 
        // This method uses the Array.LastIndexOf method to perform the
        // search.
        // 
        public int LastIndexOf(T item, int index) {
            if (index >= count)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);
            Contract.Ensures(Contract.Result<int>() >= -1);
            Contract.Ensures(((Count == 0) && (Contract.Result<int>() == -1)) || ((Count > 0) && (Contract.Result<int>() <= index)));
            Contract.EndContractBlock();
            return LastIndexOf(item, index, index + 1);
        }

        // Returns the index of the last occurrence of a given value in a range of
        // this list. The list is searched backwards, starting at index
        // index and upto count elements. The elements of
        // the list are compared to the given value using the Object.Equals
        // method.
        // 
        // This method uses the Array.LastIndexOf method to perform the
        // search.
        // 
        public int LastIndexOf(T item, int index, int count) {
            if ((Count != 0) && (index < 0)) {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            }

            if ((Count != 0) && (count < 0)) {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            }
            Contract.Ensures(Contract.Result<int>() >= -1);
            Contract.Ensures(((Count == 0) && (Contract.Result<int>() == -1)) || ((Count > 0) && (Contract.Result<int>() <= index)));
            Contract.EndContractBlock();

            if (this.count == 0) {  // Special case for empty list
                return -1;
            }

            if (index >= this.count) {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_BiggerThanCollection);
            }

            if (count > index + 1) {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_BiggerThanCollection);
            }

            return Array.LastIndexOf(buffer, item, index, count);
        }
        */
        /*
        // This method removes all items which matches the predicate.
        // The complexity is O(n).   
        public int RemoveAll(Predicate<T> match) {
            if (match == null) {
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
            }
            Contract.Ensures(Contract.Result<int>() >= 0);
            Contract.Ensures(Contract.Result<int>() <= Contract.OldValue(Count));
            Contract.EndContractBlock();

            int freeIndex = 0;   // the first free slot in items array

            // Find the first item which needs to be removed.
            while (freeIndex < count && !match(buffer[freeIndex])) freeIndex++;
            if (freeIndex >= count) return 0;

            int current = freeIndex + 1;
            while (current < count) {
                // Find the first item which needs to be kept.
                while (current < count && match(buffer[current])) current++;

                if (current < count) {
                    // copy item to the free slot.
                    buffer[freeIndex++] = buffer[current++];
                }
            }

            Array.Clear(buffer, freeIndex, count - freeIndex);
            int result = count - freeIndex;
            count = freeIndex;
            return result;
        }
        */
        /*
        // Removes a range of elements from this list.
        // 
        public void RemoveRange(int index, int count) {
            if (index < 0) {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            }

            if (count < 0) {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            }

            if (this.count - index < count)
                ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
            Contract.EndContractBlock();

            if (count > 0) {
                int i = this.count;
                this.count -= count;
                if (index < this.count) {
                    Array.Copy(this.buffer, index + count, this.buffer, index, this.count - index);
                }
                Array.Clear(this.buffer, this.count, count);
            }
        }

        // Reverses the elements in this list.
        public void Reverse() {
            Reverse(0, Count);
        }

        // Reverses the elements in a range of this list. Following a call to this
        // method, an element in the range given by index and count
        // which was previously located at index i will now be located at
        // index index + (index + count - i - 1).
        // 
        // This method uses the Array.Reverse method to reverse the
        // elements.
        // 
        public void Reverse(int index, int count) {
            if (index < 0) {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            }

            if (count < 0) {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            }

            if (this.count - index < count)
                ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
            Contract.EndContractBlock();
            Array.Reverse(buffer, index, count);
        }

        // Sorts the elements in this list.  Uses the default comparer and 
        // Array.Sort.
        public void Sort() {
            Sort(0, Count, null);
        }

        // Sorts the elements in this list.  Uses Array.Sort with the
        // provided comparer.
        public void Sort(IComparer<T> comparer) {
            Sort(0, Count, comparer);
        }

        // Sorts the elements in a section of this list. The sort compares the
        // elements to each other using the given IComparer partial interface. If
        // comparer is null, the elements are compared to each other using
        // the IComparable partial interface, which in that case must be implemented by all
        // elements of the list.
        // 
        // This method uses the Array.Sort method to sort the elements.
        // 
        public void Sort(int index, int count, IComparer<T> comparer) {
            if (index < 0) {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            }

            if (count < 0) {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            }

            if (this.count - index < count)
                ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
            Contract.EndContractBlock();

            Array.Sort<T>(buffer, index, count, comparer);
        }

        public void Sort<TComparison>(TComparison comparison) where TComparison : IFunc<T, T, int> {
            if (comparison == null) {
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
            }
            Contract.EndContractBlock();

            if (count > 0) {
                IComparer<T> comparer = new ArrayA.FunctorComparer<T>(comparison);
                Array.Sort(buffer, 0, count, comparer);
            }
        }
        */

#if NETSTANDARD2_1
        public Span<T> AsSpan(Range range) {
            // TODO: Check
            var (start, length) = range.GetOffsetAndLength(this.count);
            return this.buffer.AsSpan(start, length);
        }
        
        public Span<T> AsSpan(int start, int length) {
            // TODO: Check
            return this.buffer.AsSpan(start, length);
        }
        
        public Span<T> AsSpan(int start) {
            // TODO: Check
            return this.buffer.AsSpan(start, this.count - start);
        }

        public Span<T> AsSpan() {
            return this.buffer.AsSpan(0, this.count);
        }

        public Span<T> AsSpan(Index startIndex) {
            return this.AsSpan(startIndex.GetOffset(this.count));
        }
#endif

        /// <summary>
        ///     <para>Enumerates the elements of a <see cref="List{T}"/>. This type is a value type.</para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         The default value of <see cref="Enumerator"/> presents the empty enumerator.
        ///      </para>
        ///     <para>
        ///         Initially, the enumerator is positioned before the first element in the collection. At this position, <see cref="Current"/> is undefined.
        ///         Therefore, you must call <see cref="MoveNext"/> to advance the enumerator to the first element of the collection before reading the value of <see cref="Current"/>.
        ///         <see cref="Current"/> returns the same object until <see cref="MoveNext"/> is called. MoveNext sets <see cref="Current"/> to the next element.
        ///         If <see cref="MoveNext"/> passes the end of the collection, the enumerator is positioned after the last element in the collection and <see cref="MoveNext"/> returns false.
        ///         When the enumerator is at this position, subsequent calls to <see cref="MoveNext"/> also return false. If the last call to <see cref="MoveNext"/> returned false, <see cref="Current"/> is undefined.
        ///     </para>
        ///     <para>
        ///         An instance of <see cref="Enumerator"/> remains valid as long as <see cref="Array.Resize{T}(ref T[], int)"/> does not resize an array in-place.
        ///         If the elements of the collection are modified, the enumerator will provide modified values instead.
        ///         However the enumerator does not have exclusive access to the collection; therefore, enumerating through a collection is intrinsically not a thread-safe procedure.
        ///         To allow the collection to be accessed by multiple threads for reading and writing, you must implement your own synchronization.
        ///     </para>
        /// </remarks>
        [SerializableAttribute()]
        public partial struct Enumerator
            : System.Collections.Generic.IEnumerator<T>
            , Typed_RefReturn_Wrapped_Huge.Collections.Generic.IEnumerator<T>
            , Typed_RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyEnumerator<T> {

            private int index;

            private List<T> list;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(List<T> list) {
                this.list = list;
                this.index = -1;
            }

            T System.Collections.Generic.IEnumerator<T>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.list.buffer[this.index];
                }
            }

            public ref T Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref this.list.buffer[this.index];
                }
            }

            ref readonly T RefReturn.Collections.Generic.IReadOnlyEnumerator<T>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref this.list.buffer[this.index];
                }
            }

            /// <summary>
            ///     <para>Gets the element at the current position of the enumerator.</para>
            /// </summary>
            /// <value>
            ///     <para>The element in the <see cref="List{T}"/> at the current position of the enumerator.</para>
            /// </value>
            /// <exception cref="InvalidOperationException">
            ///     <para>
            ///         The requested operation is invalid.
            ///     </para>
            /// </exception>
            /// <exception cref="NotSupportedException">
            ///     <para>
            ///         The current position of the enumerator went beyond the bound that the internal data structure of <see cref="Enumerator"/> can support.
            ///     </para>
            /// </exception>
            /// <exception cref="OutOfMemoryException">
            ///     <para>
            ///         There is insufficient memory to satisfy the request.
            ///     </para>
            /// </exception>
            /// <exception cref="IndexOutOfRangeException">
            ///     <para>
            ///         (<c>ExceptionTypeRelaxed</c> build only.)
            ///         The requested operation is invalid. 
            ///     </para>
            /// </exception>
            /// <exception cref="NullReferenceException">
            ///     <para>
            ///         (<c>ExceptionTypeRelaxed</c> build only.)
            ///         The requested operation is invalid.
            ///     </para>
            /// </exception>
            /// <exception cref="OverflowException">
            ///     <para>
            ///         (<c>ExceptionTypeRelaxed</c> build only.)
            ///         The current position of the enumerator went beyond the bound that the internal data structure of <see cref="Enumerator"/> can support.
            ///         -or- The requested operation is invalid.
            ///     </para>
            /// </exception>
            /// <remarks>
            ///     <para>
            ///         <see cref="Current"/> is undefined under any of the following conditions:
            ///         <list type="bullet">
            ///             <item>
            ///                 The enumerator is positioned before the first element in the collection, immediately after the enumerator is created.
            ///                 <see cref="MoveNext"/> must be called to advance the enumerator to the first element of the collection before reading the value of <see cref="Current"/>.
            ///             </item>
            ///             <item>
            ///                 The last call to <see cref="MoveNext"/> returned <c lang="cs">false</c>, which indicates the end of the collection.
            ///             </item>
            ///         </list>
            ///     </para>
            ///     <para>
            ///         <see cref="Current"/> returns the same object until <see cref="MoveNext"/> is called. <see cref="MoveNext"/> sets <see cref="Current"/> to the next element.
            ///     </para>
            /// </remarks>
            object System.Collections.IEnumerator.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.list.buffer[this.index];
                }
            }

            /// <summary>
            ///     <para>Releases all resources used by the <see cref="Enumerator"/>.</para>
            /// </summary>
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Dispose() {
                // TODO
                this.list.count = 0;
                this.list.buffer = null;
            }

            /// <summary>
            ///     <para>Advances the enumerator to the next element of the <see cref="List{T}"/>.</para>
            /// </summary>
            /// <returns>
            ///     <para>
            ///         <c lang="cs">true</c> if the enumerator was successfully advanced to the next element;
            ///         <c lang="cs">false</c> if the enumerator has passed the end of the collection.
            ///     </para>
            /// </returns>
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() {
                var count = this.list.count;
                var index = this.index;
                if (count > unchecked(++index)) {
                    this.index = index;
                    return true;
                }
                return false;
            }

            /// <summary>
            ///     <para>Sets the enumerator to its initial position, which is before the first element in the collection.</para>
            /// </summary>
            /// <remarks>
            ///     <para>After calling <see cref="System.Collections.IEnumerator.Reset"/>, you must call <see cref="MoveNext"/> to advance the enumerator to the first element of the collection before reading the value of <see cref="Current"/>.</para>
            /// </remarks>
            [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Reset() {
                this.index = -1;
            }
        }
    }
}
