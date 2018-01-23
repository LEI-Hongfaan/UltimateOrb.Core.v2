﻿using System;
using System.Collections.Generic;

namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;
    using System.Runtime.CompilerServices;

    public partial interface IStrongBox<T> {

        T Value {

            get;

            set;
        }
    }
}
