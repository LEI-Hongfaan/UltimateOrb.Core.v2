using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace UltimateOrb.Linq {
    using Local = Typed_RefReturn_Wrapped_Huge;

    public readonly partial struct EmptyEnumerable<T>
        : Local.Collections.Generic.IList<T, EmptyEnumerable<T>.Enumerator>
        , Local.Collections.Generic.IReadOnlyList<T, EmptyEnumerable<T>.Enumerator> {

        private static readonly object s_EnumeratorBoxed = new Enumerator();

        public static readonly Local.Collections.Generic.IEnumerator<T> EnumeratorBoxed = (Local.Collections.Generic.IEnumerator<T>) s_EnumeratorBoxed;

        public static readonly Local.Collections.Generic.IReadOnlyEnumerator<T> ReadOnlyEnumeratorBoxed = (Local.Collections.Generic.IReadOnlyEnumerator<T>) s_EnumeratorBoxed;

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

        public long LongCount {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            get => 0;
        }

        public T this[long index] {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [PureAttribute()]
            get => Array_Empty<T>.Value[index];

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [PureAttribute()]
            set => Array_Empty<T>.Value[index] = value;
        }

        ref T RefReturn.Collections.Generic.IList<T>.this[int index] {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [PureAttribute()]
            get => ref Array_Empty<T>.Value[index];
        }

        ref T RefReturn_Huge.Collections.Generic.IList<T>.this[long index] {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [PureAttribute()]
            get => ref Array_Empty<T>.Value[index];
        }

        ref readonly T RefReturn.Collections.Generic.IReadOnlyList<T>.this[int index] {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [PureAttribute()]
            get => ref Array_Empty<T>.Value[index];
        }

        ref readonly T RefReturn_Huge.Collections.Generic.IReadOnlyList<T>.this[long index] {

            [TargetedPatchingOptOutAttribute(null)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
            [PureAttribute()]
            get => ref Array_Empty<T>.Value[index];
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
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        public void Add(T item) {
            throw ThrowHelper.ThrowNotSupportedException_FixedSizeCollection();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        ref T RefReturn.Collections.Generic.ICollection<T>.Add(T item) {
            throw ThrowHelper.ThrowNotSupportedException_FixedSizeCollection();
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
        public bool Contains<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : System.Collections.Generic.IEqualityComparer<T> {
            return false;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return false;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        bool Typed_RefReturn_Huge.Collections.Generic.IReadOnlyCollection<T, Enumerator>.Contains<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return false;
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
        public void CopyTo(T[] array, long arrayIndex) {
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public void CopyTo(Array<T> array, int arrayIndex) {
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public void CopyTo(Array<T> array, long arrayIndex) {
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public Enumerator GetEnumerator() {
            return default;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        RefReturn.Collections.Generic.IReadOnlyEnumerator<T> RefReturn.Collections.Generic.IReadOnlyEnumerable<T>.GetEnumerator() {
            return ReadOnlyEnumeratorBoxed;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        RefReturn.Collections.Generic.IEnumerator<T> RefReturn.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return EnumeratorBoxed;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() {
            return EnumeratorBoxed;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return /*EmptyEnumerable<int>.*/EnumeratorBoxed;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public int IndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
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
        public void Insert(int index, T item) {
            throw ThrowHelper.ThrowNotSupportedException_FixedSizeCollection();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        public void Insert(long index, T item) {
            throw ThrowHelper.ThrowNotSupportedException_FixedSizeCollection();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        ref T RefReturn.Collections.Generic.IList<T>.Insert(int index, T item) {
            throw ThrowHelper.ThrowNotSupportedException_FixedSizeCollection();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        ref T RefReturn_Huge.Collections.Generic.IList<T>.Insert(long index, T item) {
            throw ThrowHelper.ThrowNotSupportedException_FixedSizeCollection();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public long LongIndexOf<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : Huge.Collections.Generic.IEqualityComparer<T> {
            return -1;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public long LongIndexOf(T item) {
            return -1;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        public bool Remove<TEqualityComparer>(T item, TEqualityComparer comparer) where TEqualityComparer : IEqualityComparer<T> {
            return false;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        bool Typed_Huge.Collections.Generic.ICollection<T, Enumerator>.Remove<TEqualityComparer>(T item, TEqualityComparer comparer) {
            return false;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public bool Remove(T item) {
            return false;
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        public void RemoveAt(int index) {
            throw ThrowHelper.ThrowNotSupportedException_FixedSizeCollection();
        }

        [TargetedPatchingOptOutAttribute(null)]
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        public void RemoveAt(long index) {
            throw ThrowHelper.ThrowNotSupportedException_FixedSizeCollection();
        }

        public readonly partial struct Enumerator
            : System.Collections.Generic.IEnumerator<T>
            , Local.Collections.Generic.IEnumerator<T>
            , Local.Collections.Generic.IReadOnlyEnumerator<T>
            , IEnumerator {

            public T Current {

                [TargetedPatchingOptOutAttribute(null)]
                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [PureAttribute()]
                get => throw new InvalidOperationException();
            }

            ref T RefReturn.Collections.Generic.IEnumerator<T>.Current {

                [TargetedPatchingOptOutAttribute(null)]
                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [PureAttribute()]
                get => throw new InvalidOperationException();
            }

            ref readonly T RefReturn.Collections.Generic.IReadOnlyEnumerator<T>.Current {

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
            [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            [PureAttribute()]
            public void Reset() {
            }
        }
    }



    public static partial class Enumerable_Empty<T> {

        public static readonly Local.Collections.Generic.IList<T, EmptyEnumerable<T>.Enumerator> Boxed = default(EmptyEnumerable<T>);

        public static readonly IEnumerator<T> EnumeratorBoxed = EmptyEnumerable<T>.EnumeratorBoxed;

    }

    public static partial class Enumerable_Empty {

        public static readonly IEnumerable Boxed = Enumerable_Empty<int>.Boxed;

        public static readonly IEnumerator EnumeratorBoxed = Enumerable_Empty<int>.EnumeratorBoxed;
    }

    internal static partial class ThrowHelper {

        public static NotSupportedException ThrowNotSupportedException_FixedSizeCollection() {
            throw new NotSupportedException();
        }

        public static NotSupportedException ThrowNotSupportedException_ReadOnlyCollection() {
            throw new NotSupportedException();
        }
    }
}
