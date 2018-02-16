using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace UltimateOrb {

    public static partial class WrapperModule {
	    
        public readonly partial struct Grouping<TKey, TElement> {

            public readonly TKey Key;

            public readonly TElement Value;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal Grouping(TKey key, TElement value) {
                this.Key = key;
                this.Value = value;
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Aggregate<TSource>(this Wrapper<TSource> source, Func<TSource, TSource, TSource> func) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TAccumulate Aggregate<TSource, TAccumulate>(this Wrapper<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) {
            return func.Invoke(seed, source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TResult Aggregate<TSource, TAccumulate, TResult>(this Wrapper<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector) {
            return resultSelector.Invoke(func.Invoke(seed, source.Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this Wrapper<TSource> source) {
            return true;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static SingletonEnumerable<TSource> ToEnumerable<TSource>(this Wrapper<TSource> source) {
            return new SingletonEnumerable<TSource>(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this Wrapper<TSource> source, TSource value) {
            return source.Value.Equals(value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this Wrapper<TSource> source, TSource value, IEqualityComparer<TSource> comparer) {
            return comparer.Equals(source.Value, value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this Wrapper<TSource> source) {
            return 1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value) ? 1 : 0;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> DefaultIfEmpty<TSource>(this Wrapper<TSource> source) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> DefaultIfEmpty<TSource>(this Wrapper<TSource> source, TSource defaultValue) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> Distinct<TSource>(this Wrapper<TSource> source) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> Distinct<TSource>(this Wrapper<TSource> source, IEqualityComparer<TSource> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAt<TSource>(this Wrapper<TSource> source, int index) {
            if (0 == index) {
                return source.Value;
            }
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAtOrDefault<TSource>(this Wrapper<TSource> source, int index) {
            if (0 == index) {
                return source.Value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult> GroupBy<TSource, TKey, TElement, TResult>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, Wrapper<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var element = elementSelector.Invoke(value);
            var result = resultSelector.Invoke(key, new Wrapper<TElement>(element));
            return new Wrapper<TResult>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult> GroupBy<TSource, TKey, TElement, TResult>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, Wrapper<TElement>, TResult> resultSelector) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var element = elementSelector.Invoke(value);
            var result = resultSelector.Invoke(key, new Wrapper<TElement>(element));
            return new Wrapper<TResult>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult> GroupBy<TSource, TKey, TResult>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, Wrapper<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var result = resultSelector.Invoke(key, source);
            return new Wrapper<TResult>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult> GroupBy<TSource, TKey, TResult>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, Wrapper<TSource>, TResult> resultSelector) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var result = resultSelector.Invoke(key, source);
            return new Wrapper<TResult>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<Grouping<TKey, TSource>> GroupBy<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            return new Grouping<TKey, TSource>(keySelector.Invoke(value), value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<Grouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) {
            var value = source.Value;
            return new Grouping<TKey, TElement>(keySelector.Invoke(value), elementSelector.Invoke(value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<Grouping<TKey, TSource>> GroupBy<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector) {
            var value = source.Value;
            return new Grouping<TKey, TSource>(keySelector.Invoke(value), value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<Grouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            return new Grouping<TKey, TElement>(keySelector.Invoke(value), elementSelector.Invoke(value));
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Last<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Last<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource LastOrDefault<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource LastOrDefault<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long LongCount<TSource>(this Wrapper<TSource> source) {
            return 1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long LongCount<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value) ? 1 : 0;
        }
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> OrderBy<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> OrderBy<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> OrderByDescending<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> OrderByDescending<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> Reverse<TSource>(this Wrapper<TSource> source) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult> Select<TSource, TResult>(this Wrapper<TSource> source, Func<TSource, TResult> selector) {
            return new Wrapper<TResult>(selector.Invoke(source.Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult> Select<TSource, TResult>(this Wrapper<TSource> source, Func<TSource, int, TResult> selector) {
            return new Wrapper<TResult>(selector.Invoke(source.Value, 0));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult> SelectMany<TSource, TResult>(this Wrapper<TSource> source, Func<TSource, Wrapper<TResult>> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult> SelectMany<TSource, TResult>(this Wrapper<TSource> source, Func<TSource, int, Wrapper<TResult>> selector) {
            return selector.Invoke(source.Value, 0);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult> SelectMany<TSource, TCollection, TResult>(this Wrapper<TSource> source, Func<TSource, Wrapper<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return new Wrapper<TResult>(resultSelector.Invoke(value, collectionSelector.Invoke(value).Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Wrapper<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return collectionSelector.Invoke(value).Select((collection_value) => resultSelector.Invoke(value, collection_value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult> SelectMany<TSource, TCollection, TResult>(this Wrapper<TSource> source, Func<TSource, int, Wrapper<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return new Wrapper<TResult>(resultSelector.Invoke(value, collectionSelector.Invoke(value, 0).Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool SequenceEqual<TSource>(this Wrapper<TSource> first, Wrapper<TSource> second, IEqualityComparer<TSource> comparer) {
            return comparer.Equals(first.Value, second.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool SequenceEqual<TSource>(this Wrapper<TSource> first, Wrapper<TSource> second) {
            return EqualityComparer<TSource>.Default.Equals(first.Value, second.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TSource>(this Wrapper<TSource> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TSource>(this Wrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Average<TSource>(this Wrapper<TSource> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Average<TSource>(this Wrapper<TSource> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Average(this Wrapper<int?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Average(this Wrapper<int> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Average<TSource>(this Wrapper<TSource> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Average<TSource>(this Wrapper<TSource> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Average(this Wrapper<uint?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Average(this Wrapper<uint> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Average<TSource>(this Wrapper<TSource> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Average<TSource>(this Wrapper<TSource> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Average(this Wrapper<byte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Average(this Wrapper<byte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Average<TSource>(this Wrapper<TSource> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Average<TSource>(this Wrapper<TSource> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Average(this Wrapper<sbyte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Average(this Wrapper<sbyte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Average<TSource>(this Wrapper<TSource> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Average<TSource>(this Wrapper<TSource> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Average(this Wrapper<short?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Average(this Wrapper<short> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Average<TSource>(this Wrapper<TSource> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Average<TSource>(this Wrapper<TSource> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Average(this Wrapper<ushort?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Average(this Wrapper<ushort> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Average<TSource>(this Wrapper<TSource> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Average<TSource>(this Wrapper<TSource> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Average(this Wrapper<long?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Average(this Wrapper<long> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Average<TSource>(this Wrapper<TSource> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Average<TSource>(this Wrapper<TSource> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Average(this Wrapper<ulong?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Average(this Wrapper<ulong> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Average<TSource>(this Wrapper<TSource> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Average<TSource>(this Wrapper<TSource> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Average(this Wrapper<float?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Average(this Wrapper<float> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Average<TSource>(this Wrapper<TSource> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Average<TSource>(this Wrapper<TSource> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Average(this Wrapper<double?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Average(this Wrapper<double> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Average<TSource>(this Wrapper<TSource> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Average<TSource>(this Wrapper<TSource> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Average(this Wrapper<decimal?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Average(this Wrapper<decimal> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Average<TSource>(this Wrapper<TSource> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Average<TSource>(this Wrapper<TSource> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Average(this Wrapper<Int128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Average(this Wrapper<Int128> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Average<TSource>(this Wrapper<TSource> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Average<TSource>(this Wrapper<TSource> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Average(this Wrapper<UInt128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Average(this Wrapper<UInt128> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Min<TSource>(this Wrapper<TSource> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Min<TSource>(this Wrapper<TSource> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Min(this Wrapper<int?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Min(this Wrapper<int> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Min<TSource>(this Wrapper<TSource> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Min<TSource>(this Wrapper<TSource> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Min(this Wrapper<uint?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Min(this Wrapper<uint> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Min<TSource>(this Wrapper<TSource> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Min<TSource>(this Wrapper<TSource> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Min(this Wrapper<byte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Min(this Wrapper<byte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Min<TSource>(this Wrapper<TSource> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Min<TSource>(this Wrapper<TSource> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Min(this Wrapper<sbyte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Min(this Wrapper<sbyte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Min<TSource>(this Wrapper<TSource> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Min<TSource>(this Wrapper<TSource> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Min(this Wrapper<short?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Min(this Wrapper<short> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Min<TSource>(this Wrapper<TSource> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Min<TSource>(this Wrapper<TSource> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Min(this Wrapper<ushort?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Min(this Wrapper<ushort> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Min<TSource>(this Wrapper<TSource> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Min<TSource>(this Wrapper<TSource> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Min(this Wrapper<long?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Min(this Wrapper<long> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Min<TSource>(this Wrapper<TSource> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Min<TSource>(this Wrapper<TSource> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Min(this Wrapper<ulong?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Min(this Wrapper<ulong> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Min<TSource>(this Wrapper<TSource> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Min<TSource>(this Wrapper<TSource> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Min(this Wrapper<float?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Min(this Wrapper<float> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Min<TSource>(this Wrapper<TSource> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Min<TSource>(this Wrapper<TSource> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Min(this Wrapper<double?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Min(this Wrapper<double> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Min<TSource>(this Wrapper<TSource> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Min<TSource>(this Wrapper<TSource> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Min(this Wrapper<decimal?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Min(this Wrapper<decimal> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Min<TSource>(this Wrapper<TSource> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Min<TSource>(this Wrapper<TSource> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Min(this Wrapper<Int128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Min(this Wrapper<Int128> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Min<TSource>(this Wrapper<TSource> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Min<TSource>(this Wrapper<TSource> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Min(this Wrapper<UInt128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Min(this Wrapper<UInt128> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
		public static TResult Min<TSource, TResult>(this Wrapper<TSource> source, Func<TSource, TResult> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Max<TSource>(this Wrapper<TSource> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Max<TSource>(this Wrapper<TSource> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Max(this Wrapper<int?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Max(this Wrapper<int> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Max<TSource>(this Wrapper<TSource> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Max<TSource>(this Wrapper<TSource> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Max(this Wrapper<uint?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Max(this Wrapper<uint> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Max<TSource>(this Wrapper<TSource> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Max<TSource>(this Wrapper<TSource> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Max(this Wrapper<byte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Max(this Wrapper<byte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Max<TSource>(this Wrapper<TSource> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max<TSource>(this Wrapper<TSource> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Max(this Wrapper<sbyte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max(this Wrapper<sbyte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Max<TSource>(this Wrapper<TSource> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Max<TSource>(this Wrapper<TSource> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Max(this Wrapper<short?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Max(this Wrapper<short> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Max<TSource>(this Wrapper<TSource> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Max<TSource>(this Wrapper<TSource> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Max(this Wrapper<ushort?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Max(this Wrapper<ushort> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Max<TSource>(this Wrapper<TSource> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Max<TSource>(this Wrapper<TSource> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Max(this Wrapper<long?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Max(this Wrapper<long> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Max<TSource>(this Wrapper<TSource> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Max<TSource>(this Wrapper<TSource> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Max(this Wrapper<ulong?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Max(this Wrapper<ulong> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Max<TSource>(this Wrapper<TSource> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Max<TSource>(this Wrapper<TSource> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Max(this Wrapper<float?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Max(this Wrapper<float> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Max<TSource>(this Wrapper<TSource> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Max<TSource>(this Wrapper<TSource> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Max(this Wrapper<double?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Max(this Wrapper<double> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Max<TSource>(this Wrapper<TSource> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Max<TSource>(this Wrapper<TSource> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Max(this Wrapper<decimal?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Max(this Wrapper<decimal> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Max<TSource>(this Wrapper<TSource> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Max<TSource>(this Wrapper<TSource> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Max(this Wrapper<Int128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Max(this Wrapper<Int128> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Max<TSource>(this Wrapper<TSource> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Max<TSource>(this Wrapper<TSource> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Max(this Wrapper<UInt128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Max(this Wrapper<UInt128> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
		public static TResult Max<TSource, TResult>(this Wrapper<TSource> source, Func<TSource, TResult> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource>(this Wrapper<TSource> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Sum(this Wrapper<int?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this Wrapper<int> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Sum<TSource>(this Wrapper<TSource> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Sum(this Wrapper<uint?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Sum(this Wrapper<uint> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Sum<TSource>(this Wrapper<TSource> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Sum(this Wrapper<byte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Sum(this Wrapper<byte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Sum<TSource>(this Wrapper<TSource> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Sum(this Wrapper<sbyte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Sum(this Wrapper<sbyte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Sum<TSource>(this Wrapper<TSource> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Sum(this Wrapper<short?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Sum(this Wrapper<short> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Sum<TSource>(this Wrapper<TSource> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Sum(this Wrapper<ushort?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Sum(this Wrapper<ushort> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource>(this Wrapper<TSource> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Sum(this Wrapper<long?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this Wrapper<long> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum<TSource>(this Wrapper<TSource> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Sum(this Wrapper<ulong?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum(this Wrapper<ulong> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource>(this Wrapper<TSource> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Sum(this Wrapper<float?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this Wrapper<float> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource>(this Wrapper<TSource> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Sum(this Wrapper<double?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this Wrapper<double> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource>(this Wrapper<TSource> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Sum(this Wrapper<decimal?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this Wrapper<decimal> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Sum<TSource>(this Wrapper<TSource> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Sum(this Wrapper<Int128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Sum(this Wrapper<Int128> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Sum<TSource>(this Wrapper<TSource> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Sum<TSource>(this Wrapper<TSource> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Sum(this Wrapper<UInt128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Sum(this Wrapper<UInt128> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> ThenBy<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> ThenBy<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> ThenByDescending<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource> ThenByDescending<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this Wrapper<TSource> source) {
            return new[] { source.Value, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector) {
            var value = source.Value;
            return new Dictionary<TKey, TSource> { { keySelector.Invoke(value), value }, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) {
            var dictionary = new Dictionary<TKey, TSource>(comparer);
            var value = source.Value;
            dictionary.Add(keySelector.Invoke(value), value);
            return dictionary;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) {
            var value = source.Value;
            return new Dictionary<TKey, TElement> { { keySelector.Invoke(value), elementSelector.Invoke(value) }, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Wrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) {
            var dictionary = new Dictionary<TKey, TElement>(comparer);
            var value = source.Value;
            dictionary.Add(keySelector.Invoke(value), elementSelector.Invoke(value));
            return dictionary;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Collections.Generic.RefReturnSupported.List<TSource> ToList<TSource>(this Wrapper<TSource> source) {
            return new Collections.Generic.RefReturnSupported.List<TSource>(1) { source.Value, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult> Zip<TFirst, TSecond, TResult>(this Wrapper<TFirst> first, Wrapper<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector) {
            return new Wrapper<TResult>(resultSelector.Invoke(first.Value, second.Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Aggregate<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, TSource, TSource> func) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TAccumulate Aggregate<TSource, TWrapper, TAccumulate>(this Wrapper<TSource, TWrapper> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) {
            return func.Invoke(seed, source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TResult Aggregate<TSource, TWrapper, TAccumulate, TResult>(this Wrapper<TSource, TWrapper> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector) {
            return resultSelector.Invoke(func.Invoke(seed, source.Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return true;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static SingletonEnumerable<TSource> ToEnumerable<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return new SingletonEnumerable<TSource>(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, TSource value) {
            return source.Value.Equals(value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, TSource value, IEqualityComparer<TSource> comparer) {
            return comparer.Equals(source.Value, value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return 1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value) ? 1 : 0;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> DefaultIfEmpty<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> DefaultIfEmpty<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, TSource defaultValue) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> Distinct<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> Distinct<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, IEqualityComparer<TSource> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAt<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, int index) {
            if (0 == index) {
                return source.Value;
            }
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAtOrDefault<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, int index) {
            if (0 == index) {
                return source.Value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult, TWrapper> GroupBy<TSource, TWrapper, TKey, TElement, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, Wrapper<TElement, TWrapper>, TResult> resultSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var element = elementSelector.Invoke(value);
            var result = resultSelector.Invoke(key, new Wrapper<TElement, TWrapper>(element));
            return new Wrapper<TResult, TWrapper>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult, TWrapper> GroupBy<TSource, TWrapper, TKey, TElement, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, Wrapper<TElement, TWrapper>, TResult> resultSelector) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var element = elementSelector.Invoke(value);
            var result = resultSelector.Invoke(key, new Wrapper<TElement, TWrapper>(element));
            return new Wrapper<TResult, TWrapper>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult, TWrapper> GroupBy<TSource, TWrapper, TKey, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TKey, Wrapper<TSource, TWrapper>, TResult> resultSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var result = resultSelector.Invoke(key, source);
            return new Wrapper<TResult, TWrapper>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult, TWrapper> GroupBy<TSource, TWrapper, TKey, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TKey, Wrapper<TSource, TWrapper>, TResult> resultSelector) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var result = resultSelector.Invoke(key, source);
            return new Wrapper<TResult, TWrapper>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<Grouping<TKey, TSource>> GroupBy<TSource, TWrapper, TKey>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            return new Grouping<TKey, TSource>(keySelector.Invoke(value), value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<Grouping<TKey, TElement>> GroupBy<TSource, TWrapper, TKey, TElement>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) {
            var value = source.Value;
            return new Grouping<TKey, TElement>(keySelector.Invoke(value), elementSelector.Invoke(value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<Grouping<TKey, TSource>> GroupBy<TSource, TWrapper, TKey>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector) {
            var value = source.Value;
            return new Grouping<TKey, TSource>(keySelector.Invoke(value), value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<Grouping<TKey, TElement>> GroupBy<TSource, TWrapper, TKey, TElement>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            return new Grouping<TKey, TElement>(keySelector.Invoke(value), elementSelector.Invoke(value));
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Last<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Last<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource LastOrDefault<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource LastOrDefault<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long LongCount<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return 1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long LongCount<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value) ? 1 : 0;
        }
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> OrderBy<TSource, TWrapper, TKey>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> OrderBy<TSource, TWrapper, TKey>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> OrderByDescending<TSource, TWrapper, TKey>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> OrderByDescending<TSource, TWrapper, TKey>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> Reverse<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult, TWrapper> Select<TSource, TWrapper, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, TResult> selector) {
            return new Wrapper<TResult, TWrapper>(selector.Invoke(source.Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult, TWrapper> Select<TSource, TWrapper, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, int, TResult> selector) {
            return new Wrapper<TResult, TWrapper>(selector.Invoke(source.Value, 0));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult, TWrapper> SelectMany<TSource, TWrapper, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, Wrapper<TResult, TWrapper>> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult, TWrapper> SelectMany<TSource, TWrapper, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, int, Wrapper<TResult, TWrapper>> selector) {
            return selector.Invoke(source.Value, 0);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult, TWrapper> SelectMany<TSource, TWrapper, TCollection, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, Wrapper<TCollection, TWrapper>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return new Wrapper<TResult, TWrapper>(resultSelector.Invoke(value, collectionSelector.Invoke(value).Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> SelectMany<TSource, TWrapper, TCollection, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return collectionSelector.Invoke(value).Select((collection_value) => resultSelector.Invoke(value, collection_value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult, TWrapper> SelectMany<TSource, TWrapper, TCollection, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, int, Wrapper<TCollection, TWrapper>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return new Wrapper<TResult, TWrapper>(resultSelector.Invoke(value, collectionSelector.Invoke(value, 0).Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool SequenceEqual<TSource, TWrapper>(this Wrapper<TSource, TWrapper> first, Wrapper<TSource, TWrapper> second, IEqualityComparer<TSource> comparer) {
            return comparer.Equals(first.Value, second.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool SequenceEqual<TSource, TWrapper>(this Wrapper<TSource, TWrapper> first, Wrapper<TSource, TWrapper> second) {
            return EqualityComparer<TSource>.Default.Equals(first.Value, second.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Average<TWrapper>(this Wrapper<int?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Average<TWrapper>(this Wrapper<int, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Average<TWrapper>(this Wrapper<uint?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Average<TWrapper>(this Wrapper<uint, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Average<TWrapper>(this Wrapper<byte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Average<TWrapper>(this Wrapper<byte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Average<TWrapper>(this Wrapper<sbyte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Average<TWrapper>(this Wrapper<sbyte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Average<TWrapper>(this Wrapper<short?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Average<TWrapper>(this Wrapper<short, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Average<TWrapper>(this Wrapper<ushort?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Average<TWrapper>(this Wrapper<ushort, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Average<TWrapper>(this Wrapper<long?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Average<TWrapper>(this Wrapper<long, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Average<TWrapper>(this Wrapper<ulong?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Average<TWrapper>(this Wrapper<ulong, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Average<TWrapper>(this Wrapper<float?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Average<TWrapper>(this Wrapper<float, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Average<TWrapper>(this Wrapper<double?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Average<TWrapper>(this Wrapper<double, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Average<TWrapper>(this Wrapper<decimal?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Average<TWrapper>(this Wrapper<decimal, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Average<TWrapper>(this Wrapper<Int128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Average<TWrapper>(this Wrapper<Int128, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Average<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Average<TWrapper>(this Wrapper<UInt128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Average<TWrapper>(this Wrapper<UInt128, TWrapper> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Min<TWrapper>(this Wrapper<int?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Min<TWrapper>(this Wrapper<int, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Min<TWrapper>(this Wrapper<uint?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Min<TWrapper>(this Wrapper<uint, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Min<TWrapper>(this Wrapper<byte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Min<TWrapper>(this Wrapper<byte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Min<TWrapper>(this Wrapper<sbyte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Min<TWrapper>(this Wrapper<sbyte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Min<TWrapper>(this Wrapper<short?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Min<TWrapper>(this Wrapper<short, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Min<TWrapper>(this Wrapper<ushort?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Min<TWrapper>(this Wrapper<ushort, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Min<TWrapper>(this Wrapper<long?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Min<TWrapper>(this Wrapper<long, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Min<TWrapper>(this Wrapper<ulong?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Min<TWrapper>(this Wrapper<ulong, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Min<TWrapper>(this Wrapper<float?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Min<TWrapper>(this Wrapper<float, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Min<TWrapper>(this Wrapper<double?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Min<TWrapper>(this Wrapper<double, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Min<TWrapper>(this Wrapper<decimal?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Min<TWrapper>(this Wrapper<decimal, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Min<TWrapper>(this Wrapper<Int128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Min<TWrapper>(this Wrapper<Int128, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Min<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Min<TWrapper>(this Wrapper<UInt128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Min<TWrapper>(this Wrapper<UInt128, TWrapper> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
		public static TResult Min<TSource, TWrapper, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, TResult> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Max<TWrapper>(this Wrapper<int?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Max<TWrapper>(this Wrapper<int, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Max<TWrapper>(this Wrapper<uint?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Max<TWrapper>(this Wrapper<uint, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Max<TWrapper>(this Wrapper<byte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Max<TWrapper>(this Wrapper<byte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Max<TWrapper>(this Wrapper<sbyte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max<TWrapper>(this Wrapper<sbyte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Max<TWrapper>(this Wrapper<short?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Max<TWrapper>(this Wrapper<short, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Max<TWrapper>(this Wrapper<ushort?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Max<TWrapper>(this Wrapper<ushort, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Max<TWrapper>(this Wrapper<long?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Max<TWrapper>(this Wrapper<long, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Max<TWrapper>(this Wrapper<ulong?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Max<TWrapper>(this Wrapper<ulong, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Max<TWrapper>(this Wrapper<float?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Max<TWrapper>(this Wrapper<float, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Max<TWrapper>(this Wrapper<double?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Max<TWrapper>(this Wrapper<double, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Max<TWrapper>(this Wrapper<decimal?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Max<TWrapper>(this Wrapper<decimal, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Max<TWrapper>(this Wrapper<Int128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Max<TWrapper>(this Wrapper<Int128, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Max<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Max<TWrapper>(this Wrapper<UInt128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Max<TWrapper>(this Wrapper<UInt128, TWrapper> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
		public static TResult Max<TSource, TWrapper, TResult>(this Wrapper<TSource, TWrapper> source, Func<TSource, TResult> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Sum<TWrapper>(this Wrapper<int?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TWrapper>(this Wrapper<int, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Sum<TWrapper>(this Wrapper<uint?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Sum<TWrapper>(this Wrapper<uint, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Sum<TWrapper>(this Wrapper<byte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Sum<TWrapper>(this Wrapper<byte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Sum<TWrapper>(this Wrapper<sbyte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Sum<TWrapper>(this Wrapper<sbyte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Sum<TWrapper>(this Wrapper<short?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Sum<TWrapper>(this Wrapper<short, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Sum<TWrapper>(this Wrapper<ushort?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Sum<TWrapper>(this Wrapper<ushort, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Sum<TWrapper>(this Wrapper<long?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TWrapper>(this Wrapper<long, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Sum<TWrapper>(this Wrapper<ulong?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum<TWrapper>(this Wrapper<ulong, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Sum<TWrapper>(this Wrapper<float?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TWrapper>(this Wrapper<float, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Sum<TWrapper>(this Wrapper<double?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TWrapper>(this Wrapper<double, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Sum<TWrapper>(this Wrapper<decimal?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TWrapper>(this Wrapper<decimal, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Sum<TWrapper>(this Wrapper<Int128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Sum<TWrapper>(this Wrapper<Int128, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Sum<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Sum<TWrapper>(this Wrapper<UInt128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Sum<TWrapper>(this Wrapper<UInt128, TWrapper> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> ThenBy<TSource, TWrapper, TKey>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> ThenBy<TSource, TWrapper, TKey>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> ThenByDescending<TSource, TWrapper, TKey>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TSource, TWrapper> ThenByDescending<TSource, TWrapper, TKey>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return new[] { source.Value, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TWrapper, TKey>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector) {
            var value = source.Value;
            return new Dictionary<TKey, TSource> { { keySelector.Invoke(value), value }, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TWrapper, TKey>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) {
            var dictionary = new Dictionary<TKey, TSource>(comparer);
            var value = source.Value;
            dictionary.Add(keySelector.Invoke(value), value);
            return dictionary;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TWrapper, TKey, TElement>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) {
            var value = source.Value;
            return new Dictionary<TKey, TElement> { { keySelector.Invoke(value), elementSelector.Invoke(value) }, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TWrapper, TKey, TElement>(this Wrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) {
            var dictionary = new Dictionary<TKey, TElement>(comparer);
            var value = source.Value;
            dictionary.Add(keySelector.Invoke(value), elementSelector.Invoke(value));
            return dictionary;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Collections.Generic.RefReturnSupported.List<TSource> ToList<TSource, TWrapper>(this Wrapper<TSource, TWrapper> source) {
            return new Collections.Generic.RefReturnSupported.List<TSource>(1) { source.Value, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Wrapper<TResult, TWrapper> Zip<TFirst, TWrapper, TSecond, TResult>(this Wrapper<TFirst, TWrapper> first, Wrapper<TSecond, TWrapper> second, Func<TFirst, TSecond, TResult> resultSelector) {
            return new Wrapper<TResult, TWrapper>(resultSelector.Invoke(first.Value, second.Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Aggregate<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, TSource, TSource> func) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TAccumulate Aggregate<TSource, TAccumulate>(this ReadOnlyWrapper<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) {
            return func.Invoke(seed, source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TResult Aggregate<TSource, TAccumulate, TResult>(this ReadOnlyWrapper<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector) {
            return resultSelector.Invoke(func.Invoke(seed, source.Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ReadOnlyWrapper<TSource> source) {
            return true;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static SingletonEnumerable<TSource> ToEnumerable<TSource>(this ReadOnlyWrapper<TSource> source) {
            return new SingletonEnumerable<TSource>(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this ReadOnlyWrapper<TSource> source, TSource value) {
            return source.Value.Equals(value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this ReadOnlyWrapper<TSource> source, TSource value, IEqualityComparer<TSource> comparer) {
            return comparer.Equals(source.Value, value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ReadOnlyWrapper<TSource> source) {
            return 1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value) ? 1 : 0;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> DefaultIfEmpty<TSource>(this ReadOnlyWrapper<TSource> source) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> DefaultIfEmpty<TSource>(this ReadOnlyWrapper<TSource> source, TSource defaultValue) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> Distinct<TSource>(this ReadOnlyWrapper<TSource> source) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> Distinct<TSource>(this ReadOnlyWrapper<TSource> source, IEqualityComparer<TSource> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAt<TSource>(this ReadOnlyWrapper<TSource> source, int index) {
            if (0 == index) {
                return source.Value;
            }
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAtOrDefault<TSource>(this ReadOnlyWrapper<TSource> source, int index) {
            if (0 == index) {
                return source.Value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TSource>(this ReadOnlyWrapper<TSource> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TSource>(this ReadOnlyWrapper<TSource> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult> GroupBy<TSource, TKey, TElement, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, ReadOnlyWrapper<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var element = elementSelector.Invoke(value);
            var result = resultSelector.Invoke(key, new ReadOnlyWrapper<TElement>(element));
            return new ReadOnlyWrapper<TResult>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult> GroupBy<TSource, TKey, TElement, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, ReadOnlyWrapper<TElement>, TResult> resultSelector) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var element = elementSelector.Invoke(value);
            var result = resultSelector.Invoke(key, new ReadOnlyWrapper<TElement>(element));
            return new ReadOnlyWrapper<TResult>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult> GroupBy<TSource, TKey, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, ReadOnlyWrapper<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var result = resultSelector.Invoke(key, source);
            return new ReadOnlyWrapper<TResult>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult> GroupBy<TSource, TKey, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, ReadOnlyWrapper<TSource>, TResult> resultSelector) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var result = resultSelector.Invoke(key, source);
            return new ReadOnlyWrapper<TResult>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<Grouping<TKey, TSource>> GroupBy<TSource, TKey>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            return new Grouping<TKey, TSource>(keySelector.Invoke(value), value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<Grouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) {
            var value = source.Value;
            return new Grouping<TKey, TElement>(keySelector.Invoke(value), elementSelector.Invoke(value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<Grouping<TKey, TSource>> GroupBy<TSource, TKey>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector) {
            var value = source.Value;
            return new Grouping<TKey, TSource>(keySelector.Invoke(value), value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<Grouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            return new Grouping<TKey, TElement>(keySelector.Invoke(value), elementSelector.Invoke(value));
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Last<TSource>(this ReadOnlyWrapper<TSource> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Last<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource LastOrDefault<TSource>(this ReadOnlyWrapper<TSource> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource LastOrDefault<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long LongCount<TSource>(this ReadOnlyWrapper<TSource> source) {
            return 1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long LongCount<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value) ? 1 : 0;
        }
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> OrderBy<TSource, TKey>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> OrderBy<TSource, TKey>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> OrderByDescending<TSource, TKey>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> OrderByDescending<TSource, TKey>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> Reverse<TSource>(this ReadOnlyWrapper<TSource> source) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult> Select<TSource, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, TResult> selector) {
            return new ReadOnlyWrapper<TResult>(selector.Invoke(source.Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult> Select<TSource, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, int, TResult> selector) {
            return new ReadOnlyWrapper<TResult>(selector.Invoke(source.Value, 0));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult> SelectMany<TSource, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, ReadOnlyWrapper<TResult>> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult> SelectMany<TSource, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, int, ReadOnlyWrapper<TResult>> selector) {
            return selector.Invoke(source.Value, 0);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult> SelectMany<TSource, TCollection, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, ReadOnlyWrapper<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return new ReadOnlyWrapper<TResult>(resultSelector.Invoke(value, collectionSelector.Invoke(value).Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return collectionSelector.Invoke(value).Select((collection_value) => resultSelector.Invoke(value, collection_value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult> SelectMany<TSource, TCollection, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, int, ReadOnlyWrapper<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return new ReadOnlyWrapper<TResult>(resultSelector.Invoke(value, collectionSelector.Invoke(value, 0).Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool SequenceEqual<TSource>(this ReadOnlyWrapper<TSource> first, ReadOnlyWrapper<TSource> second, IEqualityComparer<TSource> comparer) {
            return comparer.Equals(first.Value, second.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool SequenceEqual<TSource>(this ReadOnlyWrapper<TSource> first, ReadOnlyWrapper<TSource> second) {
            return EqualityComparer<TSource>.Default.Equals(first.Value, second.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TSource>(this ReadOnlyWrapper<TSource> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TSource>(this ReadOnlyWrapper<TSource> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Average(this ReadOnlyWrapper<int?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Average(this ReadOnlyWrapper<int> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Average(this ReadOnlyWrapper<uint?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Average(this ReadOnlyWrapper<uint> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Average(this ReadOnlyWrapper<byte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Average(this ReadOnlyWrapper<byte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Average(this ReadOnlyWrapper<sbyte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Average(this ReadOnlyWrapper<sbyte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Average(this ReadOnlyWrapper<short?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Average(this ReadOnlyWrapper<short> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Average(this ReadOnlyWrapper<ushort?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Average(this ReadOnlyWrapper<ushort> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Average(this ReadOnlyWrapper<long?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Average(this ReadOnlyWrapper<long> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Average(this ReadOnlyWrapper<ulong?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Average(this ReadOnlyWrapper<ulong> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Average(this ReadOnlyWrapper<float?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Average(this ReadOnlyWrapper<float> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Average(this ReadOnlyWrapper<double?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Average(this ReadOnlyWrapper<double> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Average(this ReadOnlyWrapper<decimal?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Average(this ReadOnlyWrapper<decimal> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Average(this ReadOnlyWrapper<Int128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Average(this ReadOnlyWrapper<Int128> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Average<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Average(this ReadOnlyWrapper<UInt128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Average(this ReadOnlyWrapper<UInt128> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Min(this ReadOnlyWrapper<int?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Min(this ReadOnlyWrapper<int> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Min(this ReadOnlyWrapper<uint?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Min(this ReadOnlyWrapper<uint> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Min(this ReadOnlyWrapper<byte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Min(this ReadOnlyWrapper<byte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Min(this ReadOnlyWrapper<sbyte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Min(this ReadOnlyWrapper<sbyte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Min(this ReadOnlyWrapper<short?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Min(this ReadOnlyWrapper<short> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Min(this ReadOnlyWrapper<ushort?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Min(this ReadOnlyWrapper<ushort> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Min(this ReadOnlyWrapper<long?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Min(this ReadOnlyWrapper<long> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Min(this ReadOnlyWrapper<ulong?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Min(this ReadOnlyWrapper<ulong> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Min(this ReadOnlyWrapper<float?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Min(this ReadOnlyWrapper<float> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Min(this ReadOnlyWrapper<double?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Min(this ReadOnlyWrapper<double> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Min(this ReadOnlyWrapper<decimal?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Min(this ReadOnlyWrapper<decimal> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Min(this ReadOnlyWrapper<Int128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Min(this ReadOnlyWrapper<Int128> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Min<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Min(this ReadOnlyWrapper<UInt128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Min(this ReadOnlyWrapper<UInt128> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
		public static TResult Min<TSource, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, TResult> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Max(this ReadOnlyWrapper<int?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Max(this ReadOnlyWrapper<int> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Max(this ReadOnlyWrapper<uint?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Max(this ReadOnlyWrapper<uint> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Max(this ReadOnlyWrapper<byte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Max(this ReadOnlyWrapper<byte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Max(this ReadOnlyWrapper<sbyte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max(this ReadOnlyWrapper<sbyte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Max(this ReadOnlyWrapper<short?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Max(this ReadOnlyWrapper<short> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Max(this ReadOnlyWrapper<ushort?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Max(this ReadOnlyWrapper<ushort> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Max(this ReadOnlyWrapper<long?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Max(this ReadOnlyWrapper<long> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Max(this ReadOnlyWrapper<ulong?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Max(this ReadOnlyWrapper<ulong> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Max(this ReadOnlyWrapper<float?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Max(this ReadOnlyWrapper<float> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Max(this ReadOnlyWrapper<double?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Max(this ReadOnlyWrapper<double> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Max(this ReadOnlyWrapper<decimal?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Max(this ReadOnlyWrapper<decimal> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Max(this ReadOnlyWrapper<Int128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Max(this ReadOnlyWrapper<Int128> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Max<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Max(this ReadOnlyWrapper<UInt128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Max(this ReadOnlyWrapper<UInt128> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
		public static TResult Max<TSource, TResult>(this ReadOnlyWrapper<TSource> source, Func<TSource, TResult> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Sum(this ReadOnlyWrapper<int?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ReadOnlyWrapper<int> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Sum(this ReadOnlyWrapper<uint?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Sum(this ReadOnlyWrapper<uint> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Sum(this ReadOnlyWrapper<byte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Sum(this ReadOnlyWrapper<byte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Sum(this ReadOnlyWrapper<sbyte?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Sum(this ReadOnlyWrapper<sbyte> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Sum(this ReadOnlyWrapper<short?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Sum(this ReadOnlyWrapper<short> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Sum(this ReadOnlyWrapper<ushort?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Sum(this ReadOnlyWrapper<ushort> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Sum(this ReadOnlyWrapper<long?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ReadOnlyWrapper<long> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Sum(this ReadOnlyWrapper<ulong?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum(this ReadOnlyWrapper<ulong> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Sum(this ReadOnlyWrapper<float?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ReadOnlyWrapper<float> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Sum(this ReadOnlyWrapper<double?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ReadOnlyWrapper<double> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Sum(this ReadOnlyWrapper<decimal?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ReadOnlyWrapper<decimal> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Sum(this ReadOnlyWrapper<Int128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Sum(this ReadOnlyWrapper<Int128> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Sum<TSource>(this ReadOnlyWrapper<TSource> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Sum(this ReadOnlyWrapper<UInt128?> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Sum(this ReadOnlyWrapper<UInt128> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> ThenBy<TSource, TKey>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> ThenBy<TSource, TKey>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> ThenByDescending<TSource, TKey>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource> ThenByDescending<TSource, TKey>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this ReadOnlyWrapper<TSource> source) {
            return new[] { source.Value, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector) {
            var value = source.Value;
            return new Dictionary<TKey, TSource> { { keySelector.Invoke(value), value }, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) {
            var dictionary = new Dictionary<TKey, TSource>(comparer);
            var value = source.Value;
            dictionary.Add(keySelector.Invoke(value), value);
            return dictionary;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) {
            var value = source.Value;
            return new Dictionary<TKey, TElement> { { keySelector.Invoke(value), elementSelector.Invoke(value) }, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ReadOnlyWrapper<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) {
            var dictionary = new Dictionary<TKey, TElement>(comparer);
            var value = source.Value;
            dictionary.Add(keySelector.Invoke(value), elementSelector.Invoke(value));
            return dictionary;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Collections.Generic.RefReturnSupported.List<TSource> ToList<TSource>(this ReadOnlyWrapper<TSource> source) {
            return new Collections.Generic.RefReturnSupported.List<TSource>(1) { source.Value, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult> Zip<TFirst, TSecond, TResult>(this ReadOnlyWrapper<TFirst> first, ReadOnlyWrapper<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector) {
            return new ReadOnlyWrapper<TResult>(resultSelector.Invoke(first.Value, second.Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Aggregate<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TSource, TSource> func) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TAccumulate Aggregate<TSource, TWrapper, TAccumulate>(this ReadOnlyWrapper<TSource, TWrapper> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) {
            return func.Invoke(seed, source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TResult Aggregate<TSource, TWrapper, TAccumulate, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector) {
            return resultSelector.Invoke(func.Invoke(seed, source.Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return true;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static SingletonEnumerable<TSource> ToEnumerable<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return new SingletonEnumerable<TSource>(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, TSource value) {
            return source.Value.Equals(value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, TSource value, IEqualityComparer<TSource> comparer) {
            return comparer.Equals(source.Value, value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return 1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value) ? 1 : 0;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> DefaultIfEmpty<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> DefaultIfEmpty<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, TSource defaultValue) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> Distinct<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> Distinct<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, IEqualityComparer<TSource> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAt<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, int index) {
            if (0 == index) {
                return source.Value;
            }
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAtOrDefault<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, int index) {
            if (0 == index) {
                return source.Value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult, TWrapper> GroupBy<TSource, TWrapper, TKey, TElement, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, ReadOnlyWrapper<TElement, TWrapper>, TResult> resultSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var element = elementSelector.Invoke(value);
            var result = resultSelector.Invoke(key, new ReadOnlyWrapper<TElement, TWrapper>(element));
            return new ReadOnlyWrapper<TResult, TWrapper>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult, TWrapper> GroupBy<TSource, TWrapper, TKey, TElement, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, ReadOnlyWrapper<TElement, TWrapper>, TResult> resultSelector) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var element = elementSelector.Invoke(value);
            var result = resultSelector.Invoke(key, new ReadOnlyWrapper<TElement, TWrapper>(element));
            return new ReadOnlyWrapper<TResult, TWrapper>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult, TWrapper> GroupBy<TSource, TWrapper, TKey, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TKey, ReadOnlyWrapper<TSource, TWrapper>, TResult> resultSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var result = resultSelector.Invoke(key, source);
            return new ReadOnlyWrapper<TResult, TWrapper>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult, TWrapper> GroupBy<TSource, TWrapper, TKey, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TKey, ReadOnlyWrapper<TSource, TWrapper>, TResult> resultSelector) {
            var value = source.Value;
            var key = keySelector.Invoke(value);
            var result = resultSelector.Invoke(key, source);
            return new ReadOnlyWrapper<TResult, TWrapper>(result);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<Grouping<TKey, TSource>> GroupBy<TSource, TWrapper, TKey>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            return new Grouping<TKey, TSource>(keySelector.Invoke(value), value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<Grouping<TKey, TElement>> GroupBy<TSource, TWrapper, TKey, TElement>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) {
            var value = source.Value;
            return new Grouping<TKey, TElement>(keySelector.Invoke(value), elementSelector.Invoke(value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<Grouping<TKey, TSource>> GroupBy<TSource, TWrapper, TKey>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector) {
            var value = source.Value;
            return new Grouping<TKey, TSource>(keySelector.Invoke(value), value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<Grouping<TKey, TElement>> GroupBy<TSource, TWrapper, TKey, TElement>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) {
            var value = source.Value;
            return new Grouping<TKey, TElement>(keySelector.Invoke(value), elementSelector.Invoke(value));
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Last<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Last<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource LastOrDefault<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource LastOrDefault<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long LongCount<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return 1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long LongCount<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            return predicate.Invoke(source.Value) ? 1 : 0;
        }
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> OrderBy<TSource, TWrapper, TKey>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> OrderBy<TSource, TWrapper, TKey>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> OrderByDescending<TSource, TWrapper, TKey>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> OrderByDescending<TSource, TWrapper, TKey>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> Reverse<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult, TWrapper> Select<TSource, TWrapper, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TResult> selector) {
            return new ReadOnlyWrapper<TResult, TWrapper>(selector.Invoke(source.Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult, TWrapper> Select<TSource, TWrapper, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, int, TResult> selector) {
            return new ReadOnlyWrapper<TResult, TWrapper>(selector.Invoke(source.Value, 0));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult, TWrapper> SelectMany<TSource, TWrapper, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ReadOnlyWrapper<TResult, TWrapper>> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult, TWrapper> SelectMany<TSource, TWrapper, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, int, ReadOnlyWrapper<TResult, TWrapper>> selector) {
            return selector.Invoke(source.Value, 0);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult, TWrapper> SelectMany<TSource, TWrapper, TCollection, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ReadOnlyWrapper<TCollection, TWrapper>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return new ReadOnlyWrapper<TResult, TWrapper>(resultSelector.Invoke(value, collectionSelector.Invoke(value).Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> SelectMany<TSource, TWrapper, TCollection, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return collectionSelector.Invoke(value).Select((collection_value) => resultSelector.Invoke(value, collection_value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult, TWrapper> SelectMany<TSource, TWrapper, TCollection, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, int, ReadOnlyWrapper<TCollection, TWrapper>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) {
            var value = source.Value;
            return new ReadOnlyWrapper<TResult, TWrapper>(resultSelector.Invoke(value, collectionSelector.Invoke(value, 0).Value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool SequenceEqual<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> first, ReadOnlyWrapper<TSource, TWrapper> second, IEqualityComparer<TSource> comparer) {
            return comparer.Equals(first.Value, second.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool SequenceEqual<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> first, ReadOnlyWrapper<TSource, TWrapper> second) {
            return EqualityComparer<TSource>.Default.Equals(first.Value, second.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, bool> predicate) {
            var value = source.Value;
            if (predicate.Invoke(value)) {
                return value;
            }
            return default;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Average<TWrapper>(this ReadOnlyWrapper<int?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Average<TWrapper>(this ReadOnlyWrapper<int, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Average<TWrapper>(this ReadOnlyWrapper<uint?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Average<TWrapper>(this ReadOnlyWrapper<uint, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Average<TWrapper>(this ReadOnlyWrapper<byte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Average<TWrapper>(this ReadOnlyWrapper<byte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Average<TWrapper>(this ReadOnlyWrapper<sbyte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Average<TWrapper>(this ReadOnlyWrapper<sbyte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Average<TWrapper>(this ReadOnlyWrapper<short?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Average<TWrapper>(this ReadOnlyWrapper<short, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Average<TWrapper>(this ReadOnlyWrapper<ushort?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Average<TWrapper>(this ReadOnlyWrapper<ushort, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Average<TWrapper>(this ReadOnlyWrapper<long?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Average<TWrapper>(this ReadOnlyWrapper<long, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Average<TWrapper>(this ReadOnlyWrapper<ulong?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Average<TWrapper>(this ReadOnlyWrapper<ulong, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Average<TWrapper>(this ReadOnlyWrapper<float?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Average<TWrapper>(this ReadOnlyWrapper<float, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Average<TWrapper>(this ReadOnlyWrapper<double?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Average<TWrapper>(this ReadOnlyWrapper<double, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Average<TWrapper>(this ReadOnlyWrapper<decimal?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Average<TWrapper>(this ReadOnlyWrapper<decimal, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Average<TWrapper>(this ReadOnlyWrapper<Int128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Average<TWrapper>(this ReadOnlyWrapper<Int128, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Average<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Average<TWrapper>(this ReadOnlyWrapper<UInt128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Average<TWrapper>(this ReadOnlyWrapper<UInt128, TWrapper> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Min<TWrapper>(this ReadOnlyWrapper<int?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Min<TWrapper>(this ReadOnlyWrapper<int, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Min<TWrapper>(this ReadOnlyWrapper<uint?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Min<TWrapper>(this ReadOnlyWrapper<uint, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Min<TWrapper>(this ReadOnlyWrapper<byte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Min<TWrapper>(this ReadOnlyWrapper<byte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Min<TWrapper>(this ReadOnlyWrapper<sbyte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Min<TWrapper>(this ReadOnlyWrapper<sbyte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Min<TWrapper>(this ReadOnlyWrapper<short?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Min<TWrapper>(this ReadOnlyWrapper<short, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Min<TWrapper>(this ReadOnlyWrapper<ushort?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Min<TWrapper>(this ReadOnlyWrapper<ushort, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Min<TWrapper>(this ReadOnlyWrapper<long?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Min<TWrapper>(this ReadOnlyWrapper<long, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Min<TWrapper>(this ReadOnlyWrapper<ulong?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Min<TWrapper>(this ReadOnlyWrapper<ulong, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Min<TWrapper>(this ReadOnlyWrapper<float?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Min<TWrapper>(this ReadOnlyWrapper<float, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Min<TWrapper>(this ReadOnlyWrapper<double?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Min<TWrapper>(this ReadOnlyWrapper<double, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Min<TWrapper>(this ReadOnlyWrapper<decimal?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Min<TWrapper>(this ReadOnlyWrapper<decimal, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Min<TWrapper>(this ReadOnlyWrapper<Int128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Min<TWrapper>(this ReadOnlyWrapper<Int128, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Min<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Min<TWrapper>(this ReadOnlyWrapper<UInt128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Min<TWrapper>(this ReadOnlyWrapper<UInt128, TWrapper> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
		public static TResult Min<TSource, TWrapper, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TResult> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Max<TWrapper>(this ReadOnlyWrapper<int?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Max<TWrapper>(this ReadOnlyWrapper<int, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Max<TWrapper>(this ReadOnlyWrapper<uint?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Max<TWrapper>(this ReadOnlyWrapper<uint, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Max<TWrapper>(this ReadOnlyWrapper<byte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Max<TWrapper>(this ReadOnlyWrapper<byte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Max<TWrapper>(this ReadOnlyWrapper<sbyte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max<TWrapper>(this ReadOnlyWrapper<sbyte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Max<TWrapper>(this ReadOnlyWrapper<short?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Max<TWrapper>(this ReadOnlyWrapper<short, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Max<TWrapper>(this ReadOnlyWrapper<ushort?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Max<TWrapper>(this ReadOnlyWrapper<ushort, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Max<TWrapper>(this ReadOnlyWrapper<long?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Max<TWrapper>(this ReadOnlyWrapper<long, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Max<TWrapper>(this ReadOnlyWrapper<ulong?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Max<TWrapper>(this ReadOnlyWrapper<ulong, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Max<TWrapper>(this ReadOnlyWrapper<float?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Max<TWrapper>(this ReadOnlyWrapper<float, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Max<TWrapper>(this ReadOnlyWrapper<double?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Max<TWrapper>(this ReadOnlyWrapper<double, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Max<TWrapper>(this ReadOnlyWrapper<decimal?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Max<TWrapper>(this ReadOnlyWrapper<decimal, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Max<TWrapper>(this ReadOnlyWrapper<Int128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Max<TWrapper>(this ReadOnlyWrapper<Int128, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Max<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Max<TWrapper>(this ReadOnlyWrapper<UInt128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Max<TWrapper>(this ReadOnlyWrapper<UInt128, TWrapper> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
		public static TResult Max<TSource, TWrapper, TResult>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TResult> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, int?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, int> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int? Sum<TWrapper>(this ReadOnlyWrapper<int?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TWrapper>(this ReadOnlyWrapper<int, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, uint?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, uint> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint? Sum<TWrapper>(this ReadOnlyWrapper<uint?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static uint Sum<TWrapper>(this ReadOnlyWrapper<uint, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, byte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, byte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte? Sum<TWrapper>(this ReadOnlyWrapper<byte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte Sum<TWrapper>(this ReadOnlyWrapper<byte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, sbyte?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, sbyte> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Sum<TWrapper>(this ReadOnlyWrapper<sbyte?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static sbyte Sum<TWrapper>(this ReadOnlyWrapper<sbyte, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, short?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, short> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short? Sum<TWrapper>(this ReadOnlyWrapper<short?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static short Sum<TWrapper>(this ReadOnlyWrapper<short, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ushort?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ushort> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort? Sum<TWrapper>(this ReadOnlyWrapper<ushort?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ushort Sum<TWrapper>(this ReadOnlyWrapper<ushort, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, long?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, long> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long? Sum<TWrapper>(this ReadOnlyWrapper<long?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TWrapper>(this ReadOnlyWrapper<long, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ulong?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, ulong> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong? Sum<TWrapper>(this ReadOnlyWrapper<ulong?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum<TWrapper>(this ReadOnlyWrapper<ulong, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, float?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, float> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float? Sum<TWrapper>(this ReadOnlyWrapper<float?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TWrapper>(this ReadOnlyWrapper<float, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, double?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, double> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double? Sum<TWrapper>(this ReadOnlyWrapper<double?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TWrapper>(this ReadOnlyWrapper<double, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, decimal?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, decimal> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal? Sum<TWrapper>(this ReadOnlyWrapper<decimal?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TWrapper>(this ReadOnlyWrapper<decimal, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, Int128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, Int128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128? Sum<TWrapper>(this ReadOnlyWrapper<Int128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Sum<TWrapper>(this ReadOnlyWrapper<Int128, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, UInt128?> selector) {
            return selector.Invoke(source.Value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Sum<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, UInt128> selector) {
            return selector.Invoke(source.Value);
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128? Sum<TWrapper>(this ReadOnlyWrapper<UInt128?, TWrapper> source) {
            return source.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Sum<TWrapper>(this ReadOnlyWrapper<UInt128, TWrapper> source) {
            return source.Value;
        }
		

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> ThenBy<TSource, TWrapper, TKey>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> ThenBy<TSource, TWrapper, TKey>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> ThenByDescending<TSource, TWrapper, TKey>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TSource, TWrapper> ThenByDescending<TSource, TWrapper, TKey>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) {
            return source;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return new[] { source.Value, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TWrapper, TKey>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector) {
            var value = source.Value;
            return new Dictionary<TKey, TSource> { { keySelector.Invoke(value), value }, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TWrapper, TKey>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) {
            var dictionary = new Dictionary<TKey, TSource>(comparer);
            var value = source.Value;
            dictionary.Add(keySelector.Invoke(value), value);
            return dictionary;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TWrapper, TKey, TElement>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) {
            var value = source.Value;
            return new Dictionary<TKey, TElement> { { keySelector.Invoke(value), elementSelector.Invoke(value) }, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TWrapper, TKey, TElement>(this ReadOnlyWrapper<TSource, TWrapper> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) {
            var dictionary = new Dictionary<TKey, TElement>(comparer);
            var value = source.Value;
            dictionary.Add(keySelector.Invoke(value), elementSelector.Invoke(value));
            return dictionary;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Collections.Generic.RefReturnSupported.List<TSource> ToList<TSource, TWrapper>(this ReadOnlyWrapper<TSource, TWrapper> source) {
            return new Collections.Generic.RefReturnSupported.List<TSource>(1) { source.Value, };
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyWrapper<TResult, TWrapper> Zip<TFirst, TWrapper, TSecond, TResult>(this ReadOnlyWrapper<TFirst, TWrapper> first, ReadOnlyWrapper<TSecond, TWrapper> second, Func<TFirst, TSecond, TResult> resultSelector) {
            return new ReadOnlyWrapper<TResult, TWrapper>(resultSelector.Invoke(first.Value, second.Value));
        }
    }
}
