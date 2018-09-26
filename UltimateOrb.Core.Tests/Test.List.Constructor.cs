using FsCheck.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UltimateOrb.Core.Tests {
    using static UltimateOrb.ConstructorTags;
    using UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic;

    public static partial class TestModule {

        public static partial class ListTests_T0 {

            [Property(MaxTest = 2, QuietOnSuccess = true)]
            public static bool Null() {
                List<UInt64> list = default(List<UInt64>);
                try {
                    var r = list.Capacity;
                    // Performance requirement
                    if (0 != r) {
                        return false;
                    }
                } catch (NullReferenceException) {
                }
                try {
                    var r = list.Count;
                    if (0 != r) {
                        return false;
                    }
                } catch (NullReferenceException) {
                }
                return true;
            }

            [Property(MaxTest = 2, QuietOnSuccess = true)]
            public static bool Constructor_Default() {
                List<UInt64> list = new List<UInt64>(_);
                if (0 > list.Capacity) {
                    return false;
                }
                if (0 != list.Count) {
                    return false;
                }
                if (false != list.IsReadOnly) {
                    return false;
                }
                return true;
            }

            [Property(MaxTest = 1000, QuietOnSuccess = true)]
            public static bool Constructor_Capacity(uint a) {
                var capacity = unchecked((int)(a % 30));
                List<UInt64> list = new List<UInt64>(capacity);
                if (0 > list.Capacity) {
                    return false;
                }
                if (0 != list.Count) {
                    return false;
                }
                if (false != list.IsReadOnly) {
                    return false;
                }
                return true;
            }


            [Property(MaxTest = 1000, QuietOnSuccess = true)]
            public static bool Constructor_NegativeCapacity_ThrowsArgumentOutOfRangeException(int a) {
                var capacity = a % 10;
                if (capacity >= 0) {
                    capacity += int.MinValue;
                }
                try {
                    var _ = new List<UInt64>(capacity);
                } catch (ArgumentException) {
                    return true;
                }
                return false;
            }

            [Property(MaxTest = 1000, QuietOnSuccess = true)]
            public static bool Constructor_IEnumerable(UInt64[] enumerableD) {
                if (null == enumerableD) {
                    return true;
                }
                var enumerableLength = enumerableD.Length;
                IEnumerable<UInt64> enumerable = enumerableD;
                List<UInt64> list = new List<UInt64>(enumerable);
                var expected = enumerable.ToList();
                if (enumerableLength != list.Count) {
                    return false;
                }
                for (int i = 0; i < enumerableLength; i++) {
                    if (0 != Microsoft.FSharp.Core.Operators.Compare(expected[i], list[i])) {
                        return false;
                    }
                }
                if (false != list.IsReadOnly) {
                    return false;
                }
                return true;
            }

            [Property(MaxTest = 2, QuietOnSuccess = true)]
            public static bool Constructo_NullIEnumerable_ThrowsArgumentNullException() {
                try {
                    var _ = new List<UInt64>((IEnumerable<UInt64>)null);
                } catch (ArgumentNullException) {
                    return true;
                }
                return false;
            }
        }
    }
}

namespace UltimateOrb.Core.Tests {
    using static UltimateOrb.ConstructorTags;
    using UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic;

    public static partial class TestModule {

        public static partial class ListTests_T1 {

            [Property(MaxTest = 2, QuietOnSuccess = true)]
            public static bool Null() {
                List<Int64?> list = default(List<Int64?>);
                try {
                    var r = list.Capacity;
                    // Performance requirement
                    if (0 != r) {
                        return false;
                    }
                } catch (NullReferenceException) {
                }
                try {
                    var r = list.Count;
                    if (0 != r) {
                        return false;
                    }
                } catch (NullReferenceException) {
                }
                return true;
            }

            [Property(MaxTest = 2, QuietOnSuccess = true)]
            public static bool Constructor_Default() {
                List<Int64?> list = new List<Int64?>(_);
                if (0 > list.Capacity) {
                    return false;
                }
                if (0 != list.Count) {
                    return false;
                }
                if (false != list.IsReadOnly) {
                    return false;
                }
                return true;
            }

            [Property(MaxTest = 1000, QuietOnSuccess = true)]
            public static bool Constructor_Capacity(uint a) {
                var capacity = unchecked((int)(a % 30));
                List<Int64?> list = new List<Int64?>(capacity);
                if (0 > list.Capacity) {
                    return false;
                }
                if (0 != list.Count) {
                    return false;
                }
                if (false != list.IsReadOnly) {
                    return false;
                }
                return true;
            }


            [Property(MaxTest = 1000, QuietOnSuccess = true)]
            public static bool Constructor_NegativeCapacity_ThrowsArgumentOutOfRangeException(int a) {
                var capacity = a % 10;
                if (capacity >= 0) {
                    capacity += int.MinValue;
                }
                try {
                    var _ = new List<Int64?>(capacity);
                } catch (ArgumentException) {
                    return true;
                }
                return false;
            }

            [Property(MaxTest = 1000, QuietOnSuccess = true)]
            public static bool Constructor_IEnumerable(Int64?[] enumerableD) {
                if (null == enumerableD) {
                    return true;
                }
                var enumerableLength = enumerableD.Length;
                IEnumerable<Int64?> enumerable = enumerableD;
                List<Int64?> list = new List<Int64?>(enumerable);
                var expected = enumerable.ToList();
                if (enumerableLength != list.Count) {
                    return false;
                }
                for (int i = 0; i < enumerableLength; i++) {
                    if (0 != Microsoft.FSharp.Core.Operators.Compare(expected[i], list[i])) {
                        return false;
                    }
                }
                if (false != list.IsReadOnly) {
                    return false;
                }
                return true;
            }

            [Property(MaxTest = 2, QuietOnSuccess = true)]
            public static bool Constructo_NullIEnumerable_ThrowsArgumentNullException() {
                try {
                    var _ = new List<Int64?>((IEnumerable<Int64?>)null);
                } catch (ArgumentNullException) {
                    return true;
                }
                return false;
            }
        }
    }
}

namespace UltimateOrb.Core.Tests {
    using static UltimateOrb.ConstructorTags;
    using UltimateOrb.Typed_RefReturn_Wrapped_Huge.Collections.Generic;

    public static partial class TestModule {

        public static partial class ListTests_T2 {

            [Property(MaxTest = 2, QuietOnSuccess = true)]
            public static bool Null() {
                List<string> list = default(List<string>);
                try {
                    var r = list.Capacity;
                    // Performance requirement
                    if (0 != r) {
                        return false;
                    }
                } catch (NullReferenceException) {
                }
                try {
                    var r = list.Count;
                    if (0 != r) {
                        return false;
                    }
                } catch (NullReferenceException) {
                }
                return true;
            }

            [Property(MaxTest = 2, QuietOnSuccess = true)]
            public static bool Constructor_Default() {
                List<string> list = new List<string>(_);
                if (0 > list.Capacity) {
                    return false;
                }
                if (0 != list.Count) {
                    return false;
                }
                if (false != list.IsReadOnly) {
                    return false;
                }
                return true;
            }

            [Property(MaxTest = 1000, QuietOnSuccess = true)]
            public static bool Constructor_Capacity(uint a) {
                var capacity = unchecked((int)(a % 30));
                List<string> list = new List<string>(capacity);
                if (0 > list.Capacity) {
                    return false;
                }
                if (0 != list.Count) {
                    return false;
                }
                if (false != list.IsReadOnly) {
                    return false;
                }
                return true;
            }


            [Property(MaxTest = 1000, QuietOnSuccess = true)]
            public static bool Constructor_NegativeCapacity_ThrowsArgumentOutOfRangeException(int a) {
                var capacity = a % 10;
                if (capacity >= 0) {
                    capacity += int.MinValue;
                }
                try {
                    var _ = new List<string>(capacity);
                } catch (ArgumentException) {
                    return true;
                }
                return false;
            }

            [Property(MaxTest = 1000, QuietOnSuccess = true)]
            public static bool Constructor_IEnumerable(string[] enumerableD) {
                if (null == enumerableD) {
                    return true;
                }
                var enumerableLength = enumerableD.Length;
                IEnumerable<string> enumerable = enumerableD;
                List<string> list = new List<string>(enumerable);
                var expected = enumerable.ToList();
                if (enumerableLength != list.Count) {
                    return false;
                }
                for (int i = 0; i < enumerableLength; i++) {
                    if (0 != Microsoft.FSharp.Core.Operators.Compare(expected[i], list[i])) {
                        return false;
                    }
                }
                if (false != list.IsReadOnly) {
                    return false;
                }
                return true;
            }

            [Property(MaxTest = 2, QuietOnSuccess = true)]
            public static bool Constructo_NullIEnumerable_ThrowsArgumentNullException() {
                try {
                    var _ = new List<string>((IEnumerable<string>)null);
                } catch (ArgumentNullException) {
                    return true;
                }
                return false;
            }
        }
    }
}
