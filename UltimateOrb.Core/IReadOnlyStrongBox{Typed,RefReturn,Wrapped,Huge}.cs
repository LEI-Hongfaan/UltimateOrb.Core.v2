
namespace UltimateOrb.Huge {
    
    public partial interface IReadOnlyStrongBox<out T>
        : Core.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Wrapped {
    
    public partial interface IReadOnlyStrongBox<out T>
        : Core.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Wrapped_Huge {
    
    public partial interface IReadOnlyStrongBox<out T>
        : Huge.IReadOnlyStrongBox<T>
        , Wrapped.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.RefReturn {
    
    public partial interface IReadOnlyStrongBox<T>
        : Core.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.RefReturn_Huge {
    
    public partial interface IReadOnlyStrongBox<T>
        : Huge.IReadOnlyStrongBox<T>
        , RefReturn.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped {
    
    public partial interface IReadOnlyStrongBox<T>
        : Wrapped.IReadOnlyStrongBox<T>
        , RefReturn.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge {
    
    public partial interface IReadOnlyStrongBox<T>
        : Wrapped_Huge.IReadOnlyStrongBox<T>
        , RefReturn_Huge.IReadOnlyStrongBox<T>
        , RefReturn_Wrapped.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed {
    
    public partial interface IReadOnlyStrongBox<out T>
        : Core.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_Huge {
    
    public partial interface IReadOnlyStrongBox<out T>
        : Huge.IReadOnlyStrongBox<T>
        , Typed.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped {
    
    public partial interface IReadOnlyStrongBox<out T>
        : Wrapped.IReadOnlyStrongBox<T>
        , Typed.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge {
    
    public partial interface IReadOnlyStrongBox<out T>
        : Wrapped_Huge.IReadOnlyStrongBox<T>
        , Typed_Huge.IReadOnlyStrongBox<T>
        , Typed_Wrapped.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn {
    
    public partial interface IReadOnlyStrongBox<T>
        : RefReturn.IReadOnlyStrongBox<T>
        , Typed.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge {
    
    public partial interface IReadOnlyStrongBox<T>
        : RefReturn_Huge.IReadOnlyStrongBox<T>
        , Typed_Huge.IReadOnlyStrongBox<T>
        , Typed_RefReturn.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped {
    
    public partial interface IReadOnlyStrongBox<T>
        : RefReturn_Wrapped.IReadOnlyStrongBox<T>
        , Typed_Wrapped.IReadOnlyStrongBox<T>
        , Typed_RefReturn.IReadOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge {
    
    public partial interface IReadOnlyStrongBox<T>
        : RefReturn_Wrapped_Huge.IReadOnlyStrongBox<T>
        , Typed_Wrapped_Huge.IReadOnlyStrongBox<T>
        , Typed_RefReturn_Huge.IReadOnlyStrongBox<T>
        , Typed_RefReturn_Wrapped.IReadOnlyStrongBox<T> {
    }
}
