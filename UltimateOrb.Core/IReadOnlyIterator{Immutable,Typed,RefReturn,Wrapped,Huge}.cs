
namespace UltimateOrb.Huge.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<out T, out TIterator>
        : Core.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Huge.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<out T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , Core.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Huge.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<out T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , Core.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<out T, out TIterator>
        : Core.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<out T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , Core.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<out T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , Core.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<out T, out TIterator>
        : Huge.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<out T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , Huge.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<out T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , Huge.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<T, out TIterator>
        : Core.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , Core.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , Core.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<T, out TIterator>
        : Huge.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , Huge.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , Huge.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<T, out TIterator>
        : Wrapped.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<T, out TIterator>
        : Wrapped_Huge.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , RefReturn_Huge.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , RefReturn_Wrapped.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , Wrapped_Huge.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , RefReturn_Huge.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , RefReturn_Wrapped.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , Wrapped_Huge.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , RefReturn_Huge.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , RefReturn_Wrapped.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<out T, out TIterator>
        : Core.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<out T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , Core.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<out T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , Core.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<out T, out TIterator>
        : Huge.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Typed.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<out T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , Huge.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Typed.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<out T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , Huge.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Typed.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<out T, out TIterator>
        : Wrapped.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Typed.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<out T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Typed.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<out T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , Wrapped.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Typed.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<out T, out TIterator>
        : Wrapped_Huge.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Typed_Huge.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Typed_Wrapped.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<out T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , Wrapped_Huge.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Typed_Huge.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Typed_Wrapped.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<out T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , Wrapped_Huge.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Typed_Huge.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Typed_Wrapped.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<T, out TIterator>
        : RefReturn.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Typed.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Typed.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , RefReturn.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Typed.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<T, out TIterator>
        : RefReturn_Huge.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Typed_Huge.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Typed_RefReturn.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , RefReturn_Huge.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Typed_Huge.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Typed_RefReturn.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , RefReturn_Huge.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Typed_Huge.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Typed_RefReturn.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<T, out TIterator>
        : RefReturn_Wrapped.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Typed_Wrapped.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Typed_RefReturn.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , RefReturn_Wrapped.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Typed_Wrapped.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Typed_RefReturn.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , RefReturn_Wrapped.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Typed_Wrapped.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Typed_RefReturn.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyIterator<T, out TIterator>
        : RefReturn_Wrapped_Huge.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Typed_Wrapped_Huge.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Typed_RefReturn_Huge.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        , Typed_RefReturn_Wrapped.Collections.Immutable.IReadOnlyIterator<T, TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyBidirectionalIterator<T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , RefReturn_Wrapped_Huge.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Typed_Wrapped_Huge.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Typed_RefReturn_Huge.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        , Typed_RefReturn_Wrapped.Collections.Immutable.IReadOnlyBidirectionalIterator<T, TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Immutable {
    
    public partial interface IReadOnlyListIterator<T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , RefReturn_Wrapped_Huge.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Typed_Wrapped_Huge.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Typed_RefReturn_Huge.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        , Typed_RefReturn_Wrapped.Collections.Immutable.IReadOnlyListIterator<T, TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {
    }
}
