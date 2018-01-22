using System;

namespace UltimateOrb {

    public partial interface IRandomNumberGenerator {

        void GetBytes(byte[] array, int offset, int count);
    }
}
