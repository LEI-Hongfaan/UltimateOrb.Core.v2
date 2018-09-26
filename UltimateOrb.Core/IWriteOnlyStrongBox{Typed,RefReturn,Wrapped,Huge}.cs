
namespace UltimateOrb.Huge {
    
    public partial interface IWriteOnlyStrongBox<in T>
        : Core.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Wrapped {
    
    public partial interface IWriteOnlyStrongBox<in T>
        : Core.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Wrapped_Huge {
    
    public partial interface IWriteOnlyStrongBox<in T>
        : Huge.IWriteOnlyStrongBox<T>
        , Wrapped.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.RefReturn {
    
    public partial interface IWriteOnlyStrongBox<T>
        : Core.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.RefReturn_Huge {
    
    public partial interface IWriteOnlyStrongBox<T>
        : Huge.IWriteOnlyStrongBox<T>
        , RefReturn.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped {
    
    public partial interface IWriteOnlyStrongBox<T>
        : Wrapped.IWriteOnlyStrongBox<T>
        , RefReturn.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge {
    
    public partial interface IWriteOnlyStrongBox<T>
        : Wrapped_Huge.IWriteOnlyStrongBox<T>
        , RefReturn_Huge.IWriteOnlyStrongBox<T>
        , RefReturn_Wrapped.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed {
    
    public partial interface IWriteOnlyStrongBox<in T>
        : Core.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_Huge {
    
    public partial interface IWriteOnlyStrongBox<in T>
        : Huge.IWriteOnlyStrongBox<T>
        , Typed.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped {
    
    public partial interface IWriteOnlyStrongBox<in T>
        : Wrapped.IWriteOnlyStrongBox<T>
        , Typed.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge {
    
    public partial interface IWriteOnlyStrongBox<in T>
        : Wrapped_Huge.IWriteOnlyStrongBox<T>
        , Typed_Huge.IWriteOnlyStrongBox<T>
        , Typed_Wrapped.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn {
    
    public partial interface IWriteOnlyStrongBox<T>
        : RefReturn.IWriteOnlyStrongBox<T>
        , Typed.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge {
    
    public partial interface IWriteOnlyStrongBox<T>
        : RefReturn_Huge.IWriteOnlyStrongBox<T>
        , Typed_Huge.IWriteOnlyStrongBox<T>
        , Typed_RefReturn.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped {
    
    public partial interface IWriteOnlyStrongBox<T>
        : RefReturn_Wrapped.IWriteOnlyStrongBox<T>
        , Typed_Wrapped.IWriteOnlyStrongBox<T>
        , Typed_RefReturn.IWriteOnlyStrongBox<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge {
    
    public partial interface IWriteOnlyStrongBox<T>
        : RefReturn_Wrapped_Huge.IWriteOnlyStrongBox<T>
        , Typed_Wrapped_Huge.IWriteOnlyStrongBox<T>
        , Typed_RefReturn_Huge.IWriteOnlyStrongBox<T>
        , Typed_RefReturn_Wrapped.IWriteOnlyStrongBox<T> {
    }
}
