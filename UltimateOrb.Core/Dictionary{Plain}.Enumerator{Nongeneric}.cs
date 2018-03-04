using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Plain.ValueTypes {
    using static ThrowHelper_Dictionary;

    public partial struct Dictionary<TKey, TValue, TKeyEqualityComparer> where TKeyEqualityComparer : IEqualityComparer<TKey>, new() {

        /// <summary>Enumerates the elements of a <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
        [SerializableAttribute()]
        public struct Enumerator_A : IEnumerator<KeyValuePair<TKey, TValue>>, IDictionaryEnumerator {

            private readonly Entry[] m_Entries;

            private readonly int m_Count;

            private int m_Index;

            private KeyValuePair<TKey, TValue> m_Current;

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" /> at the current position of the enumerator.</returns>
            public KeyValuePair<TKey, TValue> Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    return this.m_Current;
                }
            }

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the collection at the current position of the enumerator, as an <see cref="object" />.</returns>
            /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>
            object IEnumerator.Current {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    var index = this.m_Index;
                    if (index > 0 && index <= this.m_Count) {
                        goto L_1;
                    }
                    ThrowInvalidOperationException_EnumOpCantHappen();
                    L_1:
                    return new DictionaryEntry(this.m_Current.Key, this.m_Current.Value);
                }
            }

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the dictionary at the current position of the enumerator, as a <see cref="DictionaryEntry" />.</returns>
            /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>
            DictionaryEntry IDictionaryEnumerator.Entry {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    var index = this.m_Index;
                    if (index > 0 && index <= this.m_Count) {
                        goto L_1;
                    }
                    ThrowInvalidOperationException_EnumOpCantHappen();
                    L_1:
                    return new DictionaryEntry(this.m_Current.Key, this.m_Current.Value);
                }
            }

            /// <summary>Gets the key of the element at the current position of the enumerator.</summary>
            /// <returns>The key of the element in the dictionary at the current position of the enumerator.</returns>
            /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>
            object IDictionaryEnumerator.Key {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    var index = this.m_Index;
                    if (index > 0 && index <= this.m_Count) {
                        goto L_1;
                    }
                    ThrowInvalidOperationException_EnumOpCantHappen();
                    L_1:
                    return this.m_Current.Key;
                }
            }

            /// <summary>Gets the value of the element at the current position of the enumerator.</summary>
            /// <returns>The value of the element in the dictionary at the current position of the enumerator.</returns>
            /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>
            object IDictionaryEnumerator.Value {

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                get {
                    var index = this.m_Index;
                    if (index > 0 && index <= this.m_Count) {
                        goto L_1;
                    }
                    ThrowInvalidOperationException_EnumOpCantHappen();
                    L_1:
                    return this.m_Current.Value;
                }
            }

            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public Enumerator_A(Dictionary<TKey, TValue, TKeyEqualityComparer> dictionary, int getEnumeratorRetType) {
                this.m_Entries = dictionary.m_EntryBuffer;
                this.m_Count = dictionary.m_EntryCount;
                this.m_Index = 0;
                this.m_Current = default;
            }

            /// <summary>Advances the enumerator to the next element of the <see cref="Dictionary{TKey,TValue,TEqualityComparer}" />.</summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() {
                var entries = this.m_Entries;
                var count = this.m_Count;
                var index = this.m_Index;
                while (unchecked((uint)index) < unchecked((uint)count)) {
                    ref var entry = ref entries[index];
                    if (0 <= entry.m_Flags) {
                        this.m_Current = new KeyValuePair<TKey, TValue>(entry.m_Key, entry.m_Value);
                        unchecked {
                            ++index;
                        }
                        this.m_Index = index;
                        return true;
                    }
                    unchecked {
                        ++index;
                    }
                }
                unchecked {
                    ++count;
                }
                this.m_Index = count;
                this.m_Current = default; // Good for GC.
                return false;
            }

            /// <summary>Releases all resources used by the <see cref="Dictionary{TKey,TValue,TEqualityComparer}.Enumerator" />.</summary>
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            public void Dispose() {
            }

            /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
            [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
            void IEnumerator.Reset() {
                this.m_Current = default;
            }
        }
    }
}
