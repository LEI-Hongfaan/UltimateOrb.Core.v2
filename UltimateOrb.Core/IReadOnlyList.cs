
namespace UltimateOrb.Huge.Collections.Generic {

    public partial interface IReadOnlyList<out T> {

        T this[long index] {

            get;
        }
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {

    public partial interface IReadOnlyList<T> {

        new ref readonly T this[int index] {

            get;
        }
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {

    public partial interface IReadOnlyList<T> {

        new ref readonly T this[long index] {

            get;
        }
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {

    public partial interface IReadOnlyList<T> {

        int IndexOf(T item);
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {

    public partial interface IReadOnlyList<T> {

        long LongIndexOf(T item);
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic {

    public partial interface IReadOnlyList<T, out TEnumerator> {

        int IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T>;
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic {

    public partial interface IReadOnlyList<T, out TEnumerator> {

        long LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T>;
    }
}
