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

    public partial interface IStack_1<T> : IStack<T> {

        new void Pop();

        T PeekPop();
        
        void PopPush(T item);

        T PeekPopPush(T item);
        
        bool TryPop();

        bool TryPeekPop(out T result);

        bool TryPopPush(T item);

        bool TryPeekPopPush(T item, out T result);
    }

    public partial interface IStack_1_1<T> : IStack_1<T> {

        bool IsFinite {

            get;
        }

        int Count {

            get;
        }

        long LongCount {

            get;
        }
    }
}
