using System;
using System.Collections.Generic;

namespace UltimateOrb.Typed {

    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection> {

        new TKeyCollection Keys {

            get;
        }

        new TValueCollection Values {

            get;
        }
    }
}

namespace UltimateOrb.RefReturn {

    public partial interface IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection> {

        ref TValue SetItem(TKey key, TValue value);

        ref TValue GetItem(TKey key);
    }
}

namespace UltimateOrb.Collections.Generic {

    public partial interface IDictionaryEx<TKey, TValue>
        : System.Collections.Generic.IDictionary<TKey, TValue> {

        TValue AddOrUpdate<TAdd, TUpdate>(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory);

        TValue GetOrAdd<TFunc>(TKey key, Func<TKey, TValue> valueFactory);

        bool TryAdd(TKey key, TValue value);

        bool TryRemove(TKey key, out TValue value);

        bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue);
    }
}

namespace UltimateOrb.Typed.Collections.Generic {

    public partial interface IDictionaryEx<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : UltimateOrb.Collections.Generic.IDictionaryEx<TKey, TValue>
        , IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        where TKeyEnumerator : IEnumerator<TKey>
        where TKeyCollection : ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator : IEnumerator<TValue>
        where TValueCollection : ICollection<TValue, TValueEnumerator> {

        new TKeyCollection Keys {

            get;
        }

        new TValueCollection Values {

            get;
        }

        TValue AddOrUpdate<TAdd, TUpdate>(TKey key, TAdd addValueFactory, TUpdate updateValueFactory)
            where TAdd : IO.IFunc<TKey, TValue>
            where TUpdate : IO.IFunc<TKey, TValue, TValue>;

        TValue GetOrAdd<TFunc>(TKey key, TFunc valueFactory)
            where TFunc : IO.IFunc<TKey, TValue>;

        bool TryUpdate<TValueEqualityComparer>(TKey key, TValueEqualityComparer valueComparer, TValue newValue, TValue comparisonValue) where TValueEqualityComparer : IEqualityComparer<TValue>;
    }
}
