using System;

namespace UltimateOrb.Core.Tests {
    using System.Runtime.CompilerServices;

    public readonly struct PtrSimulated<T> : IEquatable<PtrSimulated<T>> {

        internal readonly T[] _array;

        internal readonly uint _index;

        public ref T Data {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this._array[this._index];
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public PtrSimulated(T[] array, uint index) {
            this._array = array;
            this._index = index;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static PtrSimulated<T> operator +(PtrSimulated<T> @base, int offset) {
            return new PtrSimulated<T>(@base._array, checked((uint)(@base._index + offset)));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static PtrSimulated<T> operator +(int offset, PtrSimulated<T> @base) {
            return @base + offset;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static PtrSimulated<T> operator ++(PtrSimulated<T> @base) {
            return @base + 1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static PtrSimulated<T> operator --(PtrSimulated<T> @base) {
            return @base - 1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static PtrSimulated<T> operator +(PtrSimulated<T> @base) {
            return @base;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static PtrSimulated<T> operator -(PtrSimulated<T> @base, int offset) {
            return new PtrSimulated<T>(@base._array, checked((uint)(@base._index - offset)));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int operator -(PtrSimulated<T> first, PtrSimulated<T> second) {
            if (first._array == second._array) {
                return checked((int)((long)first._index - second._index));
            }
            // TODO: Perf
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(PtrSimulated<T> first, PtrSimulated<T> second) {
            return first._array == second._array && first._index < second._index;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(PtrSimulated<T> first, PtrSimulated<T> second) {
            return first._array == second._array && first._index <= second._index;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(PtrSimulated<T> first, PtrSimulated<T> second) {
            return first._array == second._array && first._index > second._index;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(PtrSimulated<T> first, PtrSimulated<T> second) {
            return first._array == second._array && first._index >= second._index;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(PtrSimulated<T> first, PtrSimulated<T> second) {
            return first._array == second._array && first._index == second._index;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(PtrSimulated<T> first, long second) {
            if (0 == second) {
                return null == first._array;
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(PtrSimulated<T> first, long second) {
            if (0 == second) {
                return null != first._array;
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(long first, PtrSimulated<T> second) {
            return second == first;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(long first, PtrSimulated<T> second) {
            return second != first;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(PtrSimulated<T> first, ulong second) {
            if (0 == second) {
                return null == first._array;
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(PtrSimulated<T> first, ulong second) {
            if (0 == second) {
                return null != first._array;
            }
            return false;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(ulong first, PtrSimulated<T> second) {
            return second == first;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(ulong first, PtrSimulated<T> second) {
            return second != first;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(PtrSimulated<T> first, PtrSimulated<T> second) {
            return first._index != second._index || first._array != second._array;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PtrSimulated<T> other) {
            return this._array == other._array && this._index == other._index;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() {
            return unchecked((int)this._index);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) {
            if (obj is PtrSimulated<T> ptr) {
                return this.Equals(ptr);
            }
            return base.Equals(obj);
        }

        public ref T this[int offset] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this._array[checked(this._index + offset)];
        }


        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static implicit operator PtrSimulated<T>(T[] array) {
            return new PtrSimulated<T>(array, 0);
        }
    }
}
