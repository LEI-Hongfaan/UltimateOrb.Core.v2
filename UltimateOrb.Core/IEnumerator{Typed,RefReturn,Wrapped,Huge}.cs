
namespace UltimateOrb.Huge.Collections.Generic {
    
    public partial interface IEnumerator<out T>
        : System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Generic {
    
    public partial interface IEnumerator<out T>
        : System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Generic {
    
    public partial interface IEnumerator<out T>
        : Huge.Collections.Generic.IEnumerator<T>
        , Wrapped.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {
    
    public partial interface IEnumerator<T>
        : System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {
    
    public partial interface IEnumerator<T>
        : Huge.Collections.Generic.IEnumerator<T>
        , RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IEnumerator<T>
        : Wrapped.Collections.Generic.IEnumerator<T>
        , RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IEnumerator<T>
        : Wrapped_Huge.Collections.Generic.IEnumerator<T>
        , RefReturn_Huge.Collections.Generic.IEnumerator<T>
        , RefReturn_Wrapped.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic {
    
    public partial interface IEnumerator<out T>
        : System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic {
    
    public partial interface IEnumerator<out T>
        : Huge.Collections.Generic.IEnumerator<T>
        , Typed.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic {
    
    public partial interface IEnumerator<out T>
        : Wrapped.Collections.Generic.IEnumerator<T>
        , Typed.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic {
    
    public partial interface IEnumerator<out T>
        : Wrapped_Huge.Collections.Generic.IEnumerator<T>
        , Typed_Huge.Collections.Generic.IEnumerator<T>
        , Typed_Wrapped.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic {
    
    public partial interface IEnumerator<T>
        : RefReturn.Collections.Generic.IEnumerator<T>
        , Typed.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic {
    
    public partial interface IEnumerator<T>
        : RefReturn_Huge.Collections.Generic.IEnumerator<T>
        , Typed_Huge.Collections.Generic.IEnumerator<T>
        , Typed_RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IEnumerator<T>
        : RefReturn_Wrapped.Collections.Generic.IEnumerator<T>
        , Typed_Wrapped.Collections.Generic.IEnumerator<T>
        , Typed_RefReturn.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IEnumerator<T>
        : RefReturn_Wrapped_Huge.Collections.Generic.IEnumerator<T>
        , Typed_Wrapped_Huge.Collections.Generic.IEnumerator<T>
        , Typed_RefReturn_Huge.Collections.Generic.IEnumerator<T>
        , Typed_RefReturn_Wrapped.Collections.Generic.IEnumerator<T> {
    }
}
