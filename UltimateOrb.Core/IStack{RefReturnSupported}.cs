namespace UltimateOrb.Collections.Generic.RefReturnSupported {

    public partial interface IStack<T> : Generic.IStack<T> {

        new ref T Peek();
    }
}
