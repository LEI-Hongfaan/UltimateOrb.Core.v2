using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateOrb.Collections.Generic {

    public partial interface IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        : System.Collections.Generic.IDictionary<TKey, TValue>
        , ICollection<KeyValuePair<TKey, TValue>, TEnumerator>
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

        TValue GetOrAdd<TFunc>(TKey key, TFunc valueFactory)
            where TFunc : IFunc<TKey, TValue>;

        TValue AddOrUpdate<TAdd, TUpdate>(TKey key, TAdd addValueFactory, TUpdate updateValueFactory)
            where TAdd : IFunc<TKey, TValue>
            where TUpdate : IFunc<TKey, TValue, TValue>;

        bool TryAdd(TKey key, TValue value);

        bool TryRemove(TKey key, out TValue value);

        bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue);
    }
}
