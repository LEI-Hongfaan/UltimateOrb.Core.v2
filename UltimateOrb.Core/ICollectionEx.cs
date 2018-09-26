using System;
using System.Collections.Generic;

/*
namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;

    public partial interface ICollectionEx<T>
        : ICollection<T> {

        int Capacity {

            get;
        }

        long LongCapacity {

            get;
        }

        int EnsureCapacity(int capacity);

        long EnsureCapacity(long capacity);

        void TrimExcess();

        void TrimExcess(int capacity);

        void TrimExcess(long capacity);
    }
}

namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;

    public partial interface ICollectionEx<T, out TEnumerator>
        : ICollectionEx<T>, ICollection<T, TEnumerator>
        where TEnumerator : IEnumerator<T> {

        void AddRange<TEnumerable>(TEnumerable items) where TEnumerable : System.Collections.Generic.IEnumerable<T>;

        void Clear();

        bool Remove<TPredicate>(TPredicate predicate) where TPredicate : IO.IFunc<T, bool>;

        bool Remove<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T>;

        int RemoveAll<TPredicate>(TPredicate predicate) where TPredicate : IO.IFunc<T, bool>;

        int RemoveAll<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T>;

        void RemoveRange<TEnumerable, TEqualityComparer>(TEnumerable items, TEqualityComparer comparer) where TEnumerable : System.Collections.Generic.IEnumerable<T> where TEqualityComparer : IEqualityComparer<T>;

        bool Replace<TPredicate>(TPredicate predicate, T newValue) where TPredicate : IO.IFunc<T, bool>;

        bool Replace<TEqualityComparer>(T oldValue, T newValue, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T>;

        int ReplaceAll<TPredicate>(TPredicate predicate, T newValue) where TPredicate : IO.IFunc<T, bool>;

        int ReplaceAll<TEqualityComparer>(T oldValue, T newValue, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T>;
    }
}

namespace UltimateOrb.Collections.Generic.ExtraTypeParametersProvided {
    using UltimateOrb;

    public partial interface ICollectionEx<T, out TEnumerator, in TEqualityComparer>
        : ICollectionEx<T, TEnumerator>, ICollection<T, TEnumerator, TEqualityComparer>
        where TEnumerator : IEnumerator<T>
        where TEqualityComparer : struct, IEqualityComparer<T> {

        bool Remove(T item, TEqualityComparer comparer);

        int RemoveAll(T item, TEqualityComparer comparer);

        void RemoveRange<TEnumerable>(TEnumerable items, TEqualityComparer comparer) where TEnumerable : System.Collections.Generic.IEnumerable<T>;

        bool Replace(T oldValue, T newValue, TEqualityComparer comparer);

        int ReplaceAll(T oldValue, T newValue, TEqualityComparer comparer);
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic {
    using UltimateOrb;
    using Generic = UltimateOrb.Collections.Generic;

    public partial interface ICollectionEx<T, out TEnumerator>
        : Generic.ICollectionEx<T, TEnumerator>, ICollection<T, TEnumerator>
        where TEnumerator : IEnumerator<T> {
    }
}
*/