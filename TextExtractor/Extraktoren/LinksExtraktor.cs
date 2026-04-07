using System.Text;
using System.Text.RegularExpressions;

namespace TextExtractor.Extraktoren;

/// <summary>
/// Extrahiert alle Links aus einer 'index.html'.
/// </summary>
internal static partial class LinksExtraktor
{
    /// <summary>
    /// Name der Gruppe im Regex <see cref="DataIncludeRegex"/>.
    /// </summary>
    private const string REGEX_GRUPPEN_NAME = "path";
    
    /// <summary>
    /// Compile-Zeit generiertes Regex findet data-include="*.html".
    /// </summary>
    /// <remarks>
    /// <code><![CDATA[
    /// Pattern: data-include="(?<path>[^"\s]+\.html)"
    /// ]]></code>
    /// 
    /// Schritt-für-Schritt-Erklärung:
    /// 1. data-include="   sucht exakt nach dem Attribut data-include= und dem öffnenden Anführungszeichen
    /// 2. (?{path} ...)    benannte Capture-Group "path" zum Extrahieren des Wertes
    /// 3. [^"\s]+          ein oder mehr Zeichen, die NICHT (^) Anführungszeichen (") oder Whitespace (\s) sind
    ///                     => erfasst den Dateipfad bis zum schließenden Anführungszeichen
    /// 4. \.html           verlangt ".html" als Dateiendung (\ escaped den Punkt)
    /// 5. "                abschließendes Anführungszeichen
    /// 
    /// Beispiel: data-include="content/views/xyz.html"
    /// Treffer: Group "path" = "content/views/xyz.html"
    /// </remarks>
    [GeneratedRegex($@"data-include=""(?<{REGEX_GRUPPEN_NAME}>[^""\s]+\.html)""")]
    private static partial Regex DataIncludeRegex(); // partial: Compiler generiert Implementierung
    
    /// <summary>
    /// Extrahiert alle Links aus der 'index.html'.
    /// </summary>
    /// <param name="indexHtmlPfad">Pfad zur 'index.html'</param>
    /// <returns>
    /// List der gefundenen HTML-Links
    /// </returns>
    /// <remarks>
    /// Man sucht nach etwas wie:
    /// <section data-include="content/views/xyz.html"></section>
    /// </remarks>
    internal static List<string> Extract(string indexHtmlPfad)
    {
        string ordnerPfad = Path.GetDirectoryName(indexHtmlPfad)!;
        
        // lese index.html vollständig ein
        string htmlCode = File.ReadAllText(indexHtmlPfad, Encoding.UTF8);
        
        List<string> pfade = [];
        Regex regex = DataIncludeRegex();

        // läuft über alle Treffer im HTML-Code
        foreach (Match treffer in regex.Matches(htmlCode))
        {
            // extrahiert Link aus Gruppe
            string relativerLink = treffer
                .Groups[REGEX_GRUPPEN_NAME]
                .Value.Trim();
            
            // ermittelt absoluten Pfad
            string absoluterPfad = Path.GetFullPath(Path.Combine(ordnerPfad, relativerLink));
            pfade.Add(absoluterPfad);
        }

        return pfade;
    }
    
}