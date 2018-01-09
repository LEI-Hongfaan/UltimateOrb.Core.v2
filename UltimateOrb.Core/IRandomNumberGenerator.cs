using System;

namespace UltimateOrb.Core {

    public partial interface IRandomNumberGenerator {

        void GetBytes(byte[] array, int offset, int count);
    }
}
