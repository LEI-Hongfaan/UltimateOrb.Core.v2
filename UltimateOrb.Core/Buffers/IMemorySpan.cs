using System;

namespace UltimateOrb.Buffers {

    public interface IMemorySpan {

        object? Manager {

            get;
        }

        IntPtr ByteOffset {

            get;
        }

        int Count {

            get;
        }
    }
}
