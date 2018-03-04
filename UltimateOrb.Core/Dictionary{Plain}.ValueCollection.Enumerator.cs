using System;
using System.Collections;
using System.Collections.Generic;

namespace UltimateOrb.Plain.ValueTypes {
    using static ThrowHelper_Dictionary;

    public partial struct Dictionary<TKey, TValue, TKeyEqualityComparer> where TKeyEqualityComparer : IEqualityComparer<TKey>, new() {

        public readonly partial struct ValueCollection {

            /// <summary>Enumerates the elements of a <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</summary>
            [SerializableAttribute()]
            public struct Enumerator : IEnumerator<TValue>, IDisposable, IEnumerator {

                private readonly Dictionary<TKey, TValue, TKeyEqualityComparer> m_Dictionary;

                private int m_Index;

                private TValue m_Current;

                /// <summary>Gets the element at the current position of the enumerator.</summary>
                /// <returns>The element in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" /> at the current position of the enumerator.</returns>

                public TValue Current {

                    get {
                        return this.m_Current;
                    }
                }

                /// <summary>Gets the element at the current position of the enumerator.</summary>
                /// <returns>The element in the collection at the current position of the enumerator.</returns>
                /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>

                object IEnumerator.Current {

                    get {
                        var index = this.m_Index;
                        if (index > 0 && index <= this.m_Dictionary.m_EntryCount) {
                            goto L_1;
                        }
                        ThrowInvalidOperationException_EnumOpCantHappen();
                        L_1:
                        return this.m_Current;
                    }
                }

                internal Enumerator(Dictionary<TKey, TValue, TKeyEqualityComparer> dictionary) {
                    this.m_Dictionary = dictionary;
                    this.m_Index = 0;
                    this.m_Current = default;
                }

                /// <summary>Releases all resources used by the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection.Enumerator" />.</summary>
                public void Dispose() {
                }

                /// <summary>Advances the enumerator to the next element of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.ValueCollection" />.</summary>
                /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
                public bool MoveNext() {
                    while ((uint)this.m_Index < (uint)this.m_Dictionary.m_EntryCount) {
                        if (this.m_Dictionary.m_EntryBuffer[this.m_Index].m_Flags >= 0) {
                            this.m_Current = this.m_Dictionary.m_EntryBuffer[this.m_Index].m_Value;
                            this.m_Index++;
                            return true;
                        }
                        this.m_Index++;
                    }
                    this.m_Index = this.m_Dictionary.m_EntryCount + 1;
                    this.m_Current = default(TValue);
                    return false;
                }

                /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
                

                void IEnumerator.Reset() {
                    this.m_Index = 0;
                    this.m_Current = default(TValue);
                }
            }
        }
    }
}
