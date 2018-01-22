using System;
using System.Collections.Generic;

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;

    public partial interface IReadOnlyStrongBox<T> : Generic.IReadOnlyStrongBox<T> {
        
        new ref readonly T Value {

            get;
        }
    }
}
