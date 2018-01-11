using System;
using System.Collections.Generic;
using UltimateOrb.Collections.Generic;

namespace UltimateOrb {
    using IntT = Int32;
    using UIntT = UInt32;

    public static partial class ListSearchModule {

        public partial interface IRollingHashProvider<in T, TRollingHashCodeBuilder>
            : ISequenceEqualityComparer<T>
            where TRollingHashCodeBuilder : IRollingHashCodeBuilder<T> {

            TRollingHashCodeBuilder CreateHashCodeBuilder<TList>(TList source, IntT start, IntT count) where TList : IReadOnlyList<T>;
        }

        public partial interface IRollingHashCodeBuilder<in T> {

            int GetCurrentHashCode();

            void Shift(T @out, T @in);
        }

        public static IntT SearchRabinKarp<T, TListSource, TListPattern, TRollingHashCodeBuilder, THash>(TListSource source, TListPattern pattern, THash hash)
            where TListSource : IReadOnlyList<T>
            where TListPattern : IReadOnlyList<T>
            where TRollingHashCodeBuilder : IRollingHashCodeBuilder<T>
            where THash : IRollingHashProvider<T, TRollingHashCodeBuilder> {
            var pL = pattern.Count;
            var h = hash.GetHashCode(pattern, 0, pL);
            var sL = source.Count;
            if (pL <= sL) {
                var i = (IntT)0;
                var j = checked((IntT)(i + pL));
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
