namespace UltimateOrb.Core {

    public partial interface IReadOnlyStrongBox<out T> {

        T Value {

            get;
        }
    }
}

namespace UltimateOrb.RefReturn {

    public partial interface IReadOnlyStrongBox<T> {

        new ref readonly T Value {

            get;
        }
    }
}
