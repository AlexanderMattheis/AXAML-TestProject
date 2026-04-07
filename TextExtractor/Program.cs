using TextExtractor.Extraktoren;

namespace TextExtractor;

/// <summary>
/// Erlaubt es Text aus einem Reveal-Projekt zu extrahieren und als Markdown-Datei rauszuschreiben.
/// </summary>
public static class Program
{
    /// <summary>
    /// Einstiegspunkt des Programms.
    /// </summary>
    /// <param name="args">Argumente verwendet zum Steuern der Extraktion</param>
    /// <returns>
    /// 0 - Erfolg,
    /// 1 - Fehler,
    /// 2 - Syntaxfehler
    /// </returns>
    /// <example>
    /// Einstieg: dotnet run -- index.html notes.md
    /// </example>
    public static int Main(string[] args)
    {
        // 0) Verarbeite Argumente
        int returnValue = ArgumenteProzessierer.Process(args,
            out string indexHtmlPfad, out string markdownPfad);

        // wenn: Fehler
        // dann: mit Fehlercode beenden
        if (returnValue != 0) return returnValue;

        // 1) Sammle Links
        List<string> htmlDateien = LinksExtraktor.Extract(indexHtmlPfad);

        // 2) Extrahiere Notizen
        string notizen = NotizenExtraktor.Get(htmlDateien, out int anzahlNotizBloecke);

        // 3) Schreibe Markdown-Datei
        DateiSchreiber.WriteMarkdownDatei(notizen, markdownPfad);

        return NotizReporter.ReportEnde(htmlDateien.Count, anzahlNotizBloecke, markdownPfad);
    }
    
}