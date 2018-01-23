using System;
using System.Collections.Generic;

namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;

    public partial interface IReadOnlyStrongBox<T> {

        T Value {

            get;
        }
    }
}
