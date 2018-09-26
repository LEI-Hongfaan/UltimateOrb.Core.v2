using System;

namespace UltimateOrb.Mathematics {

    using UInt = UInt32;
    using ULong = UInt64;
    using Int = Int32;
    using Long = Int64;

    using Math = Internal.System.Math;

    public static partial class DoubleArithmetic {
        
        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong BigDivRem(ULong lowDividend, ULong highDividend, ULong divisor, out ULong remainder) {
            unchecked {
                ULong p, ql, qh;
                if (0u == highDividend) {
                    return Math.DivRem(lowDividend, divisor, out remainder);
                } else if (UInt.MaxValue > divisor) {
                    // 2014Jan08
                    if (divisor <= highDividend && 0u != divisor) {
                        highDividend = checked(0u - highDividend);
                        throw (System.OverflowException)null;
                    }
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    qh = Math.DivRem(highDividend, divisor, out highDividend);
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    ql = Math.DivRem(highDividend, divisor, out remainder);
                    return (qh << Misc.UInt.BitSize) | ql;
                } else {
                    // 2013Dec24, 2014Jan08
                    if (divisor <= highDividend) {
                        highDividend = checked(0u - highDividend);
                        throw (System.OverflowException)null;
                    }
                    int c = 0;
                    if (0 <= (Long)divisor) {
                        do {
                            ++c;
                            divisor <<= 1;
                        } while (0 <= (Long)divisor);
                        highDividend = (highDividend << c) | (lowDividend >> (Misc.ULong.BitSize - c));
                        lowDividend = lowDividend << c;
                    }
                    var dh = (ULong)(UInt)(divisor >> Misc.UInt.BitSize);
                    var dl = (ULong)(UInt)divisor;
                    qh = Math.DivRem(highDividend, dh, out highDividend);
                    p = qh * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    if (highDividend < p) {
                        {
                            --qh;
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                --qh;
                                highDividend += divisor;
                            }
                        }
                    }
                    highDividend -= p;
                    ql = Math.DivRem(highDividend, dh, out highDividend);
                    p = ql * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    if (highDividend < p) {
                        {
                            --ql;
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                --ql;
                                highDividend += divisor;
                            }
                        }
                    }
                    remainder = (highDividend - p) >> c;
                    return (qh << Misc.UInt.BitSize) | ql;
                }
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong BigDivRemNoThrow(ULong lowDividend, ULong highDividend, ULong divisor, out ULong remainder) {
            unchecked {
                ULong p, ql, qh;
                if (0u == highDividend) {
                    return Math.DivRem(lowDividend, divisor, out remainder);
                } else if (UInt.MaxValue > divisor) {
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    qh = Math.DivRem(highDividend, divisor, out highDividend);
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    ql = Math.DivRem(highDividend, divisor, out remainder);
                    return (qh << Misc.UInt.BitSize) | ql;
                } else {
                    // 2013Dec24
                    int c = 0;
                    if (0 <= (Long)divisor) {
                        do {
                            ++c;
                            divisor <<= 1;
                        } while (0 <= (Long)divisor);
                        highDividend = (highDividend << c) | (lowDividend >> (Misc.ULong.BitSize - c));
                        lowDividend = lowDividend << c;
                    }
                    var dh = (ULong)(UInt)(divisor >> Misc.UInt.BitSize);
                    var dl = (ULong)(UInt)divisor;
                    qh = Math.DivRem(highDividend, dh, out highDividend);
                    p = qh * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    if (highDividend < p) {
                        {
                            --qh;
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                --qh;
                                highDividend += divisor;
                            }
                        }
                    }
                    highDividend -= p;
                    ql = Math.DivRem(highDividend, dh, out highDividend);
                    p = ql * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    if (highDividend < p) {
                        {
                            --ql;
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                --ql;
                                highDividend += divisor;
                            }
                        }
                    }
                    remainder = (highDividend - p) >> c;
                    return (qh << Misc.UInt.BitSize) | ql;
                }
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong BigDivNoThrow(ULong lowDividend, ULong highDividend, ULong divisor) {
            unchecked {
                ULong p, ql, qh;
                if (0u == highDividend) {
                    return lowDividend / divisor;
                } else if (UInt.MaxValue > divisor) {
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    qh = Math.DivRem(highDividend, divisor, out highDividend);
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    ql = highDividend / divisor;
                    return (qh << Misc.UInt.BitSize) | ql;
                } else {
                    // 2013Dec24
                    int c = 0;
                    if (0 <= (Long)divisor) {
                        do {
                            ++c;
                            divisor <<= 1;
                        } while (0 <= (Long)divisor);
                        highDividend = (highDividend << c) | (lowDividend >> (Misc.ULong.BitSize - c));
                        lowDividend = lowDividend << c;
                    }
                    var dh = (ULong)(UInt)(divisor >> Misc.UInt.BitSize);
                    var dl = (ULong)(UInt)divisor;
                    qh = Math.DivRem(highDividend, dh, out highDividend);
                    p = qh * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    if (highDividend < p) {
                        {
                            --qh;
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                --qh;
                                highDividend += divisor;
                            }
                        }
                    }
                    highDividend -= p;
                    ql = Math.DivRem(highDividend, dh, out highDividend);
                    p = ql * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    if (highDividend < p) {
                        {
                            --ql;
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                --ql;
                            }
                        }
                    }
                    return (qh << Misc.UInt.BitSize) | ql;
                }
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong BigMul(ULong first, ULong second, out ULong highResult) {
            unchecked {
                if (Misc.ULong.Size > Misc.UIntPtr.Size) {
                    // 2013Oct04, 2013Dec24
                    var fl = (UInt)first;
                    var fh = (UInt)(first >> Misc.UInt.BitSize);
                    var sl = (UInt)second;
                    var sh = (UInt)(second >> Misc.UInt.BitSize);
                    var ll = (ULong)fl * sl;
                    var lh = (ULong)fl * sh;
                    var hl = (ULong)fh * sl;
                    var hh = (ULong)fh * sh;
                    lh += (UInt)(ll >> Misc.UInt.BitSize);
                    lh += hl;
                    if (lh < hl) {
                        hh += (ULong)1u << Misc.UInt.BitSize;
                    }
                    highResult = hh + (UInt)(lh >> Misc.UInt.BitSize);
                    return ((ULong)(UInt)lh << Misc.UInt.BitSize) | (UInt)(ll);
                }
                {
                    // 2013Oct04, 2013Dec24
                    var fl = (ULong)(UInt)first;
                    var fh = (ULong)(UInt)(first >> Misc.UInt.BitSize);
                    var sl = (ULong)(UInt)second;
                    var sh = (ULong)(UInt)(second >> Misc.UInt.BitSize);
                    var ll = fl * sl;
                    var hh = fh * sh;
                    var fm = fh + fl;
                    var sm = sh + sl;
                    var mm = fm * sm - (hh + ll);
                    var mh = mm >> Misc.UInt.BitSize;
                    var ml = mm << Misc.UInt.BitSize;
                    ll += ml;
                    highResult = hh + mh + ((ll < ml) ? (ULong)1u : (ULong)0u) + ((((fm + sm) >> 1) - mh) & ((ULong)UInt.MaxValue << Misc.UInt.BitSize));
                    return ll;
                }
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong BigMul(Long first, Long second, out Long highResult) {
            ULong r;
            var q = BigMul(unchecked((ULong)first), unchecked((ULong)second), out r);
            highResult = unchecked((Long)r - (-(Long)((ULong)first >> (Misc.ULong.BitSize - 1)) & second) - (-(Long)((ULong)second >> (Misc.ULong.BitSize - 1)) & first));
            return q;
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        // primary overload
        public static ULong BigMul_A_Karatsuba(ULong first, ULong second, out ULong highResult) {
            unchecked {
                if (Misc.ULong.Size > Misc.UIntPtr.Size) {
                    // 2013Oct04
                    // 我很滿意。
                    var fl = (UInt)first;
                    var fh = (UInt)(first >> Misc.UInt.BitSize);
                    var sl = (UInt)second;
                    var sh = (UInt)(second >> Misc.UInt.BitSize);
                    var ll = (ULong)fl * sl;
                    var hh = (ULong)fh * sh;
                    var fm = (UInt)fh + fl;
                    var sm = (UInt)sh + sl;
                    var mm = (ULong)(UInt)fm * (UInt)sm - (hh + ll);
                    var mh = (UInt)(mm >> Misc.UInt.BitSize) + (((UInt)fm < fl) ? (UInt)sm : 0u) + (((UInt)sm < sl) ? (UInt)fm : 0u);
                    var fs = ((ULong)fh + fl) + ((ULong)sh + sl);
                    var ml = mm << Misc.UInt.BitSize;
                    ll += ml;
                    highResult = hh + ((ULong)mh + ((ll < ml) ? 1u : 0u)) + (((fs >> 1) - mh) & ((ULong)UInt.MaxValue << Misc.UInt.BitSize));
                    return ll;
                }
                {
                    // 2013Oct03
                    // 我很滿意。
                    var fl = (ULong)(UInt)first;
                    var fh = (ULong)(UInt)(first >> Misc.UInt.BitSize);
                    var sl = (ULong)(UInt)second;
                    var sh = (ULong)(UInt)(second >> Misc.UInt.BitSize);
                    var ll = fl * sl;
                    var hh = fh * sh;
                    var fm = fh + fl;
                    var sm = sh + sl;
                    var mm = fm * sm - (hh + ll);
                    // Bod for jitter:
                    // var mh = (ULong)(UInt)(mm >> Misc.UInt.BitSize);
                    var mh = mm >> Misc.UInt.BitSize;
                    var ml = mm << Misc.UInt.BitSize;
                    ll += ml;
                    // Bod for jitter:
                    // highResult = hh + mh + ((ll < ml) ? 1u : 0u) + ((((fm + sm) >> 1) - mh) & ((ULong)UInt.MaxValue << Misc.UInt.BitSize));
                    highResult = hh + mh + ((ll < ml) ? (ULong)1u : (ULong)0u) + ((((fm + sm) >> 1) - mh) & ((ULong)UInt.MaxValue << Misc.UInt.BitSize));
                    return ll;
                }
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        // primary overload
        public static ULong BigMul_A_Long(ULong first, ULong second, out ULong highResult) {
            unchecked {
                if (Misc.ULong.Size > Misc.UIntPtr.Size) {
                    // 2013Oct03
                    // 我很滿意。
                    var fl = (UInt)first;
                    var fh = (UInt)(first >> Misc.UInt.BitSize);
                    var sl = (UInt)second;
                    var sh = (UInt)(second >> Misc.UInt.BitSize);
                    var ll = (ULong)fl * sl;
                    var lh = (ULong)fl * sh;
                    var hl = (ULong)fh * sl;
                    var hh = (ULong)fh * sh;
                    lh += (UInt)(ll >> Misc.UInt.BitSize);
                    lh += hl;
                    if (lh < hl) {
                        hh += (ULong)1u << Misc.UInt.BitSize;
                    }
                    highResult = hh + (UInt)(lh >> Misc.UInt.BitSize);
                    // Bad for jitter:
                    // return (lh << Misc.UInt.BitSize) + (UInt)(ll);
                    return ((ULong)(UInt)lh << Misc.UInt.BitSize) | (UInt)(ll);
                }
                {
                    // 2013Oct03
                    // 我很滿意。
                    // Bad for jitter:
                    // fl = (UInt)first;
                    var fl = (ULong)(UInt)first;
                    // Bad for jitter:
                    // var fh = (ULong)(first >> Misc.UInt.BitSize);
                    var fh = (ULong)(UInt)(first >> Misc.UInt.BitSize);
                    var sl = (ULong)(UInt)second;
                    var sh = (ULong)(UInt)(second >> Misc.UInt.BitSize);
                    // Bad for jitter:
                    // var ll = (ULong)(UInt)fl * (ULong)(UInt)sl;
                    var ll = fl * sl;
                    var lh = fl * sh;
                    var hl = fh * sl;
                    var hh = fh * sh;
                    // Bad for jitter:
                    // lh += (UInt)(ll >> Misc.UInt.BitSize);
                    lh += ll >> Misc.UInt.BitSize;
                    lh += hl;
                    if (lh < hl) {
                        hh += (ULong)1u << Misc.UInt.BitSize;
                    }
                    highResult = hh + (lh >> Misc.UInt.BitSize);
                    return (lh << Misc.UInt.BitSize) + (UInt)(ll);
                }
            }
            /* // old version
            var xh = first >> Misc.UInt.BitSize;
            var yh = second >> Misc.UInt.BitSize;
            var lo = unchecked((ULong)(UInt)first * (UInt)second);
            var xl = unchecked((UInt)first * yh);
            var yl = unchecked(xh * (UInt)second);
            xl = unchecked(xl + yl);
            xh = unchecked(xh * yh);
            yh = unchecked(lo + (xl << Misc.UInt.BitSize));
            highResult = unchecked((xh + (UInt)(xl >> Misc.UInt.BitSize)) + ((lo > yh ? (ULong)1 : 0) + (yl > xl ? (ULong)1 << Misc.UInt.BitSize : 0)));
            return yh;
            */
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static UInt BigMul_M(ULong first, UInt second, out ULong lowResult) {
            var lo = unchecked((ULong)(UInt)first * (UInt)second);
            var yl = unchecked((first >> Misc.UInt.BitSize) * (UInt)second);
            var yh = unchecked(lo + (yl << Misc.UInt.BitSize));
            lowResult = yh;
            return unchecked(((UInt)(yl >> Misc.UInt.BitSize)) + ((lo > yh ? (UInt)1 : 0)));
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Long BigMulAsSigned(Long first, Long second, out Long highResult) {
            return unchecked((Long)BigMul(first, second, out highResult));
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong BigMul(ULong first_lo, ULong first_hi, ULong second_lo, ULong second_hi, out ULong result_lo_hi, out ULong result_hi_lo, out ULong result_hi_hi) {
            unchecked {
                var fl = first_lo;
                var fh = first_hi;
                var sl = second_lo;
                var sh = second_hi;
                var lll = BigMul(fl, sl, out ULong llh);
                var hhl = BigMul(fh, sh, out ULong hhh);
                var fm = unchecked(fh + fl);
                var sm = unchecked(sh + sl);
                var tl = AddUnchecked(hhl, hhh, lll, llh, out ULong th);
                var mml = BigMul(fm, sm, out ULong mmh);
                var dh = (ULong)0;
                if (fm < fl) {
                    unchecked {
                        ++dh;
                        mmh += sm;
                    }
                }
                if (sm < sl) {
                    unchecked {
                        ++dh;
                        mmh += fm;
                    }
                }
                mml = SubtractUnchecked(mml, mmh, tl, th, out mmh);
                var dl = unchecked(fm + sm);
                if (dl < fm) {
                    unchecked {
                        ++dh;
                    }
                }
                llh = unchecked(llh + mml);
                if (llh < mml) {
                    hhl = IncreaseUnchecked(hhl, hhh, out hhh);
                }
                hhl = AddUnchecked(hhl, hhh, mmh, 0, out hhh);
                dl = ShiftRightUnsigned(dl, dh, out dh);
                dl = SubtractUnchecked(dl, dh, mmh, 0, out dh);
                hhh = unchecked(hhh + dh);
                result_hi_hi = hhh;
                result_hi_lo = hhl;
                result_lo_hi = llh;
                return lll;
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong BigMul(ULong first_lo, Long first_hi, ULong second_lo, Long second_hi, out ULong result_lo_hi, out ULong result_hi_lo, out Long result_hi_hi) {
            unchecked {
                var fl = first_lo;
                var fh = unchecked((ULong)first_hi);
                var sl = second_lo;
                var sh = unchecked((ULong)second_hi);
                var lll = BigMul(fl, sl, out ULong llh);
                var hhl = BigMul(fh, sh, out ULong hhh);
                var fm = unchecked(fh + fl);
                var sm = unchecked(sh + sl);
                var tl = AddUnchecked(hhl, hhh, lll, llh, out ULong th);
                var mml = BigMul(fm, sm, out ULong mmh);
                var dh = (ULong)0;
                if (fm < fl) {
                    unchecked {
                        ++dh;
                        mmh += sm;
                    }
                }
                if (sm < sl) {
                    unchecked {
                        ++dh;
                        mmh += fm;
                    }
                }
                mml = SubtractUnchecked(mml, mmh, tl, th, out mmh);
                var dl = unchecked(fm + sm);
                if (dl < fm) {
                    unchecked {
                        ++dh;
                    }
                }
                llh = unchecked(llh + mml);
                if (llh < mml) {
                    hhl = IncreaseUnchecked(hhl, hhh, out hhh);
                }
                hhl = AddUnchecked(hhl, hhh, mmh, 0, out hhh);
                dl = ShiftRightUnsigned(dl, dh, out dh);
                dl = SubtractUnchecked(dl, dh, mmh, 0, out dh);
                hhh = unchecked(hhh + dh);
                if (0 > unchecked((Long)fh)) {
                    hhl = SubtractUnchecked(hhl, hhh, sl, sh, out hhh);
                }
                if (0 > unchecked((Long)sh)) {
                    hhl = SubtractUnchecked(hhl, hhh, fl, fh, out hhh);
                }
                result_hi_hi = unchecked((Long)hhh);
                result_hi_lo = hhl;
                result_lo_hi = llh;
                return lll;
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong BigRemNoThrow(ULong lowDividend, ULong highDividend, ULong divisor) {
            unchecked {
                ULong p;
                if (0u == highDividend) {
                    return lowDividend % divisor;
                } else if (UInt.MaxValue > divisor) {
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    highDividend %= divisor;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    return highDividend % divisor;
                } else {
                    // 2013Dec24
                    int c = 0;
                    if (0 <= (Long)divisor) {
                        do {
                            divisor <<= 1;
                            ++c;
                        } while (0 <= (Long)divisor);
                        highDividend = (highDividend << c) | (lowDividend >> (Misc.ULong.BitSize - c));
                        lowDividend = lowDividend << c;
                    }
                    var dh = (ULong)(UInt)(divisor >> Misc.UInt.BitSize);
                    var dl = (ULong)(UInt)divisor;
                    p = Math.DivRem(highDividend, dh, out highDividend) * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    if (highDividend < p) {
                        {
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                highDividend += divisor;
                            }
                        }
                    }
                    highDividend -= p;
                    p = Math.DivRem(highDividend, dh, out highDividend) * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    if (highDividend < p) {
                        {
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                highDividend += divisor;
                            }
                        }
                    }
                    return (highDividend - p) >> c;
                }
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong BigRemNoThrow(ULong dividend_lo_lo, ULong dividend_lo_hi, ULong dividend_hi_lo, ULong dividend_hi_hi, ULong divisor_lo, ULong divisor_hi, out ULong result_hi) {
            unchecked {
                if (0u == dividend_hi_lo && 0u == dividend_hi_hi) {
                    return Remainder(dividend_lo_lo, dividend_lo_hi, divisor_lo, divisor_hi, out result_hi);
                } else if (0u == divisor_hi && ULong.MaxValue > divisor_lo) {
                    result_hi = 0;
                    return Remainder(dividend_lo_lo, Remainder(dividend_lo_hi, dividend_hi_lo, divisor_lo), divisor_lo);
                } else {
                    // 2017Nov01
                    var dividend_lo_lo_ = dividend_lo_lo;
                    var dividend_lo_hi_ = dividend_lo_hi;
                    var dividend_hi_lo_ = dividend_hi_lo;
                    var dividend_hi_hi_ = dividend_hi_hi;
                    var divisor_lo_ = divisor_lo;
                    var divisor_hi_ = divisor_hi;
                    var c = 0;
                    if (0 <= (Long)divisor_hi_) {
                        do {
                            divisor_lo_ = ShiftLeft(divisor_lo_, divisor_hi_, out divisor_hi_);
                            ++c;
                        } while (0 <= (Long)divisor_hi_);
                        dividend_hi_hi_ = ShiftLeft(dividend_hi_lo_, dividend_hi_hi_, c);
                        dividend_hi_lo_ = ShiftLeft(dividend_lo_hi_, dividend_hi_lo_, c);
                        dividend_lo_lo_ = ShiftLeft(dividend_lo_lo_, dividend_lo_hi_, c, out dividend_lo_hi_);
                    }
                    ULong p_lo;
                    ULong p_hi;
                    if (dividend_hi_hi_ < divisor_hi_) {
                        p_lo = BigMul(BigDivRemPartialInternal(dividend_hi_lo_, dividend_hi_hi_, divisor_hi_, out dividend_hi_lo_), divisor_lo_, out p_hi);
                    } else {
                        p_lo = BigMul(Math.DivRem(dividend_hi_lo_, divisor_hi_, out dividend_hi_lo_), divisor_lo_, out p_hi);
                        p_hi += divisor_lo_;
                    }
                    /*
                    p_lo = BigMul(DivRem(dividend_hi_lo_, dividend_hi_hi_, divisor_hi_, 0, out dividend_hi_lo_, out var ignored0, out var q_hi), divisor_lo_, out p_hi);
                    if (1 == q_hi) {
                        p_hi += divisor_lo_;
                    }
                    */
                    if (LessThan(dividend_lo_hi_, dividend_hi_lo_, p_lo, p_hi)) {
                        {
                            dividend_lo_hi_ = AddUnchecked(dividend_lo_hi_, dividend_hi_lo_, divisor_lo_, divisor_hi_, out dividend_hi_lo_);
                        }
                        if (GreaterThanOrEqual(dividend_lo_hi_, dividend_hi_lo_, divisor_lo_, divisor_hi_)) {
                            if (LessThan(dividend_lo_hi_, dividend_hi_lo_, p_lo, p_hi)) {
                                dividend_lo_hi_ = AddUnchecked(dividend_lo_hi_, dividend_hi_lo_, divisor_lo_, divisor_hi_, out dividend_hi_lo_);
                            }
                        }
                    }
                    dividend_lo_hi_ = SubtractUnchecked(dividend_lo_hi_, dividend_hi_lo_, p_lo, p_hi, out dividend_hi_lo_);
                    if (dividend_hi_lo_ < divisor_hi_) {
                        p_lo = BigMul(BigDivRemPartialInternal(dividend_lo_hi_, dividend_hi_lo_, divisor_hi_, out dividend_lo_hi_), divisor_lo_, out p_hi);
                    } else {
                        p_lo = BigMul(Math.DivRem(dividend_lo_hi_, divisor_hi_, out dividend_lo_hi_), divisor_lo_, out p_hi);
                        p_hi += divisor_lo_;
                    }
                    /*
                    p_lo = BigMul(DivRem(dividend_lo_hi_, dividend_hi_lo_, divisor_hi_, 0, out dividend_lo_hi_, out var ignored1, out var q_lo), divisor_lo_, out p_hi);
                    if (1 == q_lo) {
                        p_hi += divisor_lo_;
                    }
                    */
                    if (LessThan(dividend_lo_lo_, dividend_lo_hi_, p_lo, p_hi)) {
                        {
                            dividend_lo_lo_ = AddUnchecked(dividend_lo_lo_, dividend_lo_hi_, divisor_lo_, divisor_hi_, out dividend_lo_hi_);
                        }
                        if (GreaterThanOrEqual(dividend_lo_lo_, dividend_lo_hi_, divisor_lo_, divisor_hi_)) {
                            if (LessThan(dividend_lo_lo_, dividend_lo_hi_, p_lo, p_hi)) {
                                dividend_lo_lo_ = AddUnchecked(dividend_lo_lo_, dividend_lo_hi_, divisor_lo_, divisor_hi_, out dividend_lo_hi_);
                            }
                        }
                    }
                    dividend_lo_lo_ = SubtractUnchecked(dividend_lo_lo_, dividend_lo_hi_, p_lo, p_hi, out dividend_lo_hi_);
                    return ShiftRightUnsigned(dividend_lo_lo_, dividend_lo_hi_, c, out result_hi);
                }
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong BigSquare(ULong value, out ULong highResult) {
            unchecked {
                if (Misc.ULong.Size > Misc.UIntPtr.Size) {
                    // 2013Oct04
                    var fl = (UInt)value;
                    var fh = (UInt)(value >> Misc.UInt.BitSize);
                    var ll = (ULong)fl * fl;
                    var lh = (ULong)fl * fh;
                    var hl = lh;
                    var hh = (ULong)fh * fh;
                    lh += (UInt)(ll >> Misc.UInt.BitSize);
                    lh += hl;
                    if (lh < hl) {
                        hh += (ULong)1u << Misc.UInt.BitSize;
                    }
                    highResult = hh + (UInt)(lh >> Misc.UInt.BitSize);
                    return ((ULong)(UInt)lh << Misc.UInt.BitSize) | (UInt)(ll);
                }
                {
                    // 2013Oct04
                    var fl = (ULong)(UInt)value;
                    var fh = (ULong)(UInt)(value >> Misc.UInt.BitSize);
                    var ll = fl * fl;
                    var lh = fl * fh;
                    var hl = lh;
                    var hh = fh * fh;
                    lh += ll >> Misc.UInt.BitSize;
                    lh += hl;
                    if (lh < hl) {
                        hh += (ULong)1u << Misc.UInt.BitSize;
                    }
                    highResult = hh + (lh >> Misc.UInt.BitSize);
                    return (lh << Misc.UInt.BitSize) + (UInt)(ll);
                }
            }
        }

        [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ULong BigSquare(ULong value_lo, ULong value_hi, out ULong result_lo_hi, out ULong result_hi_lo, out ULong result_hi_hi) {
            unchecked {
                {
                    // 2017Nov18
                    var fl = value_lo;
                    var fh = value_hi;
                    var lll = BigMul(fl, fl, out ULong llh);
                    var lhl = BigMul(fl, fh, out ULong lhh);
                    var hll = lhl;
                    var hlh = lhh;
                    var hhl = BigMul(fh, fh, out ULong hhh);
                    lhl = AddUnchecked(lhl, lhh, llh, 0, out lhh);
                    lhl = AddUnchecked(lhl, lhh, hll, hlh, out lhh);
                    if (LessThan(lhl, lhh, hll, hlh)) {
                        unchecked {
                            ++hhh;
                        }
                    }
                    result_hi_lo = AddUnchecked(hhl, hhh, lhh, 0, out result_hi_hi);
                    result_lo_hi = lhl;
                    return lll;
                }
            }
        }

        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        internal static ULong BigDivRemInternal(ULong lowDividend, ULong highDividend, ULong divisor, out ULong remainder) {
            unchecked {
                ULong p, ql, qh;
                if (0u == highDividend) {
                    return Math.DivRem(lowDividend, divisor, out remainder);
                } else if (UInt.MaxValue > divisor) {
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    qh = Math.DivRem(highDividend, divisor, out highDividend);
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    ql = Math.DivRem(highDividend, divisor, out remainder);
                    return (qh << Misc.UInt.BitSize) | ql;
                } else {
                    // 2013Dec24
                    int c = 0;
                    if (0 <= (Long)divisor) {
                        do {
                            divisor <<= 1;
                            ++c;
                        } while (0 <= (Long)divisor);
                        highDividend = (highDividend << c) | (lowDividend >> (Misc.ULong.BitSize - c));
                        lowDividend = lowDividend << c;
                    }
                    var dh = (ULong)(UInt)(divisor >> Misc.UInt.BitSize);
                    var dl = (ULong)(UInt)divisor;
                    qh = Math.DivRem(highDividend, dh, out highDividend);
                    p = qh * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    if (highDividend < p) {
                        {
                            --qh;
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                --qh;
                                highDividend += divisor;
                            }
                        }
                    }
                    highDividend -= p;
                    ql = Math.DivRem(highDividend, dh, out highDividend);
                    p = ql * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    if (highDividend < p) {
                        {
                            --ql;
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                --ql;
                                highDividend += divisor;
                            }
                        }
                    }
                    remainder = (highDividend - p) >> c;
                    return (qh << Misc.UInt.BitSize) | ql;
                }
            }
        }

        // [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        internal static ULong BigRemInternal(ULong lowDividend, ULong highDividend, ULong divisor) {
            // 2014Sep19
            unchecked {
                ULong p, ql, qh;
                if (0u == highDividend) {
                    return lowDividend % divisor;
                } else if (UInt.MaxValue > divisor) {
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    highDividend = highDividend % divisor;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    return highDividend % divisor;
                } else {
                    // 2013Dec24
                    int c = 0;
                    if (0 <= (Long)divisor) {
                        do {
                            divisor <<= 1;
                            ++c;
                        } while (0 <= (Long)divisor);
                        highDividend = (highDividend << c) | (lowDividend >> (Misc.ULong.BitSize - c));
                        lowDividend = lowDividend << c;
                    }
                    var dh = (ULong)(UInt)(divisor >> Misc.UInt.BitSize);
                    var dl = (ULong)(UInt)divisor;
                    qh = Math.DivRem(highDividend, dh, out highDividend);
                    p = qh * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    if (highDividend < p) {
                        {
                            --qh;
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                --qh;
                                highDividend += divisor;
                            }
                        }
                    }
                    highDividend -= p;
                    ql = Math.DivRem(highDividend, dh, out highDividend);
                    p = ql * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    if (highDividend < p) {
                        {
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                highDividend += divisor;
                            }
                        }
                    }
                    return (highDividend - p) >> c;
                }
            }
        }

        // [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        internal static ULong BigDivInternal(ULong lowDividend, ULong highDividend, ULong divisor) {
            // 2014Sep13
            unchecked {
                ULong p, ql, qh;
                if (0u == highDividend) {
                    return lowDividend / divisor;
                } else if (UInt.MaxValue > divisor) {
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    qh = Math.DivRem(highDividend, divisor, out highDividend);
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    ql = highDividend / divisor;
                    return (qh << Misc.UInt.BitSize) | ql;
                } else {
                    // 2013Dec24
                    int c = 0;
                    if (0 <= (Long)divisor) {
                        do {
                            divisor <<= 1;
                            ++c;
                        } while (0 <= (Long)divisor);
                        highDividend = (highDividend << c) | (lowDividend >> (Misc.ULong.BitSize - c));
                        lowDividend = lowDividend << c;
                    }
                    var dh = (ULong)(UInt)(divisor >> Misc.UInt.BitSize);
                    var dl = (ULong)(UInt)divisor;
                    qh = Math.DivRem(highDividend, dh, out highDividend);
                    p = qh * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                    if (highDividend < p) {
                        {
                            --qh;
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                --qh;
                                highDividend += divisor;
                            }
                        }
                    }
                    highDividend -= p;
                    ql = Math.DivRem(highDividend, dh, out highDividend);
                    p = ql * dl;
                    highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                    if (highDividend < p) {
                        {
                            --ql;
                            highDividend += divisor;
                        }
                        if (highDividend >= divisor) {
                            if (highDividend < p) {
                                --ql;
                                // highDividend += divisor;
                            }
                        }
                    }
                    // remainder = (highDividend - p) >> c;
                    return (qh << Misc.UInt.BitSize) | ql;
                }
            }
        }

        // [System.CLSCompliantAttribute(false)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        internal static ULong BigDivRemPartialInternal(ULong lowDividend, ULong highDividend, ULong divisor, out ULong remainder) {
            unchecked {
                var dh = (ULong)(UInt)(divisor >> Misc.UInt.BitSize);
                var dl = (ULong)(UInt)divisor;
                var qh = Math.DivRem(highDividend, dh, out highDividend);
                var p = qh * dl;
                highDividend = (highDividend << Misc.UInt.BitSize) | (lowDividend >> Misc.UInt.BitSize);
                if (highDividend < p) {
                    {
                        --qh;
                        highDividend += divisor;
                    }
                    if (highDividend >= divisor) {
                        if (highDividend < p) {
                            --qh;
                            highDividend += divisor;
                        }
                    }
                }
                highDividend -= p;
                var ql = Math.DivRem(highDividend, dh, out highDividend);
                p = ql * dl;
                highDividend = (highDividend << Misc.UInt.BitSize) | (UInt)lowDividend;
                if (highDividend < p) {
                    {
                        --ql;
                        highDividend += divisor;
                    }
                    if (highDividend >= divisor) {
                        if (highDividend < p) {
                            --ql;
                            highDividend += divisor;
                        }
                    }
                }
                remainder = highDividend - p;
                return (qh << Misc.UInt.BitSize) | ql;
            }
        }
    }
}
