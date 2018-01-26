using System;

namespace UltimateOrb.Mathematics {
	using UInt = UInt32;
	using ULong = UInt64;
	using Int = Int32;
	using Long = Int64;

	using Math = Internal.System.Math;

	using IntT = Int64;
	using UIntT = UInt64;

	public static partial class DoubleArithmetic {
		
		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static UIntT ShiftRight(UIntT low, IntT high, int count, out IntT highResult) {
			return ShiftRightSigned(low, high, count, out highResult);
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static UIntT ShiftRight(UIntT low, UIntT high, int count, out UIntT highResult) {
			return ShiftRightUnsigned(low, high, count, out highResult);
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static UIntT ShiftRight(UIntT low, IntT high, out IntT highResult) {
			return ShiftRightSigned(low, high, out highResult);
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static UIntT ShiftRight(UIntT low, UIntT high, out UIntT highResult) {
			return ShiftRightUnsigned(low, high, out highResult);
		}
	}
}

namespace UltimateOrb.Mathematics {
	using UInt = UInt32;
	using ULong = UInt64;
	using Int = Int32;
	using Long = Int64;

	using Math = Internal.System.Math;

	using IntT = Int64;
	using UIntT = UInt64;
	
	using LIntT = UInt64;
	using HIntT = UInt64;

	public static partial class DoubleArithmetic {

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static HIntT ShiftLeft(LIntT low, HIntT high, int count) {
			return unchecked((HIntT)(((UIntT)high << count) | ((UIntT)low >> (64 - count))));
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRight(LIntT low, HIntT high, int count) {
			return unchecked((LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count))));
		}

#pragma warning disable 162
		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftLeft(LIntT low, HIntT high, int count, out HIntT highResult) {
			unchecked {
				count &= 2 * 64 - 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)(((UIntT)high << count) | ((UIntT)low >> (64 - count)));
					return (LIntT)(low << count);
				} else if (count > 64) {
					highResult = (HIntT)(low << (count - 64));
				} else {
					highResult = (HIntT)low;
				}
				return (LIntT)0;
			}
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightSigned(LIntT low, HIntT high, int count, out HIntT highResult) {
			unchecked {
				count &= 2 * 64 - 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((IntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else if (count > 64) {
					if (0 > (IntT)high) {
						highResult = (HIntT)(IntT)(-1);
						return (LIntT)(((UIntT)high >> (count - 64)) | (UIntT.MaxValue << (64 + 64 - count)));
					} else {
						highResult = (HIntT)0;
						return (LIntT)((UIntT)high >> (count - 64));
					}
				} else {
					highResult = (0 > (IntT)high) ? (HIntT)(IntT)(-1) : (HIntT)0;
					return (LIntT)high;
				}
			}
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightUnsigned(LIntT low, HIntT high, int count, out HIntT highResult) {
			unchecked {
				count &= 2 * 64 - 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((UIntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else {
					highResult = (HIntT)0;
					if (count > 64) {
						return (LIntT)((UIntT)high >> (count - 64));
					} else {
						return (LIntT)high;
					}
				}
			}
		}
#pragma warning restore 162

#pragma warning disable 162
		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftLeft(LIntT low, HIntT high, out HIntT highResult) {
			unchecked {
				const int count = 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)(((UIntT)high << count) | ((UIntT)low >> (64 - count)));
					return (LIntT)(low << count);
				} else if (count > 64) {
					highResult = (HIntT)(low << (count - 64));
				} else {
					highResult = (HIntT)low;
				}
				return (LIntT)0;
			}
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightSigned(LIntT low, HIntT high, out HIntT highResult) {
			unchecked {
				const int count = 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((IntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else if (count > 64) {
					if (0 > (IntT)high) {
						highResult = (HIntT)(IntT)(-1);
						return (LIntT)(((UIntT)high >> (count - 64)) | (UIntT.MaxValue << (64 + 64 - count)));
					} else {
						highResult = (HIntT)0;
						return (LIntT)((UIntT)high >> (count - 64));
					}
				} else {
					highResult = (0 > (IntT)high) ? (HIntT)(IntT)(-1) : (HIntT)0;
					return (LIntT)high;
				}
			}
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightUnsigned(LIntT low, HIntT high, out HIntT highResult) {
			unchecked {
				const int count = 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((UIntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else {
					highResult = (HIntT)0;
					if (count > 64) {
						return (LIntT)((UIntT)high >> (count - 64));
					} else {
						return (LIntT)high;
					}
				}
			}
		}
#pragma warning restore 162
	}
}

namespace UltimateOrb.Mathematics {
	using UInt = UInt32;
	using ULong = UInt64;
	using Int = Int32;
	using Long = Int64;

	using Math = Internal.System.Math;

	using IntT = Int64;
	using UIntT = UInt64;
	
	using LIntT = UInt64;
	using HIntT = Int64;

	public static partial class DoubleArithmetic {

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static HIntT ShiftLeft(LIntT low, HIntT high, int count) {
			return unchecked((HIntT)(((UIntT)high << count) | ((UIntT)low >> (64 - count))));
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRight(LIntT low, HIntT high, int count) {
			return unchecked((LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count))));
		}

#pragma warning disable 162
		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftLeft(LIntT low, HIntT high, int count, out HIntT highResult) {
			unchecked {
				count &= 2 * 64 - 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)(((UIntT)high << count) | ((UIntT)low >> (64 - count)));
					return (LIntT)(low << count);
				} else if (count > 64) {
					highResult = (HIntT)(low << (count - 64));
				} else {
					highResult = (HIntT)low;
				}
				return (LIntT)0;
			}
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightSigned(LIntT low, HIntT high, int count, out HIntT highResult) {
			unchecked {
				count &= 2 * 64 - 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((IntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else if (count > 64) {
					if (0 > (IntT)high) {
						highResult = (HIntT)(IntT)(-1);
						return (LIntT)(((UIntT)high >> (count - 64)) | (UIntT.MaxValue << (64 + 64 - count)));
					} else {
						highResult = (HIntT)0;
						return (LIntT)((UIntT)high >> (count - 64));
					}
				} else {
					highResult = (0 > (IntT)high) ? (HIntT)(IntT)(-1) : (HIntT)0;
					return (LIntT)high;
				}
			}
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightUnsigned(LIntT low, HIntT high, int count, out HIntT highResult) {
			unchecked {
				count &= 2 * 64 - 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((UIntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else {
					highResult = (HIntT)0;
					if (count > 64) {
						return (LIntT)((UIntT)high >> (count - 64));
					} else {
						return (LIntT)high;
					}
				}
			}
		}
#pragma warning restore 162

#pragma warning disable 162
		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftLeft(LIntT low, HIntT high, out HIntT highResult) {
			unchecked {
				const int count = 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)(((UIntT)high << count) | ((UIntT)low >> (64 - count)));
					return (LIntT)(low << count);
				} else if (count > 64) {
					highResult = (HIntT)(low << (count - 64));
				} else {
					highResult = (HIntT)low;
				}
				return (LIntT)0;
			}
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightSigned(LIntT low, HIntT high, out HIntT highResult) {
			unchecked {
				const int count = 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((IntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else if (count > 64) {
					if (0 > (IntT)high) {
						highResult = (HIntT)(IntT)(-1);
						return (LIntT)(((UIntT)high >> (count - 64)) | (UIntT.MaxValue << (64 + 64 - count)));
					} else {
						highResult = (HIntT)0;
						return (LIntT)((UIntT)high >> (count - 64));
					}
				} else {
					highResult = (0 > (IntT)high) ? (HIntT)(IntT)(-1) : (HIntT)0;
					return (LIntT)high;
				}
			}
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightUnsigned(LIntT low, HIntT high, out HIntT highResult) {
			unchecked {
				const int count = 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((UIntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else {
					highResult = (HIntT)0;
					if (count > 64) {
						return (LIntT)((UIntT)high >> (count - 64));
					} else {
						return (LIntT)high;
					}
				}
			}
		}
#pragma warning restore 162
	}
}

namespace UltimateOrb.Mathematics {
	using UInt = UInt32;
	using ULong = UInt64;
	using Int = Int32;
	using Long = Int64;

	using Math = Internal.System.Math;

	using IntT = Int64;
	using UIntT = UInt64;
	
	using LIntT = Int64;
	using HIntT = UInt64;

	public static partial class DoubleArithmetic {

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static HIntT ShiftLeft(LIntT low, HIntT high, int count) {
			return unchecked((HIntT)(((UIntT)high << count) | ((UIntT)low >> (64 - count))));
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRight(LIntT low, HIntT high, int count) {
			return unchecked((LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count))));
		}

#pragma warning disable 162
		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftLeft(LIntT low, HIntT high, int count, out HIntT highResult) {
			unchecked {
				count &= 2 * 64 - 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)(((UIntT)high << count) | ((UIntT)low >> (64 - count)));
					return (LIntT)(low << count);
				} else if (count > 64) {
					highResult = (HIntT)(low << (count - 64));
				} else {
					highResult = (HIntT)low;
				}
				return (LIntT)0;
			}
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightSigned(LIntT low, HIntT high, int count, out HIntT highResult) {
			unchecked {
				count &= 2 * 64 - 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((IntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else if (count > 64) {
					if (0 > (IntT)high) {
						highResult = (HIntT)(IntT)(-1);
						return (LIntT)(((UIntT)high >> (count - 64)) | (UIntT.MaxValue << (64 + 64 - count)));
					} else {
						highResult = (HIntT)0;
						return (LIntT)((UIntT)high >> (count - 64));
					}
				} else {
					highResult = (0 > (IntT)high) ? (HIntT)(IntT)(-1) : (HIntT)0;
					return (LIntT)high;
				}
			}
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightUnsigned(LIntT low, HIntT high, int count, out HIntT highResult) {
			unchecked {
				count &= 2 * 64 - 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((UIntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else {
					highResult = (HIntT)0;
					if (count > 64) {
						return (LIntT)((UIntT)high >> (count - 64));
					} else {
						return (LIntT)high;
					}
				}
			}
		}
#pragma warning restore 162

#pragma warning disable 162
		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftLeft(LIntT low, HIntT high, out HIntT highResult) {
			unchecked {
				const int count = 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)(((UIntT)high << count) | ((UIntT)low >> (64 - count)));
					return (LIntT)(low << count);
				} else if (count > 64) {
					highResult = (HIntT)(low << (count - 64));
				} else {
					highResult = (HIntT)low;
				}
				return (LIntT)0;
			}
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightSigned(LIntT low, HIntT high, out HIntT highResult) {
			unchecked {
				const int count = 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((IntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else if (count > 64) {
					if (0 > (IntT)high) {
						highResult = (HIntT)(IntT)(-1);
						return (LIntT)(((UIntT)high >> (count - 64)) | (UIntT.MaxValue << (64 + 64 - count)));
					} else {
						highResult = (HIntT)0;
						return (LIntT)((UIntT)high >> (count - 64));
					}
				} else {
					highResult = (0 > (IntT)high) ? (HIntT)(IntT)(-1) : (HIntT)0;
					return (LIntT)high;
				}
			}
		}

		[System.CLSCompliantAttribute(false)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightUnsigned(LIntT low, HIntT high, out HIntT highResult) {
			unchecked {
				const int count = 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((UIntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else {
					highResult = (HIntT)0;
					if (count > 64) {
						return (LIntT)((UIntT)high >> (count - 64));
					} else {
						return (LIntT)high;
					}
				}
			}
		}
#pragma warning restore 162
	}
}

namespace UltimateOrb.Mathematics {
	using UInt = UInt32;
	using ULong = UInt64;
	using Int = Int32;
	using Long = Int64;

	using Math = Internal.System.Math;

	using IntT = Int64;
	using UIntT = UInt64;
	
	using LIntT = Int64;
	using HIntT = Int64;

	public static partial class DoubleArithmetic {

		[System.CLSCompliantAttribute(true)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static HIntT ShiftLeft(LIntT low, HIntT high, int count) {
			return unchecked((HIntT)(((UIntT)high << count) | ((UIntT)low >> (64 - count))));
		}

		[System.CLSCompliantAttribute(true)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRight(LIntT low, HIntT high, int count) {
			return unchecked((LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count))));
		}

#pragma warning disable 162
		[System.CLSCompliantAttribute(true)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftLeft(LIntT low, HIntT high, int count, out HIntT highResult) {
			unchecked {
				count &= 2 * 64 - 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)(((UIntT)high << count) | ((UIntT)low >> (64 - count)));
					return (LIntT)(low << count);
				} else if (count > 64) {
					highResult = (HIntT)(low << (count - 64));
				} else {
					highResult = (HIntT)low;
				}
				return (LIntT)0;
			}
		}

		[System.CLSCompliantAttribute(true)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightSigned(LIntT low, HIntT high, int count, out HIntT highResult) {
			unchecked {
				count &= 2 * 64 - 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((IntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else if (count > 64) {
					if (0 > (IntT)high) {
						highResult = (HIntT)(IntT)(-1);
						return (LIntT)(((UIntT)high >> (count - 64)) | (UIntT.MaxValue << (64 + 64 - count)));
					} else {
						highResult = (HIntT)0;
						return (LIntT)((UIntT)high >> (count - 64));
					}
				} else {
					highResult = (0 > (IntT)high) ? (HIntT)(IntT)(-1) : (HIntT)0;
					return (LIntT)high;
				}
			}
		}

		[System.CLSCompliantAttribute(true)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightUnsigned(LIntT low, HIntT high, int count, out HIntT highResult) {
			unchecked {
				count &= 2 * 64 - 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((UIntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else {
					highResult = (HIntT)0;
					if (count > 64) {
						return (LIntT)((UIntT)high >> (count - 64));
					} else {
						return (LIntT)high;
					}
				}
			}
		}
#pragma warning restore 162

#pragma warning disable 162
		[System.CLSCompliantAttribute(true)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftLeft(LIntT low, HIntT high, out HIntT highResult) {
			unchecked {
				const int count = 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)(((UIntT)high << count) | ((UIntT)low >> (64 - count)));
					return (LIntT)(low << count);
				} else if (count > 64) {
					highResult = (HIntT)(low << (count - 64));
				} else {
					highResult = (HIntT)low;
				}
				return (LIntT)0;
			}
		}

		[System.CLSCompliantAttribute(true)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightSigned(LIntT low, HIntT high, out HIntT highResult) {
			unchecked {
				const int count = 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((IntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else if (count > 64) {
					if (0 > (IntT)high) {
						highResult = (HIntT)(IntT)(-1);
						return (LIntT)(((UIntT)high >> (count - 64)) | (UIntT.MaxValue << (64 + 64 - count)));
					} else {
						highResult = (HIntT)0;
						return (LIntT)((UIntT)high >> (count - 64));
					}
				} else {
					highResult = (0 > (IntT)high) ? (HIntT)(IntT)(-1) : (HIntT)0;
					return (LIntT)high;
				}
			}
		}

		[System.CLSCompliantAttribute(true)]
		[System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static LIntT ShiftRightUnsigned(LIntT low, HIntT high, out HIntT highResult) {
			unchecked {
				const int count = 1;
				if (count < 64) {
					if (count == 0) {
						highResult = high;
						return low;
					}
					highResult = (HIntT)((UIntT)high >> count);
					return (LIntT)(((UIntT)low >> count) | ((UIntT)high << (64 - count)));
				} else {
					highResult = (HIntT)0;
					if (count > 64) {
						return (LIntT)((UIntT)high >> (count - 64));
					} else {
						return (LIntT)high;
					}
				}
			}
		}
#pragma warning restore 162
	}
}
