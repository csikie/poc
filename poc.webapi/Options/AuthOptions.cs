namespace poc.Options;

/// <summary>
/// Authentication options.
/// </summary>
public sealed class AuthOptions
{
    public const string SectionName = "Auth";
    
    /// <summary>
    /// Secret key for the token.
    /// </summary>
    public string Secret { get; set; } = default!;

    /// <summary>
    /// Valid issuer for the token.
    /// </summary>
    public string ValidIssuer { get; set; } = default!;

    /// <summary>
    /// Valid audiences for the token.
    /// </summary>
    public List<string> ValidAudience { get; set; } = default!;
}

