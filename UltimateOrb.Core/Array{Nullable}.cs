using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace UltimateOrb {
    using Local = Typed_RefReturn_Wrapped_Huge;

    public readonly partial struct Array<T>
        : INullable, INullableReference {

        bool INullable.HasValue {

            get => null != this.m_value;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsNull() {
            return null == this.m_value;
        }

        bool INullableReference.IsNull() {
            return null == this.m_value;
        }
    }
}