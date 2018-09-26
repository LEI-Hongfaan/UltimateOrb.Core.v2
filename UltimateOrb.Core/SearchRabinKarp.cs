using System;
using UltimateOrb.Collections.Generic;

namespace UltimateOrb {
    using System.Collections.Generic;

    using IntT = Int32;
    using UIntT = UInt32;

    public static partial class SequenceSearchModule {

        public partial interface ISequenceEqualityComparerWithRollingHash<in T, out TRollingHashCodeBuilder>
            : ISequenceEqualityComparer<T>
            where TRollingHashCodeBuilder : IRollingHashCodeBuilder<T> {

            TRollingHashCodeBuilder CreateHashCodeBuilder<TList>(TList source, IntT start, IntT count) where TList : IReadOnlyList<T>;
        }

        public partial interface IRollingHashCodeBuilder<in T> {

            int GetCurrentHashCode();

            void Shift(T @out, T @in);
        }

        public static IntT IndexOf_A_RabinKarp<T, TListSource, TListPattern, TRollingHashCodeBuilder, THash>(this TListSource source, IntT source_start, IntT source_count, TListPattern pattern, IntT pattern_start, IntT pattern_count, THash hash)
          where TListSource : IReadOnlyList<T>
          where TListPattern : IReadOnlyList<T>
          where TRollingHashCodeBuilder : IRollingHashCodeBuilder<T>
          where THash : ISequenceEqualityComparerWithRollingHash<T, TRollingHashCodeBuilder> {
            var h = hash.GetHashCode(pattern, pattern_start, pattern_count);
            if (pattern_count <= source_count) {
                var i = source_start;
                var j = unchecked(i + pattern_count);
                var v = unchecked(source_start + source_count);
                var g = hash.CreateHashCodeBuilder(source, i, pattern_count);
                for (; ; ) {
                    var k = g.GetCurrentHashCode();
                    if (h == k) {
                        if (hash.Equals(pattern, 0, pattern_count, source, i, pattern_count)) {
                            return i;
                        }
                    }
                    ++j;
                    if (v <= j) {
                        break;
                    }
                    ++i;
                    g.Shift(source[unchecked(i - 1)], source[unchecked(j - 1)]);
                }
            }
            return -1;
        }

        public static IntT IndexOf_A_RabinKarp<T, TListSource, TListPattern, TRollingHashCodeBuilder, THash>(TListSource source, TListPattern pattern, THash hash)
            where TListSource : IReadOnlyList<T>
            where TListPattern : IReadOnlyList<T>
            where TRollingHashCodeBuilder : IRollingHashCodeBuilder<T>
            where THash : ISequenceEqualityComparerWithRollingHash<T, TRollingHashCodeBuilder> {
            var pL = pattern.Count;
            var sL = source.Count;
            var h = hash.GetHashCode(pattern, 0, pL);
            if (pL <= sL) {
                var i = (IntT)0;
                var j = i + pL;
                var g = hash.CreateHashCodeBuilder(source, i, pL);
                for (; ; ) {
                    var k = g.GetCurrentHashCode();
                    if (h == k) {
                        if (hash.Equals(pattern, 0, pL, source, i, pL)) {
                            return i;
                        }
                    }
                    ++j;
                    if (sL <= j) {
                        break;
                    }
                    ++i;
                    g.Shift(source[unchecked(i - 1)], source[unchecked(j - 1)]);
                }
            }
            return -1;
        }
    }
}
