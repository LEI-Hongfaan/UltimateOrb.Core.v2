using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace UltimateOrb {

    public partial interface IAllocator {

        (T[] Buffer, int Offset) Allocate<T>(int length);

        (T[] Buffer, long Offset) Allocate<T>(long length);

        void Deallocate<T>(T[] buffer, int offset, int length);

        void Deallocate<T>(T[] buffer, long offset, long length);
    }

    public partial interface IAllocator<T> {

        (T[] Buffer, int Offset) Allocate(int length);

        (T[] Buffer, long Offset) Allocate(long length);

        void Deallocate(T[] buffer, int offset, int length);

        void Deallocate(T[] buffer, long offset, long length);
    }

    public partial struct DefaultAllocator : IAllocator {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public (T[] Buffer, int Offset) Allocate<T>(int length) {
            return (new T[length], 0);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public (T[] Buffer, long Offset) Allocate<T>(long length) {
            return (new T[length], 0);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Deallocate<T>(T[] buffer, int offset, int length) {
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Deallocate<T>(T[] buffer, long offset, long length) {
        }

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        internal static void ThrowOutOfMemoryException() {
            throw new OutOfMemoryException();
        }
    }

    public partial struct DefaultAllocator<T> : IAllocator<T> {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public (T[] Buffer, int Offset) Allocate(int length) {
            return (new T[length], 0);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public (T[] Buffer, long Offset) Allocate(long length) {
            return (new T[length], 0);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Deallocate(T[] buffer, int offset, int length) {
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Deallocate(T[] buffer, long offset, long length) {
        }
    }

    public partial struct NaiveSingletonAllocatorNoThrow<T> : IAllocator<T> {

        public NaiveSingletonAllocatorNoThrow(int length) {
            this.buffer = new T[length];
        }

        public NaiveSingletonAllocatorNoThrow(long length) {
            this.buffer = new T[length];
        }

        public NaiveSingletonAllocatorNoThrow(T[] buffer) {
            this.buffer = buffer;
        }

        private readonly T[] buffer;

        public (T[] Buffer, int Offset) Allocate(int length) {
            return (this.buffer, 0);
        }

        public (T[] Buffer, long Offset) Allocate(long length) {
            return (this.buffer, 0);
        }

        public void Deallocate(T[] buffer, int offset, int length) {
        }

        public void Deallocate(T[] buffer, long offset, long length) {
        }
    }

    public partial struct NaiveSingletonAllocator<T> : IAllocator<T> {

        public NaiveSingletonAllocator(int length) {
            this.buffer = new T[length];
        }

        public NaiveSingletonAllocator(long length) {
            this.buffer = new T[length];
        }

        public NaiveSingletonAllocator(T[] buffer) {
            this.buffer = buffer;
        }

        private readonly T[] buffer;

        public (T[] Buffer, int Offset) Allocate(int length) {
            var buffer = this.buffer;
            if (null == buffer || length > buffer.Length) {
                DefaultAllocator.ThrowOutOfMemoryException();
            }
            return (buffer, 0);
        }

        public (T[] Buffer, long Offset) Allocate(long length) {
            var buffer = this.buffer;
            if (null == buffer || length > buffer.Length) {
                DefaultAllocator.ThrowOutOfMemoryException();
            }
            return (buffer, 0);
        }

        public void Deallocate(T[] buffer, int offset, int length) {
        }

        public void Deallocate(T[] buffer, long offset, long length) {
        }
    }

    public partial struct NaiveSingletonAllocatorExtendable<T> : IAllocator<T> {

        public NaiveSingletonAllocatorExtendable(int length) {
            this.buffer = new T[length];
        }

        public NaiveSingletonAllocatorExtendable(long length) {
            this.buffer = new T[length];
        }

        public NaiveSingletonAllocatorExtendable(T[] buffer) {
            this.buffer = buffer;
        }

        private T[] buffer;

        public (T[] Buffer, int Offset) Allocate(int length) {
            var buffer = this.buffer;
            if (null == buffer || length > buffer.Length) {
                buffer = new T[length];
                this.buffer = buffer;
            }
            return (buffer, 0);
        }

        public (T[] Buffer, long Offset) Allocate(long length) {
            var buffer = this.buffer;
            if (null == buffer || length > buffer.Length) {
                buffer = new T[length];
                this.buffer = buffer;
            }
            return (buffer, 0);
        }

        public void Deallocate(T[] buffer, int offset, int length) {
        }

        public void Deallocate(T[] buffer, long offset, long length) {
        }
    }
}
