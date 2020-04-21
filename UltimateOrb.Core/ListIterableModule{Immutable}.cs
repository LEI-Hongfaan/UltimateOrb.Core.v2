
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Wrapped.Collections.Generic {
    using Local = UltimateOrb.Wrapped;

    public struct DefaultListEnumerator_A<T, TList>
        : Local.Collections.Generic.IEnumerator<T>
        , Local.Collections.Generic.IReadOnlyEnumerator<T>
        where TList : Local.Collections.Generic.IReadOnlyList<T> {

        private readonly TList list;

        private int index;

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public DefaultListEnumerator_A(in TList list) {
            this.list = list;
            this.index = -1;
        }

        public T Current {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.list[this.index];
        }

        T System.Collections.Generic.IEnumerator<T>.Current {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Current;
        }

        object System.Collections.IEnumerator.Current {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.list[this.index];
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Dispose() {
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext() {
            var i = this.index;
            checked {
                ++i;
            }
            var count = this.list.Count;
            if (count > i) {
                this.index = i;
                return true;
            }
            this.index = count;
            return false;
        }

        [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Reset() {
            this.index = -1;
        }
    }
}


namespace UltimateOrb.Wrapped.Collections.Generic {
    using Local = UltimateOrb.Wrapped;

    public struct DefaultListEnumerator<T, TList>
        : Local.Collections.Generic.IEnumerator<T>
        , Local.Collections.Generic.IReadOnlyEnumerator<T>
        where TList : Local.Collections.Generic.IReadOnlyList<T> {

        private readonly TList list;
        private readonly int count;
        private int index;
        private T current;

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public DefaultListEnumerator(in TList list) {
            var count = list.Count;
            this.list = list;
            this.count = count;
            this.index = 0;
            this.current = default;
        }

        public T Current {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.current;
        }

        T System.Collections.Generic.IEnumerator<T>.Current {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Current;
        }

        object System.Collections.IEnumerator.Current {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Current;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Dispose() {
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext() {
            var index = this.index;
            if (unchecked((uint)index) < unchecked((uint)this.count)) {
                this.current = this.list[index];
                this.index = unchecked(1 + index);
                return true;
            }
            return this.MoveNextRare();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private bool MoveNextRare() {
            this.index = unchecked(1 + this.count);
            this.current = default; // Good for GC.
            return false;
        }

        [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Reset() {
            this.index = 0;
            this.current = default; // Good for GC.
        }
    }
}

namespace UltimateOrb.Wrapped.Collections.Generic {
    using Local = UltimateOrb.Wrapped;
    using UltimateOrb.Wrapped.Collections.Immutable.Unchecked;
    using System.Collections;

    public readonly struct ListView<TSource, TResult, TList, TGetterSelector, TSetterSelector>
        : System.Collections.Generic.IList<TResult>
        , System.Collections.Generic.IReadOnlyList<TResult>
        , Local.Collections.Generic.IList<TResult>
        , Local.Collections.Generic.IReadOnlyList<TResult>
        where TList : System.Collections.Generic.IList<TSource>
        where TGetterSelector : UltimateOrb.IO.IFunc<TSource, TResult>, new()
        where TSetterSelector : UltimateOrb.IO.IFunc<TResult, TSource>, new() {

        private readonly TList list;

        private TGetterSelector GetterSelector {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => UltimateOrb.DefaultConstructor.Invoke<TGetterSelector>();
        }

        private TSetterSelector SetterSelector {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => UltimateOrb.DefaultConstructor.Invoke<TSetterSelector>();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private TResult Select(TSource value) {
            return this.GetterSelector.Invoke(value);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        private TSource Select(TResult value) {
            return this.SetterSelector.Invoke(value);
        }

        public TResult this[int index] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Select(this.list[index]);

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this.list[index] = this.Select(value);
        }

        public int Count {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.list.Count;
        }

        public bool IsReadOnly {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.list.IsReadOnly;
        }

        public ListView<TSource, TResult, TList, TGetterSelector, TSetterSelector> Data {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this;
        }

        public int Offset {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => 0;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Add(TResult item) {
            this.list.Add(this.Select(item));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Clear() {
            this.list.Clear();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains(TResult item) {
            return this.list.Contains(this.Select(item));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(TResult[] array, int arrayIndex) {
            unchecked {
                if (null == array) {
                    throw new ArgumentNullException(nameof(array));
                }
                var j = arrayIndex;
                if (0 > j) {
                    throw new ArgumentOutOfRangeException(nameof(arrayIndex));
                }
                var count = this.list.Count;
                if (unchecked((uint)count) > unchecked((uint)(array.Length - j))) {
                    throw new ArgumentException();
                }
                for (var i = 0; array.Length > j && count > i; ++i) {
                    array[j++] = this.Select(this.list[i]);
                }
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() {
            return new Enumerator(this);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.Generic.IEnumerator<TResult> System.Collections.Generic.IEnumerable<TResult>.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(TResult item) {
            return this.list.IndexOf(this.Select(item));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Insert(int index, TResult item) {
            this.list.Insert(index, this.Select(item));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove(TResult item) {
            return this.list.Remove(this.Select(item));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void RemoveAt(int index) {
            this.list.RemoveAt(index);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(Array<TResult> array, int arrayIndex) {
            this.CopyTo(array.Value, arrayIndex);
        }

        public struct Enumerator
            : Local.Collections.Generic.IEnumerator<TResult>
            , Local.Collections.Generic.IReadOnlyEnumerator<TResult> {

            private DefaultListEnumerator<TResult, ListView<TSource, TResult, TList, TGetterSelector, TSetterSelector>> @base;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Enumerator(ListView<TSource, TResult, TList, TGetterSelector, TSetterSelector> listView) {
                this.@base = new DefaultListEnumerator<TResult, ListView<TSource, TResult, TList, TGetterSelector, TSetterSelector>>(listView);
            }

            public TResult Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => this.@base.Current;
            }

            object IEnumerator.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get => this.@base.Current;
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Dispose() {
                this.@base.Dispose();
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() {
                return this.@base.MoveNext();
            }

            [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Reset() {
                this.@base.Reset();
            }
        }
    }
}
