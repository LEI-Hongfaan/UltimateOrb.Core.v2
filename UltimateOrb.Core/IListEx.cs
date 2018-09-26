namespace UltimateOrb.Typed.Collections.Generic {

    public partial interface IListEx<T, out TEnumerator>
        : IList<T, TEnumerator>
        where TEnumerator : System.Collections.Generic.IEnumerator<T> {

        int IndexOf<TEqualityComparer>(T item, int index, int count, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T>;

        void Insert(int index, T element);

        void InsertRange<TEnumerable>(int index, TEnumerable items) where TEnumerable : System.Collections.Generic.IEnumerable<T>;

        int LastIndexOf<TEqualityComparer>(T item, int index, int count, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T>;
       
        void RemoveAt(int index);

        void RemoveRange(int index, int count);

        void ReplaceRange(int index, int count, T newValue);

        void ReplaceRange<TEnumerable>(int index, TEnumerable items) where TEnumerable : System.Collections.Generic.IEnumerable<T>;
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {

    public partial interface IListEx<T>
        : IList<T> {
        ref T Insert(int index, T element);
    }
}


namespace UltimateOrb.Typed.Collections.Generic.ExtraTypeParametersProvided {

    public partial interface IListEx<T, out TEnumerator, in TEqualityComparer>
        : IList<T, TEnumerator, TEqualityComparer>
        , IListEx<T, TEnumerator>
        where TEnumerator : System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T>, new() {

        int IndexOf(T item, int index, int count, TEqualityComparer comparer);

        int LastIndexOf(T item, int index, int count, TEqualityComparer comparer);
  }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic {

    public partial interface IListEx<T, out TEnumerator>
        : IList<T, TEnumerator>
        , RefReturn.Collections.Generic.IListEx<T>
        , Typed.Collections.Generic.IListEx<T, TEnumerator>
        where TEnumerator : RefReturn.Collections.Generic.IEnumerator<T> {

        ref T IndexOf<TEqualityComparer>(T item, int index, int count, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T>;

        ref T LastIndexOf<TEqualityComparer>(T item, int index, int count, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T>;
    }
}
