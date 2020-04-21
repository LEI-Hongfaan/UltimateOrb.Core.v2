using System;
using System.Runtime.CompilerServices;
using UltimateOrb.Utilities;

namespace UltimateOrb.Functional {

    public static partial class Add {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int32 Invoke(Int32 arg1, Int32 arg2) {
            return checked(arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int64 Invoke(Int64 arg1, Int64 arg2) {
            return checked(arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt32 Invoke(UInt32 arg1, UInt32 arg2) {
            return checked(arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt64 Invoke(UInt64 arg1, UInt64 arg2) {
            return checked(arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int16 Invoke(Int16 arg1, Int16 arg2) {
            return checked((Int16)unchecked(arg1 + arg2));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt16 Invoke(UInt16 arg1, UInt16 arg2) {
            return checked((UInt16)unchecked(arg1 + arg2));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Byte Invoke(Byte arg1, Byte arg2) {
            return checked((Byte)unchecked(arg1 + arg2));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static SByte Invoke(SByte arg1, SByte arg2) {
            return checked((SByte)unchecked(arg1 + arg2));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static IntPtr Invoke(IntPtr arg1, IntPtr arg2) {
            return CilVerifiable.Add(arg1, arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UIntPtr Invoke(UIntPtr arg1, UIntPtr arg2) {
            return CilVerifiable.Add(arg1, arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int128 Invoke(Int128 arg1, Int128 arg2) {
            return Int128.Add(arg1, arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt128 Invoke(UInt128 arg1, UInt128 arg2) {
            return UInt128.Add(arg1, arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Double Invoke(Double arg1, Double arg2) {
            return (arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Single Invoke(Single arg1, Single arg2) {
            return (Single)(arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Quadruple Invoke(Quadruple arg1, Quadruple arg2) {
            return (arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static T Invoke<T>(T arg1, T arg2) {
            if (typeof(Int32) == typeof(T)) {
                return (T)(object)checked((Int32)(object)arg1 + (Int32)(object)arg2);
            }
            if (typeof(Int64) == typeof(T)) {
                return (T)(object)checked((Int64)(object)arg1 + (Int64)(object)arg2);
            }
            if (typeof(UInt32) == typeof(T)) {
                return (T)(object)checked((UInt32)(object)arg1 + (UInt32)(object)arg2);
            }
            if (typeof(UInt64) == typeof(T)) {
                return (T)(object)checked((UInt64)(object)arg1 + (UInt64)(object)arg2);
            }
            if (typeof(Int16) == typeof(T)) {
                return (T)(object)checked((Int16)unchecked((Int16)(object)arg1 + (Int16)(object)arg2));
            }
            if (typeof(UInt16) == typeof(T)) {
                return (T)(object)checked((UInt16)unchecked((UInt16)(object)arg1 + (UInt16)(object)arg2));
            }
            if (typeof(Byte) == typeof(T)) {
                return (T)(object)checked((Byte)unchecked((Byte)(object)arg1 + (Byte)(object)arg2));
            }
            if (typeof(SByte) == typeof(T)) {
                return (T)(object)checked((SByte)unchecked((SByte)(object)arg1 + (SByte)(object)arg2));
            }
            if (typeof(IntPtr) == typeof(T)) {
                return (T)(object)CilVerifiable.Add((IntPtr)(object)arg1, (IntPtr)(object)arg2);
            }
            if (typeof(UIntPtr) == typeof(T)) {
                return (T)(object)CilVerifiable.Add((UIntPtr)(object)arg1, (UIntPtr)(object)arg2);
            }
            if (typeof(Int128) == typeof(T)) {
                return (T)(object)Int128.Add((Int128)(object)arg1, (Int128)(object)arg2);
            }
            if (typeof(UInt128) == typeof(T)) {
                return (T)(object)UInt128.Add((UInt128)(object)arg1, (UInt128)(object)arg2);
            }
            if (typeof(Double) == typeof(T)) {
                return (T)(object)((Double)(object)arg1 + (Double)(object)arg2);
            }
            if (typeof(Single) == typeof(T)) {
                return (T)(object)(Single)((Single)(object)arg1 + (Single)(object)arg2);
            }
            if (typeof(Quadruple) == typeof(T)) {
                return (T)(object)((Quadruple)(object)arg1 + (Quadruple)(object)arg2);
            }
            return StandardFunctor<T>().Invoke(arg1, arg2);
        }
    }

    public partial struct AddT
        : IBinOp<Int32>
        , IBinOp<Int64>
        , IBinOp<UInt32>
        , IBinOp<UInt64>
        , IBinOp<Int16>
        , IBinOp<UInt16>
        , IBinOp<Byte>
        , IBinOp<SByte>
        , IBinOp<IntPtr>
        , IBinOp<UIntPtr>
        , IBinOp<Int128>
        , IBinOp<UInt128>
        , IBinOp<Double>
        , IBinOp<Single>
        , IBinOp<Quadruple>
    {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Int32 Invoke(Int32 arg1, Int32 arg2) {
            return checked(arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Int64 Invoke(Int64 arg1, Int64 arg2) {
            return checked(arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public UInt32 Invoke(UInt32 arg1, UInt32 arg2) {
            return checked(arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public UInt64 Invoke(UInt64 arg1, UInt64 arg2) {
            return checked(arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Int16 Invoke(Int16 arg1, Int16 arg2) {
            return checked((Int16)unchecked(arg1 + arg2));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public UInt16 Invoke(UInt16 arg1, UInt16 arg2) {
            return checked((UInt16)unchecked(arg1 + arg2));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Byte Invoke(Byte arg1, Byte arg2) {
            return checked((Byte)unchecked(arg1 + arg2));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public SByte Invoke(SByte arg1, SByte arg2) {
            return checked((SByte)unchecked(arg1 + arg2));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public IntPtr Invoke(IntPtr arg1, IntPtr arg2) {
            return CilVerifiable.Add(arg1, arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public UIntPtr Invoke(UIntPtr arg1, UIntPtr arg2) {
            return CilVerifiable.Add(arg1, arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Int128 Invoke(Int128 arg1, Int128 arg2) {
            return Int128.Add(arg1, arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public UInt128 Invoke(UInt128 arg1, UInt128 arg2) {
            return UInt128.Add(arg1, arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Double Invoke(Double arg1, Double arg2) {
            return (arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Single Invoke(Single arg1, Single arg2) {
            return (Single)(arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public Quadruple Invoke(Quadruple arg1, Quadruple arg2) {
            return (arg1 + arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T Invoke<T>(T arg1, T arg2) {
            return Add.Invoke(arg1, arg2);
        }

        public static void Register<T>(Func<T, T, T> func) {
            Add.RegisterStandardFunctor(func);
        }
    }

    public partial struct AddT<T> : IBinOp<T> {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public T Invoke(T arg1, T arg2) {
            return Add.Invoke(arg1, arg2);
        }
    }
}

namespace UltimateOrb.Functional {
    using Local = UltimateOrb.Functional;

    public static partial class Functors {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Func<T, T, T> Add<T>() {
            return Local.Add.StandardFunctor<T>();
        }
    }

    public static partial class Methods {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static T Add<T>(T first, T second) {
            return Local.Add.Invoke(first, second);
        }
    }
}
