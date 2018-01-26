using System;

namespace UltimateOrb {

    public partial interface IRandomNumberGenerator {

        Int32 GetNextInt32(Int32 maxExclusive);

        void GetBytes(byte[] array, int offset, int count);
    }
}
