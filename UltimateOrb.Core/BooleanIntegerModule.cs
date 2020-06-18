namespace UltimateOrb.Utilities {

    public static partial class BooleanIntegerModule {

        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int ToInteger(this bool value) {
            var result = 0;
            if (value) {
                result = 1;
            }
            return result;
        }

        /// <devdoc>
        ///     <para>
        ///         ECMA-335: (III.1.1.1 Numeric data types - Short integers)
        ///         <c>bool</c> or <see cref="System.Boolean"/> (8-bit) is zero-extended.
        ///     </para>
        ///     <para>
        ///         The body of this method will be modified by the build tools.
        ///     </para>
        /// </devdoc>
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        [ILMethodBodyAttribute(@"
            LdArg.0
            Ret
        ")]
        public static int AsIntegerUnsafe(this bool canonical) {
            return canonical.ToInteger();
        }

        /// <devdoc>
        ///     <para>
        ///         ECMA-335: (III.1.1.1 Numeric data types - Short integers)
        ///         <c>bool</c> or <see cref="System.Boolean"/> (8-bit) is zero-extended.
        ///     </para>
        ///     <para>
        ///         The body of this method will be modified by the build tools.
        ///     </para>
        /// </devdoc>
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        [ILMethodBodyAttribute(@"
            LdArg.0
            Ret
        ")]
        public static uint AsUIntegerUnsafe(this bool canonical) {
            return unchecked((uint)canonical.ToInteger());
        }

        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int ToIntegerFromCanonical(this bool canonical) {
            System.Diagnostics.Debug.Assert(unchecked((uint)canonical.AsIntegerUnsafe()) <= 1);
            return canonical.AsIntegerUnsafe();
        }

        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.MayFail)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.Contracts.PureAttribute()]
        public static int ToIntegerFromCanonicalChecked(this bool canonical) {
            _ = checked(unchecked((uint)(int)(-1)) + unchecked((uint)canonical.AsIntegerUnsafe()));
            return canonical.AsIntegerUnsafe();
        }
    }
}
