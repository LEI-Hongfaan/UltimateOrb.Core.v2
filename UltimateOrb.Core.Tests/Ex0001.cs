using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using UltimateOrb.Collections.Generic;
using UltimateOrb.Utilities;

namespace sffgafgadg {

}

namespace UltimateOrb.Ex0002 {
    using UltimateOrb.Ex0002.MetaTags;
    using UltimateOrb.Ex0002.MetaTags.Kinds;
    using UltimateOrb.Ex0002.MetaTags.Types;


    public static partial class AAAfdsafas {

    }

    public readonly partial struct Foldable : IKindable {

        public readonly partial struct Invoke<T>
            : MetaTags.Types.IConstraint
            where T : MetaTags.Types.IFunc<MetaTags.Types.IType, MetaTags.Types.IType> {

            public MetaAnd<System.Type> Minimal => throw new NotImplementedException();

            public TType GetValue<TMember, TType>() where TType : IType {
                throw new NotImplementedException();
            }

            public readonly partial struct Kind : IConstraintKind {
            }
        }

        public static readonly MetaTags.Kinds.Class<MetaTags.Kinds.TypeFunc<MetaTags.Kinds.ConcreteType, MetaTags.Kinds.ConcreteType>, MetaTags.Kinds.Constraint> Kind = default;

        public TKind GetKind<TKind>() where TKind : IKind {
            throw new NotImplementedException();
        }
    }

    public readonly partial struct fold {

        public readonly partial struct m : MetaTags.Types.ITypeVariable, MetaTags.Types.IType {
        }

        public readonly partial struct t : MetaTags.Types.ITypeVariable, MetaTags.Types.IFunc<IType, IType> {

            public readonly partial struct Invoke<T>
                : IType
                where T : IType {
            }
        }

        public static readonly MetaTags.Types.ForAll<m, MetaTags.Types.Unconstrained, MetaTags.Types.ForAll<t,
            Constraints.Create<Monoid.Invoke<m>, Foldable.Invoke<t>>,
           MetaTags.Types.Func<t.Invoke<m>, m>>> Type = default;

        public readonly partial struct T1<m> {

            public readonly partial struct T0<t> {



                public T GetValue<T>() {
                    if (typeof(System.Array) == typeof(m)) {
                        if (typeof(Int32[]) == typeof(t)) {
                            return (T)(object)(System.Func<Int32[][], Int32[]>)(x => (
                            from y in x
                            from z in y
                            select z
                            ).ToArray()
                            );
                        }
                    }
                    throw new NotImplementedException();
                }
            }
        }
    }

    public readonly partial struct Constraints {

        public readonly partial struct Create<T>
            : MetaTags.Types.IConstraints
            where T : MetaTags.Types.IConstraint {

            public TEnumerable GetValue<T0, TEnumerable>()
                where T0 : IConstraint
                where TEnumerable : IEnumerable<T0> {
                return (TEnumerable)(object)new[] { (T0)(object)default(T), };
            }
        }

        public readonly partial struct Create<T1, T2>
            : MetaTags.Types.IConstraints
            where T1 : MetaTags.Types.IConstraint
            where T2 : MetaTags.Types.IConstraint {

            public TEnumerable GetValue<T0, TEnumerable>()
                 where T0 : IConstraint
                 where TEnumerable : IEnumerable<T0> {
                return (TEnumerable)(object)new[] { (T0)(object)default(T1), (T0)(object)default(T2), };
            }
        }
    }

    public partial interface IKindable {

        TKind GetKind<TKind>()
            where TKind : MetaTags.Kinds.IKind;
    }
    public readonly partial struct All {
    }

    public readonly partial struct Any {
    }

    public readonly partial struct Sum {
    }

    public readonly partial struct Product {
    }

    public readonly partial struct Monoid : IKindable {

        public readonly partial struct Invoke<T>
            : MetaTags.Types.IConstraint
            where T : IType {

            public MetaAnd<System.Type> Minimal => throw new NotImplementedException();

            public TType GetValue<TMember, TType>() where TType : IType {
                throw new NotImplementedException();
            }

            public static readonly MetaTags.Kinds.Constraint Kind = default;
        }

        public static readonly MetaTags.Kinds.Class<MetaTags.Kinds.ConcreteType, MetaTags.Kinds.Constraint> Kind = default;

        public TKind GetKind<TKind>() where TKind : IKind {
            return (TKind)(object)Kind;
        }


        private static void AddWellKnownInstances() {
            AddWellKnownInstances__mempty();
            // ...
        }

        private static void AddWellKnownInstances__mempty() {
            // T[]
            D<mempty.T0<mempty.a>>.Candidate = (System.Func<Type, ReadOnlyWrapper<object>?>)(t => {
                // []
                if (t.IsArray) {
                    return typeof(Array_Empty<>).MakeGenericType(t.GetElementType()).GetField(nameof(Array_Empty<Void>.Value)).GetValue(null);
                }
                // ReadOnlyArray<>
                if (typeof(ReadOnlyArray<>) == t.GetGenericTypeDefinition()) {
                    return typeof(ReadOnlyArray<>).GetNestedType(nameof(ReadOnlyArray<Void>.Empty)).MakeGenericType(t.GetGenericArguments()).GetField(nameof(Array_Empty<Void>.Value)).GetValue(null);
                }
                // Array<>
                if (typeof(Array<>) == t.GetGenericTypeDefinition()) {
                    return typeof(Array<>).GetNestedType(nameof(ReadOnlyArray<Void>.Empty)).MakeGenericType(t.GetGenericArguments()).GetField(nameof(Array_Empty<Void>.Value)).GetValue(null);
                }
                return default;
            });
            // ()
            D<mempty.T0<Void>>.Candidate = DefaultConstructor.Invoke<Void>();
            D<mempty.T0<System.ValueTuple>>.Candidate = System.ValueTuple.Create();
            // bool
            D<mempty.T0<ReadOnlyWrapper<bool, All>>>.Candidate = true;
            D<mempty.T0<Wrapper<bool, All>>>.Candidate = true;
            D<mempty.T0<ReadOnlyWrapper<bool, Any>>>.Candidate = false;
            D<mempty.T0<Wrapper<bool, Any>>>.Candidate = false;
            // Sum
            D<mempty.T0<ReadOnlyWrapper<int, Sum>>>.Candidate = (int)0;
            D<mempty.T0<Wrapper<int, Sum>>>.Candidate = (int)0;
            D<mempty.T0<ReadOnlyWrapper<uint, Sum>>>.Candidate = (uint)0;
            D<mempty.T0<Wrapper<uint, Sum>>>.Candidate = (uint)0;
            D<mempty.T0<ReadOnlyWrapper<long, Sum>>>.Candidate = (long)0;
            D<mempty.T0<Wrapper<long, Sum>>>.Candidate = (long)0;
            D<mempty.T0<ReadOnlyWrapper<ulong, Sum>>>.Candidate = (ulong)0;
            D<mempty.T0<Wrapper<ulong, Sum>>>.Candidate = (ulong)0;
            D<mempty.T0<ReadOnlyWrapper<short, Sum>>>.Candidate = (short)0;
            D<mempty.T0<Wrapper<short, Sum>>>.Candidate = (short)0;
            D<mempty.T0<ReadOnlyWrapper<ushort, Sum>>>.Candidate = (ushort)0;
            D<mempty.T0<Wrapper<ushort, Sum>>>.Candidate = (ushort)0;
            D<mempty.T0<ReadOnlyWrapper<byte, Sum>>>.Candidate = (byte)0;
            D<mempty.T0<Wrapper<byte, Sum>>>.Candidate = (byte)0;
            D<mempty.T0<ReadOnlyWrapper<sbyte, Sum>>>.Candidate = (sbyte)0;
            D<mempty.T0<Wrapper<sbyte, Sum>>>.Candidate = (sbyte)0;
            D<mempty.T0<ReadOnlyWrapper<double, Sum>>>.Candidate = (double)0;
            D<mempty.T0<Wrapper<double, Sum>>>.Candidate = (double)0;
            D<mempty.T0<ReadOnlyWrapper<float, Sum>>>.Candidate = (float)0;
            D<mempty.T0<Wrapper<float, Sum>>>.Candidate = (float)0;
            D<mempty.T0<ReadOnlyWrapper<decimal, Sum>>>.Candidate = (decimal)0;
            D<mempty.T0<Wrapper<decimal, Sum>>>.Candidate = (decimal)0;
            D<mempty.T0<ReadOnlyWrapper<Int128, Sum>>>.Candidate = (Int128)0;
            D<mempty.T0<Wrapper<Int128, Sum>>>.Candidate = (Int128)0;
            D<mempty.T0<ReadOnlyWrapper<UInt128, Sum>>>.Candidate = (UInt128)0;
            D<mempty.T0<Wrapper<UInt128, Sum>>>.Candidate = (UInt128)0;
            D<mempty.T0<ReadOnlyWrapper<Mathematics.Exact.Rational64, Sum>>>.Candidate = (Mathematics.Exact.Rational64)0;
            // Product
            D<mempty.T0<ReadOnlyWrapper<int, Product>>>.Candidate = (int)1;
            D<mempty.T0<Wrapper<int, Product>>>.Candidate = (int)1;
            D<mempty.T0<ReadOnlyWrapper<uint, Product>>>.Candidate = (uint)1;
            D<mempty.T0<Wrapper<uint, Product>>>.Candidate = (uint)1;
            D<mempty.T0<ReadOnlyWrapper<long, Product>>>.Candidate = (long)1;
            D<mempty.T0<Wrapper<long, Product>>>.Candidate = (long)1;
            D<mempty.T0<ReadOnlyWrapper<ulong, Product>>>.Candidate = (ulong)1;
            D<mempty.T0<Wrapper<ulong, Product>>>.Candidate = (ulong)1;
            D<mempty.T0<ReadOnlyWrapper<short, Product>>>.Candidate = (short)1;
            D<mempty.T0<Wrapper<short, Product>>>.Candidate = (short)1;
            D<mempty.T0<ReadOnlyWrapper<ushort, Product>>>.Candidate = (ushort)1;
            D<mempty.T0<Wrapper<ushort, Product>>>.Candidate = (ushort)1;
            D<mempty.T0<ReadOnlyWrapper<byte, Product>>>.Candidate = (byte)1;
            D<mempty.T0<Wrapper<byte, Product>>>.Candidate = (byte)1;
            D<mempty.T0<ReadOnlyWrapper<sbyte, Product>>>.Candidate = (sbyte)1;
            D<mempty.T0<Wrapper<sbyte, Product>>>.Candidate = (sbyte)1;
            D<mempty.T0<ReadOnlyWrapper<double, Product>>>.Candidate = (double)1;
            D<mempty.T0<Wrapper<double, Product>>>.Candidate = (double)1;
            D<mempty.T0<ReadOnlyWrapper<float, Product>>>.Candidate = (float)1;
            D<mempty.T0<Wrapper<float, Product>>>.Candidate = (float)1;
            D<mempty.T0<ReadOnlyWrapper<decimal, Product>>>.Candidate = (decimal)1;
            D<mempty.T0<Wrapper<decimal, Product>>>.Candidate = (decimal)1;
            D<mempty.T0<ReadOnlyWrapper<Int128, Product>>>.Candidate = (Int128)1;
            D<mempty.T0<Wrapper<Int128, Product>>>.Candidate = (Int128)1;
            D<mempty.T0<ReadOnlyWrapper<UInt128, Product>>>.Candidate = (UInt128)1;
            D<mempty.T0<Wrapper<UInt128, Product>>>.Candidate = (UInt128)1;
            D<mempty.T0<ReadOnlyWrapper<Mathematics.Exact.Rational64, Product>>>.Candidate = (Mathematics.Exact.Rational64)1;
            // ...
        }

        private static readonly bool s_IsInitialized = GetIsInitialized();

        private static bool GetIsInitialized() {
            Initialize();
            return true;
        }

        public static bool IsInitialized {

            get => s_IsInitialized;
        }

        private static void Initialize() {
            AddWellKnownInstances();
        }
    }



    internal readonly partial struct D<TToken> {

        internal static object Candidate {

            set {
                if (null != value) {
                    var v = value;
                    var t = v.GetType();
                    var property = C.Type.MakeGenericType(typeof(TToken), t).GetProperty(nameof(C<Void>.Candidate), t);
                    property.SetValue(null, v);
                }
            }
        }

        internal readonly partial struct C {

            /*
            internal static readonly IDictionary<Type, Void> s_lookuptable_IsImplemeted = (IDictionary<Type, Void>)new System.Collections.Concurrent.ConcurrentDictionary<Type, Void>();

            internal static bool GetIsInstantiated(Type type) {
                return s_lookuptable_IsImplemeted.ContainsKey(type);
            }
            */

            internal static readonly Type Type = typeof(C<>);
        }

        internal readonly partial struct C<T> {

            private static T s_Candidate;

            private static bool s_IsImplemented;

            private static bool s_IsInitialized;

            public static T Candidate {

                get => s_Candidate;

                set => (s_Candidate = value).Comma(s_IsImplemented = true).Ignore();
            }

            public static bool IsImplemented {

                get => s_IsImplemented;
            }

            internal static bool IsInitialized {

                get => s_IsInitialized;

                set => (s_IsInitialized = value).Ignore();
            }
        }
    }

    public readonly partial struct mempty {

        public readonly partial struct Typed<T> {

            public static readonly T Value = GetValue<T>();
        }

        private static T GetValue<T>() {
            if (!Monoid.IsInitialized) {
                throw new NotImplementedException();
            }
            var t = GetValue0<T>();
            D<mempty>.C<T>.IsInitialized = true;
            if (!D<mempty.T0<a>>.C<T>.IsImplemented) {
                D<mempty.T0<a>>.C<T>.Candidate = t;
            }
            // type inferred
            // mempty.a == T
            if (!D<mempty.T0<T>>.C<T>.IsImplemented) {
                D<mempty.T0<T>>.C<T>.Candidate = t;
            }
            return t;
        }

        private static T GetValue0<T>() {
            if (D<mempty>.C<T>.IsInitialized) {
                return Typed<T>.Value;
            } else if (D<mempty>.C<T>.IsImplemented) {
                return D<mempty>.C<T>.Candidate;
            }
            return mempty.T0<a>.Typed<T>.Value;
        }

        public readonly partial struct a : MetaTags.Types.ITypeVariable, MetaTags.Types.IType {
        }

        public static readonly MetaTags.Types.ForAll<a,
            Constraints.Create<Monoid.Invoke<a>>,
            a> Type = default;

        public readonly partial struct T0<a> {

            public readonly partial struct Typed<T> {

                public static readonly T Value = GetValue<T>();
            }

            private static T GetValue<T>() {
                if (!Monoid.IsInitialized) {
                    throw new NotImplementedException();
                }
                var t = GetValue0<T>();
                D<mempty.T0<T>>.C<T>.IsInitialized = true;
                if (typeof(mempty.a) == typeof(a)) {
                    // type inferred
                    // mempty.a == T
                    if (!D<mempty.T0<T>>.C<T>.IsImplemented) {
                        D<mempty.T0<T>>.C<T>.Candidate = t;
                    }
                }
                if (!D<mempty>.C<T>.IsImplemented) {
                    D<mempty>.C<T>.Candidate = t;
                }
                return t;
            }

            private static T GetValue0<T>() {
                if (D<mempty.T0<a>>.C<T>.IsInitialized) {
                    return Typed<T>.Value;
                } else if (D<mempty.T0<a>>.C<T>.IsImplemented) {
                    return D<mempty.T0<a>>.C<T>.Candidate;
                }
                if (typeof(mempty.a) == typeof(a)) {                  
                    if (D<mempty.T0<a>>.C<System.Func<Type, ReadOnlyWrapper<object>?>>.IsImplemented) {
                        var c = D<mempty.T0<a>>.C<System.Func<Type, ReadOnlyWrapper<object>?>>.Candidate;
                        var b = c.Invoke(typeof(T));
                        if (b.HasValue) {
                            var a = b.GetValueOrDefault();
                            if (a.Value is T v) {
                                return v;
                            }
                        }
                    }
                    // type inferred
                    // mempty.a == T
                    return mempty.T0<T>.Typed<T>.Value;
                }
                // type inferred
                // mempty.a == T
                var t = typeof(T);
                if (t.IsGenericType) {
                    if (typeof(ReadOnlyWrapper<,>) == t.GetGenericTypeDefinition()) {
                        var gtas = t.GetGenericArguments();
                        var ta = gtas[0];
                        var tw = gtas[1];
                        var sdfa = typeof(D<>.C<>).MakeGenericType(typeof(mempty.T0<T>), ta);
                        var p = sdfa.GetProperty(nameof(D<Void>.C<Void>.IsImplemented));
                        if ((bool)(p.GetValue(null))) {
                            return (T)WrapperModule.ToReadOnlyWrapperDynamic(sdfa.GetProperty(nameof(D<Void>.C<Void>.Candidate)).GetValue(null), tw);
                        }
                    }
                    if (typeof(Wrapper<,>) == t.GetGenericTypeDefinition()) {
                        var gtas = t.GetGenericArguments();
                        var ta = gtas[0];
                        var tw = gtas[1];
                        var sdfa = typeof(D<>.C<>).MakeGenericType(typeof(mempty.T0<T>), ta);
                        var p = sdfa.GetProperty(nameof(D<Void>.C<Void>.IsImplemented));
                        if ((bool)(p.GetValue(null))) {
                            return (T)WrapperModule.ToWrapperDynamic(sdfa.GetProperty(nameof(D<Void>.C<Void>.Candidate)).GetValue(null), tw);
                        }
                    }
                }               
                throw new NotImplementedException();
            }
        }
    }

    namespace MetaTags {

        public readonly partial struct MetaNonnegative {

            public static MetaOr<T> Or<T>(T[] atoms) {
                return new MetaOr<T>(atoms);
            }

            public static MetaAnd<T> And<T>(T[] atoms) {
                return new MetaAnd<T>(atoms);
            }
        }

        public readonly partial struct MetaOr<T> {

            private readonly T[] atoms;

            public BclArrayAsReadOnly<T> Atoms {

                get => this.atoms.AsReadOnly();
            }

            private readonly MetaAnd<T>[] nonatoms;

            public BclArrayAsReadOnly<T> Nonatoms {

                get => this.atoms.AsReadOnly();
            }

            public static readonly MetaOr<T> Empty = new MetaOr<T>(Array_Empty<T>.Value, Array_Empty<MetaAnd<T>>.Value);

            public MetaOr(T[] atoms) {
                this.atoms = atoms;
                this.nonatoms = Array_Empty<MetaAnd<T>>.Value;
            }

            public MetaOr(T[] atoms, MetaAnd<T>[] nonatoms) {
                this.atoms = atoms;
                this.nonatoms = nonatoms;
            }
        }

        public readonly partial struct MetaAnd<T> {

            private readonly T[] atoms;

            public BclArrayAsReadOnly<T> Atoms {

                get => this.atoms.AsReadOnly();
            }

            private readonly MetaOr<T>[] nonatoms;

            public BclArrayAsReadOnly<T> Nonatoms {

                get => this.atoms.AsReadOnly();
            }

            public static readonly MetaAnd<T> Empty = new MetaAnd<T>(Array_Empty<T>.Value, Array_Empty<MetaOr<T>>.Value);

            public MetaAnd(T[] atoms) {
                this.atoms = atoms;
                this.nonatoms = Array_Empty<MetaOr<T>>.Value;
            }

            public MetaAnd(T[] atoms, MetaOr<T>[] nonatoms) {
                this.atoms = atoms;
                this.nonatoms = nonatoms;
            }
        }
    }

    namespace MetaTags.Types {

        public partial interface IType {
        }

        public partial interface ITypeVariable {
        }

        public readonly partial struct Type<TToken> : IType {
        }

        public partial interface IConstraint {

            MetaAnd<System.Type> Minimal {

                get;
            }

            TType GetValue<TMember, TType>() where TType : IType;
        }

        public partial interface IConstraints {

            TEnumerable GetValue<T, TEnumerable>()
                where T : IConstraint
                where TEnumerable : IEnumerable<T>;
        }

        public readonly partial struct Unconstrained : IConstraints {

            public TEnumerable GetValue<T, TEnumerable>()
                where T : IConstraint
                where TEnumerable : IEnumerable<T> {
                return (TEnumerable)(object)Array_Empty<T>.Value;
            }
        }

        public partial interface IFunc<T, TResult>
           : IType
           where T : IType
           where TResult : IType {
        }

        public readonly partial struct Func<T, TResult>
            : IType
            where T : IType
            where TResult : IType {
        }

        public readonly partial struct ForAll<TVariable, TConstraints, TType>
            : IType
            where TVariable : ITypeVariable
            where TConstraints : IConstraints
            where TType : IType {
        }
    }

    namespace MetaTags.Kinds {

        public partial interface IKind {
        }

        public partial interface ITypeDataKind : IKind {
        }

        public partial interface IDataKind : ITypeDataKind {
        }

        public readonly partial struct Data<TToken> : IDataKind {
        }

        public partial interface ITypeKind : ITypeDataKind {
        }

        public readonly partial struct Type<TToken> : ITypeKind {
        }

        public partial interface IConcreteTypeKind : ITypeDataKind {
        }

        public readonly partial struct ConcreteType : IConcreteTypeKind {
        }

        public partial interface IHigherTypeKind<in T, out TResult>
            : ITypeDataKind
            where T : ITypeDataKind
            where TResult : ITypeDataKind {
        }

        public readonly partial struct TypeFunc<T, TResult>
            : IHigherTypeKind<T, TResult>
            where T : ITypeDataKind
            where TResult : ITypeDataKind {
        }

        public partial interface IClassKind : IKind {
        }

        public partial interface IConstraintKind : IClassKind {
        }

        public partial struct Constraint : IConstraintKind {
        }

        public readonly partial struct Constraint<TToken> : IConstraintKind {
        }

        public partial interface IClassKind<in T, out TResult>
           : IClassKind
           where T : ITypeDataKind
           where TResult : IClassKind {
        }

        public readonly partial struct Class<T, TResult>
            : IClassKind<T, TResult>
            where T : ITypeDataKind
            where TResult : IClassKind {
        }
    }
}

namespace UltimateOrb.Ex0001 {

    public partial interface IType {

        T GetValue<T>();
    }

    public partial interface IQuantified {

        TConstructor GetValue<T, TConstructor>();
    }

    public partial interface IConstraint {

        T GetValue<T>();
    }

    public partial struct BclNullable : IQuantified {

        public TConstructor GetValue<T, TConstructor>() {
            throw new NotImplementedException();
            // return (TConstructor)(object)(Func<Int32, Int32>)(x => default);
        }
    }

    public readonly partial struct MetaOr<T> {

        private readonly T[] atoms;

        public BclArrayAsReadOnly<T> Atoms {

            get => this.atoms.AsReadOnly();
        }

        private readonly MetaAnd<T>[] nonatoms;

        public BclArrayAsReadOnly<T> Nonatoms {

            get => this.atoms.AsReadOnly();
        }

        public static readonly MetaOr<T> Empty = new MetaOr<T>(Array_Empty<T>.Value, Array_Empty<MetaAnd<T>>.Value);

        public MetaOr(T[] atoms) {
            this.atoms = atoms;
            this.nonatoms = Array_Empty<MetaAnd<T>>.Value;
        }

        public MetaOr(T[] atoms, MetaAnd<T>[] nonatoms) {
            this.atoms = atoms;
            this.nonatoms = nonatoms;
        }
    }

    public partial struct MetaAnd<T> {

        private readonly T[] atoms;

        public BclArrayAsReadOnly<T> Atoms {

            get => this.atoms.AsReadOnly();
        }

        private readonly MetaOr<T>[] nonatoms;

        public BclArrayAsReadOnly<T> Nonatoms {

            get => this.atoms.AsReadOnly();
        }

        public static readonly MetaAnd<T> Empty = new MetaAnd<T>(Array_Empty<T>.Value, Array_Empty<MetaOr<T>>.Value);

        public MetaAnd(T[] atoms) {
            this.atoms = atoms;
            this.nonatoms = Array_Empty<MetaOr<T>>.Value;
        }

        public MetaAnd(T[] atoms, MetaOr<T>[] nonatoms) {
            this.atoms = atoms;
            this.nonatoms = nonatoms;
        }
    }

    namespace MetaKindTags {

        public partial struct Unconstrained {

            public MetaAnd<Type> Minimal => default;

            public TType GetValue<TMember, TType>() where TType : IType {
                throw new NotImplementedException();
            }
        }

        public partial interface IConstraint {
        }

        public partial interface IConstraints {

            TEnumerable GetValue<T, TEnumerable>()
                where T : IConstraint
                where TEnumerable : IEnumerable<T>;
        }

        public partial interface IKindVariable : IKind {
        }

        public partial interface ITypeKind : IKind {
        }

        public partial struct TypeKind<T>
            : ITypeKind
            where T : IType {
        }

        public partial interface IConstraintKind : IKind {
        }

        public partial struct ConstraintKind<T>
            : IConstraintKind
            where T : MetaTypeTags.IConstraints {
        }

        public partial interface IKind {
        }

        public partial struct Func<T, TResult>
            : IKind
            where T : IKind
            where TResult : IKind {
        }

        public partial struct Quantified<TVariable, TConstraints, TKind>
            : IKind
            where TConstraints : IConstraints
            where TVariable : IKindVariable
            where TKind : IKind {
        }
    }

    namespace MetaTypeTags {

        public partial struct Unconstrained : IConstraint {

            public MetaAnd<Type> Minimal => default;

            public TType GetValue<TMember, TType>() where TType : IType {
                throw new NotImplementedException();
            }
        }

        public partial interface IConstraint {

            MetaAnd<Type> Minimal {

                get;
            }

            TType GetValue<TMember, TType>() where TType : IType;
        }

        public partial interface IConstraints {

            TEnumerable GetValue<T, TEnumerable>()
                where T : IConstraint
                where TEnumerable : IEnumerable<T>;
        }

        public partial interface IType {
        }

        public partial interface ITypeVariable : IType {
        }

        public partial struct Type<T> : IType {
        }

        public partial struct Func<T, TResult>
            : IType
            where T : IType
            where TResult : IType {
        }

        public partial struct Quantified<TVariable, TConstraints, TType>
            : IType
            where TConstraints : IConstraints
            where TVariable : ITypeVariable
            where TType : IType {
        }

        /*
        public partial interface IQuantified<TConstraint, TType>
            : IType
            where TConstraint : IConstraints
            where TType : IType {

            Quantified<TVariable, TConstraint, TType> GetValue<TVariable>() where TVariable: IType;
        }
        */
    }
    /*
   public partial struct Monoid__Constraint : MetaTypeTags.IConstraint {

       public MetaAnd<Type> Minimal => new MetaAnd<Type>(new[] { typeof(Monoid.mempty), typeof(Monoid.mappend) });

       public T GetValue<T>() {
           throw new NotImplementedException();
       }

       public TType GetValue<TMember, TType>() where TType : MetaTypeTags.IType {
           throw new NotImplementedException();
       }
   }

  public static  partial class dasfasdf {

       public partial struct k : MetaKindTags.IKindVariable {
       }

    MetaKindTags.Quantified<k, MetaKindTags.Unconstrained, MetaKindTags.Func<MetaKindTags.Func<k, k>, MetaKindTags.ConstraintKind<Monoid>>> Monoid;
   } 






   public partial struct Monoid : IQuantified {

       public TConstructor GetValue<T, TConstructor>() {

       }

       public partial struct a : MetaTypeTags.ITypeVariable {
       }

       public partial struct mempty
           : MetaTypeTags.IType {
       }

       public partial struct mappend
           : MetaTypeTags.IType {
       }

       public partial struct mconcat {


       }

       Quantified<a, , >
   }
   */
    public partial struct Int32__Add : IQuantified {

        public TConstructor GetValue<T, TConstructor>() {
            return (TConstructor)(object)(Func<Int32, Func<Int32, Int32>>)(x => y => checked(x + y));
            /*
            if (typeof(Int32) == typeof(T)) {
                if (typeof(Func<Int32, Func<Int32, Int32>>) == typeof(TConstructor)) {
                    return (TConstructor)(object)(Func<Int32, Func<Int32, Int32>>)(x => y => checked(x + y));
                }
            }
            return ThrowHelper.Throw<NotImplementedException, TConstructor>();
            */
        }
    }
}
