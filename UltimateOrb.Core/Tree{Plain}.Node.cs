using System;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Plain.ValueTypes {
    using NodeId = Int32;

    public partial struct Tree<T> {

        public partial struct Node {

            public NodeId forwarding;

            public NodeId nextSibling;

            public NodeId firstChild;

            public T Value;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Node(T value) {
                forwarding = default(NodeId);
                nextSibling = default(NodeId);
                firstChild = default(NodeId);
                Value = value;
            }
        }
    }
}
