using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UltimateOrb.Collections;
using UltimateOrb.Collections.Generic;
using UltimateOrb.RefReturnSupported;

namespace UltimateOrb {
    using Local = Typed_RefReturn_Wrapped_Huge;

    public partial class StrongBox<T>
        : Local.IStrongBox<T>
        , Local.IReadOnlyStrongBox<T> {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public StrongBox() {
        }
        
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public StrongBox(in T value) {
            this.Value = value;
        }

        public T Value;

        ref T RefReturn.IStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Value;
        }

        ref readonly T RefReturn.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Value;
        }

        T Core.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;
        }

        T Core.IStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;

            set => this.Value = value;
        }
    }

    public partial class ReadOnlyStrongBox<T>
        : Local.IStrongBox<T>
        , Local.IReadOnlyStrongBox<T> {
      
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyStrongBox() {
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyStrongBox(in T value) {
            this.Value = value;
        }

        public readonly T Value;

        ref T RefReturn.IStrongBox<T>.Value {

            get => throw new NotSupportedException();
        }

        ref readonly T RefReturn.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Value;
        }

        T Core.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;
        }

        T Core.IStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;

            set => throw new NotSupportedException();
        }
    }


    public partial class StrongBoxBase<T>
        : Local.IStrongBox<T>
        , Local.IReadOnlyStrongBox<T> {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public StrongBoxBase() {
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public StrongBoxBase(in T value) {
            this.Value = value;
        }

        protected T Value;

        ref T RefReturn.IStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Value;
        }

        ref readonly T RefReturn.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Value;
        }

        T Core.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;
        }

        T Core.IStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;

            set => this.Value = value;
        }
    }

    public partial class ReadOnlyStrongBoxBase<T>
        : Local.IStrongBox<T>
        , Local.IReadOnlyStrongBox<T> {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyStrongBoxBase() {
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyStrongBoxBase(in T value) {
            this.Value = value;
        }

        protected readonly T Value;

        ref T RefReturn.IStrongBox<T>.Value {

            get => throw new NotSupportedException();
        }

        ref readonly T RefReturn.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Value;
        }

        T Core.IReadOnlyStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;
        }

        T Core.IStrongBox<T>.Value {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Value;

            set => throw new NotSupportedException();
        }
    }
}
