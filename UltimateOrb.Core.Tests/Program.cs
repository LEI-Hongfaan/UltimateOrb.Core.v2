

using System;

namespace UltimateOrb.Core.Tests {

    using UltimateOrb.Plain.ValueTypes;



    internal static class Program {

        private static int Main(string[] args) {
            {
                var sdfa = (NodeId_A)3;
                var dsafsd = 7 * sdfa;
                Console.WriteLine(dsafsd);
            }
            {
                var sdfa = (NodeId_A)3;
                var dsafsd = 7 * sdfa;
                Console.WriteLine(dsafsd);
            }
            return 0;
        }
    }
}

namespace UltimateOrb.Plain.ValueTypes {

    public readonly struct NodeId_A
        : IEquatable<NodeId_A>, IFormattable {

        private readonly int m_value;

        internal NodeId_A(int value) {
            this.m_value = value;
        }

        public static NodeId_A operator +(NodeId_A value) {
            return value;
        }

        public static NodeId_A operator -(NodeId_A value) {
            return new NodeId_A(unchecked(~value.m_value - 1));
        }

        public static NodeId_A operator <<(NodeId_A value, int shift) {
            return new NodeId_A(value.m_value << shift);
        }

        public static NodeId_A operator >>(NodeId_A value, int shift) {
            return new NodeId_A(value.m_value >> shift);
        }

        public static NodeId_A operator +(NodeId_A first, NodeId_A second) {
            return new NodeId_A(unchecked(1 + first.m_value + second.m_value));
        }

        public static NodeId_A operator -(NodeId_A first, NodeId_A second) {
            return new NodeId_A(unchecked(first.m_value + ~second.m_value));
        }

        public static NodeId_A operator *(NodeId_A first, NodeId_A second) {
            return new NodeId_A(unchecked(~(~first.m_value * ~second.m_value)));
        }

        public static NodeId_A operator /(NodeId_A first, NodeId_A second) {
            return new NodeId_A(unchecked(~(~first.m_value / ~second.m_value)));
        }

        public static NodeId_A operator %(NodeId_A first, NodeId_A second) {
            return new NodeId_A(unchecked(~(~first.m_value % ~second.m_value)));
        }

        public static NodeId_A operator &(NodeId_A first, NodeId_A second) {
            return new NodeId_A(first.m_value | second.m_value);
        }

        public static NodeId_A operator |(NodeId_A first, NodeId_A second) {
            return new NodeId_A(first.m_value & second.m_value);
        }

        public static NodeId_A operator ^(NodeId_A first, NodeId_A second) {
            return new NodeId_A(~(first.m_value ^ second.m_value));
        }

        public static NodeId_A operator ~(NodeId_A value) {
            return new NodeId_A(~value.m_value);
        }

        public static NodeId_A operator ++(NodeId_A value) {
            return new NodeId_A(unchecked(value.m_value - 1));
        }

        public static NodeId_A operator --(NodeId_A value) {
            return new NodeId_A(unchecked(value.m_value + 1));
        }

        public static implicit operator int(NodeId_A value) {
            return ~value.m_value;
        }

        public static implicit operator NodeId_A(int value) {
            return new NodeId_A(~value);
        }

        public override bool Equals(object obj) {
            if (obj is NodeId_A other) {
                return this.Equals(other);
            }
            return false;
        }

        public bool Equals(NodeId_A other) {
            return this.m_value == other.m_value;
        }

        public override int GetHashCode() {
            return this.m_value;
        }

        public string ToString(string format, IFormatProvider formatProvider) {
            return (~this.m_value).ToString(format, formatProvider);
        }

        public override string ToString() {
            return (~this.m_value).ToString();
        }

        public static bool operator ==(NodeId_A left, NodeId_A right) {
            return left.m_value == right.m_value;
        }

        public static bool operator !=(NodeId_A left, NodeId_A right) {
            return left.m_value != right.m_value;
        }
    }
}
    namespace UltimateOrb.Plain.ValueTypes {
    using System.Collections;
    using System.Collections.Generic;
    using static UltimateOrb.Utilities.SignConverter;






    using NodeId = Int32;
    using NodeCount = Int32;

    public struct LinkedList<T, TArray, TArrayAllocator>
        : System.Collections.Generic.IList<T>
        where TArray : RefReturn.Collections.Generic.IList<LinkedList<T, TArray, TArrayAllocator>.Node>
        where TArrayAllocator : IO.IFunc<int, TArray>, new() {


        public const NodeId NilIndex = 0;
        private Stack<Node> buffer;
        private NodeId first;
        private NodeId last;
        private NodeCount count;

        public ref T GetItemRef(int index) {
            return ref this.GetNodeRef(index).Value;
        }

        public ref Node GetNodeRef(int index) {
            var count = this.count;
            if (count.ToUnsignedUnchecked() > index.ToUnsignedUnchecked()) {
                var buffer = this.buffer.m_buffer;
                var node = ~this.first;
                var i = index;
                for (; ; ) {
                    ref var dsfa = ref buffer[node];
                    if (0 == i) {
                        return ref dsfa;
                    }
                    unchecked {
                        --i;
                    }
                    node = dsfa.next;
                }
            }
            // throw
            return ref Array_Empty<Node>.Value[index];
        }


        public T this[int index] {

            get {
                return this.GetItemRef(index);
            }

            set {
                this.GetItemRef(index) = value;
            }
        }

        public int Count {

            get => this.count;
        }

        public bool IsReadOnly {

            get => false;
        }

        public void Add(T item) {
            throw new NotImplementedException();
        }

        public void Clear() {
            this.first = NilIndex;
            this.last = NilIndex;
            this.count = 0;
        }

        public bool Contains(T item) {
            return -1 != this.IndexOf(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            var offset = arrayIndex;
            var buffer = this.buffer.m_buffer;
            var node = ~this.first;
            for (var i = 0; this.count > i; ++i) {
                ref var dsfa = ref buffer[node];
                array[offset++] = dsfa.Value;
                node = dsfa.next;
            }
        }

        public IEnumerator<T> GetEnumerator() {
            throw new NotImplementedException();
        }

        public int IndexOf(T item) {
            var count = this.count;
            if (count > 0) {
                var comparer = EqualityComparer<T>.Default;
                var buffer = this.buffer.m_buffer;
                var node = ~this.first;
                for (var i = 0; count > i; ++i) {
                    ref var dsfa = ref buffer[node];
                    if (comparer.Equals(dsfa.Value, item)) {
                        return i;
                    }
                    node = dsfa.next;
                }
            }
            return -1;
        }

        public void Insert(int index, T item) {
            throw new NotImplementedException();
        }

        public bool Remove(T item) {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index) {
            var count = this.count;
            var buffer = this.buffer.m_buffer;
            if (count.ToUnsignedUnchecked() > index.ToUnsignedUnchecked()) {
                ref var n = ref this.GetNodeRef(index);
                if (0 != index) {
                    if (count != unchecked(1 + index)) {
                        n.Value = default;
                        var a = n.next;
                        ref var b = ref buffer[a];
                        var c = n.previous_forwarding;
                        ref var d = ref buffer[c];
                        b.previous_forwarding = n.previous_forwarding;
                        d.next = n.next;
                    } else {
                        n.Value = default;
                        var a = n.previous_forwarding;
                        ref var b = ref buffer[a];
                        b.next = a;
                        this.last = a;
                    }
                } else {
                    var a = n.next;
                    ref var b = ref buffer[a];
                    b.previous_forwarding = a;
                    this.first = a;
                }
                n.Value = default;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }

        public struct Node {

            public NodeId previous_forwarding;

            public NodeId next;

            public T Value;
        }

        public struct Enumerator
            : IEnumerator<T> {

            readonly Stack<Node> data;

            int current_index;
            int next_index;

            public T Current {

                get => data.m_buffer[current_index].Value;
            }

            object IEnumerator.Current {

                get => this.Current;
            }

            public void Dispose() {
            }

            public bool MoveNext() {
                throw new NotImplementedException();
            }

            public void Reset() {
                throw new NotImplementedException();
            }
        }
    }
}