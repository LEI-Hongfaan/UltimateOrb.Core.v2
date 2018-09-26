
namespace UltimateOrb.Huge.Collections.Generic {
    
    public partial interface IReadOnlyCollection<out T>
        : IReadOnlyEnumerable<T>
	    , System.Collections.Generic.IReadOnlyCollection<T> {
    }
}

namespace UltimateOrb.Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyCollection<out T>
        : IReadOnlyEnumerable<T>
	    , System.Collections.Generic.IReadOnlyCollection<T> {
    }
}

namespace UltimateOrb.Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyCollection<out T>
        : IReadOnlyEnumerable<T>
	    , Huge.Collections.Generic.IReadOnlyCollection<T>
	    , Wrapped.Collections.Generic.IReadOnlyCollection<T> {
    }
}

namespace UltimateOrb.RefReturn.Collections.Generic {
    
    public partial interface IReadOnlyCollection<T>
        : IReadOnlyEnumerable<T>
	    , System.Collections.Generic.IReadOnlyCollection<T> {
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Generic {
    
    public partial interface IReadOnlyCollection<T>
        : IReadOnlyEnumerable<T>
	    , Huge.Collections.Generic.IReadOnlyCollection<T>
	    , RefReturn.Collections.Generic.IReadOnlyCollection<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyCollection<T>
        : IReadOnlyEnumerable<T>
	    , Wrapped.Collections.Generic.IReadOnlyCollection<T>
	    , RefReturn.Collections.Generic.IReadOnlyCollection<T> {
    }
}

namespace UltimateOrb.RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyCollection<T>
        : IReadOnlyEnumerable<T>
	    , Wrapped_Huge.Collections.Generic.IReadOnlyCollection<T>
	    , RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T>
	    , RefReturn_Wrapped.Collections.Generic.IReadOnlyCollection<T> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic {
    
    public partial interface IReadOnlyCollection<out T, out TEnumerator>
        : IReadOnlyEnumerable<T, TEnumerator>
	    , System.Collections.Generic.IReadOnlyCollection<T>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic {
    
    public partial interface IReadOnlyCollection<out T, out TEnumerator>
        : IReadOnlyEnumerable<T, TEnumerator>
	    , Huge.Collections.Generic.IReadOnlyCollection<T>
	    , Typed.Collections.Generic.IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyCollection<out T, out TEnumerator>
        : IReadOnlyEnumerable<T, TEnumerator>
	    , Wrapped.Collections.Generic.IReadOnlyCollection<T>
	    , Typed.Collections.Generic.IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyCollection<out T, out TEnumerator>
        : IReadOnlyEnumerable<T, TEnumerator>
	    , Wrapped_Huge.Collections.Generic.IReadOnlyCollection<T>
	    , Typed_Huge.Collections.Generic.IReadOnlyCollection<T, TEnumerator>
	    , Typed_Wrapped.Collections.Generic.IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic {
    
    public partial interface IReadOnlyCollection<T, out TEnumerator>
        : IReadOnlyEnumerable<T, TEnumerator>
	    , RefReturn.Collections.Generic.IReadOnlyCollection<T>
	    , Typed.Collections.Generic.IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic {
    
    public partial interface IReadOnlyCollection<T, out TEnumerator>
        : IReadOnlyEnumerable<T, TEnumerator>
	    , RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T>
	    , Typed_Huge.Collections.Generic.IReadOnlyCollection<T, TEnumerator>
	    , Typed_RefReturn.Collections.Generic.IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic {
    
    public partial interface IReadOnlyCollection<T, out TEnumerator>
        : IReadOnlyEnumerable<T, TEnumerator>
	    , RefReturn_Wrapped.Collections.Generic.IReadOnlyCollection<T>
	    , Typed_Wrapped.Collections.Generic.IReadOnlyCollection<T, TEnumerator>
	    , Typed_RefReturn.Collections.Generic.IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic {
    
    public partial interface IReadOnlyCollection<T, out TEnumerator>
        : IReadOnlyEnumerable<T, TEnumerator>
	    , RefReturn_Wrapped_Huge.Collections.Generic.IReadOnlyCollection<T>
	    , Typed_Wrapped_Huge.Collections.Generic.IReadOnlyCollection<T, TEnumerator>
	    , Typed_RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T, TEnumerator>
	    , Typed_RefReturn_Wrapped.Collections.Generic.IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T> {
    }
}

namespace UltimateOrb.Typed.Collections.Generic.ExtraTypeParametersProvided {
    
    public interface IReadOnlyCollection<out T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public interface IReadOnlyCollection<out T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped.Collections.Generic.ExtraTypeParametersProvided {
    
    public interface IReadOnlyCollection<out T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_Wrapped_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public interface IReadOnlyCollection<out T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: System.Collections.Generic.IEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn.Collections.Generic.ExtraTypeParametersProvided {
    
    public interface IReadOnlyCollection<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public interface IReadOnlyCollection<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Generic.ExtraTypeParametersProvided {
    
    public interface IReadOnlyCollection<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T>
        where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic.ExtraTypeParametersProvided {
    
    public interface IReadOnlyCollection<T, out TEnumerator, in TEqualityComparer>
        : IReadOnlyCollection<T, TEnumerator>
        where TEnumerator: RefReturn.Collections.Generic.IReadOnlyEnumerator<T>
        where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
    }
}
