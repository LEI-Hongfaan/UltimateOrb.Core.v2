using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateOrb.Collections.Generic {

    public partial interface IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        : System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , IReadOnlyDictionary<KeyValuePair<TKey, TValue>, TEnumerator>
        where TEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        where TKeyEnumerator : IEnumerator<TKey>
        where TKeyCollection : IReadOnlyCollection<TKey, TKeyEnumerator>
        where TValueEnumerator : IEnumerator<TValue>
        where TValueCollection : IReadOnlyCollection<TValue, TValueEnumerator> {

        new TKeyCollection Keys {

            get;
        }

        new TKeyCollection Values {

            get;
        }
    }
}
