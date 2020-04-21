using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using static UltimateOrb.Utilities.IsNullExtensions;
using static UltimateOrb.Utilities.CollectionCountExtensions;

namespace UltimateOrb.Typed_Wrapped.Collections.Generic {

    public struct ReadOnlyListBase<T, TReadOnlyListBase>
        : IList<T, ReadOnlyListBase<T, TReadOnlyListBase>.Enumerator>, Typed_Wrapped.Collections.Generic.IReadOnlyList<T, ReadOnlyListBase<T, TReadOnlyListBase>.Enumerator>
        where TReadOnlyListBase : Core.Collections.Generic.IReadOnlyListBase<T> {
        TReadOnlyListBase _Base;

        public ReadOnlyListBase(TReadOnlyListBase @base) {
            _Base = @base;
        }

        public T this[int index] {

            get => _Base[index];
        }

        T System.Collections.Generic.IList<T>.this[int index] {

            get => _Base[index];

            set => throw new NotSupportedException();
        }

        public int Count {

            get => _Base.Count;
        }

        public bool IsReadOnly {

            get => true;
        }

        public void Add(T item) {
            throw new NotSupportedException();
        }

        public void Clear() {
            throw new NotSupportedException();
        }

        public bool Contains<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            throw new NotImplementedException();
        }

        public bool Contains(T item) {
            throw new NotImplementedException();
        }

        public void CopyTo<TList>(TList array, int arrayIndex)
            where TList : IList<T> {
            var c = this.Count;
            if (IsNullAssignable<TList>.Value && array.IsNull()) {
                throw new ArgumentNullException(nameof(array));
            }
            if (0 > arrayIndex) {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            var n = array.Count<T, TList>();
            if (c > n - arrayIndex) {
                throw new ArgumentException();
            }
            var i = arrayIndex;
            var j = 0;
            for (; n > i && c > j; ++i, ++j) {
                array[i] = this[j];
            }
        }

        public void CopyTo(Array<T> array, int arrayIndex) {
            CopyTo<Array<T>>(array, arrayIndex);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            var c = this.Count;
            if (array.IsNull()) {
                throw new ArgumentNullException(nameof(array));
            }
            if (0 > arrayIndex) {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (c > array.Length - arrayIndex) {
                throw new ArgumentException();
            }
            var i = arrayIndex;
            var j = 0;
            for (; array.Length > i && c > j; ++i, ++j) {
                array[i] = this[j];
            }
        }

        public Enumerator GetEnumerator() {
            return new Enumerator(this._Base);
        }

        public int IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            throw new NotImplementedException();
        }

        public int IndexOf(T item) {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item) {
            throw new NotSupportedException();
        }

        public bool Remove<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            throw new NotSupportedException();
        }

        public bool Remove(T item) {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index) {
            throw new NotSupportedException();
        }

        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return new Enumerator(this._Base);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return new Enumerator(this._Base);
        }

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
            , IEnumerator<T>
            , IReadOnlyEnumerator<T> {

            private TReadOnlyListBase list;

            private int index;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(TReadOnlyListBase list) {
                this.list = list;
                this.index = -1;
            }

            T System.Collections.Generic.IEnumerator<T>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.list[this.index];
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
                    return this.list[this.index];
                }
            }

            /// <summary>
            ///     <para>Releases all resources used by the <see cref="Enumerator"/>.</para>
            /// </summary>
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Dispose() {
                // TODO
                this.index = 0;
                this.list = default;
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
                var count = this.list.Count;
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
