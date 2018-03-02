using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using UltimateOrb.Collections.Generic;

namespace UltimateOrb.Linq {
    
    public readonly partial struct EmptyEnumerable<T> : IList<T, EmptyEnumerable<T>.Enumerator> {
        
        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public Enumerator GetEnumerator() {
            return default;
        }
        
        public static readonly IEnumerator<T> EnumeratorBoxed = new Enumerator();

        public long LongCount {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => 0;
        }

        public int Count {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => 0;
        }

        public bool IsReadOnly {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => true;
        }

        public T this[int index] {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [PureAttribute()]
            get => Array_Empty<T>.Value[index];

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [PureAttribute()]
            set => Array_Empty<T>.Value[index] = value;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return EnumeratorBoxed;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        IEnumerator IEnumerable.GetEnumerator() {
            return EmptyEnumerable<int>.EnumeratorBoxed;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public int IndexOf<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
            return -1;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public int IndexOf(T item) {
            return -1;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [PureAttribute()]
        public void Insert(int index, T item) {
            throw new NotSupportedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [PureAttribute()]
        public void RemoveAt(int index) {
            throw new NotSupportedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public bool Contains<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
            return false;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [PureAttribute()]
        public bool Remove<TEqualityComparer>(TEqualityComparer comparer, T item) where TEqualityComparer : IEqualityComparer<T> {
            throw new NotSupportedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [PureAttribute()]
        public void Add(T item) {
            throw new NotSupportedException();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public void Clear() {
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public bool Contains(T item) {
            return false;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public void CopyTo(T[] array, int arrayIndex) {
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public bool Remove(T item) {
            return false;
        }

        public readonly partial struct Enumerator : System.Collections.Generic.IEnumerator<T> {
            
            public T Current {

                [TargetedPatchingOptOutAttribute(null)]
                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [PureAttribute()]
                get => throw new InvalidOperationException();
            }

            object IEnumerator.Current {

                [TargetedPatchingOptOutAttribute(null)]
                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [PureAttribute()]
                get => throw new InvalidOperationException();
            }

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            public void Dispose() {
            }

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            public bool MoveNext() {
                return false;
            }

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            public void Reset() {
            }
        }
    }

    public static partial class Enumerable_Empty<T> {

        public static readonly IList<T, EmptyEnumerable<T>.Enumerator> Boxed = default(EmptyEnumerable<T>);

        public static readonly IEnumerator<T> EnumeratorBoxed = EmptyEnumerable<T>.EnumeratorBoxed;
    }

    public static partial class Enumerable_Empty {

        public static readonly IEnumerable Boxed = Enumerable_Empty<int>.Boxed;

        public static readonly IEnumerator EnumeratorBoxed = Enumerable_Empty<int>.EnumeratorBoxed;
    }  
}
