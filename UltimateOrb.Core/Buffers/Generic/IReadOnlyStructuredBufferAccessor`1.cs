using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateOrb.Buffers.Generic {

    public interface IReadOnlyStructuredBufferAccessor<TByte> {

        ReadOnlySpan<TByte> Span {

            get;
        }

        int Stride {

            get;
        }

        int Count {

            get;
        }
    }
}
