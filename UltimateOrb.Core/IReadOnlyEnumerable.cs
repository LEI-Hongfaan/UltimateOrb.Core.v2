namespace UltimateOrb.RefReturn.Collections.Generic {

    public partial interface IReadOnlyEnumerable<T> {

        new IReadOnlyEnumerator<T> GetEnumerator();
    }
}

namespace UltimateOrb.Typed.Collections.Generic {

    public partial interface IReadOnlyEnumerable<out T, out TEnumerator> {

        new TEnumerator GetEnumerator();
    }
}
