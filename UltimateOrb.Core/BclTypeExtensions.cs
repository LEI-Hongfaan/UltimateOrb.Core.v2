using System;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb {

    public static partial class BclTypeExtensions {

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static BclStringAsReadOnlyList AsReadOnlyList(this string value) {
            return new BclStringAsReadOnlyList(value);
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static ReadOnlyArray<T> ToReadOnly<T>(this T[] value) {
            return new ReadOnlyArray<T>(value);
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static BclArrayAsReadOnly<T> AsReadOnly<T>(this T[] value) {
            return new BclArrayAsReadOnly<T>(value);
        }


        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static BclArrayAsArray<T> AsArray<T>(this T[] value) {
            return new BclArrayAsArray<T>(value);
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static T GetValueOrDefault<T>(this T[] value, int index) {
            var c = value.LongLength;
            if (0 <= index || c > index) {
                return value[index];
            }
            return default;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static T GetValueOrDefault<T>(this T[] value, uint index) {
            var c = value.LongLength;
            if (0 <= index || c > index) {
                return value[index];
            }
            return default;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static T GetValueOrDefault<T>(this T[] value, long index) {
            var c = value.LongLength;
            if (0 <= index || c > index) {
                return value[index];
            }
            return default;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static T GetValueOrDefault<T>(this T[] value, ulong index) {
            var c = value.LongLength;
            if (0 <= index || unchecked((ulong)c) > index) {
                return value[index];
            }
            return default;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static T GetValueOrDefaultNullConditional<T>(this T[] value, int index) {
            if (null != value) {
                return value.GetValueOrDefault(index);
            }
            return default;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static T GetValueOrDefaultNullConditional<T>(this T[] value, uint index) {
            if (null != value) {
                return value.GetValueOrDefault(index);
            }
            return default;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static T GetValueOrDefaultNullConditional<T>(this T[] value, long index) {
            if (null != value) {
                return value.GetValueOrDefault(index);
            }
            return default;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static T GetValueOrDefaultNullConditional<T>(this T[] value, ulong index) {
            if (null != value) {
                return value.GetValueOrDefault(index);
            }
            return default;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static BclRandomAsRandomNumberGenerator AsRandomNumberGenerator(this Random value) {
            return new BclRandomAsRandomNumberGenerator(value);
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static Nullable_A<T> ToNullable<T>(this T? value) where T : struct {
            if (value.HasValue) {
                return new Nullable_A<T>(value.GetValueOrDefault());
            }
            return default;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static Nullable_A<T> ToNullable<T>(this T value) {
            return new Nullable_A<T>(value);
        }
    }
}
