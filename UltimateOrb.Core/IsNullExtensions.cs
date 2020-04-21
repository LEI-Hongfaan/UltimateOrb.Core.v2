using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Utilities {

    public static partial class CollectionCountExtensions {

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Count<T>(this T[] array) {
            return array.Length;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long LongCount<T>(this T[] array) {
            return array.LongLength;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Count<TCollection>(this TCollection array)
            where TCollection : ICollection {
            return array.Count;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int Count<T, TCollection>(this TCollection array)
            where TCollection : ICollection<T> {
            return array.Count;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static long LongCount<T, TCollection>(this TCollection array)
            where TCollection : Huge.Collections.Generic.ICollection<T> {
            return array.LongCount;
        }
    }

    public static partial class IsNullExtensions {

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool IsNull(this object wrapper) {
            return wrapper is null;
        }

        internal static partial class IsObjRef<T> {

            public static readonly bool Value = GetValue();

            private static bool GetValue() {
                
                return !typeof(T).IsValueType;
            }
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool IsNull<T>(this T value) {
            if (typeof(T).IsValueType) {
                return value is null;
            }

            if (IsNullAssignable<T>.Value) {
                if (IsStandardNullAssignable<T>.Value) {
                    return null == value;
                }

                if (IsINullableReference<T>.Value) {
                    return ((INullableReference)value).IsNull();
                }

                return !((INullable)value).HasValue;
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool IsNull<TWrapper>(this TWrapper wrapper, Void _ = default)
            where TWrapper : struct, INullable {
            return !wrapper.HasValue;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool IsNull<TWrapper>(this Nullable<TWrapper> wrapper)
            where TWrapper : struct {
            return !wrapper.HasValue;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool IsNull0<TNullableReference>(this TNullableReference wrapper)
            where TNullableReference : INullableReference {
            return wrapper.IsNull();
        }
    }
}
