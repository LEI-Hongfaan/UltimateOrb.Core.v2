using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Plain {
    using UltimateOrb.Collections.Generic.RefReturnSupported;

    public partial struct Queue<T> {

        public partial struct Enumerator : IEnumerator<T> {

            private readonly T[] buffer;

            private readonly int offset;

            private int count;

            private int index;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Enumerator(Queue<T> collection) {
                this.buffer = collection.buffer;
                var s = collection.offset;
                this.offset = s;
                this.count = collection.count;
                this.index = unchecked(s - 1);
            }

            public T Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.buffer[this.index];
                }
            }

            ref T IEnumerator<T>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref this.buffer[this.index];
                }
            }

            object System.Collections.IEnumerator.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.buffer[this.index];
                }
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Dispose() {
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() {
                var b = this.buffer;
                if (null != b) {
                    var c = this.count;
                    if (c > 0) {
                        var d = this.index;
                        unchecked {
                            --c;
                        }
                        this.count = c;
                        unchecked {
                            ++d;
                        }
                        if (b.Length == d) {
                            d = 0;
                        }
                        this.index = d;
                        return true;
                    }
                }
                return false;
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Reset() {
                var t = this.index;
                var s = this.offset;
                var r = unchecked(t - s);
                if (0 > r) {
                    unchecked {
                        r += this.buffer.Length;
                    }
                }
                this.index = unchecked(s - 1);
            }
        }
    }
}

