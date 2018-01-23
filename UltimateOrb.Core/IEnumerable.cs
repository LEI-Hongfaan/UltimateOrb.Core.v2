using System;
using System.Collections.Generic;

namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;

    public partial interface IEnumerable<out T, out TEnumerator>
        : IEnumerable<T>
        where TEnumerator : IEnumerator<T> {

        new TEnumerator GetEnumerator();
    }
}

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;
    using Generic = UltimateOrb.Collections.Generic;

    public partial interface IEnumerable<out T, out TEnumerator>
        : Generic.IEnumerable<T, TEnumerator>
        where TEnumerator : IEnumerator<T> {

        new TEnumerator GetEnumerator();
    }
}

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;
    using Generic = UltimateOrb.Collections.Generic;

    public partial interface IReadOnlyEnumerable<out T, out TEnumerator>
        : Generic.IEnumerable<T, TEnumerator>
        where TEnumerator : IReadOnlyEnumerator<T> {

        new TEnumerator GetEnumerator();
    }
}
