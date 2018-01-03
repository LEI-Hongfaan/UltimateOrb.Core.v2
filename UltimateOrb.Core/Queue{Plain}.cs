using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Collections;
using System.Collections.Generic;

namespace UltimateOrb.Plain.ValueTypes {
    using ArrayModule = Internal.System.ArrayModule;
    using UltimateOrb.Collections.Generic.RefReturnSupported;

    public partial struct Queue<T> : IEnumerable<T, Queue<T>.Enumerator> {

        public T[] buffer;

        public int count;

        public int offset;

        public int current;

        public Queue(T[] buffer, int count, int offset, int current) {
            this.buffer = buffer;
            this.count = count;
            this.offset = offset;
            this.current = current;
        }

        private int capacity {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.buffer.Length;
        }

        public T Peek() {
            var b = this.buffer;
            if (null != b) {
                if (this.count > 0) {
                    return b[this.current];
                }
                throw new InvalidOperationException();
            }
            throw (NullReferenceException)null;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Queue(int capacity) {
            if (0 <= capacity) {
                this.buffer = (capacity > 0 ? Array_Empty<T>.Value : new T[capacity]);
                this.count = 0;
                this.offset = 0;
                this.current = -1;
                return;
            }
            // TODO
            throw List_ThrowHelper.ThrowArgumentOutOfRangeException_capacity();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Push(T item) {
            var @this = this;
            if (null != @this.buffer) {
                var c = @this.count;
                checked {
                    ++c;
                }
                if (c <= @this.capacity) {
                    var d = @this.current;
                    unchecked {
                        ++d;
                    }
                    if (@this.capacity == d) {
                        d = 0;
                    }
                    @this.buffer[d] = item;
                    this.current = d;
                    this.count = c;
                    return;
                }
                {
                    @this.EnsureCapacity(c);
                    var d = @this.current;
                    unchecked {
                        ++d;
                    }
                    if (@this.capacity == d) {
                        d = 0;
                    }
                    @this.buffer[d] = item;
                    this.buffer = @this.buffer;
                    this.offset = @this.offset;
                    this.current = d;
                    this.count = c;
                    return;
                }
            }
            throw (NullReferenceException)null;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T Pop() {
            var b = this.buffer;
            if (null != b) {
                var c = this.count;
                if (c > 0) {
                    var d = this.current;
                    ref var result = ref b[d];
                    unchecked {
                        --c;
                    }
                    this.count = c;
                    if (0 == d) {
                        d = b.Length;
                    }
                    unchecked {
                        --d;
                    }
                    this.current = d;
                    return result;
                }
            }
            throw (NullReferenceException)null;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Enqueue(T item) {
            this.Push(item);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T Dequeue() {
            var b = this.buffer;
            if (null != b) {
                var c = this.count;
                if (c > 0) {
                    var d = this.offset;
                    ref var result = ref b[d];
                    unchecked {
                        --c;
                    }
                    this.count = c;
                    unchecked {
                        ++d;
                    }
                    if (b.Length == d) {
                        d = 0;
                    }
                    this.offset = d;
                    return result;
                }
            }
            throw (NullReferenceException)null;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T Shift() {
            return this.Dequeue();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Unshift(T item) {
            var @this = this;
            if (null != @this.buffer) {
                var c = @this.count;
                checked {
                    ++c;
                }
                if (c <= @this.capacity) {
                    var d = @this.offset;
                    if (0 == d) {
                        d = @this.capacity;
                    }
                    unchecked {
                        --d;
                    }
                    @this.buffer[d] = item;
                    this.offset = d;
                    this.count = c;
                    return;
                }
                {
                    @this.EnsureCapacity(c);
                    var d = @this.offset;
                    if (0 == d) {
                        d = @this.capacity;
                    }
                    unchecked {
                        --d;
                    }
                    @this.buffer[d] = item;
                    this.buffer = @this.buffer;
                    this.current = @this.current;
                    this.offset = d;
                    this.count = c;
                    return;
                }
            }
            throw (NullReferenceException)null;
        }


        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Queue<T> Select() {
            var buffer = this.buffer;
            var count = this.count;
            var offset = this.offset;
            var current = this.current;
            if (null != buffer) {
                if (count > 0) {
                    var new_buffer = new T[count];
                    if (offset <= current) {
                        Array.Copy(buffer, offset, new_buffer, 0, count);
                    } else {
                        var d = unchecked(buffer.Length - offset);
                        Array.Copy(buffer, offset, new_buffer, 0, d);
                        Array.Copy(buffer, 0, new_buffer, d, unchecked(1 + current));
                    }
                    return new Queue<T>(new_buffer, count, 0, unchecked(count - 1));
                }
                return new Queue<T>(0);
            }
            return default;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Queue<TResult> Select<TResult, TSelector>(TSelector selector) where TSelector : IO.IFunc<T, TResult> {
            var buffer = this.buffer;
            var count = this.count;
            var offset = this.offset;
            var current = this.current;
            if (null != buffer) {
                if (count > 0) {
                    var new_buffer = new TResult[count];
                    if (offset <= current) {
                        for (var i = 0; new_buffer.Length > i; ++i) {
                            new_buffer[i] = selector.Invoke(buffer[unchecked(offset + i)]);
                        }
                    } else {
                        var d = unchecked(buffer.Length - offset);
                        for (var i = 0; d > i; ++i) {
                            new_buffer[i] = selector.Invoke(buffer[unchecked(offset + i)]);
                        }
                        for (var i = 0; unchecked(1 + current) > i; ++i) {
                            new_buffer[unchecked(d + i)] = selector.Invoke(buffer[i]);
                        }
                    }
                    return new Queue<TResult>(new_buffer, count, 0, unchecked(count - 1));
                }
                return new Queue<TResult>(0);
            }
            return default;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Queue<TResult> Select<TResult, TSelector>() where TSelector : IO.IFunc<T, TResult> => Select<TResult, TSelector>(default);

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T[] ToArray() {
            var buffer = this.buffer;
            var count = this.count;
            var offset = this.offset;
            var current = this.current;
            if (null != buffer) {
                if (count > 0) {
                    var result = new T[count];
                    if (offset <= current) {
                        Array.Copy(buffer, offset, result, 0, count);
                    } else {
                        var d = unchecked(buffer.Length - offset);
                        Array.Copy(buffer, offset, result, 0, d);
                        Array.Copy(buffer, 0, result, d, unchecked(1 + current));
                    }
                    return result;
                }
                return Array_Empty<T>.Value;
            }
            return null;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public TResult[] ToArray<TResult, TSelector>(TSelector selector) where TSelector : IO.IFunc<T, TResult> {
            var buffer = this.buffer;
            var count = this.count;
            var offset = this.offset;
            var current = this.current;
            if (null != buffer) {
                if (count > 0) {
                    var result = new TResult[count];
                    if (offset <= current) {
                        for (var i = 0; result.Length > i; ++i) {
                            result[i] = selector.Invoke(buffer[unchecked(offset + i)]);
                        }
                    } else {
                        var d = unchecked(buffer.Length - offset);
                        for (var i = 0; d > i; ++i) {
                            result[i] = selector.Invoke(buffer[unchecked(offset + i)]);
                        }
                        for (var i = 0; unchecked(1 + current) > i; ++i) {
                            result[unchecked(d + i)] = selector.Invoke(buffer[i]);
                        }
                    }
                    return result;
                }
                return Array_Empty<TResult>.Value;
            }
            return null;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public TResult[] ToArray<TResult, TSelector>() where TSelector : IO.IFunc<T, TResult>, new() => this.ToArray<TResult, TSelector>(DefaultConstructor.Invoke<TSelector>());

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        public void EnsureCapacity(int min) {
            var buffer = this.buffer;
            var buffer_Length = buffer.Length;
            if (min > buffer_Length) {
                var new_capacity = buffer_Length == 0 ? List.default_capacity : unchecked(buffer_Length * 2);
                if (unchecked((uint)new_capacity) > ArrayModule.MaxArrayLength) {
                    new_capacity = ArrayModule.MaxArrayLength;
                }
                if (min > new_capacity) {
                    new_capacity = min;
                }
                var d = new T[new_capacity];
                var c = this.count;
                if (c > 0) {
                    var s = this.offset;
                    var t = this.current;
                    if (t < s) {
                        var a = unchecked(1 + t);
                        var b = unchecked(c - a);
                        Array.Copy(buffer, s, d, 0, b);
                        Array.Copy(buffer, 0, d, b, a);
                    } else {
                        Array.Copy(buffer, s, d, 0, c);
                    }
                    this.current = unchecked(c - 1);
                } else {
                    this.current = unchecked(new_capacity - 1);
                }
                this.offset = 0;
                this.buffer = d;
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() {
            var @this = this;
            if (null != @this.buffer) { // null check
                return new Enumerator(@this);
            }
            {
                throw (NullReferenceException)null;
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.Generic.IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
    }
}

