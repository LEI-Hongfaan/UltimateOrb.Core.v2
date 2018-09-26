
namespace UltimateOrb.Huge.Collections.Generic {
    
    public partial interface IReadOnlyList<out T>
        : IReadOnlyCollection<T>
	    , System.Collections.Generic.IReadOnlyList<T> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyList<out T>
        : IReadOnlyCollection<T>
	    , System.Collections.Generic.IReadOnlyList<T> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyList<out T>
        : IReadOnlyCollection<T>
	    , Huge.Collections.Generic.IReadOnlyList<T>
	    , Wrapped.Collections.Generic.IReadOnlyList<T> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {
    
    public partial interface IReadOnlyList<T>
        : IReadOnlyCollection<T>
	    , System.Collections.Generic.IReadOnlyList<T> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {
    
    public partial interface IReadOnlyList<T>
        : IReadOnlyCollection<T>
	    , Huge.Collections.Generic.IReadOnlyList<T>
	    , RefReturn.Collections.Generic.IReadOnlyList<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyList<T>
        : IReadOnlyCollection<T>
	    , Wrapped.Collections.Generic.IReadOnlyList<T>
	    , RefReturn.Collections.Generic.IReadOnlyList<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyList<T>
        : IReadOnlyCollection<T>
	    , Wrapped_Huge.Collections.Generic.IReadOnlyList<T>
	    , RefReturn_Huge.Collections.Generic.IReadOnlyList<T>
	    , RefReturn_Wrapped.Collections.Generic.IReadOnlyList<T> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic {
    
    public partial interface IReadOnlyList<out T, out TEnumerator>
        : IReadOnlyCollection<T, TEnumerator>
	    , System.Collections.Generic.IReadOnlyList<T>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic {
    
    public partial interface IReadOnlyList<out T, out TEnumerator>
        : IReadOnlyCollection<T, TEnumerator>
	    , Huge.Collections.Generic.IReadOnlyList<T>
	    , Typed.Collections.Generic.IReadOnlyList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyList<out T, out TEnumerator>
        : IReadOnlyCollection<T, TEnumerator>
	    , Wrapped.Collections.Generic.IReadOnlyList<T>
	    , Typed.Collections.Generic.IReadOnlyList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyList<out T, out TEnumerator>
        : IReadOnlyCollection<T, TEnumerator>
	    , Wrapped_Huge.Collections.Generic.IReadOnlyList<T>
	    , Typed_Huge.Collections.Generic.IReadOnlyList<T, TEnumerator>
	    , Typed_Wrapped.Collections.Generic.IReadOnlyList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic {
    
    public partial interface IReadOnlyList<T, out TEnumerator>
        : IReadOnlyCollection<T, TEnumerator>
	    , RefReturn.Collections.Generic.IReadOnlyList<T>
	    , Typed.Collections.Generic.IReadOnlyList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic {
    
    public partial interface IReadOnlyList<T, out TEnumerator>
        : IReadOnlyCollection<T, TEnumerator>
	    , RefReturn_Huge.Collections.Generic.IReadOnlyList<T>
	    , Typed_Huge.Collections.Generic.IReadOnlyList<T, TEnumerator>
	    , Typed_RefReturn.Collections.Generic.IReadOnlyList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyList<T, out TEnumerator>
        : IReadOnlyCollection<T, TEnumerator>
	    , RefReturn_Wrapped.Collections.Generic.IReadOnlyList<T>
	    , Typed_Wrapped.Collections.Generic.IReadOnlyList<T, TEnumerator>
	    , Typed_RefReturn.Collections.Generic.IReadOnlyList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyList<T, out TEnumerator>
        : IReadOnlyCollection<T, TEnumerator>
	    , RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyList<T>
	    , Typed_Wrapped_Huge.Collections.Generic.IReadOnlyList<T, TEnumerator>
	    , Typed_RefReturn_Huge.Collections.Generic.IReadOnlyList<T, TEnumerator>
	    , Typed_RefReturn_Wrapped.Collections.Generic.IReadOnlyList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyList<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyList<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyList<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyList<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyList<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyList<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyList<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyList<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public partial interface IReadOnlyList<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyList<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}
