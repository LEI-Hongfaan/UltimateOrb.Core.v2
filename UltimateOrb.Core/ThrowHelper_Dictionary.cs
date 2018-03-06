using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

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
        public static void ThrowArgumentNullException_dictionary() {
            throw new ArgumentNullException(@"dictionary");
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowArgumentNullException_key() {
            throw new ArgumentNullException(@"key");
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowArgumentNullException_value() {
            throw new ArgumentNullException(@"value");
        }
        
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowArgumentNullException_info() {
            throw new ArgumentNullException(@"info");
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowArgumentOutOfRangeException_capacity() {
            // TODO:
            throw new ArgumentOutOfRangeException(@"capacity");
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
        public static void ThrowArgumentException_AddingDuplicate() {
            // TODO:
            throw new ArgumentException();
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowArgumentException_WrongValueType(object value, Type type) {
            // TODO:
            throw new ArgumentException();
        }
        
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowNotSupportedException_KeyCollectionSet() {
            // TODO:
            throw new NotSupportedException();
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowNotSupportedException_ValueCollectionSet() {
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

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowSerializationException_MissingKeys() {
            // TODO:
            throw new SerializationException();
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void ThrowKeyNotFoundException() {
            throw new KeyNotFoundException();
        }
    }
}
