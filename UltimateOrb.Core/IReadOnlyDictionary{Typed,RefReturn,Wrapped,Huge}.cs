
namespace UltimateOrb.Huge.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , Huge.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , Wrapped.Collections.Generic.IReadOnlyDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , Huge.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , RefReturn.Collections.Generic.IReadOnlyDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , Wrapped.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , RefReturn.Collections.Generic.IReadOnlyDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , Wrapped_Huge.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , RefReturn_Huge.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , RefReturn_Wrapped.Collections.Generic.IReadOnlyDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , Huge.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , Typed.Collections.Generic.IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , Wrapped.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , Typed.Collections.Generic.IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , Wrapped_Huge.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , Typed_Huge.Collections.Generic.IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        , Typed_Wrapped.Collections.Generic.IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , RefReturn.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , Typed.Collections.Generic.IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TKey>, Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TValue>, Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , RefReturn_Huge.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , Typed_Huge.Collections.Generic.IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        , Typed_RefReturn.Collections.Generic.IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TKey>, Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TValue>, Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , RefReturn_Wrapped.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , Typed_Wrapped.Collections.Generic.IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        , Typed_RefReturn.Collections.Generic.IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TKey>, Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TValue>, Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyDictionary<TKey, TValue>
        , Typed_Wrapped_Huge.Collections.Generic.IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        , Typed_RefReturn_Huge.Collections.Generic.IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        , Typed_RefReturn_Wrapped.Collections.Generic.IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TKey>, Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TValue>, Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : System.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : System.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TKey>, Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TValue>, Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TKey>, Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TValue>, Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : System.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TKey>, Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TValue>, Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TKey>, Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TValue>, Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TKey>, Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TValue>, Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TKey>, Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TValue>, Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : System.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TKey>, Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TValue>, Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IReadOnlyDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IReadOnlyDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TKey>, Typed.Collections.Generic.IReadOnlyEnumerable<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.IReadOnlyEnumerable<TValue>, Typed.Collections.Generic.IReadOnlyEnumerable<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TValue> {
    }
}
