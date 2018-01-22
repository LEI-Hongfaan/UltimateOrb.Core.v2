using System;
using System.Collections.Generic;

namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;

    public partial interface IReadOnlyCollection<out T, out TEnumerator>
        : IReadOnlyCollection<T>, IEnumerable<T, TEnumerator>
        where TEnumerator : IEnumerator<T> {

        long LongCount {

            get;
        }
    }
}

namespace UltimateOrb.Collections.Generic.ExtraTypeParametersProvided {
    using UltimateOrb;

    public partial interface IReadOnlyCollection<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyCollection<T, TEnumerator>
        where TEnumerator : IEnumerator<T>
        where TEqualityComparer : struct, IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;
    using Generic = UltimateOrb.Collections.Generic;

    public partial interface IReadOnlyCollection<T, out TEnumerator>
        : Generic.IReadOnlyCollection<T, TEnumerator>, IEnumerable<T, TEnumerator>
        where TEnumerator : IEnumerator<T> {
    }
}
