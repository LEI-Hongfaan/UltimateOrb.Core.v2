namespace UltimateOrb.Collections.Generic.RefReturnSupported {

    public partial interface IDeque<T> : Generic.IDeque<T> {

        new ref T PeekFirst();

        new ref T PeekLast();
    }

    public partial interface IDeque_A1<T> : Generic.IDeque_A1<T>, IDeque<T> {
    }

    public partial interface IDeque_B1<T> : Generic.IDeque_B1<T>, IDeque<T> {
    }

    public partial interface IDeque_2_A1_B1_1<T> : Generic.IDeque_2_A1_B1_1<T>, IDeque_A1<T>, IDeque_B1<T> {
    }
}
