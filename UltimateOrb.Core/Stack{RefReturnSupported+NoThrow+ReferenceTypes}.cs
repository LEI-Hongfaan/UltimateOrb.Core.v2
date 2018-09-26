using System;
using UltimateOrb.Plain.ValueTypes.NoThrow;

namespace UltimateOrb.Collections.Generic.NoThrow.ReferenceTypes {

    public partial interface IStackEx<T> : Plain.ValueTypes.IStackEx<T> {
    }

    [SerializableAttribute()]
    public partial class Stack<T> : IStackEx<T> {

        private Plain.ValueTypes.NoThrow.Stack<T> m_value;

        public Stack() {
            this.m_value = new Plain.ValueTypes.NoThrow.Stack<T>(4); // default capacity
        }

        public Stack(int capacity) {
            this.m_value = new Plain.ValueTypes.NoThrow.Stack<T>(capacity);
        }

        public int Count {

            get => this.m_value.Count;
        }

        public long LongCount {

            get => this.m_value.LongCount;
        }

        public bool IsEmpty {

            get => this.m_value.IsEmpty;
        }

        public void IncreaseCapacity() {
            this.m_value.IncreaseCapacity();
        }

        public ref T Peek() {
            return ref this.m_value.Peek();
        }

        T Generic.IStack<T>.Peek() {
            // TODO: use constraned call?
            return this.m_value.Peek();
        }

        public T Pop() {
            return this.m_value.Pop();
        }

        public ref T Push() {
            return ref this.m_value.Push();
        }

        public void Push(T value) {
            this.m_value.Push(value);
        }

        public void SetCapacity(int capacity) {
            this.m_value.SetCapacity(capacity);
        }

        public bool TryPeek(out T value) {
            return this.m_value.TryPeek(out value);
        }

        public bool TryPop(out T value) {
            return this.m_value.TryPop(out value);
        }

        public bool TryPush(T value) {
            return this.m_value.TryPush(value);
        }
    }
}
