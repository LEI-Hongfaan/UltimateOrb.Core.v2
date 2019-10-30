using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Collections.Immutable.Unchecked {

    public partial struct ListIterator {

        internal static int AddOffsets(int baseOffset, int extraOffset) {
            return unchecked(baseOffset + extraOffset);
        }

        internal static int SubtractOffsets(int baseOffset, int extraOffset) {
            return unchecked(baseOffset - extraOffset);
        }
    }
}

namespace UltimateOrb.Wrapped.Collections.Immutable.Unchecked {
    using UltimateOrb.Wrapped;
    using UltimateOrb.Wrapped.Collections.Immutable;
    using static UltimateOrb.Collections.Immutable.ListIterator;

    public partial struct ListIterator<T, TList>
        : IListIterator<T, ListIterator<T, TList>>
        , IReadOnlyListIterator<T, ListIterator<T, TList>>
        where TList : Wrapped.Collections.Generic.IList<T> {

        private readonly TList @base;

        internal readonly int offset;

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ListIterator(TList @base, int offset) {
            this.@base = @base;
            this.offset = offset;
        }

        public T this[int offset] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.@base[AddOffsets(this.offset, offset)];

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this.@base[AddOffsets(this.offset, offset)] = value;
        }

        public T Current {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.@base[this.offset];

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this.@base[this.offset] = value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ListIterator<T, TList> Move(int offset) {
            return new ListIterator<T, TList>(this.@base, AddOffsets(this.offset, offset));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ListIterator<T, TList> MoveNext() {
            return this.Move(1);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ListIterator<T, TList> MovePrevious() {
            return this.Move(-1);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ListIterator<T, TList> operator +(in ListIterator<T, TList> value) {
            return value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ListIterator<T, TList> operator +(in ListIterator<T, TList> @base, int offset) {
            return @base.Move(offset);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ListIterator<T, TList> operator +(int offset, in ListIterator<T, TList> @base) {
            return @base.Move(offset);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int operator -(in ListIterator<T, TList> first, in ListIterator<T, TList> second) {
            return first.offset - second.offset;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ListIterator<T, TList> operator -(in ListIterator<T, TList> @base, int offset) {
            return new ListIterator<T, TList>(@base.@base, SubtractOffsets(@base.offset, offset));
        }
    }
}

namespace UltimateOrb.Typed_RefReturn_Wrapped.Collections.Immutable.Unchecked {
    using UltimateOrb.Typed_RefReturn_Wrapped;
    using UltimateOrb.Typed_RefReturn_Wrapped.Collections.Immutable;
    using static UltimateOrb.Collections.Immutable.ListIterator;

    public partial struct ListIterator<T, TList, TListEnumerator, TListComparer>
        : IListIterator<T, ListIterator<T, TList, TListEnumerator, TListComparer>>
        , IReadOnlyListIterator<T, ListIterator<T, TList, TListEnumerator, TListComparer>>
        where TListEnumerator : Typed_RefReturn_Wrapped_Huge.Collections.Generic.IEnumerator<T>
        where TList : Typed_RefReturn_Wrapped_Huge.Collections.Generic.IList<T, TListEnumerator>
        where TListComparer : IEqualityComparer<TList>, new() {

        private readonly TList @base;

        internal readonly int offset;

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ListIterator(TList @base, int offset) {
            this.@base = @base;
            this.offset = offset;
        }

        public ref T this[int offset] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.@base[AddOffsets(this.offset, offset)];
        }

        public ref T Current {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.@base[this.offset];
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ListIterator<T, TList, TListEnumerator, TListComparer> Move(int offset) {
            return new ListIterator<T, TList, TListEnumerator, TListComparer>(this.@base, AddOffsets(this.offset, offset));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ListIterator<T, TList, TListEnumerator, TListComparer> MoveNext() {
            return this.Move(1);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ListIterator<T, TList, TListEnumerator, TListComparer> MovePrevious() {
            return this.Move(-1);
        }

        #region Explicit Interface Implementations
        #endregion
        #region Explicit Interface Implementations (Default)
        T Core.Collections.Immutable.IIterator<T, ListIterator<T, TList, TListEnumerator, TListComparer>>.Current {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Current;

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this.Current = value;
        }

        T Core.Collections.Immutable.IReadOnlyIterator<T, ListIterator<T, TList, TListEnumerator, TListComparer>>.Current {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this.Current;
        }

        ref readonly T RefReturn.Collections.Immutable.IReadOnlyIterator<T, ListIterator<T, TList, TListEnumerator, TListComparer>>.Current {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this.Current;
        }

        ref readonly T RefReturn.Collections.Immutable.IReadOnlyListIterator<T, ListIterator<T, TList, TListEnumerator, TListComparer>>.this[int offset] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => ref this[offset];
        }

        T Core.Collections.Immutable.IReadOnlyListIterator<T, ListIterator<T, TList, TListEnumerator, TListComparer>>.this[int offset] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[offset];
        }

        T Core.Collections.Immutable.IListIterator<T, ListIterator<T, TList, TListEnumerator, TListComparer>>.this[int offset] {

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => this[offset];

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            set => this[offset] = value;
        }
        #endregion

        #region Operators
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ListIterator<T, TList, TListEnumerator, TListComparer> operator ++(in ListIterator<T, TList, TListEnumerator, TListComparer> value) {
            return value.MoveNext();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ListIterator<T, TList, TListEnumerator, TListComparer> operator --(in ListIterator<T, TList, TListEnumerator, TListComparer> value) {
            return value.MovePrevious();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ListIterator<T, TList, TListEnumerator, TListComparer> operator +(in ListIterator<T, TList, TListEnumerator, TListComparer> value) {
            return value;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ListIterator<T, TList, TListEnumerator, TListComparer> operator +(in ListIterator<T, TList, TListEnumerator, TListComparer> @base, int offset) {
            return @base.Move(offset);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ListIterator<T, TList, TListEnumerator, TListComparer> operator +(int offset, in ListIterator<T, TList, TListEnumerator, TListComparer> @base) {
            return @base.Move(offset);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int operator -(in ListIterator<T, TList, TListEnumerator, TListComparer> first, in ListIterator<T, TList, TListEnumerator, TListComparer> second) {
            return first.offset - second.offset;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static ListIterator<T, TList, TListEnumerator, TListComparer> operator -(in ListIterator<T, TList, TListEnumerator, TListComparer> @base, int offset) {
            return new ListIterator<T, TList, TListEnumerator, TListComparer>(@base.@base, SubtractOffsets(@base.offset, offset));
        }
        #endregion
    }
}
