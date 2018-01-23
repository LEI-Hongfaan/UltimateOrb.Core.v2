using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UltimateOrb.Collections.Generic.RefReturnSupported;

namespace UltimateOrb.Plain.ValueTypes {
    using NodeId = Int32;
    using NodeCount = Int32;
    using System.Collections;

    public partial struct Tree<T> {

        public const NodeId NilIndex = 0;

        public const NodeId RootIndex = 0;

        public Stack<Node> m_data;

        public Tree(Stack<Node> data) {
            this.m_data = data;
        }

        public ref Node this[NodeId id] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return ref this.m_data.m_buffer[id];
            }
        }

        [MethodImplAttribute(default(MethodImplOptions))]
        public void IncreaseCapacity() {
            Array.Resize(ref m_data.m_buffer, checked((NodeCount)(22 + 2.6180339887498948482045868343656 * m_data.m_count)));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Tree(T root, NodeCount capacity) {
            this.m_data = new Stack<Node>(capacity);
            ref var r = ref this.m_data.Push();
            r.Value = root;
        }

        internal partial struct NodeSelector0<TResult, TSelector> : IO.IFunc<Tree<T>.Node, Tree<TResult>.Node> where TSelector : IO.IFunc<T, TResult> {

            public Tree<TResult>.Node Invoke(Node arg) {
                return new Tree<TResult>.Node(arg.forwarding, arg.firstChild, arg.nextSibling, default(TSelector).Invoke(arg.Value));
            }
        }

        internal partial struct NodeSelector1<TResult, TSelector> : IO.IFunc<Tree<T>.Node, Tree<TResult>.Node> where TSelector : IO.IFunc<T, TResult> {

            public readonly TSelector selector;

            public NodeSelector1(TSelector selector) {
                this.selector = selector;
            }

            public Tree<TResult>.Node Invoke(Node arg) {
                return new Tree<TResult>.Node(arg.forwarding, arg.firstChild, arg.nextSibling, selector.Invoke(arg.Value));
            }
        }

        public Tree<TResult> Select<TResult, TSelector>(TSelector selector) where TSelector : IO.IFunc<T, TResult> {
            var @this = this;
            @this.Collect();
            return new Tree<TResult>(@this.m_data.Select<Tree<TResult>.Node, NodeSelector1<TResult, TSelector>>(new NodeSelector1<TResult, TSelector>(selector)));
        }

        public Tree<TResult> Select<TResult, TSelector>() where TSelector : IO.IFunc<T, TResult>, new() {
            var @this = this;
            @this.Collect();
            return null == default(TSelector) ? @this.Select<TResult, TSelector>(DefaultConstructor.Invoke<TSelector>()) : new Tree<TResult>(@this.m_data.Select<Tree<TResult>.Node, NodeSelector0<TResult, TSelector>>(default));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Tree<T> Create(T root) {
            return new Tree<T>(root, 200);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId CreateNewNode(T value) {
            var a = m_data.m_count + 1;
            if (null == m_data.m_buffer || a > m_data.m_buffer.Length) {
                IncreaseCapacity();
            }
            m_data.m_buffer[a - 1].Value = value;
            m_data.m_count = a;
            return a - 1;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref Node CreateNewNodeAsNodeRef(T value) {
            var a = checked(m_data.m_count + 1);
            if (null == m_data.m_buffer || a > m_data.m_buffer.Length) {
                IncreaseCapacity();
            }
            ref var node = ref m_data.m_buffer[unchecked(a - 1)];
            node.Value = value;
            m_data.m_count = a;
            return ref node;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void NodeSetNextSiblingValue(NodeId node, NodeId nextSibling) {
            m_data.m_buffer[node].nextSibling = nextSibling;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void NodeSetNextSiblingValueVolatile(NodeId node, NodeId nextSibling) {
            System.Threading.Volatile.Write(ref m_data.m_buffer[node].nextSibling, nextSibling);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId NodeGetNextSiblingValue(NodeId node) {
            return m_data.m_buffer[node].nextSibling;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref NodeId NodeGetNextSiblingValueRef(NodeId node) {
            return ref m_data.m_buffer[node].nextSibling;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId NodeGetNextSiblingValueVolatile(NodeId node) {
            return System.Threading.Volatile.Read(ref m_data.m_buffer[node].nextSibling);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId AddFirst(NodeId node, T value) {
            var result = CreateNewNode(value);
            var buffer = m_data.m_buffer;
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
                var buffer = m_data.m_buffer;
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
            m_data.m_buffer[node].firstChild = firstChild;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void NodeSetFirstChildValueVolatile(NodeId node, NodeId firstChild) {
            System.Threading.Volatile.Write(ref m_data.m_buffer[node].firstChild, firstChild);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId NodeGetFirstChildValue(NodeId node) {
            return m_data.m_buffer[node].firstChild;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref NodeId NodeGetFirstChildValueRef(NodeId node) {
            return ref m_data.m_buffer[node].firstChild;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId NodeGetFirstChildValueVolatile(NodeId node) {
            return System.Threading.Volatile.Read(ref m_data.m_buffer[node].firstChild);
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
            return new NodeNavigator(this.m_data.m_buffer);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeEnumerator GetNodeEnumerator() {
            return new NodeEnumerator(this);
        }

        public static Tree<T> FromPreorderNodeInfo<TEnumerator, TEnumerable>(TEnumerable data)
            where TEnumerable : Collections.Generic.IEnumerable<(long ChildCount, T Value), TEnumerator>
            where TEnumerator : System.Collections.Generic.IEnumerator<(long ChildCount, T Value)> {
            var e = data.GetEnumerator();
            var r = FromPreorderNodeInfo_Enumerator(e);
            e.Dispose();
            return r;
        }

        public static Tree<T> FromPreorderNodeInfo<TEnumerable>(TEnumerable data)
            where TEnumerable : System.Collections.Generic.IEnumerable<(long ChildCount, T Value)> {
            var e = data.GetEnumerator();
            var r = FromPreorderNodeInfo_Enumerator(e);
            e.Dispose();
            return r;
        }

        private static Tree<T> FromPreorderNodeInfo_Enumerator<TEnumerator>(TEnumerator data)
            where TEnumerator : System.Collections.Generic.IEnumerator<(long ChildCount, T Value)> {
            for (; data.MoveNext();) {
                Tree<T> tree;
                Stack<(long current, NodeId parent, NodeId lastChild)> s;
                NodeId p;
                NodeId q;
                {
                    var item = data.Current;
                    if (0 == item.ChildCount) {
                        return new Tree<T>(item.Value, 1);
                    } else {
                        s = Stack<(long current, NodeId parent, NodeId lastChild)>.Create();
                        tree = new Tree<T>(item.Value, 5);
                        p = RootIndex;
                        q = NilIndex;
                        s.Push((checked(item.ChildCount - 1), p, q));
                    }
                }
                for (; data.MoveNext();) {
                    var item = data.Current;
                    if (0 == item.ChildCount) {
                        q = NilIndex != q ? tree[q].nextSibling = tree.CreateNewNode(item.Value) : tree[p].firstChild = tree.CreateNewNode(item.Value);
                        for (; ; ) {
                            ref var t = ref s.Peek();
                            if (0 == t.current) {
                                if (s.Count <= 1) {
                                    goto L_0001;
                                } else {
                                    p = t.parent;
                                    // TODO
                                    unchecked {
                                        --s.m_count;
                                    }
                                }
                            } else {
                                t.current = checked(t.current - 1);
                                t.lastChild = q;
                                break;
                            }
                        }
                    } else {
                        p = NilIndex != q ? tree[q].nextSibling = tree.CreateNewNode(item.Value) : tree[p].firstChild = tree.CreateNewNode(item.Value);
                        q = NilIndex;
                        s.Push((checked(item.ChildCount - 1), p, q));
                    }
                }
                L_0001:
                return tree;
            }
            return default;
        }

        public struct PreorderNodeInfoEnumerable : Collections.Generic.IEnumerable<(long ChildCount, T Value), PreorderNodeInfoEnumerator> {
            
            internal readonly Tree<T> tree;

            public PreorderNodeInfoEnumerable(Tree<T> tree) : this() {
                this.tree = tree;
            }

            public PreorderNodeInfoEnumerator GetEnumerator() {
                return tree.GetPreorderNodeInfoEnumerator();
            }

            System.Collections.Generic.IEnumerator<(long ChildCount, T Value)> System.Collections.Generic.IEnumerable<(long ChildCount, T Value)>.GetEnumerator() {
                return tree.GetPreorderNodeInfoEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return tree.GetPreorderNodeInfoEnumerator();
            }
        }

        public PreorderNodeInfoEnumerable GetPreorderNodeInfo() {
            return new PreorderNodeInfoEnumerable(this);
        }

        public PreorderNodeInfoEnumerator GetPreorderNodeInfoEnumerator() {
            return new PreorderNodeInfoEnumerator(this);
        }
        
        public partial struct PreorderNodeInfoEnumerator : System.Collections.Generic.IEnumerator<(long ChildCount, T Value)> {

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
            public PreorderNodeInfoEnumerator(Tree<T> tree) {
                this.data = tree.m_data.m_buffer;
                var count = tree.m_data.m_count;
                this.count = count;
                this.id = count;
                this.ancestors = Stack<NodeId>.Create();
            }

            public (long ChildCount, T Value) Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    var data = this.data;
                    return (NodeGetChildCount(data, id), data[id].Value);
                }
            }

            object System.Collections.IEnumerator.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.Current;
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

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            private static long NodeGetChildCount(Node[] data, NodeId node) {
                var id = data[node].firstChild;
                for (long i = 0; ;) {
                    if (NilIndex == id) {
                        return i;
                    }
                    checked {
                        ++i;
                    }
                    id = data[node].nextSibling;
                }
            }
        }

        [MethodImplAttribute(default(MethodImplOptions))]
        public void Collect() {
            var n = RootIndex;
            if (m_data.m_buffer[n].firstChild == NilIndex) {
                return;
            }
            Stack<NodeId> s = Stack<NodeId>.Create();
            s.Push(m_data.m_buffer[n].nextSibling);
            var a = 2;
            for (NodeId ni = m_data.m_buffer[n].firstChild; ; ++a) {
                n = ni;
                m_data.m_buffer[n].forwarding = ~RootIndex;
                ni = m_data.m_buffer[n].firstChild;
                if (ni != NilIndex) {
                    s.Push(m_data.m_buffer[n].nextSibling);
                    continue;
                }
                ni = m_data.m_buffer[n].nextSibling;
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
                if (m_data.m_buffer.Length <= i) {
                    break;
                }
                n = ++i;
                if (m_data.m_buffer[n].forwarding == RootIndex) {
                    goto L_2;
                }
                m_data.m_buffer[n].forwarding = k;
            }
            // L_CompactM:;
            var m = RootIndex;
            m_data.m_buffer[m].firstChild = m_data.m_buffer[m_data.m_buffer[m].firstChild].forwarding;
            for (NodeId i = RootIndex + 1, j = a - 1, k = i; j > 0; --j, ++k) {
                L_3:;
                if (m_data.m_buffer.Length <= i) {
                    break;
                }
                n = ++i;
                if (m_data.m_buffer[n].forwarding == RootIndex) {
                    goto L_3;
                }
                if (i == k) {
                    continue;
                }
                m = k;
                m_data.m_buffer[m].firstChild = m_data.m_buffer[m_data.m_buffer[n].firstChild].forwarding;
                m_data.m_buffer[m].nextSibling = m_data.m_buffer[m_data.m_buffer[n].nextSibling].forwarding;
                m_data.m_buffer[m].Value = m_data.m_buffer[n].Value;
            }
            for (NodeId i = RootIndex + 1, j = a - 1; m_data.m_buffer.Length <= i && j > 0;) {
                n = ++i;
                if (m_data.m_buffer[n].forwarding != RootIndex) {
                    m_data.m_buffer[n].forwarding = RootIndex;
                    --j;
                }
            }
            m_data.m_count = a;
        }
    }
}
