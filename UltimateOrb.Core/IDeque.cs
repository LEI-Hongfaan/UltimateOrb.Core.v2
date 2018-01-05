namespace UltimateOrb.Collections.Generic {

    public partial interface IDeque<T> {

        T RemoveFirst();

        T PeekFirst();

        void AddFirst(T item);

        bool TryAddFirst(T item);

        bool TryPeekFirst(out T item);

        bool TryRemoveFirst(out T item);
        /*
        T RemoveFirst();

        T PeekFirst();

        void AddFirst(T item);

        bool TryAddFirst(T item);

        bool TryPeekFirst(out T item);

        bool TryRemoveFirst(out T item);
        */
        bool IsEmpty {

            get;
        }
    }
}
