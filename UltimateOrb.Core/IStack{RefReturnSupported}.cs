namespace UltimateOrb.Collections.Generic.RefReturnSupported {

    public partial interface IStack<T> : Generic.IStack<T> {

        new ref T Peek();
    }

    public partial interface IStack_1<T> : Generic.IStack_1<T>, IStack<T> {
    }

    public partial interface IStack_1_1<T> : Generic.IStack_1_1<T>, IStack_1<T> {
    }
}
