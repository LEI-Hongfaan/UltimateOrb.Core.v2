namespace UltimateOrb.RefReturnSupported {
    using Generic = UltimateOrb;

    public partial interface IStrongBox<T> : Generic.IStrongBox<T> {

        new ref T Value {

            get;
        }
    }
}
