using System;
using System.Collections.Generic;

/*
namespace UltimateOrb.Collections {

    public partial interface IReadOnlyDictionary<TKey, TValue>
        : System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , IReadOnlyCollection<KeyValuePair<TKey, TValue>> {

        new IReadOnlyCollection<TKey> Keys {

            get;
        }

        new IReadOnlyCollection<TValue> Values {

            get;
        }
    }
}
*/
namespace UltimateOrb.Typed.Collections.Generic {

    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection> {

        new TKeyCollection Keys {

            get;
        }

        new TValueCollection Values {

            get;
        }
    }
}
