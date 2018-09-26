
namespace UltimateOrb.Huge.Collections.Generic {
    
    public partial interface ICollection<T>
        : IEnumerable<T>
        , System.Collections.Generic.ICollection<T> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Generic {
    
    public partial interface ICollection<T>
        : IEnumerable<T>
        , System.Collections.Generic.ICollection<T> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Generic {
    
    public partial interface ICollection<T>
        : IEnumerable<T>
        , Huge.Collections.Generic.ICollection<T>
        , Wrapped.Collections.Generic.ICollection<T> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {
    
    public partial interface ICollection<T>
        : IEnumerable<T>
        , System.Collections.Generic.ICollection<T> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {
    
    public partial interface ICollection<T>
        : IEnumerable<T>
        , Huge.Collections.Generic.ICollection<T>
        , RefReturn.Collections.Generic.ICollection<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Generic {
    
    public partial interface ICollection<T>
        : IEnumerable<T>
        , Wrapped.Collections.Generic.ICollection<T>
        , RefReturn.Collections.Generic.ICollection<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface ICollection<T>
        : IEnumerable<T>
        , Wrapped_Huge.Collections.Generic.ICollection<T>
        , RefReturn_Huge.Collections.Generic.ICollection<T>
        , RefReturn_Wrapped.Collections.Generic.ICollection<T> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic {
    
    public partial interface ICollection<T, out TEnumerator>
        : IEnumerable<T, TEnumerator>
        , System.Collections.Generic.ICollection<T>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic {
    
    public partial interface ICollection<T, out TEnumerator>
        : IEnumerable<T, TEnumerator>
        , Huge.Collections.Generic.ICollection<T>
        , Typed.Collections.Generic.ICollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic {
    
    public partial interface ICollection<T, out TEnumerator>
        : IEnumerable<T, TEnumerator>
        , Wrapped.Collections.Generic.ICollection<T>
        , Typed.Collections.Generic.ICollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic {
    
    public partial interface ICollection<T, out TEnumerator>
        : IEnumerable<T, TEnumerator>
        , Wrapped_Huge.Collections.Generic.ICollection<T>
        , Typed_Huge.Collections.Generic.ICollection<T, TEnumerator>
        , Typed_Wrapped.Collections.Generic.ICollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic {
    
    public partial interface ICollection<T, out TEnumerator>
        : IEnumerable<T, TEnumerator>
        , RefReturn.Collections.Generic.ICollection<T>
        , Typed.Collections.Generic.ICollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic {
    
    public partial interface ICollection<T, out TEnumerator>
        : IEnumerable<T, TEnumerator>
        , RefReturn_Huge.Collections.Generic.ICollection<T>
        , Typed_Huge.Collections.Generic.ICollection<T, TEnumerator>
        , Typed_RefReturn.Collections.Generic.ICollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic {
    
    public partial interface ICollection<T, out TEnumerator>
        : IEnumerable<T, TEnumerator>
        , RefReturn_Wrapped.Collections.Generic.ICollection<T>
        , Typed_Wrapped.Collections.Generic.ICollection<T, TEnumerator>
        , Typed_RefReturn.Collections.Generic.ICollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface ICollection<T, out TEnumerator>
        : IEnumerable<T, TEnumerator>
        , RefReturn_Wrapped_Huge.Collections.Generic.ICollection<T>
        , Typed_Wrapped_Huge.Collections.Generic.ICollection<T, TEnumerator>
        , Typed_RefReturn_Huge.Collections.Generic.ICollection<T, TEnumerator>
        , Typed_RefReturn_Wrapped.Collections.Generic.ICollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface ICollection<T, out TEnumerator, in TEqualityComparer>
        : ICollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface ICollection<T, out TEnumerator, in TEqualityComparer>
        : ICollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface ICollection<T, out TEnumerator, in TEqualityComparer>
        : ICollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface ICollection<T, out TEnumerator, in TEqualityComparer>
        : ICollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface ICollection<T, out TEnumerator, in TEqualityComparer>
        : ICollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface ICollection<T, out TEnumerator, in TEqualityComparer>
        : ICollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface ICollection<T, out TEnumerator, in TEqualityComparer>
        : ICollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface ICollection<T, out TEnumerator, in TEqualityComparer>
        : ICollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}
