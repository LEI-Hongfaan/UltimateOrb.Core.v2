using System.Runtime.CompilerServices;

namespace UltimateOrb.Collections.Generic {

    public partial struct List {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int IndexOf<T, TList, TEqualityComparer>(in TList @this, T item, int offset, int count, TEqualityComparer comparer)
            where TList : System.Collections.Generic.IReadOnlyList<T>
            where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            var boundExclusive = offset + count;
            for (var i = offset; boundExclusive > i; ++i) {
                if (comparer.Equals(@this[i], item)) {
                    return i;
                }
            }
            return -1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int LastIndexOf<T, TList, TEqualityComparer>(in TList @this, T item, int offset, int count, TEqualityComparer comparer)
            where TList : System.Collections.Generic.IReadOnlyList<T>
            where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            var boundExclusive = 1 + offset - count;
            for (var i = offset; boundExclusive <= i; --i) {
                if (comparer.Equals(@this[i], item)) {
                    return i;
                }
            }
            return -1;
        }
    }
}
