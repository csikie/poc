using System.Reflection;

namespace poc.Infrastructure;

/// <summary>
/// Marker class for easily referencing the Infrastructure project assembly.
/// </summary>
public sealed class AssemblyReference
{
    /// <summary>
    /// The <see cref="Assembly"/> containing this class.
    /// </summary>
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}