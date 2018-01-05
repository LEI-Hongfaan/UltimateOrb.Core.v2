using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using UltimateOrb.Collections.Generic.RefReturnSupported;

namespace UltimateOrb.Plain.ValueTypes.NoThrow {

    /// <summary>
    ///     <para>Represents a variable size last-in-first-out (LIFO) collection of instances of the same specified type. This type is a value type.</para>
    /// </summary>
    /// <typeparam name="T">
    ///     <para>Specifies the type of elements in the stack.</para>
    /// </typeparam>
    /// <remarks>
    ///     <para>Value assignments of the <see cref="Stack{T}"/> have move semantics.</para>
    /// </remarks>
    public partial struct Stack<T> : IStack_1_1<T>, IStackEx<T> {

        public T[] buffer;

        public int count0;

        /// <summary>
        ///     <para>Sets the total number of elements the internal data structure can hold without resizing.</para>
        /// </summary>
        /// <param name="capacity">
        ///     <para>The new capacity.</para>
        /// </param>
        /// <exception cref="OutOfMemoryException">
        ///     <para>There is insufficient memory to satisfy the request.</para>
        /// </exception>
        /// <remarks>
        ///     <para>Sets this instance to dummy value if <paramref name="capacity"/> is negative.</para>
        /// </remarks>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void SetCapacity(int capacity) {
            ref var buffer = ref this.buffer;
            if (0 <= capacity) {
                if (capacity > 0) {
                    Array.Resize(ref buffer, capacity);
                } else {
                    buffer = Array_Empty<T>.Value;
                }
                if (capacity < count0) {
                    count0 = capacity;
                }
                return;
            }
            buffer = null;
            count0 = 0;
        }

        /// <summary>
        ///     <para>Increases the total number of elements the internal data structure can hold without resizing.</para>
        /// </summary>
        /// <exception cref="OverflowException">
        ///     <para>The resulting number of elements contained in the <see cref="Stack{T}"/> can not be represented in the internal data type. -or- There is insufficient memory to satisfy the request.</para>
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        ///     <para>There is insufficient memory to satisfy the request.</para>
        /// </exception>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void IncreaseCapacity() {
            Array.Resize(ref this.buffer, checked((int)(22 + 1.6180339887498948482045868343656 * this.count0)));
        }

        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="Stack{T}"/> type that is empty and has an initial capacity at least the value specified.</para>
        /// </summary>
        /// <param name="capacity">
        ///     <para>The initial number of elements that the <see cref="Stack{T}"/> can contain.</para>
        /// </param>
        /// <exception cref="OutOfMemoryException">
        ///     <para>There is insufficient memory to satisfy the request.</para>
        /// </exception>
        /// <remarks>
        ///     <para>Initializes to a dummy value if <paramref name="capacity"/> is negative.</para>
        /// </remarks>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Stack(int capacity) {
            if (0 <= capacity) {
                this.buffer = capacity > 0 ? Array_Empty<T>.Value : new T[capacity];
                this.count0 = 0;
                return;
            }
            buffer = null;
            count0 = 0;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Stack(T[] buffer, int count) {
            this.buffer = buffer;
            this.count0 = count;
        }

        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="Stack{T}"/> type that is empty and has the default initial capacity.</para>
        /// </summary>
        /// <exception cref="OutOfMemoryException">
        ///     <para>There is insufficient memory to satisfy the request.</para>
        /// </exception>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Stack<T> Create() {
            return new Stack<T>(20);
        }

        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="Stack{T}"/> type that is empty and has an initial capacity at least the value specified.</para>
        /// </summary>
        /// <param name="capacity">
        ///     <para>The initial number of elements that the <see cref="Stack{T}"/> can contain.</para>
        /// </param>
        /// <exception cref="OutOfMemoryException">
        ///     <para>There is insufficient memory to satisfy the request.</para>
        /// </exception>
        /// <remarks>
        ///     <para>A dummy value is returned if <paramref name="capacity"/> is negative.</para>
        /// </remarks>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Stack<T> Create(int capacity) {
            return new Stack<T>(capacity);
        }

        /// <summary>
        ///     <para>Inserts an object at the top of the <see cref="Stack{T}"/>.</para>
        /// </summary>
        /// <param name="item">
        ///     <para>The object to push onto the <see cref="Stack{T}"/>. The value can be null for reference types.</para>
        /// </param>
        /// <exception cref="OverflowException">
        ///     <para>The resulting number of elements contained in the <see cref="Stack{T}"/> can not be represented in the internal data type. -or- There is insufficient memory to satisfy the request.</para>
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        ///     <para>There is insufficient memory to satisfy the request.</para>
        /// </exception>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Push(T item) {
            var @this = this;
            var c = checked(@this.count0 + 1);
            if (null == @this.buffer || c > buffer.Length) {
                @this.IncreaseCapacity();
                @this.buffer[unchecked(c - 1)] = item;
                this.buffer = @this.buffer;
                this.count0 = c;
                return;
            }
            {
                @this.buffer[unchecked(c - 1)] = item;
                this.count0 = c;
                return;
            }
        }

        /// <summary>
        ///     <para>Inserts a dummy value of type <typeparamref name="T"/> at the top of <see cref="Stack{T}"/>.</para>
        /// </summary>
        /// <returns>
        ///     <para>A value of type ref <typeparamref name="T"/> (managed pointer to type <typeparamref name="T"/>) can be used to store the object being insert.</para>
        /// </returns>
        /// <exception cref="OverflowException">
        ///     <para>The resulting number of elements contained in the <see cref="Stack{T}"/> can not be represented in the internal data type. -or- There is insufficient memory to satisfy the request.</para>
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        ///     <para>There is insufficient memory to satisfy the request.</para>
        /// </exception>
        /// <remarks>
        ///     <para>Must store the object through the return value before any subsequent modification to the collection.</para>
        /// </remarks>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref T Push() {
            var c = checked(this.count0 + 1);
            var buffer = this.buffer;
            if (null == buffer || c > buffer.Length) {
                this.IncreaseCapacity();
            }
            this.count0 = c;
            return ref buffer[unchecked(c - 1)];
        }

        /// <summary>
        ///     <para>Removes and returns the object at the top of the <see cref="Stack{T}"/>.</para>
        /// </summary>
        /// <returns>
        ///     <para>The object removed from the top of the <see cref="Stack{T}"/>.</para>
        /// </returns>
        /// <remarks>
        ///     <para>A dummy value is returned if the stack is empty. The value can be null for reference types.</para>
        /// </remarks>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T Pop() {
            var a = this.count0;
            if (0 < a) {
                unchecked {
                    --a;
                }
                this.count0 = a;
                return this.buffer[a];
            }
            return default(T);
        }

        /// <summary>
        ///     <para>Returns the object at the top of the <see cref="Stack{T}"/> without removing it.</para>
        /// </summary>
        /// <returns>
        ///     <para>The object at the top of the <see cref="Stack{T}"/>.</para>
        /// </returns>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref T Peek() {
            var a = unchecked(this.count0 - 1);
            if (0 <= a) {
                return ref this.buffer[a];
            }
            return ref Dummy<T>.Value;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        T UltimateOrb.Collections.Generic.IStack<T>.Peek() {
            var a = unchecked(this.count0 - 1);
            if (0 <= a) {
                return this.buffer[a];
            }
            return default(T);
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool TryPush(T item) {
            var c = checked(this.count0 + 1);
            var buffer = this.buffer;
            if (null == buffer || c > buffer.Length) {
                try {
                    this.IncreaseCapacity();
                } catch (Exception) {
                    return false;
                }
                this.buffer[unchecked(c - 1)] = item;
                this.count0 = c;
                return true;
            }
            buffer[unchecked(c - 1)] = item;
            this.count0 = c;
            return true;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool TryPeek(out T item) {
            var a = unchecked(this.count0 - 1);
            if (0 <= a) {
                item = this.buffer[a];
                return true;
            }
            item = default(T);
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool TryPop(out T item) {
            var a = this.count0;
            if (a > 0) {
                unchecked {
                    --a;
                }
                this.count0 = a;
                item = this.buffer[a];
                return true;
            }
            item = default(T);
            return false;
        }

        /// <summary>
        ///     <para>Gets the number of elements contained in the <see cref="Stack{T}"/>.</para>
        /// </summary>
        /// <returns>
        ///     <para>The number of elements contained in the <see cref="Stack{T}"/>.</para>
        /// </returns>
        /// <exception cref="OverflowException">
        ///     <para>The result can not be represented in the result type.</para>
        /// </exception>
        public int Count {

            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return checked((int)this.count0);
            }
        }

        /// <summary>
        ///     <para>Gets the number of elements contained in the <see cref="Stack{T}"/>.</para>
        /// </summary>
        /// <returns>
        ///     <para>The number of elements contained in the <see cref="Stack{T}"/>.</para>
        /// </returns>
        public long LongCount {

            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return this.count0;
            }
        }

        public bool IsEmpty {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => 0 == this.count0;
        }

        public bool IsFinite {

            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => true;
        }

        private struct MoveFunctor : IO.IFunc<T, T> {

            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public T Invoke(T arg) {
                return arg;
            }
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Stack<T> Select() => Select<T, MoveFunctor>();
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Stack<TResult> Select<TResult, TSelector>(TSelector selector) where TSelector : IO.IFunc<T, TResult> {
            var c = this.count0;
            var b = this.buffer;
            var a = new TResult[c];
            for (var i = 0; c > i && buffer.Length > i; ++i) {
                a[i] = selector.Invoke(b[i]);
            }
            return new Stack<TResult>(a, c);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Stack<TResult> Select<TResult, TSelector>() where TSelector : IO.IFunc<T, TResult>, new() => this.Select<TResult, TSelector>(DefaultConstructor.Invoke<TSelector>());
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T[] ToArray() => ToArray<T, MoveFunctor>();
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public TResult[] ToArray<TResult, TSelector>(TSelector selector) where TSelector : IO.IFunc<T, TResult> {
            var a = this.buffer;
            if (null != a) {
                var c = this.count0;
                var r = new TResult[c];
                {
                    var i = c;
                    var j = 0;
                    for (; a.Length > j && i > 0;) {
                        r[--i] = selector.Invoke(a[j++]);
                    }
                }
                return r;
            }
            throw (NullReferenceException)null;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public TResult[] ToArray<TResult, TSelector>() where TSelector : IO.IFunc<T, TResult>, new() => this.ToArray<TResult, TSelector>(DefaultConstructor.Invoke<TSelector>());

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void Collections.Generic.IStack_1<T>.Pop() {
            var a = this.count0;
            if (0 < a) {
                unchecked {
                    --a;
                }
                this.count0 = a;
            }
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T PeekPop() {
            return this.Pop();
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void PopPush(T item) {
            this.Peek() = item;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T PeekPopPush(T item) {
            var a = unchecked(this.count0 - 1);
            if (0 <= a) {
                var b = this.buffer;
                var result = b[a];
                b[a] = item;
                return result;
            }
            return default;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool TryPop() {
            var a = this.count0;
            if (0 < a) {
                unchecked {
                    --a;
                }
                this.count0 = a;
                return true;
            }
            return false;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool TryPeekPop(out T result) {
            var a = this.count0;
            if (0 < a) {
                unchecked {
                    --a;
                }
                this.count0 = a;
                result = this.buffer[a];
                return true;
            }
            result = default;
            return false;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool TryPopPush(T item) {
            this.PopPush(item);
            return true;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool TryPeekPopPush(T item, out T result) {
            result = this.PeekPopPush(item);
            return true;
        }
    }
}
