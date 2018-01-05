using UltimateOrb.Plain.ValueTypes.NoThrow;

namespace UltimateOrb.Collections.Generic.RefReturnSupported.NoThrow.ReferenceTypes {

    public partial interface IStackEx<T> : Plain.ValueTypes.IStackEx<T> {
    }

    public partial class Stack<T> : IStackEx<T> {

        private Plain.ValueTypes.NoThrow.Stack<T> value;

        public Stack() {
            this.value = new Plain.ValueTypes.NoThrow.Stack<T>(4); // default capacity
        }

        public Stack(int capacity) {
            this.value = new Plain.ValueTypes.NoThrow.Stack<T>(capacity);
        }

        public int Count {

            get => this.value.Count;
        }

        public long LongCount {

            get => this.value.LongCount;
        }

        public bool IsEmpty {

            get => this.value.IsEmpty;
        }

        public void IncreaseCapacity() {
            this.value.IncreaseCapacity();
        }

        public ref T Peek() {
            return ref this.value.Peek();
        }

        T Generic.IStack<T>.Peek() {
            // TODO: use constraned call?
            return this.value.Peek();
        }

        public T Pop() {
            return this.value.Pop();
        }

        public ref T Push() {
            return ref this.value.Push();
        }

        public void Push(T value) {
            this.value.Push(value);
        }

        public void SetCapacity(int capacity) {
            this.value.SetCapacity(capacity);
        }

        public bool TryPeek(out T value) {
            return this.value.TryPeek(out value);
        }

        public bool TryPop(out T value) {
            return this.value.TryPop(out value);
        }

        public bool TryPush(T value) {
            return this.value.TryPush(value);
        }
    }
}
