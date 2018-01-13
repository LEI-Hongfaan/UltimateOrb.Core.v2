using System;
using System.Collections.Generic;

namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;

    public partial interface ICollection<T, out TEnumerator>
        : ICollection<T>, IEnumerable<T, TEnumerator>
        where TEnumerator : IEnumerator<T> {

        long LongCount {

            get;
        }

        bool Contains<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T>;

        bool Remove<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T>;
    }
}

namespace UltimateOrb.Collections.Generic.ExtraTypeParametersProvided {
    using UltimateOrb;

    public partial interface ICollection<T, out TEnumerator, in TEqualityComparer>
        : ICollection<T, TEnumerator>
        where TEnumerator : IEnumerator<T>
        where TEqualityComparer : struct, IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;
    using Generic = UltimateOrb.Collections.Generic;

    public partial interface ICollection<T, out TEnumerator>
        : Generic.ICollection<T, TEnumerator>, IEnumerable<T, TEnumerator>
        where TEnumerator : IEnumerator<T> {

        new ref T Add(T item);
    }
}
