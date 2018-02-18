using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using UltimateOrb.Collections.Generic;

namespace UltimateOrb {

    public readonly partial struct SingletonEnumerable<T> : IEnumerable<T, SingletonEnumerable<T>.Enumerator> {

        private readonly T Value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public SingletonEnumerable(T value) {
            this.Value = value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public Enumerator GetEnumerator() {
            return new Enumerator(this);
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return new Enumerator(this);
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        IEnumerator IEnumerable.GetEnumerator() {
            return new Enumerator(this);
        }

        public partial struct Enumerator : System.Collections.Generic.IEnumerator<T> {

            private readonly SingletonEnumerable<T> sinletonEnumerable;

            private sbyte index;

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            public Enumerator(SingletonEnumerable<T> sinletonEnumerable) {
                this.sinletonEnumerable = sinletonEnumerable;
                this.index = -1;
            }

            public T Current {

                [TargetedPatchingOptOutAttribute(null)]
                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                [PureAttribute()]
                get => this.sinletonEnumerable.Value;
            }

            object IEnumerator.Current {

                [TargetedPatchingOptOutAttribute(null)]
                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                [PureAttribute()]
                get => this.sinletonEnumerable.Value;
            }

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            public void Dispose() {
            }

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            public bool MoveNext() {
                var i = this.index;
                if (1 > i) {
                    unchecked {
                        ++i;
                    }
                    this.index = i;
                }
                return 0 == i;
            }

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            public void Reset() {
                this.index = -1;
            }
        }
    }
}

namespace UltimateOrb {

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

    public partial struct Wrapper<T> : IStrongBox<T>, IReadOnlyStrongBox<T> {

        public T Value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public Wrapper(T value) {
            this.Value = value;
        }

        T IStrongBox<T>.Value {

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

        T IReadOnlyStrongBox<T>.Value {

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

    public readonly partial struct ReadOnlyWrapper<T> : IReadOnlyStrongBox<T> {

        public readonly T Value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public ReadOnlyWrapper(T value) {
            this.Value = value;
        }

        T IReadOnlyStrongBox<T>.Value {

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

    public partial struct Wrapper<T, TWrapper> : IStrongBox<T>, IReadOnlyStrongBox<T> {

        public T Value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public Wrapper(T value) {
            this.Value = value;
        }

        T IStrongBox<T>.Value {

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

        T IReadOnlyStrongBox<T>.Value {

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

    public readonly partial struct ReadOnlyWrapper<T, TWrapper> : IReadOnlyStrongBox<T> {

        public readonly T Value;

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public ReadOnlyWrapper(T value) {
            this.Value = value;
        }

        T IReadOnlyStrongBox<T>.Value {

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
