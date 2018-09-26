
namespace UltimateOrb.Huge.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : Core.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Huge.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , Core.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Huge.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , Core.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : Core.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , Core.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , Core.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : Huge.Collections.Immutable.IIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , Huge.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , Huge.Collections.Immutable.IListIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : Core.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , Core.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , Core.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : Huge.Collections.Immutable.IIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , Huge.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , Huge.Collections.Immutable.IListIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : Wrapped.Collections.Immutable.IIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IListIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : Wrapped_Huge.Collections.Immutable.IIterator<T, TIterator>
        , RefReturn_Huge.Collections.Immutable.IIterator<T, TIterator>
        , RefReturn_Wrapped.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , Wrapped_Huge.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , RefReturn_Huge.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , RefReturn_Wrapped.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , Wrapped_Huge.Collections.Immutable.IListIterator<T, TIterator>
        , RefReturn_Huge.Collections.Immutable.IListIterator<T, TIterator>
        , RefReturn_Wrapped.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : Core.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , Core.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , Core.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : Huge.Collections.Immutable.IIterator<T, TIterator>
        , Typed.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , Huge.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Typed.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , Huge.Collections.Immutable.IListIterator<T, TIterator>
        , Typed.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : Wrapped.Collections.Immutable.IIterator<T, TIterator>
        , Typed.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Typed.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IListIterator<T, TIterator>
        , Typed.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : Wrapped_Huge.Collections.Immutable.IIterator<T, TIterator>
        , Typed_Huge.Collections.Immutable.IIterator<T, TIterator>
        , Typed_Wrapped.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , Wrapped_Huge.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Typed_Huge.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Typed_Wrapped.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , Wrapped_Huge.Collections.Immutable.IListIterator<T, TIterator>
        , Typed_Huge.Collections.Immutable.IListIterator<T, TIterator>
        , Typed_Wrapped.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : RefReturn.Collections.Immutable.IIterator<T, TIterator>
        , Typed.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Typed.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IListIterator<T, TIterator>
        , Typed.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : RefReturn_Huge.Collections.Immutable.IIterator<T, TIterator>
        , Typed_Huge.Collections.Immutable.IIterator<T, TIterator>
        , Typed_RefReturn.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , RefReturn_Huge.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Typed_Huge.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Typed_RefReturn.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , RefReturn_Huge.Collections.Immutable.IListIterator<T, TIterator>
        , Typed_Huge.Collections.Immutable.IListIterator<T, TIterator>
        , Typed_RefReturn.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : RefReturn_Wrapped.Collections.Immutable.IIterator<T, TIterator>
        , Typed_Wrapped.Collections.Immutable.IIterator<T, TIterator>
        , Typed_RefReturn.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , RefReturn_Wrapped.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Typed_Wrapped.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Typed_RefReturn.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , RefReturn_Wrapped.Collections.Immutable.IListIterator<T, TIterator>
        , Typed_Wrapped.Collections.Immutable.IListIterator<T, TIterator>
        , Typed_RefReturn.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IIterator<T, out TIterator>
        : RefReturn_Wrapped_Huge.Collections.Immutable.IIterator<T, TIterator>
        , Typed_Wrapped_Huge.Collections.Immutable.IIterator<T, TIterator>
        , Typed_RefReturn_Huge.Collections.Immutable.IIterator<T, TIterator>
        , Typed_RefReturn_Wrapped.Collections.Immutable.IIterator<T, TIterator>
        where TIterator : IIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , RefReturn_Wrapped_Huge.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Typed_Wrapped_Huge.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Typed_RefReturn_Huge.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        , Typed_RefReturn_Wrapped.Collections.Immutable.IBidirectionalIterator<T, TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , RefReturn_Wrapped_Huge.Collections.Immutable.IListIterator<T, TIterator>
        , Typed_Wrapped_Huge.Collections.Immutable.IListIterator<T, TIterator>
        , Typed_RefReturn_Huge.Collections.Immutable.IListIterator<T, TIterator>
        , Typed_RefReturn_Wrapped.Collections.Immutable.IListIterator<T, TIterator>
        where TIterator : IListIterator<T, TIterator> {
    }
}
