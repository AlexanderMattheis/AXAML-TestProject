namespace TextExtractor.Extraktoren.Normalisierer;

/// <summary>
/// Erstellt einen normalisierten Markdown-Text.
/// </summary>
internal static class MarkdownNormalisierer
{
    /// <summary>
    /// Liefert einen normalisierten Markdown-Text zurück.
    /// </summary>
    /// <param name="text">Text, welcher zu Markdown umgewandelt werden soll</param>
    /// <returns>
    /// Normalisierten Markdown-Text
    /// </returns>
    internal static string GetNormalisiert(string text)
    {
        // 1. vereinheitliche Zeilenenden auf "\n"
        string zeilenNormalisierterText = GetVereinheitlichtenText(text);

        // 2. splitte und trimme jede Zeile
        List<string> zeilen = GetGetrimmteZeilen(zeilenNormalisierterText);

        // 3. entferne leere Zeilen am Anfang und Ende
        EntferneLeerzeilenAussen(zeilen);

        // 4. reduziere aufeinanderfolgende Leerzeilen auf max. 1 
        List<string> normalisierteZeilen = GetNormalisierteZeilen(zeilen);

        // 5. erstelle Text mit "\n" als Zeilenende
        return string.Join("\n", normalisierteZeilen);
    }

    /// <summary>
    /// Vereinheitlicht Zeilenenden auf <c>\n</c>.
    /// </summary>
    /// <param name="text">Text, welcher zu Markdown umgewandelt werden soll</param>
    /// <returns>
    /// Text mit vereinheitlichten Zeilenenden
    /// </returns>
    private static string GetVereinheitlichtenText(string text)
    {
        return text
            .Replace("\r\n", "\n")
            .Replace('\r', '\n');
    }

    /// <summary>
    /// Splittet den Text in Zeilen und trimmt jede Zeile.
    /// </summary>
    /// <param name="text">Text mit vereinheitlichten Zeilenenden</param>
    /// <returns>
    /// Liste getrimmter Zeilen
    /// </returns>
    private static List<string> GetGetrimmteZeilen(string text)
    {
        return text.Split('\n')
            .Select(zeile => zeile.Trim())
            .ToList();
    }

    /// <summary>
    /// Entfernt leere Zeilen am Anfang und Ende der Liste (in-place).
    /// </summary>
    /// <param name="zeilen">
    /// Liste von Zeilen
    /// </param>
    private static void EntferneLeerzeilenAussen(List<string> zeilen)
    {
        while (zeilen.Count > 0 && zeilen[0].Length == 0) zeilen.RemoveAt(0);
        while (zeilen.Count > 0 && zeilen[^1].Length == 0) zeilen.RemoveAt(zeilen.Count - 1);
    }

    /// <summary>
    /// Reduziert aufeinanderfolgende Leerzeilen auf maximal eine Leerzeile.
    /// </summary>
    /// <param name="zeilen">Liste von Zeilen</param>
    /// <returns>
    /// Normalisierte Zeilen
    /// </returns>
    private static List<string> GetNormalisierteZeilen(List<string> zeilen)
    {
        List<string> normalisierteZeilen = new List<string>(zeilen.Count);
        bool isVorherigeLeerzeile = false; // beschreibt, ob vorherige Zeile leer war

        // laufe über alle Zeilen
        foreach (string zeile in zeilen)
        {
            bool isLeerzeile = zeile.Length == 0;

            // wenn: aktuelle Zeile leer ist UND vorherige Zeile leer ist
            // dann: suche weiter
            if (isLeerzeile && isVorherigeLeerzeile) continue;
            normalisierteZeilen.Add(zeile);

            isVorherigeLeerzeile = isLeerzeile; // aktualisiert Typ vorheriger Zeile
        }

        return normalisierteZeilen;
    }
    
}