using System;
using System.Collections;
using System.Collections.Generic;

namespace UltimateOrb.Core.Tests {
    using UltimateOrb.Collections.Generic;
    using UltimateOrb.Utilities;

    public readonly partial struct Polynomial64OfInt16
        : IList<int, Polynomial64OfInt16.Enumerator>
        , IList<Int16, Polynomial64OfInt16.Enumerator>
        , IReadOnlyList<int, Polynomial64OfInt16.Enumerator>
        , IReadOnlyList<Int16, Polynomial64OfInt16.Enumerator> {

        public readonly UInt64 bits;

        internal Polynomial64OfInt16(UInt64 bits) {
            this.bits = bits;
        }

        public static Polynomial64OfInt16 Indeterminate {

            get => new Polynomial64OfInt16((UInt64)1 << 16);
        }

        public long LongCount {

            get {
                return this.Count;
            }
        }

        public int Count {

            get {
                var i = this.bits;
                if (0 == i) {
                    return 0;
                }
                i >>= 16;
                if (0 == i) {
                    return 1;
                }
                i >>= 16;
                if (0 == i) {
                    return 2;
                }
                i >>= 16;
                if (0 == i) {
                    return 3;
                }
                return 4;
            }
        }

        public bool IsReadOnly {

            get => true;
        }

        Int16 IReadOnlyList<Int16>.this[int index] {

            get {
                if (0 <= index && 64 / 16 > index) {
                    return unchecked((Int16)(checked(this.bits >> unchecked(16 * index))));
                }
                return 0;
            }
        }

        Int16 IList<Int16>.this[int index] {

            get {
                if (0 <= index && 64 / 16 > index) {
                    return unchecked((Int16)(checked(this.bits >> unchecked(16 * index))));
                }
                return 0;
            }

            set => throw new NotSupportedException(/* NotSupported_ReadOnlyCollection */);
        }

        public int this[int index] {

            get {
                if (0 <= index && 64 / 16 > index) {
                    return unchecked((Int16)(checked(this.bits >> unchecked(16 * index))));
                }
                return 0;
            }

            set => throw new NotSupportedException(/* NotSupported_ReadOnlyCollection */);
        }

        public static Polynomial64OfInt16 FromInteger(int value) {
            return new Polynomial64OfInt16((UInt64)unchecked((UInt16)checked((Int16)value)));
        }

        public static Polynomial64OfInt16 operator +(Polynomial64OfInt16 first, Polynomial64OfInt16 second) {
            var first_d0 = first.bits;
            var second_d0 = second.bits;
            checked((Int16)(unchecked((Int16)checked(first_d0 >> 16 * 0)) + unchecked((Int16)checked(second_d0 >> 16 * 0)))).Ignore();
            checked((Int16)(unchecked((Int16)checked(first_d0 >> 16 * 1)) + unchecked((Int16)checked(second_d0 >> 16 * 1)))).Ignore();
            checked((Int16)(unchecked((Int16)checked(first_d0 >> 16 * 2)) + unchecked((Int16)checked(second_d0 >> 16 * 2)))).Ignore();
            checked((Int16)(unchecked((Int16)checked(first_d0 >> 16 * 3)) + unchecked((Int16)checked(second_d0 >> 16 * 3)))).Ignore();
            return new Polynomial64OfInt16(unchecked(first_d0 + second_d0));
        }

        public static Polynomial64OfInt16 operator -(Polynomial64OfInt16 first, Polynomial64OfInt16 second) {
            var first_d0 = first.bits;
            var second_d0 = second.bits;
            checked((Int16)(unchecked((Int16)checked(first_d0 >> 16 * 0)) - unchecked((Int16)checked(second_d0 >> 16 * 0)))).Ignore();
            checked((Int16)(unchecked((Int16)checked(first_d0 >> 16 * 1)) - unchecked((Int16)checked(second_d0 >> 16 * 1)))).Ignore();
            checked((Int16)(unchecked((Int16)checked(first_d0 >> 16 * 2)) - unchecked((Int16)checked(second_d0 >> 16 * 2)))).Ignore();
            checked((Int16)(unchecked((Int16)checked(first_d0 >> 16 * 3)) - unchecked((Int16)checked(second_d0 >> 16 * 3)))).Ignore();
            return new Polynomial64OfInt16(unchecked(first_d0 - second_d0));
        }
        
        public Enumerator GetEnumerator() {
            return new Enumerator(this.bits);
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator() {
            return new Enumerator(this.bits);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return new Enumerator(this.bits);
        }

        IEnumerator<Int16> IEnumerable<Int16>.GetEnumerator() {
            return new Enumerator(this.bits);
        }

        public int IndexOf<TEqualityComparer>(TEqualityComparer comparer, int item) where TEqualityComparer : IEqualityComparer<int> {
            throw new NotImplementedException();
        }

        public int IndexOf(int item) {
            throw new NotImplementedException();
        }

        public void Insert(int index, int item) {
            throw new NotSupportedException(/* NotSupported_ReadOnlyCollection */);
        }

        public void RemoveAt(int index) {
            throw new NotSupportedException(/* NotSupported_ReadOnlyCollection */);
        }

        public bool Contains<TEqualityComparer>(TEqualityComparer comparer, int item) where TEqualityComparer : IEqualityComparer<int> {
            throw new NotImplementedException();
        }

        public bool Remove<TEqualityComparer>(TEqualityComparer comparer, int item) where TEqualityComparer : IEqualityComparer<int> {
            throw new NotSupportedException(/* NotSupported_ReadOnlyCollection */);
        }

        public void Add(int item) {
            throw new NotSupportedException(/* NotSupported_ReadOnlyCollection */);
        }

        public void Clear() {
            throw new NotSupportedException(/* NotSupported_ReadOnlyCollection */);
        }

        public bool Contains(int item) {
            throw new NotImplementedException();
        }

        public void CopyTo(int[] array, int arrayIndex) {
            throw new NotImplementedException();
        }

        public bool Remove(int item) {
            throw new NotSupportedException(/* NotSupported_ReadOnlyCollection */);
        }

        public int IndexOf<TEqualityComparer>(TEqualityComparer comparer, Int16 item) where TEqualityComparer : IEqualityComparer<Int16> {
            throw new NotImplementedException();
        }

        public int IndexOf(Int16 item) {
            throw new NotImplementedException();
        }

        public void Insert(int index, Int16 item) {
            throw new NotSupportedException(/* NotSupported_ReadOnlyCollection */);
        }

        public bool Contains<TEqualityComparer>(TEqualityComparer comparer, Int16 item) where TEqualityComparer : IEqualityComparer<Int16> {
            throw new NotImplementedException();
        }

        public bool Remove<TEqualityComparer>(TEqualityComparer comparer, Int16 item) where TEqualityComparer : IEqualityComparer<Int16> {
            throw new NotSupportedException(/* NotSupported_ReadOnlyCollection */);
        }

        public void Add(Int16 item) {
            throw new NotSupportedException(/* NotSupported_ReadOnlyCollection */);
        }

        public bool Contains(Int16 item) {
            throw new NotImplementedException();
        }

        public void CopyTo(Int16[] array, int arrayIndex) {
            throw new NotImplementedException();
        }

        public bool Remove(Int16 item) {
            throw new NotSupportedException(/* NotSupported_ReadOnlyCollection */);
        }

        public struct Enumerator : IEnumerator<int>, IEnumerator<Int16> {

            private UInt64 bits;

            private int current;

            public Enumerator(UInt64 bits) {
                this.bits = bits;
                this.current = 0;
            }

            public int Current {

                get => this.current;
            }

            object IEnumerator.Current {

                get => this.current;
            }

            Int16 IEnumerator<Int16>.Current {

                get => unchecked((Int16)this.current);
            }

            public void Dispose() {
            }

            public bool MoveNext() {
                var bits = this.bits;
                if (0 != bits) {
                    this.current = unchecked((Int16)bits);
                    this.bits = bits >> 16;
                    return true;
                }
                return false;
            }

            public void Reset() {
                throw new NotSupportedException();
            }
        }
    }
}
