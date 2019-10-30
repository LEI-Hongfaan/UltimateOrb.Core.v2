
namespace UltimateOrb {
    using System;

    public interface IArrayAccessor {

        bool IsHuge {

            get;
        }
    }

    public interface IArrayAccessor<T>
        : IArrayAccessor {

        ref T this[int index] {

            get;
        }
    }

    public interface IArrayAccessorLong<T>
        : IArrayAccessor<T> {

        ref T this[long index] {

            get;
        }
    }

    public interface IArrayAccessorNative<T>
        : IArrayAccessor<T> {

        ref T this[IntPtr index] {

            get;
        }
    }

    public interface IArrayAccessorBasic<T> {

        bool IsHuge {

            get;
        }

        ref T this[int index] {

            get;
        }

        ref T this[uint index] {

            get;
        }

        ref T this[long index] {

            get;
        }

        ref T this[ulong index] {

            get;
        }

        ref T this[IntPtr index] {

            get;
        }

        ref T this[UIntPtr index] {

            get;
        }

        int Length {

            get;
        }

        long LongLength {

            get;
        }
    }
}
