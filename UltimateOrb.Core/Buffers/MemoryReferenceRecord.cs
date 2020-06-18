using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateOrb.Buffers {

    public struct MemoryReferenceRecord {

        public object? Manager;

        public IntPtr ByteOffset;
    }
}
