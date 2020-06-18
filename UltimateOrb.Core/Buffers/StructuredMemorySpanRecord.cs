using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateOrb.Buffers {

    public struct StructuredMemorySpanRecord {

        public MemorySpanRecord Span;

        public object? Manager {

            get => Span.Manager;

            set => Span.Manager = value;
        }

        public IntPtr ByteOffset {

            get => Span.ByteOffset;

            set => Span.ByteOffset = value;
        }

        public int Count {

            get => Span.Count;

            set => Span.Count = value;
        }

        public int Stride;
    }
}
