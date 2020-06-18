using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateOrb.Buffers.Generic {

    public interface IStructuredBufferAccessor<TByte> {

        Span<TByte> Span {

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
