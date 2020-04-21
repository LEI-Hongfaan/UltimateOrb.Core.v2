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
    using Internal.System;
    using static List_ThrowHelper;

    [DebuggerDisplayAttribute("Count = {Count}")]
    [SerializableAttribute()]
    public partial struct List
        : System.Collections.Generic.IList<Void>
        , System.Collections.Generic.IReadOnlyList<Void>
        , IList<Void, List.Enumerator>
        , IReadOnlyList<Void, List.Enumerator> {

        internal const int default_capacity = 4;

        private static readonly Void @void;

        private static Void @void1;

        [ContractPublicPropertyNameAttribute("Count")]
        private long count;
        public int Count {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return checked((int) this.count);
            }
        }

        public bool IsInitialized {

            get => true;
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


        Void Huge.Collections.Generic.IList<Void>.this[long index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ref Void this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref @void1;
        }

        public ref Void this[uint index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref @void1;
        }

        public ref Void this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref @void1;
        }

        public ref Void this[ulong index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref @void1;
        }

        Void System.Collections.Generic.IList<Void>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => @void;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set {
            }
        }

        Void System.Collections.Generic.IReadOnlyList<Void>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => @void;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref Void Add(Void item) {
            this.count = checked(1 + this.count);
            return ref @void1;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.ICollection<Void>.Add(Void item) {
            this.count = checked(1 + this.count);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void AddRange(int start, int length) {
            Contract.Ensures(Contract.OldValue(this.Count) <= this.Count);
            var index = this.count;
            /*
            this.CheckIteratorIndex(start);
            this.CheckIteratorIndex(length);
            this.CheckIteratorIndex(unchecked(start + length));
            */
            var count = length;
            if (count > 0) {
                var new_count = checked(index + count);
                this.count = new_count;
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyCollection<Void> AsReadOnly() {
            Contract.Ensures(null != Contract.Result<ReadOnlyCollection<Void>>());
            return new ReadOnlyCollection<Void>(this);
        }

        public int BinarySearch(int index, int count, Void item, IComparer<Void> comparer) {
            // TODO: IMPORTANT
            /*
            if (index < 0)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            if (count < 0)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            if (this.count - index < count)
                ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
            */
            Contract.Ensures(Contract.Result<int>() <= index + count);
            Contract.EndContractBlock();
            if (count > 0) {
                return index;
            }
            return -1;
        }

        public int BinarySearch(Void item) {
            Contract.Ensures(Contract.Result<int>() <= this.Count);
            return this.BinarySearch(0, this.Count, item, null);
        }

        public int BinarySearch(Void item, IComparer<Void> comparer) {
            Contract.Ensures(Contract.Result<int>() <= this.Count);
            return this.BinarySearch(0, this.Count, item, comparer);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Clear() {
            this.count = 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains(Void item) {
            return this.count > 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(Void[] array, int start) {
            if (List_CompilationOptions.Checking) {
                if (null == array) {
                    throw new ArgumentNullException(nameof(array));
                }
                if (0 > start) {
                    throw new ArgumentOutOfRangeException(nameof(start));
                }
                var end = array.Length;
                if (end - this.count < start) {
                    // TODO
                    throw new ArgumentException();
                }
            }
        }

        public void CopyTo(Void[] array, long arrayIndex) {
            if (List_CompilationOptions.Checking) {
                if (null == array) {
                    throw new ArgumentNullException(nameof(array));
                }
                if (0 > arrayIndex) {
                    throw new ArgumentOutOfRangeException(nameof(arrayIndex));
                }
                var end = array.Length;
                if (end - this.count < arrayIndex) {
                    // TODO
                    throw new ArgumentException();
                }
            }
        }

        public void CopyTo(Array<Void> array, int arrayIndex) {
            this.CopyTo(array.Value, arrayIndex);
        }

        public void CopyTo(Array<Void> array, long arrayIndex) {
            this.CopyTo(array.Value, arrayIndex);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() {
            return new Enumerator();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.Generic.IEnumerator<Void> IEnumerable<Void>.GetEnumerator() {
            return new Enumerator();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        IEnumerator IEnumerable.GetEnumerator() {
            return new Enumerator();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(Void item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Void> {
            if (this.count > 0) {
                return 0;
            }
            return -1;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(Void item) {
            if (this.count > 0) {
                return 0;
            }
            return -1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(Void item) where TEqualityComparer : IEqualityComparer<Void>, new() {
            if (this.count > 0) {
                return 0;
            }
            return -1;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref Void Insert(int index, Void item) {
            this.count = checked(1 + this.count);
            return ref @void1;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref Void Insert(long index, Void item) {
            this.count = checked(1 + this.count);
            return ref @void1;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void System.Collections.Generic.IList<Void>.Insert(int index, Void item) {
            var count = this.count;
            if (List_CompilationOptions.Checking) {
                if (unchecked((uint) index) > unchecked((uint) count)) {
                    throw CheckIteratorIndex_ArgumentOutOfRangeException();
                }
            }
            this.count = checked(1 + count);
        }

        public long LongIndexOf(Void item) {
            var count = this.count;
            if (count > 0) {
                return 0;
            }
            return -1;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer>(Void item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Void> {
            var count = this.count;
            if (count > 0) {
                this.count = unchecked(count - 1);
                return true;
            }
            return false;
        }

        Void Huge.Collections.Generic.IReadOnlyList<Void>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => @void;
        }

        ref readonly Void RefReturn.Collections.Generic.IReadOnlyList<Void>.this[int index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref @void;
        }

        ref readonly Void RefReturn_Huge.Collections.Generic.IReadOnlyList<Void>.this[long index] {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref @void;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains<TEqualityComparer>(Void item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Void> {
            return this.count > 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_RefReturn_Huge.Collections.Generic.IReadOnlyCollection<Void, Enumerator>.Contains<TEqualityComparer>(Void item, TEqualityComparer comparer) {
            return this.count > 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_Huge.Collections.Generic.ICollection<Void, Enumerator>.Contains<TEqualityComparer>(Void item, TEqualityComparer comparer) {
            return this.count > 0;
        }

        void Huge.Collections.Generic.IList<Void>.Insert(long index, Void item) {
            var count = this.count;
            if (List_CompilationOptions.Checking) {
                if (unchecked((uint) index) > unchecked((uint) count)) {
                    throw CheckIteratorIndex_ArgumentOutOfRangeException();
                }
            }
            this.count = checked(1 + count);
        }

        public long LongIndexOf<TEqualityComparer>(Void item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Void> {
            var count = this.count;
            if (count > 0) {
                return 0;
            }
            return -1;
        }
        long Typed_Huge.Collections.Generic.IList<Void, Enumerator>.LongIndexOf<TEqualityComparer>(Void item, TEqualityComparer comparer) {
            var count = this.count;
            if (count > 0) {
                return 0;
            }
            return -1;
        }

        long Typed_RefReturn_Huge.Collections.Generic.IReadOnlyList<Void, Enumerator>.LongIndexOf<TEqualityComparer>(Void item, TEqualityComparer comparer) {
            var count = this.count;
            if (count > 0) {
                return 0;
            }
            return -1;
        }


        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        bool Typed_Huge.Collections.Generic.ICollection<Void, Enumerator>.Remove<TEqualityComparer>(Void item, TEqualityComparer comparer) {
            var count = this.count;
            if (count > 0) {
                this.count = unchecked(count - 1);
                return true;
            }
            return false;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove(Void item) {
            var count = this.count;
            if (count > 0) {
                this.count = unchecked(count - 1);
                return true;
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer>(Void item) where TEqualityComparer : struct, IEqualityComparer<Void> {
            var count = this.count;
            if (count > 0) {
                unchecked {
                    --count;
                }
                this.count = count;
                return true;
            }
            return false;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void RemoveAt(int index) {
            Contract.Requires(0 <= index);
            Contract.Requires(this.count > index);
            var count = this.count;
            if (List_CompilationOptions.Checking) {
                if (unchecked((uint) count) <= unchecked((uint) index)) {
                    throw CheckIndex_ArgumentOutOfRangeException();
                }
            }
            count = unchecked(count - 1);
            this.count = count;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void RemoveAt(long index) {
            Contract.Requires(0 <= index);
            Contract.Requires(this.count > index);
            var count = this.count;
            if (List_CompilationOptions.Checking) {
                if (unchecked((uint) count) <= unchecked((uint) index)) {
                    throw CheckIndex_ArgumentOutOfRangeException();
                }
            }
            count = unchecked(count - 1);
            this.count = count;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List<TResult> Select<TResult, TSelector>() where TSelector : IO.IFunc<Void, TResult>, new() {
            Contract.Ensures(!this.IsInitialized || null != Contract.Result<Void[]>());
            Contract.Ensures(!this.IsInitialized || this.Count == Contract.Result<Void[]>().Length);
            return this.Select<TResult, TSelector>(DefaultConstructor.Invoke<TSelector>());
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public List<TResult> Select<TResult, TSelector>(TSelector selector) where TSelector : IO.IFunc<Void, TResult>, new() {
            Contract.Ensures(!this.IsInitialized || null != Contract.Result<Void[]>());
            Contract.Ensures(!this.IsInitialized || this.Count == Contract.Result<Void[]>().Length);
            var count = this.count;
            if (count > 0) {
                var v = selector.Invoke(default);
                var a = new List<TResult>(count) {
                    [0] = v
                };
                for (var i = 1; count > i; ++i) {
                    a[i] = v;
                }
                return a;
            }
            return new List<TResult>(0);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Void[] ToArray() {
            Contract.Ensures(!this.IsInitialized || null != Contract.Result<Void[]>());
            Contract.Ensures(!this.IsInitialized || this.Count == Contract.Result<Void[]>().Length);
            var count = this.count;
            if (count > 0) {
                return new Void[count];
            }
            return Array_Empty<Void>.Value;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void TrimExcess() {
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool TrueForAll<TPredicate>(TPredicate match) where TPredicate : IPredicate<Void> {
            var count = this.count;
            if (count > 0) {
                if (!match.Invoke(default)) {
                    return false;
                }
            }
            return true;
        }

        RefReturn.Collections.Generic.IEnumerator<Void> RefReturn.Collections.Generic.IEnumerable<Void>.GetEnumerator() {
            return new Enumerator();
        }

        RefReturn.Collections.Generic.IReadOnlyEnumerator<Void> RefReturn.Collections.Generic.IReadOnlyEnumerable<Void>.GetEnumerator() {
            return new Enumerator();
        }


        /// <summary>
        ///     <para>Enumerates the elements of a <see cref="List{Void}"/>. This type is a value type.</para>
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
        ///         An instance of <see cref="Enumerator"/> remains valid as long as <see cref="Array.Resize{Void}(ref Void[], int)"/> does not resize an array in-place.
        ///         If the elements of the collection are modified, the enumerator will provide modified values instead.
        ///         However the enumerator does not have exclusive access to the collection; therefore, enumerating through a collection is intrinsically not a thread-safe procedure.
        ///         To allow the collection to be accessed by multiple threads for reading and writing, you must implement your own synchronization.
        ///     </para>
        /// </remarks>
        [SerializableAttribute()]
        public partial struct Enumerator
            : IEnumerator<Void>
            , IReadOnlyEnumerator<Void> {

            private static readonly object void_boxed = default(Void);
            private readonly List list;

            private int index;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(List list) {
                this.list = list;
                this.index = -1;
            }

            public Void Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return default;
                }
            }

            ref readonly Void RefReturn.Collections.Generic.IReadOnlyEnumerator<Void>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref @void;
                }
            }

            ref Void RefReturn.Collections.Generic.IEnumerator<Void>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref @void1;
                }
            }

            object System.Collections.IEnumerator.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    if (List_CompilationOptions.Checking) {
                        if (unchecked((uint) this.list.count) <= unchecked((uint) this.index)) {
                            throw new InvalidOperationException();
                        }
                    }
                    return void_boxed;
                }
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

            [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Reset() {
                this.index = -1;
            }
        }
    }
}
