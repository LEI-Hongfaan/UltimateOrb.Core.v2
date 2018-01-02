using UltimateOrb.Collections.Generic.RefReturnSupported;

namespace UltimateOrb.Plain.ValueTypes {

    public struct FoldingStack<T, TAccumulate, TFunc, TStack>
           : IStack<T>
           where TFunc : IO.IFunc<TAccumulate, T, TAccumulate>
           where TStack : IStack<(T Item, TAccumulate Accumulate)> {

        public TStack data;

        public TAccumulate default_accumulate;

        internal FoldingStack(TStack _, TAccumulate default_accumulate) {
            this.data = _;
            this.default_accumulate = default_accumulate;
        }

        public static FoldingStack<T, TAccumulate, TFunc, TStack> Create<TStackConstructor>(int capacity) where TStackConstructor: IO.IFunc<int, TStack> {
            return new FoldingStack<T, TAccumulate, TFunc, TStack>(default(TStackConstructor).Invoke(capacity), default);
        }

        public static FoldingStack<T, TAccumulate, TFunc, TStack> Create<TStackConstructor>() where TStackConstructor : IO.IFunc<TStack> {
            return new FoldingStack<T, TAccumulate, TFunc, TStack>(default(TStackConstructor).Invoke(), default);
        }

        public static FoldingStack<T, TAccumulate, TFunc, TStack> Create<TStackConstructor>(int capacity, TAccumulate accumulate) where TStackConstructor : IO.IFunc<int, TStack> {
            return new FoldingStack<T, TAccumulate, TFunc, TStack>(default(TStackConstructor).Invoke(capacity), accumulate);
        }

        public static FoldingStack<T, TAccumulate, TFunc, TStack> Create<TStackConstructor>(TAccumulate accumulate) where TStackConstructor : IO.IFunc<TStack> {
            return new FoldingStack<T, TAccumulate, TFunc, TStack>(default(TStackConstructor).Invoke(), accumulate);
        }

        private TAccumulate accumulate {

            get {
                var b = this.data;
                return b.IsEmpty ? this.default_accumulate : b.Peek().Accumulate;
            }
        }

        public TAccumulate Accumulate {

            get => this.accumulate;
        }

        public bool IsEmpty {
            get => this.data.IsEmpty;
        }

        public ref T Peek() {
            return ref this.data.Peek().Item;
        }

        T Collections.Generic.IStack<T>.Peek() {
            return this.data.Peek().Item;
        }

        public T Pop() {
            return this.data.Pop().Item;
        }

        public void Push(T item) {
            this.data.Push((item, default(TFunc).Invoke(this.accumulate, item)));
        }

        public bool TryPeek(out T item) {
            if (this.data.TryPeek(out var t)) {
                item = t.Item;
                return true;
            }
            item = default;
            return false;
        }

        public bool TryPop(out T item) {
            if (this.data.TryPop(out var t)) {
                item = t.Item;
                return true;
            }
            item = default;
            return false;
        }

        public bool TryPush(T item) {
            return this.data.TryPush((item, default(TFunc).Invoke(this.accumulate, item)));
        }
    }
}
