using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateOrb.Buffers {

    public struct MemorySpanRecord {

        public MemoryReferenceRecord Reference;

        public object? Manager {

            get => Reference.Manager;

            set => Reference.Manager = value;
        }

        public IntPtr ByteOffset {

            get => Reference.ByteOffset;

            set => Reference.ByteOffset = value;
        }

        public int Count;
    }
}
