using System;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Plain.ValueTypes {
    using NodeId = Int32;
    using NodeCount = Int32;

    public partial struct Tree<T> {

        public partial struct NodeNavigator {

            readonly Node[] buffer;

            NodeId current_id;

            Stack<NodeId> ancestor_previous_id_count_collection;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal NodeNavigator(Node[] buffer) {
                this.buffer = buffer;
                this.current_id = RootIndex;
                this.ancestor_previous_id_count_collection = Stack<NodeId>.Create(5);
            }

            public ref Node Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref this.buffer[current_id];
                }
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public NodeId GetFirstChildId() {
                return this.buffer[current_id].firstChild;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public NodeId GetNextSiblingId() {
                return this.buffer[current_id].nextSibling;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public NodeId GetParentId() {
                if (this.ancestor_previous_id_count_collection.TryPeek(out var c)) {
                    var d = this.ancestor_previous_id_count_collection.count0;
                    var t = d;
                    unchecked {
                        t -= unchecked((NodeCount)c);
                    }
                    if (0 <= t) {
                        return d;
                    }
                    {
                        var ignored = checked((ulong)t);
                    }
                }
                return RootIndex;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveToFirstChild() {
                var current_id = this.current_id;
                ref var n = ref this.buffer[current_id];
                var t = n.firstChild;
                if (NilIndex != t) {
                    this.ancestor_previous_id_count_collection.Push(current_id);
                    this.ancestor_previous_id_count_collection.Push(unchecked((NodeCount)2));
                    this.current_id = t;
                    return true;
                }
                return false;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveToLastChild() {
                if (this.MoveToFirstChild()) {
                    for (; this.MoveToNextSibling();) {
                    }
                    return true;
                }
                return false;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveToNextSibling() {
                var current_id = this.current_id;
                ref var n = ref this.buffer[current_id];
                var t = n.nextSibling;
                if (NilIndex != t) {
                    ref var d = ref this.ancestor_previous_id_count_collection.Peek();
                    var c = d;
                    unchecked {
                        ++c;
                    }
                    d = current_id;
                    this.ancestor_previous_id_count_collection.Push(c);
                    this.current_id = t;
                    return true;
                }
                return false;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveToLastSibling() {
                for (; this.MoveToNextSibling();) {
                }
                return true;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveToPreviousSibling() {
                if (this.ancestor_previous_id_count_collection.TryPeek(out var c)) {
                    if (c > 2) {
                        unchecked {
                            --this.ancestor_previous_id_count_collection.count0;
                        }
                        unchecked {
                            --c;
                        }
                        ref var d = ref this.ancestor_previous_id_count_collection.Peek();
                        var n = d;
                        d = c;
                        this.current_id = n;
                        return true;
                    }
                }
                return false;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveToFirstSibling() {
                for (; this.MoveToPreviousSibling();) {
                }
                return true;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveToParent() {
                if (this.ancestor_previous_id_count_collection.TryPeek(out var c)) {
                    ref var d = ref this.ancestor_previous_id_count_collection.count0;
                    var t = d;
                    unchecked {
                        t -= unchecked((NodeCount)c);
                    }
                    if (0 <= t) {
                        var n = d;
                        d = t;
                        this.current_id = n;
                        return true;
                    }
                    {
                        var ignored = checked((ulong)t);
                    }
                }
                return false;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveToRoot() {
                this.ancestor_previous_id_count_collection.count0 = 0;
                this.current_id = RootIndex;
                return true;
            }

            /*
            public bool MoveToNextCousin() {
                if (this.MoveToNextSibling()) {
                    return true;
                }

                var TempParent = default(NodeId);
                var TempChild = default(NodeId);
                var Depth = 0;
                var Node = this.current_id;
                do {
                    TempParent = Node.Parent;
                    if (NilIndex == TempParent) {
                        return false;
                    } else {
                        var _with1 = TempParent.Children;
                        dynamic SiblingIndex = Children.IndexOf(this) + 1;
                        if (SiblingIndex < Children.Count) {
                            TempChild = Children.Item(SiblingIndex);
                        } else {
                            TempChild = NilIndex;
                        }
                        if (NilIndex == TempChild) {
                            Node = TempParent;
                            Depth += 1;
                            continue;
                        } else {
                            Node = TempChild;
                            if (Depth > 0) {
                                do {
                                    TempChild = Node.FirstChild;
                                    if (NilIndex == TempChild) {
                                        break; // TODO: might not be correct. Was : Exit Do
                                    } else {
                                        Node = TempChild;
                                        Depth -= 1;
                                        if (Depth == 0) {
                                            this.current_id = Node;
                                        }

                                    }
                                } while (true);
                            } else {
                                this.current_id = Node;
                                return true;
                            }
                        }
                    }
                } while (true);
            }

            
            internal OrderedTreeNode<T> PrevCousin {
                get {
                    OrderedTreeNode<T> TempP = default(OrderedTreeNode<T>);
                    OrderedTreeNode<T> TempC = default(OrderedTreeNode<T>);
                    int Depth = 0;
                    OrderedTreeNode<T> Node = this;
                    do {
                        TempP = Node.Parent;
                        if (TempP == null) {
                            return null;
                        } else {
                            TempC = Node.PrevSibling;
                            if (TempC == null) {
                                Node = TempP;
                                Depth += 1;
                                continue;
                            } else {
                                Node = TempC;
                                if (Depth > 0) {
                                    do {
                                        TempC = Node.LastChild;
                                        if (TempC == null) {
                                            break; // TODO: might not be correct. Was : Exit Do
                                        } else {
                                            Node = TempC;
                                            Depth -= 1;
                                            if (Depth == 0)
                                                return Node;
                                        }
                                    } while (true);
                                } else {
                                    return Node;
                                }
                            }
                        }
                    } while (true);
                }
            }
            */
        }
    }
}
