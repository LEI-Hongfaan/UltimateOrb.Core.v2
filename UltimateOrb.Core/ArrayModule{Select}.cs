using System;
using System.Collections.Generic;

namespace UltimateOrb {
    using IntT = Int32;
    using UIntT = UInt32;

    using static UltimateOrb.Utilities.ThrowHelper;
    using static UltimateOrb.Utilities.SignConverter;

    using System.Diagnostics.Contracts;
    using System.Runtime.CompilerServices;

    public static partial class ArrayModule<T> {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static TResult[] Select<TResult, TSelector>(T[] array, TSelector selector) where TSelector : IO.IFunc<T, TResult> {
            if (null != array) {
                var count = array.Length;
                var result = new TResult[count];
                for (var i = 0; count > i; ++i) {
                    result[i] = selector.Invoke(array[i]);
                }
                return result;
            }
            return null;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [PureAttribute()]
        public static TResult[] Select<TResult, TSelector>(T[] array, int count, TSelector selector) where TSelector : IO.IFunc<T, TResult> {
            if (null != array) {
                var result = new TResult[count];
                for (var i = 0; count > i && array.Length > i; ++i) {
                    result[i] = selector.Invoke(array[i]);
                }
                return result;
            }
            return null;
        }
    }
}
