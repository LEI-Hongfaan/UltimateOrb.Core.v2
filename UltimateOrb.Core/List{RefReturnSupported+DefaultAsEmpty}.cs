using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.ConstrainedExecution;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic.DefaultAsEmpty {
    using UltimateOrb;

    using System.Collections.ObjectModel;

    using static List_ThrowHelper;
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
        ///         Initializes a new instance of the <see cref="List{T}"/> type that is empty and has the specified initial capacity.
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
                this.buffer = ((0 == capacity) ? null : new T[capacity]);
                this.count = 0;
                return;
            }
            throw ThrowArgumentOutOfRangeException_capacity();
        }

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="List{T}"/> type that is empty and has the specified initial capacity.
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
                this.buffer = ((0 == capacity) ? null : new T[capacity]);
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
        /// <param name="ignored">
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
                        this.buffer = null;
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
                Contract.Ensures(0 <= Contract.Result<int>());
                var buffer = this.buffer;
                if (null != buffer) {
                    return buffer.Length;
                }
                return 0;
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set {
                var count = this.count;
                if (count <= value) {
                    var buffer = this.buffer;
                    if (null != buffer) {
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
                                this.buffer = null;
                                return;
                            }
                        }
                    }
                    {
                        if (value > 0) {
                            var new_buffer = new T[value];
                            this.buffer = new_buffer;
                            return;
                        }
                    }
                }
                throw ThrowArgumentOutOfRangeException_value();
            }
        }

        public int Count {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return checked((int) this.count);
            }
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
            get => false;
        }

        public long LongCount {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return this.count;
            }
        }

        private bool IsInitialized {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return true;
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

        T System.Collections.Generic.IList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                var @this = this;
                @this.CheckIndex(index);
                return @this.buffer[index];
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set {
                var @this = this;
                @this.CheckIndex(index);
                @this.buffer[index] = value;
            }
        }

        T Huge.Collections.Generic.IList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                var @this = this;
                @this.CheckIndex(index);
                return @this.buffer[index];
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set {
                var @this = this;
                @this.CheckIndex(index);
                @this.buffer[index] = value;
            }
        }

        T System.Collections.Generic.IReadOnlyList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                var @this = this;
                @this.CheckIndex(index);
                return @this.buffer[index];
            }
        }

        ref readonly T RefReturn.Collections.Generic.IReadOnlyList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                Contract.Requires(null != this.buffer);
                var @this = this;
                @this.CheckIndex(index);
                return ref @this.buffer[index];
            }
        }

        T Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                var @this = this;
                @this.CheckIndex(index);
                return @this.buffer[index];
            }
        }

        ref readonly T RefReturn_Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                Contract.Requires(null != this.buffer);
                var @this = this;
                @this.CheckIndex(index);
                return ref @this.buffer[index];
            }
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
        void System.Collections.Generic.ICollection<T>.Add(T item) {
            var buffer = this.buffer;
            var count = this.count;
            var new_count = checked(1 + count);
            if (null == buffer) {
                buffer = CreateNewBuffer();
                this.buffer = buffer;
            } else if (count == buffer.Length) {
                buffer = CreateNewBuffer(new_count, count, buffer);
                this.buffer = buffer;
            }
            buffer[count] = item;
            this.count = new_count;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref T Add(T item) {
            var buffer = this.buffer;
            var count = this.count;
            var new_count = checked(1 + count);
            if (null == buffer) {
                buffer = CreateNewBuffer();
                this.buffer = buffer;
            } else if (count == buffer.Length) {
                buffer = CreateNewBuffer(new_count, count, buffer);
                this.buffer = buffer;
            }
            ref var ret = ref buffer[count];
            ret = item;
            this.count = new_count;
            return ref ret;
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
            var count = this.count;
            if (count > 0) {
                var buffer = this.buffer;
                Array.Clear(buffer, 0, count); // Good for GC.
                this.count = 0;
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void ClearQuick() {
            this.count = 0;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item) {
            var count = this.count;
            if (count > 0) {
                var buffer = this.buffer;
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
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            var count = this.count;
            if (count > 0) {
                var buffer = this.buffer;
                for (int i = 0; i < count; i++) {
                    if (comparer.Equals(buffer[i], item)) {
                        return true;
                    }
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
            var count = this.count;
            if (count > 0) {
                var buffer = this.buffer;
                for (int i = 0; i < count; i++) {
                    if (comparer.Equals(buffer[i], item)) {
                        return true;
                    }
                }
            }
            return false;
        }
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            var count = this.count;
            if (count > 0) {
                var buffer = this.buffer;
                for (int i = 0; i < count; i++) {
                    if (comparer.Equals(buffer[i], item)) {
                        return true;
                    }
                }
            }
            return false;
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
            var this_count = this.count;
            if (count <= this_count - index) {
                // Delegate rest of error checking to Array.Copy.
                Array.Copy(this.buffer, index, array, arrayIndex, count);
                return;
            }
            throw ThrowArgumentException();
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

        /// <summary>
        ///     
        /// </summary>
        /// <param name="min"></param>
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void EnsureCapacity(int min) {
            if (0 > min) {
                var buffer = this.buffer;
                if (null == buffer) {
                    this.buffer = CreateNewBuffer();
                } else {
                    var buffer_Length = buffer.Length;
                    if (min > buffer_Length) {
                        this.buffer = CreateNewBuffer(min, this.count, buffer);
                    }
                }
                return;
            }
            throw ThrowArgumentOutOfRangeException_min(min);
        }

        public ref T GetData(int index) {
            return ref this.buffer[index];
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() {
            return new Enumerator(this);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.Generic.IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return new Enumerator(this);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return new Enumerator(this);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        RefReturn.Collections.Generic.IReadOnlyEnumerator<T> RefReturn.Collections.Generic.IReadOnlyEnumerable<T>.GetEnumerator() {
            return new Enumerator(this);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        RefReturn.Collections.Generic.IEnumerator<T> RefReturn.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return new Enumerator(this);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List<T> GetRange(int index, int count) {
            if (index < 0) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (count < 0) {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (this.count - index < count) {
                throw new ArgumentException();
            }
            // Contract.Ensures(Contract.Result<List<T>>() != null);
            Contract.EndContractBlock();

            List<T> list = new List<T>(count);
            Array.Copy(this.buffer, index, list.buffer, 0, count);
            list.count = count;
            return list;
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
            Contract.Ensures(Contract.Result<int>() < this.Count);
            var buffer = this.buffer;
            if (null != buffer) {
                var count = this.count;
                return Array.IndexOf(buffer, item, 0, count);
            }
            return -1;
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
            var count = this.count;
            if (index > count) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            Contract.Ensures(Contract.Result<int>() >= -1);
            Contract.Ensures(Contract.Result<int>() < this.Count);
            Contract.EndContractBlock();
            var buffer = this.buffer;
            if (null != buffer) {
                return Array.IndexOf(buffer, item, index, count - index);
            }
            return -1;
        }

        // Returns the index of the first occurrence of a given value in a range of
        // this list. The list is searched forwards, starting at index
        // index and upto count number of elements. The
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
            var buffer = this.buffer;
            if (null != buffer) {
                return Array.IndexOf(buffer, item, index, count);
            }
            return -1;
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

        // Inserts an element into this list at a given index. The size of the list
        // is increased by one. If required, the capacity of the list is doubled
        // before inserting the new element.
        // 
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.IList<T>.Insert(int index, T item) {
            this.CheckIteratorIndex(index);
            var count = this.count;
            var new_count = checked(1 + count);
            var buffer = this.buffer;
            if (null == buffer) {
                buffer = CreateNewBuffer();
                this.buffer = buffer;
            } else if (count == buffer.Length) {
                this.buffer = CreateNewBufferAndInsert(new_count, count, buffer, index, item);
                this.count = new_count;
                return;
            } else {
                if (count > index) {
                    Array.Copy(buffer, index, buffer, unchecked(1 + index), unchecked(count - index));
                }
            }
            {
                buffer[index] = item;
                this.count = new_count;
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref T Insert(int index, T item) {
            this.CheckIteratorIndex(index);
            var count = this.count;
            var new_count = checked(1 + count);
            var buffer = this.buffer;
            if (null == buffer) {
                buffer = CreateNewBuffer();
                this.buffer = buffer;
            } else if (count == buffer.Length) {
                buffer = CreateNewBufferAndInsert(new_count, count, buffer, index, item);
                ref var ret = ref buffer[index];
                this.buffer = buffer;
                this.count = new_count;
                return ref ret;
            } else {
                if (count > index) {
                    Array.Copy(buffer, index, buffer, unchecked(1 + index), unchecked(count - index));
                }
            }
            {
                ref var ret = ref buffer[index];
                ret = item;
                this.count = new_count;
                return ref ret;
            }
        }

        public ref T Insert(long index, T item) {
            this.CheckIteratorIndex(index);
            var count = this.count;
            var new_count = checked(1 + count);
            var buffer = this.buffer;
            if (null == buffer) {
                buffer = CreateNewBuffer();
                this.buffer = buffer;
            } else if (count == buffer.Length) {
                buffer = CreateNewBufferAndInsert(new_count, count, buffer, index, item);
                ref var ret = ref buffer[index];
                this.buffer = buffer;
                this.count = new_count;
                return ref ret;
            } else {
                if (count > index) {
                    Array.Copy(buffer, index, buffer, unchecked(1 + index), unchecked(count - index));
                }
            }
            {
                ref var ret = ref buffer[index];
                ret = item;
                this.count = new_count;
                return ref ret;
            }
        }

        void Huge.Collections.Generic.IList<T>.Insert(long index, T item) {
            this.CheckIteratorIndex(index);
            var count = this.count;
            var new_count = checked(1 + count);
            var buffer = this.buffer;
            if (null == buffer) {
                buffer = CreateNewBuffer();
                this.buffer = buffer;
            } else if (count == buffer.Length) {
                this.buffer = CreateNewBufferAndInsert(new_count, count, buffer, index, item);
                this.count = new_count;
                return;
            } else {
                if (count > index) {
                    Array.Copy(buffer, index, buffer, unchecked(1 + index), unchecked(count - index));
                }
            }
            {
                buffer[index] = item;
                this.count = new_count;
            }
        }

        public void InsertRange(int index, IEnumerable<T> collection) {
            if (List_CompilationOptions.Checking) {
                if (null == collection) {
                    throw new ArgumentNullException(nameof(collection));
                }
            }
            this.CheckIteratorIndex(index);
            if (collection is System.Collections.Generic.ICollection<T> c) {
                var count = c.Count;
                if (count > 0) {
                    var buffer = this.buffer;
                    if (null == buffer) {
                        var t = new T[count];
                        c.CopyTo(t, 0);
                        this.buffer = t;
                        this.count = count;
                        return;
                    }
                    var this_count = this.count;
                    var new_count = checked(this_count + count);
                    if (new_count > buffer.Length) {
                        var new_length = ComputeNewCapacity(new_count, buffer.Length);
                        var t = new T[new_length];
                        c.CopyTo(t, index);
                        Array.Copy(buffer, t, index);
                        {
                            var s = List_CompilationOptions.Checking ? unchecked(this_count - index) : checked(this_count - index);
                            if (s > 0) {
                                Array.Copy(buffer, index, buffer, index + count, s);
                            }
                        }
                        this.buffer = t;
                    } else {
                        var items_to_insert = new T[count];
                        c.CopyTo(items_to_insert, 0);
                        {
                            var s = List_CompilationOptions.Checking ? unchecked(this_count - index) : checked(this_count - index);
                            if (s > 0) {
                                Array.Copy(buffer, index, buffer, index + count, s);
                            }
                        }
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
            where TEnumerator : System.Collections.Generic.IEnumerator<T> {
            this.CheckIteratorIndex(index);
            var count = collection.Count;
            if (count > 0) {
                var buffer = this.buffer;
                if (null == buffer) {
                    var t = new T[count];
                    collection.CopyTo(t, 0);
                    this.buffer = t;
                    this.count = count;
                    return;
                }
                var this_count = this.count;
                var new_count = checked(this_count + count);
                if (new_count > buffer.Length) {
                    var new_length = ComputeNewCapacity(new_count, buffer.Length);
                    var t = new T[new_length];
                    collection.CopyTo(t, index);
                    Array.Copy(buffer, t, index);
                    {
                        var s = List_CompilationOptions.Checking ? unchecked(this_count - index) : checked(this_count - index);
                        if (s > 0) {
                            Array.Copy(buffer, index, buffer, index + count, s);
                        }
                    }
                    this.buffer = t;
                } else {
                    var items_to_insert = new T[count];
                    collection.CopyTo(items_to_insert, 0);
                    {
                        var s = List_CompilationOptions.Checking ? unchecked(this_count - index) : checked(this_count - index);
                        if (s > 0) {
                            Array.Copy(buffer, index, buffer, index + count, s);
                        }
                    }
                    items_to_insert.CopyTo(buffer, index);
                }
                this.count = new_count;
            }
        }

        public long LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            throw new NotImplementedException();
        }

        long Typed_Huge.Collections.Generic.IList<T, Enumerator>.LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            throw new NotImplementedException();
        }

        long Typed_RefReturn_Huge.Collections.Generic.IReadOnlyList<T, Enumerator>.LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) {
            throw new NotImplementedException();
        }

        public long LongIndexOf(T item) {
            throw new NotImplementedException();
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
        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
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

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void TrimExcess() {
            var count = this.count;
            var buffer = this.buffer;
            if (null != buffer) {
                var threshold = (int) (((double) buffer.Length) * 0.9); // null check
                if (count < threshold) {
                    this.Capacity = count;
                }
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
        private static T[] CreateNewBufferAndInsert(int min_capacity, int current_count, T[] old, int index, T item) {
            var new_capacity = ComputeNewCapacity(min_capacity, old.LongLength);
            var t = new T[new_capacity];
            Array.Copy(old, t, index);
            t[index] = item;
            Array.Copy(old, unchecked(1 + index), t, unchecked(1 + index), unchecked(current_count - index));
            return t;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        private static T[] CreateNewBufferAndInsert(long min_capacity, long current_count, T[] old, long index, T item) {
            var new_capacity = ComputeNewCapacity(min_capacity, old.LongLength);
            var t = new T[new_capacity];
            Array.Copy(old, t, index);
            t[index] = item;
            Array.Copy(old, unchecked(1 + index), t, unchecked(1 + index), unchecked(current_count - index));
            return t;
        }

        private static ArgumentOutOfRangeException ThrowArgumentOutOfRangeException_min(int min) {
            throw new ArgumentOutOfRangeException(nameof(min));
        }
        /*
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        private static ref T CreateNewBufferAndInsert(int min_capacity, int current_count, ref T[] buffer, int index, T item) {
            var new_capacity = ComputeNewCapacity(min_capacity, current_count);
            var t = new T[new_capacity];
            var old = buffer;
            Array.Copy(old, t, index);
            ref var ret = ref t[index];
            Array.Copy(old, unchecked(1 + index), t, unchecked(1 + index), unchecked(current_count - index));
            ret = item;
            buffer = t;
            return ref ret;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        private static ref T CreateNewBufferAndInsert(long min_capacity, long current_count, ref T[] buffer, long index, T item) {
            var new_capacity = ComputeNewCapacity(min_capacity, current_count);
            var t = new T[new_capacity];
            var old = buffer;
            Array.Copy(old, t, index);
            ref var ret = ref t[index];
            Array.Copy(old, unchecked(1 + index), t, unchecked(1 + index), unchecked(current_count - index));
            ret = item;
            buffer = t;
            return ref ret;
        }
        */
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIndex(int index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if ((uint) count <= unchecked((uint) index)) {
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
                if (unchecked((uint) index) > (uint) count) {
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
                if (unchecked((uint) index) > (uint) count) {
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
        /*
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ListWithDefaultEqualityComparer<T, TEqualityComparer> WithEqualityComparerMoveSemantics<TEqualityComparer>() where TEqualityComparer : struct, IEqualityComparer<T> {
            return new ListWithDefaultEqualityComparer<T, TEqualityComparer>(this);
        }
        */

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
            : IEnumerator<T>
            , IReadOnlyEnumerator<T> {

            private int index;

            private List<T> list;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(List<T> list) {
                this.list = list;
                this.index = -1;
            }

            /// <summary>
            ///     <para>Gets or sets the element at the current position of the enumerator.</para>
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
            ///         The value of this property is actually a reference (managed pointer) to the element at the current position of the enumerator.
            ///         The reference remains valid as long as the element stays in the collection and the internal data structure of the collection does not resize.
            ///         See <see cref="List{T}.Capacity"/> for more information.
            ///     </para>
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
            ref T RefReturn.Collections.Generic.IEnumerator<T>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref this.list.buffer[this.index];
                }
            }

            /// <summary>
            ///     <para>Gets or sets the element at the current position of the enumerator.</para>
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
            ///         The value of this property is actually a reference (managed pointer) to the element at the current position of the enumerator.
            ///         The reference remains valid as long as the element stays in the collection and the internal data structure of the collection does not resize.
            ///         See <see cref="List{T}.Capacity"/> for more information.
            ///     </para>
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
            public T Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.list.buffer[this.index];
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
