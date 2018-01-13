using FsCheck.Xunit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace UltimateOrb.Core.Tests {
    using UltimateOrb.Collections.Generic;
    using UltimateOrb.Plain.ValueTypes;

    public static class AAA {

        public static PtrSimulated<T> End<T>(this T[] array) {
            return new PtrSimulated<T>(array, checked((uint)array.Length));
        }
    }

    public partial class Program {

        private static AsyncLocal<long> item_id_1 = new AsyncLocal<long>();

        private static AsyncLocal<Queue<long>> collection_1 = new AsyncLocal<Queue<long>>();

        private static AsyncLocal<Random> random = new AsyncLocal<Random>();

        [Property(MaxTest = 100000, QuietOnSuccess = true)]
        public bool Test_Reverse_1(long[] a) {
            if (null == a) {
                return true;
            }
            var rr = GetRandom();
            var c = rr.Next(checked(1 + a.Length));
            var s = rr.Next(checked(1 + a.Length - c));
            // var t = unchecked(rr.Next() - rr.Next());
            var r0 = a.Clone() as long[];
            Array.Reverse<long>(r0, s, c);
            var r1 = a.Clone() as long[];
            ArrayModule.Reverse(r1, s, c);
            return r0.SequenceEqual(r1);
        }

        [Property(MaxTest = 100000, QuietOnSuccess = true)]
        public bool Test_Reverse_2(long[] a) {
            if (null == a) {
                return true;
            }
            var rr = GetRandom();
            // var c = rr.Next(checked(1 + a.Length));
            // var s = rr.Next(checked(1 + a.Length - c));
            // var t = unchecked(rr.Next() - rr.Next());
            var r0 = a.Clone() as long[];
            Array.Reverse<long>(r0);
            var r1 = a.Clone() as long[];
            ArrayModule.Reverse(r1);
            return r0.SequenceEqual(r1);
        }

        public static bool Test_Rotate_Stub_Shift_1(Action<List<(int ProblemSize, int Shift, bool Success)>, int, long[], int> test) {
            var rr = GetRandom();
            var rs = new List<(int ProblemSize, int Shift, bool Success)>();
            for (var aL = 0; 121 > aL; ++aL) {
                var a = Enumerable.Range(0, aL).Select((x) => 10000 + 107L * x).ToArray();
                for (var c = 0; c <= aL; ++c) {
                    for (var s = 0; s <= aL - c; ++s) {
                        for (var i = -2 - c; i <= 2 + c; ++i) {
                            test(rs, aL, a, i);
                        }
                        for (var i = 3 + c; i > 0; --i) {
                            var t = unchecked(rr.Next() - rr.Next());
                            test(rs, aL, a, t);
                        }
                    }
                }
            }
            return rs.All((x) => x.Success);
        }

        public static bool Test_Rotate_Stub_Count_Start_Shift_1(Action<List<(int ProblemSize, int Count, int Start, int Shift, bool Success)>, int, long[], int, int, int> test) {
            var rr = GetRandom();
            var rs = new List<(int ProblemSize, int Count, int Start, int Shift, bool Success)>();
            for (var aL = 0; 85 > aL; ++aL) {
                var a = Enumerable.Range(0, aL).Select((x) => 10000 + 107L * x).ToArray();
                for (var c = 0; c <= aL; ++c) {
                    for (var s = 0; s <= aL - c; ++s) {
                        for (var i = -2 - c; i <= 2 + c; ++i) {
                            test(rs, aL, a, c, s, i);
                        }
                        for (var i = 3 + c; i > 0; --i) {
                            var t = unchecked(rr.Next() - rr.Next());
                            test(rs, aL, a, c, s, t);
                        }
                    }
                }
            }
            return rs.All((x) => x.Success);
        }

        public static bool Test_Rotate_Stub_Start_Mid_EndEx_1(Action<List<(int ProblemSize, int Start, int Mid, int EndEx, bool Success)>, int, long[], int, int, int> test) {
            var rr = GetRandom();
            var rs = new List<(int ProblemSize, int Start, int Mid, int EndEx, bool Success)>();
            for (var aL = 0; 100 > aL; ++aL) {
                var a = Enumerable.Range(0, aL).Select((x) => 10000 + 107L * x).ToArray();
                for (var c = 0; c <= aL; ++c) {
                    for (var s = c; s <= aL; ++s) {
                        for (var t = s; t <= aL; ++t) {
                            test(rs, aL, a, c, s, t);
                        }
                    }
                }
            }
            return rs.All((x) => x.Success);
        }

        private static void Test_Rotate_RotateInPlace_RotateLeftInPlace_1_1(List<(int ProblemSize, int Count, int Start, int Shift, bool Success)> rs, int aL, long[] a, int c, int s, int t) {
            var r0 = a.Clone() as long[];
            ArrayModule.RotateInPlace(r0, s, s + (c == 0 ? 0 : (0 > t ? t % c + c : t % c)), s + c);
            var r1 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace(r1, s, c, t);
            rs.Add((aL, c, s, t, r0.SequenceEqual(r1)));
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_Rotate_RotateInPlace_RotateLeftInPlace_1() {
            return Test_Rotate_Stub_Count_Start_Shift_1(Test_Rotate_RotateInPlace_RotateLeftInPlace_1_1);
        }

        private static void Test_Rotate_RotateInPlace_RotateLeftInPlace_3_1(List<(int ProblemSize, int Shift, bool Success)> rs, int aL, long[] a, int t) {
            var r0 = a.Clone() as long[];
            var c = r0.Length;
            ArrayModule.RotateInPlace(r0, 0, (c == 0 ? 0 : (0 > t ? t % c + c : t % c)), c);
            var r1 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace(r1, t);
            rs.Add((aL, t, r0.SequenceEqual(r1)));
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_Rotate_RotateInPlace_RotateLeftInPlace_3() {
            return Test_Rotate_Stub_Shift_1(Test_Rotate_RotateInPlace_RotateLeftInPlace_3_1);
        }

        private static void Test_Rotate_RotateInPlace_RotateLeftInPlace_2_1(List<(int ProblemSize, int Start, int Mid, int EndEx, bool Success)> rs, int aL, long[] a, int s, int m, int t) {
            var r0 = a.Clone() as long[];
            ArrayModule.RotateInPlace(r0, s, m, t);
            var r1 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace(r1, s, checked(t - s), checked(m - s));
            rs.Add((aL, s, t, m, r0.SequenceEqual(r1)));
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_Rotate_RotateInPlace_RotateLeftInPlace_2() {
            return Test_Rotate_Stub_Start_Mid_EndEx_1(Test_Rotate_RotateInPlace_RotateLeftInPlace_2_1);
        }

        private static void Test_Rotate_RotateLeftInPlace_AA_1_1(List<(int ProblemSize, int Count, int Start, int Shift, bool Success)> rs, int aL, long[] a, int c, int s, int t) {
            var r0 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace(r0, s, c, t);
            var r1 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace_A(r1, s, c, t);
            rs.Add((aL, c, s, t, r0.SequenceEqual(r1)));
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_Rotate_RotateLeftInPlace_AA_1() {
            return Test_Rotate_Stub_Count_Start_Shift_1(Test_Rotate_RotateLeftInPlace_AA_1_1);
        }

        private static void Test_Rotate_RotateLeftInPlace_AA_2_1(List<(int ProblemSize, int Shift, bool Success)> rs, int aL, long[] a, int t) {
            var r0 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace(r0, t);
            var r1 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace_A(r1, t);
            rs.Add((aL, t, r0.SequenceEqual(r1)));
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_Rotate_RotateLeftInPlace_AA_2() {
            return Test_Rotate_Stub_Shift_1(Test_Rotate_RotateLeftInPlace_AA_2_1);
        }

        private static void Test_Rotate_RotateLeftInPlace_RotateRightInPlace_AA_1_1(List<(int ProblemSize, int Count, int Start, int Shift, bool Success)> rs, int aL, long[] a, int c, int s, int t) {
            var r0 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace_A(r0, s, c, t);
            var r1 = a.Clone() as long[];
            ArrayModule.RotateRightInPlace_A(r1, s, c, checked(-t));
            rs.Add((aL, c, s, t, r0.SequenceEqual(r1)));
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_Rotate_RotateLeftInPlace_RotateRightInPlace_AA_1() {
            return Test_Rotate_Stub_Count_Start_Shift_1(Test_Rotate_RotateLeftInPlace_RotateRightInPlace_AA_1_1);
        }

        private static void Test_Rotate_RotateLeftInPlace_RotateRightInPlace_AA_2_1(List<(int ProblemSize, int Shift, bool Success)> rs, int aL, long[] a, int t) {
            var r0 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace_A(r0, t);
            var r1 = a.Clone() as long[];
            ArrayModule.RotateRightInPlace_A(r1, checked(-t));
            rs.Add((aL, t, r0.SequenceEqual(r1)));
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_Rotate_RotateLeftInPlace_RotateRightInPlace_AA_2() {
            return Test_Rotate_Stub_Shift_1(Test_Rotate_RotateLeftInPlace_RotateRightInPlace_AA_2_1);
        }

        private static void Test_Rotate_RotateLeftInPlace_RotateRightInPlace_1_1(List<(int ProblemSize, int Count, int Start, int Shift, bool Success)> rs, int aL, long[] a, int c, int s, int t) {
            var r0 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace(r0, s, c, t);
            var r1 = a.Clone() as long[];
            ArrayModule.RotateRightInPlace(r1, s, c, checked(-t));
            rs.Add((aL, c, s, t, r0.SequenceEqual(r1)));
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_Rotate_RotateLeftInPlace_RotateRightInPlace_1() {
            return Test_Rotate_Stub_Count_Start_Shift_1(Test_Rotate_RotateLeftInPlace_RotateRightInPlace_1_1);
        }

        private static void Test_Rotate_RotateLeftInPlace_RotateRightInPlace_2_1(List<(int ProblemSize, int Shift, bool Success)> rs, int aL, long[] a, int t) {
            var r0 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace(r0, t);
            var r1 = a.Clone() as long[];
            ArrayModule.RotateRightInPlace(r1, checked(-t));
            rs.Add((aL, t, r0.SequenceEqual(r1)));
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_Rotate_RotateLeftInPlace_RotateRightInPlace_2() {
            return Test_Rotate_Stub_Shift_1(Test_Rotate_RotateLeftInPlace_RotateRightInPlace_2_1);
        }

        [Property(MaxTest = 10000, QuietOnSuccess = true, Verbose = true)]
        public bool Test_Rotate_5(long[] a) {
            if (null == a) {
                return true;
            }
            var rr = GetRandom();
            // var c = rr.Next(checked(1 + a.Length));
            // var s = rr.Next(checked(1 + a.Length - c));
            var t = unchecked(rr.Next() - rr.Next());
            var r0 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace(r0, t);
            var r1 = a.Clone() as long[];
            ArrayModule.RotateLeftInPlace_A(r1, t);
            var rrr = r0.SequenceEqual(r1);
            if (!rrr) {
                while (!rrr) {
                }
            }
            return rrr;
        }

        [Property(MaxTest = 40000, QuietOnSuccess = true)]
        public bool Test_1() {
            var ff = 2345;
            var rr = GetRandom();
            {
                var deque0 = new LinkedList<long>();
                var deque1 = new Queue<long>(0);
                var iid = 1001;
                for (var i = 0; 300 > i; ++i) {
                    var m = rr.NextDouble();
                    if (m < 0.150) {
                        if (deque0.Count > 0) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                        continue;
                    } else if (m < 0.425) {
                        {
                            var d = iid++;
                            deque0.AddLast(d);
                            deque1.Push(d);
                        }
                    } else if (m < 0.475) {
                        if (deque0.Count >= ff) {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            var d = iid++;
                            deque0.AddLast(d);
                            deque1.Push(d);
                        }
                    } else if (m < 0.490) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                    } else if (m < 0.500) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = deque0.Count;
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                    } else if (m < 0.650) {
                        if (deque0.Count > 0) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                        continue;
                    } else if (m < 0.925) {
                        {
                            var d = iid++;
                            deque0.AddFirst(d);
                            deque1.Unshift(d);
                        }
                    } else if (m < 0.975) {
                        if (deque0.Count >= ff) {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            var d = iid++;
                            deque0.AddFirst(d);
                            deque1.Unshift(d);
                        }
                    } else if (m < 0.990) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                    } else if (m < 1.000) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = deque0.Count;
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                    }
                    {
                        var s0 = deque0.ToArray();
                        var s1 = deque1.ToArray();
                        var ss = s0.SequenceEqual(s1);
                        if (!ss) {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        [Property(MaxTest = 50000, QuietOnSuccess = true)]
        public bool Test_2() {
            var ff = 2345;
            var rr = GetRandom();
            {
                var cc = rr.Next(100);
                var deque0 = new LinkedList<long>();
                var deque1 = new Queue<long>(cc);
                var iid = 1001;
                for (var i = 0; 150 > i; ++i) {
                    var m = rr.NextDouble();
                    if (m < 0.150) {
                        if (deque0.Count > 0) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                        continue;
                    } else if (m < 0.425) {
                        {
                            var d = iid++;
                            deque0.AddLast(d);
                            deque1.Push(d);
                        }
                    } else if (m < 0.475) {
                        if (deque0.Count >= ff) {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            var d = iid++;
                            deque0.AddLast(d);
                            deque1.Push(d);
                        }
                    } else if (m < 0.490) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                    } else if (m < 0.500) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = deque0.Count;
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                    } else if (m < 0.650) {
                        if (deque0.Count > 0) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                        continue;
                    } else if (m < 0.925) {
                        {
                            var d = iid++;
                            deque0.AddFirst(d);
                            deque1.Unshift(d);
                        }
                    } else if (m < 0.975) {
                        if (deque0.Count >= ff) {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            var d = iid++;
                            deque0.AddFirst(d);
                            deque1.Unshift(d);
                        }
                    } else if (m < 0.990) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                    } else if (m < 1.000) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = deque0.Count;
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                    }
                    {
                        var s0 = deque0.ToArray();
                        var s1 = deque1.ToArray();
                        var ss = s0.SequenceEqual(s1);
                        if (!ss) {
                            return false;
                        }
                    }
                    {
                        var s1 = deque1.ToArray();
                        var s1a = deque1.AsEnumerable().ToArray();
                        var ssa = s1.SequenceEqual(s1a);
                        if (!ssa) {
                            return false;
                        }
                    }
                }
                return true;
            }
        }


        private partial class AA : Collections.Generic.IStack<int>, IEnumerable<int> {

            private partial struct AAA : IFunc<int?, int, int?> {

                public int? Invoke(int? arg1, int arg2) {
                    return !(arg1 < arg2) ? arg2 : arg1;
                }
            }

            private partial struct AAAss : IFunc<Plain.ValueTypes.Stack<(int, int?)>>, IFunc<int, Plain.ValueTypes.Stack<(int, int?)>> {

                public Stack<(int, int?)> Invoke() {
                    return new Stack<(int, int?)>(0);
                }

                public Stack<(int, int?)> Invoke(int arg) {
                    return new Stack<(int, int?)>(arg);
                }
            }

            private Plain.ValueTypes.FoldingStack<int, int?, AAA, Plain.ValueTypes.Stack<(int Item, int?)>> _;

            public AA() {
                this._ = Plain.ValueTypes.FoldingStack<int, int?, AAA, Plain.ValueTypes.Stack<(int, int?)>>.Create<AAAss>();
            }

            public AA(int capacity) {
                this._ = Plain.ValueTypes.FoldingStack<int, int?, AAA, Plain.ValueTypes.Stack<(int, int?)>>.Create<AAAss>(capacity);
            }

            public bool IsEmpty {

                get => this._.IsEmpty;
            }

            public int? Min {

                get => this._.Accumulate;
            }

            public int Pop() {
                return this._.Pop();
            }

            public int Peek() {
                return this._.Peek();
            }

            public void Push(int item) {
                this._.Push(item);
            }

            public bool TryPush(int item) {
                return this._.TryPush(item);
            }

            public bool TryPeek(out int item) {
                return this._.TryPeek(out item);
            }

            public bool TryPop(out int item) {
                return this._.TryPop(out item);
            }

            public IEnumerator<int> GetEnumerator() {
                var b = this._.data.buffer;
                var c = this._.data.count0;
                for (; c > 0;) {
                    yield return b[--c].Item1;
                }
            }


            private partial struct Adfsad : IFunc<(int, int?), int> {

                public int Invoke((int, int?) arg) {
                    return arg.Item1;
                }
            }

            public int[] ToArray() {
                return this._.data.ToArray<int, Adfsad>();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                throw new NotImplementedException();
            }
        }


        private partial class AB : Collections.Generic.IStack<int>, IEnumerable<int> {

            private System.Collections.Generic.Stack<int> _;

            public AB() {
                this._ = new System.Collections.Generic.Stack<int>();
            }

            public AB(int capacity) {
                this._ = new System.Collections.Generic.Stack<int>(capacity);
            }

            public int Count {

                get {
                    return this._.Count;
                }
            }


            public bool IsEmpty {

                get => this._.Count <= 0;
            }

            public int? Min {

                get => (!this.IsEmpty ? (int?)this._.Min() : null);
            }

            public int Pop() {
                return this._.Pop();
            }

            public int Peek() {
                return this._.Peek();
            }

            public void Push(int item) {
                this._.Push(item);
            }

            public bool TryPush(int item) {
                try {
                    this._.Push(item);
                } catch (OutOfMemoryException) {
                    return false;
                }
                return true;
            }

            public bool TryPeek(out int item) {
                return this._.TryPeek(out item);
            }

            public bool TryPop(out int item) {
                return this._.TryPop(out item);
            }

            public IEnumerator<int> GetEnumerator() {
                return this._.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return this._.GetEnumerator();
            }
        }

        /*
        [Property(MaxTest = 100, QuietOnSuccess = true)]
        public bool Test_X100() {
            return true;
        }

        [Property(MaxTest = 1000, QuietOnSuccess = true)]
        public bool Test_X1000() {
            return true;
        }

        [Property(MaxTest = 10000, QuietOnSuccess = true)]
        public bool Test_X10000() {
            return true;
        }

        [Property(MaxTest = 100000, QuietOnSuccess = true)]
        public bool Test_X100000() {
            return true;
        }

        [Property(MaxTest = 1000000, QuietOnSuccess = true)]
        public bool Test_X1000000() {
            return true;
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_XA3300000000() {
            var a = false;
            for (var i = 0UL; 3300000000 > i; ++i) {
                a ^= a;
            }
            return !a;
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_X1A330000000() {
            var a = (bool?)false;
            for (var i = 0UL; 330000000 > i; ++i) {
                a ^= null;
            }
            return !a.GetValueOrDefault();
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_X2A330000000() {
            var a = (bool?)false;
            for (var i = 0UL; 330000000 > i; ++i) {
                a ^= DefaultConstructor.Invoke<bool?>();
            }
            return !a.GetValueOrDefault();
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_X3A330000000() {
            var a = (bool?)false;
            for (var i = 0UL; 330000000 > i; ++i) {
                a ^= DefaultConstructor.Invoke<bool>();
            }
            return !a.GetValueOrDefault();
        }
        */

        [Property(MaxTest = 500, QuietOnSuccess = true)]
        public bool Test_3() {
            var ff = 2345;
            var rr = GetRandom();
            {
                var cc = rr.Next(100);
                for (var g = 15; g > 0; --g) {
                    var deque0 = new AB();
                    var deque1 = new AA();
                    var iid = 1001;
                    for (var i = 0; 300 > i; ++i) {
                        var m = rr.NextDouble();
                        if (m < 0.150) {
                            if (deque0.Count > 0) {
                                deque0.Pop();
                                deque1.Pop();
                            }
                            continue;
                        } else if (m < 0.850) {
                            {
                                var d = iid++;
                                deque0.Push(d);
                                deque1.Push(d);
                            }
                        } else if (m < 0.950) {
                            if (deque0.Count >= ff) {
                                continue;
                            }
                            var n0 = 1 + rr.Next(deque0.Count);
                            for (var n = n0; n > 0; --n) {
                                var d = iid++;
                                deque0.Push(d);
                                deque1.Push(d);
                            }
                        } else if (m < 0.980) {
                            if (deque0.Count > 0) {
                            } else {
                                continue;
                            }
                            var n0 = 1 + rr.Next(deque0.Count);
                            for (var n = n0; n > 0; --n) {
                                deque0.Pop();
                                deque1.Pop();
                            }
                        } else if (m <= 1.000) {
                            if (deque0.Count > 0) {
                            } else {
                                continue;
                            }
                            var n0 = deque0.Count;
                            for (var n = n0; n > 0; --n) {
                                deque0.Pop();
                                deque1.Pop();
                            }
                        }
                        {
                            var s0 = deque0.ToArray();
                            var s1 = deque1.ToArray();
                            var ss = s0.SequenceEqual(s1);
                            if (!ss) {
                                Xunit.Assert.True(false);
                            }
                        }
                        {
                            var s0 = deque0.Min;
                            var s1 = deque1.Min;
                            var ss = s0 == s1;
                            if (!ss) {
                                Xunit.Assert.True(false);
                            }
                        }
                        {
                            var s1 = deque1.ToArray();
                            var s1a = deque1.AsEnumerable().ToArray();
                            var ssa = s1.SequenceEqual(s1a);
                            if (!ssa) {
                                Xunit.Assert.True(false);
                            }
                        }
                    }
                }
                return true;
            }
        }

        private static Random GetRandom() {
            var rr = Program.random.Value;
            if (null == rr) {
                rr = new Random();
                Program.random.Value = rr;
            }
            return rr;
        }

        private static long? dddd1 = default;


        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_IsPermutation_1() {
            var a = "Banaan🌍nas".ToCharArray();
            var c = ((Func<char, char, bool>)((x, y) => x == y)).AsIFunc();
            var d = ((Func<char, char, bool>)((x, y) => x < y)).AsIFunc();
            var t = 0UL;
            var s = new List<(ulong Id, bool Value)>(0);            
            for (var b = a.Clone() as char[]; ;) {
                var z = ArrayModule.IsPermutation(a.Clone() as char[], b.Clone() as char[], c);
                s.Add((t++, z));
                if (ArrayModule.NextPermutation(b, d)) {
                    continue;
                }
                break;
            }
            return s.All((x) => x.Value);
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_IsPermutation_2() {
            var a = "Banaan🌍nas".ToCharArray();
            var c = ((Func<char, char, bool>)((x, y) => x == y)).AsIFunc();
            var d = ((Func<char, char, bool>)((x, y) => x < y)).AsIFunc();
            var t = 0UL;
            var s = new List<(ulong Id, bool Value)>(0);
            for (var b = a.Clone() as char[]; ;) {
                var z = ArrayModule.IsPermutation(a as char[], b as char[], c);
                s.Add((t++, z));
                if (ArrayModule.NextPermutation(b, d)) {
                    continue;
                }
                break;
            }
            for (var b = a.Clone() as char[]; ;) {
                var z = ArrayModule.IsPermutation(a as char[], b as char[], c);
                s.Add((t++, z));
                if (ArrayModule.PreviousPermutation(b, d)) {
                    continue;
                }
                break;
            }
            return s.All((x) => x.Value);
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_NextPermutation_3() {
            var a = "abcdefgh".ToCharArray();
            var c = ((Func<char, char, bool>)((x, y) => x == y)).AsIFunc();
            var d = ((Func<char, char, bool>)((x, y) => x < y)).AsIFunc();
            var t = 0UL;
            var s = new List<(ulong Id, bool Value)>(0);
            for (var b = a.Clone() as char[]; ;) {
                var z = ArrayModule.IsPermutation(a as char[], b as char[], c);
                s.Add((t++, z));
                if (ArrayModule.NextPermutation(b, d)) {
                    continue;
                }
                break;
            }
            return s.All((x) => x.Value) && s.Count == 40320;
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_NextPermutation_4() {
            var a = "abcdefgg".ToCharArray();
            var c = ((Func<char, char, bool>)((x, y) => x == y)).AsIFunc();
            var d = ((Func<char, char, bool>)((x, y) => x < y)).AsIFunc();
            var t = 0UL;
            var s = new List<(ulong Id, bool Value)>(0);
            for (var b = a.Clone() as char[]; ;) {
                var z = ArrayModule.IsPermutation(a as char[], b as char[], c);
                s.Add((t++, z));
                if (ArrayModule.NextPermutation(b, d)) {
                    continue;
                }
                break;
            }
            return s.All((x) => x.Value) && s.Count == 20160;
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_PreviousPermutation_3() {
            var a = "hgfedcba".ToCharArray();
            var c = ((Func<char, char, bool>)((x, y) => x == y)).AsIFunc();
            var d = ((Func<char, char, bool>)((x, y) => x < y)).AsIFunc();
            var t = 0UL;
            var s = new List<(ulong Id, bool Value)>(0);
            for (var b = a.Clone() as char[]; ;) {
                var z = ArrayModule.IsPermutation(a as char[], b as char[], c);
                s.Add((t++, z));
                if (ArrayModule.PreviousPermutation(b, d)) {
                    continue;
                }
                break;
            }
            return s.All((x) => x.Value) && s.Count == 40320;
        }

        [Property(MaxTest = 1, QuietOnSuccess = true)]
        public bool Test_PreviousPermutation_4() {
            var a = "ggfedcba".ToCharArray();
            var c = ((Func<char, char, bool>)((x, y) => x == y)).AsIFunc();
            var d = ((Func<char, char, bool>)((x, y) => x < y)).AsIFunc();
            var t = 0UL;
            var s = new List<(ulong Id, bool Value)>(0);
            for (var b = a.Clone() as char[]; ;) {
                var z = ArrayModule.IsPermutation(a as char[], b as char[], c);
                s.Add((t++, z));
                if (ArrayModule.PreviousPermutation(b, d)) {
                    continue;
                }
                break;
            }
            return s.All((x) => x.Value) && s.Count == 20160;
        }

        private static void Printf<T>(System.IO.TextWriter textWriter, T value) {
            var t = new Microsoft.FSharp.Core.PrintfFormat<Microsoft.FSharp.Core.FSharpFunc<T, Microsoft.FSharp.Core.Unit>, System.IO.TextWriter, Microsoft.FSharp.Core.Unit, Microsoft.FSharp.Core.Unit, T>("%A");
            var f = Microsoft.FSharp.Core.PrintfModule.PrintFormatLineToTextWriter(textWriter, t);
            f.Invoke(value);
        }

        private static int Main(string[] args) {
            {
                new Program().Test_IsPermutation_2();
                {
                    var a = "Banaan🌍nas".ToCharArray();
                    var c = ((Func<char, char, bool>)((x, y) => x == y)).AsIFunc();
                    var d = ((Func<char, char, bool>)((x, y) => x < y)).AsIFunc();
                    var t = 0UL;
                    var s = new List<(ulong Id, bool Value)>(0);
                    for (var b = a.Clone() as char[]; ;) {
                        Console.Out.WriteLine(b);
                        var z = ArrayModule.IsPermutation(a.Clone() as char[], b.Clone() as char[], c);
                        s.Add((t++, z));
                        if (ArrayModule.PreviousPermutation(b, d)) {
                            continue;
                        }
                        break;
                    }
                    var f = s.All((x) => x.Value);
                }
                return 0;
            }
            {
                var source = "abc abab bbda bd bb🌍a  ba badba dbad db a dcadb bad bab adb b🌍cdab d bda　🌍 dsf 地球人好壞 b da b b🌍a a".ToCharArray();
                var pattern = " b b🌍a".ToCharArray();
                Console.Out.WriteLine(DefaultConstructor.Invoke<StringRawEqualityComparer>().GetHashCode(pattern, 0, pattern.Length));
                var hash = DefaultConstructor.Invoke<StringRawEqualityComparer>().CreateHashCodeBuilder(pattern, 0, pattern.Length);

                Console.Out.WriteLine(hash.GetCurrentHashCode());
                hash.Shift(' ', ' ');
                hash.Shift('b', 'b');
                hash.Shift(' ', ' ');
                hash.Shift('b', 'b');
                hash.Shift('a', 'a');
                Console.Out.WriteLine(hash.GetCurrentHashCode());

                var c = SequenceSearchModule.IndexOf_A_RabinKarp<char, char[], char[], StringRawEqualityComparer.HashCodeBuilder, StringRawEqualityComparer>(source, pattern, DefaultConstructor.Invoke<StringRawEqualityComparer>());
                Console.Out.WriteLine("...");
                Console.Out.WriteLine(c);
                Console.Out.WriteLine(new string(source.Skip(c).Take(pattern.Length).ToArray()));
                Console.ReadKey(true);
                return 0;
            }
            {
                var b = new int[] { 1, 2, 2, 3, 4, };
                var a = Enumerable.Range(0, b.Length).ToArray();
                var dd = 0L;
                do {
                    var c = b.Clone() as int[];
                    ArrayModule.Reorder(c, a.Clone() as int[]);
                    ++dd;
                    Printf(System.Console.Out, c);
                } while (ArrayModule.NextPermutation(a, ((Func<int, int, bool>)((x, y) => x < y)).AsIFunc()));
                Console.Out.WriteLine("...");
                Console.Out.WriteLine(dd);
                Console.ReadKey(true);
                return 0;
            }

            {
                var b = new int[] { 1, 2, 2, 3, 4, };
                var a = Enumerable.Range(0, b.Length).ToArray();
                var dd = 0L;
                do {
                    var c = a.Select(x => b[x]).ToArray();
                    ++dd;
                    Printf(System.Console.Out, c);
                } while (ArrayModule.NextPermutation(a, ((Func<int, int, bool>)((x, y) => x < y)).AsIFunc()));
                Console.Out.WriteLine("...");
                Console.Out.WriteLine(dd);
                Console.ReadKey(true);
                return 0;
            }
            {
                var a = new int[] { 4, 4, 5, 5, 5, 6 };
                // a = new int[] { 1, 3, 2, };
                var b = a.Clone() as int[];
                do {
                    Printf(System.Console.Out, b);
                } while (ArrayModule.NextPermutation(b, ((Func<int, int, bool>)((x, y) => x < y)).AsIFunc()));

                Console.Out.WriteLine("...");
                Console.ReadKey(true);
                return 0;
            }
            {
                {
                    var aaa = new Program().Test_Rotate_RotateInPlace_RotateLeftInPlace_1();
                }

                var asdfs = new object().GetHashCode();
                if (asdfs > 1) {
                    if (asdfs == 1) {
                        Console.Out.WriteLine(1024);
                    }
                }
                bool a = false;
                for (var i = 100; i > 0; --i) {
                    // a = new Program().Test_Rotate_3a(new long[] { 0, 1, 0 });
                }
                Console.Out.WriteLine(a);
                Console.Out.WriteLine("...");
                Console.ReadKey(true);
                return 0;
            }
            {
                var a = new long[33];
                {
                    long s = 10000;
                    for (PtrSimulated<long> i = a; i < a.End(); i += 7) {
                        i.Data = s++;
                    }
                }
                Console.Out.WriteLine("...");
                Console.ReadKey(true);
                return 0;
            }

            {


                var rrrrr = new Random();

                var id = 10000L;
                var tree = new Collections.Generic.ReferenceTypes.LinkedTree<long>(id++);
                var ll = new Collections.Generic.RefReturnSupported.List<Collections.Generic.ReferenceTypes.LinkedTree<long>.Node> {
                    tree.Root
                };
                var aaa = ll[rrrrr.Next(ll.Count)];
                {

                }
                ll.Add(aaa.AddFirst(id++));





                var a = tree.GetPreorderNodeInfo();
                var duzz = Plain.ValueTypes.Tree<long>.FromPreorderNodeInfo(a);
                var b = duzz.GetPreorderNodeInfo();
                var duzz2 = Plain.ValueTypes.Tree<long>.FromPreorderNodeInfo(b);

                var tree2 = new Collections.Generic.ReferenceTypes.LinkedTree<long>(duzz2.GetPreorderNodeInfo());

                Console.Out.WriteLine(tree2.ToString());

            }
            {
                UltimateOrb.Plain.ValueTypes.Stack<int> a = default;
                System.Threading.Thread.MemoryBarrier();
                a.TryInitialize(args.Length);
                System.Threading.Thread.MemoryBarrier();
                Console.Out.WriteLine(a.Count);
                return 0;
            }
            {
                System.Threading.Thread.MemoryBarrier();
                dddd1 = DefaultConstructor.Invoke<long?>();
                System.Threading.Thread.MemoryBarrier();
                return 0;
                Console.Out.WriteLine("...");
                Console.ReadKey(true);
            }

            {
                // new Program().Test_X2A330000000();
            }
            {
                System.Threading.Thread.MemoryBarrier();
                var b = DefaultConstructor.Invoke<long>();
                System.Threading.Thread.MemoryBarrier();
                Dummy<long>.Value = b;
                Console.Out.WriteLine(b);
                System.Threading.Thread.MemoryBarrier();
                var c = DefaultConstructor.Invoke<long?>();
                System.Threading.Thread.MemoryBarrier();
                Dummy<long?>.Value = c;
                Console.Out.WriteLine(c);
                Console.Out.WriteLine("...");
                Console.ReadKey(true);
            }
            {
                new Program().Test_3();
            }
            {
                var a = DefaultConstructor.Invoke<object>();
                Console.Out.WriteLine(a);
            }
            {
                var a = DefaultConstructor.Invoke<RuntimeTypeHandle>();
                Console.Out.WriteLine(a);
                try {
                    var b = a.GetModuleHandle();
                    Console.Out.WriteLine(b);
                } catch (Exception) {
                }
            }
            {
                var a = default(DefaultConstructor<System.Collections.Generic.List<long>>).Invoke();
                Console.Out.WriteLine(a);
                var b = default(DefaultConstructor<long>).Invoke();
                Console.Out.WriteLine(b);
                var c = DefaultConstructor.Invoke<long>();
                Console.Out.WriteLine(c);
                var d = DefaultConstructor.Invoke<System.Collections.Generic.List<long>>();
                Console.Out.WriteLine(d);
                Console.ReadKey(true);
            }
            {
                var deque1 = new Queue<long>(0);
                var iid = 1001;
                deque1.Unshift(iid);
            }
            var rr = new Random();
            var ff = 2345;
            for (var g = 1000; g > 0; --g) {
                var deque0 = new LinkedList<long>();
                var deque1 = new Queue<long>(0);
                var iid = 1001;
                for (var i = 0; 300 > i; ++i) {
                    var m = rr.NextDouble();
                    if (m < 0.150) {
                        if (deque0.Count > 0) {
                            Console.Out.WriteLine("Pop*1");
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                        continue;
                    } else if (m < 0.425) {
                        {
                            Console.Out.WriteLine("Push*1");
                            var d = iid++;
                            deque0.AddLast(d);
                            deque1.Push(d);
                        }
                    } else if (m < 0.475) {
                        if (deque0.Count >= ff) {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        Console.Out.WriteLine("Push*{0}", n0);
                        for (var n = n0; n > 0; --n) {
                            var d = iid++;
                            deque0.AddLast(d);
                            deque1.Push(d);
                        }
                    } else if (m < 0.490) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        Console.Out.WriteLine("Pop*{0}", n0);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                    } else if (m < 0.500) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = deque0.Count;
                        Console.Out.WriteLine("Pop*{0}", n0);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                    } else if (m < 0.650) {
                        if (deque0.Count > 0) {
                            Console.Out.WriteLine("Shift*1");
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                        continue;
                    } else if (m < 0.925) {
                        {
                            Console.Out.WriteLine("Unshift*1");
                            var d = iid++;
                            deque0.AddFirst(d);
                            deque1.Unshift(d);
                        }
                    } else if (m < 0.975) {
                        if (deque0.Count >= ff) {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        Console.Out.WriteLine("Unshift*{0}", n0);
                        for (var n = n0; n > 0; --n) {
                            var d = iid++;
                            deque0.AddFirst(d);
                            deque1.Unshift(d);
                        }
                    } else if (m < 0.990) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        Console.Out.WriteLine("Shift*{0}", n0);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                    } else if (m < 1.000) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = deque0.Count;
                        Console.Out.WriteLine("Shift*{0}", n0);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveFirst();
                            deque1.Shift();
                        }
                    }
                    {
                        var s0 = deque0.ToArray();
                        var s1 = deque1.ToArray();
                        var ss = s0.SequenceEqual(s1);
                        if (!ss) {
                            Xunit.Assert.True(false);
                        }
                    }
                    {
                        var s1 = deque1.ToArray();
                        var s1a = deque1.AsEnumerable().ToArray();
                        var ssa = s1.SequenceEqual(s1a);
                        if (!ssa) {
                            Xunit.Assert.True(false);
                        }
                    }
                }
                Console.Out.WriteLine("...");
            }
            {
                var deque0 = new LinkedList<long>();
                var deque1 = new Queue<long>(0);
                var iid = 1001;
                for (var i = 0; 10000 > i; ++i) {
                    var m = rr.NextDouble();
                    if (m < 0.30) {
                        if (deque0.Count > 0) {
                            Console.Out.WriteLine("Pop*1");
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                        continue;
                    } else if (m < 0.85) {
                        {
                            Console.Out.WriteLine("Push*1");
                            var d = iid++;
                            deque0.AddLast(d);
                            deque1.Push(d);
                        }
                    } else if (m < 0.95) {
                        var n0 = 1 + rr.Next(deque0.Count);
                        Console.Out.WriteLine("Push*{0}", n0);
                        for (var n = n0; n > 0; --n) {
                            var d = iid++;
                            deque0.AddLast(d);
                            deque1.Push(d);
                        }
                    } else if (m < 0.98) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = 1 + rr.Next(deque0.Count);
                        Console.Out.WriteLine("Pop*{0}", n0);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                    } else if (m <= 1.0) {
                        if (deque0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = deque0.Count;
                        Console.Out.WriteLine("Pop*{0}", n0);
                        for (var n = n0; n > 0; --n) {
                            deque0.RemoveLast();
                            deque1.Pop();
                        }
                    }
                    {
                        var s0 = deque0.ToArray();
                        var s1 = deque1.ToArray();
                        var ss = s0.SequenceEqual(s1);
                        if (!ss) {
                            Xunit.Assert.True(false);
                        }
                    }
                }
            }
            {
                var stack1 = new Queue<long>(0);
                var stack0 = new System.Collections.Generic.Stack<long>(0);
                var iid = 1001;
                for (var i = 0; 10000 > i; ++i) {
                    var m = rr.NextDouble();
                    if (m < 0.30) {
                        if (stack0.Count > 0) {
                            Console.Out.WriteLine("Pop*1");
                            stack0.Pop();
                            stack1.Pop();
                        }
                        continue;
                    } else if (m < 0.85) {
                        {
                            Console.Out.WriteLine("Push*1");
                            var d = iid++;
                            stack0.Push(d);
                            stack1.Push(d);
                        }
                    } else if (m < 0.95) {
                        var n0 = 1 + rr.Next(stack0.Count);
                        Console.Out.WriteLine("Push*{0}", n0);
                        for (var n = n0; n > 0; --n) {
                            var d = iid++;
                            stack0.Push(d);
                            stack1.Push(d);
                        }
                    } else if (m < 0.98) {
                        if (stack0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = 1 + rr.Next(stack0.Count);
                        Console.Out.WriteLine("Pop*{0}", n0);
                        for (var n = n0; n > 0; --n) {
                            stack0.Pop();
                            stack1.Pop();
                        }
                    } else if (m <= 1.0) {
                        if (stack0.Count > 0) {
                        } else {
                            continue;
                        }
                        var n0 = stack0.Count;
                        Console.Out.WriteLine("Pop*{0}", n0);
                        for (var n = n0; n > 0; --n) {
                            stack0.Pop();
                            stack1.Pop();
                        }
                    }
                    {
                        var s0 = stack0.ToArray();
                        Array.Reverse(s0);
                        var s1 = stack1.ToArray();
                        var ss = s0.SequenceEqual(s1);
                        if (!ss) {
                            Xunit.Assert.True(false);
                        }
                    }
                }
            }
            return 0;
        }
    }
}
