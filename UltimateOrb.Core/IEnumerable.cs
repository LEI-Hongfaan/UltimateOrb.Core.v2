namespace UltimateOrb.RefReturn.Collections.Generic {

    public partial interface IEnumerable<T> {

        new RefReturn.Collections.Generic.IEnumerator<T> GetEnumerator();
    }
}

namespace UltimateOrb.Typed.Collections.Generic {

    public partial interface IEnumerable<out T, out TEnumerator> {

        new TEnumerator GetEnumerator();
    }
}
