using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Collections.ObjectModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;

    using System.Collections;
    using Internal.System;
    using Internal.System.Collections.Generic;
    using static List_ThrowHelper;

    /// <summary>
    ///     <para>Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists. This type is a value type.</para>
    /// </summary>
    /// <typeparam name="T">
    ///     <para>The type of elements in the list.</para>
    /// </typeparam>
    [DebuggerDisplayAttribute("Count = {Count}")]
    [SerializableAttribute()]
    public partial struct List<T>
            : IList<T, List<T>.Enumerator>, IReadOnlyList<T, List<T>.Enumerator> {

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
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List(int capacity) {
            if (0 <= capacity) {
                this.buffer = (capacity > 0 ? Array_Empty<T>.Value : new T[capacity]);
                this.count = 0;
                return;
            }
            throw ThrowArgumentOutOfRangeException_capacity();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private List(T[] buffer, int count) {
            this.buffer = buffer;
            this.count = count;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static List<T> CreateFromCollection<TCollection, TEnumerator>(TCollection collection)
            where TCollection : ICollection<T, TEnumerator>
            where TEnumerator : IEnumerator<T> {
            var count = collection.Count;
            if (count > 0) {
                var buffer = new T[count];
                collection.CopyTo(buffer, 0);
                return new List<T>(buffer, count);
            }
            return new List<T>(0);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static List<T> Create<TEnumerable, TEnumerator>(TEnumerable collection)
            where TEnumerable : IEnumerable<T, TEnumerator>
            where TEnumerator : IEnumerator<T> {
            var @this = new List<T>(0);
            var e = collection.GetEnumerator();
            while (e.MoveNext()) {
                @this.Add(e.Current);
            }
            e.Dispose();
            return @this;
        }

        public List(IEnumerable<T> collection) {
            if (null != collection) {
                if (collection is ICollection<T> c) {
                    int count = c.Count;
                    if (count == 0) {
                        this.buffer = Array_Empty<T>.Value;
                        this.count = 0;
                        return;
                    } else {
                        var buffer = new T[count];
                        c.CopyTo(buffer, 0);
                        this.buffer = buffer;
                        this.count = count;
                        return;
                    }
                } else {
                    this = new List<T>(Array_Empty<T>.Value, 0);
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

        public int Capacity {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                Contract.Requires(this.Initialized);
                Contract.EnsuresOnThrow<NullReferenceException>(Contract.OldValue(this.Initialized));
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
                            } else {
                                this.buffer = Array_Empty<T>.Value;
                            }
                        }
                    }
                    throw ThrowArgumentOutOfRangeException_value();
                }
                throw (NullReferenceException)null;
            }
        }

        public int Count {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                if (null != this.buffer) {
                    return checked((int)this.count);
                }
                throw (NullReferenceException)null;
            }
        }

        public long LongCount {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                if (null != this.buffer) {
                    return this.count;
                }
                throw (NullReferenceException)null;
            }
        }

        public bool IsReadOnly {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                if (null != this.buffer) {
                    return false;
                }
                throw (NullReferenceException)null;
            }
        }

        public ref T this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                var @this = this;
                @this.CheckIndex(index);
                return ref @this.buffer[index];
            }
        }

        T IList<T>.this[int index] {

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

        T IReadOnlyList<T>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                var @this = this;
                @this.CheckIndex(index);
                return @this.buffer[index];
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIndex(int index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if ((uint)count <= unchecked((uint)index)) {
                    throw CheckIndex_ArgumentOutOfRangeException();
                }
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void CheckIteratorIndex(int index) {
            if (List_CompilationOptions.Checking) {
                var count = this.count;
                if (unchecked((uint)index) > (uint)count) {
                    throw CheckIteratorIndex_ArgumentOutOfRangeException();
                }
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void ICollection<T>.Add(T item) {
            var @this = this;
            if (null != @this.buffer) {
                var c = @this.count;
                checked {
                    ++c;
                }
                if (c <= @this.buffer.Length) {
                    @this.buffer[@this.count] = item;
                    this.count = c;
                    return;
                }
                {
                    @this.EnsureCapacity(c);
                    @this.buffer[@this.count] = item;
                    this.buffer = @this.buffer;
                    this.count = c;
                    return;
                }
            }
            throw (NullReferenceException)null;
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
                    @this.EnsureCapacity(c);
                    ref var result = ref @this.buffer[@this.count];
                    result = item;
                    this.buffer = @this.buffer;
                    this.count = c;
                    return ref result;
                }
            }
            throw (NullReferenceException)null;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void AddRange(IEnumerable<T> collection) {
            Contract.Ensures(Count >= Contract.OldValue(Count));
            this.InsertRange(count, collection);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyCollection<T> AsReadOnly() {
            Contract.Ensures(Contract.Result<ReadOnlyCollection<T>>() != null);
            return new ReadOnlyCollection<T>(this);
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
            throw (NullReferenceException)null;
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
        public bool Contains<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
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
            where TEqualityComparer : struct, IEqualityComparer<T> {
            return this.Contains(default(TEqualityComparer), item);
        }

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
            Array.Copy(buffer, 0, array, arrayIndex, count);
        }

        // Ensures that the capacity of this list is at least the given minimum
        // value. If the currect capacity of the list is less than min, the
        // capacity is increased to twice the current capacity or to min,
        // whichever is larger.

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private void EnsureCapacity(int min) {
            var buffer = this.buffer;
            var buffer_Length = buffer.Length;
            if (min > buffer_Length) {
                var new_capacity = buffer_Length == 0 ? List.default_capacity : unchecked(buffer_Length * 2);
                // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
                // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
                if (unchecked((uint)new_capacity) > Internal.System.ArrayModule.MaxArrayLength) {
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

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() {
            var @this = this;
            var length = @this.buffer.Length; // null check
            return new Enumerator(@this);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.Generic.IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
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

        // TODO: ...

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
                return Array.IndexOf(buffer, item, 0, count);
            }
            throw (NullReferenceException)null;
        }

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
            if (index > count) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            Contract.Ensures(Contract.Result<int>() >= -1);
            Contract.Ensures(Contract.Result<int>() < Count);
            Contract.EndContractBlock();
            return Array.IndexOf(buffer, item, index, count - index);
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
            Contract.Ensures(Contract.Result<int>() < Count);
            Contract.EndContractBlock();
            return Array.IndexOf(buffer, item, index, count);
        }

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

        // Inserts an element into this list at a given index. The size of the list
        // is increased by one. If required, the capacity of the list is doubled
        // before inserting the new element.
        // 
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void IList<T>.Insert(int index, T item) {
            this.CheckIteratorIndex(index);
            Contract.EndContractBlock();
            if (count == buffer.Length) {
                this.EnsureCapacity(1 + count);
            }
            if (index < count) {
                Array.Copy(buffer, index, buffer, 1 + index, count - index);
            }
            buffer[index] = item;
            count++;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref T Insert(int index, T item) {
            var buffer = this.buffer;
            var count = this.count;
            if (unchecked((uint)index) > unchecked((uint)count)) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            Contract.EndContractBlock();
            if (count == buffer.Length) {
                this.EnsureCapacity(1 + count);
            }
            if (index < count) {
                Array.Copy(buffer, index, buffer, 1 + index, count - index);
            }
            ref var ret = ref buffer[index];
            ret = item;
            this.count = unchecked(1 + count);
            return ref ret;
        }

        public void InsertRange(int index, IEnumerable<T> collection) {
            if (List_CompilationOptions.Checking) {
                if (null == collection) {
                    throw new ArgumentNullException(nameof(collection));
                }
            }
            this.CheckIteratorIndex(index);
            if (collection is ICollection<T> c) {
                int count = c.Count;
                if (count > 0) {
                    var this_count = this.count;
                    var new_count = checked(this_count + count);
                    this.EnsureCapacity(new_count);
                    var buffer = this.buffer;
                    if (this_count > index) {
                        Array.Copy(buffer, index, buffer, index + count, this_count - index);
                    }
                    if (buffer == c) {
                        Array.Copy(buffer, 0, buffer, index, index);
                        Array.Copy(buffer, index + count, buffer, unchecked(index * 2), this_count - index);
                    } else {
                        T[] items_to_insert = new T[count];
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
            where TEnumerable : IEnumerable<T, TEnumerator>
            where TEnumerator : IEnumerator<T> {
            this.CheckIteratorIndex(index);
            Contract.EndContractBlock();
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
            where TCollection : ICollection<T, TEnumerator>
            where TEnumerator : IEnumerator<T> {
            this.CheckIteratorIndex(index);
            var count = collection.Count;
            if (count > 0) {
                var this_count = this.count;
                var new_count = checked(this_count + count);
                this.EnsureCapacity(new_count);
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

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void RemoveAt(int index) {
            var count = this.count;
            if (unchecked((uint)index) >= unchecked((uint)count)) {
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
            buffer[count] = default(T); // Good for GC.
            this.count = count;
        }

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

        private bool Initialized {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return null == this.buffer;
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List<T> Select() {
            Contract.Ensures(!this.Initialized || null != Contract.Result<T[]>());
            Contract.Ensures(!this.Initialized || this.Count == Contract.Result<T[]>().Length);
            var buffer = this.buffer;
            var count = this.count;
            var new_buffer = new T[count];
            Array.Copy(buffer, 0, new_buffer, 0, count);
            return new List<T>(new_buffer, count);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List<TResult> Select<TResult, TSelector>(TSelector selector) where TSelector : IO.IFunc<T, TResult>, new() {
            Contract.Ensures(!this.Initialized || null != Contract.Result<T[]>());
            Contract.Ensures(!this.Initialized || this.Count == Contract.Result<T[]>().Length);
            var buffer = this.buffer;
            var count = this.count;
            return new List<TResult>(ArrayModule<T>.Select<TResult, TSelector>(buffer, count, selector), count);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List<TResult> Select<TResult, TSelector>() where TSelector : IO.IFunc<T, TResult>, new() {
            Contract.Ensures(!this.Initialized || null != Contract.Result<T[]>());
            Contract.Ensures(!this.Initialized || this.Count == Contract.Result<T[]>().Length);
            return this.Select<TResult, TSelector>(DefaultConstructor.Invoke<TSelector>());
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T[] ToArray() {
            Contract.Ensures(!this.Initialized || null != Contract.Result<T[]>());
            Contract.Ensures(!this.Initialized || this.Count == Contract.Result<T[]>().Length);
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
            var threshold = (int)(((double)buffer.Length) * 0.9);
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

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
            var buffer = this.buffer;
            for (var i = 0; buffer.Length > i; ++i) {
                if (comparer.Equals(item, buffer[i])) {
                    return i;
                }
            }
            return -1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(T item) where TEqualityComparer : IEqualityComparer<T>, new() {
            return this.IndexOf(DefaultConstructor.Invoke<TEqualityComparer>(), item);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
            var index = this.IndexOf(comparer, item);
            if (0 <= index) {
                this.RemoveAt(index);
                return true;
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer>(T item) where TEqualityComparer : struct, IEqualityComparer<T> {
            return this.Remove(default(TEqualityComparer), item);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ListWithDefaultEqualityComparer<T, TEqualityComparer> WithEqualityComparerMoveSemantics<TEqualityComparer>() where TEqualityComparer : struct, IEqualityComparer<T> {
            return new ListWithDefaultEqualityComparer<T, TEqualityComparer>(this);
        }

        [SerializableAttribute()]
        public partial struct Enumerator : IEnumerator<T> {

            private List<T> list;

            private int index;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(List<T> list) {
                this.list = list;
                this.index = -1;
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Dispose() {
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() {
                var list = this.list;
                var index = this.index;
                if (list.count > unchecked(++index)) {
                    this.index = index;
                    return true;
                }
                return false;
            }

            public T Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.list.buffer[this.index];
                }
            }

            ref T IEnumerator<T>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref this.list.buffer[this.index];
                }
            }

            object System.Collections.IEnumerator.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.list.buffer[this.index];
                }
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            void System.Collections.IEnumerator.Reset() {
                this.index = -1;
            }
        }
    }
}
