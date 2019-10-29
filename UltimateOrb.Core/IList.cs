namespace UltimateOrb.Huge.Collections.Generic {

    public partial interface IList<T> {

        T this[long index] {

            get;

            set;
        }

        void Insert(long index, T item);

        long LongIndexOf(T item);

        void RemoveAt(long index);
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {

    public partial interface IList<T> {

        new ref T this[int index] {

            get;
        }

        new ref T Insert(int index, T item);
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {

    public partial interface IList<T> {

        new ref T this[long index] {

            get;
        }

        new ref T Insert(long index, T item);
    }
}

namespace UltimateOrb.Typed.Collections.Generic {

    public partial interface IList<T, out TEnumerator> {

        int IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T>;
    }
}


namespace UltimateOrb.Typed_Huge.Collections.Generic {

    public partial interface IList<T, out TEnumerator> {

        long LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T>;
    }
}
