namespace UltimateOrb.Collections.Generic {

    public partial interface IStack<T> {

        T Pop();

        T Peek();

        void Push(T item);

        bool TryPush(T item);

        bool TryPeek(out T item);

        bool TryPop(out T item);

        bool IsEmpty {

            get;
        }
    }
}
