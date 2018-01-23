using System;
using System.Collections.Generic;

namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;

    public partial interface IReadOnlyList<out T, out TEnumerator>
        : IReadOnlyList<T>, IReadOnlyCollection<T, TEnumerator>
        where TEnumerator : IEnumerator<T> {
    }
}

namespace UltimateOrb.Collections.Generic.ExtraTypeParametersProvided {
    using UltimateOrb;

    public partial interface IReadOnlyList<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyList<T, TEnumerator>, IReadOnlyCollection<T, TEnumerator, TEqualityComparer>
        where TEnumerator : IEnumerator<T>
        where TEqualityComparer : struct, IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;
    using Generic = UltimateOrb.Collections.Generic;

    public partial interface IReadOnlyList<T, out TEnumerator>
        : Generic.IReadOnlyList<T, TEnumerator>, IReadOnlyCollection<T, TEnumerator>
        where TEnumerator : IReadOnlyEnumerator<T> {

        new ref readonly T this[int index] {

            get;
        }
    }
}

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;
    using Generic = UltimateOrb.Collections.Generic;

    using global::System.Runtime.CompilerServices;

    public static partial class TReadOnlyList<T, TEnumerator>
        where TEnumerator : IReadOnlyEnumerator<T> {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
#pragma warning disable IDE1006 // Naming Styles
        public static ref readonly T get_Item<TReadOnlyList>(TReadOnlyList @this, int index) where TReadOnlyList : IReadOnlyList<T, TEnumerator> {
#pragma warning restore IDE1006 // Naming Styles
            return ref @this[index];
        }
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
