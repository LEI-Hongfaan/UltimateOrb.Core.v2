using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Net.Sockets;
using System.Net;

namespace UltimateOrb.Core.Tests {

    public static partial class TestModule {
        class QuadrupleReferenceProcessor : IDisposable {

            enum Operation {
                Add,
                Subtract,
                Multiply,
                Divide,
                Remainder,
                Sqrt,
            };

            public Quadruple Sqrt(Quadruple value) {
                return UnaryOp(Operation.Sqrt, value);
            }

            public IEnumerable<Quadruple> Sqrt(IEnumerable<Quadruple> ps) {
                return UnaryOp(Operation.Sqrt, ps);
            }

            public Quadruple Add(Quadruple first, Quadruple second) {
                return BinOp(Operation.Add, first, second);
            }

            public IEnumerable<Quadruple> Add(IEnumerable<(Quadruple first, Quadruple second)> ps) {
                return BinOp(Operation.Add, ps);
            }

            private Quadruple BinOp(Operation op, Quadruple first, Quadruple second) {
                Unsafe.As<byte, Int128>(ref sb[0]) = default;
                Unsafe.As<byte, Operation>(ref sb[0]) = op;
                Unsafe.As<byte, Quadruple>(ref sb[16]) = first;
                Unsafe.As<byte, Quadruple>(ref sb[32]) = second;
                Unsafe.As<byte, Int128>(ref sb[48]) = default;
                var a = nc.Send(sb, 64, "localhost", 16383);
                IPEndPoint ep = null;
                var sdfasd = nc.Receive(ref ep);
                return Unsafe.As<byte, Quadruple>(ref sdfasd[0]);
            }

            private Quadruple UnaryOp(Operation op, Quadruple value) {
                Unsafe.As<byte, Int128>(ref sb[0]) = default;
                Unsafe.As<byte, Operation>(ref sb[0]) = op;
                Unsafe.As<byte, Quadruple>(ref sb[16]) = value;
                Unsafe.As<byte, Int128>(ref sb[32]) = default;
                Unsafe.As<byte, Int128>(ref sb[48]) = default;
                var a = nc.Send(sb, 64, "localhost", 16383);
                IPEndPoint ep = null;
                var sdfasd = nc.Receive(ref ep);
                return Unsafe.As<byte, Quadruple>(ref sdfasd[0]);
            }

            private IEnumerable<Quadruple> UnaryOp(Operation op, IEnumerable<Quadruple> ps) {
                var sda = new System.Collections.Concurrent.ConcurrentBag<byte[]>();



                long i = 0;
                var cmax = sb.Length / 64;
                var c = 0;
                foreach (var p in ps) {
                    var offset = 64 * c;
                    Unsafe.As<byte, Int128>(ref sb[offset + 0]) = default;
                    Unsafe.As<byte, Operation>(ref sb[offset + 0]) = op;
                    Unsafe.As<byte, Quadruple>(ref sb[offset + 16]) = p;
                    Unsafe.As<byte, Int128>(ref sb[offset + 32]) = default;
                    Unsafe.As<byte, Int128>(ref sb[offset + 48]) = default;
                    unchecked {
                        ++c;
                    }
                    unchecked {
                        ++i;
                    }
                    if (cmax == c) {
                        var a = nc.Send(sb, 64 * c, "localhost", 16383);
                        IPEndPoint ep = null;
                        var sdfasd = nc.Receive(ref ep);
                        if (sdfasd.Length / 16 < c) {
                            throw new Exception();
                        }
                        for (var j = 0; c > j; ++j) {
                            yield return Unsafe.As<byte, Quadruple>(ref sdfasd[16 * j + 0]);
                        }
                        c = 0;
                    }
                }
                {
                    if (c > 0) {
                        var a = nc.Send(sb, 64 * c, "localhost", 16383);
                        IPEndPoint ep = null;
                        var sdfasd = nc.Receive(ref ep);
                        if (sdfasd.Length / 16 < c) {
                            throw new Exception();
                        }
                        for (var j = 0; c > j; ++j) {
                            yield return Unsafe.As<byte, Quadruple>(ref sdfasd[16 * j + 0]);
                        }
                        c = 0;
                    }
                }
            }


            private IEnumerable<Quadruple> BinOp(Operation op, IEnumerable<(Quadruple First, Quadruple Second)> ps) {
                var sda = new System.Collections.Concurrent.ConcurrentBag<byte[]>();



                long i = 0;
                var cmax = sb.Length / 64;
                var c = 0;
                foreach (var p in ps) {
                    var offset = 64 * c;
                    Unsafe.As<byte, Int128>(ref sb[offset + 0]) = 0;
                    Unsafe.As<byte, Operation>(ref sb[offset + 0]) = op;
                    Unsafe.As<byte, Quadruple>(ref sb[offset + 16]) = p.First;
                    Unsafe.As<byte, Quadruple>(ref sb[offset + 32]) = p.Second;
                    Unsafe.As<byte, Int128>(ref sb[offset + 48]) = 0;
                    unchecked {
                        ++c;
                    }
                    unchecked {
                        ++i;
                    }
                    if (cmax == c) {
                        var a = nc.Send(sb, 64 * c, "localhost", 16383);
                        IPEndPoint ep = null;
                        var sdfasd = nc.Receive(ref ep);
                        if (sdfasd.Length / 16 < c) {
                            throw new Exception();
                        }
                        for (var j = 0; c > j; ++j) {
                            yield return Unsafe.As<byte, Quadruple>(ref sdfasd[16 * j + 0]);
                        }
                        c = 0;
                    }
                }
                {
                    if (c > 0) {
                        var a = nc.Send(sb, 64 * c, "localhost", 16383);
                        IPEndPoint ep = null;
                        var sdfasd = nc.Receive(ref ep);
                        if (sdfasd.Length / 16 < c) {
                            throw new Exception();
                        }
                        for (var j = 0; c > j; ++j) {
                            yield return Unsafe.As<byte, Quadruple>(ref sdfasd[16 * j + 0]);
                        }
                        c = 0;
                    }
                }
            }

            readonly byte[] sb = new byte[64 * 256];

            // readonly byte[] rb = new byte[16];

            readonly UdpClient nc = new UdpClient();

            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls

            protected virtual void Dispose(bool disposing) {
                if (!disposedValue) {
                    if (disposing) {
                        // TODO: dispose managed state (managed objects).
                        nc.Dispose();
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                    // TODO: set large fields to null.

                    disposedValue = true;
                }
            }

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~QuadrupleReferenceProcessor()
            // {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            //   Dispose(false);
            // }

            // This code added to correctly implement the disposable pattern.
            public void Dispose() {
                // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                Dispose(true);
                // TODO: uncomment the following line if the finalizer is overridden above.
                // GC.SuppressFinalize(this);
            }
            #endregion
        }
    }
}
