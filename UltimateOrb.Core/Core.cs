using System;

[assembly: System.CLSCompliantAttribute(true)]
[assembly: System.Security.SecurityRulesAttribute(System.Security.SecurityRuleSet.Level2)]
[assembly: System.Security.SecurityTransparentAttribute()]

namespace UltimateOrb {
    using System.Runtime.InteropServices;

    [ComVisibleAttribute(true)]
    [SerializableAttribute()]
    public struct Void {
    }

    [AttributeUsageAttribute(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ImplementShouldNotHideBaseOverloadsAttribute : Attribute {
    }
}