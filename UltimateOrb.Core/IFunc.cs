using System;
using System.Collections.Generic;

namespace UltimateOrb {

    public partial interface IFunc<out TResult> : IO.IFunc<TResult> {

        // TResult Invoke();
    }

    public partial interface IFunc<in T, out TResult> : IO.IFunc<T, TResult> {

        // TResult Invoke(T arg);
    }

    public partial interface IFunc<in T1, in T2, out TResult> : IO.IFunc<T1, T2, TResult> {

        // TResult Invoke(T1 arg1, T2 arg2);
    }

    public partial interface IPredicate<in T> : IFunc<T, bool> {

        // bool Invoke(T obj);
    }

    public partial struct FuncAsIFunc<TResult> : IFunc<TResult> {

        private readonly Func<TResult> value;

        internal FuncAsIFunc(Func<TResult> value) {
            this.value = value;
        }

        public TResult Invoke() {
            return this.value();
        }

        /*
        TResult IFunc<TResult>.Invoke() {
            return this.Invoke();
        }
        */
    }

    public partial struct FuncAsIFunc<T, TResult> : IFunc<T, TResult> {

        private readonly Func<T, TResult> value;

        internal FuncAsIFunc(Func<T, TResult> value) {
            this.value = value;
        }

        public TResult Invoke(T arg) {
            return this.value(arg);
        }

        /*
        TResult IFunc<T, TResult>.Invoke(T arg) {
            return this.Invoke(arg);
        }
        */
    }

    public partial struct FuncAsIFunc<T1, T2, TResult> : IFunc<T1, T2, TResult> {

        private readonly Func<T1, T2, TResult> value;

        internal FuncAsIFunc(Func<T1, T2, TResult> value) {
            this.value = value;
        }

        public TResult Invoke(T1 arg1, T2 arg2) {
            return this.value(arg1, arg2);
        }

        /*
        TResult IFunc<T1, T2, TResult>.Invoke(T1 arg1, T2 arg2) {
            return this.Invoke(arg1, arg2);
        }
        */
    }

    public partial struct PredicateAsIPredicate<T> : IPredicate<T> {

        private readonly Predicate<T> value;

        internal PredicateAsIPredicate(Predicate<T> value) {
            this.value = value;
        }

        public bool Invoke(T obj) {
            return this.value(obj);
        }

        /*
        bool IFunc<T, bool>.Invoke(T obj) {
            return this.Invoke(obj);
        }
        */
    }

    public static partial class DelegateConverter {

        public static FuncAsIFunc<TResult> AsIFunc<TResult>(this Func<TResult> value) {
            return new FuncAsIFunc<TResult>(value);
        }

        public static Func<TResult> AsFunc<TResult, TFunc>(this TFunc value) where TFunc : IFunc<TResult> {
            return value.Invoke;
        }

        public static FuncAsIFunc<T, TResult> AsIFunc<T, TResult>(this Func<T, TResult> value) {
            return new FuncAsIFunc<T, TResult>(value);
        }

        public static Func<T, TResult> AsFunc<T, TResult, TFunc>(this TFunc value) where TFunc : IFunc<T, TResult> {
            return value.Invoke;
        }

        public static FuncAsIFunc<T1, T2, TResult> AsIFunc<T1, T2, TResult>(this Func<T1, T2, TResult> value) {
            return new FuncAsIFunc<T1, T2, TResult>(value);
        }

        public static Func<T1, T2, TResult> AsFunc<T1, T2, TResult, TFunc>(this TFunc value) where TFunc : IFunc<T1, T2, TResult> {
            return value.Invoke;
        }

        public static PredicateAsIPredicate<T> AsIPredicate<T>(this Predicate<T> value) {
            return new PredicateAsIPredicate<T>(value);
        }

        public static Predicate<T> AsPredicate<T, TPredicate>(this TPredicate value) where TPredicate : IPredicate<T> {
            return value.Invoke;
        }
    }
}
