using System;
using System.Runtime.CompilerServices;
using UltimateOrb.Collections.Generic.RefReturnSupported;

namespace UltimateOrb.Plain.ValueTypes {
    using NodeId = Int32;

    public partial struct Tree<T> {

        public partial struct ChildrenEnumerator : IEnumerator<Node> {

            readonly Node[] data;

            NodeId parent;

            NodeId id;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public ChildrenEnumerator(Node[] data, NodeId parent) {
                this.data = data;
                this.parent = parent;
                id = NilIndex;
            }

            public ref Node Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref data[id];
                }
            }

            Node System.Collections.Generic.IEnumerator<Node>.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return data[id];
                }
            }

            void IDisposable.Dispose() {
            }

            object System.Collections.IEnumerator.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return data[id];
                }
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            bool System.Collections.IEnumerator.MoveNext() {
                if (NilIndex == id) {
                    if (NilIndex != parent) {
                        id = parent;
                        parent = NilIndex;
                        return NilIndex == (id = data[id].firstChild);
                    }
                    return false;
                } else {
                    return NilIndex == (id = data[id].nextSibling);
                }
            }

            void System.Collections.IEnumerator.Reset() {
                throw new NotSupportedException();
            }
        }
    }
}
