using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.ConstrainedExecution;
using System.Runtime.CompilerServices;

namespace Internal.System {
    using global::System.Runtime.CompilerServices;
    using global::System.Runtime.ConstrainedExecution;

    [DiscardableAttribute()]
    public static partial class ArrayModule {

        internal const int MaxArrayLength = 0X7FEFFFFF;

        internal const int MaxByteArrayLength = 0x7FFFFFC7;

        public partial struct FunctorComparer<T> : IComparer<T> {

            private readonly Comparison<T> comparison;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public FunctorComparer(Comparison<T> comparison) {
                this.comparison = comparison;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public int Compare(T x, T y) {
                return this.comparison(x, y);
            }
        }
    }
}


namespace UltimateOrb.Collections.Generic {
    using global::System.Runtime.CompilerServices;
    using global::System.Runtime.ConstrainedExecution;
    
    using IntT = Int32;
    using UIntT = UInt32;

    using UltimateOrb.Utilities;

    public static partial class ListModule {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool CheckIndex<T, TList>(TList collection, IntT index) where TList : IReadOnlyList<T> {
            Contract.Requires(null != collection);
            return collection.Count.ToUnsignedUnchecked() > unchecked((UIntT)index);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool CheckSegment<T, TList>(TList collection, IntT start, IntT count) where TList : IReadOnlyList<T> {
            Contract.Requires(null != collection);
            return unchecked(start + count) <= collection.Count && 0 <= start && 0 <= count;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool CheckSegmentNonEmpty<T, TList>(TList collection, IntT start, IntT count) where TList : IReadOnlyList<T> {
            Contract.Requires(null != collection);
            return unchecked(start + count) <= collection.Count && 0 <= start && count > 0;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static bool CheckSegmentIndex<T, TList>(TList collection, IntT start, IntT count, IntT index) where TList : IReadOnlyList<T> {
            Contract.Requires(null != collection);
            return CheckSegment<T, TList>(collection, start, count) && start <= index && index < unchecked(start + count);
        }
    }
}

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;

    using System.Collections;
    using Internal.System;
    using Internal.System.Collections.Generic;
    using static UltimateOrb.Utilities.ThrowHelper;

    using static List_ThrowHelper;

    internal static partial class List_ThrowHelper {

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        internal static ArgumentOutOfRangeException ThrowArgumentOutOfRangeException_capacity() {
            throw new ArgumentOutOfRangeException("capacity");
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        internal static ArgumentOutOfRangeException ThrowArgumentOutOfRangeException_value() {
            throw new ArgumentOutOfRangeException("value");
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        internal static ArgumentOutOfRangeException CheckIndex_ArgumentOutOfRangeException() {
            throw new ArgumentOutOfRangeException("index");
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        internal static ArgumentOutOfRangeException CheckIteratorIndex_ArgumentOutOfRangeException() {
            throw new ArgumentOutOfRangeException("index");
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        internal static ArgumentNullException ThrowArgumentNullException_collection() {
            throw new ArgumentNullException("collection");
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        internal static ArgumentException ThrowArgumentException() {
            throw new ArgumentException();
        }
    }

    [DiscardableAttribute()]
    public static partial class List_CompilationOptions {

        internal const bool Checking = false;
    }
}
