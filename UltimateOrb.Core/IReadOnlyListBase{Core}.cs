namespace UltimateOrb.Core.Collections.Generic {
    public interface IReadOnlyListBase<T> {

        T this[int index] {

            get;
        }

        int Count {

            get;
        }
    }
}
