namespace UltimateOrb.Buffers {

    public interface IStructuredMemorySpan : IMemorySpan {

        int ByteStride {

            get;
        }
    }
}
