namespace TextExtractor;

/// <summary>
/// Verarbeitet Argumente des Benutzers.
/// </summary>
internal static class ArgumenteProzessierer
{
    /// <summary>
    /// Verarbeitet die Argumente.
    /// </summary>
    /// <param name="args">zu verarbeitende Argumente</param>
    /// <param name="indexHtmlPfad">Pfad zur 'index.html'</param>
    /// <param name="markdownPfad">Pfad zur Markdown-Datei</param>
    /// <returns>
    /// 0 - Erfolg,
    /// 1 - Fehler,
    /// 2 - Syntaxfehler
    /// </returns>
    internal static int Process(string[] args, 
        out string indexHtmlPfad, out string markdownPfad)
    {
        indexHtmlPfad = string.Empty;
        markdownPfad = string.Empty;
        
        // wenn: zu wenige Argumente angegeben wurden
        // dann: Syntaxfehler-Nachricht ausgeben und beenden
        if (args.Length < 2)
        {
            Console.Error.WriteLine("Usage: dotnet run -- <path/to/index.html> <output.md> [--scanAllHtml]");
            return 2;
        }

        indexHtmlPfad = Path.GetFullPath(args[0]);
        markdownPfad = Path.GetFullPath(args[1]);

        // wenn: index.html nicht gefunden wurde
        // dann: Fehler-Nachricht ausgeben und beenden
        if (!File.Exists(indexHtmlPfad))
        {
            Console.Error.WriteLine("'index.html' not found: " + indexHtmlPfad);
            return 1;
        }
        
        return 0;
    }

}