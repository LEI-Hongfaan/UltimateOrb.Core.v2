using System;
using System.Runtime.CompilerServices;
using UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic;

namespace UltimateOrb.Plain.ValueTypes {
    using NodeId = Int32;
    using NodeCount = Int32;

    public partial struct Tree<T> {

        public partial struct NodeEnumerator : IEnumerator<Node> {

            readonly Node[] data;

            readonly NodeCount count;

            NodeId id;

            Stack<NodeId> ancestors;

            private NodeId RootPreviousIndex {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.count;
                }
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public NodeEnumerator(Tree<T> tree) {
                this.data = tree.m_data.m_buffer;
                var count = tree.m_data.m_count;
                this.count = count;
                this.id = count;
                this.ancestors = Stack<NodeId>.Create();
            }

            public ref Node Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref this.data[id];
                }
            }

            Node System.Collections.Generic.IEnumerator<Node>.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.data[id];
                }
            }

            object System.Collections.IEnumerator.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.data[id];
                }
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() {
                var id = this.id;
                var data = this.data;
                if (RootPreviousIndex != id) {
                    var nx = data[id].firstChild;
                    if (NilIndex == nx) {
                        nx = data[id].nextSibling;
                        if (NilIndex != nx) {
                            this.id = nx;
                            return true;
                        }
                        for (var ancestors = this.ancestors; ancestors.m_count > 0;) {
                            if (NilIndex != (id = data[ancestors.Pop()].nextSibling)) {
                                this.ancestors.m_count = ancestors.m_count;
                                this.id = id;
                                return true;
                            }
                        }
                        this.ancestors.m_count = 0;
                        return false;
                    }
                    this.ancestors.Push(id);
                    this.id = nx;
                    return true;
                }
                this.id = RootIndex;
                return true;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Reset() {
                this.ancestors.m_count = 0;
                this.id = RootPreviousIndex;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Dispose() {
            }
        }
    }
}
