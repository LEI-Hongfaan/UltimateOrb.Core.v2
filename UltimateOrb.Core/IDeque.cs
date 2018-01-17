namespace UltimateOrb.Collections.Generic {

    public partial interface IDeque<T> {

        T PopFirst();

        T PeekFirst();

        void PushFirst(T item);

        bool TryPushFirst(T item);

        bool TryPeekFirst(out T item);

        bool TryPopFirst(out T item);

        T PopLast();

        T PeekLast();

        void PushLast(T item);

        bool TryPushLast(T item);

        bool TryPeekLast(out T item);

        bool TryPopLast(out T item);

        bool IsEmpty {

            get;
        }
    }

    public partial interface IDeque_A1<T> : IDeque<T> {

        new void PopFirst();

        T PeekPopFirst();

        void PopPushFirst(T item);

        T PeekPopPushFirst(T item);

        bool TryPopFirst();

        bool TryPeekPopFirst(out T result);

        bool TryPopPushFirst(T item);

        bool TryPeekPopPushFirst(T item, out T result);

        new void PopLast();

        T PeekPopLast();

        void PopPushLast(T item);

        T PeekPopPushLast(T item);

        bool TryPopLast();

        bool TryPeekPopLast(out T result);

        bool TryPopPushLast(T item);

        bool TryPeekPopPushLast(T item, out T result);
    }

    public partial interface IDeque_A2<T> : IDeque_A1<T> {

        void PopLastPushFirst(T item);

        void PopFirstPushLast(T item);
    }

    public partial interface IDeque_B1<T> : IDeque<T> {

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

    public partial interface IDeque_2_A1_B1_1<T> : IDeque_A1<T>, IDeque_B1<T> {
    }
}
