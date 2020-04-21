#nullable enable

using System;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Utilities {

    public static partial class CilVerifiable {

        #region Address Comparison
        #region Managed Pointer
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            ceq
            ret
        ")]
        public static bool Equals<T>(in T firstPtr, in T secondPtr) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            clt.un
            ret
        ")]
        public static bool LessThan<T>(in T firstPtr, in T secondPtr) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            clt
            ret
        ")]
        public static bool LessThanSigned<T>(in T firstPtr, in T secondPtr) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            cgt.un
            ldc.i4.0
            ceq
            ret
        ")]
        public static bool LessThanOrEqual<T>(in T firstPtr, in T secondPtr) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            cgt
            ldc.i4.0
            ceq
            ret
        ")]
        public static bool LessThanOrEqualSigned<T>(in T firstPtr, in T secondPtr) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            cgt.un
            ret
        ")]
        public static bool GreaterThan<T>(in T firstPtr, in T secondPtr) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            cgt
            ret
        ")]
        public static bool GreaterThanSigned<T>(in T firstPtr, in T secondPtr) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            clt.un
            ldc.i4.0
            ceq
            ret
        ")]
        public static bool GreaterThanOrEqual<T>(in T firstPtr, in T secondPtr) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            clt
            ldc.i4.0
            ceq
            ret
        ")]
        public static bool GreaterThanOrEqualSinged<T>(in T firstPtr, in T secondPtr) {
            throw null!;
        }
        #endregion

        #region Object Reference
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            ceq
            ret
        ")]
        public static bool Equals(object? firstObjRef, object? secondObjRef) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            cgt.un
            ret
        ")]
        public static bool GreaterThan(object? firstObjRef, object? secondObjRef) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.1
            ldarg.0
            cgt.un
            ret
        ")]
        public static bool LessThan(object? firstObjRef, object? secondObjRef) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            clt.un
            ldc.i4.0
            ceq
            ret
        ")]
        public static bool GreaterThanOrEqual(object? firstObjRef, object? secondObjRef) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.1
            ldarg.0
            cgt.un
            ldc.i4.0
            ceq
            ret
        ")]
        public static bool LessThanOrEqual(object? firstObjRef, object? secondObjRef) {
            throw null!;
        }
        #endregion
        #endregion

        #region IntPtr, UIntPtr
        #region Array
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            newarr !!0
            ret
        ")]
        public static T[] CreateArray<T>(IntPtr length) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldlen
            ret
        ")]
        public static IntPtr/* UIntPtr */ GetLength<T>(T[] array) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            ldelem !!0
            ret
        ")]
        public static T GetValue<T>(this T[] array, IntPtr index) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            ldelema !!0
            ret
        ")]
        public static ref T GetValueRef<T>(this T[] array, IntPtr index) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            ldarg.2
            stelem !!0
            ret
        ")]
        public static void SetValue<T>(this T[] array, IntPtr index, T value) {
            throw null!;
        }
        #endregion
        #endregion

        #region Boxing
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            unbox !!0
            ret
        ")]
        public static ref readonly T UnboxRef<T>(object box) where T : struct {
            throw null!;
        }
        #endregion

        #region Native Integer
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            clt.un
            ret
        ")]
        public static bool LessThan(UIntPtr first, UIntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            clt
            ret
        ")]
        public static bool LessThan(IntPtr first, IntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            cgt.un
            ldc.i4.0
            ceq
            ret
        ")]
        public static bool LessThanOrEqual(UIntPtr first, UIntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            cgt
            ldc.i4.0
            ceq
            ret
        ")]
        public static bool LessThanOrEqual<T>(IntPtr first, IntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            cgt.un
            ret
        ")]
        public static bool GreaterThan<T>(UIntPtr first, UIntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            cgt
            ret
        ")]
        public static bool GreaterThan<T>(IntPtr first, IntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            clt.un
            ldc.i4.0
            ceq
            ret
        ")]
        public static bool GreaterThanOrEqual<T>(UIntPtr first, UIntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            clt
            ldc.i4.0
            ceq
            ret
        ")]
        public static bool GreaterThanOrEqual(IntPtr first, IntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldc.i4.0
            conv.i
            ldarg.0
            sub.ovf
            ret
        ")]
        public static IntPtr Negate(IntPtr value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldc.i4.0
            conv.i
            ldarg.0
            sub.ovf.un
            ret
        ")]
        public static UIntPtr Negate(UIntPtr value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            add.ovf
            ret
        ")]
        public static IntPtr Add(IntPtr first, IntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            add.ovf.un
            ret
        ")]
        public static UIntPtr Add(UIntPtr first, UIntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            sub.ovf
            ret
        ")]
        public static IntPtr Subtract(IntPtr first, IntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            sub.ovf.un
            ret
        ")]
        public static UIntPtr Subtract(UIntPtr first, UIntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            mul.ovf
            ret
        ")]
        public static IntPtr Multiply(IntPtr first, IntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            mul.ovf.un
            ret
        ")]
        public static UIntPtr Multiply(UIntPtr first, UIntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            div
            ret
        ")]
        public static IntPtr Divide(IntPtr first, IntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            div.un
            ret
        ")]
        public static UIntPtr Divide(UIntPtr first, UIntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            rem
            ret
        ")]
        public static IntPtr Remainder(IntPtr first, IntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            rem.un
            ret
        ")]
        public static UIntPtr Remainder(UIntPtr first, UIntPtr second) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            shr
            ret
        ")]
        public static IntPtr ShiftRight(IntPtr value, IntPtr count) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            shr.un
            ret
        ")]
        public static UIntPtr ShiftRight(UIntPtr value, IntPtr count) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            shr
            ret
        ")]
        public static IntPtr ShiftRight(IntPtr value, int count) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            ldarg.1
            shr.un
            ret
        ")]
        public static UIntPtr ShiftRight(UIntPtr value, int count) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.ovf.i.un
            ret
        ")]
        public static IntPtr ToIntPtr(UIntPtr value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.ovf.i
            ret
        ")]
        public static IntPtr ToIntPtr(long value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.ovf.i
            ret
        ")]
        public static IntPtr ToIntPtr(int value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.ovf.i.un
            ret
        ")]
        public static IntPtr ToIntPtr(ulong value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.ovf.i.un
            ret
        ")]
        public static IntPtr ToIntPtr(uint value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.ovf.u.un
            ret
        ")]
        public static UIntPtr ToUIntPtr(UIntPtr value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.ovf.u
            ret
        ")]
        public static UIntPtr ToUIntPtr(long value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.ovf.u
            ret
        ")]
        public static UIntPtr ToUIntPtr(int value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.ovf.u.un
            ret
        ")]
        public static UIntPtr ToUIntPtr(ulong value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.ovf.u.un
            ret
        ")]
        public static UIntPtr ToUIntPtr(uint value) {
            throw null!;
        }

        [CLSCompliantAttribute(false)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.r.un
            conv.r8
            ret
        ")]
        public static Double TruncateToDouble(UIntPtr value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.r8
            ret
        ")]
        public static Double TruncateToDouble(IntPtr value) {
            throw null!;
        }

        [CLSCompliantAttribute(false)]
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.r.un
            conv.r4
            ret
        ")]
        public static Single TruncateToSingle(UIntPtr value) {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.r4
            ret
        ")]
        public static Single TruncateToSingle(IntPtr value) {
            throw null!;
        }
        #endregion

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            sizeof !!0
            ret
        ")]
        public static int SizeOf<T>() {
            throw null!;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        [ILMethodBodyAttribute(@"
            ldarg.0
            conv.r8
            dup
            ldarg.1
            conv.r8
            add
            neg
            add
            neg
            conv.r8
            ret
        ")]
        public static Double AddThenSubtractFirst(Double first, Double second) {
            throw null!;
        }
    }
    /*
    public static partial class CilVerifiable {

        [ILBodyAttribute(@"
            ldarg.0
            ldarg.1
            ceq
            ret
        ")]
        public static int Ceq<T>(in T first, in T second) {
            throw null!;
        }

        [ILBodyAttribute(@"
            ldarg.0
            ldarg.1
            cgt
            ret
        ")]
        public static int Cgt<T>(in T first, in T second) {
            throw null!;
        }

        [ILBodyAttribute(@"
            ldarg.0
            ldarg.1
            cgt.un
            ret
        ")]
        public static int Cgt_Un<T>(in T first, in T second) {
            throw null!;
        }

        [ILBodyAttribute(@"
            ldarg.0
            ldarg.1
            clt
            ret
        ")]
        public static int Clt<T>(in T first, in T second) {
            throw null!;
        }

        [ILBodyAttribute(@"
            ldarg.0
            ldarg.1
            clt.un
            ret
        ")]
        public static int Clt_Un<T>(in T first, in T second) {
            throw null!;
        }

        [ILBodyAttribute(@"
            ldarg.0
            ldarg.1
            ceq
            ret
        ")]
        public static int Ceq(object? first, object? second) {
            throw null!;
        }

        [ILBodyAttribute(@"
            ldarg.0
            ldarg.1
            cgt.un
            ret
        ")]
        public static int Cgt_Un(object? first, object? second) {
            throw null!;
        }
    }
    */
}
