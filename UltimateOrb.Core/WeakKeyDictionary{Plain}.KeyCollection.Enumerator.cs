using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Plain.ValueTypes {
    using static ThrowHelper_Dictionary;

    public partial struct WeakKeyDictionary<TKey, TValue, TKeyEqualityComparer>
        where TKey : class
        where TKeyEqualityComparer : IEqualityComparer<TKey>, new() {

        public readonly partial struct KeyCollection {

            /// <summary>Enumerates the elements of a <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.</summary>
            [SerializableAttribute()]
            public struct Enumerator : IEnumerator<TKey> {

                public readonly Entry[] m_Entries;

                public readonly int m_EntryCount;

                public int m_Index;

                public TKey m_Current;

                /// <summary>Gets the element at the current position of the enumerator.</summary>
                /// <returns>The element in the <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.KeyCollection" /> at the current position of the enumerator.</returns>
                public TKey Current {

                    [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                    get {
                        return this.m_Current;
                    }
                }

                /// <summary>Gets the element at the current position of the enumerator.</summary>
                /// <returns>The element in the collection at the current position of the enumerator.</returns>
                /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>
                object IEnumerator.Current {

                    [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                    get {
                        var index = this.m_Index;
                        if (index > 0 && index <= this.m_EntryCount) {
                            goto L_1;
                        }
                        ThrowInvalidOperationException_EnumOpCantHappen();
                        L_1:
                        return this.m_Current;
                    }
                }

                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                public Enumerator(WeakKeyDictionary<TKey, TValue, TKeyEqualityComparer> dictionary) {
                    this.m_Entries = dictionary.m_EntryBuffer;
                    this.m_EntryCount = dictionary.m_EntryCount;
                    this.m_Index = 0;
                    this.m_Current = default;
                }

                /// <summary>Advances the enumerator to the next element of the <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.KeyCollection" />.</summary>
                /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() {
                    var entries = this.m_Entries;
                    var count = this.m_EntryCount;
                    var index = this.m_Index;
                    while (unchecked((uint)index) < unchecked((uint)count)) {
                        ref var entry = ref entries[index];
                        if (0 <= entry.m_Flags) {
                            if (entry.m_WeakKey.TryGetTarget(out var key)) {
                                this.m_Current = key;
                                unchecked {
                                    ++index;
                                }
                                this.m_Index = index;
                                return true;
                            }
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

                /// <summary>Releases all resources used by the <see cref="WeakKeyDictionary{TKey,TValue,TEqualityComparer}.Enumerator" />.</summary>
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                public void Dispose() {
                }

                /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
                [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
                public void Reset() {
                    this.m_Index = 0;
                    this.m_Current = default;
                }
            }
        }
    }
}
