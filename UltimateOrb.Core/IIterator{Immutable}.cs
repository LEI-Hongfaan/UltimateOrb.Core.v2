namespace UltimateOrb.Core.Collections.Immutable {

    public interface IIteratorBase<out TIterator>
        where TIterator : IIteratorBase<TIterator> {

        TIterator MoveNext();
    }

    public interface IBidirectionalIteratorBase<out TIterator>
        : IIteratorBase<TIterator>
        where TIterator : IBidirectionalIteratorBase<TIterator> {

        TIterator MovePrevious();
    }

    public interface IListIteratorBase<out TIterator>
        : IBidirectionalIteratorBase<TIterator>
        where TIterator : IListIteratorBase<TIterator> {

        TIterator Move(int offset);
    }
}

namespace UltimateOrb.Core.Collections.Immutable {

    public interface IIterator<T, out TIterator>
        : IIteratorBase<TIterator>
        where TIterator : IIterator<T, TIterator> {

        T Current {

            get;

            set;
        }
    }

    public interface IBidirectionalIterator<T, out TIterator>
        : IIterator<T, TIterator>
        , IBidirectionalIteratorBase<TIterator>
        where TIterator : IBidirectionalIterator<T, TIterator> {
    }

    public interface IListIterator<T, out TIterator>
        : IBidirectionalIterator<T, TIterator>
        , IListIteratorBase<TIterator>
        where TIterator : IListIterator<T, TIterator> {

        T this[int offset] {

            get;

            set;
        }
    }

    public interface IReadOnlyIterator<out T, out TIterator>
        : IIteratorBase<TIterator>
        where TIterator : IReadOnlyIterator<T, TIterator> {

        T Current {

            get;
        }
    }

    public interface IReadOnlyBidirectionalIterator<out T, out TIterator>
        : IReadOnlyIterator<T, TIterator>
        , IBidirectionalIteratorBase<TIterator>
        where TIterator : IReadOnlyBidirectionalIterator<T, TIterator> {
    }

    public interface IReadOnlyListIterator<out T, out TIterator>
        : IReadOnlyBidirectionalIterator<T, TIterator>
        , IListIteratorBase<TIterator>
        where TIterator : IReadOnlyListIterator<T, TIterator> {

        T this[int offset] {

            get;
        }
    }
}

namespace UltimateOrb.RefReturn.Collections.Immutable {

    public partial interface IIterator<T, out TIterator> {

        new ref T Current {

            get;
        }
    }

    public partial interface IReadOnlyIterator<T, out TIterator> {

        new ref readonly T Current {

            get;
        }
    }

    public partial interface IListIterator<T, out TIterator> {

        new ref T this[int offset] {

            get;
        }
    }

    public partial interface IReadOnlyListIterator<T, out TIterator> {

        new ref readonly T this[int offset] {

            get;
        }
    }
}

namespace UltimateOrb.Huge.Collections.Immutable {
    using Core.Collections.Immutable;

    public interface IListIteratorBase<out TIterator>
      : IBidirectionalIteratorBase<TIterator>
      where TIterator : IListIteratorBase<TIterator> {

        TIterator Move(long offset);
    }
}

namespace UltimateOrb.RefReturn_Huge.Collections.Immutable {

    public partial interface IListIterator<T, out TIterator> {

        ref T this[long offset] {

            get;
        }
    }

    public partial interface IReadOnlyListIterator<T, out TIterator> {

        ref readonly T this[long offset] {

            get;
        }
    }
}
