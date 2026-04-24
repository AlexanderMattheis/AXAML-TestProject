namespace TextExtractorGUI.Models;

/// <summary>
/// Definition der Sprache.
/// </summary>
/// <param name="AnzeigeName">angezeigter Name der Sprache</param>
/// <param name="KulturName">Name der Kultur im System</param>
public sealed record Language(string AnzeigeName, string KulturName)
{
    /// <summary>
    /// Gibt den Namen der Sprache zurück.
    /// </summary>
    /// <returns>Name der Sprache</returns>
    public override string ToString() => AnzeigeName;
}