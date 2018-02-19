namespace UltimateOrb.RefReturnSupported {
    using Generic = UltimateOrb;

    public partial interface IReadOnlyStrongBox<T> : Generic.IReadOnlyStrongBox<T> {
        
        new ref readonly T Value {

            get;
        }
    }
}
