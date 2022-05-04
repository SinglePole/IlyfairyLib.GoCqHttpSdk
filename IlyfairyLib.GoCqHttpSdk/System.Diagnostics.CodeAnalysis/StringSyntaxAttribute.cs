namespace System.Diagnostics.CodeAnalysis;

#if !NET7_0_OR_GREATER
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class StringSyntaxAttribute : Attribute
{
	public StringSyntaxAttribute(string syntax) { }
}
#endif