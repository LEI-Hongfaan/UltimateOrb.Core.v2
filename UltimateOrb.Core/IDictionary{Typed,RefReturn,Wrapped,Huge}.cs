
namespace UltimateOrb.Huge.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , System.Collections.Generic.IDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , System.Collections.Generic.IDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , Huge.Collections.Generic.IDictionary<TKey, TValue>
        , Wrapped.Collections.Generic.IDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , System.Collections.Generic.IDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , Huge.Collections.Generic.IDictionary<TKey, TValue>
        , RefReturn.Collections.Generic.IDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , Wrapped.Collections.Generic.IDictionary<TKey, TValue>
        , RefReturn.Collections.Generic.IDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        , Wrapped_Huge.Collections.Generic.IDictionary<TKey, TValue>
        , RefReturn_Huge.Collections.Generic.IDictionary<TKey, TValue>
        , RefReturn_Wrapped.Collections.Generic.IDictionary<TKey, TValue> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , System.Collections.Generic.IDictionary<TKey, TValue>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.ICollection<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , Huge.Collections.Generic.IDictionary<TKey, TValue>
        , Typed.Collections.Generic.IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed_Huge.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed_Huge.Collections.Generic.ICollection<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , Wrapped.Collections.Generic.IDictionary<TKey, TValue>
        , Typed.Collections.Generic.IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Wrapped.Collections.Generic.ICollection<TKey>, Typed.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Wrapped.Collections.Generic.ICollection<TValue>, Typed.Collections.Generic.ICollection<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , Wrapped_Huge.Collections.Generic.IDictionary<TKey, TValue>
        , Typed_Huge.Collections.Generic.IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        , Typed_Wrapped.Collections.Generic.IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Wrapped_Huge.Collections.Generic.ICollection<TKey>, Typed_Huge.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Wrapped_Huge.Collections.Generic.ICollection<TValue>, Typed_Huge.Collections.Generic.ICollection<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , RefReturn.Collections.Generic.IDictionary<TKey, TValue>
        , Typed.Collections.Generic.IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.ICollection<TKey>, Typed.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.ICollection<TValue>, Typed.Collections.Generic.ICollection<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , RefReturn_Huge.Collections.Generic.IDictionary<TKey, TValue>
        , Typed_Huge.Collections.Generic.IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        , Typed_RefReturn.Collections.Generic.IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.ICollection<TKey>, Typed_Huge.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.ICollection<TValue>, Typed_Huge.Collections.Generic.ICollection<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , RefReturn_Wrapped.Collections.Generic.IDictionary<TKey, TValue>
        , Typed_Wrapped.Collections.Generic.IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        , Typed_RefReturn.Collections.Generic.IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Wrapped.Collections.Generic.ICollection<TKey>, RefReturn.Collections.Generic.ICollection<TKey>, Typed.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Wrapped.Collections.Generic.ICollection<TValue>, RefReturn.Collections.Generic.ICollection<TValue>, Typed.Collections.Generic.ICollection<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection>
        : ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>, TEnumerator>
        , RefReturn_Wrapped_Huge.Collections.Generic.IDictionary<TKey, TValue>
        , Typed_Wrapped_Huge.Collections.Generic.IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        , Typed_RefReturn_Huge.Collections.Generic.IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        , Typed_RefReturn_Wrapped.Collections.Generic.IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Wrapped_Huge.Collections.Generic.ICollection<TKey>, RefReturn.Collections.Generic.ICollection<TKey>, Typed_Huge.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Wrapped_Huge.Collections.Generic.ICollection<TValue>, RefReturn.Collections.Generic.ICollection<TValue>, Typed_Huge.Collections.Generic.ICollection<TValue, TValueEnumerator> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : System.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed_Huge.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed_Huge.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Typed_Huge.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Typed_Huge.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Wrapped.Collections.Generic.ICollection<TKey>, Typed.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Wrapped.Collections.Generic.ICollection<TValue>, Typed.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Wrapped.Collections.Generic.ICollection<TKey>, Typed.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Wrapped.Collections.Generic.ICollection<TValue>, Typed.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : System.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Wrapped_Huge.Collections.Generic.ICollection<TKey>, Typed_Huge.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Wrapped_Huge.Collections.Generic.ICollection<TValue>, Typed_Huge.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: System.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Wrapped_Huge.Collections.Generic.ICollection<TKey>, Typed_Huge.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: System.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Wrapped_Huge.Collections.Generic.ICollection<TValue>, Typed_Huge.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.ICollection<TKey>, Typed.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.ICollection<TValue>, Typed.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.ICollection<TKey>, Typed.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.ICollection<TValue>, Typed.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : System.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.ICollection<TKey>, Typed_Huge.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.ICollection<TValue>, Typed_Huge.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: RefReturn.Collections.Generic.ICollection<TKey>, Typed_Huge.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: RefReturn.Collections.Generic.ICollection<TValue>, Typed_Huge.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Wrapped.Collections.Generic.ICollection<TKey>, RefReturn.Collections.Generic.ICollection<TKey>, Typed.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Wrapped.Collections.Generic.ICollection<TValue>, RefReturn.Collections.Generic.ICollection<TValue>, Typed.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Wrapped.Collections.Generic.ICollection<TKey>, RefReturn.Collections.Generic.ICollection<TKey>, Typed.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Wrapped.Collections.Generic.ICollection<TValue>, RefReturn.Collections.Generic.ICollection<TValue>, Typed.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : System.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : System.Collections.Generic.IEqualityComparer<TValue> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Wrapped_Huge.Collections.Generic.ICollection<TKey>, RefReturn.Collections.Generic.ICollection<TKey>, Typed_Huge.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Wrapped_Huge.Collections.Generic.ICollection<TValue>, RefReturn.Collections.Generic.ICollection<TValue>, Typed_Huge.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey> {
    }

    public partial interface IDictionary<TKey, TValue, out TEnumerator, out TKeyEnumerator, out TKeyCollection, out TValueEnumerator, out TValueCollection, in TKeyEqualityComparer, in TValueEqualityComparer>
        : IDictionary<TKey, TValue, TEnumerator, TKeyEnumerator, TKeyCollection, TValueEnumerator, TValueCollection, TKeyEqualityComparer>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>
        where TKeyEnumerator: RefReturn.Collections.Generic.IEnumerator<TKey>
        where TKeyCollection: Wrapped_Huge.Collections.Generic.ICollection<TKey>, RefReturn.Collections.Generic.ICollection<TKey>, Typed_Huge.Collections.Generic.ICollection<TKey, TKeyEnumerator>
        where TValueEnumerator: RefReturn.Collections.Generic.IEnumerator<TValue>
        where TValueCollection: Wrapped_Huge.Collections.Generic.ICollection<TValue>, RefReturn.Collections.Generic.ICollection<TValue>, Typed_Huge.Collections.Generic.ICollection<TValue, TValueEnumerator>
        where TKeyEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TKey>
        where TValueEqualityComparer : Huge.Collections.Generic.IEqualityComparer<TValue> {
    }
}
