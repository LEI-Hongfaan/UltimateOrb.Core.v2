using System;
using System.Collections.Generic;

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;
    using Generic = System.Collections.Generic;

    public partial interface IEnumerator<T> : Generic.IEnumerator<T> {

        new ref T Current {

            get;
        }
    }
}

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;
    using Generic = System.Collections.Generic;

    public static partial class TEnumerator<T> {

        public static ref T get_Current<TEnumerator>(TEnumerator @this) where TEnumerator : IEnumerator<T> {
            return ref @this.Current;
        }
    }
}
