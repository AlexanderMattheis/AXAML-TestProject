using System.Threading.Tasks;

namespace TextExtractorGUI.Services;

/// <summary>
/// Interface für Datei-Dialoge-Services.
/// </summary>
public interface IFileDialogService
{
    /// <summary>
    /// Erlaubt die Selektion der index.html-Datei.
    /// </summary>
    /// <returns>Task mit Pfad zur index.html-Datei</returns>
    Task<string?> PickIndexHtmlAsync();
    
    /// <summary>
    /// Erlaubt die Selektion des Ausgabepfades für die Markdown-Datei.
    /// </summary>
    /// <param name="dateiname"></param>
    /// <returns>Task mit Pfad zur Ausgabe-Datei</returns>
    Task<string?> PickOutputMarkdownAsync(string? dateiname = null);
}