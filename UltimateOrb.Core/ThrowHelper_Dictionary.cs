using System;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Plain.ValueTypes {

    internal static partial class ThrowHelper_Dictionary {
        
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowInvalidOperationException_EnumOpCantHappen() {
            // TODO:
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowArgumentNullException_array() {
            throw new ArgumentNullException(@"array");
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowArgumentOutOfRangeException_index_NeedNonNegNum() {
            // TODO:
            throw new ArgumentOutOfRangeException(@"index");
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowArgumentException_ArrayPlusOffTooSmall() {
            // TODO:
            throw new ArgumentException();
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowNotSupportedException_KeyCollectionSet() {
            // TODO:
            throw new NotSupportedException();
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowArgumentException_RankMultiDimNotSupported() {
            // TODO:
            throw new ArgumentException();
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowArgumentException_NonZeroLowerBound() {
            // TODO:
            throw new ArgumentException();
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowArgumentException_InvalidArrayType() {
            // TODO:
            throw new ArgumentException();
        }
    }
}
