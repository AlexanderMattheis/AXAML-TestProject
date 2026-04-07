using System.Text;

namespace TextExtractor;

/// <summary>
/// Schreibt Notizen-Text in eine Markdown-Datei.
/// </summary>
internal static class DateiSchreiber
{
    /// <summary>
    /// Schreibt die Notizen in eine Markdown-Datei.
    /// </summary>
    /// <param name="notizen">zu schreibende Notizen</param>
    /// <param name="markdownPfad">Pfad zur Ausgabedatei</param>
    internal static void WriteMarkdownDatei(string notizen, string markdownPfad)
    {
        string? ordner = Path.GetDirectoryName(markdownPfad);
        
        // wenn: Ordner nicht existiert
        // dann: Ordner erstellen
        if (!string.IsNullOrWhiteSpace(ordner))
        {
            Directory.CreateDirectory(ordner);
        }
        
        File.WriteAllText(markdownPfad, notizen, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
    }
    
}