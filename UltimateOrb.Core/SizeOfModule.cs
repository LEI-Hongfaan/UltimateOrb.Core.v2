using System;

namespace UltimateOrb.Utilities {

    /// <summary>
    ///     <para>
    ///         Provides static methods for getting the managed size of the specified type.
    ///     </para>
    /// </summary>
    /// <devdoc>
    ///     <para>
    ///         This type contains members will be modified by the build tools.
    ///         The build tools identify the type and those members by their names.
    ///         Whenever you rename this type or such a member, update the build tools accordingly.
    ///     </para>
    /// </devdoc>
    public static partial class SizeOfModule {

        /// <summary>
        ///     <para>Represents the number of bits in a byte.</para>
        /// </summary>
        public const int BitsPerByte = 8;

        /// <summary>
        ///     <para>
        ///         Returns the bit size of the specified type.
        ///     </para>
        /// </summary>
        /// <typeparam name="T">
        ///     <para>
        ///         Specifies the type.
        ///     </para>
        /// </typeparam>
        /// <returns>
        ///     <para>
        ///         The managed size, in bits, of a type.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         For a reference type, the size returned is the size of a reference value of the corresponding type, not the size of the data stored in objects referred to by a reference value.
        ///     </para>
        /// </remarks>
        /// <devdoc>
        ///     <para>
        ///         ECMA-335: Note that the runtime size of a value type shall not exceed 1 MByte (0x100000 bytes).
        ///     </para>
        /// </devdoc>
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        // [System.Diagnostics.Contracts.PureAttribute()]
        public static int BitSizeOf<T>() {
            return unchecked(SizeOfModule.BitsPerByte.ToUnsignedUnchecked() * SizeOfModule.SizeOf<T>().ToUnsignedUnchecked()).ToSignedUnchecked();
        }

        /// <summary>
        ///     <para>
        ///         Returns the result of the CIL <c>sizeof</c> instruction of the specified type.
        ///     </para>
        /// </summary>
        /// <typeparam name="T">
        ///     <para>
        ///         Specifies the type parameter of the instruction.
        ///     </para>
        /// </typeparam>
        /// <returns>
        ///     <para>
        ///         The managed size, in bytes, of a type.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         For a reference type, the size returned is the size of a reference value of the corresponding type, not the size of the data stored in objects referred to by a reference value.
        ///     </para>
        /// </remarks>
        /// <devdoc>
        ///     <para>
        ///         ECMA-335: Note that the runtime size of a value type shall not exceed 1 MByte (0x100000 bytes).
        ///     </para>
        ///     <para>
        ///         The body of this method will be modified by the build tools.
        ///         The build tools identify the method by their names.
        ///         Whenever you rename this method, update the build tools accordingly.
        ///     </para>
        /// </devdoc>
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        // [System.Diagnostics.Contracts.PureAttribute()]
        public static int SizeOf<T>() {
            throw (NotImplementedException)null;
        }
    }
}
