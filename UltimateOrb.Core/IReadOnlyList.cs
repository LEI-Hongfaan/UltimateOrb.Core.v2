using System;
using System.Collections.Generic;

namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;

    public partial interface IReadOnlyList<out T, out TEnumerator>
        : IReadOnlyList<T>, IReadOnlyCollection<T, TEnumerator>
        where TEnumerator : IEnumerator<T> {
    }
}

namespace Internal.System.Collections.Generic {
    using Internal;

    using UltimateOrb;
    using Generic = global::System.Collections.Generic;

    using global::System.Runtime.CompilerServices;

    public static partial class TReadOnlyList<T> {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
#pragma warning disable IDE1006 // Naming Styles
        public static T get_Item<TReadOnlyList>(TReadOnlyList @this, int index) where TReadOnlyList : Generic.IReadOnlyList<T> {
#pragma warning restore IDE1006 // Naming Styles
            return @this[index];
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
#pragma warning disable IDE1006 // Naming Styles
        public static T get_Item<TReadOnlyList>(ref TReadOnlyList @this, int index) where TReadOnlyList : struct, Generic.IReadOnlyList<T> {
#pragma warning restore IDE1006 // Naming Styles
            return @this[index];
        }
    }
}
