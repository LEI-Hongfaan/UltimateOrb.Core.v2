
using System;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Core.Tests {

    using NodeId = Int32;

    using LinkIdSourceNodeLocal = Int32;

    using LinkId = Int64;

    public interface ITupleBase {

        int Length {

            get;
        }
    }

    public interface ITuple : ITupleBase {
    }

    public interface ITuple<T> : ITupleBase {

        ref T Item {

            get;
        }
    }

    public interface ITuple<T1, T2> : ITupleBase {

        ref T1 Item1 {

            get;
        }

        ref T2 Item2 {

            get;
        }
    }

    public interface ITuple<T1, T2, T3> : ITupleBase {

        ref T1 Item1 {

            get;
        }

        ref T2 Item2 {

            get;
        }

        ref T3 Item3 {

            get;
        }
    }

    public interface ITuple<T1, T2, T3, T4> : ITupleBase {

        ref T1 Item1 {

            get;
        }

        ref T2 Item2 {

            get;
        }

        ref T3 Item3 {

            get;
        }

        ref T4 Item4 {

            get;
        }
    }

    public interface IReadOnlyTupleBase : ITupleBase {
    }

    public interface IReadOnlyTuple : IReadOnlyTupleBase {
    }

    public interface IReadOnlyTuple<T> : IReadOnlyTuple {

        ref readonly T Item {

            get;
        }
    }

    public interface IReadOnlyTuple<T1, T2> : IReadOnlyTuple {

        ref readonly T1 Item1 {

            get;
        }

        ref readonly T2 Item2 {

            get;
        }
    }

    public static partial class GraphModule {

        public static void aaaa<TNodeValue, TLinkValue>(ref this Graph<TNodeValue, TLinkValue> @this)
            where TNodeValue : ITuple<NodeId, NodeId, NodeId, int> {
            throw new NotImplementedException();
            var g = @this;
            var c = g.Data.m_count;
            var j = 0;
            var d = 0;
            for (var i = 0; c > i; ++i) {

                var k = i;
                L_a:
                ref var n = ref g.Data.m_buffer[k];
                ++d;
                n.NodeValue.Item1 = d;
                n.NodeValue.Item2 = d;

                n.NodeValue.Item4 = 1;
                g.Data.m_buffer[j++].NodeValue.Item3 = k;


                var ld = n.LinkData;
                var ii = 0;
                for (; ld.m_count > ii; ++ii) {
                    var t = ld.m_buffer[ii].Target;
                    if (g.Data.m_buffer[t].NodeValue.Item1 > 0) {
                        if (g.Data.m_buffer[t].NodeValue.Item4 > 0) {
                            n.NodeValue.Item2 = Math.Min(n.NodeValue.Item2, g.Data.m_buffer[t].NodeValue.Item1);
                        }
                    } else {
                        k = t;
                        goto L_a;
                    }
                }

                if (n.NodeValue.Item1 == n.NodeValue.Item1) {
                    /*
                    do {
                        g.Data.m_buffer[--j].NodeValue.Item4 = 1;

                    } while (k!= );
                    */
                }
            }

        }
    }

    public partial struct Graph<TNodeValue, TLinkValue> {

        public Plain.ValueTypes.Stack<(Plain.ValueTypes.Stack<(TLinkValue LinkValue, int Target)> LinkData, TNodeValue NodeValue)> Data;

        public partial struct DataSelector<TNodeValueResult, TLinkValueResult, TNodeValueSelector, TLinkValueSelector>
            : IO.IFunc<(Plain.ValueTypes.Stack<(TLinkValue LinkValue, NodeId Target)> LinkData, TNodeValue NodeValue), (Plain.ValueTypes.Stack<(TLinkValueResult LinkValue, NodeId Target)> LinkData, TNodeValueResult NodeValue)>
            , IO.IFunc<(TLinkValue LinkValue, NodeId Target), (TLinkValueResult LinkValue, NodeId Target)>
            where TNodeValueSelector : IO.IFunc<TNodeValue, TNodeValueResult>
            where TLinkValueSelector : IO.IFunc<TLinkValue, TLinkValueResult> {

            public TNodeValueSelector NodeValueSelector;

            public TLinkValueSelector LinkValueSelector;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public DataSelector(TNodeValueSelector nodeValueSelector, TLinkValueSelector linkValueSelector) {
                this.NodeValueSelector = nodeValueSelector;
                this.LinkValueSelector = linkValueSelector;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public (Plain.ValueTypes.Stack<(TLinkValueResult LinkValue, NodeId Target)> LinkData, TNodeValueResult NodeValue) Invoke((Plain.ValueTypes.Stack<(TLinkValue LinkValue, NodeId Target)> LinkData, TNodeValue NodeValue) arg) {
                return (arg.LinkData.Select<(TLinkValueResult LinkValue, NodeId Target), DataSelector<TNodeValueResult, TLinkValueResult, TNodeValueSelector, TLinkValueSelector>>(this), this.NodeValueSelector.Invoke(arg.NodeValue));
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public (TLinkValueResult LinkValue, NodeId Target) Invoke((TLinkValue LinkValue, NodeId Target) arg) {
                return (this.LinkValueSelector.Invoke(arg.LinkValue), arg.Target);
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Graph<TNodeValueResult, TLinkValueResult> Select<TNodeValueResult, TLinkValueResult, TNodeValueSelector, TLinkValueSelector>(TNodeValueSelector nodeValueSelector, TLinkValueSelector linkValueSelector)
            where TNodeValueSelector : IO.IFunc<TNodeValue, TNodeValueResult>
            where TLinkValueSelector : IO.IFunc<TLinkValue, TLinkValueResult> {
            return new Graph<TNodeValueResult, TLinkValueResult>(Data.Select<(Plain.ValueTypes.Stack<(TLinkValueResult LinkValue, NodeId Target)> LinkData, TNodeValueResult NodeValue), DataSelector<TNodeValueResult, TLinkValueResult, TNodeValueSelector, TLinkValueSelector>>(new DataSelector<TNodeValueResult, TLinkValueResult, TNodeValueSelector, TLinkValueSelector>(nodeValueSelector, linkValueSelector)));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Graph(int capacity) {
            this.Data = new Plain.ValueTypes.Stack<(Plain.ValueTypes.Stack<(TLinkValue LinkValue, NodeId Target)> LinkData, TNodeValue NodeValue)>(capacity);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Graph(Plain.ValueTypes.Stack<(Plain.ValueTypes.Stack<(TLinkValue LinkValue, NodeId Target)> LinkData, TNodeValue NodeValue)> data) {
            this.Data = data;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId AddNode(TNodeValue value) {
            var item = (new Plain.ValueTypes.Stack<(TLinkValue LinkValue, NodeId Target)>(0), value);
            var @this = this.Data;
            var c = checked(@this.m_count + 1);
            if (null == @this.m_buffer || c > @this.m_buffer.Length) {
                var t = @this.m_count;
                @this.IncreaseCapacity();
                @this.m_buffer[unchecked(c - 1)] = item;
                this.Data.m_buffer = @this.m_buffer;
                this.Data.m_count = c;
                return t;
            }
            {
                @this.m_buffer[unchecked(c - 1)] = item;
                this.Data.m_count = c;
                return @this.m_count;
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public LinkId AddLink(NodeId source, NodeId target, TLinkValue value) {
            var item = (value, target);
            ref var this_ref = ref this.Data.m_buffer[source].LinkData;
            var @this = this_ref;
            var c = checked(@this.m_count + 1);
            if (null == @this.m_buffer || c > @this.m_buffer.Length) {
                var t = @this.m_count;
                @this.IncreaseCapacity();
                @this.m_buffer[unchecked(c - 1)] = item;
                this_ref.m_buffer = @this.m_buffer;
                this_ref.m_count = c;
                return GetLinkIdFromSourceNodeLocal(source, t);
            }
            {
                @this.m_buffer[unchecked(c - 1)] = item;
                this_ref.m_count = c;
                return GetLinkIdFromSourceNodeLocal(source, @this.m_count);
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref TNodeValue GetNodeValue(NodeId node) {
            return ref this.Data.m_buffer[node].NodeValue;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref TLinkValue GetLinkValue(LinkId link) {
            return ref this.Data.m_buffer[GetSourceNode(link)].LinkData.m_buffer[GetLinkIdSourceNodeLocal(link)].LinkValue;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId GetTargetNode(LinkId link) {
            return this.Data.m_buffer[GetSourceNode(link)].LinkData.m_buffer[GetLinkIdSourceNodeLocal(link)].Target;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public LinkId GetLinkIdFromSourceNodeLocal(NodeId source, LinkIdSourceNodeLocal linkLocal) {
            return Combine(linkLocal, source);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public LinkIdSourceNodeLocal GetLinkIdSourceNodeLocal(LinkId link) {
            return GetFirst(link);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public NodeId GetSourceNode(LinkId link) {
            return GetSecond(link);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static Int64 Combine(Int32 first, Int32 second) {
            return unchecked((Int64)Combine(unchecked((UInt32)first), unchecked((UInt32)second)));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static UInt64 Combine(UInt32 first, UInt32 second) {
            return first | ((UInt64)second << 32);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static Int32 GetFirst(Int64 pair) {
            return unchecked((Int32)pair);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static UInt32 GetFirst(UInt64 pair) {
            return unchecked((UInt32)pair);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static Int32 GetSecond(Int64 pair) {
            return unchecked((Int32)GetSecond(unchecked((UInt64)pair)));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private static UInt32 GetSecond(UInt64 pair) {
            return unchecked((UInt32)(pair >> 32));
        }
    }
}
