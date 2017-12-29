using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Plain.ValueTypes {
    using UltimateOrb.Collections.Generic;

    /// <summary>
    ///     <para>Represents a variable size last-in-first-out (LIFO) collection of instances of the same specified type. This type is a value type.</para>
    /// </summary>
    /// <typeparam name="T">
    ///     <para>Specifies the type of elements in the stack.</para>
    /// </typeparam>
    /// <remarks>
    ///     <para>Value assignments of the <see cref="Stack{T}"/> have move semantics.</para>
    /// </remarks>
    public partial struct Stack<T> : IStack<T>, IStackEx<T> {

        public T[] buffer;

        public int count;

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
                Array.Resize(ref buffer, capacity);
                if (capacity < count) {
                    count = capacity;
                }
                return;
            }
            buffer = null;
            count = 0;
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
            Array.Resize(ref this.buffer, checked((int)(22 + 1.6180339887498948482045868343656 * this.count)));
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
                this.buffer = new T[capacity];
                this.count = 0;
                return;
            }
            buffer = null;
            count = 0;
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
            var c = checked(@this.count + 1);
            if (null == @this.buffer || c > buffer.Length) {
                @this.IncreaseCapacity();
                @this.buffer[unchecked(c - 1)] = item;
                this.buffer = @this.buffer;
                this.count = c;
                return;
            }
            {
                @this.buffer[unchecked(c - 1)] = item;
                this.count = c;
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
            var c = checked(this.count + 1);
            var buffer = this.buffer;
            if (null == buffer || c > buffer.Length) {
                this.IncreaseCapacity();
            }
            this.count = c;
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
            var a = this.count;
            if (0 < a) {
                unchecked {
                    --a;
                }
                this.count = a;
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
            var a = unchecked(this.count - 1);
            if (0 <= a) {
                return ref this.buffer[a];
            }
            return ref Dummy<T>.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        T UltimateOrb.Collections.Generic.IStack<T>.Peek() {
            var a = unchecked(this.count - 1);
            if (0 <= a) {
                return this.buffer[a];
            }
            return default(T);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool TryPush(T item) {
            var c = checked(this.count + 1);
            var buffer = this.buffer;
            if (null == buffer || c > buffer.Length) {
                try {
                    this.IncreaseCapacity();
                } catch (Exception) {
                    return false;
                }
                this.buffer[unchecked(c - 1)] = item;
                this.count = c;
                return true;
            }
            buffer[unchecked(c - 1)] = item;
            this.count = c;
            return true;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool TryPeek(out T item) {
            var a = unchecked(this.count - 1);
            if (0 <= a) {
                item = this.buffer[a];
                return true;
            }
            item = default(T);
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool TryPop(out T item) {
            var a = this.count;
            if (a > 0) {
                unchecked {
                    --a;
                }
                this.count = a;
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
                return checked((int)this.count);
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
                return this.count;
            }
        }

        public bool IsEmpty {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => 0 == this.count;
        }
    }
}
