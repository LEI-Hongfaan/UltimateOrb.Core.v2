
namespace UltimateOrb.Huge.Collections.Generic {
    
    public partial interface IList<T>
        : ICollection<T>
        , System.Collections.Generic.IList<T> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Generic {
    
    public partial interface IList<T>
        : ICollection<T>
        , System.Collections.Generic.IList<T> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Generic {
    
    public partial interface IList<T>
        : ICollection<T>
        , Huge.Collections.Generic.IList<T>
        , Wrapped.Collections.Generic.IList<T> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {
    
    public partial interface IList<T>
        : ICollection<T>
        , System.Collections.Generic.IList<T> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {
    
    public partial interface IList<T>
        : ICollection<T>
        , Huge.Collections.Generic.IList<T>
        , RefReturn.Collections.Generic.IList<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IList<T>
        : ICollection<T>
        , Wrapped.Collections.Generic.IList<T>
        , RefReturn.Collections.Generic.IList<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IList<T>
        : ICollection<T>
        , Wrapped_Huge.Collections.Generic.IList<T>
        , RefReturn_Huge.Collections.Generic.IList<T>
        , RefReturn_Wrapped.Collections.Generic.IList<T> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic {
    
    public partial interface IList<T, out TEnumerator>
        : ICollection<T, TEnumerator>
        , System.Collections.Generic.IList<T>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic {
    
    public partial interface IList<T, out TEnumerator>
        : ICollection<T, TEnumerator>
        , Huge.Collections.Generic.IList<T>
        , Typed.Collections.Generic.IList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic {
    
    public partial interface IList<T, out TEnumerator>
        : ICollection<T, TEnumerator>
        , Wrapped.Collections.Generic.IList<T>
        , Typed.Collections.Generic.IList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic {
    
    public partial interface IList<T, out TEnumerator>
        : ICollection<T, TEnumerator>
        , Wrapped_Huge.Collections.Generic.IList<T>
        , Typed_Huge.Collections.Generic.IList<T, TEnumerator>
        , Typed_Wrapped.Collections.Generic.IList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic {
    
    public partial interface IList<T, out TEnumerator>
        : ICollection<T, TEnumerator>
        , RefReturn.Collections.Generic.IList<T>
        , Typed.Collections.Generic.IList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic {
    
    public partial interface IList<T, out TEnumerator>
        : ICollection<T, TEnumerator>
        , RefReturn_Huge.Collections.Generic.IList<T>
        , Typed_Huge.Collections.Generic.IList<T, TEnumerator>
        , Typed_RefReturn.Collections.Generic.IList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IList<T, out TEnumerator>
        : ICollection<T, TEnumerator>
        , RefReturn_Wrapped.Collections.Generic.IList<T>
        , Typed_Wrapped.Collections.Generic.IList<T, TEnumerator>
        , Typed_RefReturn.Collections.Generic.IList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IList<T, out TEnumerator>
        : ICollection<T, TEnumerator>
        , RefReturn_Wrapped_Huge.Collections.Generic.IList<T>
        , Typed_Wrapped_Huge.Collections.Generic.IList<T, TEnumerator>
        , Typed_RefReturn_Huge.Collections.Generic.IList<T, TEnumerator>
        , Typed_RefReturn_Wrapped.Collections.Generic.IList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IList<T, out TEnumerator, in TEqualityComparer>
        : IList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IList<T, out TEnumerator, in TEqualityComparer>
        : IList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IList<T, out TEnumerator, in TEqualityComparer>
        : IList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IList<T, out TEnumerator, in TEqualityComparer>
        : IList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IList<T, out TEnumerator, in TEqualityComparer>
        : IList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IList<T, out TEnumerator, in TEqualityComparer>
        : IList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IList<T, out TEnumerator, in TEqualityComparer>
        : IList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IList<T, out TEnumerator, in TEqualityComparer>
        : IList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}
