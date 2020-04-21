using System;
using System.Collections;
using System.Collections.Generic;
using UltimateOrb.Core;
using UltimateOrb.Typed_Wrapped.Collections.Generic;

namespace UltimateOrb.Plain.ValueTypes {

    namespace ArrayTrees {

        public static class Module {

            public static int GetFirstChild(this int index) {
                return unchecked(1 + (2 * index));
            }

            public static int GetNextSiblingLastChild(this int index) {
                return unchecked(2 * (1 + index));
            }

            public static int GetParent(this int index) {
                return unchecked((index - 1) >> 1);
            }

            public static int GetRoot() {
                return 0;
            }
        }
    }

    namespace SegmentTree {

        using static ArrayTrees.Module;

        [FlagsAttribute()]
        public enum NodeFlags {

            None = 0,

            HasFirstChild = 0x01,

            HasNextSiblingLastChild = 0x02,

            HasParent = 0x04,

            HasTree = 0x08,
        }

        public struct Node<TKey, TValue>
            : IStrongBox<TValue>
            where TKey : struct, IComparable<TKey> {

            public NodeFlags Flags;

            public TKey LowerBound;

            public TKey UpperBound;

            public TValue Value;

            TValue IStrongBox<TValue>.Value {
                get => throw new NotImplementedException();

                set => throw new NotImplementedException();
            }

            /*
            public bool HasFirstChild {
                get => 0 != (NodeFlags.HasFirstChild & this.Flags);
            }

            public bool HasLastChild {
                get => 0 != (NodeFlags.HasNextSiblingLastChild & this.Flags);
            }
            */
        }

        public static class Module {

            public static TValue Aggregate<TKey, TValue, TBinOp>(this Node<TKey, TValue>[] tree, TBinOp op, TValue defalutValue, TKey lowerBound, TKey upperBound)
                where TKey : struct, IComparable<TKey>
                where TBinOp : IFunc<TValue, TValue, TValue> {
                return Aggregate(tree, op, defalutValue, GetRoot(), lowerBound, upperBound);
            }

            private static TValue Aggregate<TKey, TValue, TBinOp>(this Node<TKey, TValue>[] tree, TBinOp op, TValue defalutValue, int node, TKey lowerBound, TKey upperBound)
                where TKey : struct, IComparable<TKey>
                where TBinOp : IFunc<TValue, TValue, TValue> {
                ref var n = ref tree[node];
                var l = n.LowerBound;
                var u = n.UpperBound;

                for (; ; ) {
                    if (l.CompareTo(lowerBound) <= 0 && upperBound.CompareTo(u) <= 0) {
                        return n.Value;
                    }
                    if (lowerBound.CompareTo(u) > 0 || l.CompareTo(upperBound) > 0) {
                        return defalutValue;
                    }
                    {
                        return op.Invoke(Aggregate(tree, op, defalutValue, node.GetFirstChild(), l, u), Aggregate(tree, op, defalutValue, node.GetNextSiblingLastChild(), l, u));
                    }
                }
            }

            private struct Aggregate_State<TValue> {

                public int Current;

                public TValue Value;
            }
        }
    }

    public readonly struct FenwickTreeInt64PartialSumInt32Collection {

        public readonly Int32[] _Data;

        public FenwickTreeInt64PartialSumInt32Collection(int length) {
            _Data = new Int32[length];
        }

        public static Int64 SumCore(Int32[] data, int count) {
            Int64 result = 0;
            for (var i = unchecked(count - 1); 0 <= i; i = unchecked(((1 + i) & i) - 1)) {
                var t = data[i];
                unchecked {
                    result += t;
                }
            }
            return result;
        }

        #region PartialSumCollection
        public PartialSumCollection AsPartialSumCollection() {
            return new PartialSumCollection(this);
        }

        public readonly struct PartialSumCollection
            : IList<Int64, PartialSumCollection.Enumerator>
            , IReadOnlyList<Int64, PartialSumCollection.Enumerator> {

            private readonly UltimateOrb.Typed_Wrapped.Collections.Generic.ReadOnlyListBase<Int64, PartialSumAccessor> _Base;

            public PartialSumCollection(FenwickTreeInt64PartialSumInt32Collection underlying) {
                this._Base = new ReadOnlyListBase<Int64, PartialSumAccessor>(new PartialSumAccessor(underlying));
            }

            public int Count => _Base.Count;

            public bool IsReadOnly => _Base.IsReadOnly;

            public Int64 this[int index] => _Base[index];

            Int64 System.Collections.Generic.IList<Int64>.this[int index] { get => ((IList<Int64, ReadOnlyListBase<Int64, PartialSumAccessor>.Enumerator>)_Base)[index]; set => ((IList<Int64, ReadOnlyListBase<Int64, PartialSumAccessor>.Enumerator>)_Base)[index] = value; }

            public void Add(Int64 item) {
                _Base.Add(item);
            }

            public void Clear() {
                _Base.Clear();
            }

            public bool Contains<TEqualityComparer>(Int64 item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Int64> {
                return ((IList<Int64, ReadOnlyListBase<Int64, PartialSumAccessor>.Enumerator>)_Base).Contains<TEqualityComparer>(item, comparer);
            }

            public bool Contains(Int64 item) {
                return _Base.Contains(item);
            }

            public void CopyTo(Array<Int64> array, int arrayIndex) {
                _Base.CopyTo(array, arrayIndex);
            }

            public void CopyTo(Int64[] array, int arrayIndex) {
                _Base.CopyTo(array, arrayIndex);
            }

            public Enumerator GetEnumerator() {
                return new Enumerator(this);
            }

            System.Collections.Generic.IEnumerator<Int64> System.Collections.Generic.IEnumerable<Int64>.GetEnumerator() {
                return _Base.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return _Base.GetEnumerator();
            }

            public int IndexOf<TEqualityComparer>(Int64 item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Int64> {
                return ((IList<Int64, ReadOnlyListBase<Int64, PartialSumAccessor>.Enumerator>)_Base).IndexOf<TEqualityComparer>(item, comparer);
            }

            public int IndexOf(Int64 item) {
                return _Base.IndexOf(item);
            }

            public void Insert(int index, Int64 item) {
                _Base.Insert(index, item);
            }

            public bool Remove<TEqualityComparer>(Int64 item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Int64> {
                return ((IList<Int64, ReadOnlyListBase<Int64, PartialSumAccessor>.Enumerator>)_Base).Remove<TEqualityComparer>(item, comparer);
            }

            public bool Remove(Int64 item) {
                return _Base.Remove(item);
            }

            public void RemoveAt(int index) {
                _Base.RemoveAt(index);
            }

            public struct Enumerator
                : System.Collections.Generic.IEnumerator<Int64>
                , UltimateOrb.Typed_Wrapped.Collections.Generic.IEnumerator<Int64>
                , UltimateOrb.Typed_Wrapped.Collections.Generic.IReadOnlyEnumerator<Int64> {

                private UltimateOrb.Typed_Wrapped.Collections.Generic.ReadOnlyListBase<Int64, PartialSumAccessor>.Enumerator _Base;

                public Enumerator(PartialSumCollection collection) {
                    _Base = collection._Base.GetEnumerator();
                }

                public Int64 Current => ((System.Collections.Generic.IEnumerator<Int64>)_Base).Current;

                object IEnumerator.Current => ((System.Collections.Generic.IEnumerator<Int64>)_Base).Current;

                public void Dispose() {
                    ((System.Collections.Generic.IEnumerator<Int64>)_Base).Dispose();
                }

                public bool MoveNext() {
                    return ((System.Collections.Generic.IEnumerator<Int64>)_Base).MoveNext();
                }

                public void Reset() {
                    ((System.Collections.Generic.IEnumerator<Int64>)_Base).Reset();
                }
            }
        }

        private struct PartialSumAccessor : UltimateOrb.Core.Collections.Generic.IReadOnlyListBase<Int64> {
            private FenwickTreeInt64PartialSumInt32Collection _Collection;

            public PartialSumAccessor(FenwickTreeInt64PartialSumInt32Collection collection) {
                this._Collection = collection;
            }

            public int Count {
                get => checked(1 + _Collection._Data.Length);
            }

            public Int64 this[int index] {
                get => _Collection.Sum(index);
            }
        }

        #endregion PartialSumCollection

        #region PartialSumSkipOneCollection
        public PartialSumSkipOneCollection AsPartialSumSkipOneCollection() {
            return new PartialSumSkipOneCollection(this);
        }

        public readonly struct PartialSumSkipOneCollection
            : IList<Int64, PartialSumSkipOneCollection.Enumerator>
            , IReadOnlyList<Int64, PartialSumSkipOneCollection.Enumerator> {

            private readonly UltimateOrb.Typed_Wrapped.Collections.Generic.ReadOnlyListBase<Int64, PartialSumSkipOneAccessor> _Base;

            public PartialSumSkipOneCollection(FenwickTreeInt64PartialSumInt32Collection underlying) {
                this._Base = new ReadOnlyListBase<Int64, PartialSumSkipOneAccessor>(new PartialSumSkipOneAccessor(underlying));
            }

            public int Count => _Base.Count;

            public bool IsReadOnly => _Base.IsReadOnly;

            public Int64 this[int index] => _Base[index];

            Int64 System.Collections.Generic.IList<Int64>.this[int index] { get => ((IList<Int64, ReadOnlyListBase<Int64, PartialSumSkipOneAccessor>.Enumerator>)_Base)[index]; set => ((IList<Int64, ReadOnlyListBase<Int64, PartialSumSkipOneAccessor>.Enumerator>)_Base)[index] = value; }

            public void Add(Int64 item) {
                _Base.Add(item);
            }

            public void Clear() {
                _Base.Clear();
            }

            public bool Contains<TEqualityComparer>(Int64 item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Int64> {
                return ((IList<Int64, ReadOnlyListBase<Int64, PartialSumSkipOneAccessor>.Enumerator>)_Base).Contains<TEqualityComparer>(item, comparer);
            }

            public bool Contains(Int64 item) {
                return _Base.Contains(item);
            }

            public void CopyTo(Array<Int64> array, int arrayIndex) {
                _Base.CopyTo(array, arrayIndex);
            }

            public void CopyTo(Int64[] array, int arrayIndex) {
                _Base.CopyTo(array, arrayIndex);
            }

            public Enumerator GetEnumerator() {
                return new Enumerator(this);
            }

            System.Collections.Generic.IEnumerator<Int64> System.Collections.Generic.IEnumerable<Int64>.GetEnumerator() {
                return _Base.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return _Base.GetEnumerator();
            }

            public int IndexOf<TEqualityComparer>(Int64 item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Int64> {
                return ((IList<Int64, ReadOnlyListBase<Int64, PartialSumSkipOneAccessor>.Enumerator>)_Base).IndexOf<TEqualityComparer>(item, comparer);
            }

            public int IndexOf(Int64 item) {
                return _Base.IndexOf(item);
            }

            public void Insert(int index, Int64 item) {
                _Base.Insert(index, item);
            }

            public bool Remove<TEqualityComparer>(Int64 item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Int64> {
                return ((IList<Int64, ReadOnlyListBase<Int64, PartialSumSkipOneAccessor>.Enumerator>)_Base).Remove<TEqualityComparer>(item, comparer);
            }

            public bool Remove(Int64 item) {
                return _Base.Remove(item);
            }

            public void RemoveAt(int index) {
                _Base.RemoveAt(index);
            }

            public struct Enumerator
                : System.Collections.Generic.IEnumerator<Int64>
                , UltimateOrb.Typed_Wrapped.Collections.Generic.IEnumerator<Int64>
                , UltimateOrb.Typed_Wrapped.Collections.Generic.IReadOnlyEnumerator<Int64> {

                private UltimateOrb.Typed_Wrapped.Collections.Generic.ReadOnlyListBase<Int64, PartialSumSkipOneAccessor>.Enumerator _Base;

                public Enumerator(PartialSumSkipOneCollection collection) {
                    _Base = collection._Base.GetEnumerator();
                }

                public Int64 Current => ((System.Collections.Generic.IEnumerator<Int64>)_Base).Current;

                object IEnumerator.Current => ((System.Collections.Generic.IEnumerator<Int64>)_Base).Current;

                public void Dispose() {
                    ((System.Collections.Generic.IEnumerator<Int64>)_Base).Dispose();
                }

                public bool MoveNext() {
                    return ((System.Collections.Generic.IEnumerator<Int64>)_Base).MoveNext();
                }

                public void Reset() {
                    ((System.Collections.Generic.IEnumerator<Int64>)_Base).Reset();
                }
            }
        }

        private struct PartialSumSkipOneAccessor : UltimateOrb.Core.Collections.Generic.IReadOnlyListBase<Int64> {
            
            private FenwickTreeInt64PartialSumInt32Collection _Collection;

            public PartialSumSkipOneAccessor(FenwickTreeInt64PartialSumInt32Collection collection) {
                this._Collection = collection;
            }

            public int Count {
                get => _Collection._Data.Length;
            }

            public Int64 this[int index] {
                get => _Collection.Sum(checked(1 + index));
            }
        }
        #endregion PartialSumSkipOneCollection

        #region ValueCollection

        public ValueCollection AsValueCollection() {
            return new ValueCollection(this);
        }

        public readonly struct ValueCollection
            : IList<Int64, ValueCollection.Enumerator>
            , IReadOnlyList<Int64, ValueCollection.Enumerator> {

            private readonly UltimateOrb.Typed_Wrapped.Collections.Generic.ReadOnlyListBase<Int64, ValueAccessor> _Base;

            public ValueCollection(FenwickTreeInt64PartialSumInt32Collection underlying) {
                this._Base = new ReadOnlyListBase<Int64, ValueAccessor>(new ValueAccessor(underlying));
            }

            public int Count => _Base.Count;

            public bool IsReadOnly => _Base.IsReadOnly;

            public Int64 this[int index] => _Base[index];

            Int64 System.Collections.Generic.IList<Int64>.this[int index] { get => ((IList<Int64, ReadOnlyListBase<Int64, ValueAccessor>.Enumerator>)_Base)[index]; set => ((IList<Int64, ReadOnlyListBase<Int64, ValueAccessor>.Enumerator>)_Base)[index] = value; }

            public void Add(Int64 item) {
                _Base.Add(item);
            }

            public void Clear() {
                _Base.Clear();
            }

            public bool Contains<TEqualityComparer>(Int64 item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Int64> {
                return ((IList<Int64, ReadOnlyListBase<Int64, ValueAccessor>.Enumerator>)_Base).Contains<TEqualityComparer>(item, comparer);
            }

            public bool Contains(Int64 item) {
                return _Base.Contains(item);
            }

            public void CopyTo(Array<Int64> array, int arrayIndex) {
                _Base.CopyTo(array, arrayIndex);
            }

            public void CopyTo(Int64[] array, int arrayIndex) {
                _Base.CopyTo(array, arrayIndex);
            }

            public Enumerator GetEnumerator() {
                return new Enumerator(this);
            }

            System.Collections.Generic.IEnumerator<Int64> System.Collections.Generic.IEnumerable<Int64>.GetEnumerator() {
                return _Base.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return _Base.GetEnumerator();
            }

            public int IndexOf<TEqualityComparer>(Int64 item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Int64> {
                return ((IList<Int64, ReadOnlyListBase<Int64, ValueAccessor>.Enumerator>)_Base).IndexOf<TEqualityComparer>(item, comparer);
            }

            public int IndexOf(Int64 item) {
                return _Base.IndexOf(item);
            }

            public void Insert(int index, Int64 item) {
                _Base.Insert(index, item);
            }

            public bool Remove<TEqualityComparer>(Int64 item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Int64> {
                return ((IList<Int64, ReadOnlyListBase<Int64, ValueAccessor>.Enumerator>)_Base).Remove<TEqualityComparer>(item, comparer);
            }

            public bool Remove(Int64 item) {
                return _Base.Remove(item);
            }

            public void RemoveAt(int index) {
                _Base.RemoveAt(index);
            }

            public struct Enumerator
                : System.Collections.Generic.IEnumerator<Int64>
                , UltimateOrb.Typed_Wrapped.Collections.Generic.IEnumerator<Int64>
                , UltimateOrb.Typed_Wrapped.Collections.Generic.IReadOnlyEnumerator<Int64> {

                private UltimateOrb.Typed_Wrapped.Collections.Generic.ReadOnlyListBase<Int64, ValueAccessor>.Enumerator _Base;

                public Enumerator(ValueCollection collection) {
                    _Base = collection._Base.GetEnumerator();
                }

                public Int64 Current => ((System.Collections.Generic.IEnumerator<Int64>)_Base).Current;

                object IEnumerator.Current => ((System.Collections.Generic.IEnumerator<Int64>)_Base).Current;

                public void Dispose() {
                    ((System.Collections.Generic.IEnumerator<Int64>)_Base).Dispose();
                }

                public bool MoveNext() {
                    return ((System.Collections.Generic.IEnumerator<Int64>)_Base).MoveNext();
                }

                public void Reset() {
                    ((System.Collections.Generic.IEnumerator<Int64>)_Base).Reset();
                }
            }
        }

        private struct ValueAccessor : UltimateOrb.Core.Collections.Generic.IReadOnlyListBase<Int64> {
            private FenwickTreeInt64PartialSumInt32Collection _Collection;

            public ValueAccessor(FenwickTreeInt64PartialSumInt32Collection collection) {
                this._Collection = collection;
            }

            public int Count {
                get => _Collection._Data.Length;
            }

            public Int64 this[int index] {
                get => _Collection.GetValue(index);
            }
        }
        #endregion ValueCollection

        #region TreeNodeValueCollection
        public TreeNodeValueCollection AsTreeNodeValueCollection() {
            return new TreeNodeValueCollection(this);
        }

        public readonly struct TreeNodeValueCollection
            : IList<Int32, TreeNodeValueCollection.Enumerator>
            , IReadOnlyList<Int32, TreeNodeValueCollection.Enumerator> {

            private readonly UltimateOrb.Typed_Wrapped.Collections.Generic.ReadOnlyListBase<Int32, TreeNodeValueAccessor> _Base;

            public TreeNodeValueCollection(FenwickTreeInt64PartialSumInt32Collection underlying) {
                this._Base = new ReadOnlyListBase<Int32, TreeNodeValueAccessor>(new TreeNodeValueAccessor(underlying));
            }

            public int Count => _Base.Count;

            public bool IsReadOnly => _Base.IsReadOnly;

            public Int32 this[int index] => _Base[index];

            Int32 System.Collections.Generic.IList<Int32>.this[int index] { get => ((IList<Int32, ReadOnlyListBase<Int32, TreeNodeValueAccessor>.Enumerator>)_Base)[index]; set => ((IList<Int32, ReadOnlyListBase<Int32, TreeNodeValueAccessor>.Enumerator>)_Base)[index] = value; }

            public void Add(Int32 item) {
                _Base.Add(item);
            }

            public void Clear() {
                _Base.Clear();
            }

            public bool Contains<TEqualityComparer>(Int32 item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Int32> {
                return ((IList<Int32, ReadOnlyListBase<Int32, TreeNodeValueAccessor>.Enumerator>)_Base).Contains<TEqualityComparer>(item, comparer);
            }

            public bool Contains(Int32 item) {
                return _Base.Contains(item);
            }

            public void CopyTo(Array<Int32> array, int arrayIndex) {
                _Base.CopyTo(array, arrayIndex);
            }

            public void CopyTo(Int32[] array, int arrayIndex) {
                _Base.CopyTo(array, arrayIndex);
            }

            public Enumerator GetEnumerator() {
                return new Enumerator(this);
            }

            System.Collections.Generic.IEnumerator<Int32> System.Collections.Generic.IEnumerable<Int32>.GetEnumerator() {
                return _Base.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return _Base.GetEnumerator();
            }

            public int IndexOf<TEqualityComparer>(Int32 item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Int32> {
                return ((IList<Int32, ReadOnlyListBase<Int32, TreeNodeValueAccessor>.Enumerator>)_Base).IndexOf<TEqualityComparer>(item, comparer);
            }

            public int IndexOf(Int32 item) {
                return _Base.IndexOf(item);
            }

            public void Insert(int index, Int32 item) {
                _Base.Insert(index, item);
            }

            public bool Remove<TEqualityComparer>(Int32 item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<Int32> {
                return ((IList<Int32, ReadOnlyListBase<Int32, TreeNodeValueAccessor>.Enumerator>)_Base).Remove<TEqualityComparer>(item, comparer);
            }

            public bool Remove(Int32 item) {
                return _Base.Remove(item);
            }

            public void RemoveAt(int index) {
                _Base.RemoveAt(index);
            }

            public struct Enumerator
                : System.Collections.Generic.IEnumerator<Int32>
                , UltimateOrb.Typed_Wrapped.Collections.Generic.IEnumerator<Int32>
                , UltimateOrb.Typed_Wrapped.Collections.Generic.IReadOnlyEnumerator<Int32> {

                private UltimateOrb.Typed_Wrapped.Collections.Generic.ReadOnlyListBase<Int32, TreeNodeValueAccessor>.Enumerator _Base;

                public Enumerator(TreeNodeValueCollection collection) {
                    _Base = collection._Base.GetEnumerator();
                }

                public Int32 Current => ((System.Collections.Generic.IEnumerator<Int32>)_Base).Current;

                object IEnumerator.Current => ((System.Collections.Generic.IEnumerator<Int32>)_Base).Current;

                public void Dispose() {
                    ((System.Collections.Generic.IEnumerator<Int32>)_Base).Dispose();
                }

                public bool MoveNext() {
                    return ((System.Collections.Generic.IEnumerator<Int32>)_Base).MoveNext();
                }

                public void Reset() {
                    ((System.Collections.Generic.IEnumerator<Int32>)_Base).Reset();
                }
            }
        }

        private struct TreeNodeValueAccessor : UltimateOrb.Core.Collections.Generic.IReadOnlyListBase<Int32> {
            private FenwickTreeInt64PartialSumInt32Collection _Collection;

            public TreeNodeValueAccessor(FenwickTreeInt64PartialSumInt32Collection collection) {
                this._Collection = collection;
            }

            public int Count {
                get => _Collection._Data.Length;
            }

            public Int32 this[int index] {
                get => _Collection._Data[index];
            }
        }
        #endregion TreeNodeValueCollection

        public Int64 GetValue(int index) {
            var a = _Data;
            var b = a.Length;
            if (unchecked((uint)a.Length) > unchecked((uint)index)) {
                return unchecked(SumCore(a, unchecked(1 + index)) - SumCore(a, index));
            }
            throw ThrowIndexOutOfRangeException();
        }

        public Int64 Sum(int count) {
            var a = _Data;
            if (unchecked((uint)count) <= unchecked((uint)a.Length)) {
                return SumCore(a, count);
            }
            throw ThrowIndexOutOfRangeException();
        }

        public Int64 Sum(int offset, int count) {
            var a = _Data;
            var b = a.Length; // null check
            if (0 > count) {
                throw ThrowArgumentOutOfRangeException_count();
            }
            if (unchecked((uint)b) > unchecked((uint)offset)) {
                var c = checked(offset + count); // TODO: Correct Exception type
                if (unchecked((uint)c) <= unchecked((uint)b)) {
                    return unchecked(SumCore(a, c) - SumCore(a, offset));
                }
            }
            throw ThrowIndexOutOfRangeException();
        }

        public void Update(int index, int delta) {
            var a = _Data;
            var b = a.Length;
            for (var i = index; b > i; i |= unchecked(1 + i)) {
                ref var d = ref a[i];
                checked {
                    d += delta;
                }
            }
        }

        private static ArgumentOutOfRangeException ThrowArgumentOutOfRangeException_count() {
            return new ArgumentOutOfRangeException("count");
        }

        private static IndexOutOfRangeException ThrowIndexOutOfRangeException() {
            throw new IndexOutOfRangeException();
        }
    }
}
