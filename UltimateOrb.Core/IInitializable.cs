﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UltimateOrb {

	public partial interface IInitializable {

        void Initialize();
	
        bool TryInitialize();
	}
	
	public static partial class TInitializable {
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Initialize<TInitializable>(ref TInitializable @this) where TInitializable : struct, IInitializable {
			@this.Initialize();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool TryInitialize<TInitializable>(ref TInitializable @this) where TInitializable : struct, IInitializable {
			return @this.TryInitialize();
        }
	}

	public partial interface IInitializable<in T> {

        void Initialize(T arg);
	
        bool TryInitialize(T arg);
	}
	
	public static partial class TInitializable<T> {
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Initialize<TInitializable>(ref TInitializable @this, T arg) where TInitializable : struct, IInitializable<T> {
			@this.Initialize(arg);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool TryInitialize<TInitializable>(ref TInitializable @this, T arg) where TInitializable : struct, IInitializable<T> {
			return @this.TryInitialize(arg);
        }
	}

	public partial interface IInitializable<in T1, in T2> {

        void Initialize(T1 arg1, T2 arg2);
	
        bool TryInitialize(T1 arg1, T2 arg2);
	}
	
	public static partial class TInitializable<T1, T2> {
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Initialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2) where TInitializable : struct, IInitializable<T1, T2> {
			@this.Initialize(arg1, arg2);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool TryInitialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2) where TInitializable : struct, IInitializable<T1, T2> {
			return @this.TryInitialize(arg1, arg2);
        }
	}

	public partial interface IInitializable<in T1, in T2, in T3> {

        void Initialize(T1 arg1, T2 arg2, T3 arg3);
	
        bool TryInitialize(T1 arg1, T2 arg2, T3 arg3);
	}
	
	public static partial class TInitializable<T1, T2, T3> {
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Initialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2, T3 arg3) where TInitializable : struct, IInitializable<T1, T2, T3> {
			@this.Initialize(arg1, arg2, arg3);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool TryInitialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2, T3 arg3) where TInitializable : struct, IInitializable<T1, T2, T3> {
			return @this.TryInitialize(arg1, arg2, arg3);
        }
	}

	public partial interface IInitializable<in T1, in T2, in T3, in T4> {

        void Initialize(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
	
        bool TryInitialize(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
	}
	
	public static partial class TInitializable<T1, T2, T3, T4> {
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Initialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TInitializable : struct, IInitializable<T1, T2, T3, T4> {
			@this.Initialize(arg1, arg2, arg3, arg4);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool TryInitialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TInitializable : struct, IInitializable<T1, T2, T3, T4> {
			return @this.TryInitialize(arg1, arg2, arg3, arg4);
        }
	}

	public partial interface IInitializable<in T1, in T2, in T3, in T4, in T5> {

        void Initialize(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
	
        bool TryInitialize(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
	}
	
	public static partial class TInitializable<T1, T2, T3, T4, T5> {
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Initialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TInitializable : struct, IInitializable<T1, T2, T3, T4, T5> {
			@this.Initialize(arg1, arg2, arg3, arg4, arg5);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool TryInitialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TInitializable : struct, IInitializable<T1, T2, T3, T4, T5> {
			return @this.TryInitialize(arg1, arg2, arg3, arg4, arg5);
        }
	}

	public partial interface IInitializable<in T1, in T2, in T3, in T4, in T5, in T6> {

        void Initialize(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
	
        bool TryInitialize(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
	}
	
	public static partial class TInitializable<T1, T2, T3, T4, T5, T6> {
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Initialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TInitializable : struct, IInitializable<T1, T2, T3, T4, T5, T6> {
			@this.Initialize(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool TryInitialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TInitializable : struct, IInitializable<T1, T2, T3, T4, T5, T6> {
			return @this.TryInitialize(arg1, arg2, arg3, arg4, arg5, arg6);
        }
	}

	public partial interface IInitializable<in T1, in T2, in T3, in T4, in T5, in T6, in T7> {

        void Initialize(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
	
        bool TryInitialize(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
	}
	
	public static partial class TInitializable<T1, T2, T3, T4, T5, T6, T7> {
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Initialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TInitializable : struct, IInitializable<T1, T2, T3, T4, T5, T6, T7> {
			@this.Initialize(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool TryInitialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TInitializable : struct, IInitializable<T1, T2, T3, T4, T5, T6, T7> {
			return @this.TryInitialize(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
	}

	public partial interface IInitializable<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> {

        void Initialize(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
	
        bool TryInitialize(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
	}
	
	public static partial class TInitializable<T1, T2, T3, T4, T5, T6, T7, T8> {
		
        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void Initialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TInitializable : struct, IInitializable<T1, T2, T3, T4, T5, T6, T7, T8> {
			@this.Initialize(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static bool TryInitialize<TInitializable>(ref TInitializable @this, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TInitializable : struct, IInitializable<T1, T2, T3, T4, T5, T6, T7, T8> {
			return @this.TryInitialize(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
	}
}