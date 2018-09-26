
namespace UltimateOrb.Huge.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<out T>
        : System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<out T>
        : System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<out T>
        : Huge.Collections.Generic.IReadOnlyEnumerator<T>
        , Wrapped.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<T>
        : System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<T>
        : Huge.Collections.Generic.IReadOnlyEnumerator<T>
        , RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<T>
        : Wrapped.Collections.Generic.IReadOnlyEnumerator<T>
        , RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<T>
        : Wrapped_Huge.Collections.Generic.IReadOnlyEnumerator<T>
        , RefReturn_Huge.Collections.Generic.IReadOnlyEnumerator<T>
        , RefReturn_Wrapped.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<out T>
        : System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<out T>
        : Huge.Collections.Generic.IReadOnlyEnumerator<T>
        , Typed.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<out T>
        : Wrapped.Collections.Generic.IReadOnlyEnumerator<T>
        , Typed.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<out T>
        : Wrapped_Huge.Collections.Generic.IReadOnlyEnumerator<T>
        , Typed_Huge.Collections.Generic.IReadOnlyEnumerator<T>
        , Typed_Wrapped.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<T>
        : RefReturn.Collections.Generic.IReadOnlyEnumerator<T>
        , Typed.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<T>
        : RefReturn_Huge.Collections.Generic.IReadOnlyEnumerator<T>
        , Typed_Huge.Collections.Generic.IReadOnlyEnumerator<T>
        , Typed_RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<T>
        : RefReturn_Wrapped.Collections.Generic.IReadOnlyEnumerator<T>
        , Typed_Wrapped.Collections.Generic.IReadOnlyEnumerator<T>
        , Typed_RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyEnumerator<T>
        : RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyEnumerator<T>
        , Typed_Wrapped_Huge.Collections.Generic.IReadOnlyEnumerator<T>
        , Typed_RefReturn_Huge.Collections.Generic.IReadOnlyEnumerator<T>
        , Typed_RefReturn_Wrapped.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}
