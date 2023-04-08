namespace Redirector;

public record Redirect
{
    public string? RedirectUrl { get; init; }
    public string? TargetUrl { get; init; }
    public int RedirectType { get; init; }
    public bool UseRelative { get; init; }
}