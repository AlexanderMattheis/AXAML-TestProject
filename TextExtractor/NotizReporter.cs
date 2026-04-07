namespace TextExtractor;

/// <summary>
/// Reported Ende.
/// </summary>
internal static class NotizReporter
{
    /// <summary>
    /// Meldet den Ende des Programms.
    /// </summary>
    /// <param name="anzahlHtmlDateien">Anzahl der HTML-Dateien</param>
    /// <param name="anzahlNotizBloecke">Anzahl der Notiz-Blöcke</param>
    /// <param name="markdownPfad">Pfad zur Markdown-Datei</param>
    /// <returns>
    /// 0 - erfolgreicher Status
    /// </returns>
    internal static int ReportEnde(int anzahlHtmlDateien, int anzahlNotizBloecke, string markdownPfad)
    {
        Console.WriteLine($"Scanned Files: {anzahlHtmlDateien}, Found Blocks: {anzahlNotizBloecke}");
        Console.WriteLine("Output File: " + markdownPfad);
        return 0;
    }
    
}