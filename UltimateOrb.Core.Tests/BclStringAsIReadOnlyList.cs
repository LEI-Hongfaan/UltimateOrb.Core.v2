using System.Collections;
using System.Collections.Generic;

namespace UltimateOrb.Core.Tests {
    public readonly partial struct BclStringAsIReadOnlyList : UltimateOrb.Collections.Generic.IReadOnlyList<char, BclStringAsIReadOnlyList.Enumerator> {

        private readonly string str;

        public BclStringAsIReadOnlyList(string str) {
            this.str = str;
        }

        public char this[int index] {

            get => this.str[index];
        }

        public long LongCount {

            get => this.str.Length;
        }

        public int Count {

            get => checked((int)this.str.Length);
        }

        public partial struct Enumerator : IEnumerator<char> {

            private readonly string str;

            private int index;

            public Enumerator(string str) {
                this.str = str;
                this.index = -1;
            }

            public char Current {

                get => this.str[this.index];
            }

            object IEnumerator.Current {

                get => this.str[this.index];
            }

            public void Dispose() {
            }

            public bool MoveNext() {
                var i = this.index;
                unchecked {
                    ++i;
                }
                if (this.str.Length > i) {
                    this.index = i;
                    return true;
                }
                return false;
            }

            public void Reset() {
                this.index = -1;
            }
        }

        public Enumerator GetEnumerator() {
            return new Enumerator(this.str);
        }

        IEnumerator<char> IEnumerable<char>.GetEnumerator() {
            return new Enumerator(this.str);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return new Enumerator(this.str);
        }
    }
}
