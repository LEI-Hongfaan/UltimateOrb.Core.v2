using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UltimateOrb.Collections;
using UltimateOrb.Collections.Generic;
using UltimateOrb.Collections.Generic.RefReturnSupported;

namespace UltimateOrb {

    public partial class StrongBox<T> : Collections.Generic.RefReturnSupported.IStrongBox<T>, Collections.Generic.RefReturnSupported.IReadOnlyStrongBox<T> {

        ref T Collections.Generic.RefReturnSupported.IStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Value;
        }

        T Collections.Generic.IStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this.Value = value;
        }
        
        ref readonly T Collections.Generic.RefReturnSupported.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Value;
        }

        T Collections.Generic.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public StrongBox() {
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public StrongBox(in T value) {
            this.Value = value;
        }

        public T Value;
    }

    public partial class ReadOnlyStrongBox<T> : Collections.Generic.RefReturnSupported.IReadOnlyStrongBox<T> {

        ref readonly T Collections.Generic.RefReturnSupported.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Value;
        }

        T Collections.Generic.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyStrongBox() {
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyStrongBox(in T value) {
            this.Value = value;
        }

        public readonly T Value;
    }

    public partial class StrongBoxBase<T> : Collections.Generic.RefReturnSupported.IStrongBox<T>, Collections.Generic.RefReturnSupported.IReadOnlyStrongBox<T> {

        ref T Collections.Generic.RefReturnSupported.IStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Value;
        }

        T Collections.Generic.IStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this.Value = value;
        }
        
        ref readonly T Collections.Generic.RefReturnSupported.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Value;
        }

        T Collections.Generic.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        protected StrongBoxBase() {
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        protected StrongBoxBase(in T value) {
            this.Value = value;
        }

        protected T Value;
    }

    public partial class ReadOnlyStrongBoxBase<T> : Collections.Generic.RefReturnSupported.IReadOnlyStrongBox<T> {

        ref readonly T Collections.Generic.RefReturnSupported.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Value;
        }

        T Collections.Generic.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        protected ReadOnlyStrongBoxBase() {
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        protected ReadOnlyStrongBoxBase(in T value) {
            this.Value = value;
        }

        protected readonly T Value;
    }
}
