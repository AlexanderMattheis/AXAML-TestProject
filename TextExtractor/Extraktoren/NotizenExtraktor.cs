using System.Text;
using HtmlAgilityPack;
using TextExtractor.Extraktoren.Normalisierer;

namespace TextExtractor.Extraktoren;

/// <summary>
/// Extrahiert Notizen-Text aus HTML-Dateien.
/// </summary>
internal static class NotizenExtraktor
{
    /// <summary>
    /// Extrahiert den vollständigen Notiztext aus den gefundenen HTML-Dateien.
    /// </summary>
    /// <param name="htmlDateien">HTML-Dateien aus denen die Texte extrahiert werden</param>
    /// <param name="anzahlNotizBloecke">Anzahl der gefundenen Notizblöcke in HTML-Dateien</param>
    /// <returns>
    /// Markdown-Text der Notizen
    /// </returns>
    internal static string Get(List<string> htmlDateien, out int anzahlNotizBloecke)
    {
        StringBuilder builder = new();
        builder.AppendLine("# Notizen"); // Markdown-Überschrift

        anzahlNotizBloecke = 0;

        // laufe über jede HTML-Datei
        foreach (string htmlDatei in htmlDateien)
        {
            string notiz = ExtrahiereNotiz(htmlDatei);
            
            // wenn: kein Text vorhanden
            // dann: suche weiter
            if (notiz == string.Empty) continue;

            anzahlNotizBloecke++;
            
            builder.AppendLine($"## {Path.GetFileNameWithoutExtension(htmlDatei)}");
            builder.AppendLine();
            builder.AppendLine(notiz);
        }

        return builder.ToString();
    }
    
    /// <summary>
    /// Extrahiert die Notiz aus der HTML-Datei.
    /// </summary>
    /// <param name="htmlDatei">Pfad zur HTML-Datei</param>
    /// <returns>
    /// Notiz als Markdown-Text
    /// </returns>
    /// <remarks>
    /// In jeder verlinkten HTML-Datei wird maximal
    /// ein Notiz-Text <aside class="notes"> ... </aside>
    /// gefunden.
    /// </remarks>
    private static string ExtrahiereNotiz(string htmlDatei)
    {
        HtmlDocument htmlDokument = new HtmlDocument();
        
        // 1. Lese HTML-Datei ein
        string html = File.ReadAllText(htmlDatei, Encoding.UTF8);
        htmlDokument.LoadHtml(html);

        // 2. Suche nach allen <aside>-Elementen mit class="notes"
        // unter Verwendung der XML-Abfragesprache XPath:
        // <aside class="notes"> ... </aside>
        HtmlNode? notizKnoten = htmlDokument.DocumentNode
            .SelectSingleNode("//aside[@class='notes']");
        
        if (notizKnoten == null) return string.Empty;

        // 3. Normalisiere Text des <aside>-Elements
        // InnerText: reiner Text des Elements ohne HTML-Tags
        // DeEntitize: ersetzt Zeichen wie &amp; durch &
        return MarkdownNormalisierer.GetNormalisiert(
            HtmlEntity.DeEntitize(notizKnoten.InnerText));
    }
    
}