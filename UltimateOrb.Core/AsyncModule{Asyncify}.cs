#nullable enable
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UltimateOrb.Threading.Tasks {

    public static partial class AsyncModule {

        static readonly Func<YieldAwaitable> _DefaultAsyncYield = () => Task.Yield();

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Func<T[], Task> Asyncify<T>(Action<T[]> action, int bufferSize, Func<YieldAwaitable>? asyncYield = null) {
            if (action is null) {
                throw new ArgumentNullException(nameof(action));
            }
            if (0 > bufferSize) {
                throw new ArgumentOutOfRangeException(nameof(bufferSize));
            }
            return Asyncify0(action, bufferSize, asyncYield ?? _DefaultAsyncYield);
        }

        private static Func<T[], Task> Asyncify0<T>(Action<T[]> action, int bufferSize, Func<YieldAwaitable> asyncYield) {
            return async (T[] buffer) => {
                var c = bufferSize;
                var b = new T[c];
                var i = 0;
                for (var r = buffer.Length; r > 0; r -= c, i += c) {
                    await asyncYield();
                    if (c > r) {
                        c = r;
                        b = new T[r];
                    }
                    action(b);
                    Array.Copy(b, 0, buffer, i, b.Length);
                }
            };
        }

        /*
        public static Func<Memory<T>, ValueTask> Asyncify<T>(SpanAction<T> action, int bufferSize, Func<YieldAwaitable>? asyncYield = null) {
            if (action is null) {
                throw new ArgumentNullException(nameof(action));
            }
            var a = action;
            var async_yield = asyncYield ?? _DefaultAsyncYield;
            var c = bufferSize;
            return async (Memory<T> buffer) => {
                for (var i = 0; buffer.Length > i; i += c) {
                    await async_yield();
                    a(buffer.Slice(i, Math.Min(c, buffer.Length - i)).Span);
                }
            };
        }

        public static Func<Memory<T>, CancellationToken, ValueTask> AsyncifyWithCancellation<T>(SpanAction<T> action, int bufferSize, Func<YieldAwaitable>? asyncYield = null) {
            if (action is null) {
                throw new ArgumentNullException(nameof(action));
            }
            var a = action;
            var async_yield = asyncYield ?? _DefaultAsyncYield;
            var c = bufferSize;
            return async (Memory<T> buffer, CancellationToken cancellationToken) => {
                for (var i = 0; buffer.Length > i; i += c) {
                    cancellationToken.ThrowIfCancellationRequested();
                    await async_yield();
                    a(buffer.Slice(i, Math.Min(c, buffer.Length - i)).Span);
                }
            };
        }

        public static Func<Memory<T>, CancellationToken, ValueTask> Asyncify<T>(SpanAction<T, CancellationToken> action, int bufferSize, Func<YieldAwaitable>? asyncYield = null) {
            if (action is null) {
                throw new ArgumentNullException(nameof(action));
            }
            var a = action;
            var async_yield = asyncYield ?? _DefaultAsyncYield;
            var c = bufferSize;
            return async (Memory<T> buffer, CancellationToken cancellationToken) => {
                for (var i = 0; buffer.Length > i; i += c) {
                    await async_yield();
                    a(buffer.Slice(i, Math.Min(c, buffer.Length - i)).Span, cancellationToken);
                }
            };
        }

        public static Func<ReadOnlyMemory<T>, ValueTask> Asyncify<T>(ReadOnlySpanAction<T> action, int bufferSize, Func<YieldAwaitable>? asyncYield = null) {
            if (action is null) {
                throw new ArgumentNullException(nameof(action));
            }
            var a = action;
            var async_yield = asyncYield ?? _DefaultAsyncYield;
            var c = bufferSize;
            return async (ReadOnlyMemory<T> buffer) => {
                for (var i = 0; buffer.Length > i; i += c) {
                    await async_yield();
                    a(buffer.Slice(i, Math.Min(c, buffer.Length - i)).Span);
                }
            };
        }

        public static Func<ReadOnlyMemory<T>, CancellationToken, ValueTask> AsyncifyWithCancellation<T>(ReadOnlySpanAction<T> action, int bufferSize, Func<YieldAwaitable>? asyncYield = null) {
            if (action is null) {
                throw new ArgumentNullException(nameof(action));
            }
            var a = action;
            var async_yield = asyncYield ?? _DefaultAsyncYield;
            var c = bufferSize;
            return async (ReadOnlyMemory<T> buffer, CancellationToken cancellationToken) => {
                for (var i = 0; buffer.Length > i; i += c) {
                    cancellationToken.ThrowIfCancellationRequested();
                    await async_yield();
                    a(buffer.Slice(i, Math.Min(c, buffer.Length - i)).Span);
                }
            };
        }

        public static Func<ReadOnlyMemory<T>, CancellationToken, ValueTask> Asyncify<T>(ReadOnlySpanAction<T, CancellationToken> action, int bufferSize, Func<YieldAwaitable>? asyncYield = null) {
            if (action is null) {
                throw new ArgumentNullException(nameof(action));
            }
            var a = action;
            var async_yield = asyncYield ?? _DefaultAsyncYield;
            var c = bufferSize;
            return async (ReadOnlyMemory<T> buffer, CancellationToken cancellationToken) => {
                for (var i = 0; buffer.Length > i; i += c) {
                    await async_yield();
                    a(buffer.Slice(i, Math.Min(c, buffer.Length - i)).Span, cancellationToken);
                }
            };
        }
        */
    }
}
