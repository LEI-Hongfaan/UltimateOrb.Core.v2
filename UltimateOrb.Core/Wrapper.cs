using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using UltimateOrb.Collections.Generic;

namespace UltimateOrb {

    public static partial class WrapperModule {

        public static TSource Aggregate<TSource>(this Wrapper<TSource> source, Func<TSource, TSource, TSource> func) {
            return source.Value;
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this Wrapper<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) {
            return func.Invoke(seed, source.Value);
        }

        public static TResult Aggregate<TSource, TAccumulate, TResult>(this Wrapper<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector) {
            return resultSelector.Invoke(func.Invoke(seed, source.Value));
        }

        public static bool All<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value);
        }

        public static bool Any<TSource>(this Wrapper<TSource> source) {
            return true;
        }

        public static bool Any<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value);
        }

        public static System.Collections.Generic.IEnumerable<TSource> AsEnumerable<TSource>(this Wrapper<TSource> source) {
            yield return source.Value;
        }

        public static double Average<TSource>(this Wrapper<TSource> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }

        public static decimal? Average<TSource>(this Wrapper<TSource> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        public static double? Average<TSource>(this Wrapper<TSource> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        public static float Average<TSource>(this Wrapper<TSource> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }

        public static double? Average<TSource>(this Wrapper<TSource> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        public static float? Average<TSource>(this Wrapper<TSource> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        public static double Average<TSource>(this Wrapper<TSource> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }

        public static double? Average<TSource>(this Wrapper<TSource> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        public static double Average<TSource>(this Wrapper<TSource> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }

        public static decimal Average<TSource>(this Wrapper<TSource> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }

        public static decimal Average(this Wrapper<decimal> source) {
            return source.Value;
        }

        public static float Average(this Wrapper<float> source) {
            return source.Value;
        }

        public static double Average(this Wrapper<int> source) {
            return source.Value;
        }

        public static double Average(this Wrapper<long> source) {
            return source.Value;
        }

        public static decimal? Average(this Wrapper<decimal?> source) {
            return source.Value;
        }

        public static double Average(this Wrapper<double> source) {
            return source.Value;
        }

        public static double? Average(this Wrapper<int?> source) {
            return source.Value;
        }

        public static double? Average(this Wrapper<long?> source) {
            return source.Value;
        }

        public static float? Average(this Wrapper<float?> source) {
            return source.Value;
        }

        public static double? Average(this Wrapper<double?> source) {
            return source.Value;
        }

        public static bool Contains<TSource>(this Wrapper<TSource> source, TSource value) {
            return source.Value.Equals(value);
        }

        public static bool Contains<TSource>(this Wrapper<TSource> source, TSource value, IEqualityComparer<TSource> comparer) {
            return comparer.Equals(source.Value, value);
        }

        public static int Count<TSource>(this Wrapper<TSource> source) {
            return 1;
        }

        public static int Count<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value) ? 1 : 0;
        }

        public static Wrapper<TSource> DefaultIfEmpty<TSource>(this Wrapper<TSource> source) {
            return source;
        }

        public static Wrapper<TSource> DefaultIfEmpty<TSource>(this Wrapper<TSource> source, TSource defaultValue) {
            return source;
        }

        public static Wrapper<TSource> Distinct<TSource>(this Wrapper<TSource> source) {
            return source;
        }

        public static Wrapper<TSource> Distinct<TSource>(this Wrapper<TSource> source, IEqualityComparer<TSource> comparer) {
            return source;
        }

        public static TSource ElementAt<TSource>(this Wrapper<TSource> source, int index) {
            if (0 == index) {
                return source.Value;
            }
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        public static TSource ElementAtOrDefault<TSource>(this Wrapper<TSource> source, int index) {
            if (0 == index) {
                return source.Value;
            }
            return default;
        }

        public static TSource First<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        public static TSource First<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        public static TSource FirstOrDefault<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        public static TSource FirstOrDefault<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        public static Wrapper<TResult> GroupBy<TSource, TKey, TElement, TResult>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, Wrapper<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var element = elementSelector.Invoke(value);
            var result = resultSelector.Invoke(key, new Wrapper<TElement>(element));
            return new Wrapper<TResult>(result);
        }

        public static Wrapper<TResult> GroupBy<TSource, TKey, TElement, TResult>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, Wrapper<TElement>, TResult> resultSelector) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var element = elementSelector.Invoke(value);
            var result = resultSelector.Invoke(key, new Wrapper<TElement>(element));
            return new Wrapper<TResult>(result);
        }

        public static Wrapper<TResult> GroupBy<TSource, TKey, TResult>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, Wrapper<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var result = resultSelector.Invoke(key, source);
            return new Wrapper<TResult>(result);
        }

        public static Wrapper<TResult> GroupBy<TSource, TKey, TResult>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, Wrapper<TSource>, TResult> resultSelector) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var result = resultSelector.Invoke(key, source);
            return new Wrapper<TResult>(result);
        }

        public readonly partial struct Grouping<TKey, TElement> {

            public readonly TKey Key;

            public readonly TElement Value;

            internal Grouping(TKey key, TElement value) {
                this.Key = key;
                this.Value = value;
            }

            /*
            public TKey Key {

                get => this.key;
            }

            public TElement Value {

                get => this.value;
            }
            */
        }

        public static Wrapper<Grouping<TKey, TSource>> GroupBy<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            return new Grouping<TKey, TSource>(keySelector.Invoke(value), value);
        }

        public static Wrapper<Grouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) {
            var value = source.Value;
            return new Grouping<TKey, TElement>(keySelector.Invoke(value), elementSelector.Invoke(value));
        }

        public static Wrapper<Grouping<TKey, TSource>> GroupBy<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector) {
            var value = source.Value;
            return new Grouping<TKey, TSource>(keySelector.Invoke(value), value);
        }

        public static Wrapper<Grouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            return new Grouping<TKey, TElement>(keySelector.Invoke(value), elementSelector.Invoke(value));
        }
        /**/
        public static TSource Last<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        public static TSource Last<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        public static TSource LastOrDefault<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        public static TSource LastOrDefault<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        public static long LongCount<TSource>(this Wrapper<TSource> source) {
            return 1;
        }

        public static long LongCount<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value) ? 1 : 0;
        }

        public static int Max<TSource>(this Wrapper<TSource> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }

        public static long Max<TSource>(this Wrapper<TSource> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }

        public static decimal? Max<TSource>(this Wrapper<TSource> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        public static double? Max<TSource>(this Wrapper<TSource> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        public static float Max<TSource>(this Wrapper<TSource> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }

        public static long? Max<TSource>(this Wrapper<TSource> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        public static float? Max<TSource>(this Wrapper<TSource> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        public static double Max<TSource>(this Wrapper<TSource> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }

        public static int? Max<TSource>(this Wrapper<TSource> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        public static decimal Max<TSource>(this Wrapper<TSource> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }

        public static TResult Max<TSource, TResult>(this Wrapper<TSource> source, Func<TSource, TResult> selector) {
            return selector.Invoke(source.Value);
        }

        public static float Max(this Wrapper<float> source) {
            return source.Value;
        }

        public static decimal Max(this Wrapper<decimal> source) {
            return source.Value;
        }

        public static double Max(this Wrapper<double> source) {
            return source.Value;
        }

        public static int Max(this Wrapper<int> source) {
            return source.Value;
        }

        public static long Max(this Wrapper<long> source) {
            return source.Value;
        }

        public static TSource Max<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        public static double? Max(this Wrapper<double?> source) {
            return source.Value;
        }

        public static int? Max(this Wrapper<int?> source) {
            return source.Value;
        }

        public static long? Max(this Wrapper<long?> source) {
            return source.Value;
        }

        public static float? Max(this Wrapper<float?> source) {
            return source.Value;
        }

        public static decimal? Max(this Wrapper<decimal?> source) {
            return source.Value;
        }

        public static int Min<TSource>(this Wrapper<TSource> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }

        public static TResult Min<TSource, TResult>(this Wrapper<TSource> source, Func<TSource, TResult> selector) {
            return selector.Invoke(source.Value);
        }

        public static float Min<TSource>(this Wrapper<TSource> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }

        public static float? Min<TSource>(this Wrapper<TSource> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        public static long? Min<TSource>(this Wrapper<TSource> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        public static int? Min<TSource>(this Wrapper<TSource> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        public static double? Min<TSource>(this Wrapper<TSource> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        public static decimal? Min<TSource>(this Wrapper<TSource> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        public static long Min<TSource>(this Wrapper<TSource> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }

        public static decimal Min<TSource>(this Wrapper<TSource> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }

        public static double Min<TSource>(this Wrapper<TSource> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }

        public static float Min(this Wrapper<float> source) {
            return source.Value;
        }

        public static float? Min(this Wrapper<float?> source) {
            return source.Value;
        }

        public static long? Min(this Wrapper<long?> source) {
            return source.Value;
        }

        public static int? Min(this Wrapper<int?> source) {
            return source.Value;
        }

        public static double? Min(this Wrapper<double?> source) {
            return source.Value;
        }

        public static decimal? Min(this Wrapper<decimal?> source) {
            return source.Value;
        }

        public static long Min(this Wrapper<long> source) {
            return source.Value;
        }

        public static int Min(this Wrapper<int> source) {
            return source.Value;
        }

        public static double Min(this Wrapper<double> source) {
            return source.Value;
        }

        public static decimal Min(this Wrapper<decimal> source) {
            return source.Value;
        }

        public static TSource Min<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        public static Wrapper<TSource> OrderBy<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        public static Wrapper<TSource> OrderBy<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        public static Wrapper<TSource> OrderByDescending<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        public static Wrapper<TSource> OrderByDescending<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        public static Wrapper<TSource> Reverse<TSource>(this Wrapper<TSource> source) {
            return source;
        }

        public static Wrapper<TResult> Select<TSource, TResult>(this Wrapper<TSource> source, Func<TSource, TResult> selector) {
            return new Wrapper<TResult>(selector.Invoke(source.Value));
        }

        public static Wrapper<TResult> Select<TSource, TResult>(this Wrapper<TSource> source, Func<TSource, int, TResult> selector) {
            return new Wrapper<TResult>(selector.Invoke(source.Value, 0));
        }

        public static Wrapper<TResult> SelectMany<TSource, TResult>(this Wrapper<TSource> source, Func<TSource, Wrapper<TResult>> selector) {
            return selector.Invoke(source.Value);
        }

        public static Wrapper<TResult> SelectMany<TSource, TResult>(this Wrapper<TSource> source, Func<TSource, int, Wrapper<TResult>> selector) {
            return selector.Invoke(source.Value, 0);
        }

        public static Wrapper<TResult> SelectMany<TSource, TCollection, TResult>(this Wrapper<TSource> source, Func<TSource, Wrapper<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return new Wrapper<TResult>(resultSelector.Invoke(value, collectionSelector.Invoke(value).Value));
        }

        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Wrapper<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return collectionSelector.Invoke(value).Select((collection_value) => resultSelector.Invoke(value, collection_value));
        }

        public static Wrapper<TResult> SelectMany<TSource, TCollection, TResult>(this Wrapper<TSource> source, Func<TSource, int, Wrapper<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return new Wrapper<TResult>(resultSelector.Invoke(value, collectionSelector.Invoke(value, 0).Value));
        }

        public static bool SequenceEqual<TSource>(this Wrapper<TSource> first, Wrapper<TSource> second, IEqualityComparer<TSource> comparer) {
            return comparer.Equals(first.Value, second.Value);
        }

        public static bool SequenceEqual<TSource>(this Wrapper<TSource> first, Wrapper<TSource> second) {
            return EqualityComparer<TSource>.Default.Equals(first.Value, second.Value);
        }

        public static TSource Single<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        public static TSource Single<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        public static TSource SingleOrDefault<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        public static TSource SingleOrDefault<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        public static int? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        public static int Sum<TSource>(this Wrapper<TSource> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }

        public static long Sum<TSource>(this Wrapper<TSource> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }

        public static decimal? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        public static float Sum<TSource>(this Wrapper<TSource> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }

        public static float? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        public static double Sum<TSource>(this Wrapper<TSource> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }

        public static long? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        public static decimal Sum<TSource>(this Wrapper<TSource> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }

        public static double? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        public static float? Sum(this Wrapper<float?> source) {
            return source.Value;
        }

        public static long? Sum(this Wrapper<long?> source) {
            return source.Value;
        }

        public static int? Sum(this Wrapper<int?> source) {
            return source.Value;
        }

        public static double? Sum(this Wrapper<double?> source) {
            return source.Value;
        }

        public static decimal? Sum(this Wrapper<decimal?> source) {
            return source.Value;
        }

        public static float Sum(this Wrapper<float> source) {
            return source.Value;
        }

        public static long Sum(this Wrapper<long> source) {
            return source.Value;
        }

        public static int Sum(this Wrapper<int> source) {
            return source.Value;
        }

        public static double Sum(this Wrapper<double> source) {
            return source.Value;
        }

        public static decimal Sum(this Wrapper<decimal> source) {
            return source.Value;
        }

        public static Wrapper<TSource> ThenBy<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        public static Wrapper<TSource> ThenBy<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        public static Wrapper<TSource> ThenByDescending<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        public static Wrapper<TSource> ThenByDescending<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        public static TSource[] ToArray<TSource>(this Wrapper<TSource> source) {
            return new[] { source.Value, };
        }

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector) {
            var value = source.Value;
            return new Dictionary<TKey, TSource> { { keySelector.Invoke(value), value }, };
        }

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) {
            var dictionary = new Dictionary<TKey, TSource>(comparer);
            var value = source.Value;
            dictionary.Add(keySelector.Invoke(value), value);
            return dictionary;
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) {
            var value = source.Value;
            return new Dictionary<TKey, TElement> { { keySelector.Invoke(value), elementSelector.Invoke(value) }, };
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) {
            var dictionary = new Dictionary<TKey, TElement>(comparer);
            var value = source.Value;
            dictionary.Add(keySelector.Invoke(value), elementSelector.Invoke(value));
            return dictionary;
        }

        public static List<TSource> ToList<TSource>(this Wrapper<TSource> source) {
            return new List<TSource>(1) { source.Value, };
        }

        public static Wrapper<TResult> Zip<TFirst, TSecond, TResult>(this Wrapper<TFirst> first, Wrapper<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector) {
            return new Wrapper<TResult>(resultSelector.Invoke(first.Value, second.Value));
        }
    }

    public partial struct Wrapper<T> : IStrongBox<T>, IReadOnlyStrongBox<T> {

        public T Value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public Wrapper(T value) {
            this.Value = value;
        }

        T IStrongBox<T>.Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.Value;

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            set => this.Value = value;
        }

        T IReadOnlyStrongBox<T>.Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.Value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator T(Wrapper<T> value) {
            return value.Value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator Wrapper<T>(T value) {
            return new Wrapper<T>(value);
        }
    }

    public readonly partial struct ReadOnlyWrapper<T> : IReadOnlyStrongBox<T> {

        public readonly T Value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public ReadOnlyWrapper(T value) {
            this.Value = value;
        }

        T IReadOnlyStrongBox<T>.Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.Value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator T(ReadOnlyWrapper<T> value) {
            return value.Value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator ReadOnlyWrapper<T>(T value) {
            return new ReadOnlyWrapper<T>(value);
        }
    }
}
