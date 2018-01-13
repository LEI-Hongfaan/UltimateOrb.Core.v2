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
