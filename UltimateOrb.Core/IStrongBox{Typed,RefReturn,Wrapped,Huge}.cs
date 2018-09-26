
namespace UltimateOrb.Huge {
    
    public partial interface IStrongBox<T>
        : Core.IStrongBox<T> {
    }
}

namespace UltimateOrb.Wrapped {
    
    public partial interface IStrongBox<T>
        : Core.IStrongBox<T> {
    }
}

namespace UltimateOrb.Wrapped_Huge {
    
    public partial interface IStrongBox<T>
        : Huge.IStrongBox<T>
        , Wrapped.IStrongBox<T> {
    }
}

namespace UltimateOrb.RefReturn {
    
    public partial interface IStrongBox<T>
        : Core.IStrongBox<T> {
    }
}

namespace UltimateOrb.RefReturn_Huge {
    
    public partial interface IStrongBox<T>
        : Huge.IStrongBox<T>
        , RefReturn.IStrongBox<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped {
    
    public partial interface IStrongBox<T>
        : Wrapped.IStrongBox<T>
        , RefReturn.IStrongBox<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge {
    
    public partial interface IStrongBox<T>
        : Wrapped_Huge.IStrongBox<T>
        , RefReturn_Huge.IStrongBox<T>
        , RefReturn_Wrapped.IStrongBox<T> {
    }
}

namespace UltimateOrb.Typed {
    
    public partial interface IStrongBox<T>
        : Core.IStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_Huge {
    
    public partial interface IStrongBox<T>
        : Huge.IStrongBox<T>
        , Typed.IStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped {
    
    public partial interface IStrongBox<T>
        : Wrapped.IStrongBox<T>
        , Typed.IStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge {
    
    public partial interface IStrongBox<T>
        : Wrapped_Huge.IStrongBox<T>
        , Typed_Huge.IStrongBox<T>
        , Typed_Wrapped.IStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn {
    
    public partial interface IStrongBox<T>
        : RefReturn.IStrongBox<T>
        , Typed.IStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge {
    
    public partial interface IStrongBox<T>
        : RefReturn_Huge.IStrongBox<T>
        , Typed_Huge.IStrongBox<T>
        , Typed_RefReturn.IStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped {
    
    public partial interface IStrongBox<T>
        : RefReturn_Wrapped.IStrongBox<T>
        , Typed_Wrapped.IStrongBox<T>
        , Typed_RefReturn.IStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge {
    
    public partial interface IStrongBox<T>
        : RefReturn_Wrapped_Huge.IStrongBox<T>
        , Typed_Wrapped_Huge.IStrongBox<T>
        , Typed_RefReturn_Huge.IStrongBox<T>
        , Typed_RefReturn_Wrapped.IStrongBox<T> {
    }
}
