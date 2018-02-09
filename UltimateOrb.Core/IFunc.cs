﻿using System;
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

    public partial struct BclFuncAsFunc<TResult> : IFunc<TResult> {

        private readonly Func<TResult> value;

        public BclFuncAsFunc(Func<TResult> value) {
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

    public partial struct BclFuncAsFunc<T, TResult> : IFunc<T, TResult> {

        private readonly Func<T, TResult> value;

        public BclFuncAsFunc(Func<T, TResult> value) {
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

    public partial struct BclFuncAsFunc<T1, T2, TResult> : IFunc<T1, T2, TResult> {

        private readonly Func<T1, T2, TResult> value;

        public BclFuncAsFunc(Func<T1, T2, TResult> value) {
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

    public partial struct BclPredicateAsPredicate<T> : IPredicate<T> {

        private readonly Predicate<T> value;

        public BclPredicateAsPredicate(Predicate<T> value) {
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

        public static BclFuncAsFunc<TResult> AsFunc<TResult>(this Func<TResult> value) {
            return new BclFuncAsFunc<TResult>(value);
        }

        public static Func<TResult> AsBclFunc<TResult, TFunc>(this TFunc value) where TFunc : IFunc<TResult> {
            return value.Invoke;
        }

        public static BclFuncAsFunc<T, TResult> AsFunc<T, TResult>(this Func<T, TResult> value) {
            return new BclFuncAsFunc<T, TResult>(value);
        }

        public static Func<T, TResult> AsBclFunc<T, TResult, TFunc>(this TFunc value) where TFunc : IFunc<T, TResult> {
            return value.Invoke;
        }

        public static BclFuncAsFunc<T1, T2, TResult> AsFunc<T1, T2, TResult>(this Func<T1, T2, TResult> value) {
            return new BclFuncAsFunc<T1, T2, TResult>(value);
        }

        public static Func<T1, T2, TResult> AsBclFunc<T1, T2, TResult, TFunc>(this TFunc value) where TFunc : IFunc<T1, T2, TResult> {
            return value.Invoke;
        }

        public static BclPredicateAsPredicate<T> AsPredicate<T>(this Predicate<T> value) {
            return new BclPredicateAsPredicate<T>(value);
        }

        public static Predicate<T> AsBclPredicate<T, TPredicate>(this TPredicate value) where TPredicate : IPredicate<T> {
            return value.Invoke;
        }
    }
}
