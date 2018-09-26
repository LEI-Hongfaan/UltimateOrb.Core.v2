namespace UltimateOrb.RefReturn.Collections.Generic {

    public partial interface IReadOnlyEnumerator<T> {

        new ref readonly T Current {
            get;
        }
    }
}
