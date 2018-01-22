using System;
using System.Collections.Generic;

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;

    public partial interface IStrongBox<T> : Generic.IStrongBox<T> {

        new ref T Value {

            get;
        }
    }
}
