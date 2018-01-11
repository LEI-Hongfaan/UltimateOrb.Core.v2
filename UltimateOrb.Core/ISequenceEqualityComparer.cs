using System;
using System.Collections.Generic;

namespace UltimateOrb.Collections.Generic {
    using IntT = Int32;
    using UIntT = UInt32;

    public partial interface ISequenceEqualityComparer<in T> : IEqualityComparer<T> {

        int GetHashCode<TList>(TList source, IntT start, IntT count)
            where TList : IReadOnlyList<T>;

        bool Equals<TListFirst, TListSecond>(TListFirst first, IntT startFirst, IntT countFirst, TListSecond second, IntT startSecond, IntT countSecond)
            where TListFirst : IReadOnlyList<T>
            where TListSecond : IReadOnlyList<T>;
    }
}
