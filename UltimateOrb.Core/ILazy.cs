using System;
using UltimateOrb.Collections.Generic.RefReturnSupported;

namespace UltimateOrb {

    public partial interface ILazy<T> : IReadOnlyStrongBox<T> {

        bool IsEvaluated {

            get;
        }

        ref readonly T Cache {

            get;
        }

        Func<T> ValueCreator {

            get;
        }

        TFunc GetValueCreator<TFunc>() where TFunc : IO.IFunc<T>;
    }
}
