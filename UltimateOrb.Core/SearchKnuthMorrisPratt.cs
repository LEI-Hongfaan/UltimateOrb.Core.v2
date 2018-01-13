using System;
using System.Collections.Generic;
using UltimateOrb.Collections.Generic;

namespace UltimateOrb {
    using IntT = Int32;
    using UIntT = UInt32;

    public static partial class SequenceSearchModule {

        /*
        public struct SearchProcessingUnit_A_KnuthMorrisPratt {

            public static SearchProcessingUnit_A_KnuthMorrisPratt<T> Create<T, TListPattern, TEqualityComparer, TAllocator>(TListPattern pattern, IntT pattern_start, IntT pattern_count, TEqualityComparer equalityComparer, TAllocator allocator)
                where TListPattern : IReadOnlyList<T>
                where TEqualityComparer : IO.IFunc<T, T, bool>
                where TAllocator : IO.IFunc<IntT, (IntT[] Array, IntT Start)> {
                return SearchProcessingUnit_A_KnuthMorrisPratt<T>.Create(pattern, pattern_start, pattern_count, equalityComparer, allocator);
            }
        }
        */

        /*
        public readonly struct SearchProcessingUnit_A_KnuthMorrisPratt {

            internal readonly IntT[] skip_table;

            internal readonly IntT skip_table_start;

            internal SearchProcessingUnit_A_KnuthMorrisPratt(IntT[] skip_table, IntT skip_table_start) {
                this.skip_table = skip_table;
                this.skip_table_start = skip_table_start;
            }

            public static SearchProcessingUnit_A_KnuthMorrisPratt Create<T, TListPattern, TEqualityComparer, TAllocator>(TListPattern pattern, IntT pattern_start, IntT pattern_count, TEqualityComparer equalityComparer, TAllocator allocator)
                where TListPattern : IReadOnlyList<T>
                where TEqualityComparer : IO.IFunc<T, T, bool>
                where TAllocator : IO.IFunc<IntT, (IntT[] Array, IntT Start)> {
                var (skip_table, skip_table_start) = allocator.Invoke(pattern_count);
                var i = (IntT)0;
                var j = -1;
                skip_table[0] = j;
                while (pattern_count > i) {
                    while (j > -1 && !equalityComparer.Invoke(pattern[pattern_start + i], pattern[pattern_start + j])) {
                        j = skip_table[skip_table_start + j];
                    }
                    ++i;
                    ++j;
                    if (equalityComparer.Invoke(pattern[pattern_start + i], pattern[pattern_start + j])) {
                        skip_table[skip_table_start + i] = skip_table[skip_table_start + j];
                    } else {
                        skip_table[skip_table_start + i] = j;
                    }
                }
                return new SearchProcessingUnit_A_KnuthMorrisPratt(skip_table, skip_table_start);
            }

            public IntT IndexOf<T, TListSource, TListPattern, TEqualityComparer, TAllocator>(TListSource source, IntT source_start, IntT source_count, TListPattern pattern, IntT pattern_start, IntT pattern_count, TEqualityComparer equalityComparer)
                where TListSource : IReadOnlyList<T>
                where TListPattern : IReadOnlyList<T>
                where TEqualityComparer : IO.IFunc<T, T, bool> {

            }
        }
        */

        public readonly struct SearchProcessingUnit_A_KnuthMorrisPratt<T, TListPattern, TEqualityComparer, TAllocator>
            where TListPattern : IReadOnlyList<T>
            where TEqualityComparer : IO.IFunc<T, T, bool>
            where TAllocator : IO.IFunc<IntT, (IntT[] Array, IntT Start)> {

            internal readonly IntT[] skip_table;

            internal readonly IntT skip_table_start;

            internal readonly TEqualityComparer equalityComparer;

            internal readonly TListPattern pattern;

            internal readonly IntT pattern_start;

            internal readonly IntT pattern_count;

            internal SearchProcessingUnit_A_KnuthMorrisPratt(IntT[] skip_table, IntT skip_table_start, TListPattern pattern, IntT pattern_start, IntT pattern_count, TEqualityComparer equalityComparer) {
                this.skip_table = skip_table;
                this.skip_table_start = skip_table_start;
                this.equalityComparer = equalityComparer;
                this.pattern = pattern;
                this.pattern_start = pattern_start;
                this.pattern_count = pattern_count;
            }

            public static SearchProcessingUnit_A_KnuthMorrisPratt<T, TListPattern, TEqualityComparer, TAllocator> Create(TListPattern pattern, IntT start, IntT count, TEqualityComparer equalityComparer, TAllocator allocator) {
                var (skip_table, skip_table_start) = allocator.Invoke(checked(1 + count));
                var i = (IntT)0;
                var j = -1;
                skip_table[0] = j;
                while (count > i) {
                    while (j > -1 && !equalityComparer.Invoke(pattern[start + i], pattern[start + j])) {
                        j = skip_table[skip_table_start + j];
                    }
                    ++i;
                    ++j;
                    if (equalityComparer.Invoke(pattern[start + i], pattern[start + j])) {
                        skip_table[skip_table_start + i] = skip_table[skip_table_start + j];
                    } else {
                        skip_table[skip_table_start + i] = j;
                    }
                }
                return new SearchProcessingUnit_A_KnuthMorrisPratt<T, TListPattern, TEqualityComparer, TAllocator>(skip_table, skip_table_start, pattern, start, count, equalityComparer);
            }

            public IntT IndexOf<TListSource>(TListSource source, IntT start, IntT count)
                where TListSource : IReadOnlyList<T> {
                if (null != source) {
                    if (ListModule.CheckSegment<T, TListSource>(source, start, count)) {
                        return IndexOfInternal(source, start, count);
                    }
                    // TODO
                    throw new ArgumentException();
                }
                throw new ArgumentNullException("source");
            }

            internal IntT IndexOfInternal<TListSource>(TListSource source, IntT start, IntT count) where TListSource : IReadOnlyList<T> {
                var pattern_count = this.pattern_count;
                if (pattern_count > 0) {
                    if (pattern_count <= count) {
                        var t = this.skip_table;
                        var s = this.skip_table_start;
                        var pattern = this.pattern;
                        var pattern_start = this.pattern_start;
                        var comparer = this.equalityComparer;
                        var i = start;
                        var j = (IntT)0;
                        while (unchecked(start + count) > i) {
                            while (j > -1 && !comparer.Invoke(pattern[pattern_start + j], source[i])) {
                                j = t[s + j];
                            }
                            ++j;
                            ++i;
                            if (pattern_count <= j) {
                                return i - j;
                            }
                        }
                    }
                    return -1;
                }
                return start;
            }

            public IntT IndexOf<TListSource>(TListSource source)
                where TListSource : IReadOnlyList<T> {
                if (null != source) {
                    return this.IndexOfInternal(source, 0, source.Count);
                }
                throw new ArgumentNullException("source");
            }
        }

        public static IntT IndexOf_A_KnuthMorrisPratt<T, TListSource, TListPattern, TEqualityComparer, TAllocator>(TListSource source, IntT source_start, IntT source_count, TListPattern pattern, IntT pattern_start, IntT pattern_count, TEqualityComparer equalityComparer, TAllocator allocator)
            where TListSource : IReadOnlyList<T>
            where TListPattern : IReadOnlyList<T>
            where TEqualityComparer : IO.IFunc<T, T, bool>
            where TAllocator : IO.IFunc<IntT, (IntT[] Array, IntT Start)> {
            var p = SearchProcessingUnit_A_KnuthMorrisPratt<T, TListPattern, TEqualityComparer, TAllocator>.Create(pattern, pattern_start, pattern_count, equalityComparer, allocator);
            return p.IndexOf(source, source_start, source_count);
        }
    }
}
