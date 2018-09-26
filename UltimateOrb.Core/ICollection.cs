namespace UltimateOrb.Huge.Collections.Generic {

    public partial interface ICollection<T> {

        long LongCount {
            get;
        }

        void CopyTo(T[] array, long arrayIndex);
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {

    public partial interface ICollection<T> {

        new ref T Add(T item);
    }
}

namespace UltimateOrb.Typed.Collections.Generic {

    public partial interface ICollection<T, out TEnumerator> {

        bool Contains<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T>;

        bool Remove<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T>;
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic {

    public partial interface ICollection<T, out TEnumerator> {

        new bool Contains<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T>;

        new bool Remove<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T>;
    }
}

namespace UltimateOrb.Wrapped.Collections.Generic {

    public partial interface ICollection<T> {

        void CopyTo(Array<T> array, int arrayIndex);
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Generic {

    public partial interface ICollection<T> {

        void CopyTo(Array<T> array, long arrayIndex);
    }
}
