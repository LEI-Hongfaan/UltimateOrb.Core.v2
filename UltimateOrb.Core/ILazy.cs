using System;

namespace UltimateOrb {
    using UltimateOrb.Collections.Generic;

    public partial interface ILazy<T> : Core.IReadOnlyStrongBox<T> {

        bool IsEvaluated {

            get;
        }

        T Cache {

            get;
        }

        Func<T> ValueCreator {

            get;
        }

        TFunc GetValueCreator<TFunc>() where TFunc : IO.IFunc<T>;
    }
}

namespace UltimateOrb.RefReturnSupported {
    using UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic;

    public partial interface ILazy<T> : UltimateOrb.ILazy<T>, Core.IReadOnlyStrongBox<T> {

        ref readonly T Cache {

            get;
        }
    }
}
