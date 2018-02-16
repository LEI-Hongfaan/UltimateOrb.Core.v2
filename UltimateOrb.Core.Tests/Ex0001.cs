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

        }

        private static void AddWellKnownInstances__mempty() {

            // T[]
            mempty.T0<int[]>.D0.Candidate = Array_Empty<int>.Value;
            mempty.T0<uint[]>.D0.Candidate = Array_Empty<uint>.Value;
            mempty.T0<long[]>.D0.Candidate = Array_Empty<long>.Value;
            mempty.T0<ulong[]>.D0.Candidate = Array_Empty<ulong>.Value;
            mempty.T0<byte[]>.D0.Candidate = Array_Empty<byte>.Value;
            mempty.T0<sbyte[]>.D0.Candidate = Array_Empty<sbyte>.Value;
            mempty.T0<double[]>.D0.Candidate = Array_Empty<double>.Value;
            mempty.T0<float[]>.D0.Candidate = Array_Empty<float>.Value;
            mempty.T0<short[]>.D0.Candidate = Array_Empty<short>.Value;
            mempty.T0<ushort[]>.D0.Candidate = Array_Empty<ushort>.Value;
            mempty.T0<char[]>.D0.Candidate = Array_Empty<char>.Value;
            mempty.T0<string[]>.D0.Candidate = Array_Empty<string>.Value;
            mempty.T0<object[]>.D0.Candidate = Array_Empty<object>.Value;

            // Array<T>
            mempty.T0<Array<int>>.D0.Candidate = Array<int>.Empty.Value;
            mempty.T0<Array<uint>>.D0.Candidate = Array<uint>.Empty.Value;
            mempty.T0<Array<long>>.D0.Candidate = Array<long>.Empty.Value;
            mempty.T0<Array<ulong>>.D0.Candidate = Array<ulong>.Empty.Value;
            mempty.T0<Array<byte>>.D0.Candidate = Array<byte>.Empty.Value;
            mempty.T0<Array<sbyte>>.D0.Candidate = Array<sbyte>.Empty.Value;
            mempty.T0<Array<double>>.D0.Candidate = Array<double>.Empty.Value;
            mempty.T0<Array<float>>.D0.Candidate = Array<float>.Empty.Value;
            mempty.T0<Array<short>>.D0.Candidate = Array<short>.Empty.Value;
            mempty.T0<Array<ushort>>.D0.Candidate = Array<ushort>.Empty.Value;
            mempty.T0<Array<char>>.D0.Candidate = Array<char>.Empty.Value;


            mempty.T0<string[]>.D0.Candidate = Array_Empty<string>.Value;
            mempty.T0<object[]>.D0.Candidate = Array_Empty<object>.Value;

            mempty.T0<int[][]>.D0.Candidate = Array_Empty<int[]>.Value;
            mempty.T0<uint[][]>.D0.Candidate = Array_Empty<uint[]>.Value;
            mempty.T0<long[][]>.D0.Candidate = Array_Empty<long[]>.Value;
            mempty.T0<ulong[][]>.D0.Candidate = Array_Empty<ulong[]>.Value;

            mempty.T0<byte[][]>.D0.Candidate = Array_Empty<byte[]>.Value;
            mempty.T0<sbyte[][]>.D0.Candidate = Array_Empty<sbyte[]>.Value;
            mempty.T0<double[][]>.D0.Candidate = Array_Empty<double[]>.Value;
            mempty.T0<float[][]>.D0.Candidate = Array_Empty<float[]>.Value;

            mempty.T0<short[][]>.D0.Candidate = Array_Empty<short[]>.Value;
            mempty.T0<ushort[][]>.D0.Candidate = Array_Empty<ushort[]>.Value;
            mempty.T0<char[][]>.D0.Candidate = Array_Empty<char[]>.Value;

            mempty.T0<string[][]>.D0.Candidate = Array_Empty<string[]>.Value;
            mempty.T0<object[][]>.D0.Candidate = Array_Empty<object[]>.Value;

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



    public readonly partial struct mempty {

        public readonly partial struct a : MetaTags.Types.ITypeVariable, MetaTags.Types.IType {
        }

        public static readonly MetaTags.Types.ForAll<a,
            Constraints.Create<Monoid.Invoke<a>>,
            a> Type = default;

        public readonly partial struct T0<a> {

            internal readonly partial struct D0 {

                private static a s_Candidate;

                private static bool s_IsImplemented;

                private static bool s_IsInitialized;

                internal static a Candidate {

                    get => s_Candidate;

                    set => (s_Candidate = value).Comma(s_IsImplemented = true).Ignore();
                }
            }

            internal readonly partial struct D0<T> {

                private static T s_Candidate;

                private static bool s_IsImplemented;

                private static bool s_IsInitialized;

                internal static T Candidate {

                    get => s_Candidate;

                    set => (s_Candidate = value).Comma(s_IsImplemented = true).Ignore();
                }
            }

            public readonly partial struct Typed<T> {

                public static readonly T Value = GetValue<T>();
            }

            public static T GetValue<T>() {
                var t = typeof(a);
                if (typeof(System.Array) == t) {
                    return (T)typeof(Array_Empty<>).MakeGenericType(t.GetElementType()).GetProperty(nameof(Array_Empty<int>.Value), t).GetValue(null);
                }
                if (t.IsPrimitive) {
                    return default;
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
