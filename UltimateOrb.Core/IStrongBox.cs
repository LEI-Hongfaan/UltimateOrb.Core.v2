namespace UltimateOrb.Core {

    public partial interface IStrongBox<T> {

        T Value {

            get;

            set;
        }
    }
}

namespace UltimateOrb.RefReturn {

    public partial interface IStrongBox<T> {

        new ref T Value {

            get;
        }
    }
}
