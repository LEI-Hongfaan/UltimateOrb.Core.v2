using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Collections.Generic {
    using UltimateOrb;
    
    // TODO
    // REV API Namespace
    internal partial struct EqualityPredicate<T, TEqualityComparer>
        : IPredicate<T>
        where TEqualityComparer : IEqualityComparer<T> {

        private TEqualityComparer comparer;

        private T value;

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        internal EqualityPredicate(TEqualityComparer comparer, T value) {
            this.comparer = comparer;
            this.value = value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Invoke(T value) {
            return this.comparer.Equals(this.value, value);
        }
    }
}
