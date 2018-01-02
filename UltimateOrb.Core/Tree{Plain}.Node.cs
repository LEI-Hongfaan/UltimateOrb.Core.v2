using System;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Plain.ValueTypes {
    using NodeId = Int32;

    public partial struct Tree<T> {

        public partial struct Node {

            public NodeId forwarding;

            public NodeId firstChild;

            public NodeId nextSibling;

            public T Value;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Node(T value) {
                forwarding = default(NodeId);
                nextSibling = default(NodeId);
                firstChild = default(NodeId);
                Value = value;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Node(NodeId forwarding, NodeId firstChild, NodeId nextSibling, T value) {
                this.forwarding = forwarding;
                this.firstChild = firstChild;
                this.nextSibling = nextSibling;
                this.Value = value;
            }
        }
    }
}
