namespace UltimateOrb.RefReturn.Collections.Generic {

    public partial interface IEnumerator<T> {

        new ref T Current {
            get;
        }
    }
}
