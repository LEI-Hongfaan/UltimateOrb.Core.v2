using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Collections.ObjectModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Collections.Generic.RefReturnSupported {
    using UltimateOrb;

    using System.Collections;
    using Internal.System;
    using Internal.System.Collections.Generic;
    using static List_ThrowHelper;

    [DebuggerDisplayAttribute("Count = {Count}")]
    [SerializableAttribute()]
    public partial struct List : IList<Void, List.Enumerator>, IReadOnlyList<Void, List.Enumerator> {

        private static readonly Void[] array_empty = new Void[0];

        private static Void @void;

        [ContractPublicPropertyNameAttribute("Count")]
        private int count;

        internal const int default_capacity = 4;

        public int Count {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return checked((int)this.count);
            }
        }

        public long LongCount {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get {
                return this.count;
            }
        }

        public bool IsReadOnly {

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            get => false;
        }

        Void IList<Void>.this[int index] {

            get {
                return @void;
            }

            set => throw new NotImplementedException();
        }

        Void IReadOnlyList<Void>.this[int index] {

            get => throw new NotImplementedException();
        }

        public ref Void this[int index] {

            get => throw new NotImplementedException();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref Void Insert(int index, Void item) {
            this.count = checked(1 + this.count);
            return ref @void;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf<TEqualityComparer>(TEqualityComparer comparer, Void item) where TEqualityComparer : IEqualityComparer<Void> {
            if (this.count > 0) {
                return 0;
            }
            return -1;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(Void item) {
            if (this.count > 0) {
                return 0;
            }
            return -1;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void IList<Void>.Insert(int index, Void item) {
            var count = this.count;
            if (List_CompilationOptions.Checking) {
                if (unchecked((uint)index) > unchecked((uint)count)) {
                    throw CheckIteratorIndex_ArgumentOutOfRangeException();
                }
            }
            this.count = checked(1 + count);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void RemoveAt(int index) {
            Contract.Requires(0 <= index);
            Contract.Requires(this.count > index);
            var count = this.count;
            if (List_CompilationOptions.Checking) {
                if (unchecked((uint)count) <= unchecked((uint)index)) {
                    throw CheckIndex_ArgumentOutOfRangeException();
                }
            }
            count = unchecked(count - 1);
            this.count = count;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public ref Void Add(Void item) {
            this.count = checked(1 + this.count);
            return ref @void;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains<TEqualityComparer>(TEqualityComparer comparer, Void item) where TEqualityComparer : IEqualityComparer<Void> {
            return this.count > 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove<TEqualityComparer>(TEqualityComparer comparer, Void item) where TEqualityComparer : IEqualityComparer<Void> {
            var count = this.count;
            if (count > 0) {
                this.count = unchecked(count - 1);
                return true;
            }
            return false;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        void ICollection<Void>.Add(Void item) {
            this.count = checked(1 + this.count);
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void Clear() {
            this.count = 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Contains(Void item) {
            return this.count > 0;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(Void[] array, int start) {
            if (List_CompilationOptions.Checking) {
                if (null == array) {
                    throw new ArgumentNullException(nameof(array));
                }
                var end = array.Length;
                if (end - this.count < start) {
                    throw new NotImplementedException();
                }
            }
            throw new NotImplementedException();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public bool Remove(Void item) {
            var count = this.count;
            if (count > 0) {
                this.count = unchecked(count - 1);
                return true;
            }
            return false;
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() {
            return new Enumerator();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        System.Collections.Generic.IEnumerator<Void> IEnumerable<Void>.GetEnumerator() {
            return new Enumerator();
        }

        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        IEnumerator IEnumerable.GetEnumerator() {
            return new Enumerator();
        }

        [SerializableAttribute()]
        public partial struct Enumerator : IEnumerator<Void> {

            private List list;

            private int index;

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(List list) {
                this.list = list;
                this.index = -1;
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Dispose() {
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() {
                var list = this.list;
                var index = this.index;
                if (list.count > unchecked(++index)) {
                    this.index = index;
                    return true;
                }
                return false;
            }

            public Void Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return default(Void);
                }
            }

            ref Void IEnumerator<Void>.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return ref @void;
                }
            }

            private static object void_boxed = default(Void);

            object System.Collections.IEnumerator.Current {

                [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    if (List_CompilationOptions.Checking) {
                        if (unchecked((uint)this.list.count) <= unchecked((uint)this.index)) {
                            throw new InvalidOperationException();
                        }
                    }
                    return void_boxed;
                }
            }

            [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.Success)]
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            void System.Collections.IEnumerator.Reset() {
                this.index = -1;
            }
        }
    }
}
