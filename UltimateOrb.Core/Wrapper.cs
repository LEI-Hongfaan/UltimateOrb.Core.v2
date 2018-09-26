﻿using System;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb {
    using Local = Typed_Wrapped_Huge;

    public static partial class WrapperModule {

        public static object ToWrapperDynamic(object value) {
            if (null == value) {
                return null;
            }
            var t = value.GetType();
            return typeof(Wrapper<>).MakeGenericType(t).GetConstructor(new[] { t, }).Invoke(new[] { value, });
        }

        public static object ToWrapperDynamic<TWrapper>(object value) {
            if (null == value) {
                return null;
            }
            var t = value.GetType();
            return typeof(Wrapper<,>).MakeGenericType(t, typeof(TWrapper)).GetConstructor(new[] { t, }).Invoke(new[] { value, });
        }

        public static object ToWrapperDynamic(object value, Type tWrapper) {
            if (null == value) {
                return null;
            }
            var t = value.GetType();
            return typeof(Wrapper<,>).MakeGenericType(t, tWrapper).GetConstructor(new[] { t, }).Invoke(new[] { value, });
        }

        public static object ToReadOnlyWrapperDynamic(object value) {
            if (null == value) {
                return null;
            }
            var t = value.GetType();
            return typeof(ReadOnlyWrapper<>).MakeGenericType(t).GetConstructor(new[] { t, }).Invoke(new[] { value, });
        }

        public static object ToReadOnlyWrapperDynamic<TWrapper>(object value) {
            if (null == value) {
                return null;
            }
            var t = value.GetType();
            return typeof(ReadOnlyWrapper<,>).MakeGenericType(t, typeof(TWrapper)).GetConstructor(new[] { t, }).Invoke(new[] { value, });
        }

        public static object ToReadOnlyWrapperDynamic(object value, Type tWrapper) {
            if (null == value) {
                return null;
            }
            var t = value.GetType();
            return typeof(ReadOnlyWrapper<,>).MakeGenericType(t, tWrapper).GetConstructor(new[] { t, }).Invoke(new[] { value, });
        }
    }

    public partial struct Wrapper<T>
        : Local.IStrongBox<T>
        , Local.IReadOnlyStrongBox<T> {

        public T Value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public Wrapper(T value) {
            this.Value = value;
        }

        T Core.IStrongBox<T>.Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.Value;

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            set => this.Value = value;
        }

        T Core.IReadOnlyStrongBox<T>.Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.Value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator T(Wrapper<T> value) {
            return value.Value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator Wrapper<T>(T value) {
            return new Wrapper<T>(value);
        }

        public override string ToString() {
            var value = this.Value;
            if (null != value) {
                return value.ToString();
            }
            return @"";
        }
    }

    public readonly partial struct ReadOnlyWrapper<T>
        : Local.IStrongBox<T>
        , Local.IReadOnlyStrongBox<T> {

        public readonly T Value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public ReadOnlyWrapper(T value) {
            this.Value = value;
        }

        T Core.IReadOnlyStrongBox<T>.Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.Value;
        }

        T Core.IStrongBox<T>.Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.Value;

            set => throw new NotSupportedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator T(ReadOnlyWrapper<T> value) {
            return value.Value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator ReadOnlyWrapper<T>(T value) {
            return new ReadOnlyWrapper<T>(value);
        }

        public override string ToString() {
            var value = this.Value;
            if (null != value) {
                return value.ToString();
            }
            return @"";
        }
    }

    public partial struct Wrapper<T, TWrapper>
        : Local.IStrongBox<T>
        , Local.IReadOnlyStrongBox<T> {

        public T Value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public Wrapper(T value) {
            this.Value = value;
        }

        T Core.IStrongBox<T>.Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.Value;

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            set => this.Value = value;
        }

        T Core.IReadOnlyStrongBox<T>.Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.Value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator T(Wrapper<T, TWrapper> value) {
            return value.Value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator Wrapper<T, TWrapper>(T value) {
            return new Wrapper<T, TWrapper>(value);
        }
    }

    public readonly partial struct ReadOnlyWrapper<T, TWrapper>
        : Local.IStrongBox<T>
        , Local.IReadOnlyStrongBox<T> {

        public readonly T Value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public ReadOnlyWrapper(T value) {
            this.Value = value;
        }

        T Core.IReadOnlyStrongBox<T>.Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.Value;
        }

        T Core.IStrongBox<T>.Value {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => this.Value;

            set => throw new NotSupportedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator T(ReadOnlyWrapper<T, TWrapper> value) {
            return value.Value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static implicit operator ReadOnlyWrapper<T, TWrapper>(T value) {
            return new ReadOnlyWrapper<T, TWrapper>(value);
        }
    }
}
