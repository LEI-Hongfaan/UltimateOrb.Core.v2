using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb {

    public static partial class Nullable {

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static T? ToBclNullable<T>(this Nullable_A<T> value) where T : struct {
            if (value.HasValue) {
                return new T?(value.GetValueOrDefault());
            }
            return default;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        [PureAttribute()]
        internal static void ThrowInvalidOperationException() {
            throw new InvalidOperationException();
        }
        
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Nullable_A<TResult> Select<TSource, TResult>(this Nullable_A<TSource> source, Func<TSource, TResult> selector) {
            if (null != selector) {
                if (source.HasValue) {
                    return new Nullable_A<TResult>(selector.Invoke(source.GetValueOrDefault()));
                }
                return default;
            }
            throw new ArgumentNullException(nameof(selector));
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TResult? Select<TSource, TResult>(this TSource? source, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct {
            if (null != selector) {
                if (source.HasValue) {
                    return new TResult?(selector.Invoke(source.GetValueOrDefault()));
                }
                return default;
            }
            throw new ArgumentNullException(nameof(selector));
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, TCollection?> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
           where TCollection : struct {
            if (null != collectionSelector) {
                if (null != resultSelector) {
                    foreach (var item in source) {
                        var collection = collectionSelector.Invoke(item);
                        if (collection.HasValue) {
                            yield return resultSelector.Invoke(item, collection.GetValueOrDefault());
                        }
                    }
                    yield break;
                }
                throw new ArgumentNullException(nameof(resultSelector));
            }
            throw new ArgumentNullException(nameof(collectionSelector));
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, Nullable_A<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            if (null != collectionSelector) {
                if (null != resultSelector) {
                    foreach (var item in source) {
                        var collection = collectionSelector.Invoke(item);
                        if (collection.HasValue) {
                            yield return resultSelector.Invoke(item, collection.GetValueOrDefault());
                        }
                    }
                    yield break;
                }
                throw new ArgumentNullException(nameof(resultSelector));
            }
            throw new ArgumentNullException(nameof(collectionSelector));
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this TSource? source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
            where TSource : struct {
            if (null != collectionSelector) {
                if (null != resultSelector) {
                    if (source.HasValue) {
                        var source_Value = source.GetValueOrDefault();
                        var collection = collectionSelector.Invoke(source_Value);
                        return collection.Select((item) => resultSelector.Invoke(source_Value, item));
                    }
                    return Array_Empty<TResult>.Value;
                }
                throw new ArgumentNullException(nameof(resultSelector));
            }
            throw new ArgumentNullException(nameof(collectionSelector));
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Nullable_A<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            if (null != collectionSelector) {
                if (null != resultSelector) {
                    if (source.HasValue) {
                        var source_Value = source.GetValueOrDefault();
                        var collection = collectionSelector.Invoke(source_Value);
                        return collection.Select((item) => resultSelector.Invoke(source_Value, item));
                    }
                    return Array_Empty<TResult>.Value;
                }
                throw new ArgumentNullException(nameof(resultSelector));
            }
            throw new ArgumentNullException(nameof(collectionSelector));
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Nullable_A<TResult> SelectMany<TSource, TCollection, TResult>(this TSource? source, Func<TSource, TCollection?> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
            where TSource : struct
            where TCollection : struct {
            if (null != collectionSelector) {
                if (null != resultSelector) {
                    if (source.HasValue) {
                        var source_Value = source.GetValueOrDefault();
                        var collection = collectionSelector.Invoke(source_Value);
                        if (collection.HasValue) {
                            return new Nullable_A<TResult>(resultSelector.Invoke(source_Value, collection.GetValueOrDefault()));
                        }
                    }
                    return default;
                }
                throw new ArgumentNullException(nameof(resultSelector));
            }
            throw new ArgumentNullException(nameof(collectionSelector));
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Nullable_A<TResult> SelectMany<TSource, TCollection, TResult>(this TSource? source, Func<TSource, Nullable_A<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
           where TSource : struct {
            if (null != collectionSelector) {
                if (null != resultSelector) {
                    if (source.HasValue) {
                        var source_Value = source.GetValueOrDefault();
                        var collection = collectionSelector.Invoke(source_Value);
                        if (collection.HasValue) {
                            return new Nullable_A<TResult>(resultSelector.Invoke(source_Value, collection.GetValueOrDefault()));
                        }
                    }
                    return default;
                }
                throw new ArgumentNullException(nameof(resultSelector));
            }
            throw new ArgumentNullException(nameof(collectionSelector));
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Nullable_A<TResult> SelectMany<TSource, TCollection, TResult>(this Nullable_A<TSource> source, Func<TSource, TCollection?> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
            where TCollection : struct {
            if (null != collectionSelector) {
                if (null != resultSelector) {
                    if (source.HasValue) {
                        var source_Value = source.GetValueOrDefault();
                        var collection = collectionSelector.Invoke(source_Value);
                        if (collection.HasValue) {
                            return new Nullable_A<TResult>(resultSelector.Invoke(source_Value, collection.GetValueOrDefault()));
                        }
                    }
                    return default;
                }
                throw new ArgumentNullException(nameof(resultSelector));
            }
            throw new ArgumentNullException(nameof(collectionSelector));
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Nullable_A<TResult> SelectMany<TSource, TCollection, TResult>(this Nullable_A<TSource> source, Func<TSource, Nullable_A<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            if (null != collectionSelector) {
                if (null != resultSelector) {
                    if (source.HasValue) {
                        var source_Value = source.GetValueOrDefault();
                        var collection = collectionSelector.Invoke(source_Value);
                        if (collection.HasValue) {
                            return new Nullable_A<TResult>(resultSelector.Invoke(source_Value, collection.GetValueOrDefault()));
                        }
                    }
                    return default;
                }
                throw new ArgumentNullException(nameof(resultSelector));
            }
            throw new ArgumentNullException(nameof(collectionSelector));
        }

        /// <summary>
        ///     <para>
        ///         Filters a nullable value based on a predicate.
        ///     </para>
        /// </summary>
        /// <typeparam name="TSource">
        ///     <para>
        ///         The type of the value of <paramref name="source"/>.
        ///     </para>
        /// </typeparam>
        /// <param name="source">
        ///     <para>
        ///         A <see cref="Nullable{TSource}"/> to filter.
        ///     </para>
        /// </param>
        /// <param name="predicate">
        ///     <para>
        ///         A function to test the value for a condition.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         A <see cref="Nullable{TSource}"/> that contains the value from the input nullable value that satisfy the condition specified by predicate.
        ///     </para>
        /// </returns>
        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource? Where<TSource>(this TSource? source, Func<TSource, bool> predicate)
             where TSource : struct {
            if (null != predicate) {
                if (source.HasValue) {
                    if (predicate.Invoke(source.GetValueOrDefault())) {
                        return source;
                    }
                }
                return default;
            }
            throw new ArgumentNullException(nameof(predicate));
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Nullable_A<TSource> Where<TSource>(this Nullable_A<TSource> source, Func<TSource, bool> predicate) {
            if (null != predicate) {
                if (source.HasValue) {
                    if (predicate.Invoke(source.GetValueOrDefault())) {
                        return source;
                    }
                }
                return default;
            }
            throw new ArgumentNullException(nameof(predicate));
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Nullable_A<TResult> Join<TOuter, TInner, TKey, TResult>(this Nullable_A<TOuter> outer, Nullable_A<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer) {
            throw new NotImplementedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Nullable_A<TResult> Join<TOuter, TInner, TKey, TResult>(this Nullable_A<TOuter> outer, TInner? inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
            where TInner : struct {
            throw new NotImplementedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Nullable_A<TResult> Join<TOuter, TInner, TKey, TResult>(this TOuter? outer, Nullable_A<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer) 
            where TOuter : struct {
            throw new NotImplementedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Nullable_A<TResult> Join<TOuter, TInner, TKey, TResult>(this TOuter? outer, TInner? inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
            where TOuter : struct
            where TInner : struct {
            throw new NotImplementedException();
        }
        
    }

    public readonly partial struct Nullable_A<T> : INullable<T> {

        private readonly T value;

        private readonly bool hasValue;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public Nullable_A(T value) {
            this.value = value;
            if (null != value) {
                if (value is INullable v) {
                    this.hasValue = v.HasValue;
                    return;
                }
                this.hasValue = true;
                return;
            }
            this.hasValue = false;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        internal Nullable_A(T value, bool hasValue) {
            this.value = value;
            this.hasValue = hasValue;
        }

        public bool HasValue {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.hasValue;
        }

        public T Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get {
                if (!this.hasValue) {
                    Nullable.ThrowInvalidOperationException();
                }
                return this.value;
            }
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public T GetValueOrDefault() {
            return this.value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public T GetValueOrDefault(T defaultValue) {
            return this.hasValue ? this.value : defaultValue;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public override bool Equals(object other) {
            if (!this.hasValue) {
                return null == other;
            }
            if (null == other) {
                return false;
            }
            return value.Equals(other);
        }

        public override int GetHashCode() {
            return this.hasValue ? this.value.GetHashCode() : 0;
        }

        public override string ToString() {
            return this.hasValue ? this.value.ToString() : "";
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator Nullable_A<T>(T value) {
            return new Nullable_A<T>(value);
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static explicit operator T(Nullable_A<T> value) {
            return value.Value;
        }
    }
}
