﻿using System;

namespace UltimateOrb.Mathematics {

    using UInt = UInt32;
    using ULong = UInt64;
    using Int = Int32;
    using Long = Int64;

    using static UltimateOrb.Utilities.SizeOfModule;
    using Math = Internal.System.Math;
    using MathEx = DoubleArithmetic;

    public static partial class DoubleArithmetic {

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        // ~100 Cyc ex
        public static ULong DivRem(ULong lowDividend, ULong highDividend, ULong lowDivisor, ULong highDivisor, out ULong lowRemainder, out ULong highRemainder, out ULong highResult) {
            unchecked {
                if (0u != highDivisor) {
                    if (0 <= (Long)highDivisor) {
                        ULong lowProduct;
                        ULong highProduct;
                        ULong lowResult;
                        ULong t;
                        {
                            var cc = 0;
                            // CountLeadingZeros
                            // ? using CountLeadingZeros is better or not? 
                            t = highDivisor;
                            for (; 0 <= (Long)t; t <<= 1) {
                                ++cc;
                            }
                            lowResult = MathEx.BigDivInternal(
                                lowDividend >> (BitSizeOf<ULong>() - cc) | (highDividend << cc),
                                highDividend >> (BitSizeOf<ULong>() - cc),
                                (lowDivisor >> (BitSizeOf<ULong>() - cc)) | t);
                        }
                        t = lowResult * highDivisor;
                        lowProduct = MathEx.BigMul(lowResult, lowDivisor, out highProduct);
                        highProduct += t;
                        if (t > highProduct || highProduct > highDividend) {
                            goto L_0001;
                        }
                        if (highDividend > highProduct || lowProduct <= lowDividend) {
                            goto L_0002;
                        }
                        L_0001:
                        --lowResult;
                        highProduct = ((lowDivisor > lowProduct) ? (highProduct - highDivisor - 1u) : (highProduct - highDivisor));
                        lowProduct -= lowDivisor;
                        L_0002:
                        highResult = 0u;
                        highRemainder = ((lowProduct > lowDividend) ? (highDividend - highProduct - 1u) : (highDividend - highProduct));
                        lowRemainder = lowDividend - lowProduct;
                        return lowResult;
                    } else {
                        highResult = 0u;
                        if (highDivisor <= highDividend && (highDivisor != highDividend || lowDivisor <= lowDividend)) {
                            lowRemainder = MathEx.SubtractUnchecked(lowDividend, highDividend, lowDivisor, highDivisor, out highRemainder);
                            return 1u;
                        } else {
                            highRemainder = highDividend;
                            lowRemainder = lowDividend;
                            return 0u;
                        }
                    }
                } else {
                    ULong t;
                    highResult = Math.DivRem(highDividend, lowDivisor, out t);
                    highRemainder = 0u;
                    return MathEx.BigDivRemInternal(lowDividend, t, lowDivisor, out lowRemainder);
                }
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        // 91.3 Cyc (special input set test6)
        public static ULong Divide(ULong lowDividend, ULong highDividend, ULong lowDivisor, ULong highDivisor, out ULong highResult) {
            unchecked {
                if (0u != highDivisor) {
                    if (0 <= (Long)highDivisor) {
                        ULong lowProduct;
                        ULong highProduct;
                        ULong lowResult;
                        ULong t;
                        {
                            var cc = 0;
                            // CountLeadingZeros
                            // ? using CountLeadingZeros is better or not? 
                            t = highDivisor;
                            for (; 0 <= (Long)t; t <<= 1) {
                                ++cc;
                            }
                            lowResult = MathEx.BigDivInternal(
                                lowDividend >> (BitSizeOf<ULong>() - cc) | (highDividend << cc),
                                highDividend >> (BitSizeOf<ULong>() - cc),
                                (lowDivisor >> (BitSizeOf<ULong>() - cc)) | t);
                        }
                        t = lowResult * highDivisor;
                        lowProduct = MathEx.BigMul(lowResult, lowDivisor, out highProduct);
                        highProduct += t;
                        if (t > highProduct || highProduct > highDividend) {
                            goto L_0001;
                        }
                        if (highDividend > highProduct || lowProduct <= lowDividend) {
                            goto L_0002;
                        }
                        L_0001:
                        --lowResult;
                        highProduct = ((lowDivisor > lowProduct) ? (highProduct - highDivisor - 1u) : (highProduct - highDivisor));
                        lowProduct -= lowDivisor;
                        L_0002:
                        highResult = 0u;
                        return lowResult;
                    } else {
                        highResult = 0u;
                        if (highDivisor <= highDividend && (highDivisor != highDividend || lowDivisor <= lowDividend)) {
                            return 1u;
                        } else {
                            return 0u;
                        }
                    }
                } else {
                    ULong t;
                    highResult = Math.DivRem(highDividend, lowDivisor, out t);
                    return MathEx.BigDivInternal(lowDividend, t, lowDivisor);
                }
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong Divide(ULong lowDividend, ULong highDividend, ULong divisor, out ULong highResult) {
            unchecked {
                ULong t;
                highResult = Math.DivRem(highDividend, divisor, out t);
                return MathEx.BigDivInternal(lowDividend, t, divisor);
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong DivideFloat(ULong lowDividend, ULong highDividend, ULong lowDivisor) {
            const ULong highDivisor = 1u;
            unchecked {
                ULong lowProduct;
                ULong highProduct;
                ULong lowResult;
                ULong t;
                {
                    var cc = BitSizeOf<ULong>() - 1;
                    t = highDivisor << cc;
                    lowResult = MathEx.BigDivInternal(
                        lowDividend >> (BitSizeOf<ULong>() - cc) | (highDividend << cc),
                        highDividend >> (BitSizeOf<ULong>() - cc),
                        (lowDivisor >> (BitSizeOf<ULong>() - cc)) | t);
                }
                t = lowResult * highDivisor;
                lowProduct = MathEx.BigMul(lowResult, lowDivisor, out highProduct);
                highProduct += t;
                if (t > highProduct || highProduct > highDividend) {
                    goto L_0001;
                }
                if (highDividend > highProduct || lowProduct <= lowDividend) {
                    goto L_0002;
                }
                L_0001:
                --lowResult;
                L_0002:
                return lowResult;
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        // 109 Cyc (special inpot set test6)
        public static ULong Remainder(ULong lowDividend, ULong highDividend, ULong lowDivisor, ULong highDivisor, out ULong highResult) {
            unchecked {
                if (0u != highDivisor) {
                    if (0 <= (Long)highDivisor) {
                        ULong lowProduct;
                        ULong highProduct;
                        ULong lowResult;
                        ULong t;
                        {
                            var cc = 0;
                            // CountLeadingZeros
                            // ? using CountLeadingZeros is better or not? 
                            t = highDivisor;
                            for (; 0 <= (Long)t; t <<= 1) {
                                ++cc;
                            }
                            lowResult = MathEx.BigDivInternal(
                                lowDividend >> (BitSizeOf<ULong>() - cc) | (highDividend << cc),
                                highDividend >> (BitSizeOf<ULong>() - cc),
                                (lowDivisor >> (BitSizeOf<ULong>() - cc)) | t);
                        }
                        t = lowResult * highDivisor;
                        lowProduct = MathEx.BigMul(lowResult, lowDivisor, out highProduct);
                        highProduct += t;
                        if (t > highProduct || highProduct > highDividend) {
                            goto L_0001;
                        }
                        if (highDividend > highProduct || lowProduct <= lowDividend) {
                            goto L_0002;
                        }
                        L_0001:
                        --lowResult;
                        highProduct = ((lowDivisor > lowProduct) ? (highProduct - highDivisor - 1u) : (highProduct - highDivisor));
                        lowProduct -= lowDivisor;
                        L_0002:
                        highResult = ((lowProduct > lowDividend) ? (highDividend - highProduct - 1u) : (highDividend - highProduct));
                        return lowDividend - lowProduct;
                    } else {
                        highResult = 0u;
                        if (highDivisor <= highDividend && (highDivisor != highDividend || lowDivisor <= lowDividend)) {
                            return MathEx.SubtractUnchecked(lowDividend, highDividend, lowDivisor, highDivisor, out highResult);
                        } else {
                            highResult = highDividend;
                            return lowDividend;
                        }
                    }
                } else {
                    highResult = 0u;
                    return MathEx.BigRemInternal(lowDividend, highDividend % lowDivisor, lowDivisor);
                }
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong Remainder(ULong lowDividend, ULong highDividend, ULong divisor) {
            unchecked {
                ULong t = highDividend % divisor;
                return MathEx.BigRemInternal(lowDividend, t, divisor);
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong DivRem(ULong lowDividend, Long highDividend, ULong lowDivisor, Long highDivisor, out ULong lowRemainder, out Long highRemainder, out Long highResult) {
            unchecked {
                Long s = highDividend, t = highDivisor;
                if (0 > highDivisor) {
                    lowDivisor = MathEx.NegateUnchecked(lowDivisor, highDivisor, out highDivisor);
                }
                if (0 > highDividend) {
                    lowDividend = MathEx.NegateUnchecked(lowDividend, highDividend, out highDividend);
                }
                ULong lowProduct;
                ULong highProduct;
                ULong lowResult;
                ULong r;
                lowResult = DivRem(lowDividend, (ULong)highDividend, lowDivisor, (ULong)highDivisor, out lowProduct, out highProduct, out r);
                if (0 > (s ^ t)) {
                    lowResult = MathEx.NegateSigned(lowResult, r, out r);
                }
                if (0 > s) {
                    lowProduct = MathEx.NegateUnchecked(lowProduct, highProduct, out highProduct);
                }
                lowRemainder = lowProduct;
                highRemainder = (Long)highProduct;
                highResult = (Long)r;
                return lowResult;
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong DivRemUnchecked(ULong lowDividend, Long highDividend, ULong lowDivisor, Long highDivisor, out ULong lowRemainder, out Long highRemainder, out Long highResult) {
            unchecked {
                Long s = highDividend, t = highDivisor;
                if (0 > highDivisor) {
                    lowDivisor = MathEx.NegateUnchecked(lowDivisor, highDivisor, out highDivisor);
                }
                if (0 > highDividend) {
                    lowDividend = MathEx.NegateUnchecked(lowDividend, highDividend, out highDividend);
                }
                ULong lowProduct;
                ULong highProduct;
                ULong lowResult;
                ULong r;
                lowResult = DivRem(lowDividend, (ULong)highDividend, lowDivisor, (ULong)highDivisor, out lowProduct, out highProduct, out r);
                if (0 > (s ^ t)) {
                    lowResult = MathEx.NegateUnchecked(lowResult, r, out r);
                }
                if (0 > s) {
                    lowProduct = MathEx.NegateUnchecked(lowProduct, highProduct, out highProduct);
                }
                lowRemainder = lowProduct;
                highRemainder = (Long)highProduct;
                highResult = (Long)r;
                return lowResult;
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong Divide(ULong lowDividend, Long highDividend, ULong lowDivisor, Long highDivisor, out Long highResult) {
            unchecked {
                Long s = highDividend, t = highDivisor;
                if (0 > highDividend) {
                    if (~(ULong)0 == lowDivisor && lowDivisor == unchecked((ULong)highDivisor) && Long.MinValue == highDividend && 0 == lowDividend) {
                        highResult = checked(-highDividend);
                        return 0;
                    }
                    lowDividend = MathEx.NegateUnchecked(lowDividend, highDividend, out highDividend);
                }
                if (0 > highDivisor) {
                    lowDivisor = MathEx.NegateUnchecked(lowDivisor, highDivisor, out highDivisor);
                }
                ULong lowResult;
                ULong r;
                lowResult = Divide(lowDividend, (ULong)highDividend, lowDivisor, (ULong)highDivisor, out r);
                if (0 > (s ^ t)) {
                    lowResult = MathEx.NegateUnchecked(lowResult, r, out r);
                }
                highResult = (Long)r;
                return lowResult;
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong DivideUnchecked(ULong lowDividend, Long highDividend, ULong lowDivisor, Long highDivisor, out Long highResult) {
            unchecked {
                Long s = highDividend, t = highDivisor;
                if (0 > highDivisor) {
                    lowDivisor = MathEx.NegateUnchecked(lowDivisor, highDivisor, out highDivisor);
                }
                if (0 > highDividend) {
                    lowDividend = MathEx.NegateUnchecked(lowDividend, highDividend, out highDividend);
                }
                ULong lowResult;
                ULong r;
                lowResult = Divide(lowDividend, (ULong)highDividend, lowDivisor, (ULong)highDivisor, out r);
                if (0 > (s ^ t)) {
                    lowResult = MathEx.NegateUnchecked(lowResult, r, out r);
                }
                highResult = (Long)r;
                return lowResult;
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        // ~ 192 Cyc (special input set test6)
        public static ULong Remainder(ULong lowDividend, Long highDividend, ULong lowDivisor, Long highDivisor, out Long highResult) {
            unchecked {
                Long s = highDividend, t = highDivisor;
                if (0 > highDivisor) {
                    lowDivisor = MathEx.NegateUnchecked(lowDivisor, highDivisor, out highDivisor);
                }
                if (0 > highDividend) {
                    lowDividend = MathEx.NegateUnchecked(lowDividend, highDividend, out highDividend);
                }
                ULong lowResult;
                ULong r;
                lowResult = Remainder(lowDividend, (ULong)highDividend, lowDivisor, (ULong)highDivisor, out r);
                if (0 > s) {
                    lowResult = MathEx.NegateUnchecked(lowResult, r, out r);
                }
                highResult = (Long)r;
                return lowResult;
            }
        }
    }
}
