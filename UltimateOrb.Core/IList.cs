using System;
using System.Collections.Generic;

namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;

    public partial interface IList<T, out TEnumerator>
        : IList<T>, ICollection<T, TEnumerator>
        where TEnumerator : IEnumerator<T> {

        int IndexOf<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T>;
    }
}

namespace UltimateOrb.Collections.Generic.ExtraTypeParametersProvided {
    using UltimateOrb;

    public partial interface IList<T, out TEnumerator, in TEqualityComparer>
        : IList<T, TEnumerator>, ICollection<T, TEnumerator, TEqualityComparer>
        where TEnumerator : IEnumerator<T>
        where TEqualityComparer : struct, IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;
    using Generic = UltimateOrb.Collections.Generic;

    public partial interface IList<T, out TEnumerator>
        : Generic.IList<T, TEnumerator>, ICollection<T, TEnumerator>
        where TEnumerator : IEnumerator<T> {

        new ref T this[int index] {

            get;
        }

        new ref T Insert(int index, T item);
    }
}

namespace Internal.System.Collections.Generic {
    using Internal;

    using UltimateOrb;
    using Generic = global::System.Collections.Generic;

    using global::System.Runtime.CompilerServices;

    public static class TList<T> {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
#pragma warning disable IDE1006 // Naming Styles
        public static T get_Item<TList>(TList @this, int index) where TList : Generic.IList<T> {
#pragma warning restore IDE1006 // Naming Styles
            return @this[index];
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
#pragma warning disable IDE1006 // Naming Styles
        public static void set_Item<TList>(TList @this, int index, T value) where TList : Generic.IList<T> {
#pragma warning restore IDE1006 // Naming Styles
            @this[index] = value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Insert<TList>(TList @this, int index, T item) where TList : Generic.IList<T> {
            @this.Insert(index, item);
        }
    }
}