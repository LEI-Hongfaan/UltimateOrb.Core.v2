
namespace UltimateOrb.Huge.Collections.Generic {
    
    public partial interface IEnumerable<out T>
        : System.Collections.Generic.IEnumerable<T> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Generic {
    
    public partial interface IEnumerable<out T>
        : System.Collections.Generic.IEnumerable<T> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Generic {
    
    public partial interface IEnumerable<out T>
        : Huge.Collections.Generic.IEnumerable<T>
        , Wrapped.Collections.Generic.IEnumerable<T> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {
    
    public partial interface IEnumerable<T>
        : System.Collections.Generic.IEnumerable<T> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {
    
    public partial interface IEnumerable<T>
        : Huge.Collections.Generic.IEnumerable<T>
        , RefReturn.Collections.Generic.IEnumerable<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IEnumerable<T>
        : Wrapped.Collections.Generic.IEnumerable<T>
        , RefReturn.Collections.Generic.IEnumerable<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IEnumerable<T>
        : Wrapped_Huge.Collections.Generic.IEnumerable<T>
        , RefReturn_Huge.Collections.Generic.IEnumerable<T>
        , RefReturn_Wrapped.Collections.Generic.IEnumerable<T> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic {
    
    public partial interface IEnumerable<out T, out TEnumerator>
        : System.Collections.Generic.IEnumerable<T>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic {
    
    public partial interface IEnumerable<out T, out TEnumerator>
        : Huge.Collections.Generic.IEnumerable<T>
        , Typed.Collections.Generic.IEnumerable<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic {
    
    public partial interface IEnumerable<out T, out TEnumerator>
        : Wrapped.Collections.Generic.IEnumerable<T>
        , Typed.Collections.Generic.IEnumerable<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic {
    
    public partial interface IEnumerable<out T, out TEnumerator>
        : Wrapped_Huge.Collections.Generic.IEnumerable<T>
        , Typed_Huge.Collections.Generic.IEnumerable<T, TEnumerator>
        , Typed_Wrapped.Collections.Generic.IEnumerable<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic {
    
    public partial interface IEnumerable<T, out TEnumerator>
        : RefReturn.Collections.Generic.IEnumerable<T>
        , Typed.Collections.Generic.IEnumerable<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic {
    
    public partial interface IEnumerable<T, out TEnumerator>
        : RefReturn_Huge.Collections.Generic.IEnumerable<T>
        , Typed_Huge.Collections.Generic.IEnumerable<T, TEnumerator>
        , Typed_RefReturn.Collections.Generic.IEnumerable<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IEnumerable<T, out TEnumerator>
        : RefReturn_Wrapped.Collections.Generic.IEnumerable<T>
        , Typed_Wrapped.Collections.Generic.IEnumerable<T, TEnumerator>
        , Typed_RefReturn.Collections.Generic.IEnumerable<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IEnumerable<T, out TEnumerator>
        : RefReturn_Wrapped_Huge.Collections.Generic.IEnumerable<T>
        , Typed_Wrapped_Huge.Collections.Generic.IEnumerable<T, TEnumerator>
        , Typed_RefReturn_Huge.Collections.Generic.IEnumerable<T, TEnumerator>
        , Typed_RefReturn_Wrapped.Collections.Generic.IEnumerable<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IEnumerator<T> {
    }
}
