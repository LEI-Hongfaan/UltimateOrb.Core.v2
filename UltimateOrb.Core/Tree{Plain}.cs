using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Plain.ValueTypes {
    using NodeId = Int32;
    using NodeCount = Int32;

    public partial struct Tree<T> {

        public const NodeId NilIndex = 0;

        public const NodeId RootIndex = 0;

        public Stack<Node> Value;

        public ref Node this[NodeId id] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return ref this.Value.buffer[id];
            }
        }

        [MethodImplAttribute(default(MethodImplOptions))]
        public void IncreaseCapacity() {
            Array.Resize(ref Value.buffer, (NodeCount)(22 + 2.6180339887498948482045868343656 * Value.count));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Tree(T root, NodeCount capacity) {
            this.Value = new Stack<Node>(capacity);
            ref var r = ref this.Value.Push();
            r.Value = root;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Tree<T> Create(T root) {
            return new Tree<T>(root, 200);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId CreateNewNode(T value) {
            var a = Value.count + 1;
            if (null == Value.buffer || a > Value.buffer.Length) {
                IncreaseCapacity();
            }
            Value.buffer[a - 1].Value = value;
            Value.count = a;
            return a - 1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref Node CreateNewNodeAsNodeRef(T value) {
            var a = checked(Value.count + 1);
            if (null == Value.buffer || a > Value.buffer.Length) {
                IncreaseCapacity();
            }
            ref var node = ref Value.buffer[unchecked(a - 1)];
            node.Value = value;
            Value.count = a;
            return ref node;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void NodeSetNextSiblingValue(NodeId node, NodeId nextSibling) {
            Value.buffer[node].nextSibling = nextSibling;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void NodeSetNextSiblingValueVolatile(NodeId node, NodeId nextSibling) {
            System.Threading.Volatile.Write(ref Value.buffer[node].nextSibling, nextSibling);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId NodeGetNextSiblingValue(NodeId node) {
            return Value.buffer[node].nextSibling;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref NodeId NodeGetNextSiblingValueRef(NodeId node) {
            return ref Value.buffer[node].nextSibling;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId NodeGetNextSiblingValueVolatile(NodeId node) {
            return System.Threading.Volatile.Read(ref Value.buffer[node].nextSibling);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId AddFirst(NodeId node, T value) {
            var result = CreateNewNode(value);
            var buffer = Value.buffer;
            ref var nc = ref buffer[node].firstChild;
            if (NilIndex != nc) {
                buffer[result].nextSibling = nc;
            } else {
                nc = result;
            }
            return result;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId AddAfter(NodeId node, T value) {
            if (NilIndex != node && RootIndex != node) {
                var result = CreateNewNode(value);
                var buffer = Value.buffer;
                ref var ns = ref buffer[node].nextSibling;
                if (NilIndex != ns) {
                    buffer[result].nextSibling = ns;
                }
                ns = result;
                return result;
            }
            throw new InvalidOperationException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void NodeSetFirstChildValue(NodeId node, NodeId firstChild) {
            Value.buffer[node].firstChild = firstChild;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void NodeSetFirstChildValueVolatile(NodeId node, NodeId firstChild) {
            System.Threading.Volatile.Write(ref Value.buffer[node].firstChild, firstChild);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId NodeGetFirstChildValue(NodeId node) {
            return Value.buffer[node].firstChild;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref NodeId NodeGetFirstChildValueRef(NodeId node) {
            return ref Value.buffer[node].firstChild;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId NodeGetFirstChildValueVolatile(NodeId node) {
            return System.Threading.Volatile.Read(ref Value.buffer[node].firstChild);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeCount NodeGetChildCount(NodeId node) {
            var id = NodeGetFirstChildValue(node);
            for (NodeCount i = 0; ;) {
                if (NilIndex == id) {
                    return i;
                }
                checked {
                    ++i;
                }
                id = NodeGetNextSiblingValue(node);
            }
        }

        public NodeNavigator GetNodeNavigator() {
            return new NodeNavigator(this.Value.buffer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeEnumerator GetNodeEnumerator() {
            return new NodeEnumerator(this);
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(default(System.Runtime.CompilerServices.MethodImplOptions))]
        public void Collect() {
            var n = RootIndex;
            if (Value.buffer[n].firstChild == NilIndex) {
                return;
            }
            Stack<NodeId> s = Stack<NodeId>.Create();
            s.Push(Value.buffer[n].nextSibling);
            var a = 2;
            for (NodeId ni = Value.buffer[n].firstChild; ; ++a) {
                n = ni;
                Value.buffer[n].forwarding = ~RootIndex;
                ni = Value.buffer[n].firstChild;
                if (ni != NilIndex) {
                    s.Push(Value.buffer[n].nextSibling);
                    continue;
                }
                ni = Value.buffer[n].nextSibling;
                if (ni != NilIndex) {
                    continue;
                }
                for (; ; ) {
                    if (s.Count == 0) {
                        goto L_CompactS;
                    }
                    if ((ni = s.Pop()) == NilIndex) {
                        continue;
                    }
                    break;
                }
            }
            L_CompactS:;
            for (NodeId i = RootIndex + 1, j = a - 1, k = i; j > 0; --j, ++k) {
                L_2:;
                if (Value.buffer.Length <= i) {
                    break;
                }
                n = ++i;
                if (Value.buffer[n].forwarding == RootIndex) {
                    goto L_2;
                }
                Value.buffer[n].forwarding = k;
            }
            // L_CompactM:;
            var m = RootIndex;
            Value.buffer[m].firstChild = Value.buffer[Value.buffer[m].firstChild].forwarding;
            for (NodeId i = RootIndex + 1, j = a - 1, k = i; j > 0; --j, ++k) {
                L_3:;
                if (Value.buffer.Length <= i) {
                    break;
                }
                n = ++i;
                if (Value.buffer[n].forwarding == RootIndex) {
                    goto L_3;
                }
                if (i == k) {
                    continue;
                }
                m = k;
                Value.buffer[m].firstChild = Value.buffer[Value.buffer[n].firstChild].forwarding;
                Value.buffer[m].nextSibling = Value.buffer[Value.buffer[n].nextSibling].forwarding;
                Value.buffer[m].Value = Value.buffer[n].Value;
            }
            for (NodeId i = RootIndex + 1, j = a - 1; Value.buffer.Length <= i && j > 0;) {
                n = ++i;
                if (Value.buffer[n].forwarding != RootIndex) {
                    Value.buffer[n].forwarding = RootIndex;
                    --j;
                }
            }
            Value.count = a;
        }
    }
}
