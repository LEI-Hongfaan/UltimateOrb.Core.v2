using System;
using System.Runtime.CompilerServices;
using UltimateOrb.Collections.Generic.RefReturnSupported;

namespace UltimateOrb.Plain.ValueTypes {
    using NodeId = Int32;
    using NodeCount = Int32;

    public partial struct Tree<T> {

        public partial struct Enumerator : IEnumerator<T> {

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
            public Enumerator(Tree<T> tree) {
                this.data = tree.Value.buffer;
                this.count = tree.Value.count;
                this.id = count;
                this.ancestors = default(Stack<NodeId>);
            }

            public ref T Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref this.data[id].Value;
                }
            }

            T System.Collections.Generic.IEnumerator<T>.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.data[id].Value;
                }
            }

            object System.Collections.IEnumerator.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.data[id].Value;
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
                        for (var ancestors = this.ancestors; ancestors.count > 0;) {
                            if (NilIndex != (id = data[ancestors.Pop()].nextSibling)) {
                                this.ancestors.count = ancestors.count;
                                this.id = id;
                                return true;
                            }
                        }
                        this.ancestors.count = 0;
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
                this.ancestors.count = 0;
                this.id = RootPreviousIndex;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Dispose() {
            }
        }
    }
}
