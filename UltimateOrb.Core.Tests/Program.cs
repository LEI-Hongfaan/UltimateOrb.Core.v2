using FsCheck.Xunit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace UltimateOrb.Core.Tests {
    using UltimateOrb.Collections.Generic;
    using UltimateOrb.Plain.ValueTypes;

    public partial class Program {

        private static AsyncLocal<long> item_id_1 = new AsyncLocal<long>();

        private static AsyncLocal<Queue<long>> collection_1 = new AsyncLocal<Queue<long>>();

        private static AsyncLocal<Random> random = new AsyncLocal<Random>();

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


        private class AA : Collections.Generic.IStack<int>, IEnumerable<int> {

            private struct AAA : IFunc<int?, int, int?> {

                public int? Invoke(int? arg1, int arg2) {
                    return !(arg1 < arg2) ? arg2 : arg1;
                }
            }

            private struct AAAss : IFunc<Plain.ValueTypes.Stack<(int, int?)>>, IFunc<int, Plain.ValueTypes.Stack<(int, int?)>> {

                public Stack<(int, int?)> Invoke() {
                    return new Stack<(int, int?)>();
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
                var b = this._._.buffer;
                var c = this._._.count;
                for (; c > 0;) {
                    yield return b[--c].Item1;
                }
            }


            private struct Adfsad : IFunc<(int, int?), int> {

                public int Invoke((int, int?) arg) {
                    return arg.Item1;
                }
            }

            public int[] ToArray() {
                return this._._.ToArray<int, Adfsad>();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                throw new NotImplementedException();
            }
        }


        private class AB : Collections.Generic.IStack<int>, IEnumerable<int> {

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

        private static int Main(string[] args) {
            {
                new Program().Test_3();
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
