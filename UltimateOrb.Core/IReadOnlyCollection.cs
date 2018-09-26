namespace UltimateOrb.Huge.Collections.Generic {

    public partial interface IReadOnlyCollection<out T> {

        long LongCount {
            get;
        }
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {

    public partial interface IReadOnlyCollection<T> {

        void CopyTo(T[] array, long arrayIndex);
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Generic {

    public partial interface IReadOnlyCollection<T> {

        void CopyTo(Array<T> array, int arrayIndex);
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Generic {

    public partial interface IReadOnlyCollection<T> {

        void CopyTo(Array<T> array, long arrayIndex);
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic {

    public partial interface IReadOnlyCollection<T, out TEnumerator> {

        bool Contains<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T>;
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic {

    public partial interface IReadOnlyCollection<T, out TEnumerator> {

        new bool Contains<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T>;
    }
}
