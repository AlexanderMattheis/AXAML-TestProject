namespace TextExtractorGUI.Records;

/// <summary>
/// Definition der Sprache.
/// </summary>
/// <param name="DisplayName">angezeigter Name der Sprache</param>
/// <param name="CultureName">Name der Kultur im System</param>
public sealed record Sprache(string DisplayName, string CultureName)
{
    public override string ToString() => DisplayName;
}