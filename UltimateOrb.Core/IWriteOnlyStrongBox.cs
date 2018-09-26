namespace UltimateOrb.Core {

    public partial interface IWriteOnlyStrongBox<in T> {

        T Value {

            set;
        }
    }
}
