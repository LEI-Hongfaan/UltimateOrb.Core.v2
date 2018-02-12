using System;

namespace UltimateOrb {
    using UltimateOrb.Collections.Generic;

    public partial interface ILazy<T> : IReadOnlyStrongBox<T> {

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
    using UltimateOrb.Collections.Generic.RefReturnSupported;

    public partial interface ILazy<T> : UltimateOrb.ILazy<T>, IReadOnlyStrongBox<T> {

        ref readonly T Cache {

            get;
        }
    }
}
